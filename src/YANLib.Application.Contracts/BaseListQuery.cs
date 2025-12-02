using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using static Nest.SortOrder;

namespace YANLib;

public class BaseListQuery
{
    [Range(1, 100)]
    [DefaultValue(1)]
    public int PageNumber { get; set; } = 1;

    [Range(1, 500)]
    [DefaultValue(10)]
    public int PageSize { get; set; } = 10;

    public string? SortField { get; set; } = null;

    public bool? SortDescending { get; set; } = null;

    public string? Sorting { get; set; } = string.Empty;

    public string? Search { get; set; }

    public PagedAndSortedResultRequestDto PagedAndSortedDto() => new()
    {
        SkipCount = (PageNumber - 1) * PageSize,
        MaxResultCount = PageSize,
        Sorting = SortField.IsNotNullWhiteSpace() && SortDescending.HasValue ? $"{SortField} {(SortDescending.Value ? Descending : Ascending)}" : Sorting.IsNotNullWhiteSpace() ? Sorting : string.Empty
    };
}
