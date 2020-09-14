using System;
using System.Collections.Generic;

namespace Tracer.Results
{
    public class TraceResult
    {

        public List<ThreadTraceResult> ThreadTraceResults { get; }

        public TraceResult()
        {
            ThreadTraceResults = new List<ThreadTraceResult>();
        }

        public void AddThreadTraceResult(ThreadTraceResult threadTraceResult)
        {
            ThreadTraceResults.Add(threadTraceResult);
        }
    }
}
