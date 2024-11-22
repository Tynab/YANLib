using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.EsIndices;

namespace YANLib.EsServices;

public interface ICertificateEsService : IEsService<CertificateEsIndex>
{
    public ValueTask<bool> SetBulk(List<CertificateEsIndex> datas);

    public ValueTask<bool> DeleteAll();
}
