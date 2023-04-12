using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Dtos;

namespace YANLib.Services;

public interface IYANJsonService : IApplicationService
{
    public ValueTask<string> Serializes(List<JsonTestDto> requests);
    public ValueTask<string> CamelSerializes(List<JsonTestDto> requests);
    public ValueTask<List<JsonTestDto>> Deserializes(byte quantity);
}
