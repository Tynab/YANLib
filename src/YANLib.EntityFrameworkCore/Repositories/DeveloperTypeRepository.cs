//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Volo.Abp;
//using YANLib.EntityFrameworkCore.DbContext;
//using YANLib.Models;
//using static System.DateTime;
//using static YANLib.YANLibDomainErrorCodes;

//namespace YANLib.Repositories;

//public sealed class DeveloperTypeRepository : IDeveloperTypeRepository
//{
//    #region Fields
//    private readonly ILogger<DeveloperTypeRepository> _logger;
//    private readonly IYANLibDbContext _dbContext;
//    #endregion

//    #region Constructors
//    public DeveloperTypeRepository(ILogger<DeveloperTypeRepository> logger, IYANLibDbContext dbContext)
//    {
//        _logger = logger;
//        _dbContext = dbContext;
//    }
//    #endregion

//    #region Implements
//    public async ValueTask<IEnumerable<DeveloperType>> GetAll()
//    {
//        try
//        {
//            return await _dbContext.DeveloperTypes.AsNoTracking().ToArrayAsync();
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "GetAllDeveloperTypeRepository-Exception");
//            throw;
//        }
//    }

//    public async ValueTask<DeveloperType> Insert(DeveloperType entity)
//    {
//        try
//        {
//            var mdl = await _dbContext.DeveloperTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Code == entity.Code);

//            if (mdl is not null)
//            {
//                throw new BusinessException(EXIST_ID).WithData("Id", entity.Code);
//            }

//            entity.CreatedDate = Now;
//            _ = await _dbContext.DeveloperTypes.AddAsync(entity);

//            return await _dbContext.SaveChangesAsync() > 0 ? entity : throw new BusinessException(INTERNAL_SERVER_ERROR);
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "InsertDeveloperTypeRepository-Exception: {Entity}", entity.CamelSerialize());
//            throw;
//        }
//    }

//    public async ValueTask<DeveloperType> Update(DeveloperType entity)
//    {
//        try
//        {
//            var mdl = await _dbContext.DeveloperTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Code == entity.Code) ?? throw new BusinessException(NOT_FOUND_DEV_TYPE).WithData("Id", entity.Code);

//            mdl.Name = entity.Name;
//            mdl.IsActive = entity.IsActive;
//            mdl.ModifiedDate = Now;
//            _dbContext.DeveloperTypes.Update(mdl);

//            return await _dbContext.SaveChangesAsync() > 0 ? mdl : throw new BusinessException(INTERNAL_SERVER_ERROR);
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "UpdateDeveloperTypeRepository-Exception: {Entity}", entity.CamelSerialize());
//            throw;
//        }
//    }
//    #endregion
//}
