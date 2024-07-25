using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.EsIndices;
using YANLib.Utilities;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.ElasticsearchIndex;

namespace YANLib.EsServices;

public class DeveloperEsService(ILogger<DeveloperEsService> logger,
    IElasticClient elasticClient,
    IConfiguration configuration
) : YANLibAppService, IDeveloperEsService
{
    private readonly ILogger<DeveloperEsService> _logger = logger;
    private readonly IElasticClient _elasticClient = elasticClient;
    private readonly IConfiguration _configuration = configuration;

    public async ValueTask<DeveloperIndex> Get(string id)
    {
        try
        {
            return (await _elasticClient.GetAsync<DeveloperIndex>(id)).Source ?? default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetDeveloperEsService-Exception: {Id}", id);

            throw;
        }
    }

    public async ValueTask<bool> Set(DeveloperIndex data)
    {
        data.Id = data.IdCard;

        try
        {
            return await _elasticClient.IndexDocumentAsync(data) is not null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetDeveloperEsService-Exception: {Data}", data.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> SetBulk(List<DeveloperIndex> datas)
    {
        try
        {
            var index = _configuration.GetSection(Sample)?.Value;

            if (index.IsWhiteSpaceOrNull())
            {
                return false;
            }

            var reqs = new BulkDescriptor();

            foreach (var data in datas.OrderBy(x => x.CreatedAt))
            {
                data.Id = data.IdCard;
                _ = reqs.Index<DeveloperIndex>(x => x.Document(data).Index(index));
            }

            return await _elasticClient.BulkAsync(reqs) is not null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetBulkDeveloperEsService-Exception: {Datas}", datas.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> DeleteAll()
    {
        try
        {
            _ = _elasticClient.DeleteSampleIndex();

            return await FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAllDeveloperEsService-Exception");

            throw;
        }
    }

    public async ValueTask<IReadOnlyCollection<DeveloperIndex>> GetByDeveloperId(string developerId) => (await _elasticClient.SearchAsync<DeveloperIndex>(s => s
        .Query(q => q
            .Bool(b => b
                .Must(d => d
                    .Match(m => m
                        .Field(c => c.DeveloperId)
                        .Query(developerId.ToString()))))))).Documents;

    public async ValueTask<IReadOnlyCollection<DeveloperIndex>> GetByPhone(string phone) => (await _elasticClient.SearchAsync<DeveloperIndex>(s => s
        .Query(q => q
            .Bool(b => b
                .Must(d => d
                    .Match(m => m
                        .Field(c => c.Phone)
                        .Query(phone))))))).Documents;

    public async ValueTask<IReadOnlyCollection<DeveloperIndex>> SearchByPhone(string searchText) => (await _elasticClient.SearchAsync<DeveloperIndex>(s => s
        .Query(q => q
            .Bool(b => b
                .Must(d => d
                    .MatchPhrasePrefix(m => m
                        .Field(c => c.Phone)
                        .Query(searchText))))))).Documents;
}
