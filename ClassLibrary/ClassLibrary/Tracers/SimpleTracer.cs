using System;
using System.Collections.Generic;
using System.Threading;
using Tracer.Results;

namespace Tracer.Tracers
{
    public class SimpleTracer : ITracer
    {

        private readonly IDictionary<long, ThreadTracer> ThreadTracers;

        public SimpleTracer()
        {
            ThreadTracers = new Dictionary<long, ThreadTracer>();
        }

        public void StartTrace()
        {
            var threadId = GetCurrentThreadId();
            if (ThreadTracers.ContainsKey(threadId))
            {
                var threadTracer = ThreadTracers[threadId];
                threadTracer.StartTrace();
            }
            else
            {
                var threadTracer = new ThreadTracer();
                ThreadTracers.Add(threadId, threadTracer);
                threadTracer.StartTrace();
            }
        }

        public void StopTrace()
        {
            var threadId = GetCurrentThreadId();
            if (ThreadTracers.ContainsKey(threadId))
            {
                var threadTracer = ThreadTracers[threadId];
                threadTracer.StopTrace();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public TraceResult GetTraceResult()
        {
            throw new NotImplementedException();
        }

        private long GetCurrentThreadId()
        {
            var thread = Thread.CurrentThread;
            return thread.ManagedThreadId;
        }
    }
}
