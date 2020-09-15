using Tracer.Results;
using XSerializer;


namespace Tracer.Serializer
{
    public class XmlTraceResultSerializer : ITraceResultSerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var serializer = XmlSerializer.Create(traceResult.GetType());
            return serializer.Serialize(traceResult);
        }
    }
}