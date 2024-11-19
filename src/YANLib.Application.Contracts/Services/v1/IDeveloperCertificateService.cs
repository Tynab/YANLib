using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Responses;

namespace YANLib.Services.v1;

public interface IDeveloperCertificateService : ICrudAppService<DeveloperCertificateResponse, Guid, PagedAndSortedResultRequestDto, Requests.v1.Create.DeveloperCertificateCreateRequest, Requests.v1.Update.DeveloperCertificateUpdateRequest> { }
