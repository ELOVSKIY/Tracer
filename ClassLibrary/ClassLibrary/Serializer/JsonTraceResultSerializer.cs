using Tracer.Results;
using System.Text.Json;

namespace Tracer.Serializer
{
    public class JsonTraceResultSerializer : ITraceResultSerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            return JsonSerializer.Serialize(traceResult);
        }
    }
}