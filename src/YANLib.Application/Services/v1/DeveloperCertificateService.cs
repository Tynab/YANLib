using System;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Entities;
using YANLib.Repositories;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Responses;

namespace YANLib.Services.v1;

[RemoteService(false)]
public class DeveloperCertificateService(IDeveloperCertificateRepository repository) : CrudAppService<DeveloperCertificate, DeveloperCertificateResponse, Guid, PagedAndSortedResultRequestDto, DeveloperCertificateCreateRequest, DeveloperCertificateUpdateRequest>(repository), IDeveloperCertificateService { }
