﻿using BenchmarkDotNet.Attributes;
using static BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule;
using static System.Threading.Tasks.Task;

namespace YANLib.Benchmarks.Common;

[SimpleJob, GroupBenchmarksBy(ByCategory), CategoriesColumn]
public class ConcurrentBenchmark
{
    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    [Benchmark(Baseline = true), BenchmarkCategory("Synchronous")]
    public async Task Synchronous_Task()
    {
        var sum = 0;

        for (var i = 0; i < Size; i++)
        {
            sum += await GetSyncTask();
        }
    }

    [Benchmark, BenchmarkCategory("Synchronous")]
    public async Task Synchronous_ValueTask()
    {
        var sum = 0;

        for (var i = 0; i < Size; i++)
        {
            sum += await GetSyncValueTask();
        }
    }

    private static Task<int> GetSyncTask()
    {
        var result = 1 + 1;

        return FromResult(result);
    }

    private static ValueTask<int> GetSyncValueTask()
    {
        var result = 1 + 1;

        return new(result);
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Asynchronous")]
    public async Task Asynchronous_Task()
    {
        var sum = 0;

        for (var i = 0; i < Size; i++)
        {
            sum += await GetAsyncTask();
        }
    }

    [Benchmark, BenchmarkCategory("Asynchronous")]
    public async Task Asynchronous_ValueTask()
    {
        var sum = 0;

        for (var i = 0; i < Size; i++)
        {
            sum += await GetAsyncValueTask();
        }
    }

    private static async Task<int> GetAsyncTask()
    {
        var result = 1 + 1;

        return await FromResult(result);
    }

    private static async ValueTask<int> GetAsyncValueTask()
    {
        var result = 1 + 1;

        return await new ValueTask<int>(result);
    }
}
