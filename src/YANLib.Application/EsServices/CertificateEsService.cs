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
using static System.StringComparison;
using static Nest.SortOrder;

namespace YANLib.EsServices;

public class CertificateEsService(ILogger<CertificateEsService> logger, IElasticClient elasticClient, IConfiguration configuration) : YANLibAppService, ICertificateEsService
{
    private readonly ILogger<CertificateEsService> _logger = logger;
    private readonly IElasticClient _elasticClient = elasticClient;
    private readonly IConfiguration _configuration = configuration;

    public async ValueTask<PagedResultDto<CertificateEsIndex>> GetAll(PagedAndSortedResultRequestDto input)
    {
        try
        {
            var res = await _elasticClient.SearchAsync<CertificateEsIndex>(x => x.From(input.SkipCount)
                                                                                 .Size(input.MaxResultCount)
                                                                                 .Sort(y =>
                                                                                 {
                                                                                     //input.Sorting?.Split(',').ForEach(z =>
                                                                                     //{
                                                                                     //    var sortParams = z.Trim().Split(' ');

                                                                                     //    _ = y.Field(sortParams[0], sortParams.Length > 1 && sortParams[1].Equals("DESC", OrdinalIgnoreCase) ? Descending : Ascending);
                                                                                     //});

                                                                                     //return y;

                                                                                     input.Sorting?.Split(',').ForEach(z =>
                                                                                     {
                                                                                         var sortParams = z.Trim().Split(' ');

                                                                                         if (sortParams.Length > 0 && !string.IsNullOrEmpty(sortParams[0]))
                                                                                         {
                                                                                             _ = y.Field(sortParams[0], sortParams.Length > 1 && sortParams[1].Equals("DESC", OrdinalIgnoreCase) ? Descending : Ascending);
                                                                                         }
                                                                                     });

                                                                                     return y;
                                                                                 })
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
