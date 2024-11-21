using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;

namespace YANLib.Services.v1;

public interface IDeveloperCertificateService : ICrudAppService<DeveloperCertificateResponse, Guid, PagedAndSortedResultRequestDto, DeveloperCertificateCreateRequest, DeveloperCertificateUpdateRequest> { }
