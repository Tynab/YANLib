using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.EsIndices;

namespace YANLib.Services;

public interface ICertificateEsService : IEsService<CertificateEsIndex>
{
    public ValueTask<bool> SetBulk(List<CertificateEsIndex> datas);

    public ValueTask<bool> DeleteAll();
}
