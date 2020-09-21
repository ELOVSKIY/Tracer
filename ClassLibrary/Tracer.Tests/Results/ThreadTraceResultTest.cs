using Tracer.Results;
using Xunit;

namespace Tracer.Tests.Results
{
    public class ThreadTraceResultTest
    {
        private const long ThreadId = 1L;
        private const long Duration = 1L;

        private MethodTraceResult _methodTraceResult;
        private ThreadTraceResult _threadTraceResult;

        private void SetUp()
        {
            _threadTraceResult = new ThreadTraceResult(ThreadId);
            _methodTraceResult = new MethodTraceResult("class_name", "method_name") {Duration = Duration};
            _threadTraceResult.AddMethodTraceResult(_methodTraceResult);
        }

        [Fact]
        private void TestGetThreadId()
        {
            SetUp();
            var actual = _threadTraceResult.ThreadId;
            Assert.Equal(ThreadId, actual);
        }
        
        [Fact]
        private void TestGetDuration()
        {
            SetUp();
            var actual = _threadTraceResult.Duration;
            Assert.Equal(Duration, actual);
        }

        public void TestGetMethodTraceResult()
        {
            SetUp();
            var actual = _methodTraceResult.InnerMethodTraceResults[0];
            Assert.Equal(_methodTraceResult, actual);
        }
    }
}