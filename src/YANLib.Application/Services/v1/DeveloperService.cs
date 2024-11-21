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
using NUglify.Helpers;
using Volo.Abp.Domain.Entities;
using Nest;

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

    public override async Task<PagedResultDto<DeveloperResponse>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        try
        {
            var result = await base.GetListAsync(input);
            var developerTypeIds = result.Items.Where(x => x.DeveloperType.IsNotNull()).Select(x => x.DeveloperType!.Id).Distinct();
            var developerTypes = await _developerTypeRepository.GetListAsync(x => developerTypeIds.Contains(x.Id));
            var developerIds = result.Items.Select(x => x.Id).Distinct();
            var developerCertificates = await _developerCertificateRepository.GetListAsync(x => developerIds.Contains(x.DeveloperId));
            var certificateIds = developerCertificates.Select(x => x.CertificateId).Distinct();
            var certificates = await _certificateRepository.GetListAsync(x => certificateIds.Contains(x.Id));

            result.Items.ForEach(x =>
            {
                x.DeveloperType = ObjectMapper.Map<DeveloperType?, DeveloperTypeResponse?>(developerTypes.FirstOrDefault(y => y.Id == x.DeveloperType?.Id));
                x.Certificates = ObjectMapper.Map<List<Certificate?>, List<CertificateResponse?>>(
                    developerCertificates.Where(y => y.DeveloperId == x.Id).Select(y => certificates.FirstOrDefault(z => z.Id == y.CertificateId)).ToList()
                );
            });

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetList-DeveloperService: {Input}", input.Serialize());

            throw;
        }
    }

    public override async Task<DeveloperResponse> GetAsync(Guid id)
    {
        try
        {
            var result = await base.GetAsync(id);
            var developerCertificates = await _developerCertificateRepository.GetListAsync(x => x.DeveloperId == id);
            var certificates = await _certificateRepository.GetListAsync(x => developerCertificates.Select(x => x.CertificateId).Distinct().Contains(x.Id));

            result.DeveloperType = ObjectMapper.Map<DeveloperType?, DeveloperTypeResponse?>(await _developerTypeRepository.FindAsync(result.DeveloperType!.Id));
            result.Certificates = ObjectMapper.Map<List<Certificate?>, List<CertificateResponse?>>(developerCertificates.Select(x => certificates.FirstOrDefault(y => y.Id == x.CertificateId)).ToList());

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get-DeveloperService: {Id}", id);

            throw;
        }
    }

    public override async Task<DeveloperResponse> CreateAsync(DeveloperCreateRequest input)
    {
        try
        {
            var developerType = await _developerTypeRepository.FindAsync(input.DeveloperTypeId) ?? throw new EntityNotFoundException(typeof(DeveloperType), input.DeveloperTypeId);
            var result = await base.CreateAsync(input);

            if (developerType.IsNotNull())
            {
                result.DeveloperType = ObjectMapper.Map<DeveloperType?, DeveloperTypeResponse?>(developerType);
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Create-DeveloperService: {Input}", input.Serialize());

            throw;
        }
    }

    public override async Task<DeveloperResponse> UpdateAsync(Guid id, DeveloperUpdateRequest input)
    {
        try
        {
            var developerType = await _developerTypeRepository.FindAsync(input.DeveloperTypeId) ?? throw new EntityNotFoundException(typeof(DeveloperType), input.DeveloperTypeId);
            var result = await base.UpdateAsync(id, input);

            if (developerType.IsNotNull())
            {
                result.DeveloperType = ObjectMapper.Map<DeveloperType?, DeveloperTypeResponse?>(developerType);
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Update-DeveloperService: {Id} - {Input}", id, input.Serialize());

            throw;
        }
    }
}
