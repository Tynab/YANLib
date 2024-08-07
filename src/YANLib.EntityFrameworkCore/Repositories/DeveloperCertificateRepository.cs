using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using YANLib.Core;
using YANLib.DbContexts;
using YANLib.Dtos;
using YANLib.Entities;
using static System.DateTime;

namespace YANLib.Repositories;

public class DeveloperCertificateRepository(
    ILogger<DeveloperCertificateRepository> logger,
    IDbContextProvider<IYANLibDbContext> dbContextProvider,
    IYANLibDbContext dbContext
) : EfCoreRepository<IYANLibDbContext, DeveloperCertificate, Guid>(dbContextProvider), IDeveloperCertificateRepository
{
    private readonly ILogger<DeveloperCertificateRepository> _logger = logger;
    private readonly IYANLibDbContext _dbContext = dbContext;

    public async ValueTask<DeveloperCertificate?> Modify(DeveloperCertificateDto dto)
    {
        try
        {
            return await _dbContext.DeveloperCertificates.Where(x => x.Id == dto.Id && x.IsDeleted == false).ExecuteUpdateAsync(s => s
                .SetProperty(x => x.UpdatedBy, dto.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, UtcNow)
                .SetProperty(x => x.IsActive, x => dto.IsActive ?? x.IsActive)
                .SetProperty(x => x.IsDeleted, x => dto.IsDeleted ?? x.IsDeleted)
            ) > 0 ? await _dbContext.SaveChangesAsync() > 0 ? await _dbContext.DeveloperCertificates.AsNoTracking().SingleOrDefaultAsync(x => x.Id == dto.Id) : default : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Modify-CertificateRepository-Exception: {DTO}", dto.Serialize());

            throw;
        }
    }
}
