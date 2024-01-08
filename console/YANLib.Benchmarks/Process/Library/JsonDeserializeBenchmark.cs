using YANLib.Benchmarks.Models;

namespace YANLib.Benchmarks.Process.Library;

public class JsonDeserializeBenchmark
{
    private string? _json;

    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup() => _json = new SampleModel
    {
        Id = NewGuid()
    }.Serialize();

    [Benchmark(Baseline = true)]
    public void YANLib_Json() => For(0, Size, index => _json!.Deserialize<SampleModel>());

    [Benchmark]
    public void Newtonsoft_Json() => For(0, Size, index => DeserializeObject<SampleModel>(_json!));
}
