using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface IDeveloperTypeRepository : ITransientDependency
{
    public ValueTask<IEnumerable<DeveloperType>> GetAll();
    public ValueTask<DeveloperType> Insert(DeveloperType entity);
    public ValueTask<DeveloperType> Update(DeveloperType entity);
}
