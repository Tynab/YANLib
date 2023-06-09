using BenchmarkDotNet.Attributes;
using YANLib.Benchmarks.Models;
using static Newtonsoft.Json.JsonConvert;
using static System.Guid;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Benchmarks.Library;

public class JsonDeserializeBenchmark
{
    private string? _json;

    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup() => _json = new SampleModel
    {
        Id = NewGuid()
    }.CamelSerialize();

    [Benchmark(Baseline = true)]
    public void YANLib_Json() => For(0, Size, index => _json!.Deserialize<SampleModel>());

    [Benchmark]
    public void Newtonsoft_Json() => For(0, Size, index => DeserializeObject<SampleModel>(_json!));
}
