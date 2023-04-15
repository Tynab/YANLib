using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YANLib.Dtos;
using static System.Guid;
using static System.Threading.Tasks.ValueTask;
using static YANLib.YANBool;
using static YANLib.YANNum;
using static YANLib.YANText;

namespace YANLib.Services;

public class YANJsonService : YANLibAppService, IYANJsonService
{
    // Serialize
    public async ValueTask<string> Serializes(List<JsonTestDto> requests) => await FromResult(requests.Serialize());

    // Serialize camel case
    public async ValueTask<string> CamelSerializes(List<JsonTestDto> requests) => await FromResult(requests.SerializeCamel());

    // Deserialize
    public async ValueTask<List<JsonTestDto>> Deserializes(byte quantity) => quantity == 0 ? default : await FromResult(ModData(quantity).Clean().ToList());

    // Generate data
    private static IEnumerable<string> GenData(byte quantity)
    {
        for (var i = 0; i < quantity; i++)
        {
            yield return i % 2 == 0
                ? new JsonTestDto
                {
                    Id = NewGuid(),
                    Name = $"nguyễn văn {GenerateRandomCharacter()}".ToTitle(),
                    Income = GenerateRandomUshort(),
                    IsRisk = GenerateRandomBool()
                }.SerializeCamel()
                : new JsonTestDto
                {
                    Id = NewGuid(),
                    Name = $"đoàn thị {GenerateRandomCharacter()}".ToTitle(),
                    Income = GenerateRandomUshort(),
                    IsRisk = GenerateRandomBool()
                }.Serialize();
        }
    }

    // Modified data
    private static IEnumerable<JsonTestDto> ModData(byte quantity)
    {
        foreach (var dto in GenData(quantity).DeserializeDuo<JsonTestDto>())
        {
            dto.Income *= 1000;
            yield return dto;
        }
    }
}
