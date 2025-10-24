using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics;

namespace WebAPI.HealthChecks
{
    public class ApplicationHealthCheck : IHealthCheck
    {
        private readonly Process _currentProcess;

        public ApplicationHealthCheck()
        {
            _currentProcess = Process.GetCurrentProcess();
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                // Memory
                var memoryUsageInMB = _currentProcess.WorkingSet64 / (1024 * 1024);
                if (memoryUsageInMB > 512) // Example threshold
                {
                    return Task.FromResult(HealthCheckResult.Unhealthy($"High memory usage: {memoryUsageInMB} MB"));
                }

                // CPU
                var cpuUsage = _currentProcess.TotalProcessorTime.TotalMilliseconds / Environment.ProcessorCount;
                if (cpuUsage > 80) // Example threshold
                {
                    return Task.FromResult(HealthCheckResult.Unhealthy($"High CPU usage: {cpuUsage}%"));
                }

                return Task.FromResult(HealthCheckResult.Healthy("The application is healthy."));
            }
            catch (Exception ex)
            {
                // Log the exception if necessary (e.g., using a logging framework)
                return Task.FromResult(HealthCheckResult.Unhealthy($"An error occurred while checking health: {ex.Message}"));
            }
        }
    }
}
