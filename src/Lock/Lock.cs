using System;
using System.Threading;

using PipServices.Commons.Config;
using PipServices.Commons.Errors;

namespace PipServices.Components.Lock
{
    public abstract class Lock: ILock, IReconfigurable
    {
        private int _retryTimeout = 100;

        public virtual void Configure(ConfigParams config)
        {
            _retryTimeout = config.GetAsIntegerWithDefault("options.retry_timeout", _retryTimeout);
        }

        public abstract bool TryAcquireLock(string correlationId, string key, long ttl);

        public abstract void ReleaseLock(string correlationId, string key);
                
        public void AcquireLock(string correlationId, string key, long ttl, long timeout)
        {
            var expireTime = Environment.TickCount + timeout;

            // Repeat until time expires
            do
            {
                // Try to get lock first
                if (TryAcquireLock(correlationId, key, ttl))
                    return;

                // Sleep 
                Thread.Sleep(_retryTimeout);

            } while (Environment.TickCount < expireTime);

            // Throw exception
            throw new ConflictException(
                correlationId,
                "LOCK_TIMEOUT",
                "Acquiring lock " + key + " failed on timeout"
            ).WithDetails("key", key);
        }
    }
}
