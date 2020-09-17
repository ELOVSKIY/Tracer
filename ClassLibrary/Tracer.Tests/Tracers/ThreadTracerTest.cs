using System;
using Tracer.Tracers;
using Xunit;

namespace Tracer.Tests.Tracers
{
    public class ThreadTracerTest
    {
        private ThreadTracer _threadTracer;

        private void SetUp()
        {
            _threadTracer = new ThreadTracer();
        }
        
        [Fact]
        public void TestInvalidStopTrace()
        {
            SetUp();
            Assert.Throws<InvalidOperationException> (_threadTracer.StopTrace);
           
        }

        [Fact]
        public void TestThreadTrace()
        {
            SetUp();
            _threadTracer.StartTrace();
            _threadTracer.StopTrace();
            var threadTraceResult = _threadTracer.ThreadTraceResult;
            Assert.NotEmpty(threadTraceResult.MethodTraceResults);
        }
    }
}