using YANLib.Unmanaged;

namespace YANLib.Tests.Library.Unmanaged;

public partial class YANUnmanagedTest
{
    #region Basic Nullable Types

    [Fact]
    public void Parse_Nullable_NullToNullableInt_ReturnsNull()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_StringToNullableInt_ReturnsInt()
    {
        // Arrange
        object input = "123";

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Equal(123, result);
    }

    [Fact]
    public void Parse_Nullable_InvalidStringToNullableInt_ReturnsNull()
    {
        // Arrange
        object input = "abc";

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_DoubleToNullableInt_ReturnsInt()
    {
        // Arrange
        object input = 123.45;

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Equal(123, result);
    }

    [Fact]
    public void Parse_Nullable_StringToNullableDouble_ReturnsDouble()
    {
        // Arrange
        object input = "123.45";

        // Act
        var result = input.Parse<double?>();

        // Assert
        Assert.Equal(123.45, result);
    }

    [Fact]
    public void Parse_Nullable_InvalidStringToNullableDouble_ReturnsNull()
    {
        // Arrange
        object input = "abc";

        // Act
        var result = input.Parse<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_StringToNullableFloat_ReturnsFloat()
    {
        // Arrange
        object input = "123.45";

        // Act
        var result = input.Parse<float?>();

        // Assert
        Assert.Equal(123.45f, result);
    }

    [Fact]
    public void Parse_Nullable_StringToNullableBool_ReturnsBool()
    {
        // Arrange
        object input = "true";

        // Act
        var result = input.Parse<bool?>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Parse_Nullable_InvalidStringToNullableBool_ReturnsNull()
    {
        // Arrange
        object input = "abc";

        // Act
        var result = input.Parse<bool?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_StringToNullableChar_ReturnsChar()
    {
        // Arrange
        object input = "A";

        // Act
        var result = input.Parse<char?>();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Parse_Nullable_EmptyStringToNullableChar_ReturnsNull()
    {
        // Arrange
        object input = "";

        // Act
        var result = input.Parse<char?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_StringToString_ReturnsString()
    {
        // Arrange
        object input = "test string";

        // Act
        var result = input.Parse<string>();

        // Assert
        Assert.Equal("test string", result);
    }

    [Fact]
    public void Parse_Nullable_NullToString_ReturnsNull()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Parse<string>();

        // Assert
        Assert.Null(result);
    }

    #endregion

    #region Nullable DateTime

    [Fact]
    public void Parse_Nullable_StringToNullableDateTime_ReturnsDateTime()
    {
        // Arrange
        object input = "2023-01-15";

        // Act
        var result = input.Parse<DateTime?>();

        // Assert
        Assert.Equal(new DateTime(2023, 1, 15), result);
    }

    [Fact]
    public void Parse_Nullable_InvalidStringToNullableDateTime_ReturnsNull()
    {
        // Arrange
        object input = "not a date";

        // Act
        var result = input.Parse<DateTime?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_NullToNullableDateTime_ReturnsNull()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Parse<DateTime?>();

        // Assert
        Assert.Null(result);
    }

    #endregion

    #region Nullable Guid

    [Fact]
    public void Parse_Nullable_StringToNullableGuid_ReturnsGuid()
    {
        // Arrange
        var guid = Guid.NewGuid();
        object input = guid.ToString();

        // Act
        var result = input.Parse<Guid?>();

        // Assert
        Assert.Equal(guid, result);
    }

    [Fact]
    public void Parse_Nullable_InvalidStringToNullableGuid_ReturnsNull()
    {
        // Arrange
        object input = "not a guid";

        // Act
        var result = input.Parse<Guid?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_NullToNullableGuid_ReturnsNull()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Parse<Guid?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_StringToGuid_ReturnsGuid()
    {
        // Arrange
        var guid = Guid.NewGuid();
        object input = guid.ToString();

        // Act
        var result = input.Parse<Guid>();

        // Assert
        Assert.Equal(guid, result);
    }

    [Fact]
    public void Parse_Nullable_InvalidStringToGuid_ReturnsEmptyGuid()
    {
        // Arrange
        object input = "not a guid";

        // Act
        var result = input.Parse<Guid>();

        // Assert
        Assert.Equal(Guid.Empty, result);
    }

    #endregion

    #region Nullable Enum

    [Fact]
    public void Parse_Nullable_StringToNullableEnum_ReturnsEnum()
    {
        // Arrange
        object input = "First";

        // Act
        var result = input.Parse<TestEnum?>();

        // Assert
        Assert.Equal(TestEnum.First, result);
    }

    [Fact]
    public void Parse_Nullable_StringToNullableEnumIgnoreCase_ReturnsEnum()
    {
        // Arrange
        object input = "first";

        // Act
        var result = input.Parse<TestEnum?>();

        // Assert
        Assert.Equal(TestEnum.First, result);
    }

    [Fact]
    public void Parse_Nullable_NumberToNullableEnum_ReturnsEnum()
    {
        // Arrange
        object input = 2;

        // Act
        var result = input.Parse<TestEnum?>();

        // Assert
        Assert.Equal(TestEnum.Second, result);
    }

    [Fact]
    public void Parse_Nullable_InvalidStringToNullableEnum_ReturnsNull()
    {
        // Arrange
        object input = "NotAnEnum";

        // Act
        var result = input.Parse<TestEnum?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_NullToNullableEnum_ReturnsNull()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Parse<TestEnum?>();

        // Assert
        Assert.Null(result);
    }

    #endregion

    #region Nullable Collection

    [Fact]
    public void Parses_Nullable_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Parses<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_Nullable_EmptyCollection_ReturnsNull()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.Parses<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_Nullable_StringsToNullableInts_ReturnsInts()
    {
        // Arrange
        var input = new object?[] { "123", "456", "789" };

        // Act
        var result = input.Parses<int?>();

        // Assert
        Assert.Equal([123, 456, 789], result);
    }

    [Fact]
    public void Parses_Nullable_MixedToNullableInts_ReturnsInts()
    {
        // Arrange
        var input = new object?[] { "123", 456, "789" };

        // Act
        var result = input.Parses<int?>();

        // Assert
        Assert.Equal([123, 456, 789], result);
    }

    [Fact]
    public void Parses_Nullable_MixedWithInvalidToNullableInts_ReturnsIntsWithNulls()
    {
        // Arrange
        var input = new object?[] { "123", "abc", "789" };

        // Act
        var result = input.Parses<int?>();

        // Assert
        Assert.Equal([123, null, 789], result);
    }

    [Fact]
    public void Parses_Nullable_MixedWithNullToNullableInts_ReturnsIntsWithNulls()
    {
        // Arrange
        var input = new object?[] { "123", null, "789" };

        // Act
        var result = input.Parses<int?>();

        // Assert
        Assert.Equal([123, null, 789], result);
    }

    [Fact]
    public void Parses_Nullable_StringsToNullableDoubles_ReturnsDoubles()
    {
        // Arrange
        var input = new object?[] { "123.45", "456.78", "789.01" };

        // Act
        var result = input.Parses<double?>();

        // Assert
        Assert.Equal([123.45, 456.78, 789.01], result);
    }

    [Fact]
    public void Parses_Nullable_StringsToNullableDateTimes_ReturnsDateTimes()
    {
        // Arrange
        var input = new object?[] { "2023-01-15", "2023-02-20", "2023-03-25" };

        // Act
        var result = input.Parses<DateTime?>();

        // Assert
        Assert.Equal([new DateTime(2023, 1, 15), new DateTime(2023, 2, 20), new DateTime(2023, 3, 25)], result);
    }

    [Fact]
    public void Parses_Nullable_StringsWithInvalidToNullableDateTimes_ReturnsDateTimesWithNulls()
    {
        // Arrange
        var input = new object?[] { "2023-01-15", "not a date", "2023-03-25" };

        // Act
        var result = input.Parses<DateTime?>();

        // Assert
        Assert.Equal([new DateTime(2023, 1, 15), null, new DateTime(2023, 3, 25)], result);
    }

    [Fact]
    public void Parses_Nullable_StringsToNullableGuids_ReturnsGuids()
    {
        // Arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        var guid3 = Guid.NewGuid();
        var input = new object?[] { guid1.ToString(), guid2.ToString(), guid3.ToString() };

        // Act
        var result = input.Parses<Guid?>();

        // Assert
        Assert.Equal([guid1, guid2, guid3], result);
    }

    [Fact]
    public void Parses_Nullable_StringsWithInvalidToNullableGuids_ReturnsGuidsWithNulls()
    {
        // Arrange
        var guid1 = Guid.NewGuid();
        var guid3 = Guid.NewGuid();
        var input = new object?[] { guid1.ToString(), "not a guid", guid3.ToString() };

        // Act
        var result = input.Parses<Guid?>();

        // Assert
        Assert.Equal([guid1, null, guid3], result);
    }

    [Fact]
    public void Parses_Nullable_StringsToNullableEnums_ReturnsEnums()
    {
        // Arrange
        var input = new object?[] { "None", "First", "Second" };

        // Act
        var result = input.Parses<TestEnum?>();

        // Assert
        Assert.Equal([TestEnum.None, TestEnum.First, TestEnum.Second], result);
    }

    [Fact]
    public void Parses_Nullable_MixedToNullableEnums_ReturnsEnums()
    {
        // Arrange
        var input = new object?[] { "None", 1, "Second" };

        // Act
        var result = input.Parses<TestEnum?>();

        // Assert
        Assert.Equal([TestEnum.None, TestEnum.First, TestEnum.Second], result);
    }

    [Fact]
    public void Parses_Nullable_MixedWithInvalidToNullableEnums_ReturnsEnumsWithNulls()
    {
        // Arrange
        var input = new object?[] { "None", "NotAnEnum", "Second" };

        // Act
        var result = input.Parses<TestEnum?>();

        // Assert
        Assert.Equal([TestEnum.None, null, TestEnum.Second], result);
    }

    #endregion

    #region Params

    [Fact]
    public void Parses_Nullable_ParamsNullInput_ReturnsNull()
    {
        // Act
        var result = YANUnmanaged.Parses<int?>(null);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_Nullable_ParamsEmptyInput_ReturnsNull()
    {
        // Act
        var result = YANUnmanaged.Parses<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parses_Nullable_ParamsStringsToNullableInts_ReturnsInts()
    {
        // Act
        var result = YANUnmanaged.Parses<int?>("123", "456", "789");

        // Assert
        Assert.Equal([123, 456, 789], result);
    }

    [Fact]
    public void Parses_Nullable_ParamsMixedToNullableInts_ReturnsInts()
    {
        // Act
        var result = YANUnmanaged.Parses<int?>("123", 456, "789");

        // Assert
        Assert.Equal([123, 456, 789], result);
    }

    [Fact]
    public void Parses_Nullable_ParamsMixedWithInvalidToNullableInts_ReturnsIntsWithNulls()
    {
        // Act
        var result = YANUnmanaged.Parses<int?>("123", "abc", "789");

        // Assert
        Assert.Equal([123, null, 789], result);
    }

    [Fact]
    public void Parses_Nullable_ParamsMixedWithNullToNullableInts_ReturnsIntsWithNulls()
    {
        // Act
        var result = YANUnmanaged.Parses<int?>("123", null, "789");

        // Assert
        Assert.Equal([123, null, 789], result);
    }

    [Fact]
    public void Parses_Nullable_ParamsStringsToNullableDateTimes_ReturnsDateTimes()
    {
        // Act
        var result = YANUnmanaged.Parses<DateTime?>("2023-01-15", "2023-02-20", "2023-03-25");

        // Assert
        Assert.Equal([new DateTime(2023, 1, 15), new DateTime(2023, 2, 20), new DateTime(2023, 3, 25)], result);
    }

    [Fact]
    public void Parses_Nullable_ParamsStringsToNullableGuids_ReturnsGuids()
    {
        // Arrange
        var guid1 = Guid.NewGuid();
        var guid2 = Guid.NewGuid();
        var guid3 = Guid.NewGuid();

        // Act
        var result = YANUnmanaged.Parses<Guid?>(guid1.ToString(), guid2.ToString(), guid3.ToString());

        // Assert
        Assert.Equal([guid1, guid2, guid3], result);
    }

    [Fact]
    public void Parses_Nullable_ParamsStringsToNullableEnums_ReturnsEnums()
    {
        // Act
        var result = YANUnmanaged.Parses<TestEnum?>("None", "First", "Second");

        // Assert
        Assert.Equal([TestEnum.None, TestEnum.First, TestEnum.Second], result);
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void Parse_Nullable_MaxValueToNullableInt_ReturnsMaxValue()
    {
        // Arrange
        object input = int.MaxValue;

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Equal(int.MaxValue, result);
    }

    [Fact]
    public void Parse_Nullable_MinValueToNullableInt_ReturnsMinValue()
    {
        // Arrange
        object input = int.MinValue;

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Equal(int.MinValue, result);
    }

    [Fact]
    public void Parse_Nullable_OverflowToNullableInt_ReturnsNull()
    {
        // Arrange
        object input = long.MaxValue;

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_EmptyStringToNullableInt_ReturnsNull()
    {
        // Arrange
        object input = "";

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_WhitespaceToNullableInt_ReturnsNull()
    {
        // Arrange
        object input = "   ";

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_Nullable_DBNullToNullableInt_ReturnsNull()
    {
        // Arrange
        object input = DBNull.Value;

        // Act
        var result = input.Parse<int?>();

        // Assert
        Assert.Null(result);
    }

    #endregion
}
