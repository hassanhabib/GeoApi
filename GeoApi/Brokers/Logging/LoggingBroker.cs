// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System;
using Microsoft.Extensions.Logging;

namespace GeoApi.Brokers.Logging
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger logger;

        public LoggingBroker(ILogger logger) => this.logger = logger;

        public void LogError(Exception exception) => this.logger.LogError(exception, exception.Message);
        public void LogInformation(string @event) => this.logger.LogInformation(@event);
        public void LogWarning(string @event) => this.logger.LogWarning(@event);
        public void LogDebug(string @event) => this.logger.LogDebug(@event);
        public void LogTrace(string @event) => this.logger.LogTrace(@event);
        public void LogCritical(Exception exception) => this.logger.LogCritical(exception, exception.Message);
    }
}
