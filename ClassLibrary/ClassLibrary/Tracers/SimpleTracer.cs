using System;
using System.Collections.Generic;
using System.Threading;
using Tracer.Results;

namespace Tracer.Tracers
{
    public class SimpleTracer : ITracer
    {

        private TraceResult _traceResult;
        
        private readonly IDictionary<long, ThreadTracer> _threadTracers;

        public SimpleTracer()
        {
            _traceResult = new TraceResult();
            _threadTracers = new Dictionary<long, ThreadTracer>();
        }

        public void StartTrace()
        {
            var threadId = GetCurrentThreadId();
            if (_threadTracers.ContainsKey(threadId))
            {
                var threadTracer = _threadTracers[threadId];
                threadTracer.StartTrace();
            }
            else
            {
                var threadTracer = new ThreadTracer();
                _threadTracers.Add(threadId, threadTracer);
                threadTracer.StartTrace();
            }
        }

        public void StopTrace()
        {
            var threadId = GetCurrentThreadId();
            if (_threadTracers.ContainsKey(threadId))
            {
                var threadTracer = _threadTracers[threadId];
                threadTracer.StopTrace();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public TraceResult GetTraceResult()
        {
            foreach (var threadTracerPair in _threadTracers)
            {
                var threadTracer = threadTracerPair.Value;
                var threadTraceResult = threadTracer.GetTraceResult();
                _traceResult.AddThreadTraceResult(threadTraceResult);
            }
            return _traceResult;
        }

        private long GetCurrentThreadId()
        {
            var thread = Thread.CurrentThread;
            return thread.ManagedThreadId;
        }
    }
}
