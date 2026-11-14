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
