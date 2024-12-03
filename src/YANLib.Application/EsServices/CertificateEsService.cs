using Elastic.Apm.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using NUglify.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Application.Dtos;
using YANLib.Core;
using YANLib.EsIndices;
using YANLib.Responses;
using YANLib.Services.Implements;
using YANLib.Utilities;
using static System.Threading.Tasks.Task;
using static YANLib.YANLibConsts.ElasticsearchIndex;

namespace YANLib.EsServices;

public class CertificateEsService(ILogger<EsService<CertificateEsIndex>> logger, IElasticClient elasticClient, IConfiguration configuration) : EsService<CertificateEsIndex>(logger, elasticClient, configuration), ICertificateEsService
{
    private readonly ILogger<EsService<CertificateEsIndex>> _logger = logger;

    public async ValueTask<bool> SetBulk(List<CertificateEsIndex> datas)
    {
        try
        {
            return await SetBulk(datas, Certificate);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetBulk-CertificateEsService-Exception: {Datas}", datas.Serialize());

            throw;
        }
    }

    public async ValueTask<bool> DeleteAll()
    {
        try
        {
            return await DeleteAll(Certificate);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAll-CertificateEsService-Exception");

            throw;
        }
    }
}

