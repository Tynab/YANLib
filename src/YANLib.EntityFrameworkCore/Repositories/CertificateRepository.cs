using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using YANLib.Entities;
using YANLib.EntityFrameworkCore.DbContext;
using static System.DateTime;
using static YANLib.YANLibDomainErrorCodes;

namespace YANLib.Repositories;

public sealed class CertificateRepository(ILogger<CertificateRepository> logger, IYANLibDbContext dbContext) : ICertificateRepository
{
    #region Fields
    private readonly ILogger<CertificateRepository> _logger = logger;
    private readonly IYANLibDbContext _dbContext = dbContext;
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

    public async ValueTask<Certificate> Insert(Certificate entity)
    {
        try
        {
            entity.CreatedDate = Now;

            var rslt = (await _dbContext.Certificates.AddAsync(entity)).Entity;

            return await _dbContext.SaveChangesAsync() > 0 ? rslt : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "InsertCertificateRepository-Exception: {Entity}", entity.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<Certificate> Update(Certificate entity)
    {
        try
        {
            var mdl = await _dbContext.Certificates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

            mdl.Name = entity.Name;
            mdl.GPA = entity.GPA;
            mdl.DeveloperId = entity.DeveloperId;
            mdl.ModifiedDate = Now;

            var rslt = _dbContext.Certificates.Update(mdl).Entity;

            return await _dbContext.SaveChangesAsync() > 0 ? rslt : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdateCertificateRepository-Exception: {Entity}", entity.CamelSerialize());
            throw;
        }
    }
    #endregion
}
