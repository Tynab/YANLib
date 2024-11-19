using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Entities;
using YANLib.Repositories;
using YANLib.Responses;

namespace YANLib.Services.v1;

public class DeveloperCertificateService(IDeveloperCertificateRepository repository) : CrudAppService<DeveloperCertificate, DeveloperCertificateResponse, Guid, PagedAndSortedResultRequestDto, Requests.v1.Create.DeveloperCertificateCreateRequest, Requests.v1.Update.DeveloperCertificateUpdateRequest>(repository), IDeveloperCertificateService { }
