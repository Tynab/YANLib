namespace YANLib.Tests.Library;

public partial class YANTextTest
{
    #region Empty

    [Fact]
    public void AllEmpty_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<char>? collection = null;

        // Act
        var result = collection.AllEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEmpty_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<char>();

        // Act
        var result = collection.AllEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEmpty_AllDefaultChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { default(char), default, default };

        // Act
        var result = collection.AllEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEmpty_MixedChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { default, 'a', default };

        // Act
        var result = collection.AllEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEmpty_ParamsOverload_AllDefaultChars_ReturnsTrue_Collection()
    {
        // Act
        var result = YANText.AllEmpty(default, default, default);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEmpty_NullCollection_ReturnsFalse_Collection()
    {
        // Arrange
        IEnumerable<char>? collection = null;

        // Act
        var result = collection.AnyEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEmpty_EmptyCollection_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = Array.Empty<char>();

        // Act
        var result = collection.AnyEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEmpty_NoDefaultChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AnyEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEmpty_SomeDefaultChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', default, 'c' };

        // Act
        var result = collection.AnyEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEmpty_ParamsOverload_SomeDefaultChars_ReturnsTrue_Collection()
    {
        // Act
        var result = YANText.AnyEmpty('a', default, 'c');

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEmpty_AllNonDefaultChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AllNotEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEmpty_SomeNonDefaultChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { default, 'b', default };

        // Act
        var result = collection.AnyNotEmpty();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region WhiteSpace

    [Fact]
    public void AllWhiteSpace_AllWhitespaceChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { ' ', '\t', '\n' };

        // Act
        var result = collection.AllWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpace_MixedChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { ' ', 'a', '\t' };

        // Act
        var result = collection.AllWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpace_SomeWhitespaceChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', ' ', 'c' };

        // Act
        var result = collection.AnyWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpace_NoWhitespaceChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AnyWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpace_AllNonWhitespaceChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AllNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpace_SomeNonWhitespaceChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { ' ', 'b', '\t' };

        // Act
        var result = collection.AnyNotWhiteSpace();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region WhiteSpaceEmpty

    [Fact]
    public void AllWhiteSpaceEmpty_AllWhitespaceOrDefaultChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { ' ', default, '\t' };

        // Act
        var result = collection.AllWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllWhiteSpaceEmpty_MixedChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { ' ', 'a', default };

        // Act
        var result = collection.AllWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_SomeWhitespaceOrDefaultChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', ' ', 'c' };

        // Act
        var result = collection.AnyWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyWhiteSpaceEmpty_NoWhitespaceOrDefaultChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AnyWhiteSpaceEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotWhiteSpaceEmpty_AllNonWhitespaceNonDefaultChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AllNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotWhiteSpaceEmpty_SomeNonWhitespaceNonDefaultChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { ' ', 'b', default };

        // Act
        var result = collection.AnyNotWhiteSpaceEmpty();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Alphabetic

    [Fact]
    public void AllAlphabetic_AllLetters_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'B', 'c' };

        // Act
        var result = collection.AllAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_MixedChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'a', '5', 'c' };

        // Act
        var result = collection.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_SomeLetters_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { '5', 'b', '@' };

        // Act
        var result = collection.AnyAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_NoLetters_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { '5', '6', '@' };

        // Act
        var result = collection.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotAlphabetic_AllNonLetters_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { '5', '6', '@' };

        // Act
        var result = collection.AllNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphabetic_SomeNonLetters_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', '5', 'c' };

        // Act
        var result = collection.AnyNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Punctuation

    [Fact]
    public void AllPunctuation_AllPunctuationChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { '.', ',', '!' };

        // Act
        var result = collection.AllPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_MixedChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { '.', 'a', '!' };

        // Act
        var result = collection.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_SomePunctuationChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', '.', 'c' };

        // Act
        var result = collection.AnyPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_NoPunctuationChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotPunctuation_AllNonPunctuationChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AllNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotPunctuation_SomeNonPunctuationChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { '.', 'b', '!' };

        // Act
        var result = collection.AnyNotPunctuation();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Number

    [Fact]
    public void AllNumber_AllDigits_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { '1', '2', '3' };

        // Act
        var result = collection.AllNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_MixedChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { '1', 'a', '3' };

        // Act
        var result = collection.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_SomeDigits_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', '2', 'c' };

        // Act
        var result = collection.AnyNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_NoDigits_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AnyNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNumber_AllNonDigits_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AllNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNumber_SomeNonDigits_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { '1', 'a', '3' };

        // Act
        var result = collection.AnyNotNumber();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Alphanumeric

    [Fact]
    public void AllAlphanumeric_AllAlphanumericChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', '2', 'C' };

        // Act
        var result = collection.AllAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphanumeric_MixedChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'a', '@', '3' };

