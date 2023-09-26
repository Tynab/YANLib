using DotNetCore.CAP;
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
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.EventBus.Azure;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Http.Client;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Swashbuckle;
using YANLib.EntityFrameworkCore;
using YANLib.Utilities;
using static Elastic.Apm.Agent;
using static HealthChecks.UI.Client.UIResponseWriter;
using static Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults;
using static Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus;
using static System.Convert;
using static System.StringSplitOptions;

#if !DEBUG
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using YANLib.Middlewares;
using static Microsoft.OpenApi.Models.ParameterLocation;
using static Microsoft.OpenApi.Models.SecuritySchemeType;
using static System.Net.HttpStatusCode;
using static System.Threading.Tasks.Task;
#endif

namespace YANLib;

[DependsOn(
    typeof(YANLibHttpApiModule),
    typeof(YANLibApplicationModule),
    typeof(YANLibEntityFrameworkCoreModule),
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpHttpClientModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpEventBusAzureModule),
    typeof(AbpEventBusRabbitMqModule)
)]
public class YANLibHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        context.Services.AddElasticsearch(configuration);
        Configure<AbpDbContextOptions>(o => o.UseSqlServer());
        Configure<AbpMultiTenancyOptions>(o => o.IsEnabled = true);
        Configure<AbpDistributedCacheOptions>(o => o.KeyPrefix = "YANLib:");
        ConfigureLocalization();
        ConfigureConventionalControllers();
        ConfigureCors(context, configuration);
        ConfigureAuthentication(context, configuration);
        ConfigureSwaggerServices(context, configuration);
        ConfigureCap(context, configuration);
        ConfigureHealthChecks(context, configuration);
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

    private void ConfigureConventionalControllers() => Configure<AbpAspNetCoreMvcOptions>(o => o.ConventionalControllers.Create(typeof(YANLibApplicationModule).Assembly));

    private static void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration) => context.Services.AddCors(o => o
        .AddDefaultPolicy(b => b
            .WithOrigins(configuration["App:CorsOrigins"].Split(",", RemoveEmptyEntries).Select(o => o
                .RemovePostFix("/")).ToArray()).WithAbpExposedHeaders().SetIsOriginAllowedToAllowWildcardSubdomains().AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

    private static void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration) => context.Services.AddAuthentication(AuthenticationScheme).AddJwtBearer(o =>
    {
        o.Authority = configuration["AuthServer:Authority"];
        o.RequireHttpsMetadata = ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
        o.Audience = configuration["AuthServer:ApiName"];

#if !DEBUG
        o.Events = new JwtBearerEvents
        {
            OnMessageReceived = async c =>
            {
                string authorization = c.Request.Headers["Authorization"];

                if (authorization == configuration["Authorization:Bearer"])
                {
                    await CompletedTask;
                }
                else
                {
                    c.Response.StatusCode = Unauthorized.ToInt();
                    c.Response.ContentType = "application/json";
                    await c.Response.WriteAsync("Access Denied");
                }
            }
        };
#endif
    });

    private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        _ = context.Services.AddAbpSwaggerGenWithOAuth(configuration["AuthServer:Authority"], new Dictionary<string, string>
        {
            {"YANLib Sample", "YANLib API Sample"},
            {"YANLib Test", "YANLib API Test"}
        }, o =>
        {
            o.SwaggerDoc("sample", new OpenApiInfo
            {
                Title = $"YANLib API Sample - {hostingEnvironment.EnvironmentName}",
                Version = "sample"
            });

            o.SwaggerDoc("test", new OpenApiInfo
            {
                Title = $"YANLib API Test - {hostingEnvironment.EnvironmentName}",
                Version = "test"
            });

#if !DEBUG
            o.AddSecurityDefinition("Authorization", new OpenApiSecurityScheme
            {
                In = Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = ApiKey
            });

            o.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Authorization",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, new List<string>()
                }
            });
