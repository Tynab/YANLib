using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.EntityFrameworkCore;
using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Http.Client;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using YANLib.EntityFrameworkCore;
using YANLib.Utilities;
using static Elastic.Apm.Agent;
using static HealthChecks.UI.Client.UIResponseWriter;
using static Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus;
using static System.StringSplitOptions;

namespace YANLib;

[DependsOn(
    typeof(YANLibHttpApiModule),
    typeof(YANLibApplicationModule),
    typeof(YANLibEntityFrameworkCoreModule),
    //typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpHttpClientModule)
)]
public class YANLibHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        context.Services.AddElasticsearch(configuration);
        Configure<AbpDbContextOptions>(o => o.UseSqlServer());
        ConfigureConventionalControllers();
        ConfigureLocalization();
        ConfigureCors(context, configuration);
        ConfigureSwaggerServices(context, configuration);
        ConfigureHealthChecks(context, configuration);
    }

    private void ConfigureConventionalControllers() => Configure<AbpAspNetCoreMvcOptions>(o => o.ConventionalControllers.Create(typeof(YANLibApplicationModule).Assembly));

    private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        _ = context.Services.AddAbpSwaggerGenWithOAuth(configuration["AuthServer:Authority"], new Dictionary<string, string>
        {
            {"YANLib Sample", "YANLib API Sample"},
            {"YANLib Test", "YANLib API Test"}
        }, o =>
        {
            o.SwaggerDoc("sample", new OpenApiInfo { Title = $"YANLib API Sample - {hostingEnvironment.EnvironmentName}", Version = "sample" });
            o.SwaggerDoc("test", new OpenApiInfo { Title = $"YANLib API Test - {hostingEnvironment.EnvironmentName}", Version = "test" });
            o.CustomSchemaIds(t => t.FullName);
            o.HideAbpEndpoints();
            o.EnableAnnotations();
        });
    }

    private void ConfigureLocalization() => Configure<AbpLocalizationOptions>(o =>
    {
        o.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
        o.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
        o.Languages.Add(new LanguageInfo("en", "en", "English"));
        o.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
        o.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
        o.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
        o.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
        o.Languages.Add(new LanguageInfo("is", "is", "Icelandic", "is"));
        o.Languages.Add(new LanguageInfo("it", "it", "Italiano", "it"));
        o.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
        o.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
        o.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
        o.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
        o.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
        o.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
        o.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
        o.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
        o.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch", "de"));
        o.Languages.Add(new LanguageInfo("es", "es", "Español", "es"));
        o.Languages.Add(new LanguageInfo("el", "el", "Ελληνικά"));
        o.Languages.Add(new LanguageInfo("vi", "vi", "Tiếng Việt"));
    });

    private static void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration) => context.Services.AddCors(o => o
    .AddDefaultPolicy(b => b
    .WithOrigins(configuration["App:CorsOrigins"].Split(",", RemoveEmptyEntries).Select(o => o
    .RemovePostFix("/")).ToArray()).WithAbpExposedHeaders().SetIsOriginAllowedToAllowWildcardSubdomains().AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

    private static void ConfigureHealthChecks(ServiceConfigurationContext context, IConfiguration configuration) => context.Services.AddHealthChecks()
        .AddSqlServer(connectionString: configuration["ConnectionStrings:Default"], name: "database", failureStatus: Degraded, tags: new string[] { "db", "sql", "sqlserver" });

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        _ = app.UseAllElasticApm(context.GetConfiguration());
        _ = Subscribe(new HttpDiagnosticsSubscriber());
        _ = Subscribe(new EfCoreDiagnosticsSubscriber());

        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            _ = app.UseDeveloperExceptionPage();
        }

        _ = app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            _ = app.UseErrorPage();
        }

        _ = app.UseCorrelationId();
        _ = app.UseStaticFiles();
        _ = app.UseRouting();
        _ = app.UseCors();
        _ = app.UseAuthentication();
        _ = app.UseUnitOfWork();
        _ = app.UseAuthorization();
        _ = app.UseSwagger();

        _ = app.UseAbpSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/sample/swagger.json", "YANLib API Sample");
            c.SwaggerEndpoint("/swagger/test/swagger.json", "YANLib API Test");
            c.OAuthClientId(context.ServiceProvider.GetRequiredService<IConfiguration>()["AuthServer:SwaggerClientId"]);
            c.OAuthScopes("YANLib");
        });

        _ = app.UseAuditing();
        _ = app.UseAbpSerilogEnrichers();

        _ = app.UseHealthChecks("/health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = WriteHealthCheckUIResponse
        });

        _ = app.UseConfiguredEndpoints();
    }
}
