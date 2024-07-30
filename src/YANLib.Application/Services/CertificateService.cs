using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using YANLib.Entities;
using YANLib.Requests.Certificate;
using YANLib.Responses;

namespace YANLib.Services;

public class CertificateService(IRepository<Certificate, Guid> repository)
    : CrudAppService<Certificate, CertificateResponse, Guid, PagedAndSortedResultRequestDto, CertificateCreateRequest, CertificateUpdateRequest>(repository), ICertificateService
{
}
