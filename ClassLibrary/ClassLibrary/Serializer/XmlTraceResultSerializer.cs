using Tracer.Results;


namespace Tracer.Serializer
{
    public class XmlTraceResultSerializer : ITraceResultSerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var serializer = XSerializer.XmlSerializer.Create(traceResult.GetType());
            return serializer.Serialize(traceResult);
        }
    }
}