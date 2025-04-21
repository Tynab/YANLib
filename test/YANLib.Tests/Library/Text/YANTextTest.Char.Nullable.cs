using YANLib.Text;

namespace YANLib.Tests.Library.Text;

public partial class YANTextTest
{
    #region NullEmpty

    [Fact]
    public void IsNullEmpty_Nullable_NullChar_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_Nullable_EmptyChar_ReturnsTrue()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_Nullable_NonEmptyChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_AllNullOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, default(char), null };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { null, 'a', default(char) };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_NoNullOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_Params_AllNullOrEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNullEmpty(null, default(char), null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_Nullable_Params_MixedChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNullEmpty(null, 'a', default(char));

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_AllNullOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, default(char), null };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, 'a', 'b' };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_NoNullOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_Params_MixedChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNullEmpty(null, 'a', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_Nullable_Params_NoNullOrEmptyChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNullEmpty('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_Nullable_NullChar_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_Nullable_EmptyChar_ReturnsFalse()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_Nullable_NonEmptyChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_AllNullOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { null, default(char), null };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { null, 'a', 'b' };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_NoNullOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_Params_NoNullOrEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNullEmpty('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_Nullable_Params_MixedChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNullEmpty(null, 'a', 'b');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_AllNullOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { null, default(char), null };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, 'a', 'b' };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_NoNullOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_Params_MixedChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNullEmpty(null, 'a', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Nullable_Params_NoNullOrEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNullEmpty('a', 'b', 'c');

        // Assert
        Assert.True(result);
    }

    #endregion

    #region NullWhiteSpace

    [Fact]
    public void IsNullWhiteSpace_Nullable_NullChar_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_Nullable_EmptyChar_ReturnsTrue()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_Nullable_WhitespaceChar_ReturnsTrue()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_Nullable_NonWhitespaceChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_AllNullWhitespaceOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, ' ', default(char) };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { null, 'a', ' ' };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_NoNullWhitespaceOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_Params_AllNullWhitespaceOrEmptyChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNullWhiteSpace(null, ' ', default(char));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Nullable_Params_MixedChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNullWhiteSpace(null, 'a', ' ');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_AllNullWhitespaceOrEmptyChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, ' ', default(char) };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { null, 'a', 'b' };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_NoNullWhitespaceOrEmptyChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_Params_MixedChars_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNullWhiteSpace(null, 'a', 'b');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Nullable_Params_NoNullWhitespaceOrEmptyChars_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNullWhiteSpace('a', 'b', 'c');

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_Nullable_NullChar_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_Nullable_EmptyChar_ReturnsFalse()
    {
        // Arrange
        char? input = default(char);

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_Nullable_WhitespaceChar_ReturnsFalse()
    {
        // Arrange
        char? input = ' ';

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_Nullable_NonWhitespaceChar_ReturnsTrue()
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
    public void IsAlphabetic_Nullable_NullChar_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsAlphabetic();

        // Assert
        Assert.False(result);
    }

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
    public void AllAlphabetic_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_AllLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', '1', 'b' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_Nullable_WithNullChar_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', null, 'b' };

        // Act
        var result = input.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_AllLetterChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', '1', '2' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_WithNullChar_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', null, '1' };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_Nullable_NoLetterChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', '2', '3', null };

        // Act
        var result = input.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Punctuation

    [Fact]
    public void IsPunctuation_Nullable_NullChar_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsPunctuation();

        // Assert
        Assert.False(result);
    }

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
    public void AllPunctuation_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_AllPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '.', ',', '!' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '.', 'a', ',' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_Nullable_WithNullChar_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '.', null, ',' };

        // Act
        var result = input.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_AllPunctuationChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '.', ',', '!' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '.', 'a', 'b' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_WithNullChar_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '.', null, 'a' };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_Nullable_NoPunctuationChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c', null };

        // Act
        var result = input.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Number

    [Fact]
    public void IsNumber_Nullable_NullChar_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNumber_Nullable_DigitChar_ReturnsTrue()
    {
        // Arrange
        char? input = '5';

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
    public void AllNumber_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_Nullable_AllDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', '2', '3' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_Nullable_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', 'a', '2' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_Nullable_WithNullChar_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '1', null, '2' };

        // Act
        var result = input.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_Nullable_AllDigitChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', '2', '3' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_Nullable_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', 'a', 'b' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_Nullable_WithNullChar_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { '1', null, 'a' };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_Nullable_NoDigitChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'c', null };

        // Act
        var result = input.AnyNumber();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Alphanumeric

    [Fact]
    public void IsAlphanumeric_Nullable_NullChar_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsAlphanumeric();

        // Assert
        Assert.False(result);
    }

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
        char? input = '5';

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
    public void AllAlphanumeric_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_Nullable_AllAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', '1', 'b' };

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphanumeric_Nullable_MixedChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', '.', '1' };

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_Nullable_WithNullChar_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', null, '1' };

        // Act
        var result = input.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphanumeric_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphanumeric_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphanumeric_Nullable_AllAlphanumericChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', '1', 'b' };

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphanumeric_Nullable_MixedChars_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', '.', '!' };

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphanumeric_Nullable_WithNullChar_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', null, '.' };

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphanumeric_Nullable_NoAlphanumericChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { '.', ',', '!', null };

        // Act
        var result = input.AnyAlphanumeric();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region EqualsIgnoreCase

    [Fact]
    public void EqualsIgnoreCase_Nullable_BothNull_ReturnsTrue()
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
    public void EqualsIgnoreCase_Nullable_OneNull_ReturnsFalse()
    {
        // Arrange
        char? input1 = 'a';
        char? input2 = null;

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualsIgnoreCase_Nullable_SameCase_ReturnsTrue()
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
    public void EqualsIgnoreCase_Nullable_DifferentCase_ReturnsTrue()
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
    public void EqualsIgnoreCase_Nullable_DifferentChars_ReturnsFalse()
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
    public void AllEqualsIgnoreCase_Nullable_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_AllSameCharDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new char?[] { 'a', 'A', 'a' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_DifferentChars_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', 'b', 'a' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Nullable_WithNullChar_ReturnsFalse()
    {
        // Arrange
        var input = new char?[] { 'a', null, 'A' };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_Nullable_BothNull_ReturnsFalse()
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
    public void NotEqualsIgnoreCase_Nullable_OneNull_ReturnsTrue()
    {
        // Arrange
        char? input1 = 'a';
        char? input2 = null;

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_Nullable_SameCase_ReturnsFalse()
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
    public void NotEqualsIgnoreCase_Nullable_DifferentCase_ReturnsFalse()
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

    #endregion

    #region Lower

    [Fact]
    public void Lower_Nullable_NullChar_ReturnsNull()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lower_Nullable_UppercaseChar_ReturnsLowercase()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void Lower_Nullable_LowercaseChar_ReturnsSameChar()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('a', result);
    }

    [Fact]
    public void Lower_Nullable_NonAlphabeticChar_ReturnsSameChar()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal('1', result);
    }

    [Fact]
    public void Lower_Nullable_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<char?> { 'A', 'B', 'C', null };

        // Act
        input.Lower();

        // Assert
        Assert.Equal(['a', 'b', 'c', null], input);
    }

    [Fact]
    public void Lowers_Nullable_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lowers_Nullable_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Lowers_Nullable_MixedCaseCollection_ReturnsAllLowercase()
    {
        // Arrange
        var input = new char?[] { 'A', 'b', 'C', null };

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Equal(['a', 'b', 'c', null], result);
    }

    [Fact]
    public void LowerInvariant_Nullable_NullChar_ReturnsNull()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariant_Nullable_UppercaseChar_ReturnsLowercase()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal('a', result);
    }

    #endregion

    #region Upper

    [Fact]
    public void Upper_Nullable_NullChar_ReturnsNull()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Upper_Nullable_LowercaseChar_ReturnsUppercase()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Upper_Nullable_UppercaseChar_ReturnsSameChar()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Upper_Nullable_NonAlphabeticChar_ReturnsSameChar()
    {
        // Arrange
        char? input = '1';

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal('1', result);
    }

    [Fact]
    public void Upper_Nullable_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<char?> { 'a', 'b', 'c', null };

        // Act
        input.Upper();

        // Assert
        Assert.Equal(['A', 'B', 'C', null], input);
    }

    [Fact]
    public void Uppers_Nullable_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<char?>? input = null;

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Uppers_Nullable_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<char?>();

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Uppers_Nullable_MixedCaseCollection_ReturnsAllUppercase()
    {
        // Arrange
        var input = new char?[] { 'A', 'b', 'c', null };

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Equal(['A', 'B', 'C', null], result);
    }

    [Fact]
    public void UpperInvariant_Nullable_NullChar_ReturnsNull()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariant_Nullable_LowercaseChar_ReturnsUppercase()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void IsUpper_Nullable_NullChar_ReturnsFalse()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsUpper_Nullable_UppercaseChar_ReturnsTrue()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsUpper_Nullable_LowercaseChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'a';

        // Act
        var result = input.IsUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotUpper_Nullable_NullChar_ReturnsTrue()
    {
        // Arrange
        char? input = null;

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotUpper_Nullable_UppercaseChar_ReturnsFalse()
    {
        // Arrange
        char? input = 'A';

        // Act
        var result = input.IsNotUpper();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotUpper_Nullable_LowercaseChar_ReturnsTrue()
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
