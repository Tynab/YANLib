namespace YANLib.Tests.Library;

public partial class YANTextTest
{
    #region NullEmpty

    [Fact]
    public void AllNullEmpty_NullCollection_ReturnsFalse_NullableCollection()
    {
        // Arrange
        IEnumerable<char?>? collection = null;

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_EmptyCollection_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = Array.Empty<char?>();

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_AllNullOrDefaultChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { null, default(char), null };

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_MixedChars_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { null, 'a', default(char) };

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_ParamsOverload_AllNullOrDefaultChars_ReturnsTrue_NullableCollection()
    {
        // Act
        var result = YANText.AllNullEmpty(null, default(char), null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_NullCollection_ReturnsFalse_NullableCollection()
    {
        // Arrange
        IEnumerable<char?>? collection = null;

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_EmptyCollection_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = Array.Empty<char?>();

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_NoNullOrDefaultChars_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_SomeNullOrDefaultChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', null, 'c' };

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_AllNonNullNonDefaultChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_SomeNonNullNonDefaultChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { null, 'b', default(char) };

        // Act
        var result = collection.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region NullWhiteSpace

    [Fact]
    public void AllNullWhiteSpace_AllNullDefaultOrWhitespaceChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { null, default(char), ' ', '\t' };

        // Act
        var result = collection.AllNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_MixedChars_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { null, 'a', ' ' };

        // Act
        var result = collection.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_SomeNullDefaultOrWhitespaceChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', null, 'c' };

        // Act
        var result = collection.AnyNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_NoNullDefaultOrWhitespaceChars_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_AllNonNullNonDefaultNonWhitespaceChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AllNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_SomeNonNullNonDefaultNonWhitespaceChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { null, 'b', ' ' };

        // Act
        var result = collection.AnyNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Alphabetic

    [Fact]
    public void AllAlphabetic_AllLetters_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'B', 'c' };

        // Act
        var result = collection.AllAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphabetic_MixedChars_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', '5', 'c' };

        // Act
        var result = collection.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphabetic_ContainsNull_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', null, 'c' };

        // Act
        var result = collection.AllAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphabetic_SomeLetters_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '5', 'b', '@' };

        // Act
        var result = collection.AnyAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphabetic_NoLetters_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '5', '6', '@', null };

        // Act
        var result = collection.AnyAlphabetic();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotAlphabetic_AllNonLetters_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '5', '6', '@', null };

        // Act
        var result = collection.AllNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphabetic_SomeNonLetters_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', '5', 'c' };

        // Act
        var result = collection.AnyNotAlphabetic();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Punctuation

