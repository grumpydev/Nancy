namespace Nancy.Demo.Authentication.Forms
{
    using Nancy;
    using Nancy.Authentication.Forms;

    public class FormsAuthBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoC.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var formsAuthConfiguration =
                new FormsAuthenticationConfiguration()
                {
                    RedirectUrl = "~/login",
                    UserMapper = container.Resolve<IUserMapper>(),
                };

            container.Register(formsAuthConfiguration);
        }
    }
}