using System;
namespace PipServices.Components.Lock
{
    public class NullLock : ILock
    {
        public void AcquireLock(string correlationId, string key, long ttl, long timeout)
        {}

        public void ReleaseLock(string correlationId, string key)
        {}

        public bool TryAcquireLock(string correlationId, string key, long ttl)
        {
            return true;
        }
    }
}
