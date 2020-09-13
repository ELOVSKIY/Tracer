using Tracer.Results;

namespace Tracer.Tracers
{
    public interface ITracer
    {
        void StartTrace();

        void StopTrace();

        TraceResult GetTraceResult();
    }
}
