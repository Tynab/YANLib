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

public class CertificateEsService(ILogger<CertificateEsService> logger, IElasticClient elasticClient, IConfiguration configuration) : YANLibAppService, ICertificateEsService
{
    private readonly ILogger<CertificateEsService> _logger = logger;
    private readonly IElasticClient _elasticClient = elasticClient;
    private readonly IConfiguration _configuration = configuration;

    public async ValueTask<CertificateEsIndex?> Get(string id)
    {
        try
        {
            return (await _elasticClient.GetAsync<CertificateEsIndex>(id)).Source ?? default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetCertificateEsService-Exception: {Id}", id);

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
            _logger.LogError(ex, "SetCertificateEsService-Exception: {Data}", data.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> SetBulk(List<CertificateEsIndex> datas)
    {
        try
        {
            var index = _configuration.GetSection(Developer)?.Value;

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
            _logger.LogError(ex, "SetBulkCertificateEsService-Exception: {Datas}", datas.Serialize());

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
            _logger.LogError(ex, "DeleteCertificateEsService-Exception: {Id}", id);

            throw;
        }
    }

    public async ValueTask<bool> DeleteAll()
    {
        try
        {
            _ = _elasticClient.DeleteCertificateIndex();

            return await FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAllCertificateEsService-Exception");

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
            _logger.LogError(ex, "GetByNameCertificateEsService-Exception: {Name}", name);

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
            _logger.LogError(ex, "SearchByNameCertificateEsService-Exception: {SearchText}", searchText);

            throw;
        }
    }
}
