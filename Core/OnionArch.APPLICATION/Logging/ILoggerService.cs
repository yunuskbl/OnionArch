using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.APPLICATION.Logging
{
    public interface ILoggerService
    {
        Task LogInformationAsync(string messag,params object[] args);
        Task LogWarningAsync(string message, params object[] args);
        Task LogErrorAsync(string message, Exception? exception = null, params object[] args);
        Task LogDebugAsync(string message, params object[] args);
    }
}
