using OpenTelemetry.Trace;
using System.Diagnostics;
using System.Reflection;
using Castle.DynamicProxy;
namespace Common.Tracing.Aspects
{
    public class DynamicProxyTracingInterceptor : IInterceptor
    {
        private readonly Tracer _tracer;

        public DynamicProxyTracingInterceptor(Tracer tracer)
        {
            _tracer = tracer;
        }

        public void Intercept(IInvocation invocation)
        {            
            using var span = _tracer.StartActiveSpan($"Calling method {invocation.Method.DeclaringType.Name}.{invocation.Method.Name} with arguments {invocation.Arguments}");
            try
            {
                invocation.Proceed();
                using var subspan = _tracer.StartSpan($"Finished calling method {invocation.Method.DeclaringType.Name}.{invocation.Method.Name}");
            }
            catch (TargetInvocationException exc)
            {
                span.RecordException(exc.InnerException);
                throw exc.InnerException;
            }
        }
    }
}