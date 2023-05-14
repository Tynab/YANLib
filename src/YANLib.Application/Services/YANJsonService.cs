using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Json;
using YANLib.Dtos;
using static System.Guid;
using static System.Threading.Tasks.Task;

namespace YANLib.Services;

public class YANJsonService : YANLibAppService, IYANJsonService
{
    private readonly IJsonSerializer _jsonSerializer;

    public YANJsonService(IJsonSerializer jsonSerializer) => _jsonSerializer = jsonSerializer;

    public async ValueTask<string> YanVsStandards(uint quantity, bool hideSystem)
    {
        var json = new JsonDto
        {
            Id = NewGuid()
        }.Serialize();
        var jsonCamel = new JsonDto
        {
            Id = NewGuid()
        }.CamelSerialize();
        var newtonsoftTask = Run(() =>
        {
            var sw = new Stopwatch();
            sw.Start();
            var first = string.Empty;
            var last = string.Empty;
            for (var i = 0; i < quantity; i++)
            {
                var dto = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonDto>(i is 0 ? json : jsonCamel);
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
                var dto = (JsonDto)_jsonSerializer.Deserialize(typeof(JsonDto), i is 0 ? json : jsonCamel);
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
                var dto = (i is 0 ? json : jsonCamel).Deserialize<JsonDto>();
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
                    var dto = JsonSerializer.Deserialize<JsonDto>(i is 0 ? json : jsonCamel);
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
                    var dto = JsonSerializer.Deserialize<JsonDto>(i is 0 ? json : jsonCamel, new JsonSerializerOptions
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
            return $"Newtonsoft:\t\t{newtonsoftTask.Result}\nVolo.Abp:\t\t{voloTask.Result}\nSystem.Text:\t\t{textTask.Result}\nSystem.Text (option):\t{textOptTask.Result}\nYANLib:\t\t\t{yanTask.Result}";
        }
        else
        {
            _ = await WhenAll(newtonsoftTask, voloTask, yanTask);
            return $"Newtonsoft:\t{newtonsoftTask.Result}\nVolo.Abp:\t{voloTask.Result}\nYANLib:\t\t{yanTask.Result}";
        }
    }
}
