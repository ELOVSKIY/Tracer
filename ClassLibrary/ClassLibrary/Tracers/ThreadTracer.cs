using System;
using System.Diagnostics;
using System.Threading;
using Tracer.Results;

namespace Tracer.Tracers
{
    public class ThreadTracer
    {
        public ThreadTraceResult ThreadTraceResult { get; }
        private MethodTracer _currentMethodTracer;

        public ThreadTracer()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            ThreadTraceResult = new ThreadTraceResult(threadId);
        }

        public void StartTrace()
        {
            var stackTrace = new StackTrace(true);
            var frame = stackTrace.GetFrame(2);
            var method = frame.GetMethod();
            var methodName = method.Name;
            var className = method.DeclaringType.FullName;
            if (_currentMethodTracer == null)
            {
                _currentMethodTracer = new MethodTracer();
            }
            _currentMethodTracer.StartTrace(className, methodName);
        }

        public void StopTrace()
        {
            if (_currentMethodTracer != null)
            {
                _currentMethodTracer.StopTrace();
                if (!_currentMethodTracer.IsActive())
                {
                    var methodTraceResult = _currentMethodTracer.GetTraceResult();
                    ThreadTraceResult.AddMethodTraceResult(methodTraceResult);
                    _currentMethodTracer = null;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
