namespace Nancy.Authentication.Forms
{
    using System.Collections.Generic;
    using Bootstrapper;

    public class Startup : IStartup
    {
        private readonly FormsAuthenticationConfiguration configuration;

        public Startup()
        {
        }

        public Startup(FormsAuthenticationConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Gets the type registrations to register for this startup task`
        /// </summary>
        public IEnumerable<TypeRegistration> TypeRegistrations
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the collection registrations to register for this startup task
        /// </summary>
        public IEnumerable<CollectionTypeRegistration> CollectionTypeRegistrations
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the instance registrations to register for this startup task
        /// </summary>
        public IEnumerable<InstanceRegistration> InstanceRegistrations
        {
            get { return null; }
        }

        /// <summary>
        /// Perform any initialisation tasks
        /// </summary>
        public void Initialize(IApplicationPipelines pipelines)
        {
            if (this.configuration != null && this.configuration.IsValid)
            {
                FormsAuthentication.Enable(pipelines, configuration);
            }
        }
    }
}