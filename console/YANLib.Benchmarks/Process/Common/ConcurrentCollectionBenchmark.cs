using BenchmarkDotNet.Attributes;
using YANLib.Benchmarks.Datas;
using YANLib.Unmanaged;
using static System.Array;
using static System.Guid;
using static System.Linq.Enumerable;
using static System.Threading.Tasks.Parallel;
using static System.Threading.Tasks.Task;
using static YANLib.YANMath;

namespace YANLib.Benchmarks.Process.Common;

public class ConcurrentCollectionBenchmark
{
    [Params(1_000, 10_000, 100_000, 1_000_000)]
    public int Size { get; set; }

    public readonly int BATCH_SIZE = 1_000;
    public readonly object _lockObj = new();
    public List<SampleClass>? _allData = default;
    public List<int>? _batches = default;

    [GlobalSetup]
    public void Setup()
    {
        _allData = [.. Range(1, Size).Select(i => new SampleClass
        {
            Id = NewGuid()
        })];

        _batches = [.. Range(0, (Size.Parse<double>() / BATCH_SIZE).Ceiling<int>())];
    }

    [Benchmark(Baseline = true)]
    public async Task ParallelWithLock()
    {
        var result = new List<SampleClass>();

        await ForEachAsync(_batches!, new ParallelOptions
        {
            MaxDegreeOfParallelism = 8
        }, async (batchNumber, cancellationToken) =>
        {
            var skip = batchNumber * BATCH_SIZE;
            var take = Min(BATCH_SIZE, Size - skip);
            var batchData = _allData!.Skip(skip).Take(take).ToList();

            lock (_lockObj)
            {
                result.AddRange(batchData);
            }

            await CompletedTask;
        });
    }

    [Benchmark]
    public async Task ParallelWithNoLock()
    {
        var result = new SampleClass[Size];
        var allDataArray = _allData!.ToArray();

        await ForEachAsync(_batches!, new ParallelOptions
        {
            MaxDegreeOfParallelism = 8
        }, async (batchNumber, cancellationToken) =>
        {
            var skip = batchNumber * BATCH_SIZE;
            var take = Min(BATCH_SIZE, Size - skip);

            Copy(allDataArray, skip, result, skip, take);
            await CompletedTask;
        });
    }
}
