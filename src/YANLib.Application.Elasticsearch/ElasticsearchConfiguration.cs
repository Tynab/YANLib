using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

            //
            if (!Uri.TryCreate(esUrl, UriKind.Absolute, out var uri))
            {
                Console.WriteLine($"Invalid Elasticsearch URL: {esUrl}. Elasticsearch will not be configured.");

                return;
            }
            //

            settings = new ConnectionSettings(new SingleNodeConnectionPool(new Uri(esUrl))).DefaultIndex(configuration.GetSection(Developer)?.Value).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(2));
        }
        else
        {
            //
            var uriList = new List<Uri>();
            var urlSections = configuration.GetSection(urlTag).GetChildren().Any() ? configuration.GetSection(urlTag).GetChildren().ToArray() : [configuration.GetSection(urlTag)];

            foreach (var section in urlSections)
            {
                var url = section.Value;

                if (!string.IsNullOrWhiteSpace(url) && Uri.TryCreate(url, UriKind.Absolute, out var uri))
                {
                    uriList.Add(uri);
                }
            }

            if (uriList.Count == 0)
            {
                // No valid URLs found
                return;
            }
            //

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

        //
        try
        {
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
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating Elasticsearch indices: {ex.Message}. Application will continue without Elasticsearch.");
        }
        //
    }

    public static async Task<DeleteIndexResponse?> DeleteIndexAsync(this IElasticClient client, IConfiguration configuration, string indexPath, CancellationToken cancellationToken = default)
    {
        var index = configuration.GetSection(indexPath)?.Value;

        return index.IsNullWhiteSpace() ? default : await client.Indices.DeleteAsync(index, ct: cancellationToken);
    }
}
