using System.Diagnostics;
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static DateTime ParseDateTime(this string? input, DateTime defaultValue = default, IEnumerable<string?>? format = null)
        => input.IsNullWhiteSpaceImplement() ? defaultValue : format.IsNullEmptyImplement() ? TryParse(input, out var dt) ? dt : defaultValue : TryParseExact(input, [.. format], InvariantCulture, None, out dt) ? dt : defaultValue;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Guid ParseGuid(this string? input, Guid defaultValue = default) => input.IsNullWhiteSpaceImplement() ? defaultValue : Guid.TryParse(input, out var guid) ? guid : defaultValue;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static TimeSpan ParseTimeSpan(this string? input, TimeSpan defaultValue = default) => input.IsNullWhiteSpaceImplement() ? defaultValue : TimeSpan.TryParse(input, out var ts) ? ts : defaultValue;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T ParseEnum<T>(this string? input, T defaultValue = default) where T : unmanaged
        => input.IsNullWhiteSpaceImplement() ? defaultValue : Enum.TryParse(typeof(T), input, true, out var e) ? e.ParseImplement<T>() : defaultValue;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static DateTime ParseDateTime(this string? input) => input.IsNullWhiteSpaceImplement() ? default : TryParse(input, out var dt) ? dt : default;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static DateTime? ParseDateTimeNullable(this string? input) => input.IsNullWhiteSpaceImplement() ? default : TryParse(input, out var dt) ? dt : default(DateTime?);

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Guid ParseGuid(this string? input) => input.IsNullWhiteSpaceImplement() ? default : Guid.TryParse(input, out var guid) ? guid : default;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Guid? ParseGuidNullable(this string? input) => input.IsNullWhiteSpaceImplement() ? default : Guid.TryParse(input, out var guid) ? guid : default(Guid?);

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static TimeSpan ParseTimeSpan(this string? input) => input.IsNullWhiteSpaceImplement() ? default : TimeSpan.TryParse(input, out var ts) ? ts : default;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static TimeSpan? ParseTimeSpanNullable(this string? input) => input.IsNullWhiteSpaceImplement() ? default : TimeSpan.TryParse(input, out var ts) ? ts : default(TimeSpan?);

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T ParseHelper<T>(object? input, object? defaultValue, IEnumerable<string?>? format) where T : unmanaged
    {
        if (typeof(T) == typeof(DateTime))
        {
            return (input?.ToString() ?? default).ParseDateTime((defaultValue?.ToString() ?? default).ParseDateTime(default, format), format).ParseImplement<T>();
        }

        if (typeof(T) == typeof(Guid))
        {
            return (input?.ToString() ?? default).ParseGuid((defaultValue?.ToString() ?? default).ParseGuid(default)).ParseImplement<T>();
        }

        if (typeof(T) == typeof(TimeSpan))
        {
            return (input?.ToString() ?? default).ParseTimeSpan((defaultValue?.ToString() ?? default).ParseTimeSpan(default)).ParseImplement<T>();
        }

        if (typeof(T).IsEnum)
        {
            return (input?.ToString() ?? default).ParseEnum((defaultValue?.ToString() ?? default).ParseEnum<T>(default));
        }

        if (input is not null && TryChangeType(input, typeof(T), ParseCache<T>.Kind, false, out var result) && result is T value)
        {
            return value;
        }

        return defaultValue is not null && TryChangeType(defaultValue, typeof(T), ParseCache<T>.Kind, false, out var fallback) && fallback is T fallbackValue ? fallbackValue : default;
    }

    /// <summary>
    /// Converts <paramref name="input"/> to <paramref name="targetType"/> without throwing and without recursion.
    /// </summary>
    /// <remarks>
    /// Keeps the <see cref="Convert.ChangeType(object, Type)"/> semantics of 8.3.3 (current culture, round-half-to-even for
    /// boxed fractional numbers) but range-checks numbers first instead of catching <see cref="OverflowException"/>.
    /// <see cref="nint"/>/<see cref="nuint"/>, which <see cref="IConvertible"/> does not support, are converted through
    /// <see cref="long"/>/<see cref="ulong"/>. When <paramref name="floorFractions"/> is set and an integer target cannot
    /// take the value directly, the exact floor of the value is used if it is in range.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryChangeType(object input, Type targetType, ParseKind kind, bool floorFractions, out object? result)
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
            ParseKind.SByte => TryConvertInteger<sbyte>(input, floorFractions, out result),
            ParseKind.Byte => TryConvertInteger<byte>(input, floorFractions, out result),
            ParseKind.Int16 => TryConvertInteger<short>(input, floorFractions, out result),
            ParseKind.UInt16 => TryConvertInteger<ushort>(input, floorFractions, out result),
            ParseKind.Int32 => TryConvertInteger<int>(input, floorFractions, out result),
            ParseKind.UInt32 => TryConvertInteger<uint>(input, floorFractions, out result),
            ParseKind.Int64 => TryConvertInteger<long>(input, floorFractions, out result),
            ParseKind.UInt64 => TryConvertInteger<ulong>(input, floorFractions, out result),
            ParseKind.NInt => TryConvertInteger<nint>(input, floorFractions, out result),
            ParseKind.NUInt => TryConvertInteger<nuint>(input, floorFractions, out result),
            ParseKind.Boolean when input is string text => TryParseValue<bool>(text, out result),
            ParseKind.Char when input is string text => TryParseValue<char>(text, out result),
            ParseKind.Single when input is string text => TryParseValue<float>(text, out result),
            ParseKind.Double when input is string text => TryParseValue<double>(text, out result),
            ParseKind.Decimal when input is string text => TryParseValue<decimal>(text, out result),
            ParseKind.Decimal when input is double or float && !IsDecimalRange(input is double d ? d : (float)input) => Fail(out result),
            ParseKind.Enum => Fail(out result),
            _ => TryChangeTypeFallback(input, targetType, out result)
        };
    }

    /// <summary>
    /// Parses <paramref name="text"/> with <see cref="IParsable{TSelf}.TryParse(string?, IFormatProvider?, out TSelf)"/> and the current
    /// culture, which uses the same <see cref="NumberStyles"/> as <see cref="Convert.ChangeType(object, Type)"/> did, without exceptions.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryParseValue<TValue>(string text, out object? result) where TValue : IParsable<TValue>
        => TValue.TryParse(text, CurrentCulture, out var value) ? Succeed(value, out result) : Fail(out result);

    /// <summary>
    /// Mirrors <see cref="Convert.ChangeType(object, Type)"/> for the remaining targets, rejecting up front the cases in which it
    /// always throws.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryChangeTypeFallback(object input, Type targetType, out object? result)
    {
        if (input is not IConvertible)
        {
            return input.GetType() == targetType ? Succeed(input, out result) : Fail(out result);
        }

        // the BCL IConvertible types (string, primitives, DateTime, enums...) convert to no TypeCode.Object type except object itself
        return targetType != typeof(object) && Type.GetTypeCode(targetType) == TypeCode.Object && Type.GetTypeCode(input.GetType()) != TypeCode.Object
            ? Fail(out result)
            : TryChangeTypeCore(input, targetType, out result);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryConvertInteger<TInteger>(object input, bool floorFractions, out object? result) where TInteger : struct, IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
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
                return TInteger.TryParse(text, CurrentCulture, out var parsed) ? Succeed(parsed, out result)
                    : floorFractions && decimal.TryParse(text, NumberStyles.Number, CurrentCulture, out var fraction) && TryFromDecimal<TInteger>(decimal.Floor(fraction), out result)
                    || Fail(out result);
            default:
                if (TryGetInt128(input, out var number))
                {
                    return TryFromInt128<TInteger>(number, out result);
                }

                return input is IConvertible && TryChangeTypeCore(input, IntegerConversionType<TInteger>(), out var converted) && TryGetInt128(converted, out number) && TryFromInt128<TInteger>(number, out result)
                    || floorFractions && input is IConvertible && TryChangeTypeCore(input, typeof(decimal), out var boxed) && boxed is decimal m && TryFromDecimal<TInteger>(decimal.Floor(m), out result)
                    || Fail(out result);
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Type IntegerConversionType<TInteger>() => typeof(TInteger) == typeof(nint) ? typeof(long) : typeof(TInteger) == typeof(nuint) ? typeof(ulong) : typeof(TInteger);

    [DebuggerHidden]
    [DebuggerStepThrough]
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryFromInt128<TInteger>(Int128 value, out object? result) where TInteger : struct, IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
        => value >= Int128.CreateTruncating(TInteger.MinValue) && value <= Int128.CreateTruncating(TInteger.MaxValue) ? Succeed(TInteger.CreateTruncating(value), out result) : Fail(out result);

    /// <remarks><paramref name="value"/> must already be integral. The upper bound is exclusive (MaxValue + 1 is a power of two and exact as a double).</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryFromDouble<TInteger>(double value, out object? result) where TInteger : struct, IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
        => value >= double.CreateTruncating(TInteger.MinValue) && value < double.CreateTruncating(TInteger.MaxValue) + 1 ? Succeed(TInteger.CreateTruncating(value), out result) : Fail(out result);

    /// <remarks><paramref name="value"/> must already be integral.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryFromDecimal<TInteger>(decimal value, out object? result) where TInteger : struct, IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
        => value >= decimal.CreateTruncating(TInteger.MinValue) && value <= decimal.CreateTruncating(TInteger.MaxValue) ? Succeed(TInteger.CreateTruncating(value), out result) : Fail(out result);

    /// <remarks>Doubles beyond about ±7.9e28 (and NaN/infinity) make <see cref="Convert.ToDecimal(double)"/> throw.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsDecimalRange(double value) => Math.Abs(value) < 7.9e28;

    /// <summary>
    /// The only place that still calls <see cref="Convert.ChangeType(object, Type)"/>; kept for conversions that have no
    /// exception-free equivalent (bool/char/DateTime sources, custom <see cref="IConvertible"/> implementations). Strings never
    /// get here for numeric, <see cref="bool"/>, <see cref="char"/>, enum or <see cref="TypeCode.Object"/> targets.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryChangeTypeCore(object input, Type targetType, out object? result)
    {
        try
        {
            result = ChangeType(input, targetType);

            return true;
        }
        catch
        {
            return Fail(out result);
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool Succeed<TValue>(TValue value, out object? result)
    {
        result = value;

        return true;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool Fail(out object? result)
    {
        result = null;

        return false;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static string? SafeToString(this object? input)
    {
        try
        {
            return input?.ToString();
        }
        catch
        {
            return null;
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T ParseImplement<T>(this object? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => ParseHelper<T>(input, defaultValue, format);
}
