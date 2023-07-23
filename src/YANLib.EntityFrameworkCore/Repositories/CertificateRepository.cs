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
    public async ValueTask<Certificate> Get(Guid id)
    {
        try
        {
            return await _dbContext.Certificates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetCertificateRepository-Exception: {Id}", id);
            throw;
        }
    }

    public async ValueTask<Certificate> Insert(Certificate entity)
    {
        try
        {
            entity.CreatedDate = Now;
            _ = await _dbContext.Certificates.AddAsync(entity);

            return await _dbContext.SaveChangesAsync() > 0 ? entity : throw new BusinessException(INTERNAL_SERVER_ERROR);
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
            var mdl = await Get(entity.Id) ?? throw new BusinessException(NOT_FOUND_CERT);

            mdl.Name = entity.Name;
            mdl.GPA = entity.GPA;
            mdl.DeveloperId = entity.DeveloperId;
            mdl.ModifiedDate = Now;
            _dbContext.Certificates.Update(mdl);

            return await _dbContext.SaveChangesAsync() > 0 ? mdl : throw new BusinessException(INTERNAL_SERVER_ERROR);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdateCertificateRepository-Exception: {Entity}", entity.CamelSerialize());
            throw;
        }
    }

    public async ValueTask<IEnumerable<Certificate>> GetByDeveloperId(Guid developerId)
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
    #endregion
}
