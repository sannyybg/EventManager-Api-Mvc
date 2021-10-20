using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelEventManager.Extensions
{
    public static class HealthChecksExtension
    {
        public static void HealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/Event?id=0"), "1", tags: new[] { "Events Get Check" })
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/Event"), "2", tags: new[] { "Events Put Check" })
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/Event"), "3", tags: new[] { "Events Create Check" })
                .AddUrlGroup(new Uri("http://httpbin.org/status/400"), "4", tags: new[] { "Test Unhealthy" })
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/Event/GetEventAll"), "5", tags: new[] { "Events Get All Check" })
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/Event/GetFinishedEvents"), "6", tags: new[] { "Get Finished Events Check" })
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/Event"), "7", tags: new[] { "Events Edit Admin Check" })
                .AddUrlGroup(new Uri("http://httpbin.org/status/400"), "8", tags: new[] { "Test Degraded" })
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/Event/GetUserIdAsync"), "9", tags: new[] { "Get Events UserIdCheck " })
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/Event"), "10", tags: new[] { "Check Event Dates" })
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/User"), "11", tags: new[] { "User Login Check" })
                .AddUrlGroup(new Uri("http://httpbin.org/status/400"), "12", tags: new[] { "Test Unhealthy" })
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/User"), "13", tags: new[] { "User Register Check" })
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/User"), "14", tags: new[] { "Get User Check" })
                .AddUrlGroup(new Uri("https://localhost:44357/api/v1/User"), "15", tags: new[] { "Delete User Check" });
        }
    }
}
