using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface ICertificateRepository : ITransientDependency
{
    public ValueTask<IEnumerable<Certificate>> GetByDeveloperId(string developerId);

    public ValueTask<Certificate> Create(Certificate entity);

    public ValueTask<Certificate> Update(Certificate entity);
}
