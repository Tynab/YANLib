﻿using Nest;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace YANLib.Services;

public interface IElasticsearchService<TEsIndex> where TEsIndex : YANLibApplicationEsIndex<DocumentPath<TEsIndex>>
{
    public Task<PagedResultDto<TEsIndex>> GetAllAsync(PagedAndSortedResultRequestDto input, CancellationToken cancellationToken = default);

    public Task<TEsIndex?> GetAsync(DocumentPath<TEsIndex> id, CancellationToken cancellationToken = default);

    public Task<bool> SetAsync(TEsIndex data, CancellationToken cancellationToken = default);

    public Task<bool> SetBulkAsync(List<TEsIndex> datas, string indexPath, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(DocumentPath<TEsIndex> id, CancellationToken cancellationToken = default);

    public Task<bool> DeleteAllAsync(string indexPath, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<TEsIndex>> SearchWithWildcardAsync(PagedAndSortedResultRequestDto input, string searchText, IEnumerable<string> fieldNames, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<TEsIndex>> SearchWithPhrasePrefixAsync(PagedAndSortedResultRequestDto input, string searchText, IEnumerable<string> fieldNames, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<TEsIndex>> SearchWithExactPhraseAsync(PagedAndSortedResultRequestDto input, string searchText, IEnumerable<string> fieldNames, CancellationToken cancellationToken = default);

    public Task<PagedResultDto<TEsIndex>> SearchWithKeywordsAsync(PagedAndSortedResultRequestDto input, string searchText, IEnumerable<string> fieldNames, CancellationToken cancellationToken = default);
}
