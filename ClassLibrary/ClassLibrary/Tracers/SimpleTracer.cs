using System;
using System.Collections.Generic;
using System.Threading;
using Tracer.Results;

namespace Tracer.Tracers
{
    public class SimpleTracer : ITracer
    {
        private static readonly object Lock = new object();

        private TraceResult TraceResult { get; }

        private Dictionary<long, ThreadTracer> ThreadTracers { get; }

        public SimpleTracer()
        {
            TraceResult = new TraceResult();
            ThreadTracers = new Dictionary<long, ThreadTracer>();
        }

        public void StartTrace()
        {
            lock (Lock)
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
        }

        public void StopTrace()
        {
            lock (Lock)
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
        }

        public TraceResult GetTraceResult()
        {
            foreach (var threadTracerPair in ThreadTracers)
            {
                var threadTracer = threadTracerPair.Value;
                var threadTraceResult = threadTracer.ThreadTraceResult;
                TraceResult.AddThreadTraceResult(threadTraceResult);
            }

            return TraceResult;
        }

        private long GetCurrentThreadId()
        {
            var thread = Thread.CurrentThread;
            return thread.ManagedThreadId;
        }
    }
}