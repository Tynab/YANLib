using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Json;
using YANLib.Core;
using YANLib.Responses;
using static Newtonsoft.Json.JsonConvert;
using static System.Guid;
using static System.Text.Json.JsonSerializer;
using static System.Threading.Tasks.Task;

namespace YANLib.Services;

public class YANJsonService(
    IJsonSerializer jsonSerializer
) : YANLibAppService, IYANJsonService
{
    private readonly IJsonSerializer _jsonSerializer = jsonSerializer;

    public async ValueTask<string> YanVsStandards(uint quantity, bool hideSystem)
    {
        var json = new JsonResponse
        {
            Id = NewGuid()
        }.StandardSerialize();

        var jsonCamel = new JsonResponse
        {
            Id = NewGuid()
        }.Serialize();

        var newtonsoftTask = Run(() =>
        {
            var sw = new Stopwatch();

            sw.Start();

            var first = string.Empty;
            var last = string.Empty;

            for (var i = 0; i < quantity; i++)
            {
                var dto = DeserializeObject<JsonResponse>(i is 0 ? json : jsonCamel);

                first = i is 0 ? dto.Id.ToString().Replace("-", string.Empty) : first;
                last = i == quantity - 1 ? dto.Id.ToString().Replace("-", string.Empty) : last;
            }

            sw.Stop();

            return $"[{first} - {last}] {sw.Elapsed.TotalMilliseconds} ms";
        });

        var voloTask = Run(() =>
        {
            var sw = new Stopwatch();

            sw.Start();

            var first = string.Empty;
            var last = string.Empty;

            for (var i = 0; i < quantity; i++)
            {
                var dto = (JsonResponse)_jsonSerializer.Deserialize(typeof(JsonResponse), i is 0 ? json : jsonCamel);

                first = i is 0 ? dto.Id.ToString().Replace("-", string.Empty) : first;
                last = i == quantity - 1 ? dto.Id.ToString().Replace("-", string.Empty) : last;
            }

            sw.Stop();

            return $"[{first} - {last}] {sw.Elapsed.TotalMilliseconds} ms";
        });

        var yanTask = Run(() =>
        {
            var sw = new Stopwatch();

            sw.Start();

            var first = string.Empty;
            var last = string.Empty;

            for (var i = 0; i < quantity; i++)
            {
                var dto = (i is 0 ? json : jsonCamel).Deserialize<JsonResponse>();

                first = i is 0 ? dto.Id.ToString().Replace("-", string.Empty) : first;
                last = i == quantity - 1 ? dto.Id.ToString().Replace("-", string.Empty) : last;
            }

            sw.Stop();

            return $"[{first} - {last}] {sw.Elapsed.TotalMilliseconds} ms";
        });

        if (!hideSystem)
        {
            var textTask = Run(() =>
            {
                var sw = new Stopwatch();

                sw.Start();

                var first = string.Empty;
                var last = string.Empty;

                for (var i = 0; i < quantity; i++)
                {
                    var dto = Deserialize<JsonResponse>(i is 0 ? json : jsonCamel);

                    first = i is 0 ? dto.Id.ToString().Replace("-", string.Empty) : first;
                    last = i == quantity - 1 ? dto.Id.ToString().Replace("-", string.Empty) : last;
                }

                sw.Stop();

                return $"[{first} - {last}] {sw.Elapsed.TotalMilliseconds} ms";
            });

            var textOptTask = Run(() =>
            {
                var sw = new Stopwatch();

                sw.Start();

                var first = string.Empty;
                var last = string.Empty;

                for (var i = 0; i < quantity; i++)
                {
                    var dto = Deserialize<JsonResponse>(i is 0 ? json : jsonCamel, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    first = i is 0 ? dto.Id.ToString().Replace("-", string.Empty) : first;
                    last = i == quantity - 1 ? dto.Id.ToString().Replace("-", string.Empty) : last;
                }

                sw.Stop();

                return $"[{first} - {last}] {sw.Elapsed.TotalMilliseconds} ms";
            });

            _ = await WhenAll(newtonsoftTask, voloTask, textTask, textOptTask, yanTask);

            return $"Newtonsoft 13.0.3:\t{newtonsoftTask.Result}\nVolo.Abp 6.0.3:\t\t{voloTask.Result}\nSystem.Text:\t\t{textTask.Result}\nSystem.Text (option):\t{textOptTask.Result}\nYANLib:\t\t\t{yanTask.Result}";
        }
        else
        {
            _ = await WhenAll(newtonsoftTask, voloTask, yanTask);

            return $"Newtonsoft 13.0.3:\t{newtonsoftTask.Result}\nVolo.Abp 6.0.3:\t\t{voloTask.Result}\nYANLib:\t\t\t{yanTask.Result}";
        }
    }

    public ValueTask<string> JsonSerialize(Guid id) => ValueTask.FromResult(new JsonResponse
    {
        Id = id
    }.StandardSerialize());

    public ValueTask<string> JsonSerializeOptionalName(Guid idOptionalName) => ValueTask.FromResult(new JsonOptionalNameResponse
    {
        Id = idOptionalName
    }.StandardSerialize());

    public ValueTask<JsonResponse> JsonDeserialize(string json) => ValueTask.FromResult(json.Deserialize<JsonResponse>());

    public ValueTask<JsonOptionalNameResponse> JsonDeserializeOptionalName(string json) => ValueTask.FromResult(json.Deserialize<JsonOptionalNameResponse>());
}
