using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using YANLib.Entities;
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
            settings = new ConnectionSettings(new StaticConnectionPool((
                urlConfigChildren.Any()
                ? urlConfigChildren.ToArray()
                : [urlConfigSection]
            ).Select(static s => s.Value.IsNullWhiteSpace() ? default : new Uri(s.Value)).Where(static u => u.IsNotNull()).ToArray())).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(requestTimeout));
        }

        var username = configuration.GetSection(usernameConfigPath).Value;

        if (username.IsNotNullWhiteSpace())
        {
            _ = settings.ServerCertificateValidationCallback(static (o, certificate, chain, errors) => true);
            _ = settings.ServerCertificateValidationCallback(AllowAll);
            _ = settings.BasicAuthentication(username, configuration.GetSection(passwordConfigPath).Value);
        }

        if (indexMappings.IsNotNull())
        {
            foreach (var mapping in indexMappings)
            {
                var indexType = mapping.Key;
                var indexName = mapping.Value ?? $"{indexType.Namespace?.Split('.')[0]}_{indexType.Name
                    .Replace("elasticsearchindex", string.Empty, OrdinalIgnoreCase)
                    .Replace("elasticsearch", string.Empty, OrdinalIgnoreCase)
                    .Replace("index", string.Empty, OrdinalIgnoreCase)}_index_{services.GetAbpHostEnvironment().EnvironmentName ?? "dev"}".ToLowerInvariant();

                var method = typeof(ElasticsearchConfiguration).GetMethod(nameof(CreateMappingDescriptor), NonPublic | Static)?.MakeGenericMethod(indexType);

                if (method.IsNotNull())
                {
                    _ = ((typeof(ConnectionSettings).GetMethod(nameof(ConnectionSettings.DefaultMappingFor))?.MakeGenericMethod(indexType))?.Invoke(settings, [Delegate.CreateDelegate(
                        typeof(Func<,>).MakeGenericType(typeof(ClrTypeMappingDescriptor<>).MakeGenericType(indexType), typeof(ClrTypeMappingDescriptor<>).MakeGenericType(indexType)), method, indexName
                    )]));


                    _ = (typeof(ConnectionSettings).GetMethod(nameof(ConnectionSettings.DefaultMappingFor))?.MakeGenericMethod(indexType)?.Invoke(settings, [Delegate.CreateDelegate(
                        typeof(Func<,>).MakeGenericType(typeof(ClrTypeMappingDescriptor<>).MakeGenericType(indexType), typeof(ClrTypeMappingDescriptor<>).MakeGenericType(indexType)), indexName, method
                    )]));
                }
            }
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

    private static ClrTypeMappingDescriptor<T> CreateMappingDescriptor<T>(string indexName) where T : class => new ClrTypeMappingDescriptor<T>().IndexName(indexName);

    private static void CreateIndexGeneric<T>(IElasticClient client, string indexName) where T : class => client.Indices.Create(indexName, static c => c
        .Map<T>(static t => t
            .AutoMap()
            .Properties(static p => p
                .Text(static d => d
                    .Name("Id")))));

    public static async Task<DeleteIndexResponse?> DeleteIndexAsync(this IElasticClient client, IConfiguration configuration, string indexPath, CancellationToken cancellationToken = default)
    {
        var index = configuration.GetSection(indexPath)?.Value;

        return index.IsNullWhiteSpace() ? default : await client.Indices.DeleteAsync(index, ct: cancellationToken);
    }
}
