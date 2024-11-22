using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.EsIndices;

namespace YANLib.EsServices;

public interface IEsService<TEsIndex> where TEsIndex : YANLibApplicationEsIndex
{
    public ValueTask<PagedResultDto<TEsIndex>> GetAll(PagedAndSortedResultRequestDto input);

    public ValueTask<TEsIndex?> Get(string id);

    public ValueTask<bool> Set(TEsIndex data);

    public ValueTask<bool> SetBulk(List<TEsIndex> datas, string indexPath);

    public ValueTask<bool> Delete(string id);

    public ValueTask<bool> DeleteAll(string indexPath);

    public ValueTask<IReadOnlyCollection<TEsIndex>> GetByKeywords(string keyword, params string[] fieldNames);

    public ValueTask<IReadOnlyCollection<TEsIndex>> SearchKeywordsByString(string searchString, params string[] fieldNames);

    public ValueTask<IReadOnlyCollection<TEsIndex>> SearchTextsByString(string searchString, params string[] fieldNames);

    public ValueTask<IReadOnlyCollection<TEsIndex>> SearchTextsByWords(string searchWords, params string[] fieldNames);
}
