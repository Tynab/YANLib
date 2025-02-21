using BenchmarkDotNet.Attributes;
using static BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule;
using static System.Threading.Tasks.Task;

namespace YANLib.Benchmarks.Process.Common;

[SimpleJob, GroupBenchmarksBy(ByCategory), CategoriesColumn]
public class ConcurrentBenchmark
{
    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Iterations { get; set; }

    [Benchmark(Baseline = true), BenchmarkCategory("Synchronous")]
    public async Task Synchronous_Task()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            sum += await GetSyncTask();
        }
    }

    [Benchmark, BenchmarkCategory("Synchronous")]
    public async Task Synchronous_ValueTask()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            sum += await GetSyncValueTask();
        }
    }

    private static Task<int> GetSyncTask() => FromResult(1);

    private static ValueTask<int> GetSyncValueTask() => new(1);

    [Benchmark(Baseline = true), BenchmarkCategory("Asynchronous")]
    public async Task Asynchronous_Task()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            sum += await GetAsyncTask();
        }
    }

    [Benchmark, BenchmarkCategory("Asynchronous")]
    public async Task Asynchronous_ValueTask()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            sum += await GetAsyncValueTask();
        }
    }

    private static async Task<int> GetAsyncTask()
    {
        var result = 1 + 1;

        await Yield();

        return result;
    }

    private static async ValueTask<int> GetAsyncValueTask()
    {
        var result = 1 + 1;

        await Yield();

        return result;
    }
}
