using PipServices3.Commons.Refer;
using PipServices3.Components.Log;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PipServices3.Components.Trace
{
    public sealed class LogTracerTest
    {
        LogTracer _tracer;

        public LogTracerTest()
        {
            _tracer = new LogTracer();
            _tracer.SetReferences(References.FromTuples(
                new Descriptor("pip-services", "logger", "null", "default", "1.0"), new NullLogger()
            ));
        }

        [Fact]
        public void TestSimpleTracing()
        {
            _tracer.Trace("123", "mycomponent", "mymethod", 123456);
            _tracer.Failure("123", "mycomponent", "mymethod", new Exception("Test error"), 123456);
        }

        [Fact]
        public void TestTraceTiming()
        {
            var timing = _tracer.BeginTrace("123", "mycomponent", "mymethod");
            timing.EndTrace();

            timing = _tracer.BeginTrace("123", "mycomponent", "mymethod");
            timing.EndFailure(new Exception("Test error"));
        }
    }
}
