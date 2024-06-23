using BenchmarkDotNet.Attributes;
using static System.Runtime.InteropServices.CollectionsMarshal;

namespace YANLib.Benchmarks.Process.Common;

public class LoopBenchmark
{
    private List<int> _list;

    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _list = new List<int>(Size);

        for (var i = 0; i < Size; i++)
        {
            _list.Add(i);
        }
    }

    [Benchmark(Baseline = true)]
    public void For()
    {
        for (var i = 0; i < _list.Count; i++)
        {
            _ = _list[i];
        }
    }

    [Benchmark]
    public void Foreach()
    {
        foreach (var item in _list)
        {
            _ = item;
        }
    }

    [Benchmark]
    public void Foreach_List() => _list.ForEach(_ => { });

    [Benchmark]
    public void Foreach_Span()
    {
        foreach (var item in AsSpan(_list))
        {
            _ = item;
        }
    }
}
