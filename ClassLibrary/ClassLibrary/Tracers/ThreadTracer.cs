using System;
using System.Diagnostics;
using System.Threading;
using Tracer.Results;

namespace Tracer.Tracers
{
    internal class ThreadTracer
    {
        private readonly ThreadTraceResult _threadTraceResult;
        private MethodTracer _currentMethodTracer;

        internal ThreadTracer()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            _threadTraceResult = new ThreadTraceResult(threadId);
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
                    _threadTraceResult.AddMethodTraceResult(methodTraceResult);
                    _currentMethodTracer = null;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public ThreadTraceResult GetTraceResult()
        {
            return _threadTraceResult;
        }
    }
}
