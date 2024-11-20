using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using YANLib.Dtos;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface ICertificateRepository : IRepository<Certificate, string>, ITransientDependency
{
    public ValueTask<Certificate?> Modify(CertificateDto dto);
}
