using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using YANLib.ElasticsearchIndices;

namespace YANLib.Services.Implements;

public class DeveloperElasticsearchService(ILogger<ElasticsearchService<DeveloperElasticsearchIndex>> logger, IConfiguration configuration, IElasticClient elasticClient)
    : ElasticsearchService<DeveloperElasticsearchIndex>(logger, configuration, elasticClient), IDeveloperElasticsearchService
{
    private readonly ILogger<ElasticsearchService<DeveloperElasticsearchIndex>> _logger = logger;
    private readonly IElasticClient _elasticClient = elasticClient;

    public async Task<IReadOnlyCollection<DeveloperElasticsearchIndex?>> GetByIdCardAsync(string idCard, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return (await _elasticClient.SearchAsync<DeveloperElasticsearchIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(m => m
                            .Match(t => t
                                .Field(f => f.IdCard)
                                .Query(idCard)
                            )
                        )
                    )
                ), cancellationToken
            )).Documents;
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method}", nameof(GetByIdCardAsync));

            throw new OperationCanceledException($"Elasticsearch GetByIdCardAsync operation canceled", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByIdCardAsync-DeveloperElasticsearchService-Exception: {IdCard}", idCard);

            throw;
        }
    }
}
