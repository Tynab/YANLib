using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface IDeveloperCertificateRepository : IRepository<DeveloperCertificate, Guid>, ITransientDependency
{
    public ValueTask<DeveloperCertificate?> Modify(DeveloperCertificateDto dto);
}
