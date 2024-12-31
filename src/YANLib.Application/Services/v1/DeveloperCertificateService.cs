using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using YANLib.Core;
using YANLib.Entities;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
using YANLib.Responses;

namespace YANLib.Services.v1;

public class DeveloperCertificateService(
    ILogger<DeveloperCertificateService> logger,
    IRepository<DeveloperCertificate, Guid> repository,
    IRepository<Developer, Guid> developerRepository,
    IRepository<Certificate, string> certificateRepository
) : CrudAppService<DeveloperCertificate, DeveloperCertificateResponse, Guid, PagedAndSortedResultRequestDto, DeveloperCertificateCreateRequest, DeveloperCertificateUpdateRequest>(repository), IDeveloperCertificateService
{
    private readonly ILogger<DeveloperCertificateService> _logger = logger;
    private readonly IRepository<Developer, Guid> _developerRepository = developerRepository;
    private readonly IRepository<Certificate, string> _certificateRepository = certificateRepository;

    public override async Task<DeveloperCertificateResponse> CreateAsync(DeveloperCertificateCreateRequest input)
    {
        try
        {
            _ = await _developerRepository.FindAsync(x => x.Id == input.DeveloperId) ?? throw new EntityNotFoundException(typeof(Developer), input.DeveloperId);
            _ = await _certificateRepository.FindAsync(x => x.Id == input.CertificateCode) ?? throw new EntityNotFoundException(typeof(Certificate), input.CertificateCode);

            return await base.CreateAsync(input);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Create-DeveloperCertificateService: {Input}", input.Serialize());

            throw;
        }
    }

    public override async Task<DeveloperCertificateResponse> UpdateAsync(Guid id, DeveloperCertificateUpdateRequest input)
    {
        try
        {
            _ = await _developerRepository.FindAsync(x => x.Id == input.DeveloperId) ?? throw new EntityNotFoundException(typeof(Developer), input.DeveloperId);
            _ = await _certificateRepository.FindAsync(x => x.Id == input.CertificateCode) ?? throw new EntityNotFoundException(typeof(Certificate), input.CertificateCode);

            return await base.UpdateAsync(id, input);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Update-DeveloperCertificateService: {Id} - {Input}", id, input.Serialize());

            throw;
        }
    }
}
