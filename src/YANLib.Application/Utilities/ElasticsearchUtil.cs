using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Linq;
using YANLib.Core;
using YANLib.EsIndices;
using static Elasticsearch.Net.CertificateValidations;
using static System.TimeSpan;
using static YANLib.YANLibConsts.ElasticsearchIndex;

namespace YANLib.Utilities;

public static class ElasticsearchUtil
{
    private static string? _indexDeveloper;
    private static string? _indexCertificate;

    public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        var urlTag = "Elasticsearch:Url";
        var usernameTag = "Elasticsearch:Username";
        var pwdTag = "Elasticsearch:Password";

        ConnectionSettings? settings;
        if (configuration.GetSection(urlTag).GetChildren().Any())
        {
            settings = new ConnectionSettings(new StaticConnectionPool((configuration.GetSection(urlTag).GetChildren().Any()
                ? configuration.GetSection(urlTag).GetChildren().ToArray()
                : ([configuration.GetSection(urlTag)])).Select(s => s.Value.IsWhiteSpaceOrNull() ? default : new Uri(s.Value)).ToArray())).DefaultIndex(configuration.GetSection(Developer)?.Value).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(2));
        }
        else
        {
            var esUrl = configuration.GetSection(urlTag).Value;

            if (esUrl.IsWhiteSpaceOrNull())
            {
                return;
            }

            settings = new ConnectionSettings(new SingleNodeConnectionPool(new Uri(esUrl))).DefaultIndex(configuration.GetSection(Developer)?.Value).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(2));
        }

        if (configuration.GetSection(usernameTag).Value.IsNotWhiteSpaceAndNull())
        {
            _ = settings.ServerCertificateValidationCallback((o, certificate, chain, errors) => true);
            _ = settings.ServerCertificateValidationCallback(AllowAll);
            _ = settings.BasicAuthentication(configuration.GetSection(usernameTag).Value, configuration.GetSection(pwdTag).Value);
        }

        _indexDeveloper = configuration.GetSection(Developer)?.Value;
        _ = settings.DefaultMappingFor<DeveloperEsIndex>(m => m.IndexName(_indexDeveloper));
        _indexCertificate = configuration.GetSection(Certificate)?.Value;
        _ = settings.DefaultMappingFor<DeveloperEsIndex>(m => m.IndexName(_indexCertificate));

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

    public static DeleteIndexResponse? DeleteDeveloperIndex(this IElasticClient client) => _indexDeveloper.IsNotWhiteSpaceAndNull() ? client.Indices.Delete(_indexDeveloper) : default;

    public static DeleteIndexResponse? DeleteCertificateIndex(this IElasticClient client) => _indexCertificate.IsNotWhiteSpaceAndNull() ? client.Indices.Delete(_indexCertificate) : default;
}
