using System.Globalization;
using System.Numerics;
using static System.Convert;
using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;
using static System.Nullable;

namespace YANLib.Implementation;

internal static partial class YANUnmanaged
{
    #region Private

    /// <remarks>
    /// Exact <paramref name="format"/> strings are always matched with the invariant culture, whatever <paramref name="provider"/> is
    /// (8.3.3 behaviour, kept by the overloads that take a provider).
    /// </remarks>
    private static DateTime ParseDateTime(this string? input, IFormatProvider? provider, DateTime defaultValue = default, IEnumerable<string?>? format = null)
        => input.IsNullWhiteSpaceImplement() ? defaultValue : format.IsNullEmptyImplement() ? TryParseDateTime(input, provider, out var dt) ? dt : defaultValue : TryParseExact(input, [.. format], InvariantCulture, None, out dt) ? dt : defaultValue;

    private static Guid ParseGuid(this string? input, Guid defaultValue = default) => input.IsNullWhiteSpaceImplement() ? defaultValue : Guid.TryParse(input, out var guid) ? guid : defaultValue;

    private static TimeSpan ParseTimeSpan(this string? input, IFormatProvider? provider, TimeSpan defaultValue = default) => input.IsNullWhiteSpaceImplement() ? defaultValue : TryParseTimeSpan(input, provider, out var ts) ? ts : defaultValue;

    private static T ParseEnum<T>(this string? input, T defaultValue = default) where T : unmanaged
        => input.IsNullWhiteSpaceImplement() ? defaultValue : Enum.TryParse(typeof(T), input, true, out var e) && e is T value ? value : defaultValue;

    private static DateTime? ParseDateTimeNullable(this string? input, IFormatProvider? provider) => input.IsNullWhiteSpaceImplement() ? default : TryParseDateTime(input, provider, out var dt) ? dt : default(DateTime?);

    private static Guid? ParseGuidNullable(this string? input) => input.IsNullWhiteSpaceImplement() ? default : Guid.TryParse(input, out var guid) ? guid : default(Guid?);

    private static TimeSpan? ParseTimeSpanNullable(this string? input, IFormatProvider? provider) => input.IsNullWhiteSpaceImplement() ? default : TryParseTimeSpan(input, provider, out var ts) ? ts : default(TimeSpan?);

    /// <summary>
    /// <see cref="DateTime.TryParse(string?, out DateTime)"/> (current culture) for a <c>null</c> <paramref name="provider"/>, as in 8.3.3;
    /// otherwise <see cref="DateTime.TryParse(string?, IFormatProvider?, DateTimeStyles, out DateTime)"/>, where a provider that throws
    /// counts as a failed parse.
    /// </summary>
    /// <remarks>
    /// The exception guard sits in a separate method so that the <c>null</c> path, which every existing overload takes, has no exception
    /// handler (with the handler in the same method, <c>"01:02:03".Parse&lt;TimeSpan&gt;(default)</c> measured about 10 ns slower).
    /// The same split is used by <see cref="TryParseTimeSpan"/>, <see cref="TryParseValue{TValue}"/> and <see cref="TryParseInteger{TInteger}"/>.
    /// </remarks>
    private static bool TryParseDateTime(string input, IFormatProvider? provider, out DateTime result)
        => provider is null ? TryParse(input, out result) : TryParseDateTimeGuarded(input, provider, out result);

    private static bool TryParseDateTimeGuarded(string input, IFormatProvider provider, out DateTime result)
    {
        try
        {
            return TryParse(input, provider, None, out result);
        }
        catch
        {
            result = default;

            return false;
        }
    }

    /// <summary>
    /// <see cref="TimeSpan.TryParse(string?, out TimeSpan)"/> (current culture) for a <c>null</c> <paramref name="provider"/>, as in 8.3.3;
    /// otherwise <see cref="TimeSpan.TryParse(string?, IFormatProvider?, out TimeSpan)"/>, where a provider that throws counts as a failed parse.
    /// </summary>
    private static bool TryParseTimeSpan(string input, IFormatProvider? provider, out TimeSpan result)
        => provider is null ? TimeSpan.TryParse(input, out result) : TryParseTimeSpanGuarded(input, provider, out result);

