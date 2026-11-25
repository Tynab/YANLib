namespace YANLib.Tests.Library;

public partial class YANTextTest
{
    [Fact]
    public void CamelCase_List_ModifiesInPlaceAndKeepsNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "hello world", null, "HTTPServer" };
        var expected = new List<string?> { "hello world".CamelCase(), null, "HTTPServer".CamelCase() };

        // Act
        input.CamelCase();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void CamelCases_Enumerable_ReturnsConvertedInOrder_TextCollection()
    {
        // Arrange
        IEnumerable<string?> input = ["hello world", null, "user_id"];

        // Act
        var result = input.CamelCases();
        var fromParams = YANText.CamelCases("hello world", null, "user_id");

        // Assert
        Assert.Equal(["hello world".CamelCase(), null, "user_id".CamelCase()], result!);
        Assert.Equal(result!, fromParams!);
    }

    [Fact]
    public void PascalCase_List_ModifiesInPlaceAndKeepsNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "hello world", null, "HTTPServer" };
        var expected = new List<string?> { "hello world".PascalCase(), null, "HTTPServer".PascalCase() };

        // Act
        input.PascalCase();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void PascalCases_Enumerable_ReturnsConvertedInOrder_TextCollection()
    {
        // Arrange
        IEnumerable<string?> input = ["hello world", null, "user_id"];

        // Act
        var result = input.PascalCases();
        var fromParams = YANText.PascalCases("hello world", null, "user_id");

        // Assert
        Assert.Equal(["hello world".PascalCase(), null, "user_id".PascalCase()], result!);
        Assert.Equal(result!, fromParams!);
    }

    [Fact]
    public void SnakeLowerCase_List_ModifiesInPlaceAndKeepsNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "hello world", null, "HTTPServer" };
        var expected = new List<string?> { "hello world".SnakeLowerCase(), null, "HTTPServer".SnakeLowerCase() };

        // Act
        input.SnakeLowerCase();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void SnakeLowerCases_Enumerable_ReturnsConvertedInOrder_TextCollection()
    {
        // Arrange
        IEnumerable<string?> input = ["hello world", null, "user_id"];

        // Act
        var result = input.SnakeLowerCases();
        var fromParams = YANText.SnakeLowerCases("hello world", null, "user_id");

        // Assert
        Assert.Equal(["hello world".SnakeLowerCase(), null, "user_id".SnakeLowerCase()], result!);
        Assert.Equal(result!, fromParams!);
    }

    [Fact]
    public void SnakeUpperCase_List_ModifiesInPlaceAndKeepsNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "hello world", null, "HTTPServer" };
        var expected = new List<string?> { "hello world".SnakeUpperCase(), null, "HTTPServer".SnakeUpperCase() };

        // Act
        input.SnakeUpperCase();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void SnakeUpperCases_Enumerable_ReturnsConvertedInOrder_TextCollection()
    {
        // Arrange
        IEnumerable<string?> input = ["hello world", null, "user_id"];

        // Act
        var result = input.SnakeUpperCases();
        var fromParams = YANText.SnakeUpperCases("hello world", null, "user_id");

        // Assert
        Assert.Equal(["hello world".SnakeUpperCase(), null, "user_id".SnakeUpperCase()], result!);
        Assert.Equal(result!, fromParams!);
    }

    [Fact]
    public void KebabLowerCase_List_ModifiesInPlaceAndKeepsNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "hello world", null, "HTTPServer" };
        var expected = new List<string?> { "hello world".KebabLowerCase(), null, "HTTPServer".KebabLowerCase() };

        // Act
        input.KebabLowerCase();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void KebabLowerCases_Enumerable_ReturnsConvertedInOrder_TextCollection()
    {
        // Arrange
        IEnumerable<string?> input = ["hello world", null, "user_id"];

        // Act
        var result = input.KebabLowerCases();
        var fromParams = YANText.KebabLowerCases("hello world", null, "user_id");

        // Assert
        Assert.Equal(["hello world".KebabLowerCase(), null, "user_id".KebabLowerCase()], result!);
        Assert.Equal(result!, fromParams!);
    }

    [Fact]
    public void KebabUpperCase_List_ModifiesInPlaceAndKeepsNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "hello world", null, "HTTPServer" };
        var expected = new List<string?> { "hello world".KebabUpperCase(), null, "HTTPServer".KebabUpperCase() };

        // Act
        input.KebabUpperCase();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void KebabUpperCases_Enumerable_ReturnsConvertedInOrder_TextCollection()
    {
        // Arrange
        IEnumerable<string?> input = ["hello world", null, "user_id"];

        // Act
        var result = input.KebabUpperCases();
        var fromParams = YANText.KebabUpperCases("hello world", null, "user_id");

        // Assert
        Assert.Equal(["hello world".KebabUpperCase(), null, "user_id".KebabUpperCase()], result!);
        Assert.Equal(result!, fromParams!);
    }

    [Fact]
    public void WordCases_NullOrEmptyCollections_ReturnInputOrDoNothing_TextCollection()
    {
        // Arrange
        List<string?>? nullList = null;
        var emptyList = new List<string?>();
        IEnumerable<string?>? nullEnumerable = null;
        string?[] emptyArray = [];

        // Act
        nullList.CamelCase();
        emptyList.KebabUpperCase();

        // Assert
        Assert.Null(nullList);
        Assert.Empty(emptyList);
        Assert.Null(nullEnumerable.PascalCases());
        Assert.Same(emptyArray, YANText.SnakeLowerCases(emptyArray));
    }

    [Fact]
    public void WordCase_LargeList_ConvertsEveryElementInOrder_TextCollection()
    {
        // Arrange (1,000 or more elements are converted in parallel by index)
        var input = Enumerable.Range(0, 5_000).Select(static i => (string?)$"item {i}").ToList();

        // Act
        input.SnakeUpperCase();

        // Assert
        Assert.Equal(Enumerable.Range(0, 5_000).Select(static i => (string?)$"ITEM_{i}"), input);
    }
}
