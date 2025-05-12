using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using static Nest.SortOrder;
using static System.Linq.Expressions.Expression;
using static System.Math;
using static System.Reflection.BindingFlags;
using static System.Threading.Tasks.Task;
using static YANLib.YANExpression;

namespace YANLib.Services.Implements;

public class EsService<TEsIndex>(ILogger<EsService<TEsIndex>> logger, IElasticClient elasticClient, IConfiguration configuration) : IEsService<TEsIndex> where TEsIndex : YANLibApplicationEsIndex<DocumentPath<TEsIndex>>
{
    private readonly ILogger<EsService<TEsIndex>> _logger = logger;
    private readonly IElasticClient _elasticClient = elasticClient;
    private readonly IConfiguration _configuration = configuration;

    public async Task<PagedResultDto<TEsIndex>> GetAll(PagedAndSortedResultRequestDto input)
    {
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
                .Query(q => q.MatchAll())
            );

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAll-EsService-Exception with paging");

            throw;
        }
    }

    public async Task<TEsIndex?> Get(DocumentPath<TEsIndex> id)
    {
        try
        {
            return (await _elasticClient.GetAsync(id)).Source ?? default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get-EsService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<bool> Set(TEsIndex data)
    {
        try
        {
            return (await _elasticClient.IndexDocumentAsync(data)).IsNotNull();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Set-EsService-Exception: {Data}", data.Serialize());

            throw;
        }
    }

    public async Task<bool> SetBulk(List<TEsIndex> datas, string indexPath)
    {
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
                _ = requests.Index<TEsIndex>(x => x.Document(data).Index(index));
            }

            return (await _elasticClient.BulkAsync(requests)).IsNotNull();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetBulk-EsService-Exception: {Datas} - {IndexPath}", datas.Serialize(), indexPath);

            throw;
        }
    }

    public async Task<bool> Delete(DocumentPath<TEsIndex> id)
    {
        try
        {
            return (await _elasticClient.DeleteAsync<TEsIndex>(id)).IsNotNull();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Delete-EsService-Exception: {Id}", id);

            throw;
        }
    }

    public async Task<bool> DeleteAll(string indexPath)
    {
        try
        {
            return await FromResult(_elasticClient.DeleteIndex(_configuration, indexPath).IsNotNull());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "DeleteAll-EsService-Exception: {IndexPath}", indexPath);

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithWildcard(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames)
    {
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
                            )).ToArray()))));

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchKeywordsByString-EsService-Exception: {Input} - {SearchString} - {FieldNames}", input.Serialize(), searchText, fieldNames);

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithPhrasePrefix(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames)
    {
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
                            )).ToArray()))));

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchTextsByString-EsService-Exception: {Input} - {SearchString} - {FieldNames}", input.Serialize(), searchText, fieldNames);

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithExactPhrase(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames)
    {
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
                            )).ToArray()))));

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchTextsByWords-EsService-Exception: {Input} - {SearchWords} - {FieldNames}", input.Serialize(), searchText, fieldNames);

            throw;
        }
    }

    public async Task<PagedResultDto<TEsIndex>> SearchWithKeywords(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames)
    {
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
                            )).ToArray()))));

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByKeywords-EsService-Exception: {Input} - {Keyword} - {FieldNames}", input.Serialize(), searchText, fieldNames);

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
