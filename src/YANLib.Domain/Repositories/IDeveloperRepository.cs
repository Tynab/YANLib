using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface IDeveloperRepository : ITransientDependency
{
    public ValueTask<IEnumerable<Developer>> GetAll();

    public ValueTask<Developer> Create(Developer entity);

    public ValueTask<Developer> Adjust(Developer entity);
}
