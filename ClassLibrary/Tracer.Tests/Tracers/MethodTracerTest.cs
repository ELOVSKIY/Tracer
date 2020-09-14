using System;
using Tracer.Tracers;
using Xunit;

namespace Tracer.Tests.Tracers
{
    public class MethodTracerTest
    {
        private MethodTracer _methodTracer;

        private void SetUp()
        {
            _methodTracer = new MethodTracer();
        }

        [Fact]
        public void TestInvalidStopTrace()
        {
            SetUp();
            Assert.Throws<InvalidOperationException> (_methodTracer.StopTrace);
           
        }
    }
}
