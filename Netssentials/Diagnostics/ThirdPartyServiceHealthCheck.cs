using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Netssentials
{
    public class ThirdPartyServiceHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("ThirdParty services NOT running.."));
            }

            return Task.FromResult(HealthCheckResult.Healthy("ThirdParty services running ok.."));
        }
    }
}