    private static bool TryParseTimeSpanGuarded(string input, IFormatProvider provider, out TimeSpan result)
    {
        try
        {
            return TimeSpan.TryParse(input, provider, out result);
        }
        catch
        {
            result = default;

            return false;
        }
    }

    /// <summary>
    /// The parse core of <c>ParseImplement</c> and <c>ParseWithImplement</c>: <paramref name="provider"/> is the culture for every
    /// culture-dependent step, and <c>null</c> keeps the 8.3.3 behaviour (current culture).
    /// </summary>
    private static T ParseHelper<T>(object? input, object? defaultValue, IEnumerable<string?>? format, IFormatProvider? provider) where T : unmanaged
    {
        // already the requested type: return it unchanged (8.3.3 round-tripped DateTime through ToString(), losing milliseconds and Kind)
        if (input is T value)
        {
            return value;
        }

        if (typeof(T) == typeof(DateTime))
        {
            // a DateTime default is used as is; 8.3.3 re-parsed its ToString() with the format and so ignored it when a format was given
            var fallback = defaultValue is DateTime dateTime ? dateTime : defaultValue.SafeToString(provider).ParseDateTime(provider, default, format);

            return (T)(object)input.SafeToString(provider).ParseDateTime(provider, fallback, format);
        }

        if (typeof(T) == typeof(Guid))
        {
            return (T)(object)input.SafeToString(provider).ParseGuid(defaultValue is Guid guid ? guid : defaultValue.SafeToString(provider).ParseGuid(default));
        }

        if (typeof(T) == typeof(TimeSpan))
        {
            return (T)(object)input.SafeToString(provider).ParseTimeSpan(provider, defaultValue is TimeSpan timeSpan ? timeSpan : defaultValue.SafeToString(provider).ParseTimeSpan(provider, default));
        }

        if (typeof(T).IsEnum)
        {
            return input.SafeToString(provider).ParseEnum(defaultValue is T enumValue ? enumValue : defaultValue.SafeToString(provider).ParseEnum<T>(default));
        }

        if (input is not null && TryChangeType(input, typeof(T), ParseCache<T>.Kind, false, provider, out var result) && result is T parsed)
        {
            return parsed;
        }

        return defaultValue switch
        {
            null => default,
            T typedDefault => typedDefault,
            _ => TryChangeType(defaultValue, typeof(T), ParseCache<T>.Kind, false, provider, out var converted) && converted is T convertedDefault ? convertedDefault : default
        };
    }

    /// <summary>
    /// Converts <paramref name="input"/> to <paramref name="targetType"/> without throwing and without recursion.
    /// </summary>
    /// <remarks>
    /// Keeps the <see cref="Convert.ChangeType(object, Type)"/> semantics of 8.3.3 (current culture, or <paramref name="provider"/> when it
    /// is not <c>null</c>; round-half-to-even for boxed fractional numbers) but range-checks numbers first instead of catching
    /// <see cref="OverflowException"/>.
    /// <see cref="nint"/>/<see cref="nuint"/>, which <see cref="IConvertible"/> does not support, are converted through
    /// <see cref="long"/>/<see cref="ulong"/>. When <paramref name="floorFractions"/> is set and an integer target cannot
    /// take the value directly, the exact floor of the value is used if it is in range.
    /// </remarks>
    private static bool TryChangeType(object input, Type targetType, ParseKind kind, bool floorFractions, IFormatProvider? provider, out object? result)
    {
        if (kind is not ParseKind.Other)
        {
            input = input switch
            {
                nint n => (long)n,
                nuint n => (ulong)n,
                _ => input
            };
        }

        return kind switch
        {
            ParseKind.SByte => TryConvertInteger<sbyte>(input, floorFractions, provider, out result),
            ParseKind.Byte => TryConvertInteger<byte>(input, floorFractions, provider, out result),
            ParseKind.Int16 => TryConvertInteger<short>(input, floorFractions, provider, out result),
            ParseKind.UInt16 => TryConvertInteger<ushort>(input, floorFractions, provider, out result),
            ParseKind.Int32 => TryConvertInteger<int>(input, floorFractions, provider, out result),
            ParseKind.UInt32 => TryConvertInteger<uint>(input, floorFractions, provider, out result),
            ParseKind.Int64 => TryConvertInteger<long>(input, floorFractions, provider, out result),
            ParseKind.UInt64 => TryConvertInteger<ulong>(input, floorFractions, provider, out result),
            ParseKind.NInt => TryConvertInteger<nint>(input, floorFractions, provider, out result),
            ParseKind.NUInt => TryConvertInteger<nuint>(input, floorFractions, provider, out result),
            ParseKind.Boolean when input is string text => TryParseValue<bool>(text, provider, out result),
            ParseKind.Char when input is string text => TryParseValue<char>(text, provider, out result),
            ParseKind.Single when input is string text => TryParseValue<float>(text, provider, out result),
            ParseKind.Double when input is string text => TryParseValue<double>(text, provider, out result),
            ParseKind.Decimal when input is string text => TryParseValue<decimal>(text, provider, out result),
            ParseKind.Decimal when input is double or float && !IsDecimalRange(input is double d ? d : (float)input) => Fail(out result),
            ParseKind.Enum => Fail(out result),
            _ => TryChangeTypeFallback(input, targetType, provider, out result)
        };
    }

