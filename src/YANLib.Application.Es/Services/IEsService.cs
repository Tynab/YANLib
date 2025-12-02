using System.Linq.Expressions;
using Volo.Abp.Application.Dtos;

namespace YANLib.Services;

public interface IEsService<TEsIndex, TId> where TEsIndex : BaseEsIndex<TId>
{
    public Task<PagedResultDto<TEsIndex>> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default);

    public Task<TEsIndex?> GetAsync(TId id, CancellationToken cancellationToken = default);

    public Task<bool> SetAsync(TEsIndex data, CancellationToken cancellationToken = default);

    public Task<bool> SetBulkAsync(List<TEsIndex> datas, string indexPath, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAllAsync(string indexPath, CancellationToken cancellationToken = default);

    public Task<List<TEsIndex>> GetByFieldAsync(Dictionary<string, object?> dict, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<TEsIndex>> GetByFieldAsync(PagedAndSortedResultRequestDto input, Dictionary<string, object?> dict, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<TEsIndex>> SearchWithWildcardAsync(
        PagedAndSortedResultRequestDto input,
        string? searchText,
        IEnumerable<string> fieldNames,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        Expression<Func<TEsIndex, object?>>? dateFieldSelector = null,
        bool isActive = false,
        IDictionary<string, object>? filters = null,
        CancellationToken cancellationToken = default
    );

    public Task<PagedResultDto<TEsIndex>> SearchWithPhrasePrefixAsync(
        PagedAndSortedResultRequestDto input,
        string? searchText,
        IEnumerable<string> fieldNames,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        Expression<Func<TEsIndex, object?>>? dateFieldSelector = null,
        bool isActive = false,
        IDictionary<string, object>? filters = null,
        CancellationToken cancellationToken = default
    );

    public Task<PagedResultDto<TEsIndex>> SearchWithExactPhraseAsync(
        PagedAndSortedResultRequestDto input,
        string? searchText,
        IEnumerable<string> fieldNames,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        Expression<Func<TEsIndex, object?>>? dateFieldSelector = null,
        bool isActive = false,
        IDictionary<string, object>? filters = null,
        CancellationToken cancellationToken = default
    );

    public Task<PagedResultDto<TEsIndex>> SearchWithKeywordsAsync(
        PagedAndSortedResultRequestDto input,
        string? searchText,
        IEnumerable<string> fieldNames,
        DateTime? dateFrom = null,
        DateTime? dateTo = null,
        Expression<Func<TEsIndex, object?>>? dateFieldSelector = null,
        bool isActive = false,
        IDictionary<string, object>? filters = null,
        CancellationToken cancellationToken = default
    );
}
