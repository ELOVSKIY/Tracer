using System;
using System.Collections.Generic;
using Tracer.Results;

namespace Tracer.Tracers
{
    public class MethodTracer
    {

        private readonly Stack<MethodTracer> _innerMethodTracers;

        private MethodTraceResult _methodTraceResult;

        private long _startTime = 0;
        private bool _isActive = false;

        public MethodTracer()
        {
            _innerMethodTracers = new Stack<MethodTracer>();
        }

        public void StartTrace(string className, string methodName)
        {
            if (!_isActive)
            {
                _isActive = true;
                _startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                _methodTraceResult = new MethodTraceResult(className, methodName);
            }
            else
            {
                MethodTracer innerMethodTracer;
                if (_innerMethodTracers.Count == 0)
                {
                   innerMethodTracer = new MethodTracer();
                   _innerMethodTracers.Push(innerMethodTracer);
                }
                else
                {
                    innerMethodTracer = _innerMethodTracers.Peek();
                }
                innerMethodTracer.StartTrace(className, methodName);
            }
        }

        public void StopTrace()
        {
            if (_isActive)
            {
                if (_innerMethodTracers.Count == 0)
                {
                    var innerMethodTracer = _innerMethodTracers.Pop();
                    innerMethodTracer.StopTrace();
                    var innerMethodTraceResult = innerMethodTracer.GetTraceResult();
                    _methodTraceResult.AddInnerMethodTraceResult(innerMethodTraceResult);
                }
                else
                {
                    var endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    var duration = endTime - _startTime;
                    _methodTraceResult.SetDuration(duration);
                    _isActive = false;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public MethodTraceResult GetTraceResult()
        {
            return _methodTraceResult;
        }
    }
}
