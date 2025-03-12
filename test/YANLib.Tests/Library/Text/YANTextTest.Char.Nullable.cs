using YANLib.Text;

namespace YANLib.Tests.Library.Text;

public partial class YANTextTest
{
    #region IsNullEmpty
    [Fact]
    public void IsNullEmpty_Nullable_WithNull_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_Nullable_WithDefaultChar_ReturnsTrue()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_Nullable_WithNonDefaultChar_ReturnsFalse()
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
    public void AllNullEmpty_Nullable_WithAllNullOrDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, default };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_WithSomeNonNullOrDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { null, 'a' };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_Params_WithAllNullOrDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNullEmpty(null, default(char?));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_Params_WithSomeNonNullOrDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNullEmpty(null, 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNullEmpty
    [Fact]
    public void AnyNullEmpty_Nullable_WithSomeNullOrDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, 'a' };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_WithNoNullOrDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b' };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_Params_WithSomeNullOrDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNullEmpty(null, 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_Params_WithNoNullOrDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNullEmpty('a', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNullWhiteSpace
    [Fact]
    public void IsNullWhiteSpace_Nullable_WithNull_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_Nullable_WithDefaultChar_ReturnsTrue()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_Nullable_WithWhiteSpaceChar_ReturnsTrue()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_Nullable_WithNonWhiteSpaceChar_ReturnsFalse()
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
    public void AllNullWhiteSpace_Nullable_WithAllNullOrWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, ' ', default, '\t' };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_WithSomeNonWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { null, 'a', ' ' };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_Params_WithAllNullOrWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNullWhiteSpace(null, ' ', default, '\t');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_Params_WithSomeNonWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNullWhiteSpace(null, 'a', ' ');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNullWhiteSpace
    [Fact]
    public void AnyNullWhiteSpace_Nullable_WithSomeNullOrWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', null, 'b' };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_WithNoNullOrWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_Params_WithSomeNullOrWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNullWhiteSpace('a', null, 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_Params_WithNoNullOrWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNullWhiteSpace('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsAlphabetic
    [Fact]
    public void IsAlphabetic_Nullable_WithLetterChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsAlphabetic_Nullable_WithNonLetterChar_ReturnsFalse()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsAlphabetic_Nullable_WithNull_ReturnsFalse()
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
    public void AllAlphabetic_Nullable_WithAllLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'B' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_WithSomeNonLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', '1' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_WithSomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', null };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_Params_WithAllLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllAlphabetic('a', 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_Params_WithSomeNonLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllAlphabetic('a', '1');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_Params_WithSomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllAlphabetic('a', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyAlphabetic
    [Fact]
    public void AnyAlphabetic_Nullable_WithSomeLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', '1' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_WithNoLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', '2', null };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_Params_WithSomeLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyAlphabetic('a', '1');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_Params_WithNoLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyAlphabetic('1', '2', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsPunctuation
    [Fact]
    public void IsPunctuation_Nullable_WithPunctuationChar_ReturnsTrue()
    {
        // Arrange
        char? input = '.';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPunctuation_Nullable_WithNonPunctuationChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPunctuation_Nullable_WithNull_ReturnsFalse()
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
    public void AllPunctuation_Nullable_WithAllPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '.', ',' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_WithSomeNonPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '.', 'a' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_WithSomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '.', null };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_Params_WithAllPunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllPunctuation('.', ',');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_Params_WithSomeNonPunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllPunctuation('.', 'a');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_Params_WithSomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllPunctuation('.', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyPunctuation
    [Fact]
    public void AnyPunctuation_Nullable_WithSomePunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '.', 'a' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_WithNoPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', null };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_Params_WithSomePunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyPunctuation('.', 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_Params_WithNoPunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyPunctuation('a', 'b', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNumber
    [Fact]
    public void IsNumber_Nullable_WithDigitChar_ReturnsTrue()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNumber_Nullable_WithNonDigitChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNumber_Nullable_WithNull_ReturnsFalse()
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
    public void AllNumber_Nullable_WithAllDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', '2' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_Nullable_WithSomeNonDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', 'a' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_Nullable_WithSomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', null };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_Nullable_Params_WithAllDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNumber('1', '2');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_Nullable_Params_WithSomeNonDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNumber('1', 'a');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_Nullable_Params_WithSomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNumber('1', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNumber
    [Fact]
    public void AnyNumber_Nullable_WithSomeDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', 'a' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_Nullable_WithNoDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', null };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_Nullable_Params_WithSomeDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNumber('1', 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_Nullable_Params_WithNoDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNumber('a', 'b', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region EqualsIgnoreCase
    [Fact]
    public void EqualsIgnoreCase_Nullable_WithSameCharsDifferentCase_ReturnsTrue()
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
    public void EqualsIgnoreCase_Nullable_WithDifferentChars_ReturnsFalse()
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
    public void EqualsIgnoreCase_Nullable_WithNullChar_ReturnsFalse()
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
    public void AllEqualsIgnoreCase_Nullable_WithAllSameCharsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'A', 'a' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_WithSomeDifferentChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_WithSomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', null };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_Params_WithAllSameCharsDifferentCase_ReturnsTrue()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase('a', 'A', 'a');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_Params_WithSomeDifferentChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase('a', 'b');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_Params_WithSomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase('a', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyEqualsIgnoreCase
    [Fact]
    public void AnyEqualsIgnoreCase_Nullable_WithSomeSameCharsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'A', 'b' };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Nullable_WithAllDifferentChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Nullable_Params_WithSomeSameCharsDifferentCase_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyEqualsIgnoreCase('a', 'A', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Nullable_Params_WithAllDifferentChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyEqualsIgnoreCase('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNullEmpty
    [Fact]
    public void IsNotNullEmpty_Nullable_WithNonNullNonDefaultChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullEmpty_Nullable_WithNull_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_Nullable_WithDefaultChar_ReturnsFalse()
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
    public void AllNotNullEmpty_Nullable_WithAllNonNullNonDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b' };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_WithSomeNullOrDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', null };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_Params_WithAllNonNullNonDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNullEmpty('a', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_Params_WithSomeNullOrDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNullEmpty('a', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNullEmpty
    [Fact]
    public void AnyNotNullEmpty_Nullable_WithSomeNonNullNonDefaultChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', null };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_WithAllNullOrDefaultChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { null, default };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_Params_WithSomeNonNullNonDefaultChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNullEmpty('a', null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_Params_WithAllNullOrDefaultChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNullEmpty(null, default(char?));

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNullWhiteSpace
    [Fact]
    public void IsNotNullWhiteSpace_Nullable_WithNonWhiteSpaceChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_Nullable_WithNull_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_Nullable_WithDefaultChar_ReturnsFalse()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_Nullable_WithWhiteSpaceChar_ReturnsFalse()
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
    public void AllNotNullWhiteSpace_Nullable_WithAllNonNullNonWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_Nullable_WithSomeNullOrWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', ' ', 'c' };

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_Nullable_Params_WithAllNonNullNonWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNullWhiteSpace('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_Nullable_Params_WithSomeNullOrWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNullWhiteSpace('a', null, 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNullWhiteSpace
    [Fact]
    public void AnyNotNullWhiteSpace_Nullable_WithSomeNonNullNonWhiteSpaceChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { ' ', 'a', null };

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_Nullable_WithNoNonNullNonWhiteSpaceChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { ' ', '\t', null };

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_Nullable_Params_WithSomeNonNullNonWhiteSpaceChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNullWhiteSpace(' ', 'a', null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_Nullable_Params_WithNoNonNullNonWhiteSpaceChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNullWhiteSpace(' ', '\t', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotAlphabetic
    [Fact]
    public void IsNotAlphabetic_Nullable_WithNonLetterChar_ReturnsTrue()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotAlphabetic_Nullable_WithLetterChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotAlphabetic_Nullable_WithNull_ReturnsTrue()
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
    public void AllNotAlphabetic_Nullable_WithAllNonLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', '2', '3' };

        // Act
        var result = input.AllNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphabetic_Nullable_WithSomeLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', 'a', '3' };

        // Act
        var result = input.AllNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotAlphabetic_Nullable_Params_WithAllNonLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotAlphabetic('1', '2', '3');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotAlphabetic_Nullable_Params_WithSomeLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotAlphabetic('1', 'a', '3');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotAlphabetic
    [Fact]
    public void AnyNotAlphabetic_Nullable_WithSomeNonLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', '1', 'b' };

        // Act
        var result = input.AnyNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphabetic_Nullable_WithNoNonLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotAlphabetic_Nullable_Params_WithSomeNonLetterChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotAlphabetic('a', '1', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphabetic_Nullable_Params_WithNoNonLetterChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotAlphabetic('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotPunctuation
    [Fact]
    public void IsNotPunctuation_Nullable_WithNonPunctuationChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotPunctuation_Nullable_WithPunctuationChar_ReturnsFalse()
    {
        // Arrange
        char? input = '.';

        // Act
        var result = input.IsNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotPunctuation_Nullable_WithNull_ReturnsTrue()
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
    public void AllNotPunctuation_Nullable_WithAllNonPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotPunctuation_Nullable_WithSomePunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', '.', 'c' };

        // Act
        var result = input.AllNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotPunctuation_Nullable_Params_WithAllNonPunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotPunctuation('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotPunctuation_Nullable_Params_WithSomePunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotPunctuation('a', '.', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotPunctuation
    [Fact]
    public void AnyNotPunctuation_Nullable_WithSomeNonPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '.', 'a', ',' };

        // Act
        var result = input.AnyNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotPunctuation_Nullable_WithNoNonPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '.', ',', '!' };

        // Act
        var result = input.AnyNotPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotPunctuation_Nullable_Params_WithSomeNonPunctuationChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotPunctuation('.', 'a', ',');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotPunctuation_Nullable_Params_WithNoNonPunctuationChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotPunctuation('.', ',', '!');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNumber
    [Fact]
    public void IsNotNumber_Nullable_WithNonDigitChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNumber_Nullable_WithDigitChar_ReturnsFalse()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.IsNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNumber_Nullable_WithNull_ReturnsTrue()
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
    public void AllNotNumber_Nullable_WithAllNonDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNumber_Nullable_WithSomeDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', '1', 'c' };

        // Act
        var result = input.AllNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNumber_Nullable_Params_WithAllNonDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNumber('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNumber_Nullable_Params_WithSomeDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNumber('a', '1', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNumber
    [Fact]
    public void AnyNotNumber_Nullable_WithSomeNonDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', 'a', '2' };

        // Act
        var result = input.AnyNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNumber_Nullable_WithNoNonDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', '2', '3' };

        // Act
        var result = input.AnyNotNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNumber_Nullable_Params_WithSomeNonDigitChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNumber('1', 'a', '2');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNumber_Nullable_Params_WithNoNonDigitChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNumber('1', '2', '3');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region NotEqualsIgnoreCase
    [Fact]
    public void NotEqualsIgnoreCase_Nullable_WithDifferentChars_ReturnsTrue()
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
    public void NotEqualsIgnoreCase_Nullable_WithSameCharsDifferentCase_ReturnsFalse()
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
    public void NotEqualsIgnoreCase_Nullable_WithNullChar_ReturnsTrue()
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
    public void AllNotEqualsIgnoreCase_Nullable_WithAllDifferentChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'C' };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Nullable_WithSomeSameCharsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'A', 'b' };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Nullable_Params_WithAllDifferentChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotEqualsIgnoreCase('a', 'b', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Nullable_Params_WithSomeSameCharsDifferentCase_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotEqualsIgnoreCase('a', 'A', 'b');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotEqualsIgnoreCase
    [Fact]
    public void AnyNotEqualsIgnoreCase_Nullable_WithSomeDifferentChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Nullable_WithAllSameCharsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'A', 'a' };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Nullable_Params_WithSomeDifferentChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotEqualsIgnoreCase('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Nullable_Params_WithAllSameCharsDifferentCase_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotEqualsIgnoreCase('a', 'A', 'a');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region Lower and LowerInvariant
    [Fact]
    public void Lower_Nullable_WithUpperCaseChar_ReturnsLowerCaseChar()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void Lower_Nullable_WithWhiteSpaceChar_ReturnsSameChar()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal(' ', result);
    }

    [Fact]
    public void Lower_Nullable_WithNull_ReturnsNull()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lower_Nullable_List_WithMixedCaseChars_ModifiesListToLowerCase()
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
    public void Lower_Nullable_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<char?>? input = null;

        // Act & Assert
        var exception = Record.Exception(input.Lower);
        Assert.Null(exception);
    }

    [Fact]
    public void Lowers_Nullable_WithMixedCaseChars_ReturnsAllLowerCase()
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
    public void Lowers_Nullable_WithNullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lowers_Nullable_Params_WithMixedCaseChars_ReturnsAllLowerCase()
    {
        // Act
        var result = YANText.Lowers('A', 'b', 'C', null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['a', 'b', 'c', null], result);
    }

    [Fact]
    public void LowerInvariant_Nullable_WithUpperCaseChar_ReturnsLowerCaseChar()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void LowerInvariant_Nullable_List_WithMixedCaseChars_ModifiesListToLowerCase()
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
    public void LowerInvariant_Nullable_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<char?>? input = null;

        // Act & Assert
        var exception = Record.Exception(input.LowerInvariant);
        Assert.Null(exception);
    }

    [Fact]
    public void LowerInvariants_Nullable_WithMixedCaseChars_ReturnsAllLowerCase()
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
    public void LowerInvariants_Nullable_WithNullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariants_Nullable_Params_WithMixedCaseChars_ReturnsAllLowerCase()
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
    public void Upper_Nullable_WithLowerCaseChar_ReturnsUpperCaseChar()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Upper_Nullable_WithWhiteSpaceChar_ReturnsSameChar()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal(' ', result);
    }

    [Fact]
    public void Upper_Nullable_WithNull_ReturnsNull()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Upper_Nullable_List_WithMixedCaseChars_ModifiesListToUpperCase()
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
    public void Upper_Nullable_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<char?>? input = null;

        // Act & Assert
        var exception = Record.Exception(input.Upper);
        Assert.Null(exception);
    }

    [Fact]
    public void Uppers_Nullable_WithMixedCaseChars_ReturnsAllUpperCase()
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
    public void Uppers_Nullable_WithNullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Uppers_Nullable_Params_WithMixedCaseChars_ReturnsAllUpperCase()
    {
        // Act
        var result = YANText.Uppers('A', 'b', 'C', null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(['A', 'B', 'C', null], result);
    }

    [Fact]
    public void UpperInvariant_Nullable_WithLowerCaseChar_ReturnsUpperCaseChar()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void UpperInvariant_Nullable_List_WithMixedCaseChars_ModifiesListToUpperCase()
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
    public void UpperInvariant_Nullable_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<char?>? input = null;

        // Act & Assert
        var exception = Record.Exception(input.UpperInvariant);
        Assert.Null(exception);
    }

    [Fact]
    public void UpperInvariants_Nullable_WithMixedCaseChars_ReturnsAllUpperCase()
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
    public void UpperInvariants_Nullable_WithNullInput_ReturnsDefault()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariants_Nullable_Params_WithMixedCaseChars_ReturnsAllUpperCase()
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
    public void IsLower_Nullable_WithLowerCaseChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsLower_Nullable_WithUpperCaseChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsLower_Nullable_WithWhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.IsLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsLower_Nullable_WithNull_ReturnsFalse()
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
    public void AllLowers_Nullable_WithAllLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b' };

        // Act
        var result = input.AllLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllLowers_Nullable_WithSomeUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'B' };

        // Act
        var result = input.AllLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllLowers_Nullable_WithSomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', null };

        // Act
        var result = input.AllLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllLowers_Nullable_Params_WithAllLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllLowers('a', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllLowers_Nullable_Params_WithSomeUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllLowers('a', 'B');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllLowers_Nullable_Params_WithSomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllLowers('a', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyLowers
    [Fact]
    public void AnyLowers_Nullable_WithSomeLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'B' };

        // Act
        var result = input.AnyLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyLowers_Nullable_WithNoLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'A', 'B', null };

        // Act
        var result = input.AnyLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyLowers_Nullable_Params_WithSomeLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyLowers('a', 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyLowers_Nullable_Params_WithNoLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyLowers('A', 'B', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotLower
    [Fact]
    public void IsNotLower_Nullable_WithUpperCaseChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotLower_Nullable_WithLowerCaseChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotLower();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotLower_Nullable_WithNull_ReturnsTrue()
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
    public void AllNotLowers_Nullable_WithAllNonLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'A', 'B', 'C' };

        // Act
        var result = input.AllNotLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotLowers_Nullable_WithSomeLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'A', 'b', 'C' };

        // Act
        var result = input.AllNotLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotLowers_Nullable_Params_WithAllNonLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotLowers('A', 'B', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotLowers_Nullable_Params_WithSomeLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotLowers('A', 'b', 'C');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotLowers
    [Fact]
    public void AnyNotLowers_Nullable_WithSomeNonLowerCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'B', 'c' };

        // Act
        var result = input.AnyNotLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotLowers_Nullable_WithNoNonLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotLowers_Nullable_Params_WithSomeNonLowerCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotLowers('a', 'B', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotLowers_Nullable_Params_WithNoNonLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotLowers('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsUpper
    [Fact]
    public void IsUpper_Nullable_WithUpperCaseChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsUpper_Nullable_WithLowerCaseChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsUpper_Nullable_WithWhiteSpaceChar_ReturnsFalse()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsUpper_Nullable_WithNull_ReturnsFalse()
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
    public void AllUppers_Nullable_WithAllUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'A', 'B' };

        // Act
        var result = input.AllUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllUppers_Nullable_WithSomeLowerCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'A', 'b' };

        // Act
        var result = input.AllUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllUppers_Nullable_WithSomeNullChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'A', null };

        // Act
        var result = input.AllUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllUppers_Nullable_Params_WithAllUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllUppers('A', 'B');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllUppers_Nullable_Params_WithSomeLowerCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllUppers('A', 'b');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllUppers_Nullable_Params_WithSomeNullChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllUppers('A', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyUppers
    [Fact]
    public void AnyUppers_Nullable_WithSomeUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'A', 'b' };

        // Act
        var result = input.AnyUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyUppers_Nullable_WithNoUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', null };

        // Act
        var result = input.AnyUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyUppers_Nullable_Params_WithSomeUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyUppers('A', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyUppers_Nullable_Params_WithNoUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyUppers('a', 'b', null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotUpper
    [Fact]
    public void IsNotUpper_Nullable_WithLowerCaseChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotUpper_Nullable_WithUpperCaseChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotUpper_Nullable_WithNull_ReturnsTrue()
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
    public void AllNotUppers_Nullable_WithAllNonUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotUppers_Nullable_WithSomeUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'B', 'c' };

        // Act
        var result = input.AllNotUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotUppers_Nullable_Params_WithAllNonUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotUppers('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotUppers_Nullable_Params_WithSomeUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotUppers('a', 'B', 'c');

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotUppers
    [Fact]
    public void AnyNotUppers_Nullable_WithSomeNonUpperCaseChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'A', 'b', 'C' };

        // Act
        var result = input.AnyNotUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotUppers_Nullable_WithNoNonUpperCaseChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'A', 'B', 'C' };

        // Act
        var result = input.AnyNotUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotUppers_Nullable_Params_WithSomeNonUpperCaseChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotUppers('A', 'b', 'C');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotUppers_Nullable_Params_WithNoNonUpperCaseChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotUppers('A', 'B', 'C');

        // Assert
        Assert.False(result);
    }
    #endregion
}
