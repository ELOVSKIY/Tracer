using System;
using System.IO;
using System.Threading;
using Tracer.Results;
using Tracer.Serializer;
using Tracer.Tracers;

namespace ConsoleApp
{
    class Program
    {
        private static SimpleClass clazz;
        private static ITracer tracer;
        static void Main(string[] args)
        {
            tracer = new SimpleTracer();
            clazz = new SimpleClass(tracer);
            Thread thread = new Thread(new ThreadStart(Start));
            thread.Start();
            tracer.StartTrace();
            OtherMethod();
            tracer.StopTrace();
            while (thread.IsAlive)
            {
                
            }
            var res = tracer.GetTraceResult();
            var ser = new JsonTraceResultSerializer();
            var str = ser.Serialize(res);
            Console.WriteLine(str);
        }

        static void Start()
        {
            tracer.StartTrace();
            for (int i = 0; i < 100; i++)
            {
                i++;
            }
            clazz.method();
            tracer.StopTrace();
        }

        static void Method()
        {
            tracer.StartTrace();
            for (int i = 0; i < 100; i++)
            {
                i++;
            }
            OtherMethod();
            tracer.StopTrace();
        }

        static void OtherMethod()
        {
            tracer.StartTrace();
            tracer.StopTrace();
        }
    }
}
