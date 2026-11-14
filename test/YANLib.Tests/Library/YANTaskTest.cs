namespace YANLib.Tests.Library;

public partial class YANTaskTest
{
    #region WaitAnyWithCondition

    [Fact]
    public async Task WaitAnyWithCondition_NullTasks_ReturnsDefault_Task()
    {
        // Arrange
        IEnumerable<Task<int>>? tasks = null;
        static bool predicate(int x) => x > 0;

        // Act
        var result = await tasks.WaitAnyWithCondition(predicate);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public async Task WaitAnyWithCondition_EmptyTasks_ReturnsDefault_Task()
    {
        // Arrange
        var tasks = Array.Empty<Task<int>>();
        static bool predicate(int x) => x > 0;

        // Act
        var result = await tasks.WaitAnyWithCondition(predicate);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public async Task WaitAnyWithCondition_TasksWithMatchingCondition_ReturnsFirstMatchingResult_Task()
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
        var result = await tasks.WaitAnyWithCondition(predicate);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public async Task WaitAnyWithCondition_TasksWithNoMatchingCondition_ReturnsDefault_Task()
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
        var result = await tasks.WaitAnyWithCondition(predicate);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public async Task WaitAnyWithCondition_TasksWithException_HandlesExceptionGracefully_Task()
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
        var result = await tasks.WaitAnyWithCondition(predicate);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public async Task WaitAnyWithCondition_WithCancellationToken_RespectsToken_Task()
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

        // Assert
        _ = await Assert.ThrowsAsync<TaskCanceledException>(() => tasks.WaitAnyWithCondition(predicate, cts.Token));
    }

    [Fact]
    public async Task WaitAnyWithCondition_DelayedTasks_WaitsForAllTasks_Task()
    {
        // Arrange
        var tasks = new[]
        {
            Task.Delay(100).ContinueWith(_ => 1),
            Task.Delay(50).ContinueWith(_ => 2),
            Task.Delay(10).ContinueWith(_ => 3)
        };

        static bool predicate(int x) => x > 2;

        // Act
        var result = await tasks.WaitAnyWithCondition(predicate);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public async Task WaitAnyWithCondition_DelayedTasksNoMatch_ReturnsDefault_Task()
    {
        // Arrange
        var tasks = new[]
        {
            Task.Delay(100).ContinueWith(_ => 1),
            Task.Delay(50).ContinueWith(_ => 2),
            Task.Delay(10).ContinueWith(_ => 3)
        };

        static bool predicate(int x) => x > 10;

        // Act
        var result = await tasks.WaitAnyWithCondition(predicate);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public async Task WaitAnyWithCondition_CanceledWhileWaiting_ThrowsOperationCanceledException_Task()
    {
        // Arrange
        var never = new TaskCompletionSource<int>();
        using var cts = new CancellationTokenSource();
        var tasks = new[] { never.Task };

        // Act
        var operation = tasks.WaitAnyWithCondition(x => x > 0, cts.Token);

        cts.CancelAfter(200);

        // Assert (the guard only fails the test if cancellation is never observed)
        Assert.Same(operation, await Task.WhenAny(operation, Task.Delay(TimeSpan.FromSeconds(30))));
        _ = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => operation);
    }

    [Fact]
    public async Task WaitAnyWithCondition_LazySequence_StartsEachTaskOnce_Task()
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
        var result = await tasks.WaitAnyWithCondition(x => x == 3);

        // Assert
        Assert.Equal(3, result);
        Assert.Equal(3, starts);
    }

    [Fact]
    public async Task WaitAnyWithCondition_PredicateThrows_SkipsThatResult_Task()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromResult(0),
            Task.FromResult(2)
        };

        // Act
        var result = await tasks.WaitAnyWithCondition(x => 10 / x > 1);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public async Task WaitAnyWithCondition_MatchCompletesLater_ReturnsIt_Task()
    {
        // Arrange
        var later = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
        var never = new TaskCompletionSource<int>();

        var tasks = new[]
        {
            never.Task,
            Task.FromResult(1),
            later.Task
        };

        // Act
        var operation = tasks.WaitAnyWithCondition(x => x > 1);

        later.SetResult(5);

        // Assert
        Assert.Equal(5, await operation);
    }

