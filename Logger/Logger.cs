using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Logger.Base;

namespace Logger
{
    public class Logger : ILogger
    {
        private readonly TelemetryClient _telemetryClient;
        private readonly LogLevel _logLevel;

        public Logger(TelemetryClient telemetryClient, LogLevel logLevel = (LogLevel.Dependency | LogLevel.Error | LogLevel.Information | LogLevel.Warning))
        {
            _telemetryClient = telemetryClient;
            _logLevel = logLevel;
        }

        public Task Dependency(Dependency dependency)
        {
            if (_logLevel == LogLevel.None || (_logLevel & LogLevel.Dependency) != LogLevel.Dependency)
            {
                return Task.CompletedTask;
            }
            DependencyTelemetry dependencyTelemetry = new()
            {
                Name = dependency.Name,
                Success = dependency.IsSuccessful,
                Target = dependency.Operation,
                Type = dependency.Operation,
                Duration = TimeSpan.FromTicks(dependency.Ticks.GetValueOrDefault())
            };

            foreach (System.Collections.Generic.KeyValuePair<string, string> kp in dependency.Property.Properties)
            {
                dependencyTelemetry.Properties.Add(kp.Key, kp.Value);
            }

            _telemetryClient.TrackDependency(dependencyTelemetry);
            return Task.CompletedTask;
        }

        public Task Error(ExceptionMessage message)
        {
            if (_logLevel == LogLevel.None || (_logLevel & LogLevel.Error) != LogLevel.Error)
            {
                return Task.CompletedTask;
            }

            ExceptionTelemetry exceptionTelemetry = new(message.Exception);

            foreach (System.Collections.Generic.KeyValuePair<string, string> kp in message.Property.Properties)
            {
                exceptionTelemetry.Properties.Add(kp.Key, kp.Value);
            }

            _telemetryClient.TrackException(exceptionTelemetry);
            return Task.CompletedTask;
        }

        public Task Information(Message message)
        {
            if (_logLevel != LogLevel.None && ((_logLevel & LogLevel.Information) == LogLevel.Information))
            {
                _telemetryClient.TrackTrace(message.Text, SeverityLevel.Information, message.Property.Properties.ToDictionary(p => p.Key, p => p.Value));
            }

            return Task.CompletedTask;
        }

        public DependencyOperation Start(string name, string operation, Property property)
        {
            return new DependencyOperation(this, name, operation, property);
        }


        public Task Warning(Message message)
        {
            if (_logLevel != LogLevel.None && ((_logLevel & LogLevel.Warning) == LogLevel.Warning))
            {
                _telemetryClient.TrackTrace(message.Text, SeverityLevel.Warning, message.Property.Properties.ToDictionary(p => p.Key, p => p.Value));
            }

            return Task.CompletedTask;
        }
    }
}
