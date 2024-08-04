using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Responses;

namespace YANLib.CrudService;

public interface ICertificateCrudService : ICrudAppService<CertificateResponse, Guid, PagedAndSortedResultRequestDto, CertificateCreateRequest, CertificateUpdateRequest> { }
