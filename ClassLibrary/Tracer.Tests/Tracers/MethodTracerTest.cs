using System;
using Tracer.Tracers;
using Xunit;

namespace Tracer.Tests.Tracers
{
    public class MethodTracerTest
    {
        
        private const string ClassName = "class_name";
        private const string MethodName = "method_name";
        private const string InnerClassName = "inner_method_name";
        private const string InnerMethodName = "inner_method_name";
        
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

        [Fact]
        public void TestIsAlive()
        {
            SetUp();
            _methodTracer.StartTrace(ClassName, MethodName);
            _methodTracer.StartTrace(InnerClassName, InnerMethodName);
            _methodTracer.StopTrace();
            Assert.True(_methodTracer.IsActive());
            _methodTracer.StopTrace();
            Assert.False(_methodTracer.IsActive());
        }
        
        [Fact]
        public void TestInnerMethodStartTrace()
        {
            SetUp();
            _methodTracer.StartTrace(ClassName, MethodName);
            _methodTracer.StartTrace(InnerClassName, InnerMethodName);
            _methodTracer.StartTrace("InnerClassName", "InnerMethodName");
            _methodTracer.StopTrace();
            _methodTracer.StopTrace();
            _methodTracer.StopTrace();
            Assert.False(_methodTracer.IsActive());
        }

        [Fact]
        public void TestMethodTraceResult()
        {
            SetUp();
            _methodTracer.StartTrace(ClassName, MethodName);
            _methodTracer.StartTrace(InnerClassName, InnerMethodName);
            _methodTracer.StopTrace();
            _methodTracer.StopTrace();
            var methodTraceResult = _methodTracer.GetTraceResult();
            Assert.Equal(ClassName, methodTraceResult.ClassName);
            Assert.Equal(MethodName, methodTraceResult.MethodName);
            var innerMethodTraceResult = methodTraceResult.InnerMethodTraceResults[0];
            Assert.Equal(InnerClassName, innerMethodTraceResult.ClassName);
            Assert.Equal(InnerMethodName, innerMethodTraceResult.MethodName);
        }
    }
}
