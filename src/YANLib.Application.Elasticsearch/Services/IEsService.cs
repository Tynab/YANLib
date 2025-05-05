using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace YANLib.Services;

public interface IEsService<TEsIndex> where TEsIndex : YANLibApplicationEsIndex<DocumentPath<TEsIndex>>
{
    public ValueTask<PagedResultDto<TEsIndex>> GetAll(PagedAndSortedResultRequestDto input);

    public ValueTask<TEsIndex?> Get(DocumentPath<TEsIndex> id);

    public ValueTask<bool> Set(TEsIndex data);

    public ValueTask<bool> SetBulk(List<TEsIndex> datas, string indexPath);

    public ValueTask<bool> Delete(DocumentPath<TEsIndex> id);

    public ValueTask<bool> DeleteAll(string indexPath);

    public ValueTask<PagedResultDto<TEsIndex>> SearchWithWildcard(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames);

    public ValueTask<PagedResultDto<TEsIndex>> SearchWithPhrasePrefix(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames);

    public ValueTask<PagedResultDto<TEsIndex>> SearchWithExactPhrase(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames);

    public ValueTask<PagedResultDto<TEsIndex>> SearchWithKeywords(PagedAndSortedResultRequestDto input, string searchText, params string[] fieldNames);
}
