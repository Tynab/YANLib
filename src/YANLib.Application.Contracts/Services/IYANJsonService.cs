using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Dtos;

namespace YANLib.Services;

public interface IYANJsonService : IApplicationService
{
    public ValueTask<string> Serialize(JsonDto request);
    public ValueTask<string> SerializeCamel(JsonDto request);
    public ValueTask<List<JsonDto>> Deserialize(byte quantity);
}
