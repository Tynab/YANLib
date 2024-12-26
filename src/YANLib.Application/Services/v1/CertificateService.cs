using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using YANLib.Entities;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;

namespace YANLib.Services.v1;

public class CertificateService(IRepository<Certificate, string> repository) : CrudAppService<Certificate, CertificateResponse, string, PagedAndSortedResultRequestDto, CertificateCreateRequest, CertificateUpdateRequest>(repository), ICertificateService { }
