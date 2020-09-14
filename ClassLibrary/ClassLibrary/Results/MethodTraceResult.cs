using System.Collections.Generic;
using System.Security;

namespace Tracer.Results
{
    public class MethodTraceResult : IResult
    {
        public long Duration { get; private set; }

        public string MethodName { get; }

        public string ClassName { get; }

        public List<MethodTraceResult> InnerMethodTraceResults { get; }

        public MethodTraceResult(string className, string methodName)
        {
            Duration = 0;
            ClassName = className;
            MethodName = methodName;
            InnerMethodTraceResults = new List<MethodTraceResult>();
        }

        public MethodTraceResult()
        {
            throw new SecurityException();
        }

        public long GetDuration()
        {
            return Duration;
        }

        public string GetMethodName()
        {
            return MethodName;
        }

        public string GetClassName()
        {
            return ClassName;
        }

        public void SetDuration(long duration)
        {
            Duration = duration;
        }

        public void AddInnerMethodTraceResult(MethodTraceResult innerMethodTraceResult)
        {
            InnerMethodTraceResults.Add(innerMethodTraceResult);
        }

    }
}
