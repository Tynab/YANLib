using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using YANLib.Entities;

namespace YANLib.Repositories;

public interface IDeveloperRepository : IRepository<Developer, string>
{
    public ValueTask<Developer> Adjust(Developer entity);
}
