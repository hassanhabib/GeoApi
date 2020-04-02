// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System;

namespace GeoApi.Brokers.Logging
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);
        void LogCritical(Exception exception);
        void LogWarning(string @event);
        void LogInformation(string @event);
        void LogDebug(string @event);
        void LogTrace(string @event);
    }
}
