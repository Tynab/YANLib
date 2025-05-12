using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace YANLib.Services;

public interface IEsService<TEsIndex> where TEsIndex : YANLibApplicationEsIndex<DocumentPath<TEsIndex>>
{
    public Task<PagedResultDto<TEsIndex>> GetAll(PagedAndSortedResultRequestDto input);

    public Task<TEsIndex?> Get(DocumentPath<TEsIndex> id);

    public Task<bool> Set(TEsIndex data);

    public Task<bool> SetBulk(List<TEsIndex> datas, string indexPath);

    public Task<bool> Delete(DocumentPath<TEsIndex> id);

    public Task<bool> DeleteAll(string indexPath);

    public Task<PagedResultDto<TEsIndex>> SearchWithWildcard(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames);

    public Task<PagedResultDto<TEsIndex>> SearchWithPhrasePrefix(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames);

    public Task<PagedResultDto<TEsIndex>> SearchWithExactPhrase(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames);

    public Task<PagedResultDto<TEsIndex>> SearchWithKeywords(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames);
}
