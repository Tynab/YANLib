using YANLib.Text;

namespace YANLib.Tests.Library.Text;

public partial class YANTextTest
{
    #region IsEmpty
    [Fact]
    public void IsEmpty_WithDefaultChar_ReturnsTrue()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsEmpty_WithNonDefaultChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsEmpty();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllEmpty
    [Fact]
    public void AllEmpty_WithAllDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { default(char), default };

        // Act
        var result = input.AllEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEmpty_WithSomeNonDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { default, 'a' };

        // Act
        var result = input.AllEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEmpty_Params_WithAllDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllEmpty(default, default);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEmpty_Params_WithSomeNonDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllEmpty(default, 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyEmpty
    [Fact]
    public void AnyEmpty_WithSomeDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { default, 'a' };

        // Act
        var result = input.AnyEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEmpty_WithNoDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEmpty_Params_WithSomeDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyEmpty(default, 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEmpty_Params_WithNoDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyEmpty('a', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsWhiteSpace
    [Fact]
    public void IsWhiteSpace_WithWhiteSpaceChar_ReturnsTrue()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpace_WithNonWhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsWhiteSpace();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllWhiteSpace
    [Fact]
    public void AllWhiteSpace_WithAllWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', '\t' };

        // Act
        var result = input.AllWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpace_WithSomeNonWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', 'a' };

        // Act
        var result = input.AllWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpace_Params_WithAllWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllWhiteSpace(' ', '\t');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpace_Params_WithSomeNonWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllWhiteSpace(' ', 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyWhiteSpace
    [Fact]
    public void AnyWhiteSpace_WithSomeWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', 'a' };

        // Act
        var result = input.AnyWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpace_WithNoWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpace_Params_WithSomeWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyWhiteSpace(' ', 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpace_Params_WithNoWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyWhiteSpace('a', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsWhiteSpaceEmpty
    [Fact]
    public void IsWhiteSpaceEmpty_WithWhiteSpaceChar_ReturnsTrue()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpaceEmpty_WithEmptyChar_ReturnsTrue()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpaceEmpty_WithNonWhiteSpaceNonEmptyChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllWhiteSpaceEmpty
    [Fact]
    public void AllWhiteSpaceEmpty_WithAllWhiteSpaceOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', default, '\t' };

        // Act
        var result = input.AllWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_WithSomeNonWhiteSpaceNonEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', 'a', default };

        // Act
        var result = input.AllWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_Params_WithAllWhiteSpaceOrEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllWhiteSpaceEmpty(' ', default, '\t');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_Params_WithSomeNonWhiteSpaceNonEmptyChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllWhiteSpaceEmpty(' ', 'a', default);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyWhiteSpaceEmpty
    [Fact]
    public void AnyWhiteSpaceEmpty_WithSomeWhiteSpaceOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', ' ' };

        // Act
        var result = input.AnyWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_WithNoWhiteSpaceOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_Params_WithSomeWhiteSpaceOrEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyWhiteSpaceEmpty('a', ' ');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_Params_WithNoWhiteSpaceOrEmptyChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyWhiteSpaceEmpty('a', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsAlphabetic
    [Fact]
    public void IsAlphabetic_WithLetterChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphabetic_WithNonLetterChar_ReturnsFalse()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllAlphabetic
    [Fact]
    public void AllAlphabetic_WithAllLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'B' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_WithSomeNonLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', '1' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Params_WithAllLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllAlphabetic('a', 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_Params_WithSomeNonLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllAlphabetic('a', '1');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyAlphabetic
    [Fact]
    public void AnyAlphabetic_WithSomeLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', '1' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_WithNoLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '1', '2' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_Params_WithSomeLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyAlphabetic('a', '1');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_Params_WithNoLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyAlphabetic('1', '2');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsPunctuation
    [Fact]
    public void IsPunctuation_WithPunctuationChar_ReturnsTrue()
    {
        // Arrange
        var input = '.';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPunctuation_WithNonPunctuationChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllPunctuation
    [Fact]
    public void AllPunctuation_WithAllPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '.', ',' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_WithSomeNonPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '.', 'a' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_Params_WithAllPunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllPunctuation('.', ',');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_Params_WithSomeNonPunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllPunctuation('.', 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyPunctuation
    [Fact]
    public void AnyPunctuation_WithSomePunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '.', 'a' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_WithNoPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_Params_WithSomePunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyPunctuation('.', 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_Params_WithNoPunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyPunctuation('a', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNumber
    [Fact]
    public void IsNumber_WithDigitChar_ReturnsTrue()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNumber_WithNonDigitChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNumber
    [Fact]
    public void AllNumber_WithAllDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '1', '2' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_WithSomeNonDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '1', 'a' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_Params_WithAllDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNumber('1', '2');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_Params_WithSomeNonDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNumber('1', 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNumber
    [Fact]
    public void AnyNumber_WithSomeDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '1', 'a' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_WithNoDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_Params_WithSomeDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNumber('1', 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_Params_WithNoDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNumber('a', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region EqualsIgnoreCase
    [Fact]
    public void EqualsIgnoreCase_WithSameCharsDifferentCase_ReturnsTrue()
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
    public void EqualsIgnoreCase_WithDifferentChars_ReturnsFalse()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'b';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllEqualsIgnoreCase
    [Fact]
    public void AllEqualsIgnoreCase_WithAllSameCharsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'A', 'a' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_WithSomeDifferentChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Params_WithAllSameCharsDifferentCase_ReturnsTrue()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase('a', 'A', 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Params_WithSomeDifferentChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase('a', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyEqualsIgnoreCase
    [Fact]
    public void AnyEqualsIgnoreCase_WithSomeSameCharsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'A', 'b' };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_WithAllDifferentChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Params_WithSomeSameCharsDifferentCase_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyEqualsIgnoreCase('a', 'A', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Params_WithAllDifferentChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyEqualsIgnoreCase('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotEmpty
    [Fact]
    public void IsNotEmpty_WithNonDefaultChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotEmpty_WithDefaultChar_ReturnsFalse()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsNotEmpty();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotEmpty
    [Fact]
    public void AllNotEmpty_WithAllNonDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AllNotEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEmpty_WithSomeDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', default };

        // Act
        var result = input.AllNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEmpty_Params_WithAllNonDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotEmpty('a', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEmpty_Params_WithSomeDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotEmpty('a', default);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotEmpty
    [Fact]
    public void AnyNotEmpty_WithSomeNonDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', default };

        // Act
        var result = input.AnyNotEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEmpty_WithAllDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { default(char), default };

        // Act
        var result = input.AnyNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEmpty_Params_WithSomeNonDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotEmpty('a', default);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEmpty_Params_WithAllDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotEmpty(default, default);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotWhiteSpace
    [Fact]
    public void IsNotWhiteSpace_WithNonWhiteSpaceChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotWhiteSpace_WithWhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsNotWhiteSpace();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotWhiteSpace
    [Fact]
    public void AllNotWhiteSpace_WithAllNonWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpace_WithSomeWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', ' ', 'c' };

        // Act
        var result = input.AllNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpace_Params_WithAllNonWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotWhiteSpace('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpace_Params_WithSomeWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotWhiteSpace('a', ' ', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotWhiteSpace
    [Fact]
    public void AnyNotWhiteSpace_WithSomeNonWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', 'a', '\t' };

        // Act
        var result = input.AnyNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_WithNoNonWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', '\t', '\n' };

        // Act
        var result = input.AnyNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_Params_WithSomeNonWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotWhiteSpace(' ', 'a', '\t');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_Params_WithNoNonWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotWhiteSpace(' ', '\t', '\n');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotWhiteSpaceEmpty
    [Fact]
    public void IsNotWhiteSpaceEmpty_WithNonWhiteSpaceNonEmptyChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotWhiteSpaceEmpty_WithWhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpaceEmpty_WithEmptyChar_ReturnsFalse()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotWhiteSpaceEmpty
    [Fact]
    public void AllNotWhiteSpaceEmpty_WithAllNonWhiteSpaceNonEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_WithSomeWhiteSpaceOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', ' ', 'c' };

        // Act
        var result = input.AllNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_Params_WithAllNonWhiteSpaceNonEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotWhiteSpaceEmpty('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_Params_WithSomeWhiteSpaceOrEmptyChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotWhiteSpaceEmpty('a', ' ', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotWhiteSpaceEmpty
    [Fact]
    public void AnyNotWhiteSpaceEmpty_WithSomeNonWhiteSpaceNonEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', 'a', default };

        // Act
        var result = input.AnyNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_WithNoNonWhiteSpaceNonEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', '\t', default };

        // Act
        var result = input.AnyNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_Params_WithSomeNonWhiteSpaceNonEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotWhiteSpaceEmpty(' ', 'a', default);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_Params_WithNoNonWhiteSpaceNonEmptyChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotWhiteSpaceEmpty(' ', '\t', default);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotAlphabetic
    [Fact]
    public void IsNotAlphabetic_WithNonLetterChar_ReturnsTrue()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotAlphabetic_WithLetterChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotAlphabetic
    [Fact]
    public void AllNotAlphabetic_WithAllNonLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '1', '2', '3' };

        // Act
        var result = input.AllNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphabetic_WithSomeLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '1', 'a', '3' };

        // Act
        var result = input.AllNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotAlphabetic_Params_WithAllNonLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotAlphabetic('1', '2', '3');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphabetic_Params_WithSomeLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotAlphabetic('1', 'a', '3');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotAlphabetic
    [Fact]
    public void AnyNotAlphabetic_WithSomeNonLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', '1', 'b' };

        // Act
        var result = input.AnyNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphabetic_WithNoNonLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotAlphabetic_Params_WithSomeNonLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotAlphabetic('a', '1', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphabetic_Params_WithNoNonLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotAlphabetic('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotPunctuation
    [Fact]
    public void IsNotPunctuation_WithNonPunctuationChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotPunctuation_WithPunctuationChar_ReturnsFalse()
    {
        // Arrange
        var input = '.';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotPunctuation
    [Fact]
    public void AllNotPunctuation_WithAllNonPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotPunctuation_WithSomePunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', '.', 'c' };

        // Act
        var result = input.AllNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotPunctuation_Params_WithAllNonPunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotPunctuation('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotPunctuation_Params_WithSomePunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotPunctuation('a', '.', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotPunctuation
    [Fact]
    public void AnyNotPunctuation_WithSomeNonPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '.', 'a', ',' };

        // Act
        var result = input.AnyNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotPunctuation_WithNoNonPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '.', ',', '!' };

        // Act
        var result = input.AnyNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotPunctuation_Params_WithSomeNonPunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotPunctuation('.', 'a', ',');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotPunctuation_Params_WithNoNonPunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotPunctuation('.', ',', '!');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNumber
    [Fact]
    public void IsNotNumber_WithNonDigitChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNumber_WithDigitChar_ReturnsFalse()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotNumber
    [Fact]
    public void AllNotNumber_WithAllNonDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNumber_WithSomeDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', '1', 'c' };

        // Act
        var result = input.AllNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNumber_Params_WithAllNonDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNumber('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNumber_Params_WithSomeDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNumber('a', '1', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNumber
    [Fact]
    public void AnyNotNumber_WithSomeNonDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '1', 'a', '2' };

        // Act
        var result = input.AnyNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNumber_WithNoNonDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '1', '2', '3' };

        // Act
        var result = input.AnyNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNumber_Params_WithSomeNonDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNumber('1', 'a', '2');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNumber_Params_WithNoNonDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNumber('1', '2', '3');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region NotEqualsIgnoreCase
    [Fact]
    public void NotEqualsIgnoreCase_WithDifferentChars_ReturnsTrue()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'b';

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_WithSameCharsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input1 = 'a';
        var input2 = 'A';

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotEqualsIgnoreCase
    [Fact]
    public void AllNotEqualsIgnoreCase_WithAllDifferentChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'C' };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_WithSomeSameCharsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'A', 'b' };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Params_WithAllDifferentChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotEqualsIgnoreCase('a', 'b', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Params_WithSomeSameCharsDifferentCase_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotEqualsIgnoreCase('a', 'A', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotEqualsIgnoreCase
    [Fact]
    public void AnyNotEqualsIgnoreCase_WithSomeDifferentChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_WithAllSameCharsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'A', 'a' };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Params_WithSomeDifferentChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotEqualsIgnoreCase('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Params_WithAllSameCharsDifferentCase_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotEqualsIgnoreCase('a', 'A', 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region Lower and LowerInvariant
    [Fact]
    public void Lower_WithUpperCaseChar_ReturnsLowerCaseChar()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void Lower_WithWhiteSpaceChar_ReturnsSameChar()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal(' ', result);
    }

    [Fact]
    public void Lower_List_WithMixedCaseChars_ModifiesListToLowerCase()
    {
        // Arrange
        var input = new List<char> { 'A', 'b', 'C' };
        var expected = new List<char> { 'a', 'b', 'c' };

        // Act
        input.Lower();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void Lower_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<char>? input = null;

        // Act & Assert
        var exception = Record.Exception(input.Lower);
        Assert.Null(exception);
    }

    [Fact]
    public void Lowers_WithMixedCaseChars_ReturnsAllLowerCase()
    {
        // Arrange
        var input = new[] { 'A', 'b', 'C' };

        // Act
        var result = input.Lowers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['a', 'b', 'c'], result);
    }

    [Fact]
    public void Lowers_WithNullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lowers_Params_WithMixedCaseChars_ReturnsAllLowerCase()
    {
        // Act
        var result = YANText.Lowers('A', 'b', 'C');

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['a', 'b', 'c'], result);
    }

    [Fact]
    public void LowerInvariant_WithUpperCaseChar_ReturnsLowerCaseChar()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void LowerInvariant_List_WithMixedCaseChars_ModifiesListToLowerCase()
    {
        // Arrange
        var input = new List<char> { 'A', 'b', 'C' };
        var expected = new List<char> { 'a', 'b', 'c' };

        // Act
        input.LowerInvariant();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void LowerInvariant_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<char>? input = null;

        // Act & Assert
        var exception = Record.Exception(input.LowerInvariant);
        Assert.Null(exception);
    }

    [Fact]
    public void LowerInvariants_WithMixedCaseChars_ReturnsAllLowerCase()
    {
        // Arrange
        var input = new[] { 'A', 'b', 'C' };

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['a', 'b', 'c'], result);
    }

    [Fact]
    public void LowerInvariants_WithNullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariants_Params_WithMixedCaseChars_ReturnsAllLowerCase()
    {
        // Act
        var result = YANText.LowerInvariants('A', 'b', 'C');

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['a', 'b', 'c'], result);
    }
    #endregion

    #region Upper and UpperInvariant
    [Fact]
    public void Upper_WithLowerCaseChar_ReturnsUpperCaseChar()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Upper_WithWhiteSpaceChar_ReturnsSameChar()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal(' ', result);
    }

    [Fact]
    public void Upper_List_WithMixedCaseChars_ModifiesListToUpperCase()
    {
        // Arrange
        var input = new List<char> { 'A', 'b', 'C' };
        var expected = new List<char> { 'A', 'B', 'C' };

        // Act
        input.Upper();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void Upper_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<char>? input = null;

        // Act & Assert
        var exception = Record.Exception(input.Upper);
        Assert.Null(exception);
    }

    [Fact]
    public void Uppers_WithMixedCaseChars_ReturnsAllUpperCase()
    {
        // Arrange
        var input = new[] { 'A', 'b', 'C' };

        // Act
        var result = input.Uppers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['A', 'B', 'C'], result);
    }

    [Fact]
    public void Uppers_WithNullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Uppers_Params_WithMixedCaseChars_ReturnsAllUpperCase()
    {
        // Act
        var result = YANText.Uppers('A', 'b', 'C');

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['A', 'B', 'C'], result);
    }

    [Fact]
    public void UpperInvariant_WithLowerCaseChar_ReturnsUpperCaseChar()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void UpperInvariant_List_WithMixedCaseChars_ModifiesListToUpperCase()
    {
        // Arrange
        var input = new List<char> { 'A', 'b', 'C' };
        var expected = new List<char> { 'A', 'B', 'C' };

        // Act
        input.UpperInvariant();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void UpperInvariant_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<char>? input = null;

        // Act & Assert
        var exception = Record.Exception(input.UpperInvariant);
        Assert.Null(exception);
    }

    [Fact]
    public void UpperInvariants_WithMixedCaseChars_ReturnsAllUpperCase()
    {
        // Arrange
        var input = new[] { 'A', 'b', 'C' };

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['A', 'B', 'C'], result);
    }

    [Fact]
    public void UpperInvariants_WithNullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariants_Params_WithMixedCaseChars_ReturnsAllUpperCase()
    {
        // Act
        var result = YANText.UpperInvariants('A', 'b', 'C');

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['A', 'B', 'C'], result);
    }
    #endregion

    #region IsLower
    [Fact]
    public void IsLower_WithLowerCaseChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsLower_WithUpperCaseChar_ReturnsFalse()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsLower_WithWhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllLowers
    [Fact]
    public void AllLowers_WithAllLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AllLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllLowers_WithSomeUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'B' };

        // Act
        var result = input.AllLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllLowers_Params_WithAllLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllLowers('a', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllLowers_Params_WithSomeUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllLowers('a', 'B');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyLowers
    [Fact]
    public void AnyLowers_WithSomeLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'B' };

        // Act
        var result = input.AnyLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyLowers_WithNoLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'A', 'B' };

        // Act
        var result = input.AnyLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyLowers_Params_WithSomeLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyLowers('a', 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyLowers_Params_WithNoLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyLowers('A', 'B');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotLower
    [Fact]
    public void IsNotLower_WithUpperCaseChar_ReturnsTrue()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotLower_WithLowerCaseChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotLowers
    [Fact]
    public void AllNotLowers_WithAllNonLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'A', 'B', 'C' };

        // Act
        var result = input.AllNotLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotLowers_WithSomeLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'A', 'b', 'C' };

        // Act
        var result = input.AllNotLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotLowers_Params_WithAllNonLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotLowers('A', 'B', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotLowers_Params_WithSomeLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotLowers('A', 'b', 'C');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotLowers
    [Fact]
    public void AnyNotLowers_WithSomeNonLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'B', 'c' };

        // Act
        var result = input.AnyNotLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotLowers_WithNoNonLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotLowers_Params_WithSomeNonLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotLowers('a', 'B', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotLowers_Params_WithNoNonLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotLowers('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsUpper
    [Fact]
    public void IsUpper_WithUpperCaseChar_ReturnsTrue()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsUpper_WithLowerCaseChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsUpper_WithWhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllUppers
    [Fact]
    public void AllUppers_WithAllUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'A', 'B' };

        // Act
        var result = input.AllUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllUppers_WithSomeLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'A', 'b' };

        // Act
        var result = input.AllUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllUppers_Params_WithAllUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllUppers('A', 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllUppers_Params_WithSomeLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllUppers('A', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyUppers
    [Fact]
    public void AnyUppers_WithSomeUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'A', 'b' };

        // Act
        var result = input.AnyUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyUppers_WithNoUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyUppers_Params_WithSomeUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyUppers('A', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyUppers_Params_WithNoUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyUppers('a', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotUpper
    [Fact]
    public void IsNotUpper_WithLowerCaseChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotUpper_WithUpperCaseChar_ReturnsFalse()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotUppers
    [Fact]
    public void AllNotUppers_WithAllNonUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotUppers_WithSomeUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'B', 'c' };

        // Act
        var result = input.AllNotUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotUppers_Params_WithAllNonUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotUppers('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotUppers_Params_WithSomeUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotUppers('a', 'B', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotUppers
    [Fact]
    public void AnyNotUppers_WithSomeNonUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'A', 'b', 'C' };

        // Act
        var result = input.AnyNotUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotUppers_WithNoNonUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'A', 'B', 'C' };

        // Act
        var result = input.AnyNotUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotUppers_Params_WithSomeNonUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotUppers('A', 'b', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotUppers_Params_WithNoNonUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotUppers('A', 'B', 'C');

        // Assert
        Assert.False(result);
    }
    #endregion
}
