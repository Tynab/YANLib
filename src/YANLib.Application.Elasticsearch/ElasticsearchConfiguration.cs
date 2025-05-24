//using Elasticsearch.Net;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Nest;
//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using YANLib.EsIndices;
//using static Elasticsearch.Net.CertificateValidations;
//using static System.TimeSpan;
//using static YANLib.YANLibConsts.ElasticsearchIndex;

//namespace YANLib;

//public static class ElasticsearchConfiguration
//{
//    private static string? _indexDeveloper;
//    private static string? _indexProject;

//    public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
//    {
//        var urlTag = "Elasticsearch:Url";
//        var usernameTag = "Elasticsearch:Username";
//        var passwordTag = "Elasticsearch:Password";

//        ConnectionSettings? settings;

//        if (configuration.GetSection(urlTag).GetChildren().IsNullEmpty())
//        {
//            var esUrl = configuration.GetSection(urlTag).Value;

//            if (esUrl.IsNullWhiteSpace())
//            {
//                return;
//            }

//            settings = new ConnectionSettings(new SingleNodeConnectionPool(new Uri(esUrl))).DefaultIndex(configuration.GetSection(Developer)?.Value).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(2));
//        }
//        else
//        {
//            settings = new ConnectionSettings(new StaticConnectionPool(
//                (configuration.GetSection(urlTag).GetChildren().Any() ? configuration.GetSection(urlTag).GetChildren().ToArray() : [configuration.GetSection(urlTag)]).Select(static s => s.Value.IsNullWhiteSpace()
//                ? default
//                : new Uri(s.Value)).ToArray()
//            )).DefaultIndex(configuration.GetSection(Developer)?.Value).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(2));
//        }

//        if (configuration.GetSection(usernameTag).Value.IsNotNullWhiteSpace())
//        {
//            _ = settings.ServerCertificateValidationCallback(static (o, certificate, chain, errors) => true);
//            _ = settings.ServerCertificateValidationCallback(AllowAll);
//            _ = settings.BasicAuthentication(configuration.GetSection(usernameTag).Value, configuration.GetSection(passwordTag).Value);
//        }

//        _indexDeveloper = configuration.GetSection(Developer)?.Value;
//        _ = settings.DefaultMappingFor<DeveloperEsIndex>(static m => m.IndexName(_indexDeveloper));

//        _indexProject = configuration.GetSection(Project)?.Value;
//        _ = settings.DefaultMappingFor<ProjectEsIndex>(static m => m.IndexName(_indexProject));

//        var client = new ElasticClient(settings);

//        if (!client.Indices.Exists(configuration.GetSection(Developer)?.Value).Exists)
//        {
//            _ = client.Indices.Create(configuration.GetSection(Developer).Value, static c => c
//                .Map<DeveloperEsIndex>(static t => t
//                    .AutoMap().Properties(static p => p
//                    .Text(static d => d
//                        .Name(static x => x.Id)))));
//        }

//        if (!client.Indices.Exists(configuration.GetSection(Project)?.Value).Exists)
//        {
//            _ = client.Indices.Create(configuration.GetSection(Project).Value, static c => c
//                .Map<ProjectEsIndex>(static t => t
//                    .AutoMap().Properties(static p => p
//                    .Text(static d => d
//                        .Name(static x => x.Id)))));
//        }

//        _ = services.AddSingleton<IElasticClient>(client);
//    }

//    public static async Task<DeleteIndexResponse?> DeleteIndexAsync(this IElasticClient client, IConfiguration configuration, string indexPath, CancellationToken cancellationToken = default)
//    {
//        var index = configuration.GetSection(indexPath)?.Value;

//        return index.IsNullWhiteSpace() ? default : await client.Indices.DeleteAsync(index, ct: cancellationToken);
//    }
//}

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
using static System.TimeSpan;
using static System.Reflection.BindingFlags;
using static YANLib.YANText;

namespace YANLib;