    /// <summary>
    /// Parses <paramref name="text"/> with <see cref="IParsable{TSelf}.TryParse(string?, IFormatProvider?, out TSelf)"/> and the current
    /// culture (or <paramref name="provider"/>), which uses the same <see cref="NumberStyles"/> as <see cref="Convert.ChangeType(object, Type)"/>
    /// did, without exceptions. A provider that throws counts as a failed parse.
    /// </summary>
    private static bool TryParseValue<TValue>(string text, IFormatProvider? provider, out object? result) where TValue : IParsable<TValue>
        => provider is null ? TValue.TryParse(text, CurrentCulture, out var value) ? Succeed(value, out result) : Fail(out result) : TryParseValueGuarded<TValue>(text, provider, out result);

    private static bool TryParseValueGuarded<TValue>(string text, IFormatProvider provider, out object? result) where TValue : IParsable<TValue>
    {
        try
        {
            return TValue.TryParse(text, provider, out var value) ? Succeed(value, out result) : Fail(out result);
        }
        catch
        {
            return Fail(out result);
        }
    }

    /// <summary>
    /// Mirrors <see cref="Convert.ChangeType(object, Type)"/> for the remaining targets, rejecting up front the cases in which it
    /// always throws.
    /// </summary>
    private static bool TryChangeTypeFallback(object input, Type targetType, IFormatProvider? provider, out object? result)
    {
        if (input is not IConvertible)
        {
            return input.GetType() == targetType ? Succeed(input, out result) : Fail(out result);
        }

        // the BCL IConvertible types (string, primitives, DateTime, enums...) convert to no TypeCode.Object type except object itself
        return targetType != typeof(object) && Type.GetTypeCode(targetType) == TypeCode.Object && Type.GetTypeCode(input.GetType()) != TypeCode.Object
            ? Fail(out result)
            : TryChangeTypeCore(input, targetType, provider, out result);
    }

    private static bool TryConvertInteger<TInteger>(object input, bool floorFractions, IFormatProvider? provider, out object? result) where TInteger : struct, IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
    {
        switch (input)
        {
            case double or float:
            {
                var value = input is double d ? d : (float)input;

                return TryFromDouble<TInteger>(Math.Round(value), out result) || floorFractions && TryFromDouble<TInteger>(Math.Floor(value), out result);
            }
            case decimal value:
                return TryFromDecimal<TInteger>(decimal.Round(value), out result) || floorFractions && TryFromDecimal<TInteger>(decimal.Floor(value), out result);
            case string text:
                return TryParseInteger<TInteger>(text, floorFractions, provider, out result);
            default:
                if (TryGetInt128(input, out var number))
                {
                    return TryFromInt128<TInteger>(number, out result);
                }

                return input is IConvertible && TryChangeTypeCore(input, IntegerConversionType<TInteger>(), provider, out var converted) && TryGetInt128(converted, out number) && TryFromInt128<TInteger>(number, out result)
                    || floorFractions && input is IConvertible && TryChangeTypeCore(input, typeof(decimal), provider, out var boxed) && boxed is decimal m && TryFromDecimal<TInteger>(decimal.Floor(m), out result)
                    || Fail(out result);
        }
    }

