using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace demo.officeDay.codeDom
{

    public class Compiler<TCompilertype>
        where TCompilertype:CodeDomProvider
    {
        public List<string> References { get; set; }


        public Compiler()
        {
            References = new List<string> { "System.DLL" };
        }
    
        public void Build(string code, out System.Reflection.Assembly compiledAssembly, out string error)
        {
            var errorBuilder = new StringBuilder();
            try
            {              
                var compilador = Activator.CreateInstance<TCompilertype>();

                var compilerParameters = new CompilerParameters {GenerateInMemory = true};

                compilerParameters.ReferencedAssemblies.AddRange(References.ToArray());
              
                var compilerResults = compilador.CompileAssemblyFromSource(compilerParameters, code);
                
                if (!compilerResults.Errors.HasErrors)
                {
                    compiledAssembly = compilerResults.CompiledAssembly;
                }
                else
                {
                    compiledAssembly = null;
                    errorBuilder.AppendLine("Error Compiling Code:");
                    errorBuilder.AppendLine("----------------------------------------------");
                    foreach (CompilerError compilerError in compilerResults.Errors)
                    {
                        errorBuilder.AppendLine(compilerError.Line.ToString().PadLeft(5, '0') + ": #" + compilerError.ErrorNumber + " - " + compilerError.ErrorText);
                    }                   
                    errorBuilder.AppendLine("----------------------------------------------");
                    errorBuilder.AppendLine("Generated Code:");
                    errorBuilder.AppendLine(code);
                    errorBuilder.AppendLine("----------------------------------------------");
                }
            }
            catch (Exception e)
            {
                compiledAssembly = null;
                errorBuilder.AppendLine("Error compilind code:");
                errorBuilder.AppendLine( "----------------------------------------------");
                errorBuilder.AppendLine(e.ToString());
            }

            error = errorBuilder.ToString();
        }
    }
}
