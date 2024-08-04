using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.EsIndices;

namespace YANLib.EsServices;

public interface IDeveloperEsService
{
    public ValueTask<DeveloperEsIndex> Get(string id);

    public ValueTask<bool> Set(DeveloperEsIndex data);

    public ValueTask<bool> SetBulk(List<DeveloperEsIndex> datas);

    public ValueTask<bool> Delete(string id);

    public ValueTask<bool> DeleteAll();

    public ValueTask<IReadOnlyCollection<DeveloperEsIndex>> GetByName(string name);

    public ValueTask<IReadOnlyCollection<DeveloperEsIndex>> GetByPhone(string phone);

    public ValueTask<IReadOnlyCollection<DeveloperEsIndex>> SearchByName(string searchText);

    public ValueTask<IReadOnlyCollection<DeveloperEsIndex>> SearchByPhone(string searchText);
}
