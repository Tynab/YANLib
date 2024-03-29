﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.Entities;
using YANLib.EntityFrameworkCore.DbContext;
using static System.DateTime;

namespace YANLib.Repositories;

public sealed class CertificateRepository(ILogger<CertificateRepository> logger, IYANLibDbContext dbContext) : ICertificateRepository
{
    private readonly ILogger<CertificateRepository> _logger = logger;
    private readonly IYANLibDbContext _dbContext = dbContext;

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

    public async ValueTask<Certificate> Create(Certificate entity)
    {
        try
        {
            entity.CreatedAt = Now;

            var rslt = await _dbContext.Certificates.AddAsync(entity);

            return await _dbContext.SaveChangesAsync() > 0 ? rslt.Entity : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CreateCertificateRepository-Exception: {Entity}", entity.Serialize());
            throw;
        }
    }

    public async ValueTask<Certificate> Update(Certificate entity)
    {
        try
        {
            var mdl = await _dbContext.Certificates.AsNoTracking().SingleOrDefaultAsync(x => x.Id == entity.Id);

            mdl.Name = entity.Name;
            mdl.GPA = entity.GPA;
            mdl.DeveloperId = entity.DeveloperId;
            mdl.UpdatedAt = Now;

            var rslt = _dbContext.Certificates.Update(mdl);

            return await _dbContext.SaveChangesAsync() > 0 ? rslt.Entity : default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UpdateCertificateRepository-Exception: {Entity}", entity.Serialize());
            throw;
        }
    }
}
