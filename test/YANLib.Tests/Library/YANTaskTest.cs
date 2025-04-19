namespace YANLib.Tests.Library;

public partial class YANTaskTest
{
    private class Student
    {
        public string? Name { get; init; }

        public int Score { get; init; }
    }

    #region WaitAnyWithCondition
    [Fact]
    public async Task WaitAnyWithCondition_NullTasks_ReturnsNull()
    {
        // Arrange
        IEnumerable<Task<int?>>? tasks = null;

        // Act
        var result = await tasks.WaitAnyWithCondition(x => x is 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task WaitAnyWithCondition_EmptyTasks_ReturnsNull()
    {
        // Arrange
        var tasks = new List<Task<int?>>();

        // Act
        var result = await tasks.WaitAnyWithCondition(x => x is 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task WaitAnyWithCondition_NoMatch_ReturnsNull()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromResult<int?>(1),
            Task.FromResult<int?>(2)
        };

        // Act
        var result = await tasks.WaitAnyWithCondition(x => x is 3);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task WaitAnyWithCondition_Match_ReturnsValue()
    {
        // Arrange
        var studentA = new Student
        {
            Name = "A",
            Score = 5
        };

        var studentB = new Student
        {
            Name = "B",
            Score = 10
        };

        var studentC = new Student
        {
            Name = "C",
            Score = 10
        };

        var tA = Task.Run(async () =>
        {
            await Task.Delay(100);

            return studentA;
        });

        var tB = Task.Run(async () =>
        {
            await Task.Delay(1000);

            return studentB;
        });

        var tC = Task.Run(async () =>
        {
            await Task.Delay(10);

            return studentC;
        });

        var tasks = new[] { tA, tB, tC };

        // Act
        var result = await tasks.WaitAnyWithCondition(s => s.Score is 10);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("C", result.Name);
        Assert.Equal(10, result.Score);
    }

    [Fact]
    public async Task WaitAnyWithCondition_FirstCompletedNotMatch_ReturnsNull()
    {
        // Arrange
        var studentA = new Student
        {
            Name = "A",
            Score = 5
        };

        var studentB = new Student
        {
            Name = "B",
            Score = 10
        };

        var studentC = new Student
        {
            Name = "C",
            Score = 10
        };

        var tA = Task.Run(async () =>
        {
            await Task.Delay(10);

            return studentA;
        });

        var tB = Task.Run(async () =>
        {
            await Task.Delay(100);

            return studentB;
        });

        var tC = Task.Run(async () =>
        {
            await Task.Delay(1000);

            return studentC;
        });

        var tasks = new[] { tA, tB, tC };

        // Act
        var result = await tasks.WaitAnyWithCondition(s => s.Score is 10);

        // Assert
        Assert.Null(result);
    }
    #endregion

    #region WhenAnyWithCondition
    [Fact]
    public async Task WhenAnyWithCondition_NullTasks_ReturnsNull()
    {
        // Arrange
        IEnumerable<Task<int?>>? tasks = null;

        // Act
        var result = await tasks.WhenAnyWithCondition(x => x is 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task WhenAnyWithCondition_EmptyTasks_ReturnsNull()
    {
        // Arrange
        var tasks = new List<Task<int?>>();

        // Act
        var result = await tasks.WhenAnyWithCondition(x => x is 1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task WhenAnyWithCondition_NoMatch_ReturnsNull()
    {
        // Arrange
        var tasks = new[]
        {
            Task.FromResult<int?>(1),
            Task.FromResult<int?>(2)
        };

        // Act
        var result = await tasks.WhenAnyWithCondition(x => x is 3);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task WhenAnyWithCondition_Match_ReturnsValue()
    {
        // Arrange
        var studentA = new Student
        {
            Name = "A",
            Score = 5
        };

        var studentB = new Student
        {
            Name = "B",
            Score = 10
        };

        var studentC = new Student
        {
            Name = "C",
            Score = 10
        };

        var tA = Task.Run(async () =>
        {
            await Task.Delay(10);

            return studentA;
        });
        var tB = Task.Run(async () =>
        {
            await Task.Delay(1000);

            return studentB;
        });
        var tC = Task.Run(async () =>
        {
            await Task.Delay(100);

            return studentC;
        });

        var tasks = new[] { tA, tB, tC };

        // Act
        var result = await tasks.WhenAnyWithCondition(s => s.Score is 10);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("C", result.Name);
        Assert.Equal(10, result.Score);
    }

    [Fact]
    public async Task WhenAnyWithCondition_FirstCompletedNotMatchThenLaterMatch_ReturnsFirstMatching()
    {
        // Arrange
        var studentA = new Student
        {
            Name = "A",
            Score = 5
        };

        var studentB = new Student
        {
            Name = "B",
            Score = 10
        };

        var studentC = new Student
        {
            Name = "C",
            Score = 10
        };

        var tA = Task.Run(async () =>
        {
            await Task.Delay(10);

            return studentA;
        });

        var tB = Task.Run(async () =>
        {
            await Task.Delay(100);

            return studentB;
        });

        var tC = Task.Run(async () =>
        {
            await Task.Delay(1000);

            return studentC;
        });

        var tasks = new[] { tA, tB, tC };

        // Act
        var result = await tasks.WhenAnyWithCondition(s => s.Score is 10);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("B", result.Name);
        Assert.Equal(10, result.Score);
    }
    #endregion
}
