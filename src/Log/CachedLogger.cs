using System;
using System.Collections.Generic;
using PipServices.Commons.Config;
using PipServices.Commons.Errors;

namespace PipServices.Components.Log
{
    public abstract class CachedLogger : Logger, IReconfigurable
    {
        protected List<LogMessage> _cache = new List<LogMessage>();
        protected bool _updated = false;
        protected long _lastDumpTime = Environment.TickCount;
        protected int _maxCacheSize = 100;
        protected int _interval = 10000;
        protected object _lock = new object();
        
        protected override void Write(LogLevel level, string correlationId, Exception error, string message)
        {
            ErrorDescription errorDescription = error != null ? ErrorDescriptionFactory.Create(error, correlationId) : null;
            LogMessage logMessage = new LogMessage()
            {
                Time = DateTime.UtcNow,
                Level = LogLevelConverter.ToString(level),
                Source = _source,
                Error = errorDescription,
                Message = message,
                CorrelationId = correlationId
            };

            lock (_lock)
            {
                _cache.Add(logMessage);
            }

            Update();
        }

        protected abstract void Save(List<LogMessage> messages);

        public override void Configure(ConfigParams config)
        {
            base.Configure(config);

            _interval = config.GetAsIntegerWithDefault("options.interval", _interval);
            _maxCacheSize = config.GetAsIntegerWithDefault("options.max_cache_size", _maxCacheSize);
        }

        public void Clear()
        {
            lock (_lock)
            {
                _cache = new List<LogMessage>();
            }
            _updated = false;
        }

        public void Dump()
        {
            if (_updated)
            {
                if (!_updated) return;

                List<LogMessage> messages;

                lock (_lock)
                {
                    messages = _cache;
                    _cache = new List<LogMessage>();
                }

                try
                {
                    Save(messages);
                }
                catch (Exception ex)
                {
                    lock (_lock)
                    {
                        // Put failed messages back to cache
                        messages.AddRange(_cache);
                        _cache = messages;

                        // Truncate cache to max size
                        while (_cache.Count > _maxCacheSize)
                            _cache.RemoveAt(0);
                    }

                    throw ex;
                }
                finally
                {
                    _updated = false;
                    _lastDumpTime = Environment.TickCount;
                }
            }
        }

        protected void Update()
        {
            _updated = true;

            var now = Environment.TickCount;

            if (now > _lastDumpTime + _interval)
            {
                try
                {
                    Dump();
                }
                catch (Exception)
                {
                    // Todo: decide what to do
                }
            }
        }
    }
}
