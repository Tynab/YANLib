using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using NUglify.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Core;
using YANLib.EsIndices;
using YANLib.Responses;
using YANLib.Utilities;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.ElasticsearchIndex;

namespace YANLib.EsServices;

public class CertificateEsService(ILogger<CertificateEsService> logger, IElasticClient elasticClient, IConfiguration configuration) : YANLibAppService, ICertificateEsService
{
    private readonly ILogger<CertificateEsService> _logger = logger;
    private readonly IElasticClient _elasticClient = elasticClient;
    private readonly IConfiguration _configuration = configuration;

    private readonly Dictionary<string, Expression<Func<CertificateEsIndex, object?>>> _fieldSelectors = new()
    {
        { nameof(CertificateResponse.Id), x => x.CertificateId.Suffix("keyword") },
        { nameof(CertificateResponse.Code), x => x.Id.Suffix("keyword") },
        { nameof(CertificateResponse.Name), x => x.Name.Suffix("keyword") },
        { nameof(CertificateResponse.GPA), x => x.GPA },
        { nameof(CertificateResponse.DeveloperId), x => x.DeveloperId.Suffix("keyword") },
        { nameof(CertificateResponse.CreatedBy), x => x.CreatedBy.Suffix("keyword") },
        { nameof(CertificateResponse.CreatedAt), x => x.CreatedAt },
        { nameof(CertificateResponse.UpdatedBy), x => x.UpdatedBy.Suffix("keyword") },
        { nameof(CertificateResponse.UpdatedAt), x => x.UpdatedAt },
        { nameof(CertificateResponse.IsActive), x => x.IsActive }
    };

    public async ValueTask<PagedResultDto<CertificateEsIndex>> GetAll(PagedAndSortedResultRequestDto input)
    {
        try
        {
            var res = await _elasticClient.SearchAsync<CertificateEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => d
                    .Field(f =>
                    {
                        input.Sorting?.Split(',').Reverse().ForEach(x =>
                        {
                            var sortParams = x.Trim().Split(' ');

                            if (sortParams.Length > 0 && sortParams[0].IsNotWhiteSpaceAndNull() && _fieldSelectors.TryGetValue(sortParams[0], out var fieldSelector))
                            {
                                _ = f.Field(fieldSelector).MissingLast();
                            }

                            _ = sortParams.Length > 1 && sortParams[1].EqualsIgnoreCase("DESC") ? f.Descending() : f.Ascending();
                        });

                        return f;
                    }))
                .Query(q => q.MatchAll())
            );

            return new PagedResultDto<CertificateEsIndex>(res.Total, [.. res.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAll-CertificateEsService-Exception with paging");

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
                    .Wildcard(w => w
                        .Field(c => c.Name)
                        .Value($"*{searchText}*"))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchByName-CertificateEsService-Exception: {SearchText}", searchText);

            throw;
        }
    }
}
