using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Responses;

namespace YANLib.Services.v1;

public interface IDeveloperCertificateService : ICrudAppService<DeveloperCertificateResponse, Guid, PagedAndSortedResultRequestDto, DeveloperCertificateCreateRequest, DeveloperCertificateUpdateRequest> { }