        // Act
        var result = collection.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphanumeric_SomeAlphanumericChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { '@', 'b', '#' };

        // Act
        var result = collection.AnyAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphanumeric_NoAlphanumericChars_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { '@', '#', '$' };

        // Act
        var result = collection.AnyAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotAlphanumeric_AllNonAlphanumericChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { '@', '#', '$' };

        // Act
        var result = collection.AllNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphanumeric_SomeNonAlphanumericChars_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', '@', '3' };

        // Act
        var result = collection.AnyNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region EqualsIgnoreCase

    [Fact]
    public void AllEqualsIgnoreCase_AllSameLetterDifferentCase_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'A', 'a' };

        // Act
        var result = collection.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_DifferentLetters_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'a' };

        // Act
        var result = collection.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_SomeSameLetterDifferentCase_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'A', 'b' };

        // Act
        var result = collection.AnyEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_AllSameLetterDifferentCase_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'A', 'a' };

        // Act
        var result = collection.AllNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_AllDifferentLetters_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AllNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_SomeDifferentLetters_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'A', 'b' };

        // Act
        var result = collection.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Lower

    [Fact]
    public void Lower_ListWithUppercaseLetters_ModifiesList_Collection()
    {
        // Arrange
        var list = new List<char> { 'A', 'B', 'C' };

        // Act
        list.Lower();

        // Assert
        Assert.Equal(['a', 'b', 'c'], list);
    }

    [Fact]
    public void Lowers_EnumerableWithUppercaseLetters_ReturnsLowercaseLetters_Collection()
    {
        // Arrange
        var collection = new[] { 'A', 'B', 'C' };

        // Act
        var result = collection.Lowers();

        // Assert
        Assert.Equal(['a', 'b', 'c'], result);
    }

    [Fact]
    public void LowerInvariant_ListWithUppercaseLetters_ModifiesList_Collection()
    {
        // Arrange
        var list = new List<char> { 'A', 'B', 'C' };

        // Act
        list.LowerInvariant();

        // Assert
        Assert.Equal(['a', 'b', 'c'], list);
    }

    [Fact]
    public void LowerInvariants_EnumerableWithUppercaseLetters_ReturnsLowercaseLetters_Collection()
    {
        // Arrange
        var collection = new[] { 'A', 'B', 'C' };

        // Act
        var result = collection.LowerInvariants();

        // Assert
        Assert.Equal(['a', 'b', 'c'], result);
    }

    [Fact]
    public void AllLowers_AllLowercaseLetters_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AllLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllLowers_MixedCaseLetters_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'B', 'c' };

        // Act
        var result = collection.AllLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyLowers_NoLowercaseLetters_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'A', 'B', 'C' };

        // Act
        var result = collection.AnyLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyLowers_SomeLowercaseLetters_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'A', 'b', 'C' };

        // Act
        var result = collection.AnyLowers();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Upper

    [Fact]
    public void Upper_ListWithLowercaseLetters_ModifiesList_Collection()
    {
        // Arrange
        var list = new List<char> { 'a', 'b', 'c' };

        // Act
        list.Upper();

        // Assert
        Assert.Equal(['A', 'B', 'C'], list);
    }

    [Fact]
    public void Uppers_EnumerableWithLowercaseLetters_ReturnsUppercaseLetters_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.Uppers();

        // Assert
        Assert.Equal(['A', 'B', 'C'], result);
    }

    [Fact]
    public void UpperInvariant_ListWithLowercaseLetters_ModifiesList_Collection()
    {
        // Arrange
        var list = new List<char> { 'a', 'b', 'c' };

        // Act
        list.UpperInvariant();

        // Assert
        Assert.Equal(['A', 'B', 'C'], list);
    }

    [Fact]
    public void UpperInvariants_EnumerableWithLowercaseLetters_ReturnsUppercaseLetters_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.UpperInvariants();

        // Assert
        Assert.Equal(['A', 'B', 'C'], result);
    }

    [Fact]
    public void AllUppers_AllUppercaseLetters_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'A', 'B', 'C' };

        // Act
        var result = collection.AllUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllUppers_MixedCaseLetters_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'A', 'b', 'C' };

        // Act
        var result = collection.AllUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyUppers_NoUppercaseLetters_ReturnsFalse_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AnyUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyUppers_SomeUppercaseLetters_ReturnsTrue_Collection()
    {
        // Arrange
        var collection = new[] { 'a', 'B', 'c' };

        // Act
        var result = collection.AnyUppers();

        // Assert
        Assert.True(result);
    }

    #endregion
}
