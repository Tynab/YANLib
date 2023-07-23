using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests;
using YANLib.Responses;

namespace YANLib.Services;

public interface ICertificateService : IApplicationService
{
    public ValueTask<CertificateResponse> Get(Guid id);
    public ValueTask<CertificateResponse> Insert(CertificateRequest request);
    public ValueTask<CertificateResponse> Update(CertificateFullRequest request);
    public ValueTask<List<CertificateResponse>> GetByDeveloperId(Guid developerId);
}
