namespace YANLib.Tests.Library;

public partial class YANTextTest
{
    #region Null

    [Fact]
    public void AllNull_NullCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_EmptyCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_AllNullValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { null, null, null };

        // Act
        var result = collection.AllNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_MixedValues_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = new string?[] { null, "hello", null };

        // Act
        var result = collection.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_ParamsOverload_AllNullValues_ReturnsTrue_StringCollection()
    {
        // Act
        var result = YANText.AllNull(null, null, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_NullCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_EmptyCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_NoNullValues_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", "world", "test" };

        // Act
        var result = collection.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_SomeNullValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", null, "test" };

        // Act
        var result = collection.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_AllNonNullValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", "world", "test" };

        // Act
        var result = collection.AllNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_SomeNonNullValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { null, "world", null };

        // Act
        var result = collection.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region NullEmpty

    [Fact]
    public void AllNullEmpty_NullCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_EmptyCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_AllNullOrEmptyValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { null, string.Empty, null };

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_MixedValues_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = new string?[] { null, "hello", string.Empty };

        // Act
        var result = collection.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_ParamsOverload_AllNullOrEmptyValues_ReturnsTrue_StringCollection()
    {
        // Act
        var result = YANText.AllNullEmpty(null, string.Empty, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_NullCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_EmptyCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_NoNullOrEmptyValues_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", "world", "test" };

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_SomeNullOrEmptyValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", null, "test" };

        // Act
        var result = collection.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_AllNonNullNonEmptyValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", "world", "test" };

        // Act
        var result = collection.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_SomeNonNullNonEmptyValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { null, "world", string.Empty };

        // Act
        var result = collection.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region NullWhiteSpace

    [Fact]
    public void AllNullWhiteSpace_NullCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_EmptyCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_AllNullEmptyOrWhitespaceValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { null, string.Empty, "   " };

        // Act
        var result = collection.AllNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_MixedValues_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = new string?[] { null, "hello", "   " };

        // Act
        var result = collection.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_ParamsOverload_AllNullEmptyOrWhitespaceValues_ReturnsTrue_StringCollection()
    {
        // Act
        var result = YANText.AllNullWhiteSpace(null, string.Empty, "   ");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_NullCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_EmptyCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_NoNullEmptyOrWhitespaceValues_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", "world", "test" };

        // Act
        var result = collection.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_SomeNullEmptyOrWhitespaceValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", null, "test" };

        // Act
        var result = collection.AnyNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_AllNonNullNonEmptyNonWhitespaceValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", "world", "test" };

        // Act
        var result = collection.AllNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_SomeNonNullNonEmptyNonWhitespaceValues_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { null, "world", "   " };

        // Act
        var result = collection.AnyNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region EqualsIgnoreCase

    [Fact]
    public void AllEqualsIgnoreCase_NullCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_EmptyCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_AllSameStringDifferentCase_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", "HELLO", "Hello" };

        // Act
        var result = collection.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_DifferentStrings_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", "world", "test" };

        // Act
        var result = collection.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_ParamsOverload_AllSameStringDifferentCase_ReturnsTrue_StringCollection()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase("hello", "HELLO", "Hello");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_NullCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        var result = collection.AnyEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_EmptyCollection_ReturnsFalse_StringCollection()
    {
        // Arrange
        var collection = Array.Empty<string?>();

        // Act
        var result = collection.AnyEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_SomeSameStringDifferentCase_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", "HELLO", "test" };

        // Act
        var result = collection.AnyEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_AllDifferentStrings_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", "world", "test" };

        // Act
        var result = collection.AllNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_SomeDifferentStrings_ReturnsTrue_StringCollection()
    {
        // Arrange
        var collection = new string?[] { "hello", "HELLO", "test" };

        // Act
        var result = collection.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Lower

    [Fact]
    public void Lower_NullList_DoesNotThrowException_StringCollection()
    {
        // Arrange
        List<string?>? input = null;

        // Act & Assert
        input.Lower();
    }

    [Fact]
    public void Lower_EmptyList_DoesNotThrowException_StringCollection()
    {
        // Arrange
        var input = new List<string?>();

        // Act & Assert
        input.Lower();
    }

    [Fact]
    public void Lower_ListWithStrings_ModifiesList_StringCollection()
    {
        // Arrange
        var input = new List<string?> { "HELLO", "WORLD", "TEST" };

        // Act
        input.Lower();

        // Assert
        Assert.Equal(["hello", "world", "test"], input);
    }

    [Fact]
    public void Lower_ListWithNullValues_PreservesNulls_StringCollection()
    {
        // Arrange
        var input = new List<string?> { "HELLO", null, "TEST" };

        // Act
        input.Lower();

        // Assert
        Assert.Equal(["hello", null, "test"], input);
    }

    [Fact]
    public void Lowers_NullEnumerable_ReturnsNull_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lowers_EnumerableWithStrings_ReturnsLowercaseStrings_StringCollection()
    {
        // Arrange
        var input = new[] { "HELLO", "WORLD", "TEST" };

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Equal(["hello", "world", "test"], result);
    }

    [Fact]
    public void Lowers_ParamsOverload_ReturnsLowercaseStrings_StringCollection()
    {
        // Act
        var result = YANText.Lowers("HELLO", "WORLD", "TEST");

        // Assert
        Assert.Equal(["hello", "world", "test"], result);
    }

    [Fact]
    public void LowerInvariant_NullList_DoesNotThrowException_StringCollection()
    {
        // Arrange
        List<string?>? input = null;

        // Act & Assert
        input.LowerInvariant();
    }

    [Fact]
    public void LowerInvariant_ListWithStrings_ModifiesList_StringCollection()
    {
        // Arrange
        var input = new List<string?> { "HELLO", "WORLD", "TEST" };

        // Act
        input.LowerInvariant();

        // Assert
        Assert.Equal(["hello", "world", "test"], input);
    }

    [Fact]
    public void LowerInvariants_NullEnumerable_ReturnsNull_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariants_EnumerableWithStrings_ReturnsLowercaseStrings_StringCollection()
    {
        // Arrange
        var input = new[] { "HELLO", "WORLD", "TEST" };

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.Equal(["hello", "world", "test"], result);
    }

    #endregion

    #region Upper

    [Fact]
    public void Upper_NullList_DoesNotThrowException_StringCollection()
    {
        // Arrange
        List<string?>? input = null;

        // Act & Assert
        input.Upper();
    }

    [Fact]
    public void Upper_EmptyList_DoesNotThrowException_StringCollection()
    {
        // Arrange
        var input = new List<string?>();

        // Act & Assert
        input.Upper();
    }

    [Fact]
    public void Upper_ListWithStrings_ModifiesList_StringCollection()
    {
        // Arrange
        var input = new List<string?> { "hello", "world", "test" };

        // Act
        input.Upper();

        // Assert
        Assert.Equal(["HELLO", "WORLD", "TEST"], input);
    }

    [Fact]
    public void Upper_ListWithNullValues_PreservesNulls_StringCollection()
    {
        // Arrange
        var input = new List<string?> { "hello", null, "test" };

        // Act
        input.Upper();

        // Assert
        Assert.Equal(["HELLO", null, "TEST"], input);
    }

    [Fact]
    public void Uppers_NullEnumerable_ReturnsNull_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Uppers_EnumerableWithStrings_ReturnsUppercaseStrings_StringCollection()
    {
        // Arrange
        var input = new[] { "hello", "world", "test" };

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Equal(["HELLO", "WORLD", "TEST"], result);
    }

    [Fact]
    public void Uppers_ParamsOverload_ReturnsUppercaseStrings_StringCollection()
    {
        // Act
        var result = YANText.Uppers("hello", "world", "test");

        // Assert
        Assert.Equal(["HELLO", "WORLD", "TEST"], result);
    }

    [Fact]
    public void UpperInvariant_NullList_DoesNotThrowException_StringCollection()
    {
        // Arrange
        List<string?>? input = null;

        // Act & Assert
        input.UpperInvariant();
    }

    [Fact]
    public void UpperInvariant_ListWithStrings_ModifiesList_StringCollection()
    {
        // Arrange
        var input = new List<string?> { "hello", "world", "test" };

        // Act
        input.UpperInvariant();

        // Assert
        Assert.Equal(["HELLO", "WORLD", "TEST"], input);
    }

    [Fact]
    public void UpperInvariants_NullEnumerable_ReturnsNull_StringCollection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariants_EnumerableWithStrings_ReturnsUppercaseStrings_StringCollection()
    {
        // Arrange
        var input = new[] { "hello", "world", "test" };

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.Equal(["HELLO", "WORLD", "TEST"], result);
    }

    #endregion
}
