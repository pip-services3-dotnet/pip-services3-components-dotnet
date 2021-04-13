using PipServices3.Components.Log;
using PipServices3.Commons.Config;
using PipServices3.Commons.Refer;
using Xunit;

namespace PipServices3.Components.Count
{
    //[TestClass]
    public sealed class LogCountersTest
    {
        private readonly LogCounters _counters = new LogCounters();
        private readonly CountersFixture _fixture;

        public LogCountersTest()
        {
            var log = new ConsoleLogger();
            var refs = References.FromTuples(
                new Descriptor("pip-services", "logger", "null", "default", "1.0"), log
            );

            _counters.SetReferences(refs);

            _fixture = new CountersFixture(_counters);
        }

        [Fact]
        public void TestSimpleCounters()
        {
            _fixture.TestSimpleCounters();
        }

        [Fact]
        public void TestMeasureElapsedTime()
        {
            _fixture.TestMeasureElapsedTime();
        }
    }
}
