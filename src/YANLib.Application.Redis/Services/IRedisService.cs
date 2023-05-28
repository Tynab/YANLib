using Volo.Abp.Application.Services;

namespace YANLib.Application.Redis.Services;

public interface IRedisService<T> : IApplicationService
{
    public ValueTask<T?> Get(string group, string key);
    public ValueTask<IDictionary<string, T?>?> GetBulk(string group, params string[] keys);
    public ValueTask<IDictionary<string, T?>?> GetAll(string group);
    public ValueTask<bool> Set(string group, string key, T value);
    public ValueTask<bool> SetBulk(string group, IDictionary<string, T> fields);
    public ValueTask<bool> Delete(string group, string key);
    public ValueTask<bool> DeleteBulk(string group, params string[] keys);
    public ValueTask<bool> DeleteAll(string group);
    public ValueTask<IDictionary<string, IDictionary<string, T?>?>?> GetGroup(string groupPreffix);
    public ValueTask<bool> DeleteGroup(string groupPreffix);
}
