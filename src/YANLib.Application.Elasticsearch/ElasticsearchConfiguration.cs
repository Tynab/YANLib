using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Linq;
using YANLib.EsIndices;
using YANLib.Object;
using static Elasticsearch.Net.CertificateValidations;
using static System.TimeSpan;
using static YANLib.YANLibConsts.ElasticsearchIndex;

namespace YANLib;

public static class ElasticsearchConfiguration
{
    private static string? _indexDeveloper;
    private static string? _indexCertificate;

    public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        var urlTag = "Elasticsearch:Url";
        var usernameTag = "Elasticsearch:Username";
        var passwordTag = "Elasticsearch:Password";

        ConnectionSettings? settings;

        if (configuration.GetSection(urlTag).GetChildren().IsNullOEmpty())
        {
            var esUrl = configuration.GetSection(urlTag).Value;

            if (esUrl.IsNullOWhiteSpace())
            {
                return;
            }

            settings = new ConnectionSettings(new SingleNodeConnectionPool(new Uri(esUrl))).DefaultIndex(configuration.GetSection(Developer)?.Value).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(2));
        }
        else
        {
            settings = new ConnectionSettings(new StaticConnectionPool((configuration.GetSection(urlTag).GetChildren().Any()
                ? configuration.GetSection(urlTag).GetChildren().ToArray()
                : ([configuration.GetSection(urlTag)])).Select(s => s.Value.IsNullOWhiteSpace()
                ? default
                : new Uri(s.Value)).ToArray())).DefaultIndex(configuration.GetSection(Developer)?.Value).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(2));
        }

        if (configuration.GetSection(usernameTag).Value.IsNotNullNWhiteSpace())
        {
            _ = settings.ServerCertificateValidationCallback((o, certificate, chain, errors) => true);
            _ = settings.ServerCertificateValidationCallback(AllowAll);
            _ = settings.BasicAuthentication(configuration.GetSection(usernameTag).Value, configuration.GetSection(passwordTag).Value);
        }

        _indexDeveloper = configuration.GetSection(Developer)?.Value;
        _ = settings.DefaultMappingFor<DeveloperEsIndex>(m => m.IndexName(_indexDeveloper));

        _indexCertificate = configuration.GetSection(Certificate)?.Value;
        _ = settings.DefaultMappingFor<CertificateEsIndex>(m => m.IndexName(_indexCertificate));

        var client = new ElasticClient(settings);

        if (!client.Indices.Exists(configuration.GetSection(Developer)?.Value).Exists)
        {
            _ = client.Indices.Create(configuration.GetSection(Developer).Value, c => c
                .Map<DeveloperEsIndex>(t => t
                    .AutoMap().Properties(p => p
                    .Text(d => d
                        .Name(x => x.Id)))));
        }

        if (!client.Indices.Exists(configuration.GetSection(Certificate)?.Value).Exists)
        {
            _ = client.Indices.Create(configuration.GetSection(Certificate).Value, c => c
                .Map<CertificateEsIndex>(t => t
                    .AutoMap().Properties(p => p
                    .Text(d => d
                        .Name(x => x.Id)))));
        }

        _ = services.AddSingleton<IElasticClient>(client);
    }

    public static DeleteIndexResponse? DeleteIndex(this IElasticClient client, IConfiguration configuration, string indexPath)
    {
        var index = configuration.GetSection(indexPath)?.Value;

        return index.IsNullOWhiteSpace() ? default : client.Indices.Delete(index);
    }
}
