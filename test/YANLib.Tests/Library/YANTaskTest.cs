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

    #endregion
}
