using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using YANLib.EsIndices;

namespace YANLib.Services.Implements;

public class DeveloperEsService(ILogger<ElasticsearchService<DeveloperEsIndex, string>> logger, IConfiguration configuration, IElasticClient elasticClient)
    : ElasticsearchService<DeveloperEsIndex, string>(logger, configuration, elasticClient), IDeveloperEsService
{
    private readonly ILogger<ElasticsearchService<DeveloperEsIndex, string>> _logger = logger;
    private readonly IElasticClient _elasticClient = elasticClient;

    public async Task<IReadOnlyCollection<DeveloperEsIndex?>> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return (await _elasticClient.SearchAsync<DeveloperEsIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(m => m
                            .Match(t => t
                                .Field(f => f.Id)
                                .Query(id.ToString())
                            )
                        )
                    )
                ), cancellationToken
            )).Documents;
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Id}", nameof(GetById), id);

            throw new OperationCanceledException($"Elasticsearch GetById operation canceled", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetById-DeveloperEsService-Exception: {Id}", id);

            throw;
        }
    }
}
