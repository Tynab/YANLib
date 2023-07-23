﻿using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Linq;
using YANLib.EsIndexs;
using static Elasticsearch.Net.CertificateValidations;
using static System.TimeSpan;
using static YANLib.YANLibConsts;

namespace YANLib.Utilities;

public static class ElasticsearchUtil
{
    #region Fields
    private static string _indexSample;
    #endregion

    #region Extensions
    public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        var urlTag = "Elasticsearch:Url";
        var usernameTag = "Elasticsearch:Username";
        var pwdTag = "Elasticsearch:Password";
        var settings = new ConnectionSettings(configuration.GetSection(urlTag).GetChildren().Any()
            ? new StaticConnectionPool((configuration.GetSection(urlTag).GetChildren().Any()
            ? configuration.GetSection(urlTag).GetChildren().ToArray()
            : (new IConfigurationSection[] { configuration.GetSection(urlTag) })).Select(s => new Uri(s.Value)).ToArray())
            : new SingleNodeConnectionPool(new Uri(configuration.GetSection(urlTag).Value))).DefaultIndex(configuration.GetSection(IdxSample)?.Value).EnableDebugMode().PrettyJson().RequestTimeout(FromMinutes(2));

        if (configuration.GetSection(usernameTag).Value.IsWhiteSpaceOrNull())
        {
            settings.ServerCertificateValidationCallback((o, certificate, chain, errors) => true);
            settings.ServerCertificateValidationCallback(AllowAll);
            settings.BasicAuthentication(configuration.GetSection(usernameTag).Value, configuration.GetSection(pwdTag).Value);
        }

        _indexSample = configuration.GetSection(IdxSample)?.Value;
        _ = settings.DefaultMappingFor<DeveloperIndex>(m => m.IndexName(_indexSample));

        var client = new ElasticClient(settings);

        if (!client.Indices.Exists(configuration.GetSection(IdxSample)?.Value).Exists)
        {
            _ = client.Indices.Create(configuration.GetSection(IdxSample).Value, c => c
            .Map<DeveloperIndex>(t => t
            .AutoMap().Properties(p => p
            .Text(d => d
            .Name(x => x.Id)))));
        }

        _ = services.AddSingleton<IElasticClient>(client);
    }

    public static DeleteIndexResponse DeleteSampleIndex(this IElasticClient client) => _indexSample.IsNotWhiteSpaceAndNull() ? client.Indices.Delete(_indexSample) : default;
    #endregion
}