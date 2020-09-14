using System.IO;
using Tracer.Results;

namespace Tracer.Serializer
{
    public abstract class TraceResultSerializer : ITraceResultSerializer
    {
        protected TextWriter _writer;
        
        public TraceResultSerializer(TextWriter writer)
        {
            _writer = writer;
        }

        public abstract void Serialize(TraceResult traceResult);
    }
}