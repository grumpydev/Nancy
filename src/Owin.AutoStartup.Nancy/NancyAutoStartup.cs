namespace Owin.AutoStartup.Nancy
{
    using System.Collections.Generic;

    using global::Owin;
    using global::Owin.AutoStartup;

    public class NancyAutoStartup : IAutoStartup
    {
        private string[] defaultBuilderCommands;

        public string Name
        {
            get
            {
                return "Nancy";
            }
        }

        public string Path
        {
            get
            {
                return "/";
            }
        }

        public IEnumerable<string> DefaultBuilderCommands
        {
            get
            {
                return this.defaultBuilderCommands;
            }
        }

        public void Configuration(IAppBuilder builder)
        {
            builder.UseNancy();
        }

        public NancyAutoStartup()
        {
            this.defaultBuilderCommands = new[] { "builder.UseNancy();" };
        }
    }
}