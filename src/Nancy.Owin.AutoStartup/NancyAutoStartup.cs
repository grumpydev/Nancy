namespace Nancy.Owin.AutoStartup
{
    using System.Collections.Generic;

    using global::Owin;
    using global::Owin.AutoStartup;

    public class NancyAutoStartup : IAutoStartup
    {
        private IDictionary<string, object[]> defaultBuilderCommands;

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

        public IDictionary<string, object[]> DefaultBuilderCommands
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
            this.defaultBuilderCommands = new Dictionary<string, object[]> { { "UseNancy", new object[] { } } };
        }
    }
}