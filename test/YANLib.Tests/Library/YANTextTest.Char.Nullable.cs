namespace YANLib.Tests.Library;

public partial class YANTextTest
{
    #region NullEmpty

    [Fact]
    public void IsNullEmpty_NullChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_DefaultChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_NonDefaultChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_NullChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_NonDefaultChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullEmpty_DefaultChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region NullWhiteSpace

    [Fact]
    public void IsNullWhiteSpace_NullChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_DefaultChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_WhitespaceChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_NonWhitespaceChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_NullChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_DefaultChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_WhitespaceChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_NonWhitespaceChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Alphabetic

    [Fact]
    public void IsAlphabetic_NullChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsAlphabetic_Letter_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphabetic_NonLetter_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = '5';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphabetic_NullChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotAlphabetic_Letter_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphabetic_NonLetter_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = '5';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Punctuation

    [Fact]
    public void IsPunctuation_NullChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPunctuation_PunctuationChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = '.';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPunctuation_NonPunctuationChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotPunctuation_NullChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotPunctuation_PunctuationChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = '.';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotPunctuation_NonPunctuationChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Number

    [Fact]
    public void IsNumber_NullChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNumber_Digit_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = '5';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNumber_NonDigit_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNumber_NullChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNumber_Digit_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = '5';

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNumber_NonDigit_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Alphanumeric

    [Fact]
    public void IsAlphanumeric_NullChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsAlphanumeric_Letter_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphanumeric_Digit_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = '5';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphanumeric_Symbol_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = '@';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphanumeric_NullChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotAlphanumeric_Letter_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphanumeric_Digit_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = '5';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphanumeric_Symbol_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = '@';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region EqualsIgnoreCase

    [Fact]
    public void EqualsIgnoreCase_BothNull_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input1 = null;
        char? input2 = null;

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_OneNull_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input1 = null;
        char? input2 = 'a';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualsIgnoreCase_SameCase_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input1 = 'a';
        char? input2 = 'a';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_DifferentCase_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input1 = 'a';
        char? input2 = 'A';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_DifferentChars_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input1 = 'a';
        char? input2 = 'b';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_BothNull_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input1 = null;
        char? input2 = null;

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_OneNull_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input1 = null;
        char? input2 = 'a';

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_SameCase_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input1 = 'a';
        char? input2 = 'a';

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_DifferentCase_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input1 = 'a';
        char? input2 = 'A';

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_DifferentChars_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input1 = 'a';
        char? input2 = 'b';

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Lower

    [Fact]
    public void Lower_NullChar_ReturnsNull_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lower_UppercaseLetter_ReturnsLowercase_Nullable()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void Lower_LowercaseLetter_ReturnsSameChar_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void LowerInvariant_NullChar_ReturnsNull_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariant_UppercaseLetter_ReturnsLowercase_Nullable()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void LowerInvariant_LowercaseLetter_ReturnsSameChar_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void IsLower_NullChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsLower_LowercaseLetter_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsLower_UppercaseLetter_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotLower_NullChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotLower_LowercaseLetter_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotLower_UppercaseLetter_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Upper

    [Fact]
    public void Upper_NullChar_ReturnsNull_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Upper_LowercaseLetter_ReturnsUppercase_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Upper_UppercaseLetter_ReturnsSameChar_Nullable()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void UpperInvariant_NullChar_ReturnsNull_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariant_LowercaseLetter_ReturnsUppercase_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void UpperInvariant_UppercaseLetter_ReturnsSameChar_Nullable()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void IsUpper_NullChar_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsUpper_UppercaseLetter_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsUpper_LowercaseLetter_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotUpper_NullChar_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotUpper_UppercaseLetter_ReturnsFalse_Nullable()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotUpper_LowercaseLetter_ReturnsTrue_Nullable()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.True(result);
    }

    #endregion
}
