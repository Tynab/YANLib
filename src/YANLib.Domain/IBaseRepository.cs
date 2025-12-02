using System.Linq.Expressions;
using Volo.Abp.Domain.Repositories;

namespace YANLib;

public interface IBaseRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : BaseEntity
{
    public Task<bool> SoftDeleteAsync(Guid id, Guid updatedBy, CancellationToken cancellationToken = default);

    public Task<bool> SoftDeleteManyAsync(Expression<Func<TEntity, bool>> predicate, Guid updatedBy, CancellationToken cancellationToken = default);
}
