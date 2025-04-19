using YANLib.Text;

namespace YANLib.Tests.Library.Text;

public partial class YANTextTest
{
    #region IsEmpty
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
    #endregion

    #region AllEmpty
    [Fact]
    public void AllEmpty_AllDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { default(char), default };

        // Act
        var result = input.AllEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEmpty_SomeNonDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { default, 'a' };

        // Act
        var result = input.AllEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEmpty_Params_AllDefaultChars_ReturnsTrue()
    {
        // Arrange
        char obj = default;

        // Act
        var result = YANText.AllEmpty(obj, default);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEmpty_Params_SomeNonDefaultChars_ReturnsFalse()
    {
        // Arrange
        char obj = default;

        // Act
        var result = YANText.AllEmpty(obj, 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyEmpty
    [Fact]
    public void AnyEmpty_SomeDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { default, 'a' };

        // Act
        var result = input.AnyEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEmpty_NoDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEmpty_Params_SomeDefaultChars_ReturnsTrue()
    {
        // Arrange
        char obj = default;

        // Act
        var result = YANText.AnyEmpty(obj, 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEmpty_Params_NoDefaultChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyEmpty(obj, 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsWhiteSpace
    [Fact]
    public void IsWhiteSpace_WhiteSpaceChar_ReturnsTrue()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpace_NonWhiteSpaceChar_ReturnsFalse()
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
    public void AllWhiteSpace_AllWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', '\t' };

        // Act
        var result = input.AllWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpace_SomeNonWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', 'a' };

        // Act
        var result = input.AllWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpace_Params_AllWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var obj = ' ';

        // Act
        var result = YANText.AllWhiteSpace(obj, '\t');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpace_Params_SomeNonWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var obj = ' ';

        // Act
        var result = YANText.AllWhiteSpace(obj, 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyWhiteSpace
    [Fact]
    public void AnyWhiteSpace_SomeWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', 'a' };

        // Act
        var result = input.AnyWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpace_NoWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpace_Params_SomeWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var obj = ' ';

        // Act
        var result = YANText.AnyWhiteSpace(obj, 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpace_Params_NoWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyWhiteSpace(obj, 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsWhiteSpaceEmpty
    [Fact]
    public void IsWhiteSpaceEmpty_WhiteSpaceChar_ReturnsTrue()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpaceEmpty_EmptyChar_ReturnsTrue()
    {
        // Arrange
        char input = default;

        // Act
        var result = input.IsWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsWhiteSpaceEmpty_NonWhiteSpaceNonEmptyChar_ReturnsFalse()
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
    public void AllWhiteSpaceEmpty_AllWhiteSpaceOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', default, '\t' };

        // Act
        var result = input.AllWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_SomeNonWhiteSpaceNonEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', 'a', default };

        // Act
        var result = input.AllWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_Params_AllWhiteSpaceOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var obj = ' ';

        // Act
        var result = YANText.AllWhiteSpaceEmpty(obj, default, '\t');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_Params_SomeNonWhiteSpaceNonEmptyChars_ReturnsFalse()
    {
        // Arrange
        var obj = ' ';

        // Act
        var result = YANText.AllWhiteSpaceEmpty(obj, 'a', default);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyWhiteSpaceEmpty
    [Fact]
    public void AnyWhiteSpaceEmpty_SomeWhiteSpaceOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', ' ' };

        // Act
        var result = input.AnyWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_NoWhiteSpaceOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_Params_SomeWhiteSpaceOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyWhiteSpaceEmpty(obj, ' ');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_Params_NoWhiteSpaceOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyWhiteSpaceEmpty(obj, 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsAlphabetic
    [Fact]
    public void IsAlphabetic_LetterChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphabetic_NonLetterChar_ReturnsFalse()
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
    public void AllAlphabetic_AllLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'B' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_SomeNonLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', '1' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Params_AllLetterChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllAlphabetic(obj, 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_Params_SomeNonLetterChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllAlphabetic(obj, '1');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyAlphabetic
    [Fact]
    public void AnyAlphabetic_SomeLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', '1' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_NoLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '1', '2' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_Params_SomeLetterChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyAlphabetic(obj, '1');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_Params_NoLetterChars_ReturnsFalse()
    {
        // Arrange
        var obj = '1';

        // Act
        var result = YANText.AnyAlphabetic(obj, '2');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsPunctuation
    [Fact]
    public void IsPunctuation_PunctuationChar_ReturnsTrue()
    {
        // Arrange
        var input = '.';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPunctuation_NonPunctuationChar_ReturnsFalse()
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
    public void AllPunctuation_AllPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '.', ',' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_SomeNonPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '.', 'a' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_Params_AllPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var obj = '.';

        // Act
        var result = YANText.AllPunctuation(obj, ',');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_Params_SomeNonPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var obj = '.';

        // Act
        var result = YANText.AllPunctuation(obj, 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyPunctuation
    [Fact]
    public void AnyPunctuation_SomePunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '.', 'a' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_NoPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_Params_SomePunctuationChars_ReturnsTrue()
    {
        // Arrange
        var obj = '.';

        // Act
        var result = YANText.AnyPunctuation(obj, 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_Params_NoPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyPunctuation(obj, 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNumber
    [Fact]
    public void IsNumber_DigitChar_ReturnsTrue()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNumber_NonDigitChar_ReturnsFalse()
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
    public void AllNumber_AllDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '1', '2' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_SomeNonDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '1', 'a' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_Params_AllDigitChars_ReturnsTrue()
    {
        // Arrange
        var obj = '1';

        // Act
        var result = YANText.AllNumber(obj, '2');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_Params_SomeNonDigitChars_ReturnsFalse()
    {
        // Arrange
        var obj = '1';

        // Act
        var result = YANText.AllNumber(obj, 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNumber
    [Fact]
    public void AnyNumber_SomeDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '1', 'a' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_NoDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_Params_SomeDigitChars_ReturnsTrue()
    {
        // Arrange
        var obj = '1';

        // Act
        var result = YANText.AnyNumber(obj, 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_Params_NoDigitChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyNumber(obj, 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsAlphanumeric
    [Fact]
    public void IsAlphanumeric_LetterChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphanumeric_DigitChar_ReturnsTrue()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphanumeric_NonAlphanumericChar_ReturnsFalse()
    {
        // Arrange
        var input = '.';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllAlphanumeric
    [Fact]
    public void AllAlphanumeric_AllAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'B', '1', '2' };

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphanumeric_SomeNonAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', '1', '.' };

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_Params_AllAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllAlphanumeric(obj, 'B', '1', '2');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphanumeric_Params_SomeNonAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllAlphanumeric(obj, '1', '.');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyAlphanumeric
    [Fact]
    public void AnyAlphanumeric_SomeAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', '.', '!' };

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphanumeric_NoAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '.', '!', '@' };

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphanumeric_Params_SomeAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyAlphanumeric(obj, '.', '!');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphanumeric_Params_NoAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var obj = '.';

        // Act
        var result = YANText.AnyAlphanumeric(obj, '!', '@');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region EqualsIgnoreCase
    [Fact]
    public void EqualsIgnoreCase_SameCharsDifferentCase_ReturnsTrue()
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
    #endregion

    #region AllEqualsIgnoreCase
    [Fact]
    public void AllEqualsIgnoreCase_AllSameCharsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'A', 'a' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_SomeDifferentChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Params_AllSameCharsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllEqualsIgnoreCase(obj, 'A', 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Params_SomeDifferentChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllEqualsIgnoreCase(obj, 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyEqualsIgnoreCase
    [Fact]
    public void AnyEqualsIgnoreCase_SomeSameCharsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'A', 'b' };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_AllDifferentChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Params_SomeSameCharsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyEqualsIgnoreCase(obj, 'A', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Params_AllDifferentChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyEqualsIgnoreCase(obj, 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotEmpty
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
    #endregion

    #region AllNotEmpty
    [Fact]
    public void AllNotEmpty_AllNonDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AllNotEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEmpty_SomeDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', default };

        // Act
        var result = input.AllNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEmpty_Params_AllNonDefaultChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotEmpty(obj, 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEmpty_Params_SomeDefaultChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotEmpty(obj, default);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotEmpty
    [Fact]
    public void AnyNotEmpty_SomeNonDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', default };

        // Act
        var result = input.AnyNotEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEmpty_AllDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { default(char), default };

        // Act
        var result = input.AnyNotEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEmpty_Params_SomeNonDefaultChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyNotEmpty(obj, default);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEmpty_Params_AllDefaultChars_ReturnsFalse()
    {
        // Arrange
        char obj = default;

        // Act
        var result = YANText.AnyNotEmpty(obj, default);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotWhiteSpace
    [Fact]
    public void IsNotWhiteSpace_NonWhiteSpaceChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotWhiteSpace_WhiteSpaceChar_ReturnsFalse()
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
    public void AllNotWhiteSpace_AllNonWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpace_SomeWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', ' ', 'c' };

        // Act
        var result = input.AllNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpace_Params_AllNonWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotWhiteSpace(obj, 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpace_Params_SomeWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotWhiteSpace(obj, ' ', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotWhiteSpace
    [Fact]
    public void AnyNotWhiteSpace_SomeNonWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', 'a', '\t' };

        // Act
        var result = input.AnyNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_NoNonWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', '\t', '\n' };

        // Act
        var result = input.AnyNotWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_Params_SomeNonWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var obj = ' ';

        // Act
        var result = YANText.AnyNotWhiteSpace(obj, 'a', '\t');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_Params_NoNonWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var obj = ' ';

        // Act
        var result = YANText.AnyNotWhiteSpace(obj, '\t', '\n');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotWhiteSpaceEmpty
    [Fact]
    public void IsNotWhiteSpaceEmpty_NonWhiteSpaceNonEmptyChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotWhiteSpaceEmpty_WhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.IsNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotWhiteSpaceEmpty_EmptyChar_ReturnsFalse()
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
    public void AllNotWhiteSpaceEmpty_AllNonWhiteSpaceNonEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_SomeWhiteSpaceOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', ' ', 'c' };

        // Act
        var result = input.AllNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_Params_AllNonWhiteSpaceNonEmptyChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotWhiteSpaceEmpty(obj, 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_Params_SomeWhiteSpaceOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotWhiteSpaceEmpty(obj, ' ', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotWhiteSpaceEmpty
    [Fact]
    public void AnyNotWhiteSpaceEmpty_SomeNonWhiteSpaceNonEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { ' ', 'a', default };

        // Act
        var result = input.AnyNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_NoNonWhiteSpaceNonEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { ' ', '\t', default };

        // Act
        var result = input.AnyNotWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_Params_SomeNonWhiteSpaceNonEmptyChars_ReturnsTrue()
    {
        // Arrange
        var obj = ' ';

        // Act
        var result = YANText.AnyNotWhiteSpaceEmpty(obj, 'a', default);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_Params_NoNonWhiteSpaceNonEmptyChars_ReturnsFalse()
    {
        // Arrange
        var obj = ' ';

        // Act
        var result = YANText.AnyNotWhiteSpaceEmpty(obj, '\t', default);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotAlphabetic
    [Fact]
    public void IsNotAlphabetic_NonLetterChar_ReturnsTrue()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotAlphabetic_LetterChar_ReturnsFalse()
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
    public void AllNotAlphabetic_AllNonLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '1', '2', '3' };

        // Act
        var result = input.AllNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphabetic_SomeLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '1', 'a', '3' };

        // Act
        var result = input.AllNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotAlphabetic_Params_AllNonLetterChars_ReturnsTrue()
    {
        // Arrange
        var obj = '1';

        // Act
        var result = YANText.AllNotAlphabetic(obj, '2', '3');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphabetic_Params_SomeLetterChars_ReturnsFalse()
    {
        // Arrange
        var obj = '1';

        // Act
        var result = YANText.AllNotAlphabetic(obj, 'a', '3');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotAlphabetic
    [Fact]
    public void AnyNotAlphabetic_SomeNonLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', '1', 'b' };

        // Act
        var result = input.AnyNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphabetic_NoNonLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotAlphabetic_Params_SomeNonLetterChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyNotAlphabetic(obj, '1', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphabetic_Params_NoNonLetterChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyNotAlphabetic(obj, 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotPunctuation
    [Fact]
    public void IsNotPunctuation_NonPunctuationChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotPunctuation_PunctuationChar_ReturnsFalse()
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
    public void AllNotPunctuation_AllNonPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotPunctuation_SomePunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', '.', 'c' };

        // Act
        var result = input.AllNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotPunctuation_Params_AllNonPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotPunctuation(obj, 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotPunctuation_Params_SomePunctuationChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotPunctuation(obj, '.', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotPunctuation
    [Fact]
    public void AnyNotPunctuation_SomeNonPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '.', 'a', ',' };

        // Act
        var result = input.AnyNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotPunctuation_NoNonPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '.', ',', '!' };

        // Act
        var result = input.AnyNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotPunctuation_Params_SomeNonPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var obj = '.';

        // Act
        var result = YANText.AnyNotPunctuation(obj, 'a', ',');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotPunctuation_Params_NoNonPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var obj = '.';

        // Act
        var result = YANText.AnyNotPunctuation(obj, ',', '!');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNumber
    [Fact]
    public void IsNotNumber_NonDigitChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNumber_DigitChar_ReturnsFalse()
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
    public void AllNotNumber_AllNonDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNumber_SomeDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', '1', 'c' };

        // Act
        var result = input.AllNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNumber_Params_AllNonDigitChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotNumber(obj, 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNumber_Params_SomeDigitChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotNumber(obj, '1', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNumber
    [Fact]
    public void AnyNotNumber_SomeNonDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '1', 'a', '2' };

        // Act
        var result = input.AnyNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNumber_NoNonDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '1', '2', '3' };

        // Act
        var result = input.AnyNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNumber_Params_SomeNonDigitChars_ReturnsTrue()
    {
        // Arrange
        var obj = '1';

        // Act
        var result = YANText.AnyNotNumber(obj, 'a', '2');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNumber_Params_NoNonDigitChars_ReturnsFalse()
    {
        // Arrange
        var obj = '1';

        // Act
        var result = YANText.AnyNotNumber(obj, '2', '3');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotAlphanumeric
    [Fact]
    public void IsNotAlphanumeric_NonAlphanumericChar_ReturnsTrue()
    {
        // Arrange
        var input = '.';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotAlphanumeric_LetterChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphanumeric_DigitChar_ReturnsFalse()
    {
        // Arrange
        var input = '1';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotAlphanumeric
    [Fact]
    public void AllNotAlphanumeric_AllNonAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { '.', '!', '@' };

        // Act
        var result = input.AllNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphanumeric_SomeAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { '.', 'a', '!' };

        // Act
        var result = input.AllNotAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotAlphanumeric_Params_AllNonAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var obj = '.';

        // Act
        var result = YANText.AllNotAlphanumeric(obj, '!', '@');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphanumeric_Params_SomeAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var obj = '.';

        // Act
        var result = YANText.AllNotAlphanumeric(obj, 'a', '!');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotAlphanumeric
    [Fact]
    public void AnyNotAlphanumeric_SomeNonAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', '.', '1' };

        // Act
        var result = input.AnyNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphanumeric_NoNonAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', '1' };

        // Act
        var result = input.AnyNotAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotAlphanumeric_Params_SomeNonAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyNotAlphanumeric(obj, '.', '1');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphanumeric_Params_NoNonAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyNotAlphanumeric(obj, 'b', '1');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region NotEqualsIgnoreCase
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

    [Fact]
    public void NotEqualsIgnoreCase_SameCharsDifferentCase_ReturnsFalse()
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
    public void AllNotEqualsIgnoreCase_AllDifferentChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'C' };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_SomeSameCharsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'A', 'b' };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Params_AllDifferentChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotEqualsIgnoreCase(obj, 'b', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Params_SomeSameCharsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotEqualsIgnoreCase(obj, 'A', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotEqualsIgnoreCase
    [Fact]
    public void AnyNotEqualsIgnoreCase_SomeDifferentChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_AllSameCharsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'A', 'a' };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Params_SomeDifferentChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyNotEqualsIgnoreCase(obj, 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Params_AllSameCharsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyNotEqualsIgnoreCase(obj, 'A', 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region Lower
    [Fact]
    public void Lower_UpperCaseChar_ReturnsLowerCaseChar()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void Lower_WhiteSpaceChar_ReturnsSameChar()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal(' ', result);
    }

    [Fact]
    public void Lower_List_MixedCaseChars_ModifiesListToLowerCase()
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
    public void Lower_List_NullInput_NotThrowException()
    {
        // Arrange
        List<char>? input = null;

        // Act
        var exception = Record.Exception(input.Lower);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Lowers_MixedCaseChars_ReturnsAllLowerCase()
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
    public void Lowers_NullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lowers_Params_MixedCaseChars_ReturnsAllLowerCase()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.Lowers(obj, 'b', 'C');

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['a', 'b', 'c'], result);
    }
    #endregion

    #region LowerInvariant
    [Fact]
    public void LowerInvariant_UpperCaseChar_ReturnsLowerCaseChar()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void LowerInvariant_List_MixedCaseChars_ModifiesListToLowerCase()
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
    public void LowerInvariant_List_NullInput_NotThrowException()
    {
        // Arrange
        List<char>? input = null;

        // Act
        var exception = Record.Exception(input.LowerInvariant);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void LowerInvariants_MixedCaseChars_ReturnsAllLowerCase()
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
    public void LowerInvariants_NullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariants_Params_MixedCaseChars_ReturnsAllLowerCase()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.LowerInvariants(obj, 'b', 'C');

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['a', 'b', 'c'], result);
    }
    #endregion

    #region Upper
    [Fact]
    public void Upper_LowerCaseChar_ReturnsUpperCaseChar()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Upper_WhiteSpaceChar_ReturnsSameChar()
    {
        // Arrange
        var input = ' ';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal(' ', result);
    }

    [Fact]
    public void Upper_List_MixedCaseChars_ModifiesListToUpperCase()
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
    public void Upper_List_NullInput_NotThrowException()
    {
        // Arrange
        List<char>? input = null;

        // Act
        var exception = Record.Exception(input.Upper);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Uppers_MixedCaseChars_ReturnsAllUpperCase()
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
    public void Uppers_NullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Uppers_Params_MixedCaseChars_ReturnsAllUpperCase()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.Uppers(obj, 'b', 'C');

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['A', 'B', 'C'], result);
    }
    #endregion

    #region UpperInvariant
    [Fact]
    public void UpperInvariant_LowerCaseChar_ReturnsUpperCaseChar()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void UpperInvariant_List_MixedCaseChars_ModifiesListToUpperCase()
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
    public void UpperInvariant_List_NullInput_NotThrowException()
    {
        // Arrange
        List<char>? input = null;

        // Act
        var exception = Record.Exception(input.UpperInvariant);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void UpperInvariants_MixedCaseChars_ReturnsAllUpperCase()
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
    public void UpperInvariants_NullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char>? input = null;

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariants_Params_MixedCaseChars_ReturnsAllUpperCase()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.UpperInvariants(obj, 'b', 'C');

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['A', 'B', 'C'], result);
    }
    #endregion

    #region IsLower
    [Fact]
    public void IsLower_LowerCaseChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsLower_UpperCaseChar_ReturnsFalse()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsLower_WhiteSpaceChar_ReturnsFalse()
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
    public void AllLowers_AllLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AllLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllLowers_SomeUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'B' };

        // Act
        var result = input.AllLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllLowers_Params_AllLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllLowers(obj, 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllLowers_Params_SomeUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllLowers(obj, 'B');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyLowers
    [Fact]
    public void AnyLowers_SomeLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'B' };

        // Act
        var result = input.AnyLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyLowers_NoLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'A', 'B' };

        // Act
        var result = input.AnyLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyLowers_Params_SomeLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyLowers(obj, 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyLowers_Params_NoLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.AnyLowers(obj, 'B');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotLower
    [Fact]
    public void IsNotLower_UpperCaseChar_ReturnsTrue()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotLower_LowerCaseChar_ReturnsFalse()
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
    public void AllNotLowers_AllNonLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'A', 'B', 'C' };

        // Act
        var result = input.AllNotLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotLowers_SomeLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'A', 'b', 'C' };

        // Act
        var result = input.AllNotLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotLowers_Params_AllNonLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.AllNotLowers(obj, 'B', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotLowers_Params_SomeLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.AllNotLowers(obj, 'b', 'C');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotLowers
    [Fact]
    public void AnyNotLowers_SomeNonLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'B', 'c' };

        // Act
        var result = input.AnyNotLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotLowers_NoNonLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotLowers_Params_SomeNonLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyNotLowers(obj, 'B', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotLowers_Params_NoNonLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyNotLowers(obj, 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsUpper
    [Fact]
    public void IsUpper_UpperCaseChar_ReturnsTrue()
    {
        // Arrange
        var input = 'A';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsUpper_LowerCaseChar_ReturnsFalse()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsUpper_WhiteSpaceChar_ReturnsFalse()
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
    public void AllUppers_AllUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'A', 'B' };

        // Act
        var result = input.AllUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllUppers_SomeLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'A', 'b' };

        // Act
        var result = input.AllUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllUppers_Params_AllUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.AllUppers(obj, 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllUppers_Params_SomeLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.AllUppers(obj, 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyUppers
    [Fact]
    public void AnyUppers_SomeUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'A', 'b' };

        // Act
        var result = input.AnyUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyUppers_NoUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'b' };

        // Act
        var result = input.AnyUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyUppers_Params_SomeUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.AnyUppers(obj, 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyUppers_Params_NoUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AnyUppers(obj, 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotUpper
    [Fact]
    public void IsNotUpper_LowerCaseChar_ReturnsTrue()
    {
        // Arrange
        var input = 'a';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotUpper_UpperCaseChar_ReturnsFalse()
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
    public void AllNotUppers_AllNonUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotUppers_SomeUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'a', 'B', 'c' };

        // Act
        var result = input.AllNotUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotUppers_Params_AllNonUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotUppers(obj, 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotUppers_Params_SomeUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'a';

        // Act
        var result = YANText.AllNotUppers(obj, 'B', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotUppers
    [Fact]
    public void AnyNotUppers_SomeNonUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new[] { 'A', 'b', 'C' };

        // Act
        var result = input.AnyNotUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotUppers_NoNonUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new[] { 'A', 'B', 'C' };

        // Act
        var result = input.AnyNotUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotUppers_Params_SomeNonUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.AnyNotUppers(obj, 'b', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotUppers_Params_NoNonUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var obj = 'A';

        // Act
        var result = YANText.AnyNotUppers(obj, 'B', 'C');

        // Assert
        Assert.False(result);
    }
    #endregion
}
