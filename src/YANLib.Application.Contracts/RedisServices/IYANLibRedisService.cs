using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace YANLib.RedisServices;

public interface IYANLibRedisService<TCreateRequest, TUpdateRequest, TResponse, TKey> : IApplicationService
    where TCreateRequest : YANLibApplicationCreateRequest
    where TUpdateRequest : YANLibApplicationUpdateRequest
    where TResponse : YANLibApplicationResponse<TKey>
    where TKey : notnull, IEquatable<TKey>
{
    public Task<List<TResponse?>?> GetAllAsync(CancellationToken cancellationToken = default);

    public Task<TResponse?> GetOrAddAsync(TKey id, CancellationToken cancellationToken = default);

    public Task<TResponse?> AddAsync(TCreateRequest request, CancellationToken cancellationToken = default);

    public Task<TResponse?> ModifyAsync(TKey code, TUpdateRequest request, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(TKey code, Guid updatedBy, CancellationToken cancellationToken = default);

    public Task<bool> SyncDataToRedisAsync(CancellationToken cancellationToken = default);
}
