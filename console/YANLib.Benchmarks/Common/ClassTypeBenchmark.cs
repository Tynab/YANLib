using BenchmarkDotNet.Attributes;
using YANLib.Benchmarks.Models;
using static System.Guid;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Benchmarks.Common;

public class ClassTypeBenchmark
{
    private SampleModel? _class;
    private SampleSealed? _sealed;
    private SampleRecord? _record;

    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _class = new SampleModel
        {
            Id = NewGuid()
        };
        _sealed = new SampleSealed
        {
            Id = NewGuid()
        };
        _record = new SampleRecord
        {
            Id = NewGuid()
        };
    }

    [Benchmark(Baseline = true)]
    public void Class() => For(0, Size, index => _ = new SampleModel
    {
        Id = _class!.Id
    });

    [Benchmark]
    public void Sealed() => For(0, Size, index => _ = new SampleSealed
    {
        Id = _sealed!.Id
    });

    [Benchmark]
    public void Record() => For(0, Size, index => _ = _record! with { });
}
