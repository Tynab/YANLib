using YANLib.Text;

namespace YANLib.Tests.Library.Text;

public partial class YANTextTest
{
    #region Title
    [Fact]
    public void Title_WithNullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Title();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Title_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Title_WithWhiteSpaceString_ReturnsWhiteSpaceString()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Title_WithLowerCaseString_ReturnsTitleCaseString()
    {
        // Arrange
        var input = "hello world";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void Title_WithUpperCaseString_ReturnsTitleCaseString()
    {
        // Arrange
        var input = "HELLO WORLD";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void Title_WithMixedCaseString_ReturnsTitleCaseString()
    {
        // Arrange
        var input = "hElLo WoRlD";

        // Act
        var result = input.Title();

        // Assert
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void Title_List_WithMixedCaseStrings_ModifiesListToTitleCase()
    {
        // Arrange
        var input = new List<string?> { "hello world", "GOOD MORNING", null, "hAvE a NiCe DaY" };
        var expected = new List<string?> { "Hello World", "Good Morning", null, "Have A Nice Day" };

        // Act
        input.Title();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void Title_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.Title);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Titles_WithMixedCaseStrings_ReturnsAllTitleCase()
    {
        // Arrange
        var input = new[] { "hello world", "GOOD MORNING", null, "hAvE a NiCe DaY" };

        // Act
        var result = input.Titles();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["Hello World", "Good Morning", null, "Have A Nice Day"], result);
    }

    [Fact]
    public void Titles_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Titles();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Titles_Params_WithMixedCaseStrings_ReturnsAllTitleCase()
    {
        // Act
        var result = YANText.Titles("hello world", "GOOD MORNING", null, "hAvE a NiCe DaY");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["Hello World", "Good Morning", null, "Have A Nice Day"], result);
    }
    #endregion

    #region Capitalize
    [Fact]
    public void Capitalize_WithNullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Capitalize_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Capitalize_WithWhiteSpaceString_ReturnsWhiteSpaceString()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Capitalize_WithLowerCaseString_ReturnsCapitalizedString()
    {
        // Arrange
        var input = "hello world";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("Hello world", result);
    }

    [Fact]
    public void Capitalize_WithUpperCaseString_ReturnsCapitalizedString()
    {
        // Arrange
        var input = "HELLO WORLD";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("Hello world", result);
    }

    [Fact]
    public void Capitalize_WithMixedCaseString_ReturnsCapitalizedString()
    {
        // Arrange
        var input = "hElLo WoRlD";

        // Act
        var result = input.Capitalize();

        // Assert
        Assert.Equal("Hello world", result);
    }

    [Fact]
    public void Capitalize_List_WithMixedCaseStrings_ModifiesListToCapitalized()
    {
        // Arrange
        var input = new List<string?> { "hello world", "GOOD MORNING", null, "hAvE a NiCe DaY" };
        var expected = new List<string?> { "Hello world", "Good morning", null, "Have a nice day" };

        // Act
        input.Capitalize();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void Capitalize_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.Capitalize);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Capitalizes_WithMixedCaseStrings_ReturnsAllCapitalized()
    {
        // Arrange
        var input = new[] { "hello world", "GOOD MORNING", null, "hAvE a NiCe DaY" };

        // Act
        var result = input.Capitalizes();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["Hello world", "Good morning", null, "Have a nice day"], result);
    }

