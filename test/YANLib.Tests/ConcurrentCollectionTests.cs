using YANLib.Benchmarks.Datas;
using YANLib.Benchmarks.Process.Common;

namespace YANLib.Tests;

public class ConcurrentCollectionTests
{
    private const int TEST_SIZE = 10_000;
    private readonly ConcurrentCollectionBenchmark _benchmark;

    public ConcurrentCollectionTests()
    {
        _benchmark = new ConcurrentCollectionBenchmark
        {
            Size = TEST_SIZE
        };

        _benchmark.Setup();
    }

    [Fact]
    public async Task TestResultsMatch()
    {
        var resultWithLock = await ExecuteParallelWithLock();
        var resultNoLock = await ExecuteParallelWithDirectCopy();

        Assert.Equal(resultWithLock.Count, resultNoLock.Count);

        for (var i = 0; i < resultWithLock.Count; i++)
        {
            Assert.Equal(resultWithLock[i].Id, resultNoLock[i].Id);
        }
    }

    private async Task<List<SampleClass>> ExecuteParallelWithLock()
    {
        var result = new List<SampleClass>();
        var batches = _benchmark._batches;
        var allData = _benchmark._allData;
        var lockObj = _benchmark._lockObj;

        var tasks = batches!.Select(async batchNumber =>
        {
            var skip = batchNumber * _benchmark.BATCH_SIZE;
            var take = YANMath.Min(_benchmark.BATCH_SIZE, _benchmark.Size - skip);
            var batchData = allData!.Skip(skip).Take(take).ToList();

            lock (lockObj)
            {
                result.AddRange(batchData);
            }

            await Task.CompletedTask;
        });

        await Task.WhenAll(tasks);

        return result;
    }

    private async Task<List<SampleClass>> ExecuteParallelWithDirectCopy()
    {
        var finalResult = new SampleClass[_benchmark.Size];
        var batches = _benchmark._batches;
        var allDataArray = _benchmark._allData!.ToArray();

        var tasks = batches!.Select(async batchNumber =>
        {
            var skip = batchNumber * _benchmark.BATCH_SIZE;
            var take = YANMath.Min(_benchmark.BATCH_SIZE, _benchmark.Size - skip);

            Array.Copy(allDataArray, skip, finalResult, skip, take);
            await Task.CompletedTask;
        });

        await Task.WhenAll(tasks);

        return [.. finalResult];
    }
}
