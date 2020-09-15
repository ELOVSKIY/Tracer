using System.Collections.Generic;
using System.Xml.Serialization;
using XSerializer;

namespace Tracer.Results
{
    public class TraceResult
    {
        [JsonProperty("threads")]
        [XmlElement("threads")]
        public List<ThreadTraceResult> ThreadTraceResults { get; }

        public TraceResult()
        {
            ThreadTraceResults = new List<ThreadTraceResult>();
        }

        public void AddThreadTraceResult(ThreadTraceResult threadTraceResult)
        {
            ThreadTraceResults.Add(threadTraceResult);
        }
    }
}
