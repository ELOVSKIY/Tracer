using Tracer.Results;
using Tracer.Serializer;
using Xunit;

namespace Tracer.Tests.Serializer
{
    public class JsonSerializerTest
    {
        private JsonTraceResultSerializer _jsonTraceResultSerializer;
        private const string SerializedResult = "{\"threads\":[]}";
        
        private void SetUp()
        {
            _jsonTraceResultSerializer = new JsonTraceResultSerializer();
        }

        [Fact]
        public void TestSerialize()
        {
            SetUp();
            var traceResult = new TraceResult();
            var result = _jsonTraceResultSerializer.Serialize(traceResult);
            Assert.Equal(SerializedResult, result);
        }
    }
}