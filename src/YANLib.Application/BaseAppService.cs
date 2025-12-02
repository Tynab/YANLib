using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using YANLib.Localization;
using static Volo.Abp.Check;

namespace YANLib;

public abstract class BaseAppService : ApplicationService
{
    protected BaseAppService() => LocalizationResource = typeof(BaseResource);

    protected virtual async Task<PagedResultDto<TSource>> CreatePagedResultAsync<TSource>(IEnumerable<TSource> source, PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _ = NotNull(source, nameof(source));
        _ = NotNull(input, nameof(input));

        try
        {
            return await CreatePagedResultAsync(source.AsQueryable(), input, cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "CreatePagedResultAsync-BaseAppService-Exception: {Source} - {Input}", source.Serialize(), input.Serialize());

            throw;
        }
    }

    protected virtual async Task<PagedResultDto<TSource>> CreatePagedResultAsync<TSource>(IQueryable<TSource> query, PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _ = NotNull(query, nameof(query));
        _ = NotNull(input, nameof(input));

        try
        {
            if (!IsValidSortingField<TSource>(input.Sorting, cancellationToken))
            {
                input.Sorting = string.Empty;
            }

            if (input.Sorting.IsNotNullWhiteSpace())
            {
                query = query.OrderBy(input.Sorting);
            }

            return new PagedResultDto<TSource>(await AsyncExecuter.CountAsync(query, cancellationToken), await AsyncExecuter.ToListAsync(query.PageBy(input), cancellationToken));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "CreatePagedResultAsync-BaseAppService-Exception: {Query} - {Input}", query.Serialize(), input.Serialize());

            throw;
        }
    }

    protected virtual async Task<PagedResultDto<TResult>> CreatePagedResultAsync<TSource, TResult>(IQueryable<TSource> query, PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        _ = NotNull(query, nameof(query));
        _ = NotNull(input, nameof(input));

        try
        {
            if (!IsValidSortingField<TSource>(input.Sorting, cancellationToken))
            {
                input.Sorting = string.Empty;
            }

            if (input.Sorting.IsNotNullWhiteSpace())
            {
                query = query.OrderBy(input.Sorting);
            }

            return new PagedResultDto<TResult>(await AsyncExecuter.CountAsync(query, cancellationToken), ObjectMapper.Map<List<TSource>, List<TResult>>(await AsyncExecuter.ToListAsync(query.PageBy(input), cancellationToken)));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "CreatePagedResultAsync-BaseAppService-Exception: {Query} - {Input}", query.Serialize(), input.Serialize());

            throw;
        }
    }

    protected virtual bool IsValidSortingField<T>(string? sorting, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (sorting.IsNullWhiteSpace())
        {
            return false;
        }

        var properties = typeof(T).GetProperties();
        var sortFields = sorting.Split(',');

        foreach (var field in sortFields)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (properties.All(x => x.Name.NotEqualsIgnoreCase(field.Trim().Split(' ')[0])))
            {
                return false;
            }
        }

        return true;
    }
}