    /// <summary>
    /// Parses <paramref name="text"/> as <typeparamref name="TInteger"/> with the current culture (or <paramref name="provider"/>); with
    /// <paramref name="floorFractions"/>, a fractional or out-of-range number is floored exactly if the floor fits. A provider that throws
    /// counts as a failed parse.
    /// </summary>
    private static bool TryParseInteger<TInteger>(string text, bool floorFractions, IFormatProvider? provider, out object? result) where TInteger : struct, IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
        => provider is null ? TryParseIntegerCore<TInteger>(text, floorFractions, CurrentCulture, out result) : TryParseIntegerGuarded<TInteger>(text, floorFractions, provider, out result);

    private static bool TryParseIntegerGuarded<TInteger>(string text, bool floorFractions, IFormatProvider provider, out object? result) where TInteger : struct, IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
    {
        try
        {
            return TryParseIntegerCore<TInteger>(text, floorFractions, provider, out result);
        }
        catch
        {
            return Fail(out result);
        }
    }

    private static bool TryParseIntegerCore<TInteger>(string text, bool floorFractions, IFormatProvider provider, out object? result) where TInteger : struct, IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
        => TInteger.TryParse(text, provider, out var parsed) ? Succeed(parsed, out result)
            : floorFractions && decimal.TryParse(text, NumberStyles.Number, provider, out var fraction) && TryFromDecimal<TInteger>(decimal.Floor(fraction), out result)
            || Fail(out result);

    private static Type IntegerConversionType<TInteger>() => typeof(TInteger) == typeof(nint) ? typeof(long) : typeof(TInteger) == typeof(nuint) ? typeof(ulong) : typeof(TInteger);

    private static bool TryGetInt128(object? input, out Int128 value)
    {
        (var isInteger, value) = input switch
        {
            int x => (true, (Int128)x),
            long x => (true, x),
            uint x => (true, x),
            ulong x => (true, x),
            short x => (true, x),
            ushort x => (true, x),
            byte x => (true, x),
            sbyte x => (true, x),
            char x => (true, x),
            _ => (false, Int128.Zero)
        };

        return isInteger;
    }

    private static bool TryFromInt128<TInteger>(Int128 value, out object? result) where TInteger : struct, IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
        => value >= Int128.CreateTruncating(TInteger.MinValue) && value <= Int128.CreateTruncating(TInteger.MaxValue) ? Succeed(TInteger.CreateTruncating(value), out result) : Fail(out result);

    /// <remarks><paramref name="value"/> must already be integral. The upper bound is exclusive (MaxValue + 1 is a power of two and exact as a double).</remarks>
    private static bool TryFromDouble<TInteger>(double value, out object? result) where TInteger : struct, IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
        => value >= double.CreateTruncating(TInteger.MinValue) && value < double.CreateTruncating(TInteger.MaxValue) + 1 ? Succeed(TInteger.CreateTruncating(value), out result) : Fail(out result);

    /// <remarks><paramref name="value"/> must already be integral.</remarks>
    private static bool TryFromDecimal<TInteger>(decimal value, out object? result) where TInteger : struct, IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
        => value >= decimal.CreateTruncating(TInteger.MinValue) && value <= decimal.CreateTruncating(TInteger.MaxValue) ? Succeed(TInteger.CreateTruncating(value), out result) : Fail(out result);

    /// <remarks>
    /// <see cref="Convert.ToDecimal(double)"/> and <see cref="Convert.ToDecimal(float)"/> throw for NaN, infinity and every value
    /// whose magnitude is at least 2^96 (binary exponent above 96); every smaller value converts (rounded to 15 or 7 significant
    /// digits), so only the certain failures are rejected here and the rest is left to the guarded conversion.
    /// </remarks>
    private static bool IsDecimalRange(double value) => Math.Abs(value) < 79228162514264337593543950336.0;