    [Fact]
    public async Task WaitAnyWithCondition_NullTaskInCollection_ThrowsArgumentException_Task()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromResult(1),
            null!
        };

        // Act & Assert
        _ = await Assert.ThrowsAsync<ArgumentException>(() => tasks.WaitAnyWithCondition(x => x > 0));
    }

    #endregion

    #region WhenAnyWithCondition

    [Fact]
    public async Task WhenAnyWithCondition_NullTasks_ReturnsDefault_Task()
    {
        // Arrange
        IEnumerable<Task<int>>? tasks = null;
        static bool predicate(int x) => x > 0;

        // Act
        var result = await tasks.WhenAnyWithCondition(predicate);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public async Task WhenAnyWithCondition_EmptyTasks_ReturnsDefault_Task()
    {
        // Arrange
        var tasks = Array.Empty<Task<int>>();
        static bool predicate(int x) => x > 0;

        // Act
        var result = await tasks.WhenAnyWithCondition(predicate);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public async Task WhenAnyWithCondition_TasksWithMatchingCondition_ReturnsFirstMatchingResult_Task()
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
        var result = await tasks.WhenAnyWithCondition(predicate);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public async Task WhenAnyWithCondition_TasksWithNoMatchingCondition_ReturnsDefault_Task()
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
        var result = await tasks.WhenAnyWithCondition(predicate);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public async Task WhenAnyWithCondition_TasksWithException_HandlesExceptionGracefully_Task()
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
        var result = await tasks.WhenAnyWithCondition(predicate);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public async Task WhenAnyWithCondition_WithCancellationToken_RespectsToken_Task()
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

        // Assert
        _ = await Assert.ThrowsAsync<TaskCanceledException>(() => tasks.WhenAnyWithCondition(predicate, cts.Token));
    }

    [Fact]
    public async Task WhenAnyWithCondition_DelayedTasks_WaitsForAllTasks_Task()
    {
        // Arrange
        var tasks = new[]
        {
            Task.Delay(100).ContinueWith(_ => 1),
            Task.Delay(50).ContinueWith(_ => 2),
            Task.Delay(10).ContinueWith(_ => 3)
        };

        static bool predicate(int x) => x > 2;

        // Act
        var result = await tasks.WhenAnyWithCondition(predicate);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public async Task WhenAnyWithCondition_DelayedTasksNoMatch_ReturnsDefault_Task()
    {
        // Arrange
        var tasks = new[]
        {
            Task.Delay(100).ContinueWith(_ => 1),
            Task.Delay(50).ContinueWith(_ => 2),
            Task.Delay(10).ContinueWith(_ => 3)
        };

        static bool predicate(int x) => x > 10;

        // Act
        var result = await tasks.WhenAnyWithCondition(predicate);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public async Task WhenAnyWithCondition_CanceledWhileWaiting_ThrowsOperationCanceledException_Task()
    {
        // Arrange
        var never = new TaskCompletionSource<int>();
        using var cts = new CancellationTokenSource();
        var tasks = new[] { never.Task };

        // Act
        var operation = tasks.WhenAnyWithCondition(x => x > 0, cts.Token);

        cts.CancelAfter(200);

        // Assert (the guard only fails the test if cancellation is never observed)
        Assert.Same(operation, await Task.WhenAny(operation, Task.Delay(TimeSpan.FromSeconds(30))));
        _ = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => operation);
    }

    [Fact]
    public async Task WhenAnyWithCondition_LazySequence_StartsEachTaskOnce_Task()
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
        var result = await tasks.WhenAnyWithCondition(x => x == 3);

        // Assert
        Assert.Equal(3, result);
        Assert.Equal(3, starts);
    }

    #endregion
}
