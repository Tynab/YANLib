using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using NUglify.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.EsIndices;
using YANLib.Utilities;
using static System.Threading.Tasks.Task;
using static YANLib.Constants.YANLibConsts.ElasticsearchIndex;

namespace YANLib.EsServices;

public class DeveloperService(ILogger<DeveloperService> logger, IElasticClient elasticClient, IConfiguration configuration) : YANLibAppService, IDeveloperService
{
    private readonly ILogger<DeveloperService> _logger = logger;
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
        try
        {
            return (await _elasticClient.IndexDocumentAsync(data)).IsNotNull();
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
            var index = _configuration.GetSection(Developer)?.Value;

            if (index.IsWhiteSpaceOrNull())
            {
                return false;
            }

            var reqs = new BulkDescriptor();

            datas.OrderBy(x => x.CreatedAt).ForEach(data => reqs.Index<DeveloperIndex>(x => x.Document(data).Index(index)));

            return (await _elasticClient.BulkAsync(reqs)).IsNotNull();
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
            _ = _elasticClient.DeleteDeveloperIndex();

            return await FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAllDeveloperEsService-Exception");

            throw;
        }
    }
    public async ValueTask<IReadOnlyCollection<DeveloperIndex>> GetByName(string name)
    {
        try
        {
            return (await _elasticClient.SearchAsync<DeveloperIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(d => d
                            .Match(m => m
                                .Field(c => c.Name)
                                .Query(name))))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByNameDeveloperEsService-Exception: {Name}", name);

            throw;
        }
    }

    public async ValueTask<IReadOnlyCollection<DeveloperIndex>> GetByPhone(string phone)
    {
        try
        {
            return (await _elasticClient.SearchAsync<DeveloperIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(d => d
                            .Match(m => m
                                .Field(c => c.Phone)
                                .Query(phone))))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByPhoneDeveloperEsService-Exception: {Phone}", phone);

            throw;
        }
    }

    public async ValueTask<IReadOnlyCollection<DeveloperIndex>> SearchByName(string searchText)
    {
        try
        {
            return (await _elasticClient.SearchAsync<DeveloperIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(d => d
                            .MatchPhrasePrefix(m => m
                                .Field(c => c.Name)
                                .Query(searchText))))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchByNameDeveloperEsService-Exception: {SearchText}", searchText);

            throw;
        }
    }

    public async ValueTask<IReadOnlyCollection<DeveloperIndex>> SearchByPhone(string searchText)
    {
        try
        {
            return (await _elasticClient.SearchAsync<DeveloperIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(d => d
                            .MatchPhrasePrefix(m => m
                                .Field(c => c.Phone)
                                .Query(searchText))))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchByPhoneDeveloperEsService-Exception: {SearchText}", searchText);

            throw;
        }
    }
}
