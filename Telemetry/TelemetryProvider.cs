using Microsoft.ApplicationInsights;
using System.Collections.Generic;

namespace AppInsightsTelemetryDemo.Telemetry
{
    public interface ITelemetryProvider
    {
        public void AddTelemetryEventProperty(string property, string value);
        public void TrackEvent(string eventName);
    }

    public class TelemetryProvider : ITelemetryProvider
    {
        private TelemetryClient _telemetryClient;
        private Dictionary<string, string> _eventProperties;

        public TelemetryProvider(TelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
            _eventProperties = new Dictionary<string, string>();
        }

        public void AddTelemetryEventProperty(string property, string value)
        {
            _eventProperties.Add(property, value);
        }

        public void TrackEvent (string eventName)
        {
            _telemetryClient.TrackEvent(eventName, _eventProperties);
            _eventProperties.Clear();
        }
    }
}
