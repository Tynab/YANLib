using Volo.Abp.Application.Services;
using YANLib;

namespace YANLib.RedisServices;

public interface IBaseRedisService<TCreateOrUpdateRequest, TResponse> : IApplicationService where TCreateOrUpdateRequest : BaseCreateOrUpdateRequest where TResponse : BaseResponse
{
    public Task<List<TResponse?>?> GetAllAsync(CancellationToken cancellationToken = default);

    public Task<TResponse?> GetOrAddAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<TResponse?> AddAsync(TCreateOrUpdateRequest request, CancellationToken cancellationToken = default);

    public Task<TResponse?> UpdateAsync(Guid id, TCreateOrUpdateRequest request, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<bool> SyncDataToRedisAsync(CancellationToken cancellationToken = default);
}
