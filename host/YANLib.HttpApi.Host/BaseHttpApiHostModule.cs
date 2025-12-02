#if RELEASE
using EOE.CCSBE.Middlewares;
#endif

using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Elastic.Apm.DiagnosticSource;
using Elastic.Apm.EntityFrameworkCore;
using Elastic.Apm.NetCoreAll;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using NUglify.Helpers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.RateLimiting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.Users;
using YANLib;
using static Asp.Versioning.ApiVersionReader;
using static Elastic.Apm.Agent;
using static YANLib.BaseConsts;
using static YANLib.BaseErrorCodes;
using static Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static Microsoft.OpenApi.Models.ReferenceType;
using static Microsoft.OpenApi.Models.SecuritySchemeType;
using static System.Globalization.NumberFormatInfo;
using static System.Text.Encoding;
using static System.Threading.RateLimiting.MetadataName;
using static System.Threading.RateLimiting.RateLimitPartition;
using static System.TimeSpan;
using YANLib.Application.Es;
using YANLib.EsIndices;
using YANLib.Options;
using YANLib.Filters;

namespace YANLib;

[DependsOn(
    typeof(BaseHttpApiModule),
    typeof(BaseApplicationModule),
    typeof(BaseEntityFrameworkCoreModule),
    typeof(AbpAutofacModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpHttpClientModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpAspNetCoreSignalRModule),
    typeof(AbpBackgroundJobsHangfireModule),
    typeof(AbpAspNetCoreSerilogModule)
)]
public class BaseHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        ConfigureNpgsql();
        ConfigureApiVersioning(context);
        ConfigureAuthentication(context, configuration);
        ConfigureCors(context, configuration);
        ConfigureElasticsearch(context, configuration);
        ConfigureSwaggerServices(context, configuration);
        ConfigureCap(context, configuration);
        ConfigureHangfire(context, configuration);
        ConfigureRateLimiters(context, configuration);
    }

    private void ConfigureNpgsql() => Configure<AbpDbContextOptions>(static o => o.UseNpgsql());

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

    private static void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration) => context.Services.AddAuthentication(AuthenticationScheme).AddJwtBearer(o =>
    {
        var auth = configuration.GetSection("AuthServer").Get<AuthServerOption>() ?? new();
        var jwt = configuration.GetSection("JWT").Get<JwtOption>() ?? new();

        o.Authority = auth.Authority;
        o.RequireHttpsMetadata = auth.RequireHttpsMetadata;
        o.Audience = auth.SwaggerClientId;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt.Issuer,
            ValidAudience = jwt.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(UTF8.GetBytes(jwt.Secret ?? string.Empty))
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

    private static void ConfigureElasticsearch(ServiceConfigurationContext context, IConfiguration configuration)
    {
        var indexMappings = new Dictionary<Type, string?>
        {
            { typeof(SampleEsIndex), configuration["Elasticsearch:Indices:Sample"] },
        };

        _ = context.Services.AddEs(configuration, indexMappings: indexMappings);
    }

    private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
    {
        _ = context.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOption>();

        var authority = configuration["AuthServer:Authority"];

        if (authority.IsNullWhiteSpace())
        {
            return;
        }

        var namesapce = typeof(BaseHttpApiHostModule).Namespace?.Split('.')[1] ?? string.Empty;

        _ = context.Services.AddAbpSwaggerGenWithOAuth(authority, new Dictionary<string, string>
        {
            {namesapce, $"{namesapce} API"}
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

            o.DocumentFilter<CustomSwaggerFilter>();
            o.EnableAnnotations();
            o.DescribeAllParametersInCamelCase();
        });
    }

    private static void ConfigureCap(ServiceConfigurationContext context, IConfiguration configuration)
    {
        var cap = configuration.GetSection("CAP").Get<CapOption>() ?? new();

        _ = context.Services.AddSingleton<IMongoClient>(new MongoClient(cap.ConnectionString));

        _ = context.Services.AddCap(c =>
        {
            _ = c.UseDashboard(o => o.PathMatch = "/cap");

            _ = c.UseMongoDB(o =>
            {
                o.DatabaseName = cap.DBName ?? string.Empty;
                o.DatabaseConnection = cap.ConnectionString ?? string.Empty;
            });

            _ = c.UseRabbitMQ(o =>
            {
                o.HostName = cap.RabbitMQ.HostName ?? string.Empty;
                o.Port = cap.RabbitMQ.Port;
                o.UserName = cap.RabbitMQ.Username ?? string.Empty;
                o.Password = cap.RabbitMQ.Password ?? string.Empty;
                o.VirtualHost = cap.RabbitMQ.VirtualHost ?? string.Empty;
                o.ExchangeName = cap.RabbitMQ.ExchangeName ?? string.Empty;
            });

            c.DefaultGroupName = cap.DefaultGroupName ?? string.Empty;
        });
    }

    private static void ConfigureHangfire(ServiceConfigurationContext context, IConfiguration configuration)
        => context.Services.AddHangfire(c => c.UsePostgreSqlStorage(o => o.UseNpgsqlConnection(configuration.GetConnectionString(ConnectionStringName.Default))));

    private static void ConfigureRateLimiters(ServiceConfigurationContext context, IConfiguration configuration) => context.Services.AddRateLimiter(o =>
    {
        o.RejectionStatusCode = Status429TooManyRequests;

        o.OnRejected = static (c, ct) =>
        {
            if (c.Lease.TryGetMetadata(RetryAfter, out var retryAfter))
            {
                c.HttpContext.Response.Headers.RetryAfter = retryAfter.TotalSeconds.Parse<int>().ToString(InvariantInfo);
            }

            c.HttpContext.Response.StatusCode = Status429TooManyRequests;
            c.HttpContext.RequestServices.GetService<ILoggerFactory>()?.CreateLogger("Microsoft.AspNetCore.RateLimitingMiddleware").LogWarning("OnRejected: {RequestPath}", c.HttpContext.Request.Path);

            return new ValueTask();
        };

        _ = o.AddPolicy("UserBasedRateLimiting", c =>
        {
            var currentUser = c.RequestServices.GetService<ICurrentUser>();
            var userBasedRateLimiting = configuration.GetSection("RateLimiting:UserBased").Get<UserBasedRateLimitOption>() ?? new();

            if (currentUser.IsNotNull() && currentUser.IsAuthenticated && currentUser.UserName.IsNotNullWhiteSpace())
            {
                return GetTokenBucketLimiter(currentUser.UserName, _ => new TokenBucketRateLimiterOptions
                {
                    TokenLimit = userBasedRateLimiting.Authenticated.TokenLimit,
                    QueueProcessingOrder = userBasedRateLimiting.Authenticated.QueueProcessingOrder,
                    QueueLimit = userBasedRateLimiting.Authenticated.QueueLimit,
                    ReplenishmentPeriod = FromSeconds(userBasedRateLimiting.Authenticated.ReplenishmentPeriodSeconds),
                    TokensPerPeriod = userBasedRateLimiting.Authenticated.TokensPerPeriod,
                    AutoReplenishment = userBasedRateLimiting.Authenticated.AutoReplenishment
                });
            }

            var ipAddress = c.Connection.RemoteIpAddress?.ToString() ?? "unknown-user";

            return GetSlidingWindowLimiter(ipAddress, _ => new SlidingWindowRateLimiterOptions
            {
                PermitLimit = userBasedRateLimiting.Anonymous.PermitLimit,
                QueueProcessingOrder = userBasedRateLimiting.Anonymous.QueueProcessingOrder,
                QueueLimit = userBasedRateLimiting.Anonymous.QueueLimit,
                Window = FromSeconds(userBasedRateLimiting.Anonymous.WindowSeconds),
                SegmentsPerWindow = userBasedRateLimiting.Anonymous.SegmentsPerWindow
            });
        });
    });

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();

        if (context.GetEnvironment().IsDevelopment())
        {
            _ = app.UseDeveloperExceptionPage();

            _ = app.Use(async (c, n) =>
            {
                try
                {
                    await n();
                }
                catch (Exception)
                {
                    c.Response.Clear();
                    c.Response.StatusCode = Status500InternalServerError;
                    c.Response.ContentType = "application/json";

                    await c.Response.WriteAsync(new
                    {
                        error = new
                        {
                            code = INTERNAL_SERVER_ERROR,
                            message = BaseErrorMessages.INTERNAL_SERVER_ERROR
                        }
                    }.Serialize() ?? string.Empty);
                }
            });
        }
        else
        {
            _ = app.UseHsts();
        }

        _ = app.UseAllElasticApm(context.GetConfiguration());
        _ = Subscribe(new HttpDiagnosticsSubscriber());
        _ = Subscribe(new EfCoreDiagnosticsSubscriber());
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
            c.OAuthScopes(typeof(BaseHttpApiHostModule).Namespace?.Split('.')[1]);
            c.DefaultModelsExpandDepth(-1);
        });

        _ = app.UseUnitOfWork();
        _ = app.UseAuditing();
        _ = app.UseAbpSerilogEnrichers();

        _ = app.UseHangfireDashboard("/hangfire", new DashboardOptions
        {
            Authorization = [new AllowAllAuthorizationFilter()]
        });

        _ = app.UseRateLimiter();
        _ = app.UseConfiguredEndpoints(e => e.MapControllers().RequireRateLimiting("UserBasedRateLimiting"));
    }
}
