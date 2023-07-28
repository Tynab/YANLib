using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using YANLib.Models;

namespace YANLib.Repositories;

public interface ICertificateRepository : ITransientDependency
{
    public ValueTask<IEnumerable<Certificate>> GetByDeveloperId(Guid developerId);
    public ValueTask<IEnumerable<Certificate>> Inserts(IEnumerable<Certificate> entities);
    public ValueTask<IEnumerable<Certificate>> Updates(IEnumerable<Certificate> entities);
}
