using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using static Nest.SortOrder;
using static System.Linq.Expressions.Expression;
using static System.Math;
using static System.Reflection.BindingFlags;
using static System.Threading.Tasks.Task;
using static YANLib.YANExpression;

namespace YANLib.Services.Implements;

public class ElasticsearchService<TEsIndex, TId>(ILogger<ElasticsearchService<TEsIndex, TId>> logger, IConfiguration configuration, IElasticClient elasticClient)
    : IElasticsearchService<TEsIndex, TId> where TEsIndex : YANLibApplicationEsIndex<TId>
{
    private readonly ILogger<ElasticsearchService<TEsIndex, TId>> _logger = logger;
    private readonly IConfiguration _configuration = configuration;
    private readonly IElasticClient _elasticClient = elasticClient;

    public async Task<PagedResultDto<TEsIndex>> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var fieldSelectors = ToFieldSelectorDictionary();

            var response = await _elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => input.Sorting.IsNullWhiteSpace() ? d : d.Field(f =>
                {
                    foreach (var sortParams in input.Sorting.Split(',').AsEnumerable().Reverse().Where(x => x.IsNotNullWhiteSpace()).Select(x => x.Trim().Split(' ')))
                    {
                        if (sortParams.Length > 0 && sortParams[0].IsNotNullWhiteSpace() && fieldSelectors.TryGetValue(sortParams[0], out var fieldSelector))
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
            _logger.LogWarning("Operation was canceled: {Method}", nameof(GetAllAsync));

            throw new OperationCanceledException($"Elasticsearch GetAllAsync operation canceled", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllAsync-ElasticsearchService-Exception");

            throw;
        }
    }

    public async Task<TEsIndex?> GetAsync(TId id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return (await _elasticClient.GetAsync<TEsIndex>(id?.ToString(), ct: cancellationToken)).Source ?? default;
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Id}", nameof(GetAsync), id);

            throw new OperationCanceledException($"Elasticsearch GetAsync operation canceled for {id}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAsync-ElasticsearchService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<bool> SetAsync(TEsIndex data, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return (await _elasticClient.IndexAsync(data, i => i.Id(data.Id?.ToString()), cancellationToken)).IsNotNull();
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Id}", nameof(SetAsync), data.Id);

            throw new OperationCanceledException($"Elasticsearch SetAsync operation canceled for {data.Id}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetAsync-ElasticsearchService-Exception: {Data}", data.Serialize());

            throw;
        }
    }

    public async Task<bool> SetBulkAsync(List<TEsIndex> datas, string indexPath, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var index = _configuration.GetSection(indexPath)?.Value;

            if (index.IsNullWhiteSpace())
            {
                return false;
            }

            var requests = new BulkDescriptor();

            foreach (var data in datas.OrderBy(x => x.CreatedAt))
            {
                cancellationToken.ThrowIfCancellationRequested();
                _ = requests.Index<TEsIndex>(x => x.Document(data).Index(index).Id(data.Id?.ToString()));
            }

            return (await _elasticClient.BulkAsync(requests, cancellationToken)).IsNotNull();
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {IndexPath}", nameof(SetBulkAsync), indexPath);

            throw new OperationCanceledException($"Elasticsearch SetBulkAsync operation canceled for {indexPath}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetBulkAsync-ElasticsearchService-Exception: {Datas} - {IndexPath}", datas.Serialize(), indexPath);

            throw;
        }
    }

    public async Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return (await _elasticClient.DeleteAsync<TEsIndex>(id?.ToString(), ct: cancellationToken)).IsNotNull();
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {Id}", nameof(DeleteAsync), id);

            throw new OperationCanceledException($"Elasticsearch DeleteAsync operation canceled for {id}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAsync-ElasticsearchService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<bool> DeleteAllAsync(string indexPath, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return await FromResult(_elasticClient.DeleteIndexAsync(_configuration, indexPath, cancellationToken).IsNotNull());
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogWarning("Operation was canceled: {Method} - {IndexPath}", nameof(DeleteAllAsync), indexPath);

            throw new OperationCanceledException($"Elasticsearch DeleteAllAsync operation canceled for {indexPath}", ex, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAllAsync-ElasticsearchService-Exception: {IndexPath}", indexPath);

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithWildcardAsync(PagedAndSortedResultRequestDto input, string searchText, IEnumerable<string> fieldNames, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var fieldSelectors = ToFieldSelectorDictionary();

            var response = await _elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => input.Sorting.IsNullWhiteSpace() ? d : d.Field(f =>
                {
                    foreach (var sortParams in input.Sorting.Split(',').AsEnumerable().Reverse().Where(x => x.IsNotNullWhiteSpace()).Select(x => x.Trim().Split(' ')))
                    {
                        if (sortParams.Length > 0 && sortParams[0].IsNotNullWhiteSpace() && fieldSelectors.TryGetValue(sortParams[0], out var fieldSelector))
                        {
                            _ = f.Field(fieldSelector).MissingLast();
                        }

                        _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                    }

                    return f;
                }))
                .Query(q => q
                    .Bool(b => b
                        .Should(fieldNames.Select(x =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.Wildcard(w => w
                                    .Field(PropertyExpression<TEsIndex>("c", x))
                                    .Value($"*{searchText}*"))
                            )).ToArray()))), cancellationToken);

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithWildcardAsync-ElasticsearchService-Exception: {Input} - {SearchString} - {FieldNames}", input.Serialize(), searchText, fieldNames);

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithPhrasePrefixAsync(PagedAndSortedResultRequestDto input, string searchText, IEnumerable<string> fieldNames, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var fieldSelectors = ToFieldSelectorDictionary();

            var response = await _elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => input.Sorting.IsNullWhiteSpace() ? d : d.Field(f =>
                {
                    foreach (var sortParams in input.Sorting.Split(',').AsEnumerable().Reverse().Where(x => x.IsNotNullWhiteSpace()).Select(x => x.Trim().Split(' ')))
                    {
                        if (sortParams.Length > 0 && sortParams[0].IsNotNullWhiteSpace() && fieldSelectors.TryGetValue(sortParams[0], out var fieldSelector))
                        {
                            _ = f.Field(fieldSelector).MissingLast();
                        }

                        _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                    }

                    return f;
                }))
                .Query(q => q
                    .Bool(b => b
                        .Should(fieldNames.Select(x =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.MatchPhrasePrefix(m => m
                                    .Field(PropertyExpression<TEsIndex>("c", x))
                                    .Query(searchText))
                            )).ToArray()))), cancellationToken);

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithPhrasePrefixAsync-ElasticsearchService-Exception: {Input} - {SearchString} - {FieldNames}", input.Serialize(), searchText, fieldNames);

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithExactPhraseAsync(PagedAndSortedResultRequestDto input, string searchText, IEnumerable<string> fieldNames, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var fieldSelectors = ToFieldSelectorDictionary();

            var response = await _elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => input.Sorting.IsNullWhiteSpace() ? d : d.Field(f =>
                {
                    foreach (var sortParams in input.Sorting.Split(',').AsEnumerable().Reverse().Where(x => x.IsNotNullWhiteSpace()).Select(x => x.Trim().Split(' ')))
                    {
                        if (sortParams.Length > 0 && sortParams[0].IsNotNullWhiteSpace() && fieldSelectors.TryGetValue(sortParams[0], out var fieldSelector))
                        {
                            _ = f.Field(fieldSelector).MissingLast();
                        }

                        _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                    }

                    return f;
                }))
                .Query(q => q
                    .Bool(b => b
                        .Should(fieldNames.Select(x =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.MatchPhrase(m => m
                                    .Field(PropertyExpression<TEsIndex>("c", x))
                                    .Query(searchText))
                            )).ToArray()))), cancellationToken);

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithExactPhraseAsync-ElasticsearchService-Exception: {Input} - {SearchWords} - {FieldNames}", input.Serialize(), searchText, fieldNames);

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithKeywordsAsync(PagedAndSortedResultRequestDto input, string searchText, IEnumerable<string> fieldNames, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var fieldSelectors = ToFieldSelectorDictionary();

            var response = await _elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => input.Sorting.IsNullWhiteSpace() ? d : d.Field(f =>
                {
                    foreach (var sortParams in input.Sorting.Split(',').AsEnumerable().Reverse().Where(x => x.IsNotNullWhiteSpace()).Select(x => x.Trim().Split(' ')))
                    {
                        if (sortParams.Length > 0 && sortParams[0].IsNotNullWhiteSpace() && fieldSelectors.TryGetValue(sortParams[0], out var fieldSelector))
                        {
                            _ = f.Field(fieldSelector).MissingLast();
                        }

                        _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                    }

                    return f;
                }))
                .Query(q => q
                    .Bool(b => b
                        .Should(fieldNames.Select(x =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.Match(m => m
                                    .Field(PropertyExpression<TEsIndex>("c", x))
                                    .Query(searchText))
                            )).ToArray()))), cancellationToken);

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchWithKeywordsAsync-ElasticsearchService-Exception: {Input} - {Keyword} - {FieldNames}", input.Serialize(), searchText, fieldNames);

            throw;
        }
    }

    private static Dictionary<string, Expression<Func<TEsIndex, object?>>> ToFieldSelectorDictionary()
    {
        var fieldSelectors = new Dictionary<string, Expression<Func<TEsIndex, object?>>>();

        foreach (var propertyInfo in typeof(TEsIndex).GetProperties(Public | Instance))
        {
            var parameter = Parameter(typeof(TEsIndex), "x");
            var propertyAccess = Property(parameter, propertyInfo);

            fieldSelectors.Add(propertyInfo.Name, Lambda<Func<TEsIndex, object?>>(propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(Guid) ? Call(typeof(SuffixExtensions).GetMethod(nameof(SuffixExtensions.Suffix), new[]
            {
                typeof(object),
                typeof(string)
            })!, Convert(propertyAccess, typeof(object)), Constant("keyword")) : Convert(propertyAccess, typeof(object)), parameter));
        }

        return fieldSelectors;
    }
}
