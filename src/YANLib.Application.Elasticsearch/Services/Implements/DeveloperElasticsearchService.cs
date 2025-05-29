using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.ElasticsearchIndices;
using YANLib.Responses;

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
                                .Field(f => f.DeveloperIdCard)
                                .Query(idCard)
                            )
                        )
                    )
                ), cancellationToken
            )).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByIdCardAsync-DeveloperElasticsearchService-Exception: {IdCard}", idCard);

            throw;
        }
    }
}
