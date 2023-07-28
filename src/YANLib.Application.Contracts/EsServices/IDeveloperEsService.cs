using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.EsIndexs;

namespace YANLib.EsServices;

public interface IDeveloperEsService
{
    public ValueTask<DeveloperIndex> Get(string id);
    public ValueTask<bool> Set(DeveloperIndex data);
    public ValueTask<bool> SetBulk(List<DeveloperIndex> datas);
    public ValueTask<bool> DeleteAll();
    public ValueTask<IReadOnlyCollection<DeveloperIndex>> GetByDeveloperId(Guid developerId);
    public ValueTask<IReadOnlyCollection<DeveloperIndex>> GetByPhone(string phone);
}
