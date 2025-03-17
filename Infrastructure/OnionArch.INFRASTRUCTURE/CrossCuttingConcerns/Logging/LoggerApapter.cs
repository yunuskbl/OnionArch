using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.APPLICATION.Logging;
using OnionArch.DOMAIN.Abstracts;
using Serilog;

namespace OnionArch.INFRASTRUCTURE.CrossCuttingConcerns.Logging
{
    public class LoggerApapter : ILoggerService
    {
        public Task LogDebugAsync(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public Task LogErrorAsync(string message, Exception? exception = null, params object[] args)
        {
            throw new NotImplementedException();
        }

        public Task LogInformationAsync(string messag, params object[] args)
        {
            throw new NotImplementedException();
        }

        public Task LogWarningAsync(string message, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
