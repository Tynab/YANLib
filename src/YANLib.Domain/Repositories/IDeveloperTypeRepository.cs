using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Domains;

public interface IDeveloperTypeRepository : IRepository<DeveloperType, long>, ITransientDependency
{
    public Task<DeveloperType?> ModifyAsync(DeveloperTypeDto dto, CancellationToken cancellationToken = default);
}
