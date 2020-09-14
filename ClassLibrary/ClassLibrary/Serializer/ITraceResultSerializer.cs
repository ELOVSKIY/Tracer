using Tracer.Results;

namespace Tracer.Serializer
{
    public interface ITraceResultSerializer
    {
        string Serialize(TraceResult traceResult);
    }
}