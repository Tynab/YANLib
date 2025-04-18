namespace YANLib.Tests.Library;

public partial class YANProcessTest
{
    [Fact]
    public async Task KillAllProcessesByNames_SingleName_NullOrWhitespace_DoesNotThrow()
    {
        // Arrange
        string? nullName = null;
        var empty = string.Empty;
        var whitespace = " ";

        // Act & Assert
        var ex1 = await Record.ExceptionAsync(nullName.KillAllProcessesByName);
        Assert.Null(ex1);

        var ex2 = await Record.ExceptionAsync(empty.KillAllProcessesByName);
        Assert.Null(ex2);

        var ex3 = await Record.ExceptionAsync(whitespace.KillAllProcessesByName);
        Assert.Null(ex3);
    }

    [Fact]
    public async Task KillAllProcessesByNames_SingleName_NonExistent_DoesNotThrow()
    {
        // Arrange
        var name = "ProcessDoesNotExist123";

        // Act
        var ex = await Record.ExceptionAsync(name.KillAllProcessesByName);

        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public async Task KillAllProcessesByNames_IEnumerable_NullOrEmpty_DoesNotThrow()
    {
        // Arrange
        IEnumerable<string?>? nullNames = null;
        var emptyList = new List<string?>();

        // Act & Assert
        var ex1 = await Record.ExceptionAsync(nullNames.KillAllProcessesByNames);
        Assert.Null(ex1);

        var ex2 = await Record.ExceptionAsync(emptyList.KillAllProcessesByNames);
        Assert.Null(ex2);
    }

    [Fact]
    public async Task KillAllProcessesByNames_IEnumerable_NonExistentNames_DoesNotThrow()
    {
        // Arrange
        var names = new[] { "FakeProcessA", "FakeProcessB" };

        // Act
        var ex = await Record.ExceptionAsync(names.KillAllProcessesByNames);

        // Assert
        Assert.Null(ex);
    }

    [Fact]
    public async Task KillAllProcessesByNames_Params_NullOrEmpty_DoesNotThrow()
    {
        // Arrange
        string?[]? nullArray = null;
        string?[] emptyArray = [];

        // Act & Assert
        var ex1 = await Record.ExceptionAsync(() => YANProcess.KillAllProcessesByNames(nullArray));
        Assert.Null(ex1);

        var ex2 = await Record.ExceptionAsync(() => YANProcess.KillAllProcessesByNames(emptyArray));
        Assert.Null(ex2);
    }

    [Fact]
    public async Task KillAllProcessesByNames_Params_VariousNames_NonExistent_DoesNotThrow()
    {
        // Act
        var ex = await Record.ExceptionAsync(() => YANProcess.KillAllProcessesByNames("FakeA", null, " ", "FakeB"));

        // Assert
        Assert.Null(ex);
    }
}
