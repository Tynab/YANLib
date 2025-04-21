using YANLib.Object;
using YANLib.Text;

namespace YANLib.Tests.Library.Text;

public partial class YANTextTest
{
    #region Null

    [Fact]
    public void AllNull_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_String_AllNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, null, null };

        // Act
        var result = input.AllNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_String_MixedStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "hello", null };

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_String_NoNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "" };

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_String_Params_AllNullStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNull(null, null, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_String_Params_MixedStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNull(null, "hello", null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_String_AllNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, null, null };

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_String_MixedStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "hello", "world" };

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_String_NoNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "" };

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_String_Params_MixedStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNull(null, "hello", "world");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_String_Params_NoNullStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNull("hello", "world", "");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_String_AllNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, null, null };

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_String_MixedStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "hello", "world" };

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_String_NoNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "" };

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_String_Params_NoNullStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNull("hello", "world", "");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_String_Params_MixedStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNull(null, "hello", "world");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_String_AllNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, null, null };

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_String_MixedStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "hello", "world" };

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_String_NoNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "" };

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_String_Params_MixedStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNull(null, "hello", "world");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_String_Params_AllNullStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNull(null, null, null);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region NullEmpty

    [Fact]
    public void IsNullEmpty_String_NullString_ReturnsTrue()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_String_EmptyString_ReturnsTrue()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_String_WhitespaceString_ReturnsFalse()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNullEmpty_String_NonEmptyString_ReturnsFalse()
    {
        // Arrange
        var input = "hello";

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_String_AllNullOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "", null };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_String_MixedStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "hello", "" };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_String_NoNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "test" };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_String_Params_AllNullOrEmptyStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNullEmpty(null, "", null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_String_Params_MixedStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNullEmpty(null, "hello", "");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_String_AllNullOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "", null };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_String_MixedStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "hello", "world" };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_String_NoNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "test" };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_String_Params_MixedStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNullEmpty(null, "hello", "world");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_String_Params_NoNullOrEmptyStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNullEmpty("hello", "world", "test");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_String_NullString_ReturnsFalse()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_String_EmptyString_ReturnsFalse()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_String_WhitespaceString_ReturnsTrue()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullEmpty_String_NonEmptyString_ReturnsTrue()
    {
        // Arrange
        var input = "hello";

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_String_AllNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "", null };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_String_MixedStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "hello", "world" };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_String_NoNullOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "test" };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_String_Params_NoNullOrEmptyStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNullEmpty("hello", "world", "test");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_String_Params_MixedStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNullEmpty(null, "hello", "world");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_String_AllNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "", null };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_String_MixedStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "hello", "" };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_String_NoNullOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "test" };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_String_Params_MixedStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNullEmpty(null, "hello", "");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_String_Params_AllNullOrEmptyStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNullEmpty(null, "", null);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region NullWhiteSpace

    [Fact]
    public void IsNullWhiteSpace_String_NullString_ReturnsTrue()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_String_EmptyString_ReturnsTrue()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_String_WhitespaceString_ReturnsTrue()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_String_TabString_ReturnsTrue()
    {
        // Arrange
        var input = "\t\t";

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_String_NewlineString_ReturnsTrue()
    {
        // Arrange
        var input = "\n\r";

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_String_NonWhitespaceString_ReturnsFalse()
    {
        // Arrange
        var input = "hello";

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_String_AllNullWhitespaceOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "   ", "" };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_String_MixedStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "hello", "   " };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_String_NoNullWhitespaceOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "test" };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_String_Params_AllNullWhitespaceOrEmptyStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNullWhiteSpace(null, "   ", "");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_String_Params_MixedStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNullWhiteSpace(null, "hello", "   ");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_String_AllNullWhitespaceOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "   ", "" };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_String_MixedStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "hello", "world" };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_String_NoNullWhitespaceOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "test" };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_String_Params_MixedStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNullWhiteSpace(null, "hello", "world");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_String_Params_NoNullWhitespaceOrEmptyStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNullWhiteSpace("hello", "world", "test");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_String_NullString_ReturnsFalse()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_String_EmptyString_ReturnsFalse()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_String_WhitespaceString_ReturnsFalse()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_String_NonWhitespaceString_ReturnsTrue()
    {
        // Arrange
        var input = "hello";

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_String_AllNullWhitespaceOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "   ", "" };

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_String_MixedStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "hello", "world" };

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_String_NoNullWhitespaceOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "test" };

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_String_Params_NoNullWhitespaceOrEmptyStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNullWhiteSpace("hello", "world", "test");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_String_Params_MixedStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNullWhiteSpace(null, "hello", "world");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_String_AllNullWhitespaceOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "   ", "" };

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_String_MixedStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "hello", "   " };

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_String_NoNullWhitespaceOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "test" };

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_String_Params_MixedStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNullWhiteSpace(null, "hello", "   ");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_String_Params_AllNullWhitespaceOrEmptyStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNullWhiteSpace(null, "   ", "");

        // Assert
        Assert.False(result);
    }

    #endregion

    #region EqualsIgnoreCase

    [Fact]
    public void EqualsIgnoreCase_String_BothNull_ReturnsTrue()
    {
        // Arrange
        string? input1 = null;
        string? input2 = null;

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_String_OneNull_ReturnsFalse()
    {
        // Arrange
        var input1 = "hello";
        string? input2 = null;

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualsIgnoreCase_String_SameCase_ReturnsTrue()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "hello";

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_String_DifferentCase_ReturnsTrue()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "HELLO";

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_String_DifferentStrings_ReturnsFalse()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "world";

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_String_AllSameStringDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "hello", "HELLO", "Hello" };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_String_DifferentStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "hello" };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_String_WithNullString_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "hello", null, "HELLO" };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_String_Params_AllSameStringDifferentCase_ReturnsTrue()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase("hello", "HELLO", "Hello");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_String_Params_DifferentStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase("hello", "world", "hello");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_String_AllDifferentStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "test" };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_String_SomeSameStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "HELLO" };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_String_Params_SomeSameStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyEqualsIgnoreCase("hello", "world", "HELLO");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_String_Params_AllDifferentStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyEqualsIgnoreCase("hello", "world", "test");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_String_BothNull_ReturnsFalse()
    {
        // Arrange
        string? input1 = null;
        string? input2 = null;

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_String_OneNull_ReturnsTrue()
    {
        // Arrange
        var input1 = "hello";
        string? input2 = null;

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_String_SameCase_ReturnsFalse()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "hello";

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_String_DifferentCase_ReturnsFalse()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "HELLO";

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_String_DifferentStrings_ReturnsTrue()
    {
        // Arrange
        var input1 = "hello";
        var input2 = "world";

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_String_AllDifferentStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "test" };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_String_SomeSameStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "HELLO" };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_String_Params_AllDifferentStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotEqualsIgnoreCase("hello", "world", "test");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_String_Params_SomeSameStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotEqualsIgnoreCase("hello", "world", "HELLO");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_String_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_String_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_String_AllSameStringDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "hello", "HELLO", "Hello" };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_String_SomeDifferentStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "hello", "world", "HELLO" };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_String_Params_SomeDifferentStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotEqualsIgnoreCase("hello", "world", "HELLO");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_String_Params_AllSameStringDifferentCase_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotEqualsIgnoreCase("hello", "HELLO", "Hello");

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Lower

    [Fact]
    public void Lower_String_NullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lower_String_EmptyString_ReturnsEmpty()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Lower_String_WhitespaceString_ReturnsWhitespace()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Lower_String_UppercaseString_ReturnsLowercase()
    {
        // Arrange
        var input = "HELLO WORLD";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void Lower_String_MixedCaseString_ReturnsLowercase()
    {
        // Arrange
        var input = "Hello World";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void Lower_String_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<string?> { "HELLO", "World", null, "" };

        // Act
        input.Lower();

        // Assert
        Assert.Equal(["hello", "world", null, ""], input);
    }

    [Fact]
    public void Lowers_String_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lowers_String_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Lowers_String_MixedCaseCollection_ReturnsAllLowercase()
    {
        // Arrange
        var input = new[] { "HELLO", "World", null, "" };

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Equal(["hello", "world", null, ""], result);
    }

    [Fact]
    public void Lowers_String_Params_MixedCaseStrings_ReturnsAllLowercase()
    {
        // Act
        var result = YANText.Lowers("HELLO", "World", null, "");

        // Assert
        Assert.Equal(["hello", "world", null, ""], result);
    }

    [Fact]
    public void LowerInvariant_String_NullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariant_String_UppercaseString_ReturnsLowercase()
    {
        // Arrange
        var input = "HELLO WORLD";

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void LowerInvariant_String_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<string?> { "HELLO", "World", null, "" };

        // Act
        input.LowerInvariant();

        // Assert
        Assert.Equal(["hello", "world", null, ""], input);
    }

    [Fact]
    public void LowerInvariants_String_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariants_String_MixedCaseCollection_ReturnsAllLowercase()
    {
        // Arrange
        var input = new[] { "HELLO", "World", null, "" };

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.Equal(["hello", "world", null, ""], result);
    }

    [Fact]
    public void LowerInvariants_String_Params_MixedCaseStrings_ReturnsAllLowercase()
    {
        // Act
        var result = YANText.LowerInvariants("HELLO", "World", null, "");

        // Assert
        Assert.Equal(["hello", "world", null, ""], result);
    }

    #endregion

    #region Upper

    [Fact]
    public void Upper_String_NullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Upper_String_EmptyString_ReturnsEmpty()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Upper_String_WhitespaceString_ReturnsWhitespace()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Upper_String_LowercaseString_ReturnsUppercase()
    {
        // Arrange
        var input = "hello world";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("HELLO WORLD", result);
    }

    [Fact]
    public void Upper_String_MixedCaseString_ReturnsUppercase()
    {
        // Arrange
        var input = "Hello World";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("HELLO WORLD", result);
    }

    [Fact]
    public void Upper_String_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<string?> { "hello", "World", null, "" };

        // Act
        input.Upper();

        // Assert
        Assert.Equal(["HELLO", "WORLD", null, ""], input);
    }

    [Fact]
    public void Uppers_String_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Uppers_String_EmptyCollection_ReturnsEmpty()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Uppers_String_MixedCaseCollection_ReturnsAllUppercase()
    {
        // Arrange
        var input = new[] { "hello", "World", null, "" };

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Equal(["HELLO", "WORLD", null, ""], result);
    }

    [Fact]
    public void Uppers_String_Params_MixedCaseStrings_ReturnsAllUppercase()
    {
        // Act
        var result = YANText.Uppers("hello", "World", null, "");

        // Assert
        Assert.Equal(["HELLO", "WORLD", null, ""], result);
    }

    [Fact]
    public void UpperInvariant_String_NullString_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariant_String_LowercaseString_ReturnsUppercase()
    {
        // Arrange
        var input = "hello world";

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal("HELLO WORLD", result);
    }

    [Fact]
    public void UpperInvariant_String_List_ModifiesListInPlace()
    {
        // Arrange
        var input = new List<string?> { "hello", "World", null, "" };

        // Act
        input.UpperInvariant();

        // Assert
        Assert.Equal(["HELLO", "WORLD", null, ""], input);
    }

    [Fact]
    public void UpperInvariants_String_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariants_String_MixedCaseCollection_ReturnsAllUppercase()
    {
        // Arrange
        var input = new[] { "hello", "World", null, "" };

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.Equal(["HELLO", "WORLD", null, ""], result);
    }

    [Fact]
    public void UpperInvariants_String_Params_MixedCaseStrings_ReturnsAllUppercase()
    {
        // Act
        var result = YANText.UpperInvariants("hello", "World", null, "");

        // Assert
        Assert.Equal(["HELLO", "WORLD", null, ""], result);
    }

    #endregion
}
