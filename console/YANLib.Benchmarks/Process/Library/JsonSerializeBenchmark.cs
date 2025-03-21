using BenchmarkDotNet.Attributes;
using YANLib.Benchmarks.Models;
using static Newtonsoft.Json.JsonConvert;
using static System.Guid;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Benchmarks.Process.Library;

public class JsonSerializeBenchmark
{
    private SampleClass? _model;

    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup() => _model = new SampleClass
    {
        Id = NewGuid()
    };

    [Benchmark(Baseline = true)]
    public void YANLib_Json() => For(0, Size, index => _model.StandardSerialize());

    [Benchmark]
    public void Newtonsoft_Json() => For(0, Size, index => SerializeObject(_model));
}
