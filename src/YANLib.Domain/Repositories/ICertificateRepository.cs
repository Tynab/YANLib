using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using YANLib.Models;

namespace YANLib.Repositories;

public interface ICertificateRepository : ITransientDependency
{
    public ValueTask<Certificate> Get(Guid id);
    public ValueTask<Certificate> Insert(Certificate entity);
    public ValueTask<Certificate> Update(Certificate entity);
    public ValueTask<IEnumerable<Certificate>> GetByDeveloperId(Guid developerId);
}
