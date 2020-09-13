using System.Collections.Generic;

namespace Tracer.Results
{
    public class MethodTraceResult : IResult
    {
        private long Duration = 0;

        private readonly string MethodName;

        private readonly string ClassName;

        private readonly List<MethodTraceResult> InnerMethodTraceResults;

        public MethodTraceResult(string className, string methodName)
        {
            ClassName = className;
            MethodName = methodName;
            InnerMethodTraceResults = new List<MethodTraceResult>();
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
