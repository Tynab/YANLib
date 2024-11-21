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
            var developerTypeIds = result.Items.Where(x => x.DeveloperType.IsNotNull()).Select(x => x.DeveloperType!.Id).Distinct();
            var developerTypesTask = _developerTypeRepository.GetListAsync(x => developerTypeIds.Contains(x.Id));
            var developerIds = result.Items.Select(x => x.Id);
            var developerCertificatesTask = _developerCertificateRepository.GetListAsync(x => developerIds.Contains(x.DeveloperId));

            _ = await WhenAny(developerTypesTask, developerCertificatesTask);

            var developerTypes = await developerTypesTask;
            var developerCertificates = await developerCertificatesTask;
            var certificateIds = developerCertificates.Select(x => x.CertificateId).Distinct();
            var certificates = await _certificateRepository.GetListAsync(x => certificateIds.Contains(x.Id));

            result.Items = result.Items.Select(x =>
            {
                x.DeveloperType = ObjectMapper.Map<DeveloperType?, DeveloperTypeResponse?>(developerTypes.FirstOrDefault(y => y.Id == x.DeveloperType?.Id));
                x.Certificates = ObjectMapper.Map<List<Certificate?>, List<CertificateResponse?>>(
                    developerCertificates.Where(y => y.DeveloperId == x.Id).Select(y => certificates.FirstOrDefault(z => z.Id == y.CertificateId)).ToList()
                );

                return x;
            }).ToList();

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetList-DeveloperService: {DTO}", dto.Serialize());

            throw;
        }
    }

    public override async Task<DeveloperResponse> GetAsync(Guid id)
    {
        try
        {
            var resultTask = base.GetAsync(id);
            var developerCertificatesTask = _developerCertificateRepository.GetListAsync(x => x.DeveloperId == id);

            _ = await WhenAny(resultTask, developerCertificatesTask);

            var developerCertificates = await developerCertificatesTask;
            var certificatesTask = _certificateRepository.GetListAsync(x => developerCertificates.Select(x => x.CertificateId).Distinct().Contains(x.Id));
            var result = await resultTask;
            var developerTypeTask = _developerTypeRepository.FindAsync(result.DeveloperType!.Id);

            _ = await WhenAny(developerTypeTask, certificatesTask);

            var certificates = await certificatesTask;

            result.Certificates = ObjectMapper.Map<List<Certificate?>, List<CertificateResponse?>>(developerCertificates.Select(x => certificates.FirstOrDefault(y => y.Id == x.CertificateId)).ToList());
            result.DeveloperType = ObjectMapper.Map<DeveloperType?, DeveloperTypeResponse?>(await developerTypeTask);
            
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get-DeveloperService: {Id}", id);

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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Create-DeveloperService: {Request}", request.Serialize());

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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Update-DeveloperService: {Id} - {Request}", id, request.Serialize());

            throw;
        }
    }
}
