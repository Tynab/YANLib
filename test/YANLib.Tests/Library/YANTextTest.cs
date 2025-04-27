namespace YANLib.Tests.Library;

public partial class YANTextTest
{
    #region Title

    [Fact]
    public void Title_NullString_ReturnsNull_Text()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Title();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Title_EmptyString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Title_WhitespaceString_ReturnsWhitespace_Text()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Title_LowercaseString_ReturnsTitleCase_Text()
    {
        // Arrange
        var input = "hello world";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void Title_UppercaseString_ReturnsTitleCase_Text()
    {
        // Arrange
        var input = "HELLO WORLD";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void Title_MixedCaseString_ReturnsTitleCase_Text()
    {
        // Arrange
        var input = "hElLo WoRlD";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("Hello World", result);
    }

    #endregion

    #region Capitalize

    [Fact]
    public void Capitalize_NullString_ReturnsNull_Text()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Capitalize_EmptyString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Capitalize_WhitespaceString_ReturnsWhitespace_Text()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Capitalize_LowercaseString_ReturnsCapitalized_Text()
    {
        // Arrange
        var input = "hello world";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("Hello world", result);
    }

    [Fact]
    public void Capitalize_UppercaseString_ReturnsCapitalized_Text()
    {
        // Arrange
        var input = "HELLO WORLD";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("Hello world", result);
    }

    [Fact]
    public void Capitalize_MixedCaseString_ReturnsCapitalized_Text()
    {
        // Arrange
        var input = "hElLo WoRlD";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("Hello world", result);
    }

    #endregion

    #region CleanSpace

    [Fact]
    public void CleanSpace_NullString_ReturnsNull_Text()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CleanSpace_EmptyString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void CleanSpace_WhitespaceString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void CleanSpace_StringWithExtraSpaces_ReturnsCleanedString_Text()
    {
        // Arrange
        var input = "  hello   world  ";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void CleanSpace_StringWithTabs_ReturnsCleanedString_Text()
    {
        // Arrange
        var input = "hello\t\tworld";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void CleanSpace_StringWithNewlines_ReturnsCleanedString_Text()
    {
        // Arrange
        var input = "hello\n\nworld";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal("hello world", result);
    }

    #endregion

    #region FormatName

    [Fact]
    public void FormatName_NullString_ReturnsNull_Text()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FormatName_EmptyString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FormatName_WhitespaceString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FormatName_NameWithPunctuation_ReturnsFormattedName_Text()
    {
        // Arrange
        var input = "john.doe";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void FormatName_NameWithNumbers_ReturnsFormattedNameWithoutNumbers_Text()
    {
        // Arrange
        var input = "john123doe";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("Johndoe", result);
    }

    [Fact]
    public void FormatName_NameWithExtraSpaces_ReturnsFormattedName_Text()
    {
        // Arrange
        var input = "  john   doe  ";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("John Doe", result);
    }

    #endregion

    #region FilterAlphabetic

    [Fact]
    public void FilterAlphabetic_NullString_ReturnsNull_Text()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphabetic_EmptyString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphabetic_WhitespaceString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphabetic_StringWithMixedCharacters_ReturnsOnlyLetters_Text()
    {
        // Arrange
        var input = "abc123!@#";

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal("abc", result);
    }

    [Fact]
    public void FilterAlphabetic_StringWithNoLetters_ReturnsEmpty_Text()
    {
        // Arrange
        var input = "123!@#";

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    #endregion

    #region FilterNumber

    [Fact]
    public void FilterNumber_NullString_ReturnsNull_Text()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterNumber_EmptyString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterNumber_WhitespaceString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterNumber_StringWithMixedCharacters_ReturnsOnlyNumbers_Text()
    {
        // Arrange
        var input = "abc123!@#";

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal("123", result);
    }

    [Fact]
    public void FilterNumber_StringWithNoNumbers_ReturnsEmpty_Text()
    {
        // Arrange
        var input = "abc!@#";

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    #endregion

    #region FilterAlphanumeric

    [Fact]
    public void FilterAlphanumeric_NullString_ReturnsNull_Text()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphanumeric_EmptyString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphanumeric_WhitespaceString_ReturnsEmpty_Text()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphanumeric_StringWithMixedCharacters_ReturnsOnlyAlphanumeric_Text()
    {
        // Arrange
        var input = "abc123!@#";

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal("abc123", result);
    }

    [Fact]
    public void FilterAlphanumeric_StringWithNoAlphanumeric_ReturnsEmpty_Text()
    {
        // Arrange
        var input = "!@#$%^";

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    #endregion
}
