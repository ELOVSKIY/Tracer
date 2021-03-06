﻿using Tracer.Results;

namespace Tracer.Serializer
{
    public class JsonTraceResultSerializer : ITraceResultSerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var serializer = XSerializer.JsonSerializer.Create(traceResult.GetType());
            return serializer.Serialize(traceResult);
        }
    }
}