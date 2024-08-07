using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Entities;
using YANLib.Repositories;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Responses;

namespace YANLib.CrudServices;

public class DeveloperCertificateCrudService(IDeveloperCertificateRepository repository) : CrudAppService<DeveloperCertificate, DeveloperCertificateResponse, Guid, PagedAndSortedResultRequestDto, DeveloperCertificateCreateRequest, DeveloperCertificateUpdateRequest>(repository), IDeveloperCertificateCrudService { }
