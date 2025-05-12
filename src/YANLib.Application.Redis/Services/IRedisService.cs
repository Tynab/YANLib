using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace YANLib.Services;

public interface IRedisService<TRedisDto> : IApplicationService where TRedisDto : YANLibApplicationRedisDto
{
    public Task<TRedisDto?> Get(string group, string key);

    public Task<IDictionary<string, TRedisDto?>?> GetBulk(string group, params string[] keys);

    public Task<IDictionary<string, TRedisDto?>?> GetAll(string group);

    public Task<bool> Set(string group, string key, TRedisDto value);

    public Task<bool> SetBulk(string group, IDictionary<string, TRedisDto> fields);

    public Task<bool> Delete(string group, string key);

    public Task<bool> DeleteBulk(string group, params string[] keys);

    public Task<bool> DeleteAll(string group);

    public Task<IDictionary<string, IDictionary<string, TRedisDto?>?>?> GetGroup(string groupPreffix);

    public Task<bool> DeleteGroup(string groupPreffix);
}
