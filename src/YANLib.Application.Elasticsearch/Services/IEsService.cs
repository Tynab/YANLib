using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.EsIndices;

namespace YANLib.Services;

public interface IEsService<TEsIndex> where TEsIndex : YANLibApplicationEsIndex
{
    public ValueTask<PagedResultDto<TEsIndex>> GetAll(PagedAndSortedResultRequestDto input);

    public ValueTask<TEsIndex?> Get(string id);

    public ValueTask<bool> Set(TEsIndex data);

    public ValueTask<bool> SetBulk(List<TEsIndex> datas, string indexPath);

    public ValueTask<bool> Delete(string id);

    public ValueTask<bool> DeleteAll(string indexPath);

    public ValueTask<PagedResultDto<TEsIndex>> SearchWithWildcard(PagedAndSortedResultRequestDto input, string searchString, params string[] fieldNames);

    public ValueTask<PagedResultDto<TEsIndex>> SearchWithPhrasePrefix(PagedAndSortedResultRequestDto input, string searchString, params string[] fieldNames);

    public ValueTask<PagedResultDto<TEsIndex>> SearchWithExactPhrase(PagedAndSortedResultRequestDto input, string searchWords, params string[] fieldNames);

    public ValueTask<PagedResultDto<TEsIndex>> SearchWithKeywords(PagedAndSortedResultRequestDto input, string keyword, params string[] fieldNames);
}
