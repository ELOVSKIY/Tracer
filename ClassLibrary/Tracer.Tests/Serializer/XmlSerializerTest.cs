using Tracer.Results;
using Tracer.Serializer;
using Tracer.Tracers;
using Xunit;

namespace Tracer.Tests.Serializer
{
    public class XmlSerializerTest
    {
        private XmlTraceResultSerializer _xmlTraceResultSerializer;
        private const string SerializedResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?><TraceResult xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" />";

        private void SetUp()
        {
            _xmlTraceResultSerializer = new XmlTraceResultSerializer();
        }
        
        [Fact]
        public void TestSerialize()
        {
            SetUp();
            var traceResult = new TraceResult();
            var result = _xmlTraceResultSerializer.Serialize(traceResult);
            Assert.Equal(SerializedResult, result);
        }
    }
}