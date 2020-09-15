using System.Collections.Generic;
using System.Xml.Serialization;
using XSerializer;

namespace Tracer.Results
{
    public class MethodTraceResult
    {
        [JsonProperty("duration")]
        [XmlElement("duration")]
        public long Duration { get; set; }

        [JsonProperty("name")]
        [XmlElement("name")]
        public string MethodName { get; }

        [JsonProperty("class")]
        [XmlElement("class")]
        public string ClassName { get; }

        [JsonProperty("methods")]
        [XmlElement("methods")]
        public List<MethodTraceResult> InnerMethodTraceResults { get; }

        public MethodTraceResult(string className, string methodName)
        {
            Duration = 0;
            ClassName = className;
            MethodName = methodName;
            InnerMethodTraceResults = new List<MethodTraceResult>();
        }

        public void AddInnerMethodTraceResult(MethodTraceResult innerMethodTraceResult)
        {
            InnerMethodTraceResults.Add(innerMethodTraceResult);
        }

    }
}
