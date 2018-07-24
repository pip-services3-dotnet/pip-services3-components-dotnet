using System;

namespace PipServices.Components.Lock
{
    public interface ILock
    {
        bool TryAcquireLock(string correlationId, string key, long ttl);
    
        void AcquireLock(string correlationId, string key, long ttl, long timeout);

        void ReleaseLock(string correlationId, string key);
    }
}
