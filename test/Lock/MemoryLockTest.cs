using System;
using Xunit;

namespace PipServices3.Components.Lock
{
    //[TestClass]
    public class MemoryLockTest
    {
        private MemoryLock _lock;
        private LockFixture _fixture;

        public MemoryLockTest()
        {
            _lock = new MemoryLock();
            _fixture = new LockFixture(_lock);
        }

        [Fact]
        public void TestTryAcquireLock()
        {
            _fixture.TestTryAcquireLock();
        }

        [Fact]
        public void TestAcquireLock()
        {
            _fixture.TestAcquireLock();
        }

        [Fact]
        public void TestReleaseLock()
        {
            _fixture.TestReleaseLock();
        }

        [Fact]
        public void TestIsLock()
        {
            _fixture.TestIsLock();
        }
    }
}
