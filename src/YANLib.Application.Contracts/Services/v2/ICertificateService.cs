using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;

namespace YANLib.Services.v2;

public interface ICertificateService
{
    public ValueTask<PagedResultDto<CertificateResponse>> GetAll(PagedAndSortedResultRequestDto input);

    public ValueTask<CertificateResponse?> Get(string id);

    public ValueTask<CertificateResponse?> Insert(CertificateCreateRequest request);

    public ValueTask<CertificateResponse?> Modify(string id, CertificateUpdateRequest dto);

    public ValueTask<bool> Delete(string id, Guid updatedBy);

    public ValueTask<bool> SyncDbToEs();

    public ValueTask<PagedResultDto<CertificateResponse>> SearchWithWildcard(PagedAndSortedResultRequestDto input, string searchText);

    public ValueTask<PagedResultDto<CertificateResponse>> SearchWithPhrasePrefix(PagedAndSortedResultRequestDto input, string searchText);

    public ValueTask<PagedResultDto<CertificateResponse>> SearchWithExactPhrase(PagedAndSortedResultRequestDto input, string searchText);

    public ValueTask<PagedResultDto<CertificateResponse>> SearchWithKeywords(PagedAndSortedResultRequestDto input, string searchText);
}
