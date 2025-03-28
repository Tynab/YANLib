using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using YANLib.Object;
using static System.Collections.Immutable.ImmutableList;
using static System.Linq.Enumerable;

namespace YANLib.Benchmarks.Process.Library;

public class CountBenchmark
{
    public int Size { get; set; } = 1_000;

    private IEnumerable<int>? _list = default;
    private IReadOnlyCollection<int>? _readOnly = default;
    private IImmutableList<int>? _immutableList = default;
    private ConcurrentBag<int>? _concurrentBag = default;

    [GlobalSetup]
    public void Setup()
    {
        _list = [.. Range(1, Size)];
        _readOnly = _list.ToList().AsReadOnly();
        _immutableList = CreateRange(_list);
        _concurrentBag = [.. _list];
    }

    [Benchmark(Baseline = true)]
    public int StandardCount_List() => _list.StandardCount();

    [Benchmark]
    public int GetCount_List() => _list.GetCount();

    [Benchmark]
    public int StandardCount_ReadOnly() => _readOnly.StandardCount();

    [Benchmark]
    public int GetCount_ReadOnly() => _readOnly.GetCount();

    [Benchmark]
    public int StandardCount_ConcurrentBag() => _concurrentBag.StandardCount();

    [Benchmark]
    public int GetCount_ConcurrentBag() => _concurrentBag.GetCount();

    [Benchmark]
    public int StandardCount_ImmutableList() => _immutableList.StandardCount();

    [Benchmark]
    public int GetCount_ImmutableList() => _immutableList.GetCount();
}

public static class Extensions
{
    public static int StandardCount<T>(this IEnumerable<T>? input) => input.IsNullEmpty() ? 0 : input.Count();
}