    [Fact]
    public void AllPunctuation_AllPunctuationChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '.', ',', '!' };

        // Act
        var result = collection.AllPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllPunctuation_MixedChars_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '.', 'a', '!' };

        // Act
        var result = collection.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllPunctuation_ContainsNull_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '.', null, '!' };

        // Act
        var result = collection.AllPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyPunctuation_SomePunctuationChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', '.', 'c' };

        // Act
        var result = collection.AnyPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyPunctuation_NoPunctuationChars_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'c', null };

        // Act
        var result = collection.AnyPunctuation();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotPunctuation_AllNonPunctuationChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'c', null };

        // Act
        var result = collection.AllNotPunctuation();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotPunctuation_SomeNonPunctuationChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '.', 'b', '!' };

        // Act
        var result = collection.AnyNotPunctuation();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Number

    [Fact]
    public void AllNumber_AllDigits_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '1', '2', '3' };

        // Act
        var result = collection.AllNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNumber_MixedChars_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '1', 'a', '3' };

        // Act
        var result = collection.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNumber_ContainsNull_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '1', null, '3' };

        // Act
        var result = collection.AllNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNumber_SomeDigits_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', '2', 'c' };

        // Act
        var result = collection.AnyNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNumber_NoDigits_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'c', null };

        // Act
        var result = collection.AnyNumber();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNumber_AllNonDigits_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'c', null };

        // Act
        var result = collection.AllNotNumber();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNumber_SomeNonDigits_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '1', 'a', '3' };

        // Act
        var result = collection.AnyNotNumber();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Alphanumeric

    [Fact]
    public void AllAlphanumeric_AllAlphanumericChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', '2', 'C' };

        // Act
        var result = collection.AllAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllAlphanumeric_MixedChars_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', '@', '3' };

        // Act
        var result = collection.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAlphanumeric_ContainsNull_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', null, '3' };

        // Act
        var result = collection.AllAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAlphanumeric_SomeAlphanumericChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '@', 'b', '#' };

        // Act
        var result = collection.AnyAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAlphanumeric_NoAlphanumericChars_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '@', '#', '$', null };

        // Act
        var result = collection.AnyAlphanumeric();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotAlphanumeric_AllNonAlphanumericChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { '@', '#', '$', null };

        // Act
        var result = collection.AllNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotAlphanumeric_SomeNonAlphanumericChars_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', '@', '3' };

        // Act
        var result = collection.AnyNotAlphanumeric();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region EqualsIgnoreCase

    [Fact]
    public void AllEqualsIgnoreCase_AllSameLetterDifferentCase_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'A', 'a' };

        // Act
        var result = collection.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_DifferentLetters_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'a' };

        // Act
        var result = collection.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_ContainsNull_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', null, 'A' };

        // Act
        var result = collection.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_SomeSameLetterDifferentCase_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'A', 'b' };

        // Act
        var result = collection.AnyEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_AllDifferentLetters_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AllNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Lower

    [Fact]
    public void Lower_ListWithUppercaseLetters_ModifiesList_NullableCollection()
    {
        // Arrange
        var list = new List<char?> { 'A', 'B', 'C' };

        // Act
        list.Lower();

        // Assert
        Assert.Equal(['a', 'b', 'c'], list);
    }

    [Fact]
    public void Lower_ListWithNulls_PreservesNulls_NullableCollection()
    {
        // Arrange
        var list = new List<char?> { 'A', null, 'C' };

        // Act
        list.Lower();

        // Assert
        Assert.Equal(['a', null, 'c'], list);
    }

    [Fact]
    public void Lowers_EnumerableWithUppercaseLetters_ReturnsLowercaseLetters_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'A', 'B', 'C' };

        // Act
        var result = collection.Lowers();

        // Assert
        Assert.Equal(['a', 'b', 'c'], result);
    }

    [Fact]
    public void Lowers_EnumerableWithNulls_PreservesNulls_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'A', null, 'C' };

        // Act
        var result = collection.Lowers();

        // Assert
        Assert.Equal(['a', null, 'c'], result);
    }

    [Fact]
    public void LowerInvariant_ListWithUppercaseLetters_ModifiesList_NullableCollection()
    {
        // Arrange
        var list = new List<char?> { 'A', 'B', 'C' };

        // Act
        list.LowerInvariant();

        // Assert
        Assert.Equal(['a', 'b', 'c'], list);
    }

    [Fact]
    public void AllLowers_AllLowercaseLetters_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = collection.AllLowers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllLowers_MixedCaseLetters_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'B', 'c' };

        // Act
        var result = collection.AllLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllLowers_ContainsNull_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', null, 'c' };

        // Act
        var result = collection.AllLowers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyLowers_SomeLowercaseLetters_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'A', 'b', 'C' };

        // Act
        var result = collection.AnyLowers();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Upper

    [Fact]
    public void Upper_ListWithLowercaseLetters_ModifiesList_NullableCollection()
    {
        // Arrange
        var list = new List<char?> { 'a', 'b', 'c' };

        // Act
        list.Upper();

        // Assert
        Assert.Equal(['A', 'B', 'C'], list);
    }

    [Fact]
    public void Upper_ListWithNulls_PreservesNulls_NullableCollection()
    {
        // Arrange
        var list = new List<char?> { 'a', null, 'c' };

        // Act
        list.Upper();

        // Assert
        Assert.Equal(['A', null, 'C'], list);
    }

    [Fact]
    public void Uppers_EnumerableWithLowercaseLetters_ReturnsUppercaseLetters_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'b', 'c' };

        // Act
        var result = collection.Uppers();

        // Assert
        Assert.Equal(['A', 'B', 'C'], result);
    }

    [Fact]
    public void Uppers_EnumerableWithNulls_PreservesNulls_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', null, 'c' };

        // Act
        var result = collection.Uppers();

        // Assert
        Assert.Equal(['A', null, 'C'], result);
    }

    [Fact]
    public void UpperInvariant_ListWithLowercaseLetters_ModifiesList_NullableCollection()
    {
        // Arrange
        var list = new List<char?> { 'a', 'b', 'c' };

        // Act
        list.UpperInvariant();

        // Assert
        Assert.Equal(['A', 'B', 'C'], list);
    }

    [Fact]
    public void AllUppers_AllUppercaseLetters_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'A', 'B', 'C' };

        // Act
        var result = collection.AllUppers();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllUppers_MixedCaseLetters_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'A', 'b', 'C' };

        // Act
        var result = collection.AllUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllUppers_ContainsNull_ReturnsFalse_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'A', null, 'C' };

        // Act
        var result = collection.AllUppers();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyUppers_SomeUppercaseLetters_ReturnsTrue_NullableCollection()
    {
        // Arrange
        var collection = new char?[] { 'a', 'B', 'c' };

        // Act
        var result = collection.AnyUppers();

        // Assert
        Assert.True(result);
    }

    #endregion
}
