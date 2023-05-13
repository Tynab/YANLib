using Volo.Abp.Application.Services;

namespace YANLib.Application.Redis.Services;

public interface IRedisService<T> : IApplicationService
{
    public ValueTask<IDictionary<string, T?>?> GetAll(string group);
    public ValueTask<T?> Get(string group, string key);
    public ValueTask<Dictionary<string, T?>?> GetBulk(string group, params string[] keys);
    public Task Set(string group, string key, T value);
    public Task SetBulk(string group, IDictionary<string, T> fields);
    public ValueTask<bool> DeleteAll(string group);
    public ValueTask<bool> Delete(string group, string key);
    public ValueTask<bool> DeleteBulk(string group, params string[] keys);
}
