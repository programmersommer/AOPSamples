using Castle.DynamicProxy;
using System.Diagnostics;


// https://autofaccn.readthedocs.io/en/latest/advanced/interceptors.html
// JIT Emission of Classes
// This approach works only with public virtual methods and with interfaces
// https://www.postsharp.net/aop.net/runtime-weaving

namespace AutofacInterceptors.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Debug.WriteLine($"Calling method {invocation.Method.Name}");

            invocation.Proceed();

            Debug.WriteLine($"Result of invocation is: {invocation.ReturnValue}");
        }
    }
}
