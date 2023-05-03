using System.Diagnostics;
using System.Threading.Tasks;
using YANLib.Dtos;
using static System.Guid;
using static System.Threading.Tasks.Task;

namespace YANLib.Services;

public class YANJsonService : YANLibAppService, IYANJsonService
{
    public async ValueTask<string> DuoVsStandard(uint quantity)
    {
        var json = new JsonDto
        {
            Id = NewGuid()
        }.Serialize();
        var duoTask = Run(() =>
        {
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < quantity; i++)
            {
                _ = json.DeserializeDuo<JsonDto>();
            }
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        });
        var stdTask = Run(() =>
        {
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < quantity; i++)
            {
                _ = json.DeserializeStandard<JsonDto>();
            }
            sw.Stop();
            return sw.Elapsed.TotalMilliseconds;
        });
        _ = await WhenAll(duoTask, stdTask);
        return $"Standard: {stdTask.Result}\nDuo: {duoTask.Result}";
    }
}
