using YANLib.Text;

namespace YANLib.Tests.Library.Text;

public partial class YANTextTest
{
    #region IsNullEmpty
    [Fact]
    public void IsNullEmpty_Nullable_Null_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_Nullable_DefaultChar_ReturnsTrue()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_Nullable_NonDefaultChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNullEmpty
    [Fact]
    public void AllNullEmpty_Nullable_AllNullOrDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, default };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_SomeNonNullOrDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { null, 'a' };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_Params_AllNullOrDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNullEmpty(null, default(char?));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_Params_SomeNonNullOrDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNullEmpty(null, 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNullEmpty
    [Fact]
    public void AnyNullEmpty_Nullable_SomeNullOrDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, 'a' };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_NoNullOrDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b' };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_Params_SomeNullOrDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNullEmpty(null, 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_Params_NoNullOrDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNullEmpty('a', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNullWhiteSpace
    [Fact]
    public void IsNullWhiteSpace_Nullable_Null_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_Nullable_DefaultChar_ReturnsTrue()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_Nullable_WhiteSpaceChar_ReturnsTrue()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_Nullable_NonWhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNullWhiteSpace
    [Fact]
    public void AllNullWhiteSpace_Nullable_AllNullOrWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, ' ', default, '\t' };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_SomeNonWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { null, 'a', ' ' };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_Params_AllNullOrWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNullWhiteSpace(null, ' ', default, '\t');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_Params_SomeNonWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNullWhiteSpace(null, 'a', ' ');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNullWhiteSpace
    [Fact]
    public void AnyNullWhiteSpace_Nullable_SomeNullOrWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', null, 'b' };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_NoNullOrWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_Params_SomeNullOrWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNullWhiteSpace('a', null, 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_Params_NoNullOrWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNullWhiteSpace('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsAlphabetic
    [Fact]
    public void IsAlphabetic_Nullable_LetterChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphabetic_Nullable_NonLetterChar_ReturnsFalse()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsAlphabetic_Nullable_Null_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllAlphabetic
    [Fact]
    public void AllAlphabetic_Nullable_AllLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'B' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_SomeNonLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', '1' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_SomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', null };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_Params_AllLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllAlphabetic('a', 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_Params_SomeNonLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllAlphabetic('a', '1');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_Params_SomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllAlphabetic('a', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyAlphabetic
    [Fact]
    public void AnyAlphabetic_Nullable_SomeLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', '1' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_NoLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', '2', null };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_Params_SomeLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyAlphabetic('a', '1');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_Params_NoLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyAlphabetic('1', '2', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsPunctuation
    [Fact]
    public void IsPunctuation_Nullable_PunctuationChar_ReturnsTrue()
    {
        // Arrange
        char? input = '.';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPunctuation_Nullable_NonPunctuationChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPunctuation_Nullable_Null_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllPunctuation
    [Fact]
    public void AllPunctuation_Nullable_AllPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '.', ',' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_SomeNonPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '.', 'a' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_SomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '.', null };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_Params_AllPunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllPunctuation('.', ',');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_Params_SomeNonPunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllPunctuation('.', 'a');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_Params_SomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllPunctuation('.', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyPunctuation
    [Fact]
    public void AnyPunctuation_Nullable_SomePunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '.', 'a' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_NoPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', null };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_Params_SomePunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyPunctuation('.', 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_Params_NoPunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyPunctuation('a', 'b', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNumber
    [Fact]
    public void IsNumber_Nullable_DigitChar_ReturnsTrue()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNumber_Nullable_NonDigitChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNumber_Nullable_Null_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNumber
    [Fact]
    public void AllNumber_Nullable_AllDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', '2' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_Nullable_SomeNonDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', 'a' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_Nullable_SomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', null };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_Nullable_Params_AllDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNumber('1', '2');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_Nullable_Params_SomeNonDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNumber('1', 'a');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_Nullable_Params_SomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNumber('1', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNumber
    [Fact]
    public void AnyNumber_Nullable_SomeDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', 'a' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_Nullable_NoDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', null };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_Nullable_Params_SomeDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNumber('1', 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_Nullable_Params_NoDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNumber('a', 'b', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsAlphanumeric
    [Fact]
    public void IsAlphanumeric_Nullable_LetterChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphanumeric_Nullable_DigitChar_ReturnsTrue()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphanumeric_Nullable_NonAlphanumericChar_ReturnsFalse()
    {
        // Arrange
        char? input = '.';

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsAlphanumeric_Nullable_Null_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllAlphanumeric
    [Fact]
    public void AllAlphanumeric_Nullable_AllAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'B', '1', '2' };

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphanumeric_Nullable_SomeNonAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', '1', '.' };

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_Nullable_SomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', '1', null };

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_Nullable_Params_AllAlphanumericChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllAlphanumeric('a', 'B', '1', '2');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphanumeric_Nullable_Params_SomeNonAlphanumericChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllAlphanumeric('a', '1', '.');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_Nullable_Params_SomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllAlphanumeric('a', '1', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyAlphanumeric
    [Fact]
    public void AnyAlphanumeric_Nullable_SomeAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', '.', '!' };

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphanumeric_Nullable_NoAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '.', '!', '@', null };

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphanumeric_Nullable_Params_SomeAlphanumericChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyAlphanumeric('a', '.', '!');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphanumeric_Nullable_Params_NoAlphanumericChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyAlphanumeric('.', '!', '@', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region EqualsIgnoreCase
    [Fact]
    public void EqualsIgnoreCase_Nullable_SameCharsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input1 = 'a';
        char? input2 = 'A';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_Nullable_DifferentChars_ReturnsFalse()
    {
        // Arrange
        var input1 = 'a';
        char? input2 = 'b';

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualsIgnoreCase_Nullable_NullChar_ReturnsFalse()
    {
        // Arrange
        var input1 = 'a';
        char? input2 = null;

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllEqualsIgnoreCase
    [Fact]
    public void AllEqualsIgnoreCase_Nullable_AllSameCharsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'A', 'a' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_SomeDifferentChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_SomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', null };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_Params_AllSameCharsDifferentCase_ReturnsTrue()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase('a', 'A', 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_Params_SomeDifferentChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase('a', 'b');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_Params_SomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase('a', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyEqualsIgnoreCase
    [Fact]
    public void AnyEqualsIgnoreCase_Nullable_SomeSameCharsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'A', 'b' };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Nullable_AllDifferentChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Nullable_Params_SomeSameCharsDifferentCase_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyEqualsIgnoreCase('a', 'A', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Nullable_Params_AllDifferentChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyEqualsIgnoreCase('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNullEmpty
    [Fact]
    public void IsNotNullEmpty_Nullable_NonNullNonDefaultChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullEmpty_Nullable_Null_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_Nullable_DefaultChar_ReturnsFalse()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotNullEmpty
    [Fact]
    public void AllNotNullEmpty_Nullable_AllNonNullNonDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b' };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_SomeNullOrDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', null };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_Params_AllNonNullNonDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNullEmpty('a', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_Params_SomeNullOrDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNullEmpty('a', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNullEmpty
    [Fact]
    public void AnyNotNullEmpty_Nullable_SomeNonNullNonDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', null };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_AllNullOrDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { null, default };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_Params_SomeNonNullNonDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNullEmpty('a', null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_Params_AllNullOrDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNullEmpty(null, default(char?));

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNullWhiteSpace
    [Fact]
    public void IsNotNullWhiteSpace_Nullable_NonWhiteSpaceChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_Nullable_Null_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_Nullable_DefaultChar_ReturnsFalse()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_Nullable_WhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotNullWhiteSpace
    [Fact]
    public void AllNotNullWhiteSpace_Nullable_AllNonNullNonWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_Nullable_SomeNullOrWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', ' ', 'c' };

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_Nullable_Params_AllNonNullNonWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNullWhiteSpace('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_Nullable_Params_SomeNullOrWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNullWhiteSpace('a', null, 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNullWhiteSpace
    [Fact]
    public void AnyNotNullWhiteSpace_Nullable_SomeNonNullNonWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { ' ', 'a', null };

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_Nullable_NoNonNullNonWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { ' ', '\t', null };

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_Nullable_Params_SomeNonNullNonWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNullWhiteSpace(' ', 'a', null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_Nullable_Params_NoNonNullNonWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNullWhiteSpace(' ', '\t', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotAlphabetic
    [Fact]
    public void IsNotAlphabetic_Nullable_NonLetterChar_ReturnsTrue()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotAlphabetic_Nullable_LetterChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphabetic_Nullable_Null_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AllNotAlphabetic
    [Fact]
    public void AllNotAlphabetic_Nullable_AllNonLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', '2', '3' };

        // Act
        var result = input.AllNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphabetic_Nullable_SomeLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', 'a', '3' };

        // Act
        var result = input.AllNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotAlphabetic_Nullable_Params_AllNonLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotAlphabetic('1', '2', '3');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphabetic_Nullable_Params_SomeLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotAlphabetic('1', 'a', '3');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotAlphabetic
    [Fact]
    public void AnyNotAlphabetic_Nullable_SomeNonLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', '1', 'b' };

        // Act
        var result = input.AnyNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphabetic_Nullable_NoNonLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotAlphabetic_Nullable_Params_SomeNonLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotAlphabetic('a', '1', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphabetic_Nullable_Params_NoNonLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotAlphabetic('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotPunctuation
    [Fact]
    public void IsNotPunctuation_Nullable_NonPunctuationChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotPunctuation_Nullable_PunctuationChar_ReturnsFalse()
    {
        // Arrange
        char? input = '.';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotPunctuation_Nullable_Null_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AllNotPunctuation
    [Fact]
    public void AllNotPunctuation_Nullable_AllNonPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotPunctuation_Nullable_SomePunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', '.', 'c' };

        // Act
        var result = input.AllNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotPunctuation_Nullable_Params_AllNonPunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotPunctuation('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotPunctuation_Nullable_Params_SomePunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotPunctuation('a', '.', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotPunctuation
    [Fact]
    public void AnyNotPunctuation_Nullable_SomeNonPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '.', 'a', ',' };

        // Act
        var result = input.AnyNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotPunctuation_Nullable_NoNonPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '.', ',', '!' };

        // Act
        var result = input.AnyNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotPunctuation_Nullable_Params_SomeNonPunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotPunctuation('.', 'a', ',');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotPunctuation_Nullable_Params_NoNonPunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotPunctuation('.', ',', '!');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNumber
    [Fact]
    public void IsNotNumber_Nullable_NonDigitChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNumber_Nullable_DigitChar_ReturnsFalse()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNumber_Nullable_Null_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AllNotNumber
    [Fact]
    public void AllNotNumber_Nullable_AllNonDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNumber_Nullable_SomeDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', '1', 'c' };

        // Act
        var result = input.AllNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNumber_Nullable_Params_AllNonDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNumber('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNumber_Nullable_Params_SomeDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNumber('a', '1', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNumber
    [Fact]
    public void AnyNotNumber_Nullable_SomeNonDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', 'a', '2' };

        // Act
        var result = input.AnyNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNumber_Nullable_NoNonDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', '2', '3' };

        // Act
        var result = input.AnyNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNumber_Nullable_Params_SomeNonDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNumber('1', 'a', '2');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNumber_Nullable_Params_NoNonDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNumber('1', '2', '3');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotAlphanumeric
    [Fact]
    public void IsNotAlphanumeric_Nullable_NonAlphanumericChar_ReturnsTrue()
    {
        // Arrange
        char? input = '.';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotAlphanumeric_Nullable_LetterChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphanumeric_Nullable_DigitChar_ReturnsFalse()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphanumeric_Nullable_Null_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotAlphanumeric();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AllNotAlphanumeric
    [Fact]
    public void AllNotAlphanumeric_Nullable_AllNonAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '.', '!', '@', null };

        // Act
        var result = input.AllNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphanumeric_Nullable_SomeAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '.', 'a', '!' };

        // Act
        var result = input.AllNotAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotAlphanumeric_Nullable_Params_AllNonAlphanumericChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotAlphanumeric('.', '!', '@', null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphanumeric_Nullable_Params_SomeAlphanumericChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotAlphanumeric('.', 'a', '!');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotAlphanumeric
    [Fact]
    public void AnyNotAlphanumeric_Nullable_SomeNonAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', '.', '1' };

        // Act
        var result = input.AnyNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphanumeric_Nullable_NoNonAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', '1' };

        // Act
        var result = input.AnyNotAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotAlphanumeric_Nullable_Params_SomeNonAlphanumericChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotAlphanumeric('a', '.', '1');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphanumeric_Nullable_Params_NoNonAlphanumericChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotAlphanumeric('a', 'b', '1');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region NotEqualsIgnoreCase
    [Fact]
    public void NotEqualsIgnoreCase_Nullable_DifferentChars_ReturnsTrue()
    {
        // Arrange
        char? input1 = 'a';
        char? input2 = 'b';

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_Nullable_SameCharsDifferentCase_ReturnsFalse()
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
    public void NotEqualsIgnoreCase_Nullable_NullChar_ReturnsTrue()
    {
        // Arrange
        char? input1 = 'a';
        char? input2 = null;

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AllNotEqualsIgnoreCase
    [Fact]
    public void AllNotEqualsIgnoreCase_Nullable_AllDifferentChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'C' };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Nullable_SomeSameCharsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'A', 'b' };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Nullable_Params_AllDifferentChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotEqualsIgnoreCase('a', 'b', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Nullable_Params_SomeSameCharsDifferentCase_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotEqualsIgnoreCase('a', 'A', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotEqualsIgnoreCase
    [Fact]
    public void AnyNotEqualsIgnoreCase_Nullable_SomeDifferentChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Nullable_AllSameCharsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'A', 'a' };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Nullable_Params_SomeDifferentChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotEqualsIgnoreCase('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Nullable_Params_AllSameCharsDifferentCase_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotEqualsIgnoreCase('a', 'A', 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region Lower and LowerInvariant
    [Fact]
    public void Lower_Nullable_UpperCaseChar_ReturnsLowerCaseChar()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void Lower_Nullable_WhiteSpaceChar_ReturnsSameChar()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal(' ', result);
    }

    [Fact]
    public void Lower_Nullable_Null_ReturnsNull()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lower_Nullable_List_MixedCaseChars_ModifiesListToLowerCase()
    {
        // Arrange
        var input = new List<char?> { 'A', 'b', 'C' };
        var expected = new List<char?> { 'a', 'b', 'c' };

        // Act
        input.Lower();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void Lower_Nullable_List_NullInput_DoesNotThrowException()
    {
        // Arrange
        List<char?>? input = null;

        // Act
        var exception = Record.Exception(input.Lower);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Lowers_Nullable_MixedCaseChars_ReturnsAllLowerCase()
    {
        // Arrange
        var input = new char?[] { 'A', 'b', 'C', null };

        // Act
        var result = input.Lowers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['a', 'b', 'c', null], result);
    }

    [Fact]
    public void Lowers_Nullable_NullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lowers_Nullable_Params_MixedCaseChars_ReturnsAllLowerCase()
    {
        // Act
        var result = YANText.Lowers('A', 'b', 'C', null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['a', 'b', 'c', null], result);
    }

    [Fact]
    public void LowerInvariant_Nullable_UpperCaseChar_ReturnsLowerCaseChar()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void LowerInvariant_Nullable_List_MixedCaseChars_ModifiesListToLowerCase()
    {
        // Arrange
        var input = new List<char?> { 'A', 'b', 'C', null };
        var expected = new List<char?> { 'a', 'b', 'c', null };

        // Act
        input.LowerInvariant();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void LowerInvariant_Nullable_List_NullInput_DoesNotThrowException()
    {
        // Arrange
        List<char?>? input = null;

        // Act
        var exception = Record.Exception(input.LowerInvariant);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void LowerInvariants_Nullable_MixedCaseChars_ReturnsAllLowerCase()
    {
        // Arrange
        var input = new char?[] { 'A', 'b', 'C', null };

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['a', 'b', 'c', null], result);
    }

    [Fact]
    public void LowerInvariants_Nullable_NullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariants_Nullable_Params_MixedCaseChars_ReturnsAllLowerCase()
    {
        // Act
        var result = YANText.LowerInvariants('A', 'b', 'C', null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['a', 'b', 'c', null], result);
    }
    #endregion

    #region Upper and UpperInvariant
    [Fact]
    public void Upper_Nullable_LowerCaseChar_ReturnsUpperCaseChar()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Upper_Nullable_WhiteSpaceChar_ReturnsSameChar()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal(' ', result);
    }

    [Fact]
    public void Upper_Nullable_Null_ReturnsNull()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Upper_Nullable_List_MixedCaseChars_ModifiesListToUpperCase()
    {
        // Arrange
        var input = new List<char?> { 'A', 'b', 'C', null };
        var expected = new List<char?> { 'A', 'B', 'C', null };

        // Act
        input.Upper();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void Upper_Nullable_List_NullInput_DoesNotThrowException()
    {
        // Arrange
        List<char?>? input = null;

        // Act
        var exception = Record.Exception(input.Upper);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Uppers_Nullable_MixedCaseChars_ReturnsAllUpperCase()
    {
        // Arrange
        var input = new char?[] { 'A', 'b', 'C', null };

        // Act
        var result = input.Uppers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['A', 'B', 'C', null], result);
    }

    [Fact]
    public void Uppers_Nullable_NullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Uppers_Nullable_Params_MixedCaseChars_ReturnsAllUpperCase()
    {
        // Act
        var result = YANText.Uppers('A', 'b', 'C', null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['A', 'B', 'C', null], result);
    }

    [Fact]
    public void UpperInvariant_Nullable_LowerCaseChar_ReturnsUpperCaseChar()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void UpperInvariant_Nullable_List_MixedCaseChars_ModifiesListToUpperCase()
    {
        // Arrange
        var input = new List<char?> { 'A', 'b', 'C', null };
        var expected = new List<char?> { 'A', 'B', 'C', null };

        // Act
        input.UpperInvariant();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void UpperInvariant_Nullable_List_NullInput_DoesNotThrowException()
    {
        // Arrange
        List<char?>? input = null;

        // Act
        var exception = Record.Exception(input.UpperInvariant);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void UpperInvariants_Nullable_MixedCaseChars_ReturnsAllUpperCase()
    {
        // Arrange
        var input = new char?[] { 'A', 'b', 'C', null };

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['A', 'B', 'C', null], result);
    }

    [Fact]
    public void UpperInvariants_Nullable_NullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariants_Nullable_Params_MixedCaseChars_ReturnsAllUpperCase()
    {
        // Act
        var result = YANText.UpperInvariants('A', 'b', 'C', null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['A', 'B', 'C', null], result);
    }
    #endregion

    #region IsLower
    [Fact]
    public void IsLower_Nullable_LowerCaseChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsLower_Nullable_UpperCaseChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsLower_Nullable_WhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsLower_Nullable_Null_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllLowers
    [Fact]
    public void AllLowers_Nullable_AllLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b' };

        // Act
        var result = input.AllLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllLowers_Nullable_SomeUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'B' };

        // Act
        var result = input.AllLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllLowers_Nullable_SomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', null };

        // Act
        var result = input.AllLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllLowers_Nullable_Params_AllLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllLowers('a', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllLowers_Nullable_Params_SomeUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllLowers('a', 'B');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllLowers_Nullable_Params_SomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllLowers('a', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyLowers
    [Fact]
    public void AnyLowers_Nullable_SomeLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'B' };

        // Act
        var result = input.AnyLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyLowers_Nullable_NoLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'A', 'B', null };

        // Act
        var result = input.AnyLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyLowers_Nullable_Params_SomeLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyLowers('a', 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyLowers_Nullable_Params_NoLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyLowers('A', 'B', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotLower
    [Fact]
    public void IsNotLower_Nullable_UpperCaseChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotLower_Nullable_LowerCaseChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotLower_Nullable_Null_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AllNotLowers
    [Fact]
    public void AllNotLowers_Nullable_AllNonLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'A', 'B', 'C' };

        // Act
        var result = input.AllNotLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotLowers_Nullable_SomeLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'A', 'b', 'C' };

        // Act
        var result = input.AllNotLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotLowers_Nullable_Params_AllNonLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotLowers('A', 'B', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotLowers_Nullable_Params_SomeLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotLowers('A', 'b', 'C');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotLowers
    [Fact]
    public void AnyNotLowers_Nullable_SomeNonLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'B', 'c' };

        // Act
        var result = input.AnyNotLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotLowers_Nullable_NoNonLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotLowers_Nullable_Params_SomeNonLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotLowers('a', 'B', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotLowers_Nullable_Params_NoNonLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotLowers('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsUpper
    [Fact]
    public void IsUpper_Nullable_UpperCaseChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsUpper_Nullable_LowerCaseChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsUpper_Nullable_WhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsUpper_Nullable_Null_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllUppers
    [Fact]
    public void AllUppers_Nullable_AllUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'A', 'B' };

        // Act
        var result = input.AllUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllUppers_Nullable_SomeLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'A', 'b' };

        // Act
        var result = input.AllUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllUppers_Nullable_SomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'A', null };

        // Act
        var result = input.AllUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllUppers_Nullable_Params_AllUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllUppers('A', 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllUppers_Nullable_Params_SomeLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllUppers('A', 'b');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllUppers_Nullable_Params_SomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllUppers('A', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyUppers
    [Fact]
    public void AnyUppers_Nullable_SomeUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'A', 'b' };

        // Act
        var result = input.AnyUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyUppers_Nullable_NoUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', null };

        // Act
        var result = input.AnyUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyUppers_Nullable_Params_SomeUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyUppers('A', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyUppers_Nullable_Params_NoUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyUppers('a', 'b', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotUpper
    [Fact]
    public void IsNotUpper_Nullable_LowerCaseChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotUpper_Nullable_UpperCaseChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotUpper_Nullable_Null_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AllNotUppers
    [Fact]
    public void AllNotUppers_Nullable_AllNonUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotUppers_Nullable_SomeUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'B', 'c' };

        // Act
        var result = input.AllNotUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotUppers_Nullable_Params_AllNonUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotUppers('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotUppers_Nullable_Params_SomeUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotUppers('a', 'B', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotUppers
    [Fact]
    public void AnyNotUppers_Nullable_SomeNonUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'A', 'b', 'C' };

        // Act
        var result = input.AnyNotUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotUppers_Nullable_NoNonUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'A', 'B', 'C' };

        // Act
        var result = input.AnyNotUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotUppers_Nullable_Params_SomeNonUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotUppers('A', 'b', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotUppers_Nullable_Params_NoNonUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotUppers('A', 'B', 'C');

        // Assert
        Assert.False(result);
    }
    #endregion
}
