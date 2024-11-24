using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nest;
using NUglify.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Core;
using YANLib.Utilities;
using static System.Linq.Expressions.Expression;
using static System.Threading.Tasks.Task;
using static System.Math;
using YANLib.EsIndices;
using YANLib.Responses;
using static System.Reflection.BindingFlags;
using static Nest.SuffixExtensions;
using static Nest.SortOrder;
using System.Xml.Linq;
using static YANLib.Core.YANExpression;

namespace YANLib.EsServices;

public class EsService<TEsIndex>(ILogger<EsService<TEsIndex>> logger, IElasticClient elasticClient, IConfiguration configuration) : YANLibAppService, IEsService<TEsIndex> where TEsIndex : YANLibApplicationEsIndex
{
    private readonly ILogger<EsService<TEsIndex>> _logger = logger;
    private readonly IElasticClient _elasticClient = elasticClient;
    private readonly IConfiguration _configuration = configuration;

    public async ValueTask<PagedResultDto<TEsIndex>> GetAll(PagedAndSortedResultRequestDto input)
    {
        try
        {
            var fieldSelectors = ToFieldSelectorDictionary();
            var response = await _elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => d
                    .Field(f =>
                    {
                        input.Sorting?.Split(',').Reverse().ForEach(x =>
                        {
                            var sortParams = x.Trim().Split(' ');

                            if (sortParams.Length > 0 && sortParams[0].IsNotWhiteSpaceAndNull() && fieldSelectors.TryGetValue(sortParams[0], out var fieldSelector))
                            {
                                _ = f.Field(fieldSelector).MissingLast();
                            }

                            _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                        });

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

    public async ValueTask<TEsIndex?> Get(string id)
    {
        try
        {
            return (await _elasticClient.GetAsync<TEsIndex>(id)).Source ?? default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Get-EsService-Exception: {Id}", id);

            throw;
        }
    }

    public async ValueTask<bool> Set(TEsIndex data)
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

    public async ValueTask<bool> SetBulk(List<TEsIndex> datas, string indexPath)
    {
        try
        {
            var index = _configuration.GetSection(indexPath)?.Value;

            if (index.IsWhiteSpaceOrNull())
            {
                return false;
            }

            var requests = new BulkDescriptor();

            datas.OrderBy(x => x.CreatedAt).ForEach(data => requests.Index<TEsIndex>(x => x.Document(data).Index(index)));

            return (await _elasticClient.BulkAsync(requests)).IsNotNull();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetBulk-EsService-Exception: {Datas} - {IndexPath}", datas.Serialize(), indexPath);

            throw;
        }
    }

    public async ValueTask<bool> Delete(string id)
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

    public async ValueTask<bool> DeleteAll(string indexPath)
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

    public async ValueTask<PagedResultDto<TEsIndex>> GetByKeywords(PagedAndSortedResultRequestDto input, string keyword, params string[] fieldNames)
    {
        try
        {
            var fieldSelectors = ToFieldSelectorDictionary();
            var response = await _elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => d
                    .Field(f =>
                    {
                        input.Sorting?.Split(',').Reverse().ForEach(x =>
                        {
                            var sortParams = x.Trim().Split(' ');

                            if (sortParams.Length > 0 && sortParams[0].IsNotWhiteSpaceAndNull() && fieldSelectors.TryGetValue(sortParams[0], out var fieldSelector))
                            {
                                _ = f.Field(fieldSelector).MissingLast();
                            }

                            _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                        });

                        return f;
                    }))
                .Query(q => q
                    .Bool(b => b
                        .Should(fieldNames.Select(x =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.Match(m => m
                                    .Field(PropertyExpression<TEsIndex>("c", x))
                                    .Query(keyword))
                            )).ToArray()))));

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByKeywords-EsService-Exception: {Input} - {Keyword} - {FieldNames}", input.Serialize(), keyword, fieldNames);

            throw;
        }
    }

    public async ValueTask<PagedResultDto<TEsIndex>> SearchKeywordsByString(PagedAndSortedResultRequestDto input, string searchString, params string[] fieldNames)
    {
        try
        {
            var fieldSelectors = ToFieldSelectorDictionary();
            var response = await _elasticClient.SearchAsync<TEsIndex>(s => s
                .From(input.SkipCount)
                .Size(input.MaxResultCount)
                .Sort(d => d
                    .Field(f =>
                    {
                        input.Sorting?.Split(',').Reverse().ForEach(x =>
                        {
                            var sortParams = x.Trim().Split(' ');

                            if (sortParams.Length > 0 && sortParams[0].IsNotWhiteSpaceAndNull() && fieldSelectors.TryGetValue(sortParams[0], out var fieldSelector))
                            {
                                _ = f.Field(fieldSelector).MissingLast();
                            }

                            _ = sortParams.Length > 1 && sortParams[1].ToEnum<SortOrder>() is Descending ? f.Descending() : f.Ascending();
                        });

                        return f;
                    }))
                .Query(q => q
                    .Bool(b => b
                        .Should(fieldNames.Select(x =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.Wildcard(w => w
                                    .Field(PropertyExpression<TEsIndex>("c", x))
                                    .Value($"*{searchString}*"))
                            )).ToArray()))));

            return new PagedResultDto<TEsIndex>(Max(0, response.Total), [.. response.Documents]);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchKeywordsByString-EsService-Exception: {Input} - {SearchString} - {FieldNames}", input.Serialize(), searchString, fieldNames);

            throw;
        }
    }

    public async ValueTask<IReadOnlyCollection<TEsIndex>> SearchTextsByString(string searchString, params string[] fieldNames)
    {
        try
        {
            return (await _elasticClient.SearchAsync<TEsIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Should(fieldNames.Select(x =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.MatchPhrasePrefix(m => m
                                    .Field(PropertyExpression<TEsIndex>("c", x))
                                    .Query(searchString))
                            )).ToArray()))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchTextsByString-EsService-Exception: {SearchString} - {FieldNames}", searchString, fieldNames);

            throw;
        }
    }

    public async ValueTask<IReadOnlyCollection<TEsIndex>> SearchTextsByWords(string searchWords, params string[] fieldNames)
    {
        try
        {
            return (await _elasticClient.SearchAsync<TEsIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Should(fieldNames.Select(x =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.MatchPhrase(m => m
                                    .Field(PropertyExpression<TEsIndex>("c", x))
                                    .Query(searchWords))
                            )).ToArray()))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchTextsByWords-EsService-Exception: {SearchWords} - {FieldNames}", searchWords, fieldNames);

            throw;
        }
    }

    private static Dictionary<string, Expression<Func<TEsIndex, object?>>> ToFieldSelectorDictionary()
    {
        var fieldSelectors = new Dictionary<string, Expression<Func<TEsIndex, object?>>>();

        typeof(TEsIndex).GetProperties(Public | Instance).ForEach(x =>
        {
            var parameter = Parameter(typeof(TEsIndex), "x");
            var propertyAccess = Property(parameter, x);

            fieldSelectors.Add(x.Name, Lambda<Func<TEsIndex, object?>>(x.PropertyType == typeof(string) || x.PropertyType == typeof(Guid) ? Call(typeof(SuffixExtensions).GetMethod(nameof(SuffixExtensions.Suffix), new[]
            {
                typeof(object),
                typeof(string)
            })!, Convert(propertyAccess, typeof(object)), Constant("keyword")) : Convert(propertyAccess, typeof(object)), parameter));
        });

        return fieldSelectors;
    }
}
