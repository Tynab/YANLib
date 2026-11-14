namespace YANLib.Tests.Library;

public partial class YANTaskTest
{
    #region WaitAnyWithConditions

    [Fact]
    public async Task WaitAnyWithConditions_NullTasks_ReturnsEmptyEnumerable_TaskCollection()
    {
        // Arrange
        IEnumerable<Task<int>>? tasks = null;
        static bool predicate(int x) => x > 0;

        // Act
        var result = tasks.WaitAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WaitAnyWithConditions_EmptyTasks_ReturnsEmptyEnumerable_TaskCollection()
    {
        // Arrange
        var tasks = Array.Empty<Task<int>>();
        static bool predicate(int x) => x > 0;

        // Act
        var result = tasks.WaitAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WaitAnyWithConditions_TasksWithMatchingCondition_ReturnsMatchingResults_TaskCollection()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromResult(1),
            Task.FromResult(2),
            Task.FromResult(3)
        };

        static bool predicate(int x) => x > 1;

        // Act
        var result = tasks.WaitAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WaitAnyWithConditions_TasksWithNoMatchingCondition_ReturnsEmptyEnumerable_TaskCollection()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromResult(1),
            Task.FromResult(2),
            Task.FromResult(3)
        };

        static bool predicate(int x) => x > 10;

