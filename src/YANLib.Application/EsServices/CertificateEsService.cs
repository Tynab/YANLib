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
            _ = _elasticClient.DeleteCertificateIndex();

            return await FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAll-CertificateEsService-Exception");

            throw;
        }
    }
}
