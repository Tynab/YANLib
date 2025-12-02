using Microsoft.Extensions.Logging;
using Volo.Abp.Security.Claims;
using YANLib;
using YANLib.Attributes;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.RedisServices;
using YANLib.Requests.CreateOrUpdateRequest;
using YANLib.Responses;
using static YANLib.Attributes.RedisGroupAttributeHelper;
using static YANLib.BaseConsts.RedisConstant;

namespace YANLib.Services;

[RedisGroup(SAMPLE_GROUP)]
public class SampleRedisService(
    ILogger<SampleRedisService> logger,
    IBaseRepository<Sample> repository,
    IRedisService<SampleRedisDto> redisService,
    ICurrentPrincipalAccessor currentPrincipalAccessor
) : BaseRedisService<SampleCreateOrUpdateRequest, SampleRedisDto, SampleResponse, Sample>(
    logger, repository, redisService, GetRedisGroup<SampleRedisService>(), currentPrincipalAccessor
), ISampleRedisService
{
}
