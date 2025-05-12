using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface IDeveloperRepository : IRepository<Developer, Guid>, ITransientDependency
{
    public Task<Developer?> Modify(DeveloperDto dto);

    public Task<Developer?> Adjust(Developer entity);
}
