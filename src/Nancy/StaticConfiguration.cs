namespace Nancy
{
    public static class StaticConfiguration
    {
#if DEBUG
        private static bool disableCaches = true;
#else
        private static bool disableCaches = false;
#endif   

        /// <summary>
        /// Gets or sets a value indicating whether Nancy should disable caching
        /// </summary>
        public static bool DisableCaches
        {
            get { return disableCaches; }
            set { disableCaches = value; }
        }

#if DEBUG
        private static bool disableErrorTraces = false;
#else
        private static bool disableErrorTraces = true;
#endif
        /// <summary>
        /// Gets or sets a value indicating whether or not to disable traces in error messages
        /// </summary>
        public static bool DisableErrorTraces
        {
            get { return disableErrorTraces; }
            set { disableErrorTraces = value; }
        }

#if DEBUG
        private static bool enableDiagnostics = false;
#else
        private static bool enableDiagnostics = true;
#endif
        /// <summary>
        /// Gets or sets a value indicating whether or not to enable diagnostics
        /// </summary>
        public static bool EnableDiagnostics
        {
            get { return enableDiagnostics; }
            set { enableDiagnostics = value; }
        }
    }
}