using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YANLib.Dtos;
using static System.Threading.Tasks.ValueTask;
using static YANLib.YANBool;
using static YANLib.YANNum;
using static YANLib.YANText;

namespace YANLib.Services;

public class YANJsonService : YANLibAppService, IYANJsonService
{
    // Serialize
    public async ValueTask<string> Serialize(JsonDto request) => await FromResult(request.Serialize());

    // Serialize camel case
    public async ValueTask<string> SerializeCamel(JsonDto request) => await FromResult(request.SerializeCamel());

    // Deserialize
    public async ValueTask<List<JsonDto>> Deserialize(byte quantity) => quantity == 0 ? default : await FromResult(GenData(quantity).DeserializeStandard<JsonDto>().Clean().ToList());

    // Generate data
    private static IEnumerable<string> GenData(byte quantity)
    {
        for (var i = 0; i < quantity; i++)
        {
            yield return new JsonDto
            {
                Id = Guid.NewGuid(),
                Name = $"Nguyễn Văn {GenerateRandomCharacter()}".ToTitle(),
                Income = GenerateRandomUint(),
                IsRisk = GenerateRandomBool()
            }.SerializeCamel();
        }
    }
}
