using System;
using Tracer.Tracers;
using Xunit;

namespace Tracer.Tests.Tracers
{
    public class SimpleTracerTest
    {
        private SimpleTracer _simpleTracer;

        private void SetUp()
        {
            _simpleTracer = new SimpleTracer();
        }

        [Fact]
        public void TestInvalidStopTrace()
        {
            SetUp();
            Assert.Throws<InvalidOperationException> (_simpleTracer.StopTrace);
        }

        [Fact]
        public void TestGetTraceResult()
        {
            SetUp();
            _simpleTracer.StartTrace();
            _simpleTracer.StartTrace();
            _simpleTracer.StopTrace();
            _simpleTracer.StopTrace();
            var traceResult = _simpleTracer.GetTraceResult();
            Assert.NotNull(traceResult);
        }

    }
}