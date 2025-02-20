using BenchmarkDotNet.Attributes;
using static System.Threading.Tasks.Task;

namespace YANLib.Benchmarks.Process.Common;

public class ConcurrentBenchmark
{
    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Iterations { get; set; }

    [Benchmark(Baseline = true)]
    public async Task Synchronous_Task()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            sum += await GetSyncTask();
        }
    }

    [Benchmark]
    public async Task Synchronous_ValueTask()
    {
        var sum = 0;

        for (var i = 0; i < Iterations; i++)
        {
            sum += await GetSyncValueTask();
        }
    }

    //[Benchmark]
    //public async Task Asynchronous_Task()
    //{
    //    var sum = 0;

    //    for (var i = 0; i < Iterations; i++)
    //    {
    //        sum += await GetAsyncTask();
    //    }
    //}

    //[Benchmark]
    //public async Task Asynchronous_ValueTask()
    //{
    //    var sum = 0;

    //    for (var i = 0; i < Iterations; i++)
    //    {
    //        sum += await GetAsyncValueTask();
    //    }
    //}

    private static Task<int> GetSyncTask() => FromResult(1);

    private static ValueTask<int> GetSyncValueTask() => new(1);

    //private static async Task<int> GetAsyncTask()
    //{
    //    await Delay(1);

    //    return 1;
    //}

    //private static async ValueTask<int> GetAsyncValueTask()
    //{
    //    await Delay(1);

    //    return 1;
    //}
}
