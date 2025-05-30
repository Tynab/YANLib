using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Elasticsearch.Net.CertificateValidations;
using static System.Reflection.BindingFlags;
using static System.StringComparison;
using static System.TimeSpan;
using static YANLib.YANExpression;

namespace YANLib;

public static class ElasticsearchConfiguration
{
    public static IServiceCollection AddElasticsearch(
        this IServiceCollection services,
        IConfiguration configuration,
        string urlConfigPath = "Elasticsearch:Url",
        string usernameConfigPath = "Elasticsearch:Username",
        string passwordConfigPath = "Elasticsearch:Password",
        IDictionary<Type, string?>? indexMappings = null,
        int requestTimeout = 2
    )
    {
        try
        {
            ConnectionSettings? settings;
            var urlConfigSection = configuration.GetSection(urlConfigPath);
            var urlConfigChildren = urlConfigSection.GetChildren();

            if (urlConfigChildren.IsNullEmpty())
            {
                var url = urlConfigSection.Value;

                if (url.IsNullWhiteSpace())
                {
                    return services;
                }

                settings = new ConnectionSettings(new SingleNodeConnectionPool(new Uri(url))).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(requestTimeout));
            }
            else
            {
                settings = new ConnectionSettings(new StaticConnectionPool(
                    (urlConfigChildren.IsNullEmpty() ? [urlConfigSection] : urlConfigChildren.ToArray()).Select(static s => s.Value.IsNullWhiteSpace() ? default : new Uri(s.Value)).Where(static u => u.IsNotNull()).ToArray()
                )).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(requestTimeout));
            }

            var username = configuration.GetSection(usernameConfigPath).Value;

            if (username.IsNotNullWhiteSpace())
            {
                _ = settings.ServerCertificateValidationCallback(static (o, certificate, chain, errors) => true);
                _ = settings.ServerCertificateValidationCallback(AllowAll);
                _ = settings.BasicAuthentication(username, configuration.GetSection(passwordConfigPath).Value);
            }

            var client = new ElasticClient(settings);

            if (indexMappings.IsNotNull())
            {
                foreach (var mapping in indexMappings)
                {
                    var indexType = mapping.Key;
                    var indexName = (mapping.Value ?? $"{indexType.Namespace?.Split('.')[0]}_{indexType.Name
                        .Replace("elasticsearchindex", string.Empty, OrdinalIgnoreCase)
                        .Replace("elasticsearch", string.Empty, OrdinalIgnoreCase)
                        .Replace("index", string.Empty, OrdinalIgnoreCase)}_index_{services.GetAbpHostEnvironment().EnvironmentName ?? "dev"}").ToLowerInvariant();

                    _ = typeof(ElasticsearchConfiguration).GetMethod(nameof(ConfigureDefaultMappingGeneric), NonPublic | Static)?.MakeGenericMethod(indexType)?.Invoke(null, [settings, indexName]);

                    if (!client.Indices.Exists(indexName).Exists)
                    {
                        _ = typeof(ElasticsearchConfiguration).GetMethod(nameof(CreateIndexGeneric), NonPublic | Static)?.MakeGenericMethod(indexType)?.Invoke(null, [client, indexName]);
                    }
                }
            }

            _ = services.AddSingleton<IElasticClient>(client);

            return services;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error configuring Elasticsearch: {ex.Message}");

            return services;
        }
    }

    private static void ConfigureDefaultMappingGeneric<T>(ConnectionSettings settings, string indexName) where T : class => settings.DefaultMappingFor<T>(m => m.IndexName(indexName));

    private static void CreateIndexGeneric<T>(IElasticClient client, string indexName) where T : class => client.Indices.Create(indexName, static c => c.Map<T>(m => m.AutoMap()));

    public static async Task<DeleteIndexResponse?> DeleteIndexAsync(this IElasticClient client, IConfiguration configuration, string indexPath, CancellationToken cancellationToken = default)
    {
        var index = configuration.GetSection(indexPath)?.Value;

        return index.IsNullWhiteSpace() ? default : await client.Indices.DeleteAsync(index, ct: cancellationToken);
    }
}
