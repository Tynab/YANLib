namespace YANLib.Tests.Library;

public partial class YANTextTest
{
    #region NullEmpty

    [Fact]
    public void IsNullEmpty_NullString_ReturnsTrue_String()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_EmptyString_ReturnsTrue_String()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_WhitespaceString_ReturnsFalse_String()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNullEmpty_NonEmptyString_ReturnsFalse_String()
    {
        // Arrange
        var input = "hello";

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_NullString_ReturnsFalse_String()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_EmptyString_ReturnsFalse_String()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_WhitespaceString_ReturnsTrue_String()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullEmpty_NonEmptyString_ReturnsTrue_String()
    {
        // Arrange
        var input = "hello";

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region NullWhiteSpace

    [Fact]
    public void IsNullWhiteSpace_NullString_ReturnsTrue_String()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_EmptyString_ReturnsTrue_String()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_WhitespaceString_ReturnsTrue_String()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_NonEmptyString_ReturnsFalse_String()
    {
        // Arrange
        var input = "hello";

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_NullString_ReturnsFalse_String()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_EmptyString_ReturnsFalse_String()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_WhitespaceString_ReturnsFalse_String()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_NonEmptyString_ReturnsTrue_String()
    {
        // Arrange
        var input = "hello";

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region EqualsIgnoreCase

    [Fact]
    public void EqualsIgnoreCase_BothNull_ReturnsTrue_String()
    {
        // Arrange
        string? input1 = null;
        string? input2 = null;

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_OneNull_ReturnsFalse_String()
    {
        // Arrange
        string? input1 = null;
        var input2 = "hello";

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualsIgnoreCase_BothEmpty_ReturnsTrue_String()
    {
        // Arrange
        var input1 = string.Empty;
        var input2 = string.Empty;

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_SameCase_ReturnsTrue_String()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "hello";

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_DifferentCase_ReturnsTrue_String()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "HELLO";

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_DifferentStrings_ReturnsFalse_String()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "world";

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_SameCase_ReturnsFalse_String()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "hello";

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_DifferentCase_ReturnsFalse_String()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "HELLO";

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_DifferentStrings_ReturnsTrue_String()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "world";

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Lower

    [Fact]
    public void Lower_NullString_ReturnsNull_String()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lower_EmptyString_ReturnsEmpty_String()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Lower_WhitespaceString_ReturnsWhitespace_String()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Lower_UppercaseString_ReturnsLowercase_String()
    {
        // Arrange
        var input = "HELLO WORLD";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void Lower_MixedCaseString_ReturnsLowercase_String()
    {
        // Arrange
        var input = "Hello World";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void LowerInvariant_NullString_ReturnsNull_String()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariant_UppercaseString_ReturnsLowercase_String()
    {
        // Arrange
        var input = "HELLO WORLD";

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal("hello world", result);
    }

    #endregion

    #region Upper

    [Fact]
    public void Upper_NullString_ReturnsNull_String()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Upper_EmptyString_ReturnsEmpty_String()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Upper_WhitespaceString_ReturnsWhitespace_String()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Upper_LowercaseString_ReturnsUppercase_String()
    {
        // Arrange
        var input = "hello world";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("HELLO WORLD", result);
    }

    [Fact]
    public void Upper_MixedCaseString_ReturnsUppercase_String()
    {
        // Arrange
        var input = "Hello World";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("HELLO WORLD", result);
    }

    [Fact]
    public void UpperInvariant_NullString_ReturnsNull_String()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariant_LowercaseString_ReturnsUppercase_String()
    {
        // Arrange
        var input = "hello world";

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal("HELLO WORLD", result);
    }

    #endregion
}
