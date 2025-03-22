using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.APPLICATION.Logging
{
    public interface ILoggerService
    {
        void LogInformationAsync(string message);
        void LogWarningAsync(string message);
        void LogErrorAsync(string message, Exception? exception = null);
        void LogDebugAsync(string message);
    }
}
