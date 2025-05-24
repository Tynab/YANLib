#if RELEASE

using YANLib.Middlewares;

#endif

using Amazon.CloudWatch;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Confluent.Kafka;
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
using RabbitMQ.Client;
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
using YANLib;
using YANLib.EsIndices;
using YANLib.Filters;
using YANLib.Options;
using static Amazon.RegionEndpoint;
using static Amazon.Runtime.CredentialManagement.AWSCredentialsFactory;
using static Asp.Versioning.ApiVersionReader;
using static Confluent.Kafka.Acks;
using static Confluent.Kafka.SaslMechanism;
using static Confluent.Kafka.SecurityProtocol;
using static Elastic.Apm.Agent;
using static HealthChecks.UI.Client.UIResponseWriter;
using static Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults;
using static Microsoft.OpenApi.Models.ReferenceType;
using static Microsoft.OpenApi.Models.SecuritySchemeType;
using static System.Text.Encoding;
using static YANLib.YANLibConsts;
using static YANLib.YANLibConsts.ElasticsearchIndex;
using static YANLib.YANText;

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
    typeof(AbpEventBusAzureModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(AbpAspNetCoreSignalRModule),
    typeof(AbpBackgroundJobsHangfireModule),
    typeof(AbpAspNetCoreSerilogModule)
)]
public class YANLibHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        ConfigureSqlServer();
        ConfigureApiVersioning(context);
        //ConfigureAzureApplicationInsights(context);
        ConfigureAuthentication(context, configuration);
        ConfigureCors(context, configuration);
        ConfigureSwaggerServices(context, configuration);
        ConfigureElasticsearch(context, configuration);
        ConfigureCap(context, configuration);
        ConfigureHangfire(context, configuration);
        ConfigureHealthChecks(context, configuration);
    }

    private void ConfigureSqlServer() => Configure<AbpDbContextOptions>(static o => o.UseSqlServer());

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

        Configure<AbpAspNetCoreMvcOptions>(static o => o.ChangeControllerModelApiExplorerGroupName = false);
    }

    //private static void ConfigureAzureApplicationInsights(ServiceConfigurationContext context) => context.Services.AddApplicationInsightsTelemetry();

    private static void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration) => context.Services.AddAuthentication(AuthenticationScheme).AddJwtBearer(o =>
    {
        o.Authority = configuration["AuthServer:Authority"];
        o.RequireHttpsMetadata = configuration["AuthServer:RequireHttpsMetadata"].Parse<bool>();
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
        var corsOrigins = configuration["App:CorsOrigins"]?.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(o => o.RemovePostFix("/")).ToArray();

        if (corsOrigins.IsNullEmpty())
        {
            return;
        }

        _ = context.Services.AddCors(s => s.AddDefaultPolicy(b => b.WithOrigins(corsOrigins).WithAbpExposedHeaders().SetIsOriginAllowedToAllowWildcardSubdomains().AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
    }

    private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
    {
        _ = context.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        var authority = configuration["AuthServer:Authority"];

        if (authority.IsNullWhiteSpace())
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
                    }, []
                }
            });

            //o.CustomSchemaIds(static t => t.FullName?.Replace("+", "."));
            o.DocumentFilter<CustomSwaggerFilter>(); //o.HideAbpEndpoints();
            o.EnableAnnotations();
            o.DescribeAllParametersInCamelCase();
        });
    }

    private static void ConfigureElasticsearch(ServiceConfigurationContext context, IConfiguration configuration)
        => context.Services.AddElasticsearch(configuration, defaultIndexName: configuration.GetSection(Developer)?.Value, indexMappings: configuration.CreateIndexMappings(
            (typeof(DeveloperEsIndex), Developer),
            (typeof(ProjectEsIndex), Project)
        ));

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

                if (dbName.IsNullWhiteSpace() || connectionString.IsNullWhiteSpace())
                {
                    return;
                }

                o.DatabaseName = dbName;
                o.DatabaseConnection = connectionString;
            });

            _ = c.UseKafka(o =>
            {
                var connection = configuration["CAP:Kafka:Connections:Default:BootstrapServers"];

                if (connection.IsNullWhiteSpace())
                {
                    return;
                }

                o.Servers = connection;
                o.MainConfig.Add("security.protocol", "SASL_PLAINTEXT");
                o.MainConfig.Add("sasl.mechanism", "PLAIN");

                var username = configuration["CAP:Kafka:Username"];

                if (username.IsNotNullWhiteSpace())
                {
                    o.MainConfig.Add("sasl.username", username);
                }

                var password = configuration["CAP:Kafka:Password"];

                if (password.IsNotNullWhiteSpace())
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
            c.FailedRetryCount = configuration["Cap:FailedRetryCount"].Parse<int>();
        });
    }

    private static void ConfigureHangfire(ServiceConfigurationContext context, IConfiguration configuration) => context.Services.AddHangfire(c => c.UseSqlServerStorage(configuration.GetConnectionString(ConnectionStringName.Default)));

    private static void ConfigureHealthChecks(ServiceConfigurationContext context, IConfiguration configuration)
    {
        var healthChecksBuilder = context.Services.AddHealthChecks();
        var sql = configuration["ConnectionStrings:Default"];

        if (sql.IsNotNullWhiteSpace())
        {
            _ = healthChecksBuilder.AddSqlServer(sql, tags: ["db", "sql", "mssql"]);
        }

        var mongo = configuration["CAP:ConnectionString"];

        if (mongo.IsNotNullWhiteSpace())
        {
            _ = healthChecksBuilder.AddMongoDb(mongo, tags: ["db", "nosql", "mongo"]);
        }

        var esUrl = configuration["Elasticsearch:Url"];
        var esUsername = configuration["Elasticsearch:Username"];
        var esPassword = configuration["Elasticsearch:Password"];

        if (AllNotNullWhiteSpace(esUrl, esUsername, esPassword))
        {
            _ = healthChecksBuilder.AddElasticsearch(x => x.UseServer(esUrl!).UseBasicAuthentication(esUsername!, esPassword!), tags: ["db", "nosql", "es"]);
        }

        var redis = configuration["Redis:Configuration"];

        if (redis.IsNotNullWhiteSpace())
        {
            _ = healthChecksBuilder.AddRedis(redis, tags: ["db", "nosql", "redis"]);
        }

        var kafkaBootstrap = configuration["CAP:Kafka:Connections:Default:BootstrapServers"];
        var kafkaUsername = configuration["CAP:Kafka:Username"];
        var kafkaPassword = configuration["CAP:Kafka:Password"];

        if (kafkaBootstrap.IsNotNullWhiteSpace())
        {
            var kafkaConfig = new ProducerConfig
            {
                Acks = Leader,
                SecurityProtocol = SaslPlaintext,
                SaslMechanism = Plain,
                BootstrapServers = kafkaBootstrap,
                SaslUsername = kafkaUsername,
                SaslPassword = kafkaPassword
            };

            _ = healthChecksBuilder.AddKafka(kafkaConfig, tags: ["db", "nosql", "kafka"]);
        }

        var rabbitHostName = configuration["RabbitMQ:Connections:Default:HostName"];
        var rabbitPort = configuration["RabbitMQ:Connections:Default:Port"].Parse<int>(5672);
        var rabbitUsername = configuration["RabbitMQ:Connections:Default:Username"];
        var rabbitPassword = configuration["RabbitMQ:Connections:Default:Password"];
        var rabbitVirtualHost = configuration["RabbitMQ:Connections:Default:VirtualHost"] ?? string.Empty;
        //var rabbitSsl = configuration["RabbitMQ:Connections:Default:Ssl:Enabled"].ToBool();
        //var rabbitServerName = configuration["RabbitMQ:Connections:Default:Ssl:ServerName"];

        if (AllNotNullWhiteSpace(rabbitHostName, rabbitUsername, rabbitPassword))
        {
            _ = healthChecksBuilder.AddRabbitMQ((serviceProvider, rabbitOptions) =>
            {
                rabbitOptions.ConnectionFactory = new ConnectionFactory
                {
                    HostName = rabbitHostName,
                    Port = rabbitPort,
                    UserName = rabbitUsername,
                    Password = rabbitPassword,
                    //VirtualHost = rabbitVirtualHost,
                    //Ssl = new SslOption
                    //{
                    //    Enabled = rabbitSsl,
                    //    ServerName = rabbitServerName
                    //}
                };

                rabbitOptions.Connection = rabbitOptions.ConnectionFactory.CreateConnection();
            }, tags: ["db", "nosql", "rabbit"]);
        }

        //var asb = configuration["Azure:ServiceBus:Connections:Default:ConnectionString"];
        //var asbTopic = configuration["Azure:EventBus:TopicName"];

        //if (AllNotNullWhiteSpace(asb, asbTopic))
        //{
        //    healthChecksBuilder.AddAzureServiceBusTopic(asb!, asbTopic!, tags: ["db", "cloud", "asb"]);
        //}

        var signalRHubUrl = configuration["SignalRHub:Url"] ?? string.Empty;

        _ = healthChecksBuilder.AddHangfire(c =>
        {
            c.MaximumJobsFailed = 1;
            c.MinimumAvailableServers = 1;
        }, tags: ["service", "job", "hangfire"]).AddSignalRHub(signalRHubUrl, tags: ["service", "noti", "signalr"]);

        var profileName = "Tynab";
        var profileSource = new SharedCredentialsFile();

        if (profileSource.TryGetProfile(profileName, out var profile) && TryGetAWSCredentials(profile, profileSource, out var credentials))
        {
            var bucketName = configuration["AWS:S3:BucketName"];

            if (bucketName.IsNotNullWhiteSpace())
            {
                _ = healthChecksBuilder.AddS3(x =>
                {
                    x.Credentials = credentials;
                    x.BucketName = bucketName;

                    x.S3Config = new AmazonS3Config
                    {
                        RegionEndpoint = APSoutheast1
                    };
                }, tags: ["storage", "cloud", "s3"]);
            }

            var environmentName = context.Services.GetHostingEnvironment().EnvironmentName;
            var secretId = $"{environmentName}/YANLib/appsettings";

            _ = healthChecksBuilder.AddSecretsManager(x =>
            {
                x.Credentials = credentials;
                x.RegionEndpoint = APSoutheast1;
                _ = x.AddSecret(secretId);
            }, tags: ["secrets", "cloud", "sm"]).AddCloudWatchPublisher(x =>
            {
                x.ClientBuilder = o => new AmazonCloudWatchClient(credentials, APSoutheast1);
                x.Namespace = "YANLib";
                x.ServiceCheckName = environmentName;
            });
        }

        var aai = configuration["Azure:ApplicationInsights:ConnectionString"];

        if (aai.IsNotNullWhiteSpace())
        {
            _ = healthChecksBuilder.AddApplicationInsightsPublisher(aai);
        }

        _ = context.Services.AddHealthChecksUI()
            //.AddSqlServerStorage(sql!)
            .AddInMemoryStorage();
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
            app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions.ForEach(x => c.SwaggerEndpoint($"/swagger/{x.GroupName}/swagger.json", x.GroupName.ToLowerInvariant()));
            c.OAuthClientId(context.ServiceProvider.GetRequiredService<IConfiguration>()["AuthServer:SwaggerClientId"]);
            c.OAuthScopes("YANLib");
            c.DefaultModelsExpandDepth(-1);
        });

        _ = app.UseUnitOfWork();
        _ = app.UseAuditing();
        _ = app.UseAbpSerilogEnrichers();

        _ = app.UseHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = WriteHealthCheckUIResponse
        });

        _ = app.UseRouting().UseEndpoints(x => x.MapHealthChecksUI(s => s.UIPath = "/health-ui"));

        _ = app.UseHangfireDashboard("/hangfire", new DashboardOptions
        {
            Authorization = [new AllowAllAuthorizationFilter()]
        });

        _ = app.UseConfiguredEndpoints();
    }
}
