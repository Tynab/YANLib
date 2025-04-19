using YANLib.Object;
using YANLib.Text;

namespace YANLib.Tests.Library.Text;

public partial class YANTextTest
{
    #region AllNull
    [Fact]
    public void AllNull_AllNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, null };

        // Act
        var result = input.AllNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_SomeNonNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_Params_AllNullStrings_ReturnsTrue()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AllNull(obj, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_Params_SomeNonNullStrings_ReturnsFalse()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AllNull(obj, "test");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNull
    [Fact]
    public void AnyNull_SomeNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_NoNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_Params_SomeNullStrings_ReturnsTrue()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AnyNull(obj, "test");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_Params_NoNullStrings_ReturnsFalse()
    {
        // Arrange
        var obj = "test1";

        // Act
        var result = YANText.AnyNull(obj, "test2");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNullEmpty
    [Fact]
    public void IsNullEmpty_Null_ReturnsTrue()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_EmptyString_ReturnsTrue()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_NonEmptyString_ReturnsFalse()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNullEmpty_WhiteSpaceString_ReturnsFalse()
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
    public void AllNullEmpty_AllNullOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, string.Empty };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_SomeNonEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Params_AllNullOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AllNullEmpty(obj, string.Empty);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_Params_SomeNonEmptyStrings_ReturnsFalse()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AllNullEmpty(obj, "test");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNullEmpty
    [Fact]
    public void AnyNullEmpty_SomeNullOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_NoNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_Params_SomeNullOrEmptyStrings_ReturnsTrue()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AnyNullEmpty(obj, "test");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_Params_NoNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var obj = "test1";

        // Act
        var result = YANText.AnyNullEmpty(obj, "test2");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNullWhiteSpace
    [Fact]
    public void IsNullWhiteSpace_Null_ReturnsTrue()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_EmptyString_ReturnsTrue()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_WhiteSpaceString_ReturnsTrue()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.IsNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullWhiteSpace_NonWhiteSpaceString_ReturnsFalse()
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
    public void AllNullWhiteSpace_AllNullOrWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, string.Empty, "   " };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_SomeNonWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AllNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Params_AllNullOrWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AllNullWhiteSpace(obj, string.Empty, "   ");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullWhiteSpace_Params_SomeNonWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AllNullWhiteSpace(obj, "test");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNullWhiteSpace
    [Fact]
    public void AnyNullWhiteSpace_SomeNullOrWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "test" };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_NoNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AnyNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Params_SomeNullOrWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AnyNullWhiteSpace(obj, "test");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullWhiteSpace_Params_NoNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        var obj = "test1";

        // Act
        var result = YANText.AnyNullWhiteSpace(obj, "test2");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region EqualsIgnoreCase
    [Fact]
    public void EqualsIgnoreCase_SameStringsDifferentCase_ReturnsTrue()
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
    public void EqualsIgnoreCase_DifferentStrings_ReturnsFalse()
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
    public void EqualsIgnoreCase_BothNull_ReturnsTrue()
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
    public void EqualsIgnoreCase_OneNull_ReturnsFalse()
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
    public void AllEqualsIgnoreCase_AllSameStringsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test", "TEST", "Test" };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_SomeDifferentStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", "different" };

        // Act
        var result = input.AllEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Params_AllSameStringsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.AllEqualsIgnoreCase(obj, "TEST", "Test");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllEqualsIgnoreCase_Params_SomeDifferentStrings_ReturnsFalse()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.AllEqualsIgnoreCase(obj, "different");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyEqualsIgnoreCase
    [Fact]
    public void AnyEqualsIgnoreCase_SomeSameStringsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test", "TEST", "different" };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_AllDifferentStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AnyEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Params_SomeSameStringsDifferentCase_ReturnsTrue()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.AnyEqualsIgnoreCase(obj, "TEST", "different");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyEqualsIgnoreCase_Params_AllDifferentStrings_ReturnsFalse()
    {
        // Arrange
        var obj = "test1";

        // Act
        var result = YANText.AnyEqualsIgnoreCase(obj, "test2", "test3");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AllNotNull
    [Fact]
    public void AllNotNull_AllNonNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_SomeNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", null };

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_Params_AllNonNullStrings_ReturnsTrue()
    {
        // Arrange
        var obj = "test1";

        // Act
        var result = YANText.AllNotNull(obj, "test2");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_Params_SomeNullStrings_ReturnsFalse()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.AllNotNull(obj, null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNull
    [Fact]
    public void AnyNotNull_SomeNonNullStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test", null };

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_AllNullStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, null };

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_Params_SomeNonNullStrings_ReturnsTrue()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.AnyNotNull(obj, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_Params_AllNullStrings_ReturnsFalse()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AnyNotNull(obj, null);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNullEmpty
    [Fact]
    public void IsNotNullEmpty_NonEmptyString_ReturnsTrue()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullEmpty_Null_ReturnsFalse()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_EmptyString_ReturnsFalse()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_WhiteSpaceString_ReturnsTrue()
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
    public void AllNotNullEmpty_AllNonNullNonEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_SomeNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", null };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Params_AllNonNullNonEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var obj = "test1";

        // Act
        var result = YANText.AllNotNullEmpty(obj, "test2");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_Params_SomeNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.AllNotNullEmpty(obj, string.Empty);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNullEmpty
    [Fact]
    public void AnyNotNullEmpty_SomeNonNullNonEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test", null };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_AllNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, string.Empty };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Params_SomeNonNullNonEmptyStrings_ReturnsTrue()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.AnyNotNullEmpty(obj, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Params_AllNullOrEmptyStrings_ReturnsFalse()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AnyNotNullEmpty(obj, string.Empty);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region IsNotNullWhiteSpace
    [Fact]
    public void IsNotNullWhiteSpace_NonWhiteSpaceString_ReturnsTrue()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_Null_ReturnsFalse()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_EmptyString_ReturnsFalse()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullWhiteSpace_WhiteSpaceString_ReturnsFalse()
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
    public void AllNotNullWhiteSpace_AllNonNullNonWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2" };

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_SomeNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", null };

        // Act
        var result = input.AllNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_Params_AllNonNullNonWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        var obj = "test1";

        // Act
        var result = YANText.AllNotNullWhiteSpace(obj, "test2");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullWhiteSpace_Params_SomeNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.AllNotNullWhiteSpace(obj, "   ");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotNullWhiteSpace
    [Fact]
    public void AnyNotNullWhiteSpace_SomeNonNullNonWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test", null, "   " };

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_AllNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, string.Empty, "   " };

        // Act
        var result = input.AnyNotNullWhiteSpace();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_Params_SomeNonNullNonWhiteSpaceStrings_ReturnsTrue()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.AnyNotNullWhiteSpace(obj, null, "   ");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullWhiteSpace_Params_AllNullOrWhiteSpaceStrings_ReturnsFalse()
    {
        // Arrange
        string? obj = null;

        // Act
        var result = YANText.AnyNotNullWhiteSpace(obj, string.Empty, "   ");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region NotEqualsIgnoreCase
    [Fact]
    public void NotEqualsIgnoreCase_DifferentStrings_ReturnsTrue()
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
    public void NotEqualsIgnoreCase_SameStringsDifferentCase_ReturnsFalse()
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
    public void NotEqualsIgnoreCase_BothNull_ReturnsFalse()
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
    public void NotEqualsIgnoreCase_OneNull_ReturnsFalse()
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
    public void AllNotEqualsIgnoreCase_AllDifferentStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_SomeSameStringsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", "TEST", "test3" };

        // Act
        var result = input.AllNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Params_AllDifferentStrings_ReturnsTrue()
    {
        // Arrange
        var obj = "test1";

        // Act
        var result = YANText.AllNotEqualsIgnoreCase(obj, "test2", "test3");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotEqualsIgnoreCase_Params_SomeSameStringsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.AllNotEqualsIgnoreCase(obj, "TEST", "test3");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region AnyNotEqualsIgnoreCase
    [Fact]
    public void AnyNotEqualsIgnoreCase_SomeDifferentStrings_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_AllSameStringsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test", "TEST", "Test" };

        // Act
        var result = input.AnyNotEqualsIgnoreCase();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Params_SomeDifferentStrings_ReturnsTrue()
    {
        // Arrange
        var obj = "test1";

        // Act
        var result = YANText.AnyNotEqualsIgnoreCase(obj, "test2", "test3");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotEqualsIgnoreCase_Params_AllSameStringsDifferentCase_ReturnsFalse()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.AnyNotEqualsIgnoreCase(obj, "TEST", "Test");

        // Assert
        Assert.False(result);
    }
    #endregion

    #region Lower
    [Fact]
    public void Lower_UpperCaseString_ReturnsLowerCaseString()
    {
        // Arrange
        var input = "TEST";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("test", result);
    }

    [Fact]
    public void Lower_MixedCaseString_ReturnsLowerCaseString()
    {
        // Arrange
        var input = "TeSt";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("test", result);
    }

    [Fact]
    public void Lower_Null_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lower_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Lower_WhiteSpaceString_ReturnsWhiteSpaceString()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Lower();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Lower_List_MixedCaseStrings_ModifiesListToLowerCase()
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
    public void Lower_List_NullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.Lower);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Lowers_MixedCaseStrings_ReturnsAllLowerCase()
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
    public void Lowers_NullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Lowers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Lowers_Params_MixedCaseStrings_ReturnsAllLowerCase()
    {
        // Arrange
        var obj = "TEST";

        // Act
        var result = YANText.Lowers(obj, "TeSt", null, "HELLO");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["test", "test", null, "hello"], result);
    }
    #endregion

    #region LowerInvariant
    [Fact]
    public void LowerInvariant_UpperCaseString_ReturnsLowerCaseString()
    {
        // Arrange
        var input = "TEST";

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Equal("test", result);
    }

    [Fact]
    public void LowerInvariant_Null_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.LowerInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariant_List_MixedCaseStrings_ModifiesListToLowerCase()
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
    public void LowerInvariant_List_NullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.LowerInvariant);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void LowerInvariants_MixedCaseStrings_ReturnsAllLowerCase()
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
    public void LowerInvariants_NullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.LowerInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LowerInvariants_Params_MixedCaseStrings_ReturnsAllLowerCase()
    {
        // Arrange
        var obj = "TEST";

        // Act
        var result = YANText.LowerInvariants(obj, "TeSt", null, "HELLO");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["test", "test", null, "hello"], result);
    }
    #endregion

    #region Upper
    [Fact]
    public void Upper_LowerCaseString_ReturnsUpperCaseString()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("TEST", result);
    }

    [Fact]
    public void Upper_MixedCaseString_ReturnsUpperCaseString()
    {
        // Arrange
        var input = "TeSt";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("TEST", result);
    }

    [Fact]
    public void Upper_Null_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Upper_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Upper_WhiteSpaceString_ReturnsWhiteSpaceString()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Upper();

        // Assert
        Assert.Equal("   ", result);
    }

    [Fact]
    public void Upper_List_MixedCaseStrings_ModifiesListToUpperCase()
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
    public void Upper_List_NullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.Upper);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Uppers_MixedCaseStrings_ReturnsAllUpperCase()
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
    public void Uppers_NullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Uppers();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Uppers_Params_MixedCaseStrings_ReturnsAllUpperCase()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.Uppers(obj, "TeSt", null, "hello");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["TEST", "TEST", null, "HELLO"], result);
    }
    #endregion

    #region UpperInvariant
    [Fact]
    public void UpperInvariant_LowerCaseString_ReturnsUpperCaseString()
    {
        // Arrange
        var input = "test";

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Equal("TEST", result);
    }

    [Fact]
    public void UpperInvariant_Null_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.UpperInvariant();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariant_List_MixedCaseStrings_ModifiesListToUpperCase()
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
    public void UpperInvariant_List_NullInput_DoesNotThrowException()
    {
        // Arrange
        List<string?>? input = null;

        // Act
        var exception = Record.Exception(input.UpperInvariant);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void UpperInvariants_MixedCaseStrings_ReturnsAllUpperCase()
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
    public void UpperInvariants_NullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.UpperInvariants();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void UpperInvariants_Params_MixedCaseStrings_ReturnsAllUpperCase()
    {
        // Arrange
        var obj = "test";

        // Act
        var result = YANText.UpperInvariants(obj, "TeSt", null, "hello");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(["TEST", "TEST", null, "HELLO"], result);
    }
    #endregion
}
