using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using YANLib.Models;

namespace YANLib.Repositories;

public interface IDeveloperRepository : ITransientDependency
{
    public ValueTask<IEnumerable<Developer>> GetAll();
    public ValueTask<Developer> Insert(Developer entity);
    public ValueTask<Developer> Update(Developer entity);
}
