using YANLib.Text;

namespace YANLib.Tests.Library.Text;

public partial class YANTextTest
{
    #region Title

    [Fact]
    public void Title_NullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Title();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Title_EmptyString_ReturnsEmpty()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Title_WhitespaceString_ReturnsWhitespace()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Title_LowercaseString_ReturnsTitleCase()
    {
        // Arrange
        var input = "hello world";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void Title_UppercaseString_ReturnsTitleCase()
    {
        // Arrange
        var input = "HELLO WORLD";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void Title_MixedCaseString_ReturnsTitleCase()
    {
        // Arrange
        var input = "hElLo WoRlD";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void Title_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<string?> { "hello world", "GOOD MORNING", null, "" };

        // Act
        input.Title();

        // Assert
        Assert.Equal(["Hello World", "Good Morning", null, ""], input);
    }

    [Fact]
    public void Titles_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Titles();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Titles_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.Titles();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Titles_MixedCaseCollection_ReturnsAllTitleCase()
    {
        // Arrange
        var input = new[] { "hello world", "GOOD MORNING", null, "" };

        // Act
        var result = input.Titles();

        // Assert
        Assert.Equal(["Hello World", "Good Morning", null, ""], result);
    }

    [Fact]
    public void Titles_Params_MixedCaseStrings_ReturnsAllTitleCase()
    {
        // Act
        var result = YANText.Titles("hello world", "GOOD MORNING", null, "");

        // Assert
        Assert.Equal(["Hello World", "Good Morning", null, ""], result);
    }

    #endregion

    #region Capitalize

    [Fact]
    public void Capitalize_NullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Capitalize_EmptyString_ReturnsEmpty()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Capitalize_WhitespaceString_ReturnsWhitespace()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Capitalize_LowercaseString_ReturnsCapitalized()
    {
        // Arrange
        var input = "hello world";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("Hello world", result);
    }

    [Fact]
    public void Capitalize_UppercaseString_ReturnsCapitalized()
    {
        // Arrange
        var input = "HELLO WORLD";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("Hello world", result);
    }

    [Fact]
    public void Capitalize_MixedCaseString_ReturnsCapitalized()
    {
        // Arrange
        var input = "hElLo WoRlD";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("Hello world", result);
    }

    [Fact]
    public void Capitalize_StringStartingWithNonAlphabetic_ReturnsLowercase()
    {
        // Arrange
        var input = "123hello world";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("123Hello world", result);
    }

    [Fact]
    public void Capitalize_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<string?> { "hello world", "GOOD MORNING", null, "" };

        // Act
        input.Capitalize();

        // Assert
        Assert.Equal(["Hello world", "Good morning", null, ""], input);
    }

    [Fact]
    public void Capitalizes_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Capitalizes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Capitalizes_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.Capitalizes();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Capitalizes_MixedCaseCollection_ReturnsAllCapitalized()
    {
        // Arrange
        var input = new[] { "hello world", "GOOD MORNING", null, "" };

        // Act
        var result = input.Capitalizes();

        // Assert
        Assert.Equal(["Hello world", "Good morning", null, ""], result);
    }

    [Fact]
    public void Capitalizes_Params_MixedCaseStrings_ReturnsAllCapitalized()
    {
        // Act
        var result = YANText.Capitalizes("hello world", "GOOD MORNING", null, "");

        // Assert
        Assert.Equal(["Hello world", "Good morning", null, ""], result);
    }

    #endregion

    #region CleanSpace

    [Fact]
    public void CleanSpace_NullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CleanSpace_EmptyString_ReturnsEmpty()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void CleanSpace_WhitespaceString_ReturnsEmpty()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void CleanSpace_StringWithExtraSpaces_ReturnsCleanedString()
    {
        // Arrange
        var input = "  hello   world  ";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void CleanSpace_StringWithTabs_ReturnsCleanedString()
    {
        // Arrange
        var input = "hello\t\tworld";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void CleanSpace_StringWithNewlines_ReturnsCleanedString()
    {
        // Arrange
        var input = "hello\n\nworld";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void CleanSpace_StringWithMixedWhitespace_ReturnsCleanedString()
    {
        // Arrange
        var input = "  hello \t world \n\r  test  ";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal("hello world test", result);
    }

    [Fact]
    public void CleanSpace_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<string?> { "  hello   world  ", "GOOD\t\tMORNING", null, "" };

        // Act
        input.CleanSpace();

        // Assert
        Assert.Equal(["hello world", "GOOD MORNING", null, ""], input);
    }

    [Fact]
    public void CleanSpaces_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.CleanSpaces();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CleanSpaces_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.CleanSpaces();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void CleanSpaces_CollectionWithExtraSpaces_ReturnsCleanedStrings()
    {
        // Arrange
        var input = new[] { "  hello   world  ", "GOOD\t\tMORNING", null, "" };

        // Act
        var result = input.CleanSpaces();

        // Assert
        Assert.Equal(["hello world", "GOOD MORNING", null, ""], result);
    }

    [Fact]
    public void CleanSpaces_Params_StringsWithExtraSpaces_ReturnsCleanedStrings()
    {
        // Act
        var result = YANText.CleanSpaces("  hello   world  ", "GOOD\t\tMORNING", null, "");

        // Assert
        Assert.Equal(["hello world", "GOOD MORNING", null, ""], result);
    }

    #endregion

    #region FormatName

    [Fact]
    public void FormatName_NullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FormatName_EmptyString_ReturnsEmpty()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FormatName_WhitespaceString_ReturnsWhitespace()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void FormatName_SimpleString_ReturnsFormattedName()
    {
        // Arrange
        var input = "john doe";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void FormatName_StringWithPunctuation_ReturnsFormattedName()
    {
        // Arrange
        var input = "john.doe";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void FormatName_StringWithNumbers_ReturnsFormattedNameWithoutNumbers()
    {
        // Arrange
        var input = "john123doe";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("Johndoe", result);
    }

    [Fact]
    public void FormatName_StringWithExtraSpaces_ReturnsFormattedName()
    {
        // Arrange
        var input = "  john   doe  ";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void FormatName_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<string?> { "john doe", "JANE.DOE", null, "" };

        // Act
        input.FormatName();

        // Assert
        Assert.Equal(["John Doe", "Jane Doe", null, ""], input);
    }

    [Fact]
    public void FormatNames_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FormatNames();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FormatNames_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.FormatNames();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void FormatNames_Collection_ReturnsFormattedNames()
    {
        // Arrange
        var input = new[] { "john doe", "JANE.DOE", null, "" };

        // Act
        var result = input.FormatNames();

        // Assert
        Assert.Equal(["John Doe", "Jane Doe", null, ""], result);
    }

    [Fact]
    public void FormatNames_Params_ReturnsFormattedNames()
    {
        // Act
        var result = YANText.FormatNames("john doe", "JANE.DOE", null, "");

        // Assert
        Assert.Equal(["John Doe", "Jane Doe", null, ""], result);
    }

    #endregion

    #region FilterAlphabetic

    [Fact]
    public void FilterAlphabetic_NullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphabetic_EmptyString_ReturnsEmpty()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphabetic_WhitespaceString_ReturnsEmpty()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphabetic_MixedString_ReturnsOnlyLetters()
    {
        // Arrange
        var input = "abc123!@#";

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal("abc", result);
    }

    [Fact]
    public void FilterAlphabetic_OnlyNumbers_ReturnsEmpty()
    {
        // Arrange
        var input = "12345";

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphabetic_OnlySymbols_ReturnsEmpty()
    {
        // Arrange
        var input = "!@#$%";

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphabetic_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<string?> { "abc123", "!@#DEF", null, "" };

        // Act
        input.FilterAlphabetic();

        // Assert
        Assert.Equal(["abc", "DEF", null, ""], input);
    }

    [Fact]
    public void FilterAlphabetics_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FilterAlphabetics();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphabetics_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.FilterAlphabetics();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void FilterAlphabetics_Collection_ReturnsOnlyLetters()
    {
        // Arrange
        var input = new[] { "abc123", "!@#DEF", null, "" };

        // Act
        var result = input.FilterAlphabetics();

        // Assert
        Assert.Equal(["abc", "DEF", null, ""], result);
    }

    [Fact]
    public void FilterAlphabetics_Params_ReturnsOnlyLetters()
    {
        // Act
        var result = YANText.FilterAlphabetics("abc123", "!@#DEF", null, "");

        // Assert
        Assert.Equal(["abc", "DEF", null, ""], result);
    }

    #endregion

    #region FilterNumber

    [Fact]
    public void FilterNumber_NullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterNumber_EmptyString_ReturnsEmpty()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterNumber_WhitespaceString_ReturnsEmpty()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterNumber_MixedString_ReturnsOnlyNumbers()
    {
        // Arrange
        var input = "abc123!@#";

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal("123", result);
    }

    [Fact]
    public void FilterNumber_OnlyLetters_ReturnsEmpty()
    {
        // Arrange
        var input = "abcde";

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterNumber_OnlySymbols_ReturnsEmpty()
    {
        // Arrange
        var input = "!@#$%";

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterNumber_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<string?> { "abc123", "!@#456", null, "" };

        // Act
        input.FilterNumber();

        // Assert
        Assert.Equal(["123", "456", null, ""], input);
    }

    [Fact]
    public void FilterNumbers_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FilterNumbers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterNumbers_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.FilterNumbers();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void FilterNumbers_Collection_ReturnsOnlyNumbers()
    {
        // Arrange
        var input = new[] { "abc123", "!@#456", null, "" };

        // Act
        var result = input.FilterNumbers();

        // Assert
        Assert.Equal(["123", "456", null, ""], result);
    }

    [Fact]
    public void FilterNumbers_Params_ReturnsOnlyNumbers()
    {
        // Act
        var result = YANText.FilterNumbers("abc123", "!@#456", null, "");

        // Assert
        Assert.Equal(["123", "456", null, ""], result);
    }

    #endregion

    #region FilterAlphanumeric

    [Fact]
    public void FilterAlphanumeric_NullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphanumeric_EmptyString_ReturnsEmpty()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphanumeric_WhitespaceString_ReturnsEmpty()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphanumeric_MixedString_ReturnsOnlyAlphanumeric()
    {
        // Arrange
        var input = "abc123!@#";

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal("abc123", result);
    }

    [Fact]
    public void FilterAlphanumeric_OnlySymbols_ReturnsEmpty()
    {
        // Arrange
        var input = "!@#$%";

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphanumeric_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<string?> { "abc123!@#", "DEF456$%^", null, "" };

        // Act
        input.FilterAlphanumeric();

        // Assert
        Assert.Equal(["abc123", "DEF456", null, ""], input);
    }

    [Fact]
    public void FilterAlphanumerics_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FilterAlphanumerics();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphanumerics_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.FilterAlphanumerics();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void FilterAlphanumerics_Collection_ReturnsOnlyAlphanumeric()
    {
        // Arrange
        var input = new[] { "abc123!@#", "DEF456$%^", null, "" };

        // Act
        var result = input.FilterAlphanumerics();

        // Assert
        Assert.Equal(["abc123", "DEF456", null, ""], result);
    }

    [Fact]
    public void FilterAlphanumerics_Params_ReturnsOnlyAlphanumeric()
    {
        // Act
        var result = YANText.FilterAlphanumerics("abc123!@#", "DEF456$%^", null, "");

        // Assert
        Assert.Equal(["abc123", "DEF456", null, ""], result);
    }

    #endregion
}
