namespace YANLib.Tests.Library;

public partial class YANTextTest
{
    #region Title

    [Fact]
    public void Title_NullList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        List<string?>? input = null;

        // Act & Assert
        input.Title();
    }

    [Fact]
    public void Title_EmptyList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        var input = new List<string?>();

        // Act & Assert
        input.Title();
    }

    [Fact]
    public void Title_ListWithStrings_ModifiesList_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "hello world", "GOOD MORNING", "tESt StRiNg" };

        // Act
        input.Title();

        // Assert
        Assert.Equal(["Hello World", "Good Morning", "Test String"], input);
    }

    [Fact]
    public void Title_ListWithNullValues_PreservesNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "hello world", null, "tESt StRiNg" };

        // Act
        input.Title();

        // Assert
        Assert.Equal(["Hello World", null, "Test String"], input);
    }

    [Fact]
    public void Titles_NullEnumerable_ReturnsNull_TextCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Titles();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Titles_EnumerableWithStrings_ReturnsTitleCaseStrings_TextCollection()
    {
        // Arrange
        var input = new[] { "hello world", "GOOD MORNING", "tESt StRiNg" };

        // Act
        var result = input.Titles();

        // Assert
        Assert.Equal(["Hello World", "Good Morning", "Test String"], result);
    }

    [Fact]
    public void Titles_ParamsOverload_ReturnsTitleCaseStrings_TextCollection()
    {
        // Act
        var result = YANText.Titles("hello world", "GOOD MORNING", "tESt StRiNg");

        // Assert
        Assert.Equal(["Hello World", "Good Morning", "Test String"], result);
    }

    #endregion

    #region Capitalize

    [Fact]
    public void Capitalize_NullList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        List<string?>? input = null;

        // Act & Assert
        input.Capitalize();
    }

    [Fact]
    public void Capitalize_EmptyList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        var input = new List<string?>();

        // Act & Assert
        input.Capitalize();
    }

    [Fact]
    public void Capitalize_ListWithStrings_ModifiesList_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "hello world", "GOOD MORNING", "tESt StRiNg" };

        // Act
        input.Capitalize();

        // Assert
        Assert.Equal(["Hello world", "Good morning", "Test string"], input);
    }

    [Fact]
    public void Capitalize_ListWithNullValues_PreservesNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "hello world", null, "tESt StRiNg" };

        // Act
        input.Capitalize();

        // Assert
        Assert.Equal(["Hello world", null, "Test string"], input);
    }

    [Fact]
    public void Capitalizes_NullEnumerable_ReturnsNull_TextCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Capitalizes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Capitalizes_EnumerableWithStrings_ReturnsCapitalizedStrings_TextCollection()
    {
        // Arrange
        var input = new[] { "hello world", "GOOD MORNING", "tESt StRiNg" };

        // Act
        var result = input.Capitalizes();

        // Assert
        Assert.Equal(["Hello world", "Good morning", "Test string"], result);
    }

    [Fact]
    public void Capitalizes_ParamsOverload_ReturnsCapitalizedStrings_TextCollection()
    {
        // Act
        var result = YANText.Capitalizes("hello world", "GOOD MORNING", "tESt StRiNg");

        // Assert
        Assert.Equal(["Hello world", "Good morning", "Test string"], result);
    }

    #endregion

    #region CleanSpace

    [Fact]
    public void CleanSpace_NullList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        List<string?>? input = null;

        // Act & Assert
        input.CleanSpace();
    }

    [Fact]
    public void CleanSpace_EmptyList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        var input = new List<string?>();

        // Act & Assert
        input.CleanSpace();
    }

    [Fact]
    public void CleanSpace_ListWithStrings_ModifiesList_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "  hello  world  ", " GOOD  MORNING ", "\ttESt\nStRiNg\r" };

        // Act
        input.CleanSpace();

        // Assert
        Assert.Equal(["hello world", "GOOD MORNING", "tESt StRiNg"], input);
    }

    [Fact]
    public void CleanSpace_ListWithNullValues_PreservesNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "  hello  world  ", null, "\ttESt\nStRiNg\r" };

        // Act
        input.CleanSpace();

        // Assert
        Assert.Equal(["hello world", null, "tESt StRiNg"], input);
    }

    [Fact]
    public void CleanSpaces_NullEnumerable_ReturnsNull_TextCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.CleanSpaces();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CleanSpaces_EnumerableWithStrings_ReturnsCleanedStrings_TextCollection()
    {
        // Arrange
        var input = new[] { "  hello  world  ", " GOOD  MORNING ", "\ttESt\nStRiNg\r" };

        // Act
        var result = input.CleanSpaces();

        // Assert
        Assert.Equal(["hello world", "GOOD MORNING", "tESt StRiNg"], result);
    }

    [Fact]
    public void CleanSpaces_ParamsOverload_ReturnsCleanedStrings_TextCollection()
    {
        // Act
        var result = YANText.CleanSpaces("  hello  world  ", " GOOD  MORNING ", "\ttESt\nStRiNg\r");

        // Assert
        Assert.Equal(["hello world", "GOOD MORNING", "tESt StRiNg"], result);
    }

    #endregion

    #region FormatName

    [Fact]
    public void FormatName_NullList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        List<string?>? input = null;

        // Act & Assert
        input.FormatName();
    }

    [Fact]
    public void FormatName_EmptyList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        var input = new List<string?>();

        // Act & Assert
        input.FormatName();
    }

    [Fact]
    public void FormatName_ListWithStrings_ModifiesList_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "john.doe", "jane123smith", "  robert  brown  " };

        // Act
        input.FormatName();

        // Assert
        Assert.Equal(["John Doe", "Janesmith", "Robert Brown"], input);
    }

    [Fact]
    public void FormatName_ListWithNullValues_PreservesNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "john.doe", null, "  robert  brown  " };

        // Act
        input.FormatName();

        // Assert
        Assert.Equal(["John Doe", null, "Robert Brown"], input);
    }

    [Fact]
    public void FormatNames_NullEnumerable_ReturnsNull_TextCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FormatNames();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FormatNames_EnumerableWithStrings_ReturnsFormattedNames_TextCollection()
    {
        // Arrange
        var input = new[] { "john.doe", "jane123smith", "  robert  brown  " };

        // Act
        var result = input.FormatNames();

        // Assert
        Assert.Equal(["John Doe", "Janesmith", "Robert Brown"], result);
    }

    [Fact]
    public void FormatNames_ParamsOverload_ReturnsFormattedNames_TextCollection()
    {
        // Act
        var result = YANText.FormatNames("john.doe", "jane123smith", "  robert  brown  ");

        // Assert
        Assert.Equal(["John Doe", "Janesmith", "Robert Brown"], result);
    }

    #endregion

    #region FilterAlphabetic

    [Fact]
    public void FilterAlphabetic_NullList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        List<string?>? input = null;

        // Act & Assert
        input.FilterAlphabetic();
    }

    [Fact]
    public void FilterAlphabetic_EmptyList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        var input = new List<string?>();

        // Act & Assert
        input.FilterAlphabetic();
    }

    [Fact]
    public void FilterAlphabetic_ListWithStrings_ModifiesList_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "abc123", "XYZ!@#", "123!@#" };

        // Act
        input.FilterAlphabetic();

        // Assert
        Assert.Equal(["abc", "XYZ", ""], input);
    }

    [Fact]
    public void FilterAlphabetic_ListWithNullValues_PreservesNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "abc123", null, "XYZ!@#" };

        // Act
        input.FilterAlphabetic();

        // Assert
        Assert.Equal(["abc", null, "XYZ"], input);
    }

    [Fact]
    public void FilterAlphabetics_NullEnumerable_ReturnsNull_TextCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FilterAlphabetics();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphabetics_EnumerableWithStrings_ReturnsFilteredStrings_TextCollection()
    {
        // Arrange
        var input = new[] { "abc123", "XYZ!@#", "123!@#" };

        // Act
        var result = input.FilterAlphabetics();

        // Assert
        Assert.Equal(["abc", "XYZ", ""], result);
    }

    [Fact]
    public void FilterAlphabetics_ParamsOverload_ReturnsFilteredStrings_TextCollection()
    {
        // Act
        var result = YANText.FilterAlphabetics("abc123", "XYZ!@#", "123!@#");

        // Assert
        Assert.Equal(["abc", "XYZ", ""], result);
    }

    #endregion

    #region FilterNumber

    [Fact]
    public void FilterNumber_NullList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        List<string?>? input = null;

        // Act & Assert
        input.FilterNumber();
    }

    [Fact]
    public void FilterNumber_EmptyList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        var input = new List<string?>();

        // Act & Assert
        input.FilterNumber();
    }

    [Fact]
    public void FilterNumber_ListWithStrings_ModifiesList_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "abc123", "XYZ!@#", "123!@#" };

        // Act
        input.FilterNumber();

        // Assert
        Assert.Equal(["123", "", "123"], input);
    }

    [Fact]
    public void FilterNumber_ListWithNullValues_PreservesNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "abc123", null, "123!@#" };

        // Act
        input.FilterNumber();

        // Assert
        Assert.Equal(["123", null, "123"], input);
    }

    [Fact]
    public void FilterNumbers_NullEnumerable_ReturnsNull_TextCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FilterNumbers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterNumbers_EnumerableWithStrings_ReturnsFilteredStrings_TextCollection()
    {
        // Arrange
        var input = new[] { "abc123", "XYZ!@#", "123!@#" };

        // Act
        var result = input.FilterNumbers();

        // Assert
        Assert.Equal(["123", "", "123"], result);
    }

    [Fact]
    public void FilterNumbers_ParamsOverload_ReturnsFilteredStrings_TextCollection()
    {
        // Act
        var result = YANText.FilterNumbers("abc123", "XYZ!@#", "123!@#");

        // Assert
        Assert.Equal(["123", "", "123"], result);
    }

    #endregion

    #region FilterAlphanumeric

    [Fact]
    public void FilterAlphanumeric_NullList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        List<string?>? input = null;

        // Act & Assert
        input.FilterAlphanumeric();
    }

    [Fact]
    public void FilterAlphanumeric_EmptyList_DoesNotThrowException_TextCollection()
    {
        // Arrange
        var input = new List<string?>();

        // Act & Assert
        input.FilterAlphanumeric();
    }

    [Fact]
    public void FilterAlphanumeric_ListWithStrings_ModifiesList_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "abc123", "XYZ!@#", "123!@#" };

        // Act
        input.FilterAlphanumeric();

        // Assert
        Assert.Equal(["abc123", "XYZ", "123"], input);
    }

    [Fact]
    public void FilterAlphanumeric_ListWithNullValues_PreservesNulls_TextCollection()
    {
        // Arrange
        var input = new List<string?> { "abc123", null, "XYZ!@#" };

        // Act
        input.FilterAlphanumeric();

        // Assert
        Assert.Equal(["abc123", null, "XYZ"], input);
    }

    [Fact]
    public void FilterAlphanumerics_NullEnumerable_ReturnsNull_TextCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.FilterAlphanumerics();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FilterAlphanumerics_EnumerableWithStrings_ReturnsFilteredStrings_TextCollection()
    {
        // Arrange
        var input = new[] { "abc123", "XYZ!@#", "123!@#" };

        // Act
        var result = input.FilterAlphanumerics();

        // Assert
        Assert.Equal(["abc123", "XYZ", "123"], result);
    }

    [Fact]
    public void FilterAlphanumerics_ParamsOverload_ReturnsFilteredStrings_TextCollection()
    {
        // Act
        var result = YANText.FilterAlphanumerics("abc123", "XYZ!@#", "123!@#");

        // Assert
        Assert.Equal(["abc123", "XYZ", "123"], result);
    }

    #endregion
}
