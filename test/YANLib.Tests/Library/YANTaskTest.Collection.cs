namespace YANLib.Tests.Library;

public partial class YANTaskTest
{
    #region WaitAnyWithConditions

    [Fact]
    public async Task WaitAnyWithConditions_NullTasks_ReturnsEmptyEnumerable()
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
    public async Task WaitAnyWithConditions_EmptyTasks_ReturnsEmptyEnumerable()
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
    public async Task WaitAnyWithConditions_TasksWithMatchingCondition_ReturnsMatchingResults()
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
    public async Task WaitAnyWithConditions_TasksWithNoMatchingCondition_ReturnsEmptyEnumerable()
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
    public async Task WaitAnyWithConditions_TasksWithException_HandlesExceptionGracefully()
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
    public async Task WaitAnyWithConditions_WithCancellationToken_RespectsToken()
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
    public async Task WaitAnyWithConditions_DelayedTasks_WaitsForAllTasks()
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
    public async Task WaitAnyWithConditions_WithTakenParameter_LimitsResults()
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
    public async Task WaitAnyWithConditions_YieldsInCompletionOrder()
    {
        // Arrange
        var first = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
        var second = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
        var third = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
        var timeout = TimeSpan.FromSeconds(5);
        static bool predicate(int x) => x > 0;

        await using var enumerator = new[] { first.Task, second.Task, third.Task }.WaitAnyWithConditions(predicate).GetAsyncEnumerator();

        // Act & Assert
        var moveNext = enumerator.MoveNextAsync().AsTask();
        third.SetResult(3);
        Assert.True(await moveNext.WaitAsync(timeout));
        Assert.Equal(3, enumerator.Current);

        moveNext = enumerator.MoveNextAsync().AsTask();
        first.SetResult(1);
        Assert.True(await moveNext.WaitAsync(timeout));
        Assert.Equal(1, enumerator.Current);

        moveNext = enumerator.MoveNextAsync().AsTask();
        second.SetResult(2);
        Assert.True(await moveNext.WaitAsync(timeout));
        Assert.Equal(2, enumerator.Current);

        Assert.False(await enumerator.MoveNextAsync().AsTask().WaitAsync(timeout));
    }

    [Fact]
    public async Task WaitAnyWithConditions_CanceledWhilePending_ThrowsOperationCanceled()
    {
        // Arrange
        var pending = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var cts = new CancellationTokenSource();
        static bool predicate(int x) => x > 0;

        var enumeration = new[] { pending.Task }.WaitAnyWithConditions(predicate, cancellationToken: cts.Token).ToListAsync().AsTask();

        // Act
        cts.CancelAfter(TimeSpan.FromMilliseconds(50));

        var finished = await Task.WhenAny(enumeration, Task.Delay(TimeSpan.FromSeconds(5)));

        // Assert
        Assert.Same(enumeration, finished);
        _ = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => enumeration);
    }

    [Fact]
    public async Task WaitAnyWithConditions_LazySequence_EnumeratesSourceOnce()
    {
        // Arrange
        var calls = 0;

        var tasks = new[] { 1, 2, 3 }.Where(static _ => true).Select(x =>
        {
            calls++;

            return Task.FromResult(x);
        });

        static bool predicate(int x) => x > 2;

        // Act
        var items = await tasks.WaitAnyWithConditions(predicate).ToListAsync();

        // Assert
        Assert.Equal(3, Assert.Single(items));
        Assert.Equal(3, calls);
    }

    #endregion

    #region WhenAnyWithConditions

    [Fact]
    public async Task WhenAnyWithConditions_NullTasks_ReturnsEmptyEnumerable()
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
    public async Task WhenAnyWithConditions_EmptyTasks_ReturnsEmptyEnumerable()
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
    public async Task WhenAnyWithConditions_TasksWithMatchingCondition_ReturnsMatchingResults()
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
    public async Task WhenAnyWithConditions_TasksWithNoMatchingCondition_ReturnsEmptyEnumerable()
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
    public async Task WhenAnyWithConditions_TasksWithException_HandlesExceptionGracefully()
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
    public async Task WhenAnyWithConditions_WithCancellationToken_RespectsToken()
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
    public async Task WhenAnyWithConditions_DelayedTasks_WaitsForAllTasks()
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
    public async Task WhenAnyWithConditions_WithTakenParameter_LimitsResults()
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
    public async Task WhenAnyWithConditions_TakenReached_DoesNotWaitForPendingTasks()
    {
        // Arrange
        var never = new TaskCompletionSource<int>();
        var tasks = new[] { never.Task, Task.FromResult(2) };
        static bool predicate(int x) => x > 1;

        // Act
        var items = await tasks.WhenAnyWithConditions(predicate, taken: 1).ToListAsync().AsTask().WaitAsync(TimeSpan.FromSeconds(5));

        // Assert
        Assert.Equal(2, Assert.Single(items));
    }

    [Fact]
    public async Task WhenAnyWithConditions_CanceledViaEnumeratorToken_ThrowsOperationCanceled()
    {
        // Arrange
        var pending = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var cts = new CancellationTokenSource();
        static bool predicate(int x) => x > 0;

        var enumeration = new[] { pending.Task }.WhenAnyWithConditions(predicate).ToListAsync(cts.Token).AsTask();

        // Act
        cts.CancelAfter(TimeSpan.FromMilliseconds(50));

        var finished = await Task.WhenAny(enumeration, Task.Delay(TimeSpan.FromSeconds(5)));

        // Assert
        Assert.Same(enumeration, finished);
        _ = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => enumeration);
    }

    #endregion

    #region AsyncEnumerableEmpty

    [Fact]
    public async Task AsyncEnumerableEmpty_ReturnsEmptyEnumerable()
    {
        // Arrange
        var result = YANTask.AsyncEnumerableEmpty<int>();

        // Act
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task AsyncEnumerableEmpty_WithDifferentType_ReturnsEmptyEnumerable()
    {
        // Arrange
        var result = YANTask.AsyncEnumerableEmpty<string>();

        // Act
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task AsyncEnumerableEmpty_EnumerationCompletes_WithoutExceptions()
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
