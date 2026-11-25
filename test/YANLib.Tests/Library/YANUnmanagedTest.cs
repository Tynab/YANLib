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

    [Fact]
    public void Parse_FloatingPointNearDecimalLimit_ConvertsLikeConvertToDecimal()
    {
        // Arrange (every double/float below 2^96 converts to decimal; 2^96 and above overflow)
        var twoPow96 = 79228162514264337593543950336.0;
        object[] inRange = [7.91e28, -7.91e28, Math.BitDecrement(twoPow96), 7.91e28f];
        object outOfRange = twoPow96;

        // Act & Assert
        Assert.All(inRange, static x => Assert.Equal(Convert.ToDecimal(x), x.Parse<decimal>()));
        Assert.Equal(0m, outOfRange.Parse<decimal>());
        Assert.Equal(-1m, outOfRange.Parse<decimal>(-1m));
        Assert.Null(outOfRange.Parse<decimal?>());
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
    public void Parse_StringDefaultValueNotMatchingFormat_FallsBackToGeneralParse()
    {
        // Act (before 8.4.0 the string default was parsed with the format only, so these returned DateTime.MinValue)
        var (iso, enumerableFormat, usDefault, ukDefault) = WithCulture(new CultureInfo("en-US"), static () => (
            "bad".Parse<DateTime>("2025-01-01", "dd/MM/yyyy"),
            "bad".Parse<DateTime>("2025-01-01", new List<string?> { "dd/MM/yyyy" }),
            "bad".Parse<DateTime>("01/02/2025", "yyyyMMdd"),
            WithCulture(new CultureInfo("en-GB"), static () => "bad".Parse<DateTime>("01/02/2025", "yyyyMMdd"))));

        // Assert (the general parse uses the current culture)
        Assert.Equal(new DateTime(2025, 1, 1), iso);
        Assert.Equal(new DateTime(2025, 1, 1), enumerableFormat);
        Assert.Equal(new DateTime(2025, 1, 2), usDefault);
        Assert.Equal(new DateTime(2025, 2, 1), ukDefault);
    }

    [Fact]
    public void Parse_StringDefaultValueMatchingFormat_UsesFormatFirst()
    {
        // Act (en-US would read "02/01/2025" as 1 February; the format reads it as 2 January)
        var (result, minValue) = WithCulture(new CultureInfo("en-US"), static () => ("bad".Parse<DateTime>("02/01/2025", "dd/MM/yyyy"), "bad".Parse<DateTime>("01/01/0001", "dd/MM/yyyy")));

        // Assert
        Assert.Equal(new DateTime(2025, 1, 2), result);
        Assert.Equal(DateTime.MinValue, minValue);
    }

    [Fact]
    public void Parse_UnparsableStringDefaultValueWithFormat_ReturnsMinValue()
    {
        // Act
        var (bad, blank, input) = WithCulture(new CultureInfo("en-US"), static () => (
            "bad".Parse<DateTime>("also bad", "dd/MM/yyyy"),
            "bad".Parse<DateTime>(" ", "dd/MM/yyyy"),
            "15/06/2023".Parse<DateTime>("2025-01-01", "dd/MM/yyyy")));

        // Assert (a valid input still wins over the default)
        Assert.Equal(DateTime.MinValue, bad);
        Assert.Equal(DateTime.MinValue, blank);
        Assert.Equal(new DateTime(2023, 6, 15), input);
    }

    [Fact]
    public void ParseWith_StringDefaultValueNotMatchingFormat_FallsBackToProvider()
    {
        // Arrange
        var german = new CultureInfo("de-DE");

        // Act (the current culture is en-US; the general parse of the default uses the provider)
        var (result, enumerableFormat, invariantFormat) = WithCulture(new CultureInfo("en-US"), () => (
            "bad".ParseWith<DateTime>(german, "01.02.2025", "yyyyMMdd"),
            "bad".ParseWith<DateTime>(german, "01.02.2025", new List<string?> { "yyyyMMdd" }),
            "bad".ParseWith<DateTime>(german, "20250102", "yyyyMMdd")));

        // Assert
        Assert.Equal(new DateTime(2025, 2, 1), result);
        Assert.Equal(new DateTime(2025, 2, 1), enumerableFormat);
        Assert.Equal(new DateTime(2025, 1, 2), invariantFormat);
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

    #region ParseWith

    [Theory]
    [InlineData("de-DE")]
    [InlineData("vi-VN")]
    public void ParseWith_InvariantProviderUnderCommaDecimalCulture_ParsesDotAsDecimalSeparator(string culture)
    {
        // Act
        var (with, existing) = WithCulture(new CultureInfo(culture), static () => ("1.5".ParseWith<double>(CultureInfo.InvariantCulture, 0d), "1.5".Parse<double>(0d)));

        // Assert (the existing overload reads the current culture, where '.' is the group separator)
        Assert.Equal(1.5, with);
        Assert.Equal(15, existing);
    }

    [Fact]
    public void ParseWith_GermanProviderUnderInvariantCulture_ParsesCommaAsDecimalSeparator()
    {
        // Arrange
        var german = new CultureInfo("de-DE");

        // Act
        var (number, grouped, existing) = WithCulture(CultureInfo.InvariantCulture, () => ("1,5".ParseWith<double>(german, 0d), "-1.234,5".ParseWith<decimal>(german, 0m), "1,5".Parse<double>(0d)));

        // Assert
        Assert.Equal(1.5, number);
        Assert.Equal(-1234.5m, grouped);
        Assert.Equal(15, existing);
    }

    [Fact]
    public void ParseWith_NullProvider_UsesCurrentCultureLikeParse()
    {
        // Act
        var (withNull, existing, comma) = WithCulture(new CultureInfo("de-DE"), static () => ("1.5".ParseWith<double>(null, 0d), "1.5".Parse<double>(0d), "1,5".ParseWith<double>(null, 0d, (IEnumerable<string?>?)null)));

        // Assert
        Assert.Equal(existing, withNull);
        Assert.Equal(15, withNull);
        Assert.Equal(1.5, comma);
    }

    [Fact]
    public void ParseWith_StringDefaultValue_IsParsedWithProvider()
    {
        // Act
        var (with, existing) = WithCulture(new CultureInfo("de-DE"), static () => ("abc".ParseWith<double>(CultureInfo.InvariantCulture, "2.5"), "abc".Parse<double>("2.5")));

        // Assert
        Assert.Equal(2.5, with);
        Assert.Equal(25, existing);
    }

    [Fact]
    public void ParseWith_StringDefaultValueForDateTimeAndTimeSpan_IsParsedWithProvider()
    {
        // Act (under the invariant culture "01/02/2025" is 2 January and "1:02:03:04,5" is no TimeSpan)
        var (british, american, timeSpan, invariantTimeSpan) = WithCulture(CultureInfo.InvariantCulture, static () => (
            "abc".ParseWith<DateTime>(new CultureInfo("en-GB"), "01/02/2025"),
            "abc".ParseWith<DateTime>(new CultureInfo("en-US"), "01/02/2025"),
            "abc".ParseWith<TimeSpan>(new CultureInfo("de-DE"), "1:02:03:04,5"),
            "abc".ParseWith<TimeSpan>(CultureInfo.InvariantCulture, "1:02:03:04,5")));

        // Assert
        Assert.Equal(new DateTime(2025, 2, 1), british);
        Assert.Equal(new DateTime(2025, 1, 2), american);
        Assert.Equal(new TimeSpan(1, 2, 3, 4, 500), timeSpan);
        Assert.Equal(TimeSpan.Zero, invariantTimeSpan);
    }

    [Fact]
    public void ParseWith_FractionalStringForInteger_ReturnsDefaultValueLikeParse()
    {
        // Act (the defaultValue overloads do not floor fractional strings, whatever the provider)
        var (withNullDefault, withDefault) = WithCulture(new CultureInfo("de-DE"), static () => ("3.7".ParseWith<int>(CultureInfo.InvariantCulture, null), "3.7".ParseWith<int>(CultureInfo.InvariantCulture, -1)));

        // Assert
        Assert.Equal(0, withNullDefault);
        Assert.Equal(-1, withDefault);
    }

    [Fact]
    public void ParseWith_DateTimeWithoutFormat_UsesProviderDatePattern()
    {
        // Arrange
        object input = "01/02/2025";

        // Act
        var (us, british, existing) = WithCulture(CultureInfo.InvariantCulture, () => (input.ParseWith<DateTime>(new CultureInfo("en-US"), null), input.ParseWith<DateTime>(new CultureInfo("en-GB"), null), input.Parse<DateTime>(null)));

        // Assert
        Assert.Equal(new DateTime(2025, 1, 2), us);
        Assert.Equal(new DateTime(2025, 2, 1), british);
        Assert.Equal(new DateTime(2025, 1, 2), existing);
    }

    [Fact]
    public void ParseWith_DateTimeTextOfProvider_RoundTrips()
    {
        // Arrange (the text comes from the BCL, so the test does not depend on the ICU version's date pattern)
        var german = new CultureInfo("de-DE");
        var expected = new DateTime(2025, 12, 13, 14, 15, 16);
        object input = expected.ToString(german);

        // Act
        var result = WithCulture(new CultureInfo("en-US"), () => input.ParseWith<DateTime>(german, DateTime.MaxValue));

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseWith_ExactFormat_IsMatchedWithInvariantCulture()
    {
        // Arrange
        var german = new CultureInfo("de-DE");

        // Act (as with Parse, '/' in an exact format is a literal slash; the provider does not change the formats)
        var (slash, dot) = WithCulture(german, () => ("13/12/2025".ParseWith<DateTime>(german, null, "dd/MM/yyyy"), "13.12.2025".ParseWith<DateTime>(german, null, new List<string?> { "dd/MM/yyyy" })));

        // Assert
        Assert.Equal(new DateTime(2025, 12, 13), slash);
        Assert.Equal(default, dot);
    }

    [Fact]
    public void ParseWith_TimeSpanWithCultureDecimalSeparator_UsesProvider()
    {
        // Arrange
        object input = "1:02:03:04,5";
        var fallback = TimeSpan.FromMinutes(77);
        var expected = TimeSpan.Parse("1:02:03:04,5", new CultureInfo("de-DE"));

        // Act
        var (german, invariant) = WithCulture(CultureInfo.InvariantCulture, () => (input.ParseWith<TimeSpan>(new CultureInfo("de-DE"), fallback), input.ParseWith<TimeSpan>(CultureInfo.InvariantCulture, fallback)));

        // Assert
        Assert.Equal(new TimeSpan(1, 2, 3, 4, 500), expected);
        Assert.Equal(expected, german);
        Assert.Equal(fallback, invariant);
    }

    [Fact]
    public void ParseWith_CustomConvertible_ReceivesProvider()
    {
        // Arrange
        object input = new ProviderEchoConvertible();
        var german = new CultureInfo("de-DE");

        // Act
        var (with, withNull, existing) = WithCulture(new CultureInfo("vi-VN"), () => (input.ParseWith<long>(german, 0L), input.ParseWith<long>(null, 0L), input.Parse<long>(0L)));

        // Assert (a null provider passes the current culture, as Convert.ChangeType(object, Type) does)
        Assert.Equal(ProviderEchoConvertible.Code(german), with);
        Assert.Equal(ProviderEchoConvertible.Code(new CultureInfo("vi-VN")), withNull);
        Assert.Equal(withNull, existing);
    }

    [Fact]
    public void ParseWith_ProviderThrows_ReturnsDefaultValue()
    {
        // Arrange
        var provider = new ThrowingFormatProvider();
        var date = new DateTime(2000, 1, 1);
        var time = TimeSpan.FromMinutes(77);

        // Act & Assert (never throws: the step that uses the provider counts as a failed parse)
        Assert.Equal(42, "5".ParseWith<int>(provider, 42));
        Assert.Equal(42L, "5".ParseWith<long>(provider, 42L, (IEnumerable<string?>?)null));
        Assert.Equal(2.5, "1.5".ParseWith<double>(provider, 2.5));
        Assert.Equal(2.5m, "1.5".ParseWith<decimal>(provider, 2.5m));
        Assert.Equal(date, "2025-01-02".ParseWith<DateTime>(provider, date));
        Assert.Equal(date, ((object)1.5).ParseWith<DateTime>(provider, date));
        Assert.Equal(time, "01:02:03".ParseWith<TimeSpan>(provider, time));
        Assert.Equal(7, new ProviderEchoConvertible().ParseWith<int>(provider, 7));
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

    private sealed class ThrowingFormatProvider : IFormatProvider
    {
        public object? GetFormat(Type? formatType) => throw new InvalidOperationException("GetFormat failed");
    }

    /// <summary>Formats differently with and without a provider, to show which <c>ToString</c> the parse methods call.</summary>
    private sealed class FormattableEcho : IFormattable
    {
        public override string ToString() => "plain";

        public string ToString(string? format, IFormatProvider? formatProvider) => "formatted:" + (formatProvider as CultureInfo)?.Name;
    }

    /// <summary>A custom <see cref="IConvertible"/> whose numeric conversions report the provider they were handed.</summary>
    private sealed class ProviderEchoConvertible : IConvertible
    {
        public static int Code(IFormatProvider? provider) => provider switch
        {
            null => 1,
            CultureInfo { Name: "de-DE" } => 2,
            CultureInfo { Name: "vi-VN" } => 3,
            CultureInfo => 4,
            _ => provider.GetFormat(typeof(NumberFormatInfo)) is null ? 5 : 6
        };

        public TypeCode GetTypeCode() => TypeCode.Object;

        public bool ToBoolean(IFormatProvider? provider) => throw new InvalidCastException();

        public byte ToByte(IFormatProvider? provider) => (byte)Code(provider);

        public char ToChar(IFormatProvider? provider) => throw new InvalidCastException();

        public DateTime ToDateTime(IFormatProvider? provider) => throw new InvalidCastException();

        public decimal ToDecimal(IFormatProvider? provider) => Code(provider);

        public double ToDouble(IFormatProvider? provider) => Code(provider);

        public short ToInt16(IFormatProvider? provider) => (short)Code(provider);

        public int ToInt32(IFormatProvider? provider) => Code(provider);

        public long ToInt64(IFormatProvider? provider) => Code(provider);

        public sbyte ToSByte(IFormatProvider? provider) => (sbyte)Code(provider);

        public float ToSingle(IFormatProvider? provider) => Code(provider);

        public string ToString(IFormatProvider? provider) => "echo" + Code(provider);

        public object ToType(Type conversionType, IFormatProvider? provider) => throw new InvalidCastException();

        public ushort ToUInt16(IFormatProvider? provider) => (ushort)Code(provider);

        public uint ToUInt32(IFormatProvider? provider) => (uint)Code(provider);

        public ulong ToUInt64(IFormatProvider? provider) => (ulong)Code(provider);
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
