using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace YANLib;

public interface IYANLibRepository<TDto, TEntity, TKey> : IRepository<TEntity, TKey>, ITransientDependency where TDto : YANLibDomainDto<TKey> where TEntity : YANLibDomainEntity<TKey> where TKey : notnull, IEquatable<TKey>
{
    public Task<TEntity?> ModifyAsync(TDto dto, CancellationToken cancellationToken = default);
}