        // Act
        var result = tasks.WaitAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WaitAnyWithConditions_TasksWithException_HandlesExceptionGracefully_TaskCollection()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromException<int>(new Exception("Test exception")),
            Task.FromResult(2),
            Task.FromResult(3)
        };

        static bool predicate(int x) => x > 1;

        // Act
        var result = tasks.WaitAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WaitAnyWithConditions_WithCancellationToken_RespectsToken_TaskCollection()
    {
        // Arrange
        var cts = new CancellationTokenSource();

        var tasks = new[]
        {
            Task.Delay(1000).ContinueWith(_ => 1),
            Task.Delay(2000).ContinueWith(_ => 2),
            Task.Delay(3000).ContinueWith(_ => 3)
        };

        static bool predicate(int x) => x > 1;

        // Act
        cts.Cancel();

        var result = tasks.WaitAnyWithConditions(predicate, cancellationToken: cts.Token);

        // Assert
        var items = await result.ToListAsync();

        Assert.Empty(items);
    }

    [Fact]
    public async Task WaitAnyWithConditions_DelayedTasks_WaitsForAllTasks_TaskCollection()
    {
        // Arrange
        var tasks = new[]
        {
            Task.Delay(100).ContinueWith(_ => 1),
            Task.Delay(50).ContinueWith(_ => 2),
            Task.Delay(10).ContinueWith(_ => 3)
        };

        static bool predicate(int x) => x > 1;

        // Act
        var result = tasks.WaitAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WaitAnyWithConditions_WithTakenParameter_LimitsResults_TaskCollection()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromResult(1),
            Task.FromResult(2),
            Task.FromResult(3),
            Task.FromResult(4),
            Task.FromResult(5)
        };

        static bool predicate(int x) => x > 1;
        uint taken = 2;

        // Act
        var result = tasks.WaitAnyWithConditions(predicate, taken);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
    }

    [Fact]
    public async Task WaitAnyWithConditions_CanceledDuringEnumeration_EndsWithoutException_TaskCollection()
    {
        // Arrange
        var never = new TaskCompletionSource<int>();
        using var cts = new CancellationTokenSource();

        var tasks = new[]
        {
            Task.FromResult(1),
            never.Task
        };

        var items = new List<int>();

        // Act
        async Task Enumerate()
        {
            await foreach (var item in tasks.WaitAnyWithConditions(x => x > 0, cancellationToken: cts.Token))
            {
                items.Add(item);
                cts.Cancel();
            }
        }

        var enumeration = Enumerate();

        // Assert (the guard only fails the test if cancellation is never observed)
        Assert.Same(enumeration, await Task.WhenAny(enumeration, Task.Delay(TimeSpan.FromSeconds(30))));
        await enumeration;
        Assert.Equal([1], items);
    }

    [Fact]
    public async Task WaitAnyWithConditions_CanceledWhileWaiting_EndsWithoutException_TaskCollection()
    {
        // Arrange
        var never = new TaskCompletionSource<int>();
        using var cts = new CancellationTokenSource();
        var tasks = new[] { never.Task };

        // Act
        var enumeration = tasks.WaitAnyWithConditions(x => x > 0, cancellationToken: cts.Token).ToListAsync().AsTask();

        cts.CancelAfter(200);

        // Assert (the guard only fails the test if cancellation is never observed)
        Assert.Same(enumeration, await Task.WhenAny(enumeration, Task.Delay(TimeSpan.FromSeconds(30))));
        Assert.Empty(await enumeration);
    }

    [Fact]
    public async Task WaitAnyWithConditions_CanceledWithCancellation_ReturnsEmptyEnumerable_TaskCollection()
    {
        // Arrange
        using var cts = new CancellationTokenSource();

        var tasks = new[]
        {
            Task.FromResult(1),
            Task.FromResult(2)
        };

        cts.Cancel();

        // Act
        var items = new List<int>();

        await foreach (var item in tasks.WaitAnyWithConditions(x => x > 0).WithCancellation(cts.Token))
        {
            items.Add(item);
        }

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WaitAnyWithConditions_LazySequence_StartsEachTaskOnce_TaskCollection()
    {
        // Arrange
        var starts = 0;

        // An iterator has no precomputed count, so checking it for emptiness would run (and start) its first item.
        IEnumerable<Task<int>> StartTasks()
        {
            for (var x = 1; x <= 3; x++)
            {
                starts++;

                yield return Task.FromResult(x);
            }
        }

        var tasks = StartTasks();

        // Act
        var items = await tasks.WaitAnyWithConditions(x => x > 1).ToListAsync();

        // Assert
        Assert.Equal([2, 3], items);
        Assert.Equal(3, starts);
    }

    [Fact]
    public async Task WaitAnyWithConditions_DelayedTasks_YieldsInCompletionOrder_TaskCollection()
    {
        // Arrange
        var first = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
        var second = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

        var tasks = new[]
        {
            second.Task,
            first.Task
        };

        // Act
        var enumeration = tasks.WaitAnyWithConditions(x => x > 0).ToListAsync().AsTask();

        first.SetResult(1);
        await Task.Delay(100);
        second.SetResult(2);

        // Assert
        Assert.Equal([1, 2], await enumeration);
    }

    [Fact]
    public async Task WaitAnyWithConditions_PredicateThrows_PropagatesException_TaskCollection()
    {
        // Arrange
        var tasks = new[] { Task.FromResult(0) };

        // Act & Assert
        _ = await Assert.ThrowsAsync<DivideByZeroException>(async () => await tasks.WaitAnyWithConditions(x => 10 / x > 1).ToListAsync());
    }

    #endregion

    #region WhenAnyWithConditions

    [Fact]
    public async Task WhenAnyWithConditions_NullTasks_ReturnsEmptyEnumerable_TaskCollection()
    {
        // Arrange
        IEnumerable<Task<int>>? tasks = null;
        static bool predicate(int x) => x > 0;

        // Act
        var result = tasks.WhenAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WhenAnyWithConditions_EmptyTasks_ReturnsEmptyEnumerable_TaskCollection()
    {
        // Arrange
        var tasks = Array.Empty<Task<int>>();
        static bool predicate(int x) => x > 0;

        // Act
        var result = tasks.WhenAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WhenAnyWithConditions_TasksWithMatchingCondition_ReturnsMatchingResults_TaskCollection()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromResult(1),
            Task.FromResult(2),
            Task.FromResult(3)
        };

        static bool predicate(int x) => x > 1;

        // Act
        var result = tasks.WhenAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WhenAnyWithConditions_TasksWithNoMatchingCondition_ReturnsEmptyEnumerable_TaskCollection()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromResult(1),
            Task.FromResult(2),
            Task.FromResult(3)
        };

        static bool predicate(int x) => x > 10;

        // Act
        var result = tasks.WhenAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WhenAnyWithConditions_TasksWithException_HandlesExceptionGracefully_TaskCollection()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromException<int>(new Exception("Test exception")),
            Task.FromResult(2),
            Task.FromResult(3)
        };

        static bool predicate(int x) => x > 1;

        // Act
        var result = tasks.WhenAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WhenAnyWithConditions_WithCancellationToken_RespectsToken_TaskCollection()
    {
        // Arrange
        var cts = new CancellationTokenSource();

        var tasks = new[]
        {
            Task.Delay(1000).ContinueWith(_ => 1),
            Task.Delay(2000).ContinueWith(_ => 2),
            Task.Delay(3000).ContinueWith(_ => 3)
        };

        static bool predicate(int x) => x > 1;

        // Act
        cts.Cancel();
        var result = tasks.WhenAnyWithConditions(predicate, cancellationToken: cts.Token);

        // Assert
        var items = await result.ToListAsync();
        Assert.Empty(items);
    }

    [Fact]
    public async Task WhenAnyWithConditions_DelayedTasks_WaitsForAllTasks_TaskCollection()
    {
        // Arrange
        var tasks = new[]
        {
            Task.Delay(100).ContinueWith(_ => 1),
            Task.Delay(50).ContinueWith(_ => 2),
            Task.Delay(10).ContinueWith(_ => 3)
        };

        static bool predicate(int x) => x > 1;

        // Act
        var result = tasks.WhenAnyWithConditions(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WhenAnyWithConditions_WithTakenParameter_LimitsResults_TaskCollection()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromResult(1),
            Task.FromResult(2),
            Task.FromResult(3),
            Task.FromResult(4),
            Task.FromResult(5)
        };

        static bool predicate(int x) => x > 1;
        uint taken = 2;

        // Act
        var result = tasks.WhenAnyWithConditions(predicate, taken);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
    }

    [Fact]
    public async Task WhenAnyWithConditions_CanceledWhileWaiting_EndsWithoutException_TaskCollection()
    {
        // Arrange
        var never = new TaskCompletionSource<int>();
        using var cts = new CancellationTokenSource();
        var tasks = new[] { never.Task };

        // Act
        var enumeration = tasks.WhenAnyWithConditions(x => x > 0, cancellationToken: cts.Token).ToListAsync().AsTask();

        cts.CancelAfter(200);

        // Assert (the guard only fails the test if cancellation is never observed)
        Assert.Same(enumeration, await Task.WhenAny(enumeration, Task.Delay(TimeSpan.FromSeconds(30))));
        Assert.Empty(await enumeration);
    }

    [Fact]
    public async Task WhenAnyWithConditions_LazySequence_StartsEachTaskOnce_TaskCollection()
    {
        // Arrange
        var starts = 0;

        // An iterator has no precomputed count, so checking it for emptiness would run (and start) its first item.
        IEnumerable<Task<int>> StartTasks()
        {
            for (var x = 1; x <= 3; x++)
            {
                starts++;

                yield return Task.FromResult(x);
            }
        }

        var tasks = StartTasks();

        // Act
        var items = await tasks.WhenAnyWithConditions(x => x > 1).ToListAsync();

        // Assert
        Assert.Equal([2, 3], items);
        Assert.Equal(3, starts);
    }

    #endregion

    #region AsyncEnumerableEmpty

    [Fact]
    public async Task AsyncEnumerableEmpty_ReturnsEmptyEnumerable_TaskCollection()
    {
        // Arrange
        var result = YANTask.AsyncEnumerableEmpty<int>();

        // Act
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task AsyncEnumerableEmpty_WithDifferentType_ReturnsEmptyEnumerable_TaskCollection()
    {
        // Arrange
        var result = YANTask.AsyncEnumerableEmpty<string>();

        // Act
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task AsyncEnumerableEmpty_EnumerationCompletes_WithoutExceptions_TaskCollection()
    {
        // Arrange
        var result = YANTask.AsyncEnumerableEmpty<int>();

        // Act
        var exception = await Record.ExceptionAsync(async () =>
        {
            await foreach (var item in result)
            {
                Assert.Fail("Should not have any items");
            }
        });

        // Assert
        Assert.Null(exception);
    }

    #endregion
}
