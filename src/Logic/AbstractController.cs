using System;
using System.Threading.Tasks;

using PipServices3.Components.Cache;
using PipServices3.Commons.Config;
using PipServices3.Components.Count;
using PipServices3.Components.Log;
using PipServices3.Commons.Refer;

namespace PipServices3.Components.Logic
{
    public abstract class AbstractController : IConfigurable, IReferenceable
    {
        protected DependencyResolver _dependencyResolver = new DependencyResolver();
        protected CompositeLogger _logger = new CompositeLogger();
        protected CompositeCounters _counters = new CompositeCounters();
        protected ICache _cache = new NullCache();

        public abstract string Component { get; }

        public virtual void Configure(ConfigParams config)
        {
            _dependencyResolver.Configure(config);
        }

        public virtual void SetReferences(IReferences references)
        {
            _dependencyResolver.SetReferences(references);
            _logger.SetReferences(references);
            _counters.SetReferences(references);
        }

        #region Instrumentation Methods

        protected virtual CounterTiming Instrument(string correlationId, string methodName, string message = "")
        {
            _logger.Trace(correlationId, "Executed {0}.{1} {2}", Component, methodName, message);
            return _counters.BeginTiming(Component + "." + methodName + ".exec_time");
        }

        protected virtual void HandleError(string correlationId, string methodName, Exception ex)
        {
            _logger.Error(correlationId, ex, "Failed to execute {0}.{1}", Component, methodName);
        }

        protected async Task<T> SafeInvokeAsync<T>(string correlationId, string methodName, Func<Task<T>> invokeFunc, bool throwException = false)
        {
            return await SafeInvokeAsync<T>(correlationId, methodName, invokeFunc, null, throwException);
        }

        protected async Task<T> SafeInvokeAsync<T>(string correlationId, string methodName, Func<Task<T>> invokeFunc, Func<Task<T>> errorHandlerFunc, bool throwException = false)
        {
            using (var timing = Instrument(correlationId, methodName))
            {
                try
                {
                    return await invokeFunc();
                }
                catch (Exception ex)
                {
                    HandleError(correlationId, methodName, ex);

                    if (errorHandlerFunc != null)
                    {
                        return await errorHandlerFunc();
                    }

                    if (throwException)
                    {
                        throw ex;
                    }
                }

                return await Task.FromResult(default(T));
            }
        }

        #endregion

        #region Cache Methods

        protected virtual async Task<T> RetrieveFromCacheAsync<T>(string correlationId, string cacheKey)
        {
            return await _cache.RetrieveAsync<T>(correlationId, cacheKey);
        }

        protected virtual async Task<T> StoreInCacheAsync<T>(string correlationId, string cacheKey, T result)
        {
            return await _cache.StoreAsync(correlationId, cacheKey, result, 0);
        }

        protected virtual async Task RemoveFromCacheAsync(string correlationId, string id)
        {
            var cacheKey = GetCacheKey(id);
            await _cache.RemoveAsync(correlationId, cacheKey);

            cacheKey = GetProjectionCacheKey(id);
            await _cache.RemoveAsync(correlationId, cacheKey);
        }

        protected virtual string GetProjectionCacheKey(string id)
        {
            return $"{Component}.{id}.Projection";
        }

        protected virtual string GetCacheKey(string id)
        {
            return $"{Component}.{id}";
        }

        #endregion

        #region Audit Methods

        protected virtual async Task AuditCreateAsync<T>(string correlationId, string collectionName, object createdObject, Func<Task<T>> auditFunc)
        {
            if (createdObject == null)
            {
                _logger.Error(correlationId, $"Unable to audit create null object for collection '{collectionName}'.");
                return;
            }

            await SafeAuditAsync(correlationId, "AuditCreateAsync", auditFunc);
        }

        protected virtual async Task AuditUpdateAsync<T>(string correlationId, string collectionName, object oldObject, object updatedObject, Func<Task<T>> auditFunc)
        {
            if (oldObject == null || updatedObject == null)
            {
                _logger.Error(correlationId, $"Unable to audit update of null object for collection '{collectionName}'.");
                return;
            }

            await SafeAuditAsync(correlationId, "AuditUpdateAsync", auditFunc);
        }

        protected virtual async Task AuditDeleteAsync<T>(string correlationId, string collectionName, object deletedObject, Func<Task<T>> auditFunc)
        {
            if (deletedObject == null)
            {
                _logger.Error(correlationId, $"Unable to audit delete of null object for collection '{collectionName}'.");
                return;
            }

            await SafeAuditAsync(correlationId, "AuditDeleteAsync", auditFunc);
        }

        private async Task<T> SafeAuditAsync<T>(string correlationId, string methodName, Func<Task<T>> auditFunc)
        {
            using (var timing = Instrument(correlationId, methodName))
            {
                try
                {
                    return await auditFunc();
                }
                catch (Exception ex)
                {
                    HandleError(correlationId, methodName, ex);
                }

                return await Task.FromResult(default(T));
            }
        }

        #endregion

    }
}
