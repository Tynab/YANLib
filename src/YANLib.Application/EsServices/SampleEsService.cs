using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YANLib.EsIndexs;
using YANLib.Utilities;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts;

namespace YANLib.EsServices;

public class SampleEsService : YANLibAppService, ISampleEsService
{
    private readonly ILogger<SampleEsService> _logger;
    private readonly IElasticClient _elasticClient;
    private readonly IConfiguration _configuration;

    public SampleEsService(ILogger<SampleEsService> logger, IElasticClient elasticClient, IConfiguration configuration)
    {
        _logger = logger;
        _elasticClient = elasticClient;
        _configuration = configuration;
    }

    public async ValueTask<DeveloperIndex> Get(string id)
    {
        try
        {
            return (await _elasticClient.GetAsync<DeveloperIndex>(id)).Source ?? default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetSampleEsService-Exception: {Id}", id);
            throw;
        }
    }

    public async ValueTask<bool> Set(DeveloperIndex data)
    {
        data.Id = data.IdCard;

        try
        {
            var res = await _elasticClient.IndexDocumentAsync(data);

            if (!res.IsValid)
            {
                _logger.LogError("SetSampleEsService-Failed: {Id} - {ServerError}", res.Id, res.ServerError.CamelSerialize());

                return default;
            }

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetSampleEsService-Exception: {Data}", data.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<bool> SetBulk(List<DeveloperIndex> datas)
    {
        try
        {
            var index = _configuration.GetSection(IdxSample)?.Value;

            if (index.IsWhiteSpaceOrNull())
            {
                return false;
            }

            var reqs = new BulkDescriptor();

            foreach (var data in datas.OrderBy(x => x.CreatedDate))
            {
                data.Id = data.IdCard;
                reqs.Index<DeveloperIndex>(x => x.Document(data).Index(index));
            }

            var res = await _elasticClient.BulkAsync(reqs);

            if (!res.IsValid)
            {
                _logger.LogError("SetBulkSampleEsService-Failed: {ServerError}", res.ServerError.CamelSerialize());

                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetBulkSampleEsService-Exception: {Datas}", datas.CamelSerialize());
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
            _logger.LogError(ex, "DeleteAllSampleEsService-Exception");
            throw;
        }
    }
}
