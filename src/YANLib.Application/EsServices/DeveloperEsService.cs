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

public class DeveloperEsService : YANLibAppService, IDeveloperEsService
{
    #region Fields
    private readonly ILogger<DeveloperEsService> _logger;
    private readonly IElasticClient _elasticClient;
    private readonly IConfiguration _configuration;
    #endregion

    #region Constructors
    public DeveloperEsService(ILogger<DeveloperEsService> logger, IElasticClient elasticClient, IConfiguration configuration)
    {
        _logger = logger;
        _elasticClient = elasticClient;
        _configuration = configuration;
    }
    #endregion

    #region Implements
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
            _logger.LogError(ex, "SetDeveloperEsService-Exception: {Data}", data.CamelSerialize());
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

            return await _elasticClient.BulkAsync(reqs) is not null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetBulkDeveloperEsService-Exception: {Datas}", datas.CamelSerialize());
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
    #endregion
}
