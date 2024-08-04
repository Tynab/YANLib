﻿using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.EsIndices;

namespace YANLib.EsServices;

public interface ICertificateEsService
{
    public ValueTask<CertificateEsIndex> Get(string id);

    public ValueTask<bool> Set(CertificateEsIndex data);

    public ValueTask<bool> SetBulk(List<CertificateEsIndex> datas);

    public ValueTask<bool> DeleteAll();

    public ValueTask<IReadOnlyCollection<CertificateEsIndex>> GetByName(string name);

    public ValueTask<IReadOnlyCollection<CertificateEsIndex>> SearchByName(string searchText);
}
