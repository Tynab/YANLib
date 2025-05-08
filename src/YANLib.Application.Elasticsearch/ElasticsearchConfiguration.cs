using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Linq;
using YANLib.EsIndices;
using static Elasticsearch.Net.CertificateValidations;
using static System.TimeSpan;
using static YANLib.YANLibConsts.ElasticsearchIndex;

namespace YANLib;

public static class ElasticsearchConfiguration
{
    private static string? _indexDeveloper;
    private static string? _indexProject;

    public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        var urlTag = "Elasticsearch:Url";
        var usernameTag = "Elasticsearch:Username";
        var passwordTag = "Elasticsearch:Password";

        ConnectionSettings? settings;

        if (configuration.GetSection(urlTag).GetChildren().IsNullEmpty())
        {
            var esUrl = configuration.GetSection(urlTag).Value;

            if (esUrl.IsNullWhiteSpace())
            {
                return;
            }

            settings = new ConnectionSettings(new SingleNodeConnectionPool(new Uri(esUrl))).DefaultIndex(configuration.GetSection(Developer)?.Value).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(2));
        }
        else
        {
            settings = new ConnectionSettings(new StaticConnectionPool(
                (configuration.GetSection(urlTag).GetChildren().Any() ? configuration.GetSection(urlTag).GetChildren().ToArray() : [configuration.GetSection(urlTag)]).Select(static s => s.Value.IsNullWhiteSpace()
                ? default
                : new Uri(s.Value)).ToArray()
            )).DefaultIndex(configuration.GetSection(Developer)?.Value).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(2));
        }

        if (configuration.GetSection(usernameTag).Value.IsNotNullWhiteSpace())
        {
            _ = settings.ServerCertificateValidationCallback(static (o, certificate, chain, errors) => true);
            _ = settings.ServerCertificateValidationCallback(AllowAll);
            _ = settings.BasicAuthentication(configuration.GetSection(usernameTag).Value, configuration.GetSection(passwordTag).Value);
        }

        _indexDeveloper = configuration.GetSection(Developer)?.Value;
        _ = settings.DefaultMappingFor<DeveloperEsIndex>(static m => m.IndexName(_indexDeveloper));

        _indexProject = configuration.GetSection(Project)?.Value;
        _ = settings.DefaultMappingFor<ProjectEsIndex>(static m => m.IndexName(_indexProject));

        var client = new ElasticClient(settings);

        if (!client.Indices.Exists(configuration.GetSection(Developer)?.Value).Exists)
        {
            _ = client.Indices.Create(configuration.GetSection(Developer).Value, static c => c
                .Map<DeveloperEsIndex>(static t => t
                    .AutoMap().Properties(static p => p
                    .Text(static d => d
                        .Name(static x => x.Id)))));
        }

        if (!client.Indices.Exists(configuration.GetSection(Project)?.Value).Exists)
        {
            _ = client.Indices.Create(configuration.GetSection(Project).Value, static c => c
                .Map<ProjectEsIndex>(static t => t
                    .AutoMap().Properties(static p => p
                    .Text(static d => d
                        .Name(static x => x.Id)))));
        }

        _ = services.AddSingleton<IElasticClient>(client);
    }

    public static DeleteIndexResponse? DeleteIndex(this IElasticClient client, IConfiguration configuration, string indexPath)
    {
        var index = configuration.GetSection(indexPath)?.Value;

        return index.IsNullWhiteSpace() ? default : client.Indices.Delete(index);
    }
}
