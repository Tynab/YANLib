using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using static Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult;

namespace YANLib.ServiceDefaults;

public static class Extensions
{
    public static IHostApplicationBuilder AddServiceDefaults(this IHostApplicationBuilder builder)
    {
        _ = builder.ConfigureOpenTelemetry();
        _ = builder.AddDefaultHealthChecks();
        _ = builder.Services.AddServiceDiscovery();

        _ = builder.Services.ConfigureHttpClientDefaults(static h =>
        {
            _ = h.AddStandardResilienceHandler();
            _ = h.AddServiceDiscovery();
        });

        return builder;
    }

    public static IHostApplicationBuilder ConfigureOpenTelemetry(this IHostApplicationBuilder builder)
    {
        _ = builder.Logging.AddOpenTelemetry(static l =>
        {
            l.IncludeFormattedMessage = true;
            l.IncludeScopes = true;
        });

        _ = builder.Services.AddOpenTelemetry()
                            .WithMetrics(static m => m.AddAspNetCoreInstrumentation().AddHttpClientInstrumentation().AddRuntimeInstrumentation())
                            .WithTracing(static t => t.AddAspNetCoreInstrumentation().AddHttpClientInstrumentation());

        _ = builder.AddOpenTelemetryExporters();

        return builder;
    }

    private static IHostApplicationBuilder AddOpenTelemetryExporters(this IHostApplicationBuilder builder)
    {
        if (builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"].IsNotNullWhiteSpace())
        {
            _ = builder.Services.AddOpenTelemetry().UseOtlpExporter();
        }

        return builder;
    }

    public static IHostApplicationBuilder AddDefaultHealthChecks(this IHostApplicationBuilder builder)
    {
        _ = builder.Services.AddHealthChecks().AddCheck("self", static () => Healthy(), ["live"]);

        return builder;
    }

    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            _ = app.MapHealthChecks("/health");

            _ = app.MapHealthChecks("/alive", new HealthCheckOptions
            {
                Predicate = static r => r.Tags.Contains("live")
            });
        }

        return app;
    }
}
