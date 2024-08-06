﻿using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using YANLib.Entities;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Responses;

namespace YANLib.CrudService;

public class CertificateCrudService(IRepository<Certificate, Guid> repository) : CrudAppService<Certificate, CertificateResponse, Guid, PagedAndSortedResultRequestDto, CertificateCreateRequest, CertificateUpdateRequest>(repository), ICertificateCrudService { }