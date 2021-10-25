using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PipServices3.Components.State
{
    public class MemoryStateStoreTest
    {
        private MemoryStateStore _cache;
        private StateStoreFixture _fixture;

        public MemoryStateStoreTest()
        {
            _cache = new MemoryStateStore();
            _fixture = new StateStoreFixture(_cache);
        }

        [Fact]
        public void TestSaveAndLoad()
        {
            _fixture.TestSaveAndLoad();
        }

        [Fact]
        public void TestDelete()
        {
            _fixture.TestDelete();
        }
    }
}
