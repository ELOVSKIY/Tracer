using System;
using System.IO;
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
            var t = traceResult.ThreadTraceResults;
            TextWriter textWriter = Console.Out;
            var serializer = new JsonTraceResultSerializer();
            Console.Write(serializer.Serialize(traceResult));
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
