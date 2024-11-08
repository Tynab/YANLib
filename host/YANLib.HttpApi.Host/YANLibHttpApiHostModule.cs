#if RELEASE
using YANLib.Middlewares;
#endif
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.EntityFrameworkCore;
using Elastic.Apm.NetCoreAll;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using NUglify.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.EventBus.Azure;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using YANLib.Core;
using YANLib.Options;
using YANLib.Utilities;
using static Elastic.Apm.Agent;
using static HealthChecks.UI.Client.UIResponseWriter;
using static Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults;
using static Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus;
using static Microsoft.OpenApi.Models.ReferenceType;
using static Microsoft.OpenApi.Models.SecuritySchemeType;
using static System.Array;
using static System.Text.Encoding;
using static YANLib.YANLibConsts;
using static Asp.Versioning.ApiVersionReader;

namespace YANLib;

[DependsOn(
    typeof(YANLibHttpApiModule),
    typeof(YANLibApplicationModule),
    typeof(YANLibEntityFrameworkCoreModule),
    typeof(AbpAutofacModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpHttpClientModule),
    typeof(AbpCachingStackExchangeRedisModule),
    //typeof(AbpEventBusAzureModule),
    //typeof(AbpEventBusRabbitMqModule),
    //typeof(AbpAspNetCoreSignalRModule),
    //typeof(AbpBackgroundJobsHangfireModule),
    typeof(AbpAspNetCoreSerilogModule)
)]
public class YANLibHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        ConfigureSqlServer();
        ConfigureApiVersioning(context);
        ConfigureAuthentication(context, configuration);
        ConfigureCors(context, configuration);
        ConfigureSwaggerServices(context, configuration);
        //ConfigureElasticsearch(context, configuration);
        //ConfigureCap(context, configuration);
        //ConfigureHangfire(context, configuration);
        //ConfigureHealthChecks(context, configuration);
    }

    private void ConfigureSqlServer() => Configure<AbpDbContextOptions>(o => o.UseSqlServer());

    private void ConfigureApiVersioning(ServiceConfigurationContext context)
    {
        _ = context.Services.AddAbpApiVersioning(o =>
        {
            o.ReportApiVersions = true;
            o.AssumeDefaultVersionWhenUnspecified = true;
            o.ApiVersionReader = Combine(new UrlSegmentApiVersionReader(), new HeaderApiVersionReader("x-api-version"), new MediaTypeApiVersionReader("version"));
        }).AddApiExplorer(o =>
        {
            o.GroupNameFormat = "'v'VVV";
            o.SubstituteApiVersionInUrl = true;
        });

        Configure<AbpAspNetCoreMvcOptions>(o => o.ChangeControllerModelApiExplorerGroupName = false);
    }

    private static void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration) => context.Services.AddAuthentication(AuthenticationScheme).AddJwtBearer(o =>
    {
        o.Authority = configuration["AuthServer:Authority"];
        o.RequireHttpsMetadata = configuration["AuthServer:RequireHttpsMetadata"].ToBool();
        o.Audience = configuration["AuthServer:ApiName"];
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JWT:Issuer"],
            ValidAudience = configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(UTF8.GetBytes(configuration["JWT:Secret"] ?? string.Empty))
        };
    });

    private static void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
    {
        var corsOrigins = configuration["App:CorsOrigins"]?.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(origin => origin.RemovePostFix("/")).ToArray();

        if (corsOrigins.IsEmptyOrNull())
        {
            return;
        }

        _ = context.Services.AddCors(s => s.AddDefaultPolicy(b => b.WithOrigins(corsOrigins).WithAbpExposedHeaders().SetIsOriginAllowedToAllowWildcardSubdomains().AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
    }

    private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
    {
        _ = context.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        var authority = configuration["AuthServer:Authority"];

        if (authority.IsWhiteSpaceOrNull())
        {
            return;
        }

        _ = context.Services.AddAbpSwaggerGenWithOAuth(authority, new Dictionary<string, string>
        {
            {"YANLib", "YANLib API"}
        }, o =>
        {
            o.OperationFilter<SwaggerDefaultValues>();
            o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            o.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = SecurityScheme,
                            Id = "Bearer"
                        }
                    }, Empty<string>()
                }
            });

            o.CustomSchemaIds(t => t.FullName);
            //o.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
            o.HideAbpEndpoints();
            o.EnableAnnotations();
            o.DescribeAllParametersInCamelCase();
        });
    }

    private static void ConfigureElasticsearch(ServiceConfigurationContext context, IConfiguration configuration) => context.Services.AddElasticsearch(configuration);

    private static void ConfigureCap(ServiceConfigurationContext context, IConfiguration configuration)
    {
        _ = context.Services.AddSingleton<IMongoClient>(new MongoClient(configuration["CAP:ConnectionString"]));

        _ = context.Services.AddCap(c =>
        {
            _ = c.UseDashboard(o => o.PathMatch = "/cap");
            //_ = c.UseSqlServer(configuration.GetConnectionString(ConnectionStringName.Default) ?? string.Empty);

            _ = c.UseMongoDB(o =>
            {
                var dbName = configuration["CAP:DBName"];
                var connectionString = configuration["CAP:ConnectionString"];

                if (dbName.IsWhiteSpaceOrNull() || connectionString.IsWhiteSpaceOrNull())
                {
                    return;
                }

                o.DatabaseName = dbName;
                o.DatabaseConnection = connectionString;
            });

            _ = c.UseKafka(o =>
            {
                var connection = configuration["CAP:Kafka:Connections:Default:BootstrapServers"];

                if (connection.IsWhiteSpaceOrNull())
                {
                    return;
                }

                o.Servers = connection;
                o.MainConfig.Add("security.protocol", "SASL_PLAINTEXT");
                o.MainConfig.Add("sasl.mechanism", "PLAIN");

                var username = configuration["CAP:Kafka:Username"];

                if (username.IsNotWhiteSpaceAndNull())
                {
                    o.MainConfig.Add("sasl.username", username);
                }

                var password = configuration["CAP:Kafka:Password"];

                if (password.IsNotWhiteSpaceAndNull())
                {
                    o.MainConfig.Add("sasl.password", password);
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

    private static void ConfigureHangfire(ServiceConfigurationContext context, IConfiguration configuration)
        => context.Services.AddHangfire(c => c.UseSqlServerStorage(configuration.GetConnectionString(ConnectionStringName.Default)));

    private static void ConfigureHealthChecks(ServiceConfigurationContext context, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:Default"];

        if (connectionString.IsWhiteSpaceOrNull())
        {
            return;
        }

        _ = context.Services.AddHealthChecks().AddSqlServer(connectionString: connectionString, name: "database", failureStatus: Degraded, tags: ["db", "sql", "sqlserver"]);
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        _ = context.GetEnvironment().IsDevelopment() ? app.UseDeveloperExceptionPage() : app.UseHsts();
        _ = app.UseAllElasticApm(context.GetConfiguration()); // primary required
        _ = Subscribe(new HttpDiagnosticsSubscriber()); // secondary required
        _ = Subscribe(new EfCoreDiagnosticsSubscriber()); // secondary required
        _ = app.UseHttpsRedirection();
        _ = app.UseCorrelationId();
        _ = app.UseStaticFiles();
        _ = app.UseRouting();

        _ = app.UseAbpRequestLocalization(o =>
        {
            _ = o.SetDefaultCulture("vi");
            _ = o.AddSupportedCultures("vi");
            _ = o.AddSupportedUICultures("vi");
        });

        _ = app.UseCors();
        _ = app.UseAuthentication();
        _ = app.UseAuthorization();
        _ = app.UseSwagger();

#if RELEASE
        _ = app.UseMiddleware<SwaggerBasicAuthMiddleware>();
#endif

        _ = app.UseAbpSwaggerUI(c =>
        {
            app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions.ForEach(x => c.SwaggerEndpoint($"/swagger/{x.GroupName}/swagger.json", x.GroupName.ToUpperInvariant()));
            c.OAuthClientId(context.ServiceProvider.GetRequiredService<IConfiguration>()["AuthServer:SwaggerClientId"]);
            c.OAuthScopes("YANLib");
            c.DefaultModelsExpandDepth(-1);
        });

        _ = app.UseUnitOfWork();
        _ = app.UseAuditing();
        _ = app.UseAbpSerilogEnrichers();

        _ = app.UseHealthChecks("/health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = WriteHealthCheckUIResponse
        });

        //_ = app.UseHangfireDashboard();
        _ = app.UseConfiguredEndpoints();
    }
}
