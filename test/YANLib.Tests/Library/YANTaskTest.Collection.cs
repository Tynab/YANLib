using YANLib.Tests.Extensions;

namespace YANLib.Tests.Library;

public partial class YANTaskTest
{
    #region WaitAnyWithConditionsTest

    [Fact]
    public async Task WaitAnyWithConditionsTest_NullTasks_ReturnsEmptyEnumerable()
    {
        // Arrange
        IEnumerable<Task<int>>? tasks = null;
        static bool predicate(int x) => x > 0;

        // Act
        var result = tasks.WaitAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WaitAnyWithConditionsTest_EmptyTasks_ReturnsEmptyEnumerable()
    {
        // Arrange
        var tasks = Array.Empty<Task<int>>();
        static bool predicate(int x) => x > 0;

        // Act
        var result = tasks.WaitAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WaitAnyWithConditionsTest_TasksWithMatchingCondition_ReturnsMatchingResults()
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
        var result = tasks.WaitAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WaitAnyWithConditionsTest_TasksWithNoMatchingCondition_ReturnsEmptyEnumerable()
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
        var result = tasks.WaitAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WaitAnyWithConditionsTest_TasksWithException_HandlesExceptionGracefully()
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
        var result = tasks.WaitAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WaitAnyWithConditionsTest_WithCancellationToken_RespectsToken()
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

        var result = tasks.WaitAnyWithConditionsTest(predicate, cancellationToken: cts.Token);

        // Assert
        var items = await result.ToListAsync();

        Assert.Empty(items);
    }

    [Fact]
    public async Task WaitAnyWithConditionsTest_DelayedTasks_WaitsForAllTasks()
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
        var result = tasks.WaitAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WaitAnyWithConditionsTest_WithTakenParameter_LimitsResults()
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
        var result = tasks.WaitAnyWithConditionsTest(predicate, taken);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
    }

    #endregion

    #region WhenAnyWithConditionsTest

    [Fact]
    public async Task WhenAnyWithConditionsTest_NullTasks_ReturnsEmptyEnumerable()
    {
        // Arrange
        IEnumerable<Task<int>>? tasks = null;
        static bool predicate(int x) => x > 0;

        // Act
        var result = tasks.WhenAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WhenAnyWithConditionsTest_EmptyTasks_ReturnsEmptyEnumerable()
    {
        // Arrange
        var tasks = Array.Empty<Task<int>>();
        static bool predicate(int x) => x > 0;

        // Act
        var result = tasks.WhenAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WhenAnyWithConditionsTest_TasksWithMatchingCondition_ReturnsMatchingResults()
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
        var result = tasks.WhenAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WhenAnyWithConditionsTest_TasksWithNoMatchingCondition_ReturnsEmptyEnumerable()
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
        var result = tasks.WhenAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task WhenAnyWithConditionsTest_TasksWithException_HandlesExceptionGracefully()
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
        var result = tasks.WhenAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WhenAnyWithConditionsTest_WithCancellationToken_RespectsToken()
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
        var result = tasks.WhenAnyWithConditionsTest(predicate, cancellationToken: cts.Token);

        // Assert
        var items = await result.ToListAsync();
        Assert.Empty(items);
    }

    [Fact]
    public async Task WhenAnyWithConditionsTest_DelayedTasks_WaitsForAllTasks()
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
        var result = tasks.WhenAnyWithConditionsTest(predicate);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }

    [Fact]
    public async Task WhenAnyWithConditionsTest_WithTakenParameter_LimitsResults()
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
        var result = tasks.WhenAnyWithConditionsTest(predicate, taken);
        var items = await result.ToListAsync();

        // Assert
        Assert.Equal(2, items.Count);
    }

    #endregion

    #region AsyncEnumerableEmptyTest

    [Fact]
    public async Task AsyncEnumerableEmptyTest_ReturnsEmptyEnumerable()
    {
        // Arrange
        var result = YANTaskTestExtensions.AsyncEnumerableEmptyTest<int>();

        // Act
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task AsyncEnumerableEmptyTest_WithDifferentType_ReturnsEmptyEnumerable()
    {
        // Arrange
        var result = YANTaskTestExtensions.AsyncEnumerableEmptyTest<string>();

        // Act
        var items = await result.ToListAsync();

        // Assert
        Assert.Empty(items);
    }

    [Fact]
    public async Task AsyncEnumerableEmptyTest_EnumerationCompletes_WithoutExceptions()
    {
        // Arrange
        var result = YANTaskTestExtensions.AsyncEnumerableEmptyTest<int>();

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