    /// <summary>
    /// The only place that still calls <see cref="Convert.ChangeType(object, Type, IFormatProvider)"/>; kept for conversions that have no
    /// exception-free equivalent (bool/char/DateTime sources, custom <see cref="IConvertible"/> implementations). Strings never
    /// get here for numeric, <see cref="bool"/>, <see cref="char"/>, enum or <see cref="TypeCode.Object"/> targets.
    /// </summary>
    /// <remarks>
    /// A <c>null</c> <paramref name="provider"/> passes the current culture, which is what <see cref="Convert.ChangeType(object, Type)"/>
    /// passes, so a custom <see cref="IConvertible"/> sees the same provider as in 8.3.3.
    /// </remarks>
    private static bool TryChangeTypeCore(object input, Type targetType, IFormatProvider? provider, out object? result)
    {
        try
        {
            result = ChangeType(input, targetType, provider ?? CurrentCulture);

            return true;
        }
        catch
        {
            return Fail(out result);
        }
    }

    private static bool Succeed<TValue>(TValue value, out object? result)
    {
        result = value;

        return true;
    }

    private static bool Fail(out object? result)
    {
        result = null;

        return false;
    }

    /// <summary>
    /// The text of <paramref name="input"/>, or <c>null</c> when its <see cref="object.ToString"/> throws. With a <paramref name="provider"/>,
    /// an <see cref="IFormattable"/> input is formatted with it (<c>1.5</c> is <c>"1.5"</c> with the invariant culture under de-DE);
    /// a <c>null</c> provider calls <see cref="object.ToString"/> as 8.3.3 did.
    /// </summary>
    private static string? SafeToString(this object? input, IFormatProvider? provider)
    {
        try
        {
            return provider is not null && input is IFormattable formattable ? formattable.ToString(null, provider) : input?.ToString();
        }
        catch
        {
            return null;
        }
    }

    private static ParseKind GetParseKind(Type type) => type.IsEnum ? ParseKind.Enum : type == typeof(nint) ? ParseKind.NInt : type == typeof(nuint) ? ParseKind.NUInt : Type.GetTypeCode(type) switch
    {
        TypeCode.Boolean => ParseKind.Boolean,
        TypeCode.Char => ParseKind.Char,
        TypeCode.SByte => ParseKind.SByte,
        TypeCode.Byte => ParseKind.Byte,
        TypeCode.Int16 => ParseKind.Int16,
        TypeCode.UInt16 => ParseKind.UInt16,
        TypeCode.Int32 => ParseKind.Int32,
        TypeCode.UInt32 => ParseKind.UInt32,
        TypeCode.Int64 => ParseKind.Int64,
        TypeCode.UInt64 => ParseKind.UInt64,
        TypeCode.Single => ParseKind.Single,
        TypeCode.Double => ParseKind.Double,
        TypeCode.Decimal => ParseKind.Decimal,
        _ => ParseKind.Other
    };

    private enum ParseKind : byte
    {
        Other,
        Enum,
        Boolean,
        Char,
        SByte,
        Byte,
        Int16,
        UInt16,
        Int32,
        UInt32,
        Int64,
        UInt64,
        NInt,
        NUInt,
        Single,
        Double,
        Decimal
    }

    /// <summary>
    /// Per-type parse metadata. The CLR initialises each closed generic instantiation exactly once and
    /// thread-safely, so concurrent first-time parses of many distinct types need no lock and no shared dictionary.
    /// </summary>
    private static class ParseCache<T>
    {
        internal static readonly Type? Underlying = GetUnderlyingType(typeof(T));

        /// <summary>The conversion target: the underlying type for <see cref="Nullable{T}"/>, otherwise <typeparamref name="T"/>.</summary>
        internal static readonly Type Target = Underlying ?? typeof(T);

        internal static readonly ParseKind Kind = GetParseKind(Target);

        /// <summary>
        /// Whether the one-argument overload floors fractional and out-of-range input: only when <typeparamref name="T"/>
        /// itself is a non-nullable integer type (8.3.3 behaviour).
        /// </summary>
        internal static readonly bool FloorFractions = Underlying is null && Kind is >= ParseKind.SByte and <= ParseKind.NUInt;
    }

    #endregion

    internal static T ParseImplement<T>(this object? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => ParseHelper<T>(input, defaultValue, format, null);

    internal static T ParseWithImplement<T>(this object? input, IFormatProvider? provider, object? defaultValue, IEnumerable<string?>? format) where T : unmanaged
        => ParseHelper<T>(input, defaultValue, format, provider);
}
