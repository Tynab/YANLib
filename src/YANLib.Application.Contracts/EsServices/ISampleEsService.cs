using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.EsIndexs;

namespace YANLib.EsServices;

public interface ISampleEsService
{
    public ValueTask<DeveloperIndex> Get(string id);
    public ValueTask<bool> Set(DeveloperIndex data);
    public ValueTask<bool> SetBulk(List<DeveloperIndex> datas);
    public ValueTask<bool> DeleteAll();
}
