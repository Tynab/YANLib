using YANLib.Object;
using YANLib.Text;

namespace YANLib.Tests.Library.Text;

public partial class YANTextTest
{
    #region AllNull
    [Fact]
    public void AllNull_WithAllNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, null };

        // Act
        var result = input.AllNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_WithSomeNonNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_Params_WithAllNullStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNull(null, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_Params_WithSomeNonNullStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNull(null, "test");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNull
    [Fact]
    public void AnyNull_WithSomeNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_WithNoNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_Params_WithSomeNullStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNull(null, "test");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_Params_WithNoNullStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNull("test1", "test2");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNullEmpty
    [Fact]
    public void IsNullEmpty_WithNull_ReturnsTrue()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_WithEmptyString_ReturnsTrue()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_WithNonEmptyString_ReturnsFalse()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNullEmpty_WithWhiteSpaceString_ReturnsFalse()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNullEmpty
    [Fact]
    public void AllNullEmpty_WithAllNullOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, string.Empty };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_WithSomeNonEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Params_WithAllNullOrEmptyStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNullEmpty(null, string.Empty);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_Params_WithSomeNonEmptyStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNullEmpty(null, "test");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNullEmpty
    [Fact]
    public void AnyNullEmpty_WithSomeNullOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_WithNoNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_Params_WithSomeNullOrEmptyStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNullEmpty(null, "test");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_Params_WithNoNullOrEmptyStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNullEmpty("test1", "test2");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNullWhiteSpace
    [Fact]
    public void IsNullWhiteSpace_WithNull_ReturnsTrue()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_WithEmptyString_ReturnsTrue()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_WithWhiteSpaceString_ReturnsTrue()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_WithNonWhiteSpaceString_ReturnsFalse()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNullWhiteSpace
    [Fact]
    public void AllNullWhiteSpace_WithAllNullOrWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, string.Empty, "   " };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_WithSomeNonWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Params_WithAllNullOrWhiteSpaceStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNullWhiteSpace(null, string.Empty, "   ");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Params_WithSomeNonWhiteSpaceStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNullWhiteSpace(null, "test");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNullWhiteSpace
    [Fact]
    public void AnyNullWhiteSpace_WithSomeNullOrWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_WithNoNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Params_WithSomeNullOrWhiteSpaceStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNullWhiteSpace(null, "test");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Params_WithNoNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNullWhiteSpace("test1", "test2");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region EqualsIgnoreCase
    [Fact]
    public void EqualsIgnoreCase_WithSameStringsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input1 = "test";
        var input2 = "TEST";

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void EqualsIgnoreCase_WithDifferentStrings_ReturnsFalse()
    {
        // Arrange
        var input1 = "test1";
        var input2 = "test2";

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void EqualsIgnoreCase_WithBothNull_ReturnsTrue()
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
    public void EqualsIgnoreCase_WithOneNull_ReturnsFalse()
    {
        // Arrange
        var input1 = "test";
        string? input2 = null;

        // Act
        var result = input1.EqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllEqualsIgnoreCase
    [Fact]
    public void AllEqualsIgnoreCase_WithAllSameStringsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test", "TEST", "Test" };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_WithSomeDifferentStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", "different" };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Params_WithAllSameStringsDifferentCase_ReturnsTrue()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase("test", "TEST", "Test");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Params_WithSomeDifferentStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllEqualsIgnoreCase("test", "different");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyEqualsIgnoreCase
    [Fact]
    public void AnyEqualsIgnoreCase_WithSomeSameStringsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test", "TEST", "different" };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_WithAllDifferentStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Params_WithSomeSameStringsDifferentCase_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyEqualsIgnoreCase("test", "TEST", "different");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Params_WithAllDifferentStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyEqualsIgnoreCase("test1", "test2", "test3");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotNull
    [Fact]
    public void AllNotNull_WithAllNonNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_WithSomeNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", null };

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_Params_WithAllNonNullStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNull("test1", "test2");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_Params_WithSomeNullStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNull("test", null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNull
    [Fact]
    public void AnyNotNull_WithSomeNonNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test", null };

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_WithAllNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, null };

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_Params_WithSomeNonNullStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNull("test", null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_Params_WithAllNullStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNull(null, null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNullEmpty
    [Fact]
    public void IsNotNullEmpty_WithNonEmptyString_ReturnsTrue()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullEmpty_WithNull_ReturnsFalse()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_WithWhiteSpaceString_ReturnsTrue()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }
    #endregion

    #region AllNotNullEmpty
    [Fact]
    public void AllNotNullEmpty_WithAllNonNullNonEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_WithSomeNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", null };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Params_WithAllNonNullNonEmptyStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNullEmpty("test1", "test2");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_Params_WithSomeNullOrEmptyStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNullEmpty("test", string.Empty);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNullEmpty
    [Fact]
    public void AnyNotNullEmpty_WithSomeNonNullNonEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test", null };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_WithAllNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, string.Empty };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Params_WithSomeNonNullNonEmptyStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNullEmpty("test", null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Params_WithAllNullOrEmptyStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNullEmpty(null, string.Empty);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNullWhiteSpace
    [Fact]
    public void IsNotNullWhiteSpace_WithNonWhiteSpaceString_ReturnsTrue()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_WithNull_ReturnsFalse()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_WithWhiteSpaceString_ReturnsFalse()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotNullWhiteSpace
    [Fact]
    public void AllNotNullWhiteSpace_WithAllNonNullNonWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_WithSomeNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", null };

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_Params_WithAllNonNullNonWhiteSpaceStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotNullWhiteSpace("test1", "test2");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_Params_WithSomeNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotNullWhiteSpace("test", "   ");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNullWhiteSpace
    [Fact]
    public void AnyNotNullWhiteSpace_WithSomeNonNullNonWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test", null, "   " };

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_WithAllNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, string.Empty, "   " };

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_Params_WithSomeNonNullNonWhiteSpaceStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotNullWhiteSpace("test", null, "   ");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_Params_WithAllNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotNullWhiteSpace(null, string.Empty, "   ");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region NotEqualsIgnoreCase
    [Fact]
    public void NotEqualsIgnoreCase_WithDifferentStrings_ReturnsTrue()
    {
        // Arrange
        var input1 = "test1";
        var input2 = "test2";

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_WithSameStringsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input1 = "test";
        var input2 = "TEST";

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void NotEqualsIgnoreCase_WithBothNull_ReturnsFalse()
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
    public void NotEqualsIgnoreCase_WithOneNull_ReturnsFalse()
    {
        // Arrange
        var input1 = "test";
        string? input2 = null;

        // Act
        var result = input1.NotEqualsIgnoreCase(input2);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotEqualsIgnoreCase
    [Fact]
    public void AllNotEqualsIgnoreCase_WithAllDifferentStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_WithSomeSameStringsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", "TEST", "test3" };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Params_WithAllDifferentStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AllNotEqualsIgnoreCase("test1", "test2", "test3");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Params_WithSomeSameStringsDifferentCase_ReturnsFalse()
    {
        // Act
        var result = YANText.AllNotEqualsIgnoreCase("test", "TEST", "test3");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotEqualsIgnoreCase
    [Fact]
    public void AnyNotEqualsIgnoreCase_WithSomeDifferentStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_WithAllSameStringsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", "TEST", "Test" };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Params_WithSomeDifferentStrings_ReturnsTrue()
    {
        // Act
        var result = YANText.AnyNotEqualsIgnoreCase("test1", "test2", "test3");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Params_WithAllSameStringsDifferentCase_ReturnsFalse()
    {
        // Act
        var result = YANText.AnyNotEqualsIgnoreCase("test", "TEST", "Test");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region Lower
    [Fact]
    public void Lower_WithUpperCaseString_ReturnsLowerCaseString()
    {
        // Arrange
        var input = "TEST";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("test", result);
    }

    [Fact]
    public void Lower_WithMixedCaseString_ReturnsLowerCaseString()
    {
        // Arrange
        var input = "TeSt";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("test", result);
    }

    [Fact]
    public void Lower_WithNull_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lower_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Lower_WithWhiteSpaceString_ReturnsWhiteSpaceString()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Lower_List_WithMixedCaseStrings_ModifiesListToLowerCase()
    {
        // Arrange
        var input = new List<string?> { "TEST", "TeSt", null, "HELLO" };
        var expected = new List<string?> { "test", "test", null, "hello" };

        // Act
        input.Lower();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void Lower_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.Lower);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Lowers_WithMixedCaseStrings_ReturnsAllLowerCase()
    {
        // Arrange
        var input = new[] { "TEST", "TeSt", null, "HELLO" };

        // Act
        var result = input.Lowers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["test", "test", null, "hello"], result);
    }

    [Fact]
    public void Lowers_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lowers_Params_WithMixedCaseStrings_ReturnsAllLowerCase()
    {
        // Act
        var result = YANText.Lowers("TEST", "TeSt", null, "HELLO");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["test", "test", null, "hello"], result);
    }
    #endregion

    #region LowerInvariant
    [Fact]
    public void LowerInvariant_WithUpperCaseString_ReturnsLowerCaseString()
    {
        // Arrange
        var input = "TEST";

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal("test", result);
    }

    [Fact]
    public void LowerInvariant_WithNull_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariant_List_WithMixedCaseStrings_ModifiesListToLowerCase()
    {
        // Arrange
        var input = new List<string?> { "TEST", "TeSt", null, "HELLO" };
        var expected = new List<string?> { "test", "test", null, "hello" };

        // Act
        input.LowerInvariant();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void LowerInvariant_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.LowerInvariant);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void LowerInvariants_WithMixedCaseStrings_ReturnsAllLowerCase()
    {
        // Arrange
        var input = new[] { "TEST", "TeSt", null, "HELLO" };

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["test", "test", null, "hello"], result);
    }

    [Fact]
    public void LowerInvariants_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariants_Params_WithMixedCaseStrings_ReturnsAllLowerCase()
    {
        // Act
        var result = YANText.LowerInvariants("TEST", "TeSt", null, "HELLO");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["test", "test", null, "hello"], result);
    }
    #endregion

    #region Upper
    [Fact]
    public void Upper_WithLowerCaseString_ReturnsUpperCaseString()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("TEST", result);
    }

    [Fact]
    public void Upper_WithMixedCaseString_ReturnsUpperCaseString()
    {
        // Arrange
        var input = "TeSt";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("TEST", result);
    }

    [Fact]
    public void Upper_WithNull_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Upper_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Upper_WithWhiteSpaceString_ReturnsWhiteSpaceString()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Upper_List_WithMixedCaseStrings_ModifiesListToUpperCase()
    {
        // Arrange
        var input = new List<string?> { "test", "TeSt", null, "hello" };
        var expected = new List<string?> { "TEST", "TEST", null, "HELLO" };

        // Act
        input.Upper();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void Upper_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.Upper);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Uppers_WithMixedCaseStrings_ReturnsAllUpperCase()
    {
        // Arrange
        var input = new[] { "test", "TeSt", null, "hello" };

        // Act
        var result = input.Uppers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["TEST", "TEST", null, "HELLO"], result);
    }

    [Fact]
    public void Uppers_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Uppers_Params_WithMixedCaseStrings_ReturnsAllUpperCase()
    {
        // Act
        var result = YANText.Uppers("test", "TeSt", null, "hello");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["TEST", "TEST", null, "HELLO"], result);
    }
    #endregion

    #region UpperInvariant
    [Fact]
    public void UpperInvariant_WithLowerCaseString_ReturnsUpperCaseString()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal("TEST", result);
    }

    [Fact]
    public void UpperInvariant_WithNull_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariant_List_WithMixedCaseStrings_ModifiesListToUpperCase()
    {
        // Arrange
        var input = new List<string?> { "test", "TeSt", null, "hello" };
        var expected = new List<string?> { "TEST", "TEST", null, "HELLO" };

        // Act
        input.UpperInvariant();

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void UpperInvariant_List_WithNullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.UpperInvariant);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void UpperInvariants_WithMixedCaseStrings_ReturnsAllUpperCase()
    {
        // Arrange
        var input = new[] { "test", "TeSt", null, "hello" };

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["TEST", "TEST", null, "HELLO"], result);
    }

    [Fact]
    public void UpperInvariants_WithNullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariants_Params_WithMixedCaseStrings_ReturnsAllUpperCase()
    {
        // Act
        var result = YANText.UpperInvariants("test", "TeSt", null, "hello");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["TEST", "TEST", null, "HELLO"], result);
    }
    #endregion
}
