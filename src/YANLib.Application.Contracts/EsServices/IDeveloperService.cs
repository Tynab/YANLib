using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.EsIndices;

namespace YANLib.EsServices;

public interface IDeveloperService
{
    public ValueTask<DeveloperIndex> Get(string id);

    public ValueTask<bool> Set(DeveloperIndex data);

    public ValueTask<bool> SetBulk(List<DeveloperIndex> datas);

    public ValueTask<bool> DeleteAll();

    public ValueTask<IReadOnlyCollection<DeveloperIndex>> GetByName(string name);

    public ValueTask<IReadOnlyCollection<DeveloperIndex>> GetByPhone(string phone);

    public ValueTask<IReadOnlyCollection<DeveloperIndex>> SearchByName(string searchText);

    public ValueTask<IReadOnlyCollection<DeveloperIndex>> SearchByPhone(string searchText);
}