    [Fact]
    public void Capitalizes_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Capitalizes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Capitalizes_Params_WithMixedCaseStrings_ReturnsAllCapitalized()
    {
        // Act
        var result = YANText.Capitalizes("hello world", "GOOD MORNING", null, "hAvE a NiCe DaY");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["Hello world", "Good morning", null, "Have a nice day"], result);
    }
    #endregion

    #region CleanSpace
    [Fact]
    public void CleanSpace_WithNullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CleanSpace_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void CleanSpace_WithWhiteSpaceString_ReturnsEmptyString()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void CleanSpace_WithMultipleSpaces_ReturnsSingleSpaces()
    {
        // Arrange
        var input = "hello   world";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void CleanSpace_WithLeadingAndTrailingSpaces_ReturnsCleanedString()
    {
        // Arrange
        var input = "  hello world  ";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void CleanSpace_WithMultipleWhitespaceTypes_ReturnsCleanedString()
    {
        // Arrange
        var input = " hello\t\tworld\n\r ";

        // Act
        var result = input.CleanSpace();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void CleanSpace_List_WithMultipleSpacesStrings_ModifiesListToCleanedStrings()
    {
        // Arrange
        var input = new List<string?> { "hello   world", "  GOOD MORNING  ", null, "hAvE   a   NiCe   DaY" };
        var expected = new List<string?> { "hello world", "GOOD MORNING", null, "hAvE a NiCe DaY" };

        // Act
        input.CleanSpace();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void CleanSpace_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.CleanSpace);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void CleanSpaces_WithMultipleSpacesStrings_ReturnsAllCleanedStrings()
    {
        // Arrange
        var input = new[] { "hello   world", "  GOOD MORNING  ", null, "hAvE   a   NiCe   DaY" };

        // Act
        var result = input.CleanSpaces();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["hello world", "GOOD MORNING", null, "hAvE a NiCe DaY"], result);
    }

    [Fact]
    public void CleanSpaces_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.CleanSpaces();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CleanSpaces_Params_WithMultipleSpacesStrings_ReturnsAllCleanedStrings()
    {
        // Act
        var result = YANText.CleanSpaces("hello   world", "  GOOD MORNING  ", null, "hAvE   a   NiCe   DaY");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["hello world", "GOOD MORNING", null, "hAvE a NiCe DaY"], result);
    }
    #endregion

    #region FormatName
    [Fact]
    public void FormatName_WithNullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FormatName_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FormatName_WithWhiteSpaceString_ReturnsEmptyString()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal(input, result);
    }

    [Fact]
    public void FormatName_WithSimpleName_ReturnsFormattedName()
    {
        // Arrange
        var input = "john doe";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void FormatName_WithPunctuation_RemovesPunctuation()
    {
        // Arrange
        var input = "john.doe@example.com";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("John Doe Example Com", result);
    }

    [Fact]
    public void FormatName_WithNumbers_RemovesNumbers()
    {
        // Arrange
        var input = "john123 doe456";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void FormatName_WithMultipleSpaces_RemovesExtraSpaces()
    {
        // Arrange
        var input = "john   doe";

        // Act
        var result = input.FormatName();

        // Assert
        Assert.Equal("John Doe", result);
    }

    [Fact]
    public void FormatName_List_WithVariousStrings_ModifiesListToFormattedNames()
    {
        // Arrange
        var input = new List<string?> { "john doe", "JANE.DOE", null, "bob123 smith" };
        var expected = new List<string?> { "John Doe", "Jane Doe", null, "Bob Smith" };

        // Act
        input.FormatName();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void FormatName_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.FormatName);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void FormatNames_WithVariousStrings_ReturnsAllFormattedNames()
    {
        // Arrange
        var input = new[] { "john doe", "JANE.DOE", null, "bob123 smith" };

        // Act
        var result = input.FormatNames();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["John Doe", "Jane Doe", null, "Bob Smith"], result);
    }

    [Fact]
    public void FormatNames_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FormatNames();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FormatNames_Params_WithVariousStrings_ReturnsAllFormattedNames()
    {
        // Act
        var result = YANText.FormatNames("john doe", "JANE.DOE", null, "bob123 smith");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["John Doe", "Jane Doe", null, "Bob Smith"], result);
    }
    #endregion

    #region FilterAlphabetic
    [Fact]
    public void FilterAlphabetic_WithNullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphabetic_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphabetic_WithWhiteSpaceString_ReturnsEmptyString()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphabetic_WithMixedString_ReturnsOnlyLetters()
    {
        // Arrange
        var input = "abc123!@#";

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal("abc", result);
    }

    [Fact]
    public void FilterAlphabetic_WithOnlyLetters_ReturnsSameString()
    {
        // Arrange
        var input = "abcDEF";

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal("abcDEF", result);
    }

    [Fact]
    public void FilterAlphabetic_WithNoLetters_ReturnsEmptyString()
    {
        // Arrange
        var input = "123!@#";

        // Act
        var result = input.FilterAlphabetic();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphabetic_List_WithMixedStrings_ModifiesListToOnlyLetters()
    {
        // Arrange
        var input = new List<string?> { "abc123", "DEF456", null, "!@#GHI" };
        var expected = new List<string?> { "abc", "DEF", null, "GHI" };

        // Act
        input.FilterAlphabetic();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void FilterAlphabetic_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.FilterAlphabetic);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void FilterAlphabetics_WithMixedStrings_ReturnsAllOnlyLetters()
    {
        // Arrange
        var input = new[] { "abc123", "DEF456", null, "!@#GHI" };

        // Act
        var result = input.FilterAlphabetics();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["abc", "DEF", null, "GHI"], result);
    }

    [Fact]
    public void FilterAlphabetics_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FilterAlphabetics();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphabetics_Params_WithMixedStrings_ReturnsAllOnlyLetters()
    {
        // Act
        var result = YANText.FilterAlphabetics("abc123", "DEF456", null, "!@#GHI");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["abc", "DEF", null, "GHI"], result);
    }
    #endregion

    #region FilterNumber
    [Fact]
    public void FilterNumber_WithNullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterNumber_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterNumber_WithWhiteSpaceString_ReturnsEmptyString()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterNumber_WithMixedString_ReturnsOnlyNumbers()
    {
        // Arrange
        var input = "abc123!@#";

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal("123", result);
    }

    [Fact]
    public void FilterNumber_WithOnlyNumbers_ReturnsSameString()
    {
        // Arrange
        var input = "12345";

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal("12345", result);
    }

    [Fact]
    public void FilterNumber_WithNoNumbers_ReturnsEmptyString()
    {
        // Arrange
        var input = "abc!@#";

        // Act
        var result = input.FilterNumber();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterNumber_List_WithMixedStrings_ModifiesListToOnlyNumbers()
    {
        // Arrange
        var input = new List<string?> { "abc123", "DEF456", null, "!@#789" };
        var expected = new List<string?> { "123", "456", null, "789" };

        // Act
        input.FilterNumber();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void FilterNumber_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.FilterNumber);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void FilterNumbers_WithMixedStrings_ReturnsAllOnlyNumbers()
    {
        // Arrange
        var input = new[] { "abc123", "DEF456", null, "!@#789" };

        // Act
        var result = input.FilterNumbers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["123", "456", null, "789"], result);
    }

    [Fact]
    public void FilterNumbers_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FilterNumbers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterNumbers_Params_WithMixedStrings_ReturnsAllOnlyNumbers()
    {
        // Act
        var result = YANText.FilterNumbers("abc123", "DEF456", null, "!@#789");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["123", "456", null, "789"], result);
    }
    #endregion

    #region FilterAlphanumeric
    [Fact]
    public void FilterAlphanumeric_WithNullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphanumeric_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphanumeric_WithWhiteSpaceString_ReturnsEmptyString()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphanumeric_WithMixedString_ReturnsOnlyLettersAndNumbers()
    {
        // Arrange
        var input = "abc123!@#";

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal("abc123", result);
    }

    [Fact]
    public void FilterAlphanumeric_WithOnlyLettersAndNumbers_ReturnsSameString()
    {
        // Arrange
        var input = "abc123";

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal("abc123", result);
    }

    [Fact]
    public void FilterAlphanumeric_WithNoLettersOrNumbers_ReturnsEmptyString()
    {
        // Arrange
        var input = "!@#$%^";

        // Act
        var result = input.FilterAlphanumeric();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FilterAlphanumeric_List_WithMixedStrings_ModifiesListToOnlyLettersAndNumbers()
    {
        // Arrange
        var input = new List<string?> { "abc123!@#", "DEF456*&^", null, "!@#GHI789" };
        var expected = new List<string?> { "abc123", "DEF456", null, "GHI789" };

        // Act
        input.FilterAlphanumeric();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void FilterAlphanumeric_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.FilterAlphanumeric);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void FilterAlphanumerics_WithMixedStrings_ReturnsAllOnlyLettersAndNumbers()
    {
        // Arrange
        var input = new[] { "abc123!@#", "DEF456*&^", null, "!@#GHI789" };

        // Act
        var result = input.FilterAlphanumerics();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["abc123", "DEF456", null, "GHI789"], result);
    }

    [Fact]
    public void FilterAlphanumerics_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FilterAlphanumerics();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphanumerics_Params_WithMixedStrings_ReturnsAllOnlyLettersAndNumbers()
    {
        // Act
        var result = YANText.FilterAlphanumerics("abc123!@#", "DEF456*&^", null, "!@#GHI789");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["abc123", "DEF456", null, "GHI789"], result);
    }
    #endregion
}
