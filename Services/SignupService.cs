using AppInsightsTelemetryDemo.Models;
using AppInsightsTelemetryDemo.Telemetry;

namespace AppInsightsTelemetryDemo.Services
{
    public interface ISignupService
    {
        void ProcessRequest(NewSignupRequest request);
    }

    public class SignupService : ISignupService
    {
        private ITelemetryProvider _telemetryProvider;

        public SignupService(ITelemetryProvider telemetryProvider)
        {
            _telemetryProvider = telemetryProvider;
        }

        public void ProcessRequest(NewSignupRequest request)
        {
            _telemetryProvider.AddTelemetryEventProperty("IsMetro", request.IsMetro.ToString());
            _telemetryProvider.TrackEvent("RequestProcessed");

            SendNotificationEmail(request.IsMetro);
            CreateAndUploadBlob(request.IsMetro);
            UpdateDatabase(request.IsMetro);
        }

        public void SendNotificationEmail(bool isMetro)
        {
            try
            {
                // Code for sending email goes here

                // Telemetry code
                _telemetryProvider.AddTelemetryEventProperty("IsMetro", isMetro.ToString());
                _telemetryProvider.TrackEvent("NotificationEmailSent");
            }
            catch
            {
                // Exception handling logic here
            }
        }

        public void CreateAndUploadBlob(bool isMetro)
        {
            if (!isMetro)
            {
                return;
            }

            try
            {
                // Code for doing blob stuff goes here

                // Telemetry code
                _telemetryProvider.AddTelemetryEventProperty("IsMetro", isMetro.ToString());
                _telemetryProvider.TrackEvent("BlobCreated");
            }
            catch
            {
                // Exception handling logic here
            }
        }

        public void UpdateDatabase(bool isMetro)
        {
            try
            {
                // Code for DB update goes here

                // Telemetry code
                _telemetryProvider.AddTelemetryEventProperty("IsMetro", isMetro.ToString());
                _telemetryProvider.TrackEvent("DatabaseUpdate");
            }
            catch
            {
                // Exception handling logic here
            }
        }
    }
}
