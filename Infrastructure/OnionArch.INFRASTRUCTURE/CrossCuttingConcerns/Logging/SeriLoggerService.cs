﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArch.APPLICATION.Logging;
using OnionArch.DOMAIN.Abstracts;
using Serilog;

namespace OnionArch.INFRASTRUCTURE.CrossCuttingConcerns.Logging
{
    public class SeriLoggerService : ILoggerService
    {
        public void LogDebugAsync(string message)
        {
            Log.Debug($"[LOG] {message}");
        }

        public void LogErrorAsync(string message, Exception? exception = null)
        {
            Log.Error($"[ERROR] {exception}",message);
        }

        public void LogInformationAsync(string message)
        {
               Log.Information("[LOG] {Message}", message);
        }

        public void LogWarningAsync(string message)
        {
            Log.Warning("[WARNING] {Message}", message);
        }

    }
}
