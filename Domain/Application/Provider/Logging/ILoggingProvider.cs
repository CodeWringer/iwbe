using System;

namespace Iwbe.Domain.Provider
{
    /// <summary>
    /// Provides a means of logging messages, either to a console or file stream. 
    /// </summary>
    public interface ILoggingProvider
    {
        void Log(string message);
        void LogWarn(string message);
        void LogError(string message, Exception exc = null);
    }
}