public static class ElasticsearchConfiguration
{
    /// <summary>
    /// Adds Elasticsearch services to the specified IServiceCollection with custom index mappings
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to</param>
    /// <param name="configuration">The configuration instance</param>
    /// <param name="urlConfigPath">Configuration path for Elasticsearch URL(s)</param>
    /// <param name="usernameConfigPath">Configuration path for Elasticsearch username</param>
    /// <param name="passwordConfigPath">Configuration path for Elasticsearch password</param>
    /// <param name="defaultIndexName">Default index name to use</param>
    /// <param name="indexMappings">Dictionary mapping index types to index names</param>
    /// <param name="requestTimeout">Request timeout in minutes (default: 2)</param>
    /// <returns>The service collection for chaining</returns>
    public static IServiceCollection AddElasticsearch(
        this IServiceCollection services,
        IConfiguration configuration,
        string urlConfigPath = "Elasticsearch:Url",
        string usernameConfigPath = "Elasticsearch:Username",
        string passwordConfigPath = "Elasticsearch:Password",
        string? defaultIndexName = null,
        IDictionary<Type, string>? indexMappings = null,
        int requestTimeout = 2
    )
    {
        ConnectionSettings? settings;

        if (configuration.GetSection(urlConfigPath).GetChildren().IsNullEmpty())
        {
            var esUrl = configuration.GetSection(urlConfigPath).Value;

            if (esUrl.IsNullWhiteSpace())
            {
                return services;
            }

            settings = new ConnectionSettings(
                new SingleNodeConnectionPool(new Uri(esUrl))
            ).DefaultIndex(defaultIndexName).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(requestTimeout));
        }
        else
        {
            settings = new ConnectionSettings(
                new StaticConnectionPool((configuration.GetSection(urlConfigPath).GetChildren().Any()
                ? configuration.GetSection(urlConfigPath).GetChildren().ToArray()
                : [configuration.GetSection(urlConfigPath)]).Select(s => s.Value.IsNullWhiteSpace() ? default : new Uri(s.Value)).Where(u => u.IsNotNull()).ToArray())
            ).DefaultIndex(defaultIndexName).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(requestTimeout));
        }

        var username = configuration.GetSection(usernameConfigPath).Value;

        if (username.IsNotNullWhiteSpace())
        {
            _ = settings.ServerCertificateValidationCallback(static (o, certificate, chain, errors) => true);
            _ = settings.ServerCertificateValidationCallback(AllowAll);
            _ = settings.BasicAuthentication(username, configuration.GetSection(passwordConfigPath).Value);
        }

        if (indexMappings.IsNotNullEmpty())
        {
            foreach (var mapping in indexMappings)
            {
                _ = ((typeof(ConnectionSettingsBase<ConnectionSettings>).GetMethod(nameof(ConnectionSettingsBase<>.DefaultMappingFor))?.MakeGenericMethod(mapping.Key))?.Invoke(
                    settings,
                    [new Func<ClrTypeMappingDescriptor<object>, IClrTypeMapping<object>>(m => m.IndexName(mapping.Value))]
                ));
            }
        }

        var client = new ElasticClient(settings);

        if (indexMappings.IsNotNull())
        {
            foreach (var mapping in indexMappings)
            {
                if (!client.Indices.Exists(mapping.Value).Exists)
                {
                    _ = ((typeof(ElasticsearchConfiguration).GetMethod(nameof(CreateIndex), NonPublic | Static)?.MakeGenericMethod(mapping.Key))?.Invoke(
                        null,
                        [client, mapping.Value]
                    ));
                }
            }
        }

        _ = services.AddSingleton<IElasticClient>(client);

        return services;
    }

    /// <summary>
    /// Helper method to create index mappings from configuration
    /// </summary>
    /// <param name="configuration">The configuration instance</param>
    /// <param name="mappings">Tuples of (IndexType, ConfigPath) to map</param>
    /// <returns>Dictionary mapping index types to index names</returns>
    public static IDictionary<Type, string> CreateIndexMappings(this IConfiguration configuration, params (Type IndexType, string ConfigPath)[] mappings)
    {
        var result = new Dictionary<Type, string>();

        foreach (var (indexType, configPath) in mappings)
        {
            var indexName = configuration.GetSection(configPath)?.Value;

            if (indexName.IsNotNullWhiteSpace())
            {
                result.Add(indexType, indexName);
            }
        }

        return result;
    }

    /// <summary>
    /// Creates an index with auto-mapping for the specified type
    /// </summary>
    private static void CreateIndex<T>(IElasticClient client, string indexName) where T : class => client.Indices.Create(indexName, static c => c
        .Map<T>(static t => t
            .AutoMap()
            .Properties(static p => p
                .Text(static d => d
                    .Name("Id")))));

    /// <summary>
    /// Deletes an index asynchronously
    /// </summary>
    public static async Task<DeleteIndexResponse?> DeleteIndexAsync(this IElasticClient client, IConfiguration configuration, string indexPath, CancellationToken cancellationToken = default)
    {
        var index = configuration.GetSection(indexPath)?.Value;

        return index.IsNullWhiteSpace() ? default : await client.Indices.DeleteAsync(index, ct: cancellationToken);
    }
}
