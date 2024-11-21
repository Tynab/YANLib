using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using YANLib.Core;
using YANLib.Entities;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;
using static YANLib.YANLibDomainErrorCodes;
using static System.Threading.Tasks.Task;
using System.Collections.Generic;

namespace YANLib.Services.v1;

public class DeveloperService(
    ILogger<DeveloperService> logger,
    IRepository<Developer, Guid> repository,
    IRepository<DeveloperType, long> developerTypeRepository,
    IRepository<DeveloperCertificate, Guid> developerCertificateRepository,
    IRepository<Certificate, string> certificateRepository
) : CrudAppService<Developer, DeveloperResponse, Guid, PagedAndSortedResultRequestDto, DeveloperCreateRequest, DeveloperUpdateRequest>(repository), IDeveloperService
{
    private readonly ILogger<DeveloperService> _logger = logger;
    private readonly IRepository<DeveloperType, long> _developerTypeRepository = developerTypeRepository;
    private readonly IRepository<DeveloperCertificate, Guid> _developerCertificateRepository = developerCertificateRepository;
    private readonly IRepository<Certificate, string> _certificateRepository = certificateRepository;

    public override async Task<PagedResultDto<DeveloperResponse>> GetListAsync(PagedAndSortedResultRequestDto dto)
    {
        try
        {
            var result = await base.GetListAsync(dto);
            var developerTypes = await _developerTypeRepository.GetListAsync(x => result.Items.Where(x => x.DeveloperType.IsNotNull()).Select(x => x.DeveloperType!.Id).Distinct().Contains(x.Id));
            var developerCertificates = await _developerCertificateRepository.GetListAsync(x => result.Items.Select(x => x.Id).Contains(x.DeveloperId));
            var certificates = await _certificateRepository.GetListAsync(x => developerCertificates.Select(x => x.CertificateId).Distinct().Contains(x.Id));

            result.Items = result.Items.Select(x =>
            {
                x.DeveloperType = ObjectMapper.Map<DeveloperType?, DeveloperTypeResponse?>(developerTypes.FirstOrDefault(y => y.Id == x.DeveloperType?.Id));
                x.Certificates = ObjectMapper.Map<List<Certificate?>, List<CertificateResponse?>>(
                    developerCertificates.Where(y => y.DeveloperId == x.Id).Select(y => certificates.FirstOrDefault(z => z.Id == y.CertificateId)).Where(z => z.IsNotNull()).ToList()
                );

                return x;
            }).ToList();

            return result;
        }
        catch (Exception)
        {
            _logger.LogError("GetList-DeveloperService: {DTO}", dto.Serialize());

            throw;
        }
    }

    public override async Task<DeveloperResponse> CreateAsync(DeveloperCreateRequest request)
    {
        try
        {
            _ = await _developerTypeRepository.FindAsync(request.DeveloperTypeId) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", request.DeveloperTypeId);

            return await base.CreateAsync(request);
        }
        catch (Exception)
        {
            _logger.LogError("Create-DeveloperService: {Request}", request.Serialize());

            throw;
        }
    }

    public override async Task<DeveloperResponse> UpdateAsync(Guid id, DeveloperUpdateRequest request)
    {
        try
        {
            _ = await _developerTypeRepository.FindAsync(request.DeveloperTypeId) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Code", request.DeveloperTypeId);

            return await base.UpdateAsync(id, request);
        }
        catch (Exception)
        {
            _logger.LogError("Update-DeveloperService: {Id} - {Request}", id, request.Serialize());

            throw;
        }
    }
}
