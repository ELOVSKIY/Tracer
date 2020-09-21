using Tracer.Results;
using Xunit;

namespace Tracer.Tests.Results
{
    public class MethodTraceResultTest
    {
        private MethodTraceResult _methodTraceResult;

        private const string ClassName = "class_name";
        private const string MethodName = "method_name";
        private const long Duration = 500L;

        private void SetUp()
        {
            _methodTraceResult = new MethodTraceResult(ClassName, MethodName);
        }

        [Fact]
        public void TestGetMethodName()
        {
            SetUp();
            var actual = _methodTraceResult.MethodName;
            Assert.Equal(MethodName, actual);
        }
        
        [Fact]
        public void TestGetClassName()
        {
            SetUp();
            var actual = _methodTraceResult.ClassName;
            Assert.Equal(ClassName, actual);
        }
        
        [Fact]
        public void TestGetDuration()
        {
            SetUp();
            _methodTraceResult.Duration = Duration;
            var actual = _methodTraceResult.Duration;
            Assert.Equal(Duration, actual);
        }
    }
}