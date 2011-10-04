namespace Nancy.ViewEngines.Razor
{
    using System;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Globalization;
    using System.Web.Compilation;
    using System.Web.Razor;

    [BuildProviderAppliesTo(BuildProviderAppliesTo.Code | BuildProviderAppliesTo.Web)]
    public class NancyRazorBuildProvider : BuildProvider
    {
        private readonly RazorEngineHost host;

        private readonly CompilerType compilerType;

        private CodeCompileUnit generatedCode;

        public NancyRazorBuildProvider()
        {
            this.compilerType = GetDefaultCompilerTypeForLanguage("C#");

            this.host = new RazorEngineHost(new CSharpRazorCodeLanguage())
            {
                DefaultBaseClass = typeof(NancyRazorViewBase).FullName,
                DefaultNamespace = "RazorOutput",
                DefaultClassName = "RazorView"
            };
        }

        public override void GenerateCode(AssemblyBuilder assemblyBuilder)
        {
            assemblyBuilder.AddCodeCompileUnit(this, this.GetGeneratedCode());

            assemblyBuilder.GenerateTypeFactory(string.Format(CultureInfo.InvariantCulture, "{0}.{1}", new object[] { this.host.DefaultNamespace, this.host.DefaultClassName }));
        }

        private CodeCompileUnit GetGeneratedCode()
        {
            if (this.generatedCode == null)
            {
                var engine = new RazorTemplateEngine(this.host);
                GeneratorResults results;
                using (var reader = OpenReader())
                {
                    results = engine.GenerateCode(reader);
                }

                if (!results.Success)
                {
                    throw new InvalidOperationException(results.ToString());
                }

                this.generatedCode = results.GeneratedCode;
            }

            return this.generatedCode;
        }

        public override CompilerType CodeCompilerType
        {
            get { return compilerType; }
        }

        public override Type GetGeneratedType(CompilerResults results)
        {
            return results.CompiledAssembly.GetType(string.Format(CultureInfo.CurrentCulture, "{0}.{1}", new object[] { this.host.DefaultNamespace, this.host.DefaultClassName }));
        }
    }
}