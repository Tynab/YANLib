using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Responses;

namespace YANLib.Services;

public interface IYANJsonService : IApplicationService
{
    public ValueTask<string> YanVsStandards(uint quantity, bool hideSystem);

    public ValueTask<string> JsonSerialize(Guid id);

    public ValueTask<string> JsonSerializeOptionalName(Guid idOptionalName);

    public ValueTask<JsonResponse> JsonDeserialize(string json);

    public ValueTask<JsonOptionalNameResponse> JsonDeserializeOptionalName(string json);
}
