using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.EsIndices;

namespace YANLib.EsServices;

public interface ICertificateEsService
{
    public ValueTask<CertificateEsIndex?> Get(string id);

    public ValueTask<bool> Set(CertificateEsIndex data);

    public ValueTask<bool> SetBulk(List<CertificateEsIndex> datas);

    public ValueTask<bool> Delete(string id);

    public ValueTask<bool> DeleteAll();
}
