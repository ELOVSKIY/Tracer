using System.Collections.Generic;

namespace Tracer.Results
{
    public class ThreadTraceResult : IResult
    {
        private readonly List<MethodTraceResult> _methodTraceResults;

        private readonly long _threadId;
       
        private long _duration;

        public ThreadTraceResult(long threadId)
        {
            _threadId = threadId;
            _methodTraceResults = new List<MethodTraceResult>();
        }

        public void SetDuration(long duration)
        {
            _duration = duration;
        }

        public long GetDuration()
        {
            return _duration;
        }

        public long GetThreadId()
        {
            return _threadId;
        }

        public void AddMethodTraceResult(MethodTraceResult methodTraceResult)
        {
            _methodTraceResults.Add(methodTraceResult);
        }

        public List<MethodTraceResult> GetMethodTraceResults()
        {
            return _methodTraceResults;
        }
    }
}
