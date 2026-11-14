namespace YANLib.Tests.Library;

[CollectionDefinition(nameof(YANTaskLeakTest), DisableParallelization = true)]
public class YANTaskLeakTestCollection { }

// Runs on its own (no other test runs in parallel) because it measures the whole managed heap.
[Collection(nameof(YANTaskLeakTest))]
public class YANTaskLeakTest
{
    private const int CALLS = 20_000;
    private const long MAX_GROWTH_BYTES = 8 * 1024 * 1024;

    // Every call has to wait, so it registers a continuation on the long-lived task, and it must remove that continuation
    // when it returns early. The predicate completes the matching task while the already complete 0 is checked, that is
    // before the continuations are registered, so every call takes that path without any timing assumption.
    private static Task<int>[] CreateTasks(Task<int> longLived, out Func<int, bool> predicate)
    {
        var match = new TaskCompletionSource<int>();

        predicate = x =>
        {
            if (x is 0)
            {
                _ = match.TrySetResult(1);

                return false;
            }

            return true;
        };

        return
        [
            longLived,
            match.Task,
            Task.FromResult(0)
        ];
    }

    // Best-effort: a heap measurement, not an exact count. With the removal left out, 20,000 calls kept about 35 MB alive
    // here; with it the heap grows by a few KB. The old Task.WhenAny loop did not leak either, so this test passes on 8.3.3.
    [Fact]
    public async Task WaitAnyWithCondition_EarlyMatchWithLongLivedTask_DoesNotLeakContinuations_Task()
    {
        // Arrange
        var never = new TaskCompletionSource<int>();
        var tasks = CreateTasks(never.Task, out var predicate);

        Assert.Equal(1, await tasks.WaitAnyWithCondition(predicate));

        var before = GC.GetTotalMemory(forceFullCollection: true);

        // Act
        for (var i = 0; i < CALLS; i++)
        {
            tasks = CreateTasks(never.Task, out predicate);
            _ = await tasks.WaitAnyWithCondition(predicate);
        }

        var growth = GC.GetTotalMemory(forceFullCollection: true) - before;

        // Assert
        GC.KeepAlive(never);
        Assert.True(growth < MAX_GROWTH_BYTES, $"The heap grew by {growth:N0} bytes after {CALLS:N0} calls.");
    }

    // Best-effort, see above: the same check for an enumeration that is abandoned after its first item.
    [Fact]
    public async Task WaitAnyWithConditions_AbandonedEnumerationWithLongLivedTask_DoesNotLeakContinuations_TaskCollection()
    {
        // Arrange
        var never = new TaskCompletionSource<int>();
        var tasks = CreateTasks(never.Task, out var predicate);

        Assert.Equal([1], await tasks.WaitAnyWithConditions(predicate, taken: 1).ToListAsync());

        var before = GC.GetTotalMemory(forceFullCollection: true);

        // Act
        for (var i = 0; i < CALLS; i++)
        {
            tasks = CreateTasks(never.Task, out predicate);

            await foreach (var item in tasks.WaitAnyWithConditions(predicate))
            {
                break;
            }
        }

        var growth = GC.GetTotalMemory(forceFullCollection: true) - before;

        // Assert
        GC.KeepAlive(never);
        Assert.True(growth < MAX_GROWTH_BYTES, $"The heap grew by {growth:N0} bytes after {CALLS:N0} enumerations.");
    }
}
