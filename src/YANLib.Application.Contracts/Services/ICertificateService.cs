using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.Certificate;
using YANLib.Responses;

namespace YANLib.Services;

public interface ICertificateService : ICrudAppService<CertificateResponse, Guid, PagedAndSortedResultRequestDto, CertificateCreateRequest, CertificateUpdateRequest>
{
}
