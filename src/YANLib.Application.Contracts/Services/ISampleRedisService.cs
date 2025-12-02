using YANLib.RedisServices;
using YANLib.Requests.CreateOrUpdateRequest;
using YANLib.Responses;

namespace YANLib.Services;

public interface ISampleRedisService : IBaseRedisService<SampleCreateOrUpdateRequest, SampleResponse>
{
}
