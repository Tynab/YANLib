using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib;
using YANLib.Requests;
using YANLib.Responses;

namespace YANLib.Services;

public interface ISampleService : IApplicationService
{
    public Task Send(SampleRequest request, CancellationToken cancellationToken = default);

    public Task Schedule(SampleRequest request, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<SampleResponse>> GetList(BaseListQuery listQuery, CancellationToken cancellationToken = default);

    public Task<SampleResponse?> Get(BaseListQuery listQuery, CancellationToken cancellationToken = default);
}
