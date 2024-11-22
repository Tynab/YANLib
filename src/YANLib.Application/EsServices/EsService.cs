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

namespace YANLib.EsServices;

public class EsService<TEsIndex>(ILogger<EsService<TEsIndex>> logger, IElasticClient elasticClient, IConfiguration configuration) : YANLibAppService, IEsService<TEsIndex> where TEsIndex : YANLibApplicationEsIndex
{
    private readonly ILogger<EsService<TEsIndex>> _logger = logger;
    private readonly IElasticClient _elasticClient = elasticClient;
    private readonly IConfiguration _configuration = configuration;

    private static Dictionary<string, Expression<Func<TEsIndex, object?>>> CreateFieldSelectors()
    {
        var selectors = new Dictionary<string, Expression<Func<TEsIndex, object?>>>();

        typeof(TEsIndex).GetProperties().ForEach(x =>
        {
            var parameter = Parameter(typeof(TEsIndex), "x");
            var suffix = GetSuffixFromAttribute(x);
            Expression finalExpression = Property(parameter, x.Name);

            if (suffix.IsNotWhiteSpaceAndNull())
            {
                finalExpression = AddSuffixExpression(finalExpression, suffix);
            }

            finalExpression = Convert(finalExpression, typeof(object));
            selectors[x.Name] = Lambda<Func<TEsIndex, object?>>(finalExpression, parameter);
        });

        return selectors;
    }

    private static string? GetSuffixFromAttribute(PropertyInfo property)
    {
        foreach (var attribute in property.GetCustomAttributes())
        {
            var attributeName = attribute.GetType().Name.ToLower();

            if (attributeName.IsNotWhiteSpaceAndNull())
            {
                return attributeName;
            }
        }

        return default;
    }

    private static MethodCallExpression AddSuffixExpression(Expression propertyAccess, string suffix) => Call(propertyAccess, typeof(string).GetMethod("Suffix", [typeof(string)])!, Constant(suffix));

    public async ValueTask<PagedResultDto<TEsIndex>> GetAll(PagedAndSortedResultRequestDto input)
    {
        try
        {
            var fieldSelectors = CreateFieldSelectors();
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

                            _ = sortParams.Length > 1 && sortParams[1].EqualsIgnoreCase("DESC") ? f.Descending() : f.Ascending();
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

    public async ValueTask<IReadOnlyCollection<TEsIndex>> GetByKeywords(string keyword, params string[] fieldNames)
    {
        try
        {
            return (await _elasticClient.SearchAsync<TEsIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Should(fieldNames.Select(fieldName =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.Match(m => m
                                    .Field(fieldName)
                                    .Query(keyword))
                            )).ToArray()))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetByKeywords-EsService-Exception: {Keyword} - {FieldNames}", keyword, fieldNames);

            throw;
        }
    }

    public async ValueTask<IReadOnlyCollection<TEsIndex>> SearchKeywordsByString(string searchString, params string[] fieldNames)
    {
        try
        {
            return (await _elasticClient.SearchAsync<TEsIndex>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Should(fieldNames.Select(fieldName =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.Wildcard(w => w
                                    .Field(fieldName)
                                    .Value($"*{searchString}*"))
                            )).ToArray()))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchKeywordsByString-EsService-Exception: {SearchString} - {FieldNames}", searchString, fieldNames);

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
                        .Should(fieldNames.Select(fieldName =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.MatchPhrasePrefix(m => m
                                    .Field(fieldName)
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
                        .Should(fieldNames.Select(fieldName =>
                            new Func<QueryContainerDescriptor<TEsIndex>, QueryContainer>(d =>
                                d.MatchPhrase(m => m
                                    .Field(fieldName)
                                    .Query(searchWords))
                            )).ToArray()))))).Documents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SearchTextsByWords-EsService-Exception: {SearchWords} - {FieldNames}", searchWords, fieldNames);

            throw;
        }
    }
}
