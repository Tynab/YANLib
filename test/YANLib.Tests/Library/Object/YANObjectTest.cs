using YANLib.Object;

namespace YANLib.Tests.Library.Object;

public partial class YANObjectTest
{
    #region IsNull

    [Fact]
    public void IsNull_NullInput_ReturnsTrue()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.IsNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNull_NonNullInput_ReturnsFalse()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNull_EmptyString_ReturnsFalse()
    {
        // Arrange
        object input = string.Empty;

        // Act
        var result = input.IsNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNull_DefaultValueType_ReturnsFalse()
    {
        // Arrange
        object input = default(int);

        // Act
        var result = input.IsNull();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllNull

    [Fact]
    public void AllNull_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_AllNullElements_ReturnsTrue()
    {
        // Arrange
        var input = new object?[] { null, null, null };

        // Act
        var result = input.AllNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_MixedElements_ReturnsFalse()
    {
        // Arrange
        var input = new object?[] { null, "test", null };

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_NoNullElements_ReturnsFalse()
    {
        // Arrange
        var input = new object?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AllNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNull((object?[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_Params_EmptyArray_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = YANObject.AllNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNull_Params_AllNullElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllNull((object?)null, null, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNull_Params_MixedElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNull(null, "test", null);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyNull

    [Fact]
    public void AnyNull_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_AllNullElements_ReturnsTrue()
    {
        // Arrange
        var input = new object?[] { null, null, null };

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_MixedElements_ReturnsTrue()
    {
        // Arrange
        var input = new object?[] { null, "test", null };

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_NoNullElements_ReturnsFalse()
    {
        // Arrange
        var input = new object?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AnyNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNull((object?[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_Params_EmptyArray_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = YANObject.AnyNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNull_Params_AllNullElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNull((object?)null, null, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_Params_MixedElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNull(null, "test", null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNull_Params_NoNullElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNull("test1", "test2", "test3");

        // Assert
        Assert.False(result);
    }

    #endregion

    #region IsNotNull

    [Fact]
    public void IsNotNull_NullInput_ReturnsFalse()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNull_NonNullInput_ReturnsTrue()
    {
        // Arrange
        var input = new object();

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNull_EmptyString_ReturnsTrue()
    {
        // Arrange
        object input = string.Empty;

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotNull_DefaultValueType_ReturnsTrue()
    {
        // Arrange
        object input = default(int);

        // Act
        var result = input.IsNotNull();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AllNotNull

    [Fact]
    public void AllNotNull_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_AllNullElements_ReturnsFalse()
    {
        // Arrange
        var input = new object?[] { null, null, null };

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_MixedElements_ReturnsFalse()
    {
        // Arrange
        var input = new object?[] { null, "test", null };

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_NoNullElements_ReturnsTrue()
    {
        // Arrange
        var input = new object?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AllNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNull_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotNull((object?[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_Params_EmptyArray_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = YANObject.AllNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_Params_AllNullElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotNull((object?)null, null, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_Params_MixedElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotNull(null, "test", null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNull_Params_NoNullElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllNotNull("test1", "test2", "test3");

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyNotNull

    [Fact]
    public void AnyNotNull_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_AllNullElements_ReturnsFalse()
    {
        // Arrange
        var input = new object?[] { null, null, null };

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_MixedElements_ReturnsTrue()
    {
        // Arrange
        var input = new object?[] { null, "test", null };

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_NoNullElements_ReturnsTrue()
    {
        // Arrange
        var input = new object?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AnyNotNull();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNotNull((object?[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_Params_EmptyArray_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = YANObject.AnyNotNull(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_Params_AllNullElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNotNull((object?)null, null, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNull_Params_MixedElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNotNull(null, "test", null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNull_Params_NoNullElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNotNull("test1", "test2", "test3");

        // Assert
        Assert.True(result);
    }

    #endregion

    #region IsDefault

    [Fact]
    public void IsDefault_DefaultInt_ReturnsTrue()
    {
        // Arrange
        int input = default;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_NonDefaultInt_ReturnsFalse()
    {
        // Arrange
        var input = 42;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsDefault_DefaultString_ReturnsTrue()
    {
        // Arrange
        string? input = default;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_EmptyString_ReturnsFalse()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsDefault_DefaultDateTime_ReturnsTrue()
    {
        // Arrange
        DateTime input = default;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_DefaultStruct_ReturnsTrue()
    {
        // Arrange
        TestStruct input = default;

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsDefault_NonDefaultStruct_ReturnsFalse()
    {
        // Arrange
        var input = new TestStruct
        {
            Value = 42
        };

        // Act
        var result = input.IsDefault();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllDefault

    [Fact]
    public void AllDefault_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<int>();

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_AllDefaultElements_ReturnsTrue()
    {
        // Arrange
        var input = new int[] { 0, 0, 0 };

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllDefault_MixedElements_ReturnsFalse()
    {
        // Arrange
        var input = new int[] { 0, 42, 0 };

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_NoDefaultElements_ReturnsFalse()
    {
        // Arrange
        var input = new int[] { 1, 2, 3 };

        // Act
        var result = input.AllDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllDefault((int[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllDefault<int>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllDefault_Params_AllDefaultElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllDefault(0, 0, 0);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllDefault_Params_MixedElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllDefault(0, 42, 0);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyDefault

    [Fact]
    public void AnyDefault_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<int>();

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_AllDefaultElements_ReturnsTrue()
    {
        // Arrange
        var input = new int[] { 0, 0, 0 };

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyDefault_MixedElements_ReturnsTrue()
    {
        // Arrange
        var input = new int[] { 0, 42, 0 };

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyDefault_NoDefaultElements_ReturnsFalse()
    {
        // Arrange
        var input = new int[] { 1, 2, 3 };

        // Act
        var result = input.AnyDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyDefault((int[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyDefault<int>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyDefault_Params_AllDefaultElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyDefault(0, 0, 0);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyDefault_Params_MixedElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyDefault(0, 42, 0);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyDefault_Params_NoDefaultElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyDefault(1, 2, 3);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region IsNotDefault

    [Fact]
    public void IsNotDefault_DefaultInt_ReturnsFalse()
    {
        // Arrange
        int input = default;

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotDefault_NonDefaultInt_ReturnsTrue()
    {
        // Arrange
        var input = 42;

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotDefault_DefaultString_ReturnsFalse()
    {
        // Arrange
        string? input = default;

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotDefault_EmptyString_ReturnsTrue()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNotDefault_DefaultStruct_ReturnsFalse()
    {
        // Arrange
        TestStruct input = default;

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotDefault_NonDefaultStruct_ReturnsTrue()
    {
        // Arrange
        var input = new TestStruct
        {
            Value = 42
        };

        // Act
        var result = input.IsNotDefault();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AllNotDefault

    [Fact]
    public void AllNotDefault_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<int>();

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_AllDefaultElements_ReturnsFalse()
    {
        // Arrange
        var input = new int[] { 0, 0, 0 };

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_MixedElements_ReturnsFalse()
    {
        // Arrange
        var input = new int[] { 0, 42, 0 };

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_NoDefaultElements_ReturnsTrue()
    {
        // Arrange
        var input = new int[] { 1, 2, 3 };

        // Act
        var result = input.AllNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotDefault_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotDefault((int[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotDefault<int>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_Params_AllDefaultElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotDefault(0, 0, 0);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_Params_MixedElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotDefault(0, 42, 0);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotDefault_Params_NoDefaultElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllNotDefault(1, 2, 3);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyNotDefault

    [Fact]
    public void AnyNotDefault_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<int>();

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_AllDefaultElements_ReturnsFalse()
    {
        // Arrange
        var input = new int[] { 0, 0, 0 };

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_MixedElements_ReturnsTrue()
    {
        // Arrange
        var input = new int[] { 0, 42, 0 };

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotDefault_NoDefaultElements_ReturnsTrue()
    {
        // Arrange
        var input = new int[] { 1, 2, 3 };

        // Act
        var result = input.AnyNotDefault();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotDefault_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNotDefault((int[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNotDefault<int>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_Params_AllDefaultElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNotDefault(0, 0, 0);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotDefault_Params_MixedElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNotDefault(0, 42, 0);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotDefault_Params_NoDefaultElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNotDefault(1, 2, 3);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region IsNullEmpty

    [Fact]
    public void IsNullEmpty_NullCollection_ReturnsTrue()
    {
        // Arrange
        IEnumerable<string>? input = null;

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_EmptyCollection_ReturnsTrue()
    {
        // Arrange
        var input = Array.Empty<string>();

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsNullEmpty_NonEmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = new[] { "test" };

        // Act
        var result = input.IsNullEmpty();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AllNullEmpty

    [Fact]
    public void AllNullEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_AllNullOrEmptyElements_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, string.Empty, null };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_MixedElements_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "test", string.Empty };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_NoNullOrEmptyElements_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AllNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNullEmpty((string?[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNullEmpty<string>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNullEmpty_Params_AllNullOrEmptyElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllNullEmpty(null, string.Empty, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNullEmpty_Params_MixedElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNullEmpty(null, "test", string.Empty);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region AnyNullEmpty

    [Fact]
    public void AnyNullEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_AllNullOrEmptyElements_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, string.Empty, null };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_MixedElements_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "test", string.Empty };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_NoNullOrEmptyElements_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AnyNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNullEmpty((string?[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNullEmpty<string>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNullEmpty_Params_AllNullOrEmptyElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNullEmpty(null, string.Empty, null);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_Params_MixedElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNullEmpty(null, "test", string.Empty);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNullEmpty_Params_NoNullOrEmptyElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNullEmpty("test1", "test2", "test3");

        // Assert
        Assert.False(result);
    }

    #endregion

    #region IsNotNullEmpty

    [Fact]
    public void IsNotNullEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string>? input = null;

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string>();

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsNotNullEmpty_NonEmptyCollection_ReturnsTrue()
    {
        // Arrange
        var input = new[] { "test" };

        // Act
        var result = input.IsNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AllNotNullEmpty

    [Fact]
    public void AllNotNullEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_AllNullOrEmptyElements_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, string.Empty, null };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_MixedElements_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, "test", string.Empty };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_NoNullOrEmptyElements_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AllNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AllNotNullEmpty_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotNullEmpty((string?[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotNullEmpty<string>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Params_AllNullOrEmptyElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotNullEmpty(null, string.Empty, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Params_MixedElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AllNotNullEmpty(null, "test", string.Empty);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllNotNullEmpty_Params_NoNullOrEmptyElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AllNotNullEmpty("test1", "test2", "test3");

        // Assert
        Assert.True(result);
    }

    #endregion

    #region AnyNotNullEmpty

    [Fact]
    public void AnyNotNullEmpty_NullCollection_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_EmptyCollection_ReturnsFalse()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_AllNullOrEmptyElements_ReturnsFalse()
    {
        // Arrange
        var input = new string?[] { null, string.Empty, null };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_MixedElements_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { null, "test", string.Empty };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_NoNullOrEmptyElements_ReturnsTrue()
    {
        // Arrange
        var input = new string?[] { "test1", "test2", "test3" };

        // Act
        var result = input.AnyNotNullEmpty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Params_NullArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNotNullEmpty((string?[]?)null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Params_EmptyArray_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNotNullEmpty<string>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Params_AllNullOrEmptyElements_ReturnsFalse()
    {
        // Act
        var result = YANObject.AnyNotNullEmpty(null, string.Empty, null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Params_MixedElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNotNullEmpty(null, "test", string.Empty);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyNotNullEmpty_Params_NoNullOrEmptyElements_ReturnsTrue()
    {
        // Act
        var result = YANObject.AnyNotNullEmpty("test1", "test2", "test3");

        // Assert
        Assert.True(result);
    }

    #endregion

    #region ChangeTimeZoneAllProperty

    [Fact]
    public void ChangeTimeZoneAllProperty_NullInput_ReturnsNull()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.ChangeTimeZoneAllProperty();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_NoDateTimeProperties_ReturnsSameObject()
    {
        // Arrange
        var input = new TestClassNoDateTime
        {
            Name = "Test"
        };

        // Act
        var result = input.ChangeTimeZoneAllProperty();

        // Assert
        Assert.Same(input, result);
        Assert.Equal("Test", result!.Name);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_WithDateTimeProperties_ChangesTimeZones()
    {
        // Arrange
        var date = new DateTime(2023, 6, 15, 12, 0, 0);
        var input = new TestClass { Date = date };
        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(date.AddHours(7), result.Date);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_WithNestedObjects_ChangesAllDateTimes()
    {
        // Arrange
        var date1 = new DateTime(2023, 6, 15, 12, 0, 0);
        var date2 = new DateTime(2023, 6, 16, 12, 0, 0);
        var nested = new TestClass { Date = date2 };
        var input = new TestClassWithNested
        {
            Date = date1,
            Nested = nested
        };

        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(date1.AddHours(7), result.Date);
        Assert.NotNull(result.Nested);
        Assert.Equal(date2.AddHours(7), result.Nested.Date);
    }

    [Fact]
    public void ChangeTimeZoneAllProperty_WithDateTimeList_ChangesAllDateTimes()
    {
        // Arrange
        var date1 = new DateTime(2023, 6, 15, 12, 0, 0);
        var date2 = new DateTime(2023, 6, 16, 12, 0, 0);
        var input = new TestClassWithList
        {
            Dates = [date1, date2]
        };

        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZoneAllProperty(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Dates);
        Assert.Equal(2, result.Dates.Count);
        Assert.Equal(date1.AddHours(7), result.Dates[0]);
        Assert.Equal(date2.AddHours(7), result.Dates[1]);
    }

    #endregion

    #region ChangeTimeZoneAllProperties

    [Fact]
    public void ChangeTimeZoneAllProperties_NullInput_ReturnsNull()
    {
        // Arrange
        IEnumerable<TestClass>? input = null;

        // Act
        var result = input.ChangeTimeZoneAllProperties();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_EmptyInput_ReturnsEmptyCollection()
    {
        // Arrange
        var input = Array.Empty<TestClass>();

        // Act
        var result = input.ChangeTimeZoneAllProperties();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_WithDateTimeProperties_ChangesTimeZones()
    {
        // Arrange
        var date1 = new DateTime(2023, 6, 15, 12, 0, 0);
        var date2 = new DateTime(2023, 6, 16, 12, 0, 0);
        var input = new List<TestClass>
        {
            new() { Date = date1 },
            new() { Date = date2 }
        };

        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZoneAllProperties(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);

        var resultList = result.ToList();
        Assert.Equal(2, resultList.Count);
        Assert.Equal(date1.AddHours(7), resultList[0]!.Date);
        Assert.Equal(date2.AddHours(7), resultList[1]!.Date);
    }

    [Fact]
    public void ChangeTimeZoneAllProperties_MixedNullAndValidObjects_HandlesNullsCorrectly()
    {
        // Arrange
        var date = new DateTime(2023, 6, 15, 12, 0, 0);
        var input = new List<TestClass?>
        {
            new() { Date = date },
            null
        };

        var tzSrc = 0;
        var tzDst = 7;

        // Act
        var result = input.ChangeTimeZoneAllProperties(tzSrc, tzDst);

        // Assert
        Assert.NotNull(result);

        var resultList = result.ToList();
        Assert.Equal(2, resultList.Count);
        Assert.Equal(date.AddHours(7), resultList[0]?.Date);
        Assert.Null(resultList[1]);
    }

    #endregion

    #region Copy

    [Fact]
    public void Copy_NullInput_ReturnsNull()
    {
        // Arrange
        TestClass? input = null;

        // Act
        var result = input.Copy();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Copy_ValidObject_ReturnsNewObjectWithSameValues()
    {
        // Arrange
        var input = new TestClass
        {
            Date = new DateTime(2023, 6, 15),
            Name = "Test"
        };

        // Act
        var result = input.Copy();

        // Assert
        Assert.NotNull(result);
        Assert.NotSame(input, result);
        Assert.Equal(input.Date, result.Date);
        Assert.Equal(input.Name, result.Name);
    }

    [Fact]
    public void Copy_ComplexObject_CopiesAllProperties()
    {
        // Arrange
        var nested = new TestClass
        {
            Date = new DateTime(2023, 6, 16),
            Name = "Nested"
        };

        var input = new TestClassWithNested
        {
            Date = new DateTime(2023, 6, 15),
            Name = "Parent",
            Nested = nested
        };

        // Act
        var result = input.Copy();

        // Assert
        Assert.NotNull(result);
        Assert.NotSame(input, result);
        Assert.Equal(input.Date, result.Date);
        Assert.Equal(input.Name, result.Name);
        Assert.NotNull(result.Nested);
        Assert.Same(input.Nested, result.Nested);
    }

    #endregion

    #region Test Classes

    private struct TestStruct
    {
        public int Value { get; set; }
    }

    private class TestClass
    {
        public DateTime Date { get; set; }

        public string? Name { get; set; }
    }

    private class TestClassNoDateTime
    {
        public string? Name { get; set; }

        public int Value { get; set; }
    }

    private class TestClassWithNested
    {
        public DateTime Date { get; set; }

        public string? Name { get; set; }

        public TestClass? Nested { get; set; }
    }

    private class TestClassWithList
    {
        public List<DateTime>? Dates { get; set; }
    }

    #endregion
}
