using BenchmarkDotNet.Attributes;
using static System.Runtime.InteropServices.CollectionsMarshal;
using static YANLib.YANRandom;

namespace YANLib.Benchmarks.Process.Common;

public class LoopBenchmark
{
    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    private readonly List<int> _list = [];

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < Size; i++)
        {
            _list.Add(GenerateRandom<int>(0, Size));
        }
    }

    [Benchmark(Baseline = true)]
    public int For()
    {
        var sum = 0;

        for (var i = 0; i < _list.Count; i++)
        {
            sum += _list[i];
        }

        return sum;
    }

    [Benchmark]
    public int Foreach()
    {
        var sum = 0;

        foreach (var item in _list)
        {
            sum += item;
        }

        return sum;
    }

    [Benchmark]
    public int ForeachList()
    {
        var sum = 0;

        _list.ForEach(x => sum += x);

        return sum;
    }

    [Benchmark]
    public int ForeachSpan()
    {
        var sum = 0;
        var span = AsSpan(_list);

        foreach (var item in span)
        {
            sum += item;
        }

        return sum;
    }
}
