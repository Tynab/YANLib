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
        ConnectionSettings? settings;

        if (configuration.GetSection(urlConfigPath).GetChildren().IsNullEmpty())
        {
            var url = configuration.GetSection(urlConfigPath).Value;

            if (url.IsNullWhiteSpace())
            {
                return services;
            }

            settings = new ConnectionSettings(new SingleNodeConnectionPool(new Uri(url))).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(requestTimeout));
        }
        else
        {
            var uris = (configuration.GetSection(urlConfigPath).GetChildren().Any()
                ? configuration.GetSection(urlConfigPath).GetChildren().ToArray()
                : [configuration.GetSection(urlConfigPath)]).Select(s => s.Value.IsNullWhiteSpace() ? default : new Uri(s.Value)).Where(u => u.IsNotNull()).ToArray();

            settings = new ConnectionSettings(new StaticConnectionPool(uris)).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(requestTimeout));
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

                if (!client.Indices.Exists(indexName).Exists)
                {
                    _ = ((typeof(ElasticsearchConfiguration).GetMethod(nameof(CreateIndexGeneric), NonPublic | Static)?.MakeGenericMethod(indexType))?.Invoke(null, [client, indexName]));
                }
            }
        }

        _ = services.AddSingleton<IElasticClient>(client);

        return services;
    }

    //private static void CreateIndexForType(IElasticClient client, string indexName, Type indexType)
    //    => (typeof(ElasticsearchConfiguration).GetMethod(nameof(CreateIndexGeneric), NonPublic | Static)?.MakeGenericMethod(indexType))?.Invoke(null, [client, indexName]);

    private static void CreateIndexGeneric<T>(IElasticClient client, string indexName) where T : class => client.Indices.Create(indexName, c => c
        .Map<T>(t => t
            .AutoMap()
            .Properties(p => p
                .Text(d => d
                    .Name("Id")))));

    public static async Task<DeleteIndexResponse?> DeleteIndexAsync(this IElasticClient client, IConfiguration configuration, string indexPath, CancellationToken cancellationToken = default)
    {
        var index = configuration.GetSection(indexPath)?.Value;

        return index.IsNullWhiteSpace() ? default : await client.Indices.DeleteAsync(index, ct: cancellationToken);
    }
}
