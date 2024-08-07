using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;

namespace YANLib.Services;

public interface IDeveloperCertificateService : IApplicationService
{
    public ValueTask<IEnumerable<DeveloperCertificateResponse>?> GetAll();

    public ValueTask<DeveloperCertificateResponse?> Get(string idCard, long code);

    public ValueTask<DeveloperCertificateResponse?> Insert(DeveloperCertificateInsertRequest request);

    public ValueTask<DeveloperCertificateResponse?> Modify(string idCard, long code, DeveloperCertificateModifyRequest request);

    public ValueTask<DeveloperCertificateResponse?> Delete(string idCard, long code, Guid updatedBy);

    public ValueTask<bool> SyncDbToRedis();
}
