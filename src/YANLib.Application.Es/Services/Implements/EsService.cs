using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using System.Linq.Expressions;
using System.Reflection;
using Volo.Abp.Application.Dtos;
using YANLib;
using YANLib.Attributes;
using YANLib.Services;
using static Nest.DateMath;
using static Nest.SortOrder;
using static System.Guid;
using static System.Linq.Expressions.Expression;
using static System.Math;
using static System.Reflection.BindingFlags;
using static System.Threading.Tasks.Task;
using static YANLib.YANExpression;

namespace YANLib.Services.Implements;

public class EsService<TEsIndex, TId>(ILogger<EsService<TEsIndex, TId>> logger, IConfiguration configuration, IElasticClient elasticClient)
    : IEsService<TEsIndex, TId> where TEsIndex : BaseEsIndex<TId>
{
    protected virtual string GetDocumentIdAsync(TEsIndex data)
    {
        try
        {
            var idField = typeof(TEsIndex).GetCustomAttribute<EsIdFieldAttribute>();

            if (idField.IsNotNull())
            {
                var property = typeof(TEsIndex).GetProperty(idField.FieldName, Instance | Public | IgnoreCase);

                if (property.IsNotNull())
                {
                    var value = property.GetValue(data);

                    if (value.IsNotNull())
                    {
                        return value.ToString()!;
                    }
                }

                logger.LogWarning("EsIdField '{FieldName}' not found or is null, falling back to Id", idField.FieldName);
            }

            return data.Id?.ToString() ?? NewGuid().ToString();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetDocumentIdAsync-EsService-Exception: {Data}", data.Serialize());

            return data.Id?.ToString() ?? NewGuid().ToString();
        }
    }

    public async Task<PagedResultDto<TEsIndex>> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var fieldSelectors = ToFieldSelectorDictionary(cancellationToken);

            var response = await elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => input.Sorting.IsNullWhiteSpace() ? d : d.Field(f =>
                {
                    foreach (var sortParams in input.Sorting.Split(',').AsEnumerable().Reverse().Where(x => x.IsNotNullWhiteSpace()).Select(x => x.Trim().Split(' ')))
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        if (sortParams.Length > 0 && sortParams[0].IsNotNullWhiteSpace() && fieldSelectors.TryGetValue(sortParams[0].LowerInvariant() ?? string.Empty, out var fieldSelector))
                        {
                            _ = f.Field(fieldSelector).MissingLast();
                        }

                        _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                    }

                    return f;
                }))
                .Query(q => q.MatchAll()), cancellationToken
            );

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (OperationCanceledException ex)
        {
            logger.LogWarning("Operation was canceled: {Method}", nameof(GetAllAsync));

            throw new OperationCanceledException($"Elasticsearch GetAllAsync operation canceled", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetAllAsync-EsService-Exception");

            throw;
        }
    }

    public async Task<TEsIndex?> GetAsync(TId id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return (await elasticClient.GetAsync<TEsIndex>(id?.ToString(), ct: cancellationToken)).Source ?? default;
        }
        catch (OperationCanceledException ex)
        {
            logger.LogWarning("Operation was canceled: {Method} - {Id}", nameof(GetAsync), id);

            throw new OperationCanceledException($"Elasticsearch GetAsync operation canceled for {id}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetAsync-EsService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<bool> SetAsync(TEsIndex data, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return (await elasticClient.IndexAsync(data, i => i.Id(GetDocumentIdAsync(data)), cancellationToken)).IsNotNull();
        }
        catch (OperationCanceledException ex)
        {
            logger.LogWarning("Operation was canceled: {Method} - {Data}", nameof(SetAsync), data.Serialize());

            throw new OperationCanceledException($"Elasticsearch SetAsync operation canceled for {data.Serialize()}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SetAsync-EsService-Exception: {Data}", data.Serialize());

            throw;
        }
    }

    public async Task<bool> SetBulkAsync(List<TEsIndex> datas, string indexPath, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var index = configuration.GetSection(indexPath)?.Value;

            if (index.IsNullWhiteSpace())
            {
                return false;
            }

            var requests = new BulkDescriptor();

            foreach (var data in datas.OrderBy(x => x.CreatedAt))
            {
                cancellationToken.ThrowIfCancellationRequested();
                _ = requests.Index<TEsIndex>(x => x.Document(data).Index(index).Id(GetDocumentIdAsync(data)));
            }

            return (await elasticClient.BulkAsync(requests, cancellationToken)).IsNotNull();
        }
        catch (OperationCanceledException ex)
        {
            logger.LogWarning("Operation was canceled: {Method} - {Datas} - {IndexPath}", nameof(SetBulkAsync), datas.Serialize(), indexPath);

            throw new OperationCanceledException($"Elasticsearch SetBulkAsync operation canceled for {datas.Serialize()} - {indexPath}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SetBulkAsync-EsService-Exception: {Datas} - {IndexPath}", datas.Serialize(), indexPath);

            throw;
        }
    }

    public async Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return (await elasticClient.DeleteAsync<TEsIndex>(id?.ToString(), ct: cancellationToken)).IsNotNull();
        }
        catch (OperationCanceledException ex)
        {
            logger.LogWarning("Operation was canceled: {Method} - {Id}", nameof(DeleteAsync), id);

            throw new OperationCanceledException($"Elasticsearch DeleteAsync operation canceled for {id}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "DeleteAsync-EsService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<bool> DeleteAllAsync(string indexPath, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return await FromResult(elasticClient.DeleteIndexAsync(configuration, indexPath, cancellationToken).IsNotNull());
        }
        catch (OperationCanceledException ex)
        {
            logger.LogWarning("Operation was canceled: {Method} - {IndexPath}", nameof(DeleteAllAsync), indexPath);

            throw new OperationCanceledException($"Elasticsearch DeleteAllAsync operation canceled for {indexPath}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "DeleteAllAsync-EsService-Exception: {IndexPath}", indexPath);

            throw;
        }
    }

    public async Task<List<TEsIndex>> GetByFieldAsync(Dictionary<string, object?> dict, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var fieldSelectors = ToFieldSelectorDictionary(cancellationToken);
            var mustQueries = new List<Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>>();

            foreach (var kvp in dict)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var fieldName = kvp.Key;
                var value = kvp.Value;

                if (!fieldSelectors.TryGetValue(fieldName.LowerInvariant() ?? string.Empty, out var expr))
                {
                    throw new ArgumentException($"Field '{fieldName}' not found in {nameof(TEsIndex)} properties.", nameof(dict));
                }

                if (value.IsNull())
                {
                    mustQueries.Add(q => q
                        .Bool(b => b
                            .MustNot(n => n
                                .Exists(e => e
                                    .Field(expr)
                                )
                            )
                        )
                    );
                }
                else
                {
                    mustQueries.Add(q => q
                        .Term(t => t
                            .Field(expr)
                            .Value(value)
                        )
                    );
                }
            }

            var response = await elasticClient.SearchAsync<TEsIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(mustQueries.ToArray())
                    )
                ), cancellationToken
            );

            return [.. response.Documents];
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetByFieldAsync-EsService-Exception: {Dict}", dict.Serialize());

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> GetByFieldAsync(PagedAndSortedResultRequestDto input, Dictionary<string, object?> dict, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var fieldSelectors = ToFieldSelectorDictionary(cancellationToken);
            var mustQueries = new List<Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>>();

            foreach (var kvp in dict)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var fieldName = kvp.Key;
                var value = kvp.Value;

                if (!fieldSelectors.TryGetValue(fieldName.LowerInvariant() ?? string.Empty, out var expr))
                {
                    throw new ArgumentException($"Field '{fieldName}' not found in {nameof(TEsIndex)} properties.", nameof(dict));
                }

                if (value.IsNull())
                {
                    mustQueries.Add(q => q
                        .Bool(b => b
                            .MustNot(n => n
                                .Exists(e => e
                                    .Field(expr)
                                )
                            )
                        )
                    );
                }
                else
                {
                    mustQueries.Add(q => q
                        .Term(t => t
                            .Field(expr)
                            .Value(value)
                        )
                    );
                }
            }

            var response = await elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(sort => input.Sorting.IsNullWhiteSpace()
                    ? sort
                    : sort.Field(f =>
                    {
                        foreach (var sortParams in input.Sorting.Split(',').Reverse().Where(x => x.IsNotNullWhiteSpace()).Select(x => x.Trim().Split(' ')))
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            if (sortParams.Length > 0 && fieldSelectors.TryGetValue(sortParams[0], out var selector))
                            {
                                _ = f.Field(selector).MissingLast();
                            }

                            _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                        }

                        return f;
                    })
                )
                .Query(q => q
                    .Bool(b => b
                        .Must(mustQueries.ToArray())
                    )
                ), cancellationToken
            );

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetByFieldAsync-EsService-Exception: {Dict}", dict.Serialize());

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithWildcardAsync(
        PagedAndSortedResultRequestDto input,
        string? searchText,
        IEnumerable<string> fieldNames,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        Expression<Func<TEsIndex, object?>>? dateFieldSelector = null,
        bool isActive = false,
        IDictionary<string, object>? filters = null,
        CancellationToken cancellationToken = default
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var mustQueries = searchText.IsNullWhiteSpace()
                ? new List<Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>>
                {
                    d => d.Bool(b => b
                        .Should(fieldNames.Select(x => new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(m => m
                            .MatchAll()
                            )).ToArray()
                        )
                    )
                }
                :
                [
                    d => d.Bool(b => b
                        .Should(fieldNames.Select(x => new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(m => m
                            .Wildcard(p => p
                                .Field(PropertyExpression<TEsIndex>("c", x))
                                .Value($"*{searchText}*"))
                            )).ToArray()
                        )
                    )
                ];

            if (filters.IsNotNull())
            {
                foreach (var filter in filters)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (filter.Value.IsNull())
                    {
                        mustQueries.Add(q => q
                            .Bool(b => b
                                .MustNot(n => n
                                    .Exists(e => e
                                        .Field(PropertyExpression<TEsIndex>("c", filter.Key))
                                    )
                                )
                            )
                        );
                    }
                    else
                    {
                        mustQueries.Add(q => q
                            .Term(t => t
                                .Field(PropertyExpression<TEsIndex>("c", filter.Key))
                                .Value(filter.Value)
                            )
                        );
                    }
                }
            }

            if (dateFrom.HasValue || dateTo.HasValue)
            {
                mustQueries.Add(d => d.DateRange(r =>
                {
                    _ = r.Field(dateFieldSelector ?? (x => x.CreatedAt));

                    if (dateFrom.HasValue)
                    {
                        _ = r.GreaterThanOrEquals(Anchored(dateFrom.Value));
                    }

                    if (dateTo.HasValue)
                    {
                        dateTo = dateTo.Value.AddDays(1).AddTicks(-1);
                        _ = r.LessThanOrEquals(Anchored(dateTo.Value));
                    }

                    return r;
                }));
            }

            if (isActive)
            {
                mustQueries.Add(d => d
                    .Term(t => t
                        .Field(x => x.IsActive)
                        .Value(true)
                    )
                );
            }

            var fieldSelectors = ToFieldSelectorDictionary(cancellationToken);

            var response = await elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => input.Sorting.IsNullWhiteSpace() ? d : d.Field(f =>
                {
                    foreach (var sortParams in input.Sorting.Split(',').AsEnumerable().Reverse().Where(x => x.IsNotNullWhiteSpace()).Select(x => x.Trim().Split(' ')))
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        if (sortParams.Length > 0 && sortParams[0].IsNotNullWhiteSpace() && fieldSelectors.TryGetValue(sortParams[0].LowerInvariant() ?? string.Empty, out var fieldSelector))
                        {
                            _ = f.Field(fieldSelector).MissingLast();
                        }

                        _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                    }

                    return f;
                }))
                .Query(q => q
                    .Bool(b => b
                        .Must(mustQueries.ToArray())
                    )
                ), cancellationToken);

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SearchWithWildcardAsync-EsService-Exception: {Input} - {SearchString} - {FieldNames}", input.Serialize(), searchText, fieldNames);

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithPhrasePrefixAsync(
        PagedAndSortedResultRequestDto input,
        string? searchText,
        IEnumerable<string> fieldNames,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        Expression<Func<TEsIndex, object?>>? dateFieldSelector = null,
        bool isActive = false,
        IDictionary<string, object>? filters = null,
        CancellationToken cancellationToken = default
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var mustQueries = searchText.IsNullWhiteSpace()
                ? new List<Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>>
                {
                    d => d.Bool(b => b
                        .Should(fieldNames.Select(x => new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(m => m
                            .MatchAll()
                            )).ToArray()
                        )
                    )
                }
                :
                [
                    d => d.Bool(b => b
                        .Should(fieldNames.Select(x => new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(m => m
                            .MatchPhrasePrefix(p => p
                                .Field(PropertyExpression<TEsIndex>("c", x))
                                .Query(searchText))
                            )).ToArray()
                        )
                    )
                ];

            if (filters.IsNotNull())
            {
                foreach (var filter in filters)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (filter.Value.IsNull())
                    {
                        mustQueries.Add(q => q
                            .Bool(b => b
                                .MustNot(n => n
                                    .Exists(e => e
                                        .Field(PropertyExpression<TEsIndex>("c", filter.Key))
                                    )
                                )
                            )
                        );
                    }
                    else
                    {
                        mustQueries.Add(q => q
                            .Term(t => t
                                .Field(PropertyExpression<TEsIndex>("c", filter.Key))
                                .Value(filter.Value)
                            )
                        );
                    }
                }
            }

            if (dateFrom.HasValue || dateTo.HasValue)
            {
                mustQueries.Add(d => d.DateRange(r =>
                {
                    _ = r.Field(dateFieldSelector ?? (x => x.CreatedAt));

                    if (dateFrom.HasValue)
                    {
                        _ = r.GreaterThanOrEquals(Anchored(dateFrom.Value));
                    }

                    if (dateTo.HasValue)
                    {
                        dateTo = dateTo.Value.AddDays(1).AddTicks(-1);
                        _ = r.LessThanOrEquals(Anchored(dateTo.Value));
                    }

                    return r;
                }));
            }

            if (isActive)
            {
                mustQueries.Add(d => d
                    .Term(t => t
                        .Field(x => x.IsActive)
                        .Value(true)
                    )
                );
            }

            var fieldSelectors = ToFieldSelectorDictionary(cancellationToken);

            var response = await elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => input.Sorting.IsNullWhiteSpace() ? d : d.Field(f =>
                {
                    foreach (var sortParams in input.Sorting.Split(',').AsEnumerable().Reverse().Where(x => x.IsNotNullWhiteSpace()).Select(x => x.Trim().Split(' ')))
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        if (sortParams.Length > 0 && sortParams[0].IsNotNullWhiteSpace() && fieldSelectors.TryGetValue(sortParams[0].LowerInvariant() ?? string.Empty, out var fieldSelector))
                        {
                            _ = f.Field(fieldSelector).MissingLast();
                        }

                        _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                    }

                    return f;
                }))
                .Query(q => q
                    .Bool(b => b
                        .Must(mustQueries.ToArray())
                    )
                ), cancellationToken);

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SearchWithPhrasePrefixAsync-EsService-Exception: {Input} - {SearchString} - {FieldNames}", input.Serialize(), searchText, fieldNames);

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithExactPhraseAsync(
        PagedAndSortedResultRequestDto input,
        string? searchText,
        IEnumerable<string> fieldNames,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        Expression<Func<TEsIndex, object?>>? dateFieldSelector = null,
        bool isActive = false,
        IDictionary<string, object>? filters = null,
        CancellationToken cancellationToken = default
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var mustQueries = searchText.IsNullWhiteSpace()
                ? new List<Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>>
                {
                    d => d.Bool(b => b
                        .Should(fieldNames.Select(x => new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(m => m
                            .MatchAll()
                            )).ToArray()
                        )
                    )
                }
                :
                [
                    d => d.Bool(b => b
                        .Should(fieldNames.Select(x => new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(m => m
                            .MatchPhrase(p => p
                                .Field(PropertyExpression<TEsIndex>("c", x))
                                .Query(searchText))
                            )).ToArray()
                        )
                    )
                ];

            if (filters.IsNotNull())
            {
                foreach (var filter in filters)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (filter.Value.IsNull())
                    {
                        mustQueries.Add(q => q
                            .Bool(b => b
                                .MustNot(n => n
                                    .Exists(e => e
                                        .Field(PropertyExpression<TEsIndex>("c", filter.Key))
                                    )
                                )
                            )
                        );
                    }
                    else
                    {
                        mustQueries.Add(q => q
                            .Term(t => t
                                .Field(PropertyExpression<TEsIndex>("c", filter.Key))
                                .Value(filter.Value)
                            )
                        );
                    }
                }
            }

            if (dateFrom.HasValue || dateTo.HasValue)
            {
                mustQueries.Add(d => d.DateRange(r =>
                {
                    _ = r.Field(dateFieldSelector ?? (x => x.CreatedAt));

                    if (dateFrom.HasValue)
                    {
                        _ = r.GreaterThanOrEquals(Anchored(dateFrom.Value));
                    }

                    if (dateTo.HasValue)
                    {
                        dateTo = dateTo.Value.AddDays(1).AddTicks(-1);
                        _ = r.LessThanOrEquals(Anchored(dateTo.Value));
                    }

                    return r;
                }));
            }

            if (isActive)
            {
                mustQueries.Add(d => d
                    .Term(t => t
                        .Field(x => x.IsActive)
                        .Value(true)
                    )
                );
            }

            var fieldSelectors = ToFieldSelectorDictionary(cancellationToken);

            var response = await elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => input.Sorting.IsNullWhiteSpace() ? d : d.Field(f =>
                {
                    foreach (var sortParams in input.Sorting.Split(',').AsEnumerable().Reverse().Where(x => x.IsNotNullWhiteSpace()).Select(x => x.Trim().Split(' ')))
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        if (sortParams.Length > 0 && sortParams[0].IsNotNullWhiteSpace() && fieldSelectors.TryGetValue(sortParams[0].LowerInvariant() ?? string.Empty, out var fieldSelector))
                        {
                            _ = f.Field(fieldSelector).MissingLast();
                        }

                        _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                    }

                    return f;
                }))
                .Query(q => q
                    .Bool(b => b
                        .Must(mustQueries.ToArray())
                    )
                ), cancellationToken);

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SearchWithExactPhraseAsync-EsService-Exception: {Input} - {SearchWords} - {FieldNames}", input.Serialize(), searchText, fieldNames);

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithKeywordsAsync(
        PagedAndSortedResultRequestDto input,
        string? searchText,
        IEnumerable<string> fieldNames,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        Expression<Func<TEsIndex, object?>>? dateFieldSelector = null,
        bool isActive = false,
        IDictionary<string, object>? filters = null,
        CancellationToken cancellationToken = default
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var mustQueries = searchText.IsNullWhiteSpace()
                ? new List<Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>>
                {
                    d => d.Bool(b => b
                        .Should(fieldNames.Select(x => new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(m => m
                            .MatchAll()
                            )).ToArray()
                        )
                    )
                }
                :
                [
                    d => d.Bool(b => b
                        .Should(fieldNames.Select(x => new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(m => m
                            .Match(p => p
                                .Field(PropertyExpression<TEsIndex>("c", x))
                                .Query(searchText))
                            )).ToArray()
                        )
                    )
                ];

            if (filters.IsNotNull())
            {
                foreach (var filter in filters)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (filter.Value.IsNull())
                    {
                        mustQueries.Add(q => q
                            .Bool(b => b
                                .MustNot(n => n
                                    .Exists(e => e
                                        .Field(PropertyExpression<TEsIndex>("c", filter.Key))
                                    )
                                )
                            )
                        );
                    }
                    else
                    {
                        mustQueries.Add(q => q
                            .Term(t => t
                                .Field(PropertyExpression<TEsIndex>("c", filter.Key))
                                .Value(filter.Value)
                            )
                        );
                    }
                }
            }

            if (dateFrom.HasValue || dateTo.HasValue)
            {
                mustQueries.Add(d => d.DateRange(r =>
                {
                    _ = r.Field(dateFieldSelector ?? (x => x.CreatedAt));

                    if (dateFrom.HasValue)
                    {
                        _ = r.GreaterThanOrEquals(Anchored(dateFrom.Value));
                    }

                    if (dateTo.HasValue)
                    {
                        dateTo = dateTo.Value.AddDays(1).AddTicks(-1);
                        _ = r.LessThanOrEquals(Anchored(dateTo.Value));
                    }

                    return r;
                }));
            }

            if (isActive)
            {
                mustQueries.Add(d => d
                    .Term(t => t
                        .Field(x => x.IsActive)
                        .Value(true)
                    )
                );
            }

            var fieldSelectors = ToFieldSelectorDictionary(cancellationToken);

            var response = await elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => input.Sorting.IsNullWhiteSpace() ? d : d.Field(f =>
                {
                    foreach (var sortParams in input.Sorting.Split(',').AsEnumerable().Reverse().Where(x => x.IsNotNullWhiteSpace()).Select(x => x.Trim().Split(' ')))
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        if (sortParams.Length > 0 && sortParams[0].IsNotNullWhiteSpace() && fieldSelectors.TryGetValue(sortParams[0].LowerInvariant() ?? string.Empty, out var fieldSelector))
                        {
                            _ = f.Field(fieldSelector).MissingLast();
                        }

                        _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                    }

                    return f;
                }))
                .Query(q => q
                    .Bool(b => b
                        .Must(mustQueries.ToArray())
                    )
                ), cancellationToken);

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SearchWithKeywordsAsync-EsService-Exception: {Input} - {SearchWords} - {FieldNames}", input.Serialize(), searchText, fieldNames);

            throw;
        }
    }

    protected static Dictionary<string, Expression<Func<TEsIndex, object?>>> ToFieldSelectorDictionary(CancellationToken cancellationToken = default)
    {
        var fieldSelectors = new Dictionary<string, Expression<Func<TEsIndex, object?>>>();

        foreach (var propertyInfo in typeof(TEsIndex).GetProperties(Public | Instance))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var parameter = Parameter(typeof(TEsIndex), "x");
            var propertyAccess = Property(parameter, propertyInfo);

            fieldSelectors.Add(propertyInfo.Name.LowerInvariant() ?? string.Empty, Lambda<Func<TEsIndex, object?>>(propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(Guid) ? Call(typeof(SuffixExtensions).GetMethod(nameof(SuffixExtensions.Suffix), new[]
            {
                typeof(object),
                typeof(string)
            })!, Convert(propertyAccess, typeof(object)), Constant("keyword")) : Convert(propertyAccess, typeof(object)), parameter));
        }

        return fieldSelectors;
    }
}
