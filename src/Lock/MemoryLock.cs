using System;
using System.Collections.Generic;

namespace PipServices.Components.Lock
{
    public class MemoryLock: Lock
    {
        private Dictionary<string, long> _locks = new Dictionary<string, long>();

        public override bool TryAcquireLock(string correlationId, string key, long ttl)
        {
            var now = Environment.TickCount;

            lock (_locks)
            {
                long expireTime;

                if (_locks.TryGetValue(key, out expireTime))
                {
                    if (expireTime > now) return false;
                }

                expireTime = now + ttl;
                _locks[key] = expireTime;
            }

            return true;
        }

        public override void ReleaseLock(string correlationId, string key)
        {
            lock (_locks)
            {
                _locks.Remove(key);
            }
        }
    }
}
