using System.Globalization;

namespace YANLib.Tests.Library;

public partial class YANUnmanagedTest
{
    #region Parse

    [Fact]
    public void Parse_NullInput_ReturnsDefaultValue()
    {
        // Arrange
        object? input = null;
        var defaultValue = 42;

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    [Fact]
    public void Parse_ValidIntInput_ReturnsIntValue()
    {
        // Arrange
        object input = "123";

        // Act
        var result = input.Parse<int>();

        // Assert
        Assert.Equal(123, result);
    }

    [Fact]
    public void Parse_ValidDoubleInput_ReturnsDoubleValue()
    {
        // Arrange
        object input = "123.45";

        // Act
        var result = input.Parse<double>();

        // Assert
        Assert.Equal(123.45, result);
    }

    [Fact]
    public void Parse_InvalidInput_ReturnsDefaultValue()
    {
        // Arrange
        object input = "not a number";
        var defaultValue = 42;

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    [Fact]
    public void Parse_ValidDateTimeInput_ReturnsDateTime()
    {
        // Arrange
        object input = "2023-06-15";
        var expected = new DateTime(2023, 6, 15);

        // Act
        var result = input.Parse<DateTime>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_DateTimeWithFormat_UsesFormat()
    {
        // Arrange
        object input = "15/06/2023";
        var expected = new DateTime(2023, 6, 15);
        string[] format = ["dd/MM/yyyy"];

        // Act
        var result = input.Parse<DateTime>(null, format);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_EnumInput_ReturnsEnumValue()
    {
        // Arrange
        object input = "Tuesday";

        // Act
        var result = input.Parse<DayOfWeek>();

        // Assert
        Assert.Equal(DayOfWeek.Tuesday, result);
    }

    [Fact]
    public void Parse_EnumInputCaseInsensitive_ReturnsEnumValue()
    {
        // Arrange
        object input = "tuesday";

        // Act
        var result = input.Parse<DayOfWeek>();

        // Assert
        Assert.Equal(DayOfWeek.Tuesday, result);
    }

    [Fact]
    public void Parse_InvalidEnumInput_ReturnsDefaultValue()
    {
        // Arrange
        object input = "NotADay";
        var defaultValue = DayOfWeek.Friday;

        // Act
        var result = input.Parse<DayOfWeek>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    [Fact]
    public void Parse_BoolInput_ReturnsBoolValue()
    {
        // Arrange
        object input = "true";

        // Act
        var result = input.Parse<bool>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Parse_CharInput_ReturnsCharValue()
    {
        // Arrange
        object input = "A";

        // Act
        var result = input.Parse<char>();

        // Assert
        Assert.Equal('A', result);
    }

    [Fact]
    public void Parse_GuidInput_ReturnsGuidValue()
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
    public void Parse_TimeSpanInput_ReturnsTimeSpanValue()
    {
        // Arrange
        object input = "01:30:45";
        var expected = new TimeSpan(1, 30, 45);

        // Act
        var result = input.Parse<TimeSpan>();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_ParamsFormatOverload_UsesFormat()
    {
        // Arrange
        object input = "15/06/2023";
        var expected = new DateTime(2023, 6, 15);

        // Act
        var result = input.Parse<DateTime>(null, "dd/MM/yyyy");

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_InvalidGuidInput_ReturnsDefaultValue()
    {
        // Arrange
        object input = "not a guid";
        var defaultValue = Guid.NewGuid();

        // Act
        var result = input.Parse<Guid>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    [Fact]
    public void Parse_EmptyString_ReturnsDefaultValue()
    {
        // Arrange
        object input = "";
        var defaultValue = 42;

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    [Fact]
    public void Parse_WhitespaceString_ReturnsDefaultValue()
    {
        // Arrange
        object input = "   ";
        var defaultValue = 42;

        // Act
        var result = input.Parse<int>(defaultValue);

        // Assert
        Assert.Equal(defaultValue, result);
    }

    #endregion

    #region Parse - overflow, native integers, rounding

    // 8.3.3 recursed forever (stack overflow, process crash) whenever an integer conversion overflowed in the
    // one-argument overload, and could not convert to or from nint/nuint at all.

    [Theory]
    [InlineData("99999999999")]
    [InlineData("-99999999999")]
    [InlineData("2147483648")]
    [InlineData("18446744073709551616")]
    public void Parse_OutOfRangeString_ReturnsZero(string input)
    {
        // Act
        var result = WithCulture(CultureInfo.InvariantCulture, () => input.Parse<int>());

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Parse_OutOfRangeBoxedNumber_ReturnsZero()
    {
        // Arrange
        object?[] inputs = [1e10, -1e10, 3_000_000_000u, long.MaxValue, ulong.MaxValue, 100_000_000_000_000_000_000m, 1e20f, double.NaN, double.PositiveInfinity];

        // Act
        var results = inputs.Select(static x => x.Parse<int>()).ToList();

        // Assert
        Assert.All(results, static x => Assert.Equal(0, x));
    }

    [Fact]
    public void Parse_OutOfRangeWithDefaultValue_ReturnsDefaultValue()
    {
        // Arrange
        object input = 1e10;
        object text = "99999999999";

        // Act
        var result = input.Parse<int>(-1);
        var textResult = text.Parse<int>(-1);

        // Assert
        Assert.Equal(-1, result);
        Assert.Equal(-1, textResult);
    }

    [Fact]
    public void Parse_NegativeToUnsigned_ReturnsZero()
    {
        // Arrange
        object text = "-5";
        object number = -1L;

        // Act
        var byteResult = text.Parse<byte>();
        var ulongResult = number.Parse<ulong>();

        // Assert
        Assert.Equal(0, byteResult);
        Assert.Equal(0UL, ulongResult);
    }

    [Fact]
    public void Parse_ToNativeInteger_Converts()
    {
        // Arrange
        object boxed = 5;
        object text = "5";
        object negative = "-5";
        object big = (ulong)uint.MaxValue;

        // Act & Assert
        Assert.Equal(5, boxed.Parse<nint>());
        Assert.Equal(5, boxed.Parse<nint>(0));
        Assert.Equal(5, text.Parse<nint>(0));
        Assert.Equal(-5, negative.Parse<nint>());
        Assert.Equal(5U, text.Parse<nuint>());
        Assert.Equal(0U, negative.Parse<nuint>());
        Assert.Equal(uint.MaxValue, big.Parse<nuint>());
    }

    [Fact]
    public void Parse_FromNativeInteger_Converts()
    {
        // Arrange
        object signed = (nint)(-7);
        object unsigned = (nuint)7;

        // Act & Assert
        Assert.Equal(-7, signed.Parse<int>());
        Assert.Equal(-7L, signed.Parse<long>(0));
        Assert.Equal(7L, unsigned.Parse<long>());
        Assert.Equal(7.0, unsigned.Parse<double>());
        Assert.Equal(0U, signed.Parse<uint>());
    }

    [Fact]
    public void Parse_BoxedFraction_RoundsHalfToEvenLikeConvert()
    {
        // Act & Assert (unchanged 8.3.3 behaviour: boxed numbers go through Convert semantics)
        Assert.Equal(4, ((object)3.7).Parse<int>());
        Assert.Equal(2, ((object)2.5).Parse<int>());
        Assert.Equal(4, ((object)3.5).Parse<int>());
        Assert.Equal(-2, ((object)(-2.5)).Parse<int>());
        Assert.Equal(2, ((object)2.5m).Parse<int>(-77));
    }

    [Fact]
    public void Parse_FractionalString_FloorsOnlyWithoutDefaultValue()
    {
        // Act
        var (floored, negative, withDefault) = WithCulture(CultureInfo.InvariantCulture, static () => ("3.7".Parse<int>(), "-3.5".Parse<int>(), "3.5".Parse<int>(-77)));

        // Assert (unchanged 8.3.3 behaviour; the overload asymmetry is an open decision)
        Assert.Equal(3, floored);
        Assert.Equal(-4, negative);
        Assert.Equal(-77, withDefault);
    }

    [Fact]
    public void Parse_RoundedValueOverflowsButFloorFits_ReturnsFloor()
    {
        // Act & Assert
        Assert.Equal(int.MaxValue, ((object)2147483647.6).Parse<int>());
        Assert.Equal(byte.MaxValue, ((object)255.5).Parse<byte>());
        Assert.Equal(long.MaxValue, ((object)9223372036854775807.5m).Parse<long>());
    }

    // Integer targets floor the exact decimal value; 8.3.3 floored through double and lost digits past ~15
    [Theory]
    [InlineData("2.9999999999999999", "int", 2)]
    [InlineData("0.99999999999999999999", "byte", 0)]
    [InlineData("12345678901234567.9", "long", 12345678901234567)]
    [InlineData("-0.5", "long", -1)]
    public void Parse_FractionalStringBeyondDoublePrecision_FloorsExactDecimal(string input, string target, long expected)
    {
        // Act
        var result = WithCulture(CultureInfo.InvariantCulture, () => target switch
        {
            "int" => input.Parse<int>(),
            "byte" => input.Parse<byte>(),
            _ => input.Parse<long>()
        });

        // Assert
        Assert.Equal(expected, result);
    }

    #endregion

    #region Parse - input already of the target type, ToString failures

    [Fact]
    public void Parse_DateTimeInput_KeepsMillisecondsAndKind()
    {
        // Arrange
        object input = new DateTime(2025, 1, 2, 3, 4, 5, 678, DateTimeKind.Utc);

        // Act
        var result = input.Parse<DateTime>(DateTime.MaxValue);

        // Assert (8.3.3 round-tripped the value through ToString() and lost .678 and Kind)
        Assert.Equal(input, result);
        Assert.Equal(DateTimeKind.Utc, result.Kind);
    }

    [Fact]
    public void Parse_DateTimeDefaultValueWithFormat_ReturnsDefaultValue()
    {
        // Arrange
        object input = "not a date";
        var defaultValue = new DateTime(1999, 9, 9, 9, 9, 9, 999, DateTimeKind.Utc);

        // Act
        var result = input.Parse<DateTime>(defaultValue, "dd/MM/yyyy");
        var withoutFormat = input.Parse<DateTime>(defaultValue);

        // Assert (8.3.3 re-parsed defaultValue.ToString() with the format and returned DateTime.MinValue)
        Assert.Equal(defaultValue, result);
        Assert.Equal(DateTimeKind.Utc, result.Kind);
        Assert.Equal(defaultValue, withoutFormat);
    }

    [Fact]
    public void Parse_DateTimeStringWithMilliseconds_KeepsMilliseconds()
    {
        // Act
        var result = WithCulture(CultureInfo.InvariantCulture, static () => "2025-01-02 03:04:05.678".Parse<DateTime>(DateTime.MaxValue));

        // Assert
        Assert.Equal(new DateTime(2025, 1, 2, 3, 4, 5, 678), result);
    }

    [Fact]
    public void Parse_UndefinedEnumValue_ReturnsSameValue()
    {
        // Arrange
        object input = (DayOfWeek)99;

        // Act
        var result = input.Parse<DayOfWeek>(DayOfWeek.Monday);

        // Assert
        Assert.Equal((DayOfWeek)99, result);
    }

    [Fact]
    public void Parse_InputWhoseToStringThrows_ReturnsDefaultValue()
    {
        // Arrange
        object input = new ThrowingToString();
        var date = new DateTime(2000, 1, 1);
        var guid = Guid.NewGuid();

        // Act & Assert (8.3.3 let the exception escape for DateTime, Guid, TimeSpan and enum targets)
        Assert.Equal(date, input.Parse<DateTime>(date));
        Assert.Equal(guid, input.Parse<Guid>(guid));
        Assert.Equal(TimeSpan.FromSeconds(1), input.Parse<TimeSpan>(TimeSpan.FromSeconds(1)));
        Assert.Equal(DayOfWeek.Friday, input.Parse<DayOfWeek>(DayOfWeek.Friday));
        Assert.Equal(42, input.Parse<int>(42));
    }

    #endregion

    private class Animal
    {
    }

    private sealed class Dog : Animal
    {
    }

    private sealed class ThrowingToString
    {
        public override string ToString() => throw new InvalidOperationException("ToString failed");
    }

    private static T WithCulture<T>(CultureInfo culture, Func<T> action)
    {
        var previous = CultureInfo.CurrentCulture;

        CultureInfo.CurrentCulture = culture;

        try
        {
            return action();
        }
        finally
        {
            CultureInfo.CurrentCulture = previous;
        }
    }
}