#endif

            o.CustomSchemaIds(t => t.FullName.Replace("+", "."));
            o.HideAbpEndpoints();
            o.EnableAnnotations();
        });
    }

    private static void ConfigureCap(ServiceConfigurationContext context, IConfiguration configuration)
    {
        _ = context.Services.AddSingleton<IMongoClient>(new MongoClient(configuration["CAP:ConnectionString"]));

        _ = context.Services.AddCap(c =>
        {
            _ = c.UseDashboard(o => o.PathMatch = "/cap");

            _ = c.UseMongoDB(o =>
            {
                o.DatabaseName = configuration["CAP:DBName"];
                o.DatabaseConnection = configuration["CAP:ConnectionString"];
            });

            _ = c.UseKafka(o =>
            {
                o.Servers = configuration["CAP:Kafka:Connections:Default:BootstrapServers"];
                o.MainConfig.Add("security.protocol", "SASL_PLAINTEXT");
                o.MainConfig.Add("sasl.mechanism", "PLAIN");

                if (configuration["CAP:Kafka:Username"].IsNotWhiteSpaceAndNull())
                {
                    o.MainConfig.Add("sasl.username", configuration["CAP:Kafka:Username"]);
                }

                if (configuration["CAP:Kafka:Password"].IsNotWhiteSpaceAndNull())
                {
                    o.MainConfig.Add("sasl.password", configuration["CAP:Kafka:Password"]);
                }
            });

            //_ = c.UseRabbitMQ(o =>
            //{
            //    var host = configuration["CAP:RabbitMQ:Connections:Default:HostName"];

            //    o.HostName = host;
            //    o.Port = configuration["CAP:RabbitMQ:Connections:Default:Port"].ToInt(5672);
            //    o.VirtualHost = configuration["CAP:RabbitMQ:Connections:Default:VirtualHost"];
            //    o.UserName = configuration["CAP:RabbitMQ:Connections:Default:Username"];
            //    o.Password = configuration["CAP:RabbitMQ:Connections:Default:Password"];

            //    if (configuration["CAP:RabbitMQ:Connections:Default:Ssl"].IsNotWhiteSpaceAndNull())
            //    {
            //        o.ConnectionFactoryOptions = f =>
            //        {
            //            f.Ssl.Enabled = configuration["CAP:RabbitMQ:Connections:Default:Ssl:Enabled"].ToBool(true);
            //            f.Ssl.ServerName = configuration["CAP:RabbitMQ:Connections:Default:Ssl:ServerName"] ?? host;
            //        };
            //    }

            //    o.ExchangeName = configuration["CAP:RabbitMQ:EventBus:ExchangeName"];
            //});

            c.DefaultGroupName = configuration["Cap:DefaultGroupName"] ?? c.DefaultGroupName;
            c.FailedRetryCount = configuration["Cap:FailedRetryCount"].ToInt(0);
        });
    }

    private static void ConfigureHealthChecks(ServiceConfigurationContext context, IConfiguration configuration) => context.Services.AddHealthChecks().AddSqlServer(
        connectionString: configuration["ConnectionStrings:Default"],
        name: "database",
        failureStatus: Degraded,
        tags: new string[] { "db", "sql", "sqlserver"
    });

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        _ = context.GetEnvironment().IsDevelopment() ? app.UseDeveloperExceptionPage() : app.UseHsts();
        _ = app.UseHttpsRedirection();
        _ = app.UseCorrelationId();
        _ = app.UseStaticFiles();
        _ = app.UseRouting();

        _ = app.UseAbpRequestLocalization(o =>
        {
            o.SetDefaultCulture("vi");
            o.AddSupportedCultures("vi");
            o.AddSupportedUICultures("vi");
        });

        _ = app.UseSwagger();

        _ = app.UseAbpSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/sample/swagger.json", "YANLib API Sample");
            c.SwaggerEndpoint("/swagger/test/swagger.json", "YANLib API Test");
            c.OAuthClientId(context.ServiceProvider.GetRequiredService<IConfiguration>()["AuthServer:SwaggerClientId"]);
            c.OAuthScopes("YANLib");
        });

        _ = app.UseHealthChecks("/health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = WriteHealthCheckUIResponse
        });

        _ = app.UseCapDashboard();

#if !DEBUG
        _ = app.UseMiddleware<UnauthorizedHandlerMiddleware>();
#endif

        _ = app.UseCors();
        _ = app.UseAuthentication();
        _ = app.UseAuthorization();
        _ = app.UseAuditing();
        _ = app.UseAbpSerilogEnrichers();
        _ = app.UseConfiguredEndpoints();
        _ = app.UseAllElasticApm(context.GetConfiguration());
        _ = Subscribe(new HttpDiagnosticsSubscriber());
        _ = Subscribe(new EfCoreDiagnosticsSubscriber());
    }
}
