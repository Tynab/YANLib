using YANLib.RedisServices;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface IDeveloperTypeService : IYANLibRedisService<DeveloperTypeCreateRequest, DeveloperTypeUpdateRequest, DeveloperTypeResponse, long>
{
}
