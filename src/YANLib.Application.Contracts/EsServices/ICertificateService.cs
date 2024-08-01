using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.EsIndices;

namespace YANLib.EsServices;

public interface ICertificateService
{
    public ValueTask<CertificateIndex> Get(string id);

    public ValueTask<bool> Set(CertificateIndex data);

    public ValueTask<bool> SetBulk(List<CertificateIndex> datas);

    public ValueTask<bool> DeleteAll();

    public ValueTask<IReadOnlyCollection<CertificateIndex>> GetByName(string name);

    public ValueTask<IReadOnlyCollection<CertificateIndex>> SearchByName(string searchText);
}
