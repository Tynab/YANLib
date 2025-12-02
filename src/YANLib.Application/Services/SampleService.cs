using DotNetCore.CAP;
using EOE.CCSBE.BackgroundArgs;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Dtos;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Security.Claims;
using YANLib;
using YANLib.Etos;
using static YANLib.BaseConsts.RabbitMQTopic;
using static YANLib.Enums.SampleType;
using static System.TimeSpan;
using YANLib.Entities;
using YANLib.Responses;
using YANLib.Requests;

namespace YANLib.Services;

public class SampleService(
    ILogger<SampleService> logger,
    IBaseRepository<Sample> repository,
    ICapPublisher capPublisher,
    IBackgroundJobManager backgroundJobManager,
    ICurrentPrincipalAccessor currentPrincipalAccessor
) : BaseAccessorService(currentPrincipalAccessor), ISampleService
{
    public async Task Send(SampleRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var eto = ObjectMapper.Map<SampleRequest, SampleEto>(request);

            logger.LogInformation("Send-SampleService: {ETO}", eto.Serialize());

            await capPublisher.PublishAsync(EOE_YANLIB_SAMPLE, eto, cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Send-SampleService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async Task Schedule(SampleRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var args = new SampleArgs(request.Message);

            logger.LogInformation("Schedule-SampleService: {Args}", args.Serialize());

            _ = await backgroundJobManager.EnqueueAsync(args, delay: FromSeconds(10));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Schedule-SampleService-Exception: {Request}", request.Serialize());

            throw;
        }
    }

    public async Task<PagedResultDto<SampleResponse>> GetList(BaseListQuery listQuery, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var query = (await repository.GetQueryableAsync()).WhereIf(listQuery.Search.IsNullWhiteSpace(), x => x.Type == Retail);

            return await CreatePagedResultAsync<Sample, SampleResponse>(query, listQuery.PagedAndSortedDto(), cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetList-SampleService-Exception: {ListQuery}", listQuery.Serialize());

            throw;
        }
    }

    public async Task<SampleResponse?> Get(BaseListQuery listQuery, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var query = (await repository.GetQueryableAsync()).WhereIf(listQuery.Search.IsNullWhiteSpace(), x => x.Type == Banking);

            return ObjectMapper.Map<Sample?, SampleResponse?>(await AsyncExecuter.FirstOrDefaultAsync(query, cancellationToken));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetList-SampleService-Exception: {ListQuery}", listQuery.Serialize());

            throw;
        }
    }
}
