using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using NUglify.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp;
using YANLib.Core;
using YANLib.EsIndices;
using YANLib.Utilities;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.ElasticsearchIndex;

namespace YANLib.EsServices;

public class CertificateEsService(ILogger<CertificateEsService> logger, IElasticClient elasticClient, IConfiguration configuration) : YANLibAppService, ICertificateEsService
{
    private readonly ILogger<CertificateEsService> _logger = logger;
    private readonly IElasticClient _elasticClient = elasticClient;
    private readonly IConfiguration _configuration = configuration;

    public async ValueTask<ISearchResponse<CertificateEsIndex>> GetAll(PagedAndSortedResultRequestDto dto)
    {
        try
        {
            var res = await _elasticClient.SearchAsync<CertificateEsIndex>(new SearchRequest<CertificateEsIndex>(Certificate)
            {
                From = dto.SkipCount,
                Size = dto.MaxResultCount,
                Sort = dto.Sorting.IsWhiteSpaceOrNull() ? default : new List<ISort>
                {
                    new FieldSort
                    {
                        Field = dto.Sorting, Order = SortOrder.Ascending
                    }
                }
            });

            if (!res.IsValid)
            {
                _logger.LogError("GetAll-CertificateEsService-SearchError: {Error}", res.ServerError.Error.Reason);

                throw new BusinessException("Error retrieving data from Elasticsearch");
            }

            return res;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAll-CertificateEsService-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }

    public async ValueTask<CertificateEsIndex?> Get(string id)
    {
        try
        {
            return (await _elasticClient.GetAsync<CertificateEsIndex>(id)).Source ?? default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get-CertificateEsService-Exception: {Id}", id);

            throw;
        }
    }

    public async ValueTask<bool> Set(CertificateEsIndex data)
    {
        try
        {
            return (await _elasticClient.IndexDocumentAsync(data)).IsNotNull();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Set-CertificateEsService-Exception: {Data}", data.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> SetBulk(List<CertificateEsIndex> datas)
    {
        try
        {
            var index = _configuration.GetSection(Certificate)?.Value;

            if (index.IsWhiteSpaceOrNull())
            {
                return false;
            }

            var reqs = new BulkDescriptor();

            datas.OrderBy(x => x.CreatedAt).ForEach(data => reqs.Index<CertificateEsIndex>(x => x.Document(data).Index(index)));

            return (await _elasticClient.BulkAsync(reqs)).IsNotNull();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetBulk-CertificateEsService-Exception: {Datas}", datas.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> Delete(string id)
    {
        try
        {
            return (await _elasticClient.DeleteAsync<CertificateEsIndex>(id)).IsNotNull();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-CertificateEsService-Exception: {Id}", id);

            throw;
        }
    }

    public async ValueTask<bool> DeleteAll()
    {
        try
        {
            return await FromResult(_elasticClient.DeleteCertificateIndex().IsNotNull());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAll-CertificateEsService-Exception");

            throw;
        }
    }

    public async ValueTask<IReadOnlyCollection<CertificateEsIndex>> GetByName(string name)
    {
        try
        {
            return (await _elasticClient.SearchAsync<CertificateEsIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(d => d
                            .Match(m => m
                                .Field(c => c.Name)
                                .Query(name))))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByName-CertificateEsService-Exception: {Name}", name);

            throw;
        }
    }

    public async ValueTask<IReadOnlyCollection<CertificateEsIndex>> SearchByName(string searchText)
    {
        try
        {
            return (await _elasticClient.SearchAsync<CertificateEsIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(d => d
                            .MatchPhrasePrefix(m => m
                                .Field(c => c.Name)
                                .Query(searchText))))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchByName-CertificateEsService-Exception: {SearchText}", searchText);

            throw;
        }
    }
}
