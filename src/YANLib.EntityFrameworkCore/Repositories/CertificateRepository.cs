using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.EntityFrameworkCore.DbContext;
using YANLib.Models;
using static System.DateTime;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Repositories;

public sealed class CertificateRepository : ICertificateRepository
{
    #region Fields
    private readonly ILogger<CertificateRepository> _logger;
    private readonly IYANLibDbContext _dbContext;
    #endregion

    #region Constructors
    public CertificateRepository(ILogger<CertificateRepository> logger, IYANLibDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    #endregion

    #region Implements
    public async ValueTask<IEnumerable<Certificate>> GetByDeveloperId(string developerId)
    {
        try
        {
            return await _dbContext.Certificates.AsNoTracking().Where(x => x.DeveloperId == developerId).ToArrayAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByDeveloperIdCertificateRepository-Exception: {DeveloperId}", developerId);
            throw;
        }
    }

    public async ValueTask<IEnumerable<Certificate>> Inserts(List<Certificate> entities)
    {
        try
        {
            entities.ForEach(x => x.CreatedDate = Now);

            await _dbContext.Certificates.AddRangeAsync(entities);

            return await _dbContext.SaveChangesAsync() > 0 ? entities : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertsCertificateRepository-Exception: {Entities}", entities.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<IEnumerable<Certificate>> Updates(List<Certificate> entities)
    {
        try
        {
            var rslts = await _dbContext.Certificates.AsNoTracking().Where(x => entities.Select(y => y.Id).Contains(x.Id)).ToListAsync();

            rslts.ForEach(x =>
            {
                var ent = entities.FirstOrDefault(y => y.Id == x.Id);

                x.Name = ent.Name;
                x.GPA = ent.GPA;
                x.DeveloperId = ent.DeveloperId;
                x.ModifiedDate = Now;
            });

            _dbContext.Certificates.UpdateRange(rslts);

            return await _dbContext.SaveChangesAsync() > 0 ? rslts : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdatesCertificateRepository-Exception: {Entities}", entities.CamelSerialize());
            throw;
        }
    }
    #endregion
}
