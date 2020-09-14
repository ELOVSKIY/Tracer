using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tracer.Results
{
    public class ThreadTraceResult : IResult
    {
        public List<MethodTraceResult> MethodTraceResults { get; }

        public long ThreadId { get; }
       
        public long Duration { get; private set; }

        public ThreadTraceResult(long threadId)
        {
            ThreadId = threadId;
            MethodTraceResults = new List<MethodTraceResult>();
        }

        public ThreadTraceResult()
        {
            throw new SerializationException();
        }

        public void SetDuration(long duration)
        {
            Duration = duration;
        }

        public long GetDuration()
        {
            return Duration;
        }

        public long GetThreadId()
        {
            return ThreadId;
        }

        public void AddMethodTraceResult(MethodTraceResult methodTraceResult)
        {
            MethodTraceResults.Add(methodTraceResult);
        }

        public List<MethodTraceResult> GetMethodTraceResults()
        {
            return MethodTraceResults;
        }
    }
}
