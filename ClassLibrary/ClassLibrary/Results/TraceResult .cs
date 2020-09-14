using System.Collections.Generic;

namespace Tracer.Results
{
    public class TraceResult
    {

        private readonly List<ThreadTraceResult> _threadTraceResults;

        public TraceResult()
        {
            _threadTraceResults = new List<ThreadTraceResult>();
        }

        public void AddThreadTraceResult(ThreadTraceResult threadTraceResult)
        {
            _threadTraceResults.Add(threadTraceResult);
        }

        public List<ThreadTraceResult> GetThreadTraceResults()
        {
            return _threadTraceResults;
        }
    }
}
