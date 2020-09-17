using Tracer.Tracers;

namespace ConsoleApp
{
    public class SimpleClass
    {
        private ITracer _Tracer;

        public SimpleClass(ITracer tracer)
        {
            _Tracer = tracer;
        }

        public void method()
        {
            _Tracer.StartTrace();
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                j += i;
            }
            _Tracer.StopTrace();
        }
    }
}