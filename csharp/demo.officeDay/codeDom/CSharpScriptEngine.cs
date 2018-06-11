using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace demo.officeDay.codeDom
{
    public class CSharpScriptEngine
    {
        private static Compiler<CSharpCodeProvider> _compiler;

        static  CSharpScriptEngine()
        {
            _compiler = new Compiler<CSharpCodeProvider>();
        }

        public static T Eval<T>(string code,object[] parameters)
        {
            T toReturn = default(T);
            Assembly builtAssembly;
            String error;
            
            string fullCode = Scafold(code);

            //Build
            _compiler.Build(fullCode, out builtAssembly, out error);
            if (builtAssembly == null)
                throw new Exception(error);

            //Execute it via reflection!
            var evalType = builtAssembly.GetType("Eval");
            var evalInstance = Activator.CreateInstance(evalType);
            var runMethod = evalType.GetMethod("Run");
            var resultObject = runMethod.Invoke(evalInstance,new object[]{parameters});
            //Casting to T
            toReturn = (T)Convert.ChangeType(resultObject, typeof(T));

            return toReturn;
        }


        private static string Scafold(string code)
        {
            var fullCode = new StringBuilder();
            fullCode.AppendLine("public class Eval");
            fullCode.AppendLine("{");
            fullCode.AppendLine("    public object Run(object[] parameters)");
            fullCode.AppendLine("    {");
            fullCode.AppendLine("        " + code);
            fullCode.AppendLine("    }");
            fullCode.AppendLine("}");
            return fullCode.ToString();
        }
    }
}
