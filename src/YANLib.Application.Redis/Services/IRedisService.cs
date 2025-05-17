using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace YANLib.Services;

public interface IRedisService<TRedisDto> : IApplicationService where TRedisDto : YANLibApplicationRedisDto
{
    public Task<TRedisDto?> GetAsync(string group, string key, CancellationToken cancellationToken = default);

    public Task<IDictionary<string, TRedisDto?>?> GetBulkAsync(string group, IEnumerable<string> keys, CancellationToken cancellationToken = default);

    public Task<IDictionary<string, TRedisDto?>?> GetAllAsync(string group, CancellationToken cancellationToken = default);

    public Task<bool> SetAsync(string group, string key, TRedisDto value, CancellationToken cancellationToken = default);

    public Task<bool> SetBulkAsync(string group, IDictionary<string, TRedisDto> fields, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(string group, string key, CancellationToken cancellationToken = default);

    public Task<bool> DeleteBulkAsync(string group, IEnumerable<string> keys, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAllAsync(string group, CancellationToken cancellationToken = default);

    public Task<IDictionary<string, IDictionary<string, TRedisDto?>?>?> GetGroupAsync(string groupPreffix, CancellationToken cancellationToken = default);

    public Task<bool> DeleteGroupAsync(string groupPreffix, CancellationToken cancellationToken = default);
}
