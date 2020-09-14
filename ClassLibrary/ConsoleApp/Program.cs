using System;
using Tracer.Serializer;
using Tracer.Tracers;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleTracer tracer = new SimpleTracer();
            Method(tracer);
            var traceResult = tracer.GetTraceResult();
            var serializer = new JsonTraceResultSerializer();
            var json = serializer.Serialize(traceResult);
            Console.Write(json);
        }

        static void Method(SimpleTracer tracer)
        {
            tracer.StartTrace();
            OtherMethod(tracer);
            tracer.StopTrace();
        }

        static void OtherMethod(SimpleTracer tracer)
        {
            tracer.StartTrace();
            tracer.StopTrace();
        }
    }
}
