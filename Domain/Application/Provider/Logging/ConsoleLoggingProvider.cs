using System;

namespace Iwbe.Domain.Provider
{
    public class ConsoleLoggingProvider : ILoggingProvider
    {
        private const string LEVEL_INFO = "INFO";
        private const string LEVEL_WARN = "WARN";
        private const string LEVEL_ERROR = "ERROR";

        public void Log(string message)
        {
            Console.WriteLine(this.GetFormatted(LEVEL_INFO, message));
        }

        public void LogError(string message, Exception exc = null)
        {
            Console.WriteLine(this.GetFormatted(LEVEL_ERROR, message));
            this.LogException(exc);
        }

        public void LogWarn(string message)
        {
            Console.WriteLine(this.GetFormatted(LEVEL_WARN, message));
        }

        private string GetFormatted(string level, string message)
        {
            return string.Format("[{0}] [{1}] \"{2}\"", level, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ff"), message);
        }

        private void LogException(Exception exc)
        {
            if (exc == null)
                return;

            Console.WriteLine(exc.Message);
            Console.WriteLine(exc.Source);
            Console.WriteLine(exc.StackTrace);

            if (exc.InnerException != null)
                this.LogException(exc.InnerException);
        }
    }
}
