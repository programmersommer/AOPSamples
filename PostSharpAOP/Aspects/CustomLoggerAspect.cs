using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PostSharpAOPSample.Aspects
{

    // https://doc.postsharp.net/method-interception
    // https://doc.postsharp.net/method-decorator

    [PSerializable]
    public class CustomLoggerAspect : MethodInterceptionAspect
    {
        private string[] parameterNames;

        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            parameterNames = method.GetParameters().Select(p => p.Name).ToArray();
        }

        // Pointcut - point of execution in the application at which cross-cutting concern needs to be applied
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            // Advice - the additional code that you want to apply

            var sb = new StringBuilder();
            foreach (object arg in args.Arguments)
            {
                sb.Append($" {arg}");
            }

            Debug.WriteLine($"{args.Method.Name} was called with parameters: {sb}");

            args.Proceed();
        }

    }
}
