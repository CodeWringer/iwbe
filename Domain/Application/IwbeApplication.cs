using System;
using Iwbe.Domain.StoreSystem;
using Iwbe.Domain.Provider;
using Iwbe.Domain.Provider.Mock;
using StoreSystem;

namespace Iwbe.Domain
{
    /// <summary>
    /// The application singleton.  
    /// </summary>
    public static class IwbeApplication
    {
        /// <summary>
        /// Single-source-of-truth of all application state. 
        /// </summary>
        public static RootState State { get; private set; } = new RootState();

        /// <summary>
        /// TODO
        /// </summary>
        public static bool Mock { get; private set; } = true; // TODO: Launch parameter?

        public static IAppSettingsProvider AppSettingsProvider
        {
            get
            {
                if (Mock)
                    return new MockAppSettingsProvider();
                else
                    return new AppSettingsProvider();
            }
            private set { /* Do nothing */ }
        }

        public static IProjectProvider ProjectProvider
        {
            get
            {
                if (Mock)
                    return new MockProjectProvider();
                else
                    return new ProjectProvider();
            }
            private set { /* Do nothing */ }
        }

        public static ILoggingProvider LoggingProvider
        {
            get
            {
                return new ConsoleLoggingProvider();
            }
            private set { /* Do nothing */ }
        }
    }
}