using System.Collections.Generic;
using System.Xml.Serialization;
using XSerializer;

namespace Tracer.Results
{
    public class ThreadTraceResult
    {
        [JsonProperty("id")]
        [XmlElement("id")]
        public long ThreadId { get; }
        
        [JsonProperty("duration")]
        [XmlElement("duration")]
        public long Duration { get; set; }
        
        [JsonProperty("methods")]
        [XmlElement("methods")] 
        public List<MethodTraceResult> MethodTraceResults { get; }

        public ThreadTraceResult(long threadId)
        {
            ThreadId = threadId;
            MethodTraceResults = new List<MethodTraceResult>();
        }

        public void AddMethodTraceResult(MethodTraceResult methodTraceResult)
        {
            MethodTraceResults.Add(methodTraceResult);
        }
    }
}