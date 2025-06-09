using Microsoft.Extensions.Logging;
using YANLib.Attributes;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.RedisServices;
using YANLib.Repositories;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using static YANLib.Attributes.RedisGroupAttributeHelper;
using static YANLib.YANLibConsts.RedisConstant;

namespace YANLib.Services.v2;

[RedisGroup(DeveloperTypeGroup)]
public class DeveloperTypeService(
    ILogger<DeveloperTypeService> logger,
    IDeveloperTypeRepository repository,
    IRedisService<DeveloperTypeRedisDto> redisService
) : YANLibRedisService<DeveloperTypeCreateRequest, DeveloperTypeUpdateRequest, DeveloperTypeDto, DeveloperTypeRedisDto, DeveloperTypeResponse, DeveloperType, long>(
    logger, repository, redisService, GetRedisGroup<DeveloperTypeService>()
), IDeveloperTypeService
{
}
