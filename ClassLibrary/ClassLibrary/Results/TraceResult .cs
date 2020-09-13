using System.Collections.Generic;

namespace Tracer.Results
{
    public class TraceResult
    {

        private readonly List<ThreadTraceResult> ThreadTraceResults;

        public TraceResult()
        {
            ThreadTraceResults = new List<ThreadTraceResult>();
        }

        public List<ThreadTraceResult> GetThreadTraceResults()
        {
            return ThreadTraceResults;
        }
    }
}
