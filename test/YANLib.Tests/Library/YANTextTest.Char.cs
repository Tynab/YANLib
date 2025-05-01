namespace YANLib.Tests.Library;

public partial class YANTextTest
{
    #region Empty

    [Fact]
    public void IsEmpty_DefaultChar_ReturnsTrue()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsEmpty_NonDefaultChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotEmpty_DefaultChar_ReturnsFalse()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotEmpty_NonDefaultChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotEmpty();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region WhiteSpace

    [Fact]
    public void IsWhiteSpace_Space_ReturnsTrue()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpace_Tab_ReturnsTrue()
    {
        // Arrange
        var input = '\t';

        // Act
        var result = input.IsWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpace_NewLine_ReturnsTrue()
    {
        // Arrange
        var input = '\n';

        // Act
        var result = input.IsWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpace_Letter_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpace_Space_ReturnsFalse()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpace_Tab_ReturnsFalse()
    {
        // Arrange
        var input = '\t';

        // Act
        var result = input.IsNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpace_NewLine_ReturnsFalse()
    {
        // Arrange
        var input = '\n';

        // Act
        var result = input.IsNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpace_Letter_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region WhiteSpaceEmpty

    [Fact]
    public void IsWhiteSpaceEmpty_DefaultChar_ReturnsTrue()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpaceEmpty_Space_ReturnsTrue()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpaceEmpty_Letter_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpaceEmpty_DefaultChar_ReturnsFalse()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpaceEmpty_Space_ReturnsFalse()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpaceEmpty_Letter_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Alphabetic

    [Fact]
    public void IsAlphabetic_Letter_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphabetic_UppercaseLetter_ReturnsTrue()
    {
        // Arrange
        var input = 'Z';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphabetic_Number_ReturnsFalse()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsAlphabetic_Symbol_ReturnsFalse()
    {
        // Arrange
        var input = '@';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphabetic_Letter_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphabetic_UppercaseLetter_ReturnsFalse()
    {
        // Arrange
        var input = 'Z';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphabetic_Number_ReturnsTrue()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotAlphabetic_Symbol_ReturnsTrue()
    {
        // Arrange
        var input = '@';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Punctuation

    [Fact]
    public void IsPunctuation_Period_ReturnsTrue()
    {
        // Arrange
        var input = '.';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPunctuation_Comma_ReturnsTrue()
    {
        // Arrange
        var input = ',';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPunctuation_Letter_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotPunctuation_Period_ReturnsFalse()
    {
        // Arrange
        var input = '.';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotPunctuation_Letter_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotPunctuation_Space_ReturnsTrue()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Number

    [Fact]
    public void IsNumber_Digit_ReturnsTrue()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNumber_Letter_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNumber_Digit_ReturnsFalse()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNumber_Letter_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Alphanumeric

    [Fact]
    public void IsAlphanumeric_Letter_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphanumeric_Digit_ReturnsTrue()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphanumeric_Symbol_ReturnsFalse()
    {
        // Arrange
        var input = '@';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphanumeric_Letter_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphanumeric_Digit_ReturnsFalse()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphanumeric_Symbol_ReturnsTrue()
    {
        // Arrange
        var input = '@';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region EqualsIgnoreCase

    [Fact]
    public void EqualsIgnoreCase_SameCase_ReturnsTrue()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'a';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_DifferentCase_ReturnsTrue()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'A';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_DifferentChars_ReturnsFalse()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'b';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_SameCase_ReturnsFalse()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'a';

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_DifferentCase_ReturnsFalse()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'A';

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_DifferentChars_ReturnsTrue()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'b';

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Lower

    [Fact]
    public void Lower_UppercaseLetter_ReturnsLowercase()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void Lower_LowercaseLetter_ReturnsSameChar()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void Lower_NonLetter_ReturnsSameChar()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('5', result);
    }

    [Fact]
    public void LowerInvariant_UppercaseLetter_ReturnsLowercase()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void LowerInvariant_LowercaseLetter_ReturnsSameChar()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void LowerInvariant_NonLetter_ReturnsSameChar()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal('5', result);
    }

    [Fact]
    public void IsLower_LowercaseLetter_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsLower_UppercaseLetter_ReturnsFalse()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsLower_NonLetter_ReturnsFalse()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotLower_LowercaseLetter_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotLower_UppercaseLetter_ReturnsTrue()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotLower_NonLetter_ReturnsTrue()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Upper

    [Fact]
    public void Upper_LowercaseLetter_ReturnsUppercase()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Upper_UppercaseLetter_ReturnsSameChar()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Upper_NonLetter_ReturnsSameChar()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('5', result);
    }

    [Fact]
    public void UpperInvariant_LowercaseLetter_ReturnsUppercase()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void UpperInvariant_UppercaseLetter_ReturnsSameChar()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void UpperInvariant_NonLetter_ReturnsSameChar()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal('5', result);
    }

    [Fact]
    public void IsUpper_UppercaseLetter_ReturnsTrue()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsUpper_LowercaseLetter_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsUpper_NonLetter_ReturnsFalse()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotUpper_UppercaseLetter_ReturnsFalse()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotUpper_LowercaseLetter_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotUpper_NonLetter_ReturnsTrue()
    {
        // Arrange
        var input = '5';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.True(result);
    }

    #endregion
}
