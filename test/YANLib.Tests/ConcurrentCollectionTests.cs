using YANLib.Tests.Models;

namespace YANLib.Tests;

public class ConcurrentCollectionTests
{
    private const int TEST_SIZE = 10_000;
    private readonly ConcurrentCollectionData _data = new(TEST_SIZE);

    [Fact]
    public async Task TestResultsMatch()
    {
        var resultWithLock = await ExecuteParallelWithLock();
        var resultNoLock = await ExecuteParallelWithDirectCopy();
        var resultWithSemaphore = await ExecuteWhenAllWithSemaphoreSlim();

        Assert.Equal(resultWithLock.Count, resultNoLock.Count);
        Assert.Equal(resultWithLock.Count, resultWithSemaphore.Count);

        for (var i = 0; i < resultWithLock.Count; i++)
        {
            Assert.Equal(resultWithLock[i].Id, resultNoLock[i].Id);
            Assert.Equal(resultWithLock[i].Id, resultWithSemaphore[i].Id);
        }
    }

    private async Task<List<ConcurrentCollectionItem>> ExecuteParallelWithLock()
    {
        var result = new List<ConcurrentCollectionItem>();
        var batches = _data.Batches;
        var allData = _data.AllData;
        var lockObj = _data.LockObj;

        var tasks = batches.Select(async batchNumber =>
        {
            var skip = batchNumber * _data.BatchSize;
            var take = YANMath.Min(_data.BatchSize, _data.Size - skip);
            var batchData = allData.Skip(skip).Take(take).ToList();

            lock (lockObj)
            {
                result.AddRange(batchData);
            }

            await Task.CompletedTask;
        });

        await Task.WhenAll(tasks);

        return result;
    }

    private async Task<List<ConcurrentCollectionItem>> ExecuteParallelWithDirectCopy()
    {
        var finalResult = new ConcurrentCollectionItem[_data.Size];
        var batches = _data.Batches;
        var allDataArray = _data.AllData.ToArray();

        var tasks = batches.Select(async batchNumber =>
        {
            var skip = batchNumber * _data.BatchSize;
            var take = YANMath.Min(_data.BatchSize, _data.Size - skip);

            Array.Copy(allDataArray, skip, finalResult, skip, take);
            await Task.CompletedTask;
        });

        await Task.WhenAll(tasks);

        return [.. finalResult];
    }

    private async Task<List<ConcurrentCollectionItem>> ExecuteWhenAllWithSemaphoreSlim()
    {
        var result = new List<ConcurrentCollectionItem>();
        var batches = _data.Batches;
        var allData = _data.AllData;
        var ss = new SemaphoreSlim(1);

        var tasks = batches.Select(async batchNumber =>
        {
            var skip = batchNumber * _data.BatchSize;
            var take = YANMath.Min(_data.BatchSize, _data.Size - skip);
            var batchData = allData.Skip(skip).Take(take).ToList();

            await ss.WaitAsync();

            try
            {
                result.AddRange(batchData);
            }
            finally
            {
                _ = ss.Release();
            }
        });

        await Task.WhenAll(tasks);

        return result;
    }
}
