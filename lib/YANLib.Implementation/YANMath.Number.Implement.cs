using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Globalization.CultureInfo;
using static System.MidpointRounding;

namespace YANLib.Implementation;

// Number dispatch. 8.3.3 sent every value through double, which lost precision for decimal and for 64-bit integers above
// 2^53 (1.005m.Round(2) gave 1, 9007199254740993L.Abs() gave ...992). The typed methods now work natively when T is one of
// the 13 numeric types and is not nullable: integers in Int128 (exact, then range-checked), decimal in decimal, float and
// double in double as before, all without boxing. Every other T (nullable, enum, char, string, ...) takes the object path,
// which computes integer and decimal targets in decimal and every other target in double exactly as 8.3.3 did. Functions
// that are inherently double (Sqrt, Sin, Log, ...) stay in double.
//
// Unchanged semantics: a result that does not fit the target is default (0, or null for a nullable target), never an
// exception; a decimal overflow falls back to the 8.3.3 double computation; a result converted to an integer target is
// rounded half to even; decimal results carry no trailing zeros, as the double round trip produced.
internal static partial class YANMath
{
    #region Classification

    private enum NumberKind : byte
    {
        Other,
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
    /// The kind of <typeparamref name="T"/> itself (not of its underlying type): the typed methods work natively only for these.
    /// The comparisons are JIT-time constants for value types, so each instantiation keeps a single branch.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static NumberKind KindOf<T>()
        => typeof(T) == typeof(int) ? NumberKind.Int32
        : typeof(T) == typeof(long) ? NumberKind.Int64
        : typeof(T) == typeof(double) ? NumberKind.Double
        : typeof(T) == typeof(decimal) ? NumberKind.Decimal
        : typeof(T) == typeof(float) ? NumberKind.Single
        : typeof(T) == typeof(uint) ? NumberKind.UInt32
        : typeof(T) == typeof(ulong) ? NumberKind.UInt64
        : typeof(T) == typeof(short) ? NumberKind.Int16
        : typeof(T) == typeof(ushort) ? NumberKind.UInt16
        : typeof(T) == typeof(byte) ? NumberKind.Byte
        : typeof(T) == typeof(sbyte) ? NumberKind.SByte
        : typeof(T) == typeof(nint) ? NumberKind.NInt
        : typeof(T) == typeof(nuint) ? NumberKind.NUInt
        : NumberKind.Other;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsInteger(NumberKind kind) => kind is >= NumberKind.SByte and <= NumberKind.NUInt;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsBinaryFloatingPoint(NumberKind kind) => kind is NumberKind.Single or NumberKind.Double;

    /// <summary>Per-type data of the object path.</summary>
    private static class NumberTarget<T>
    {
        /// <summary>
        /// Whether the object path computes results for <typeparamref name="T"/> in <see cref="decimal"/>: <typeparamref name="T"/>,
        /// or the underlying type of a nullable <typeparamref name="T"/>, is an integer type or <see cref="decimal"/> (not an enum).
        /// </summary>
        internal static readonly bool IsDecimal = IsDecimalTarget(Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));

        [DebuggerHidden]
        [DebuggerStepThrough]
        private static bool IsDecimalTarget(Type type)
            => type == typeof(decimal) || type == typeof(int) || type == typeof(long) || type == typeof(uint) || type == typeof(ulong) || type == typeof(short)
            || type == typeof(ushort) || type == typeof(byte) || type == typeof(sbyte) || type == typeof(nint) || type == typeof(nuint);
    }

    #endregion

    #region Conversions

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static TTo As<TFrom, TTo>(TFrom value) => Unsafe.As<TFrom, TTo>(ref value);

    /// <summary>Widens an integer <typeparamref name="T"/> to <see cref="Int128"/>; only for <see cref="IsInteger"/> kinds.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Int128 ToInt128<T>(T value) => KindOf<T>() switch
    {
        NumberKind.SByte => (Int128)As<T, sbyte>(value),
        NumberKind.Byte => (Int128)As<T, byte>(value),
        NumberKind.Int16 => (Int128)As<T, short>(value),
        NumberKind.UInt16 => (Int128)As<T, ushort>(value),
        NumberKind.Int32 => (Int128)As<T, int>(value),
        NumberKind.UInt32 => (Int128)As<T, uint>(value),
        NumberKind.Int64 => (Int128)As<T, long>(value),
        NumberKind.UInt64 => (Int128)As<T, ulong>(value),
        NumberKind.NInt => (Int128)As<T, nint>(value),
        NumberKind.NUInt => (Int128)As<T, nuint>(value),
        _ => throw new UnreachableException()
    };

    /// <summary>Narrows <paramref name="value"/> to an integer <typeparamref name="T"/>; <c>false</c> when it is out of range.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryFromInt128<T>(Int128 value, out T result) => KindOf<T>() switch
    {
        NumberKind.SByte => TryNarrow<sbyte, T>(value, out result),
        NumberKind.Byte => TryNarrow<byte, T>(value, out result),
        NumberKind.Int16 => TryNarrow<short, T>(value, out result),
        NumberKind.UInt16 => TryNarrow<ushort, T>(value, out result),
        NumberKind.Int32 => TryNarrow<int, T>(value, out result),
        NumberKind.UInt32 => TryNarrow<uint, T>(value, out result),
        NumberKind.Int64 => TryNarrow<long, T>(value, out result),
        NumberKind.UInt64 => TryNarrow<ulong, T>(value, out result),
        NumberKind.NInt => TryNarrow<nint, T>(value, out result),
        NumberKind.NUInt => TryNarrow<nuint, T>(value, out result),
        _ => throw new UnreachableException()
    };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool TryNarrow<TInteger, T>(Int128 value, out T result) where TInteger : IBinaryInteger<TInteger>, IMinMaxValue<TInteger>
    {
        if (value >= Int128.CreateTruncating(TInteger.MinValue) && value <= Int128.CreateTruncating(TInteger.MaxValue))
        {
            result = As<TInteger, T>(TInteger.CreateTruncating(value));

            return true;
        }

        result = default!;

        return false;
    }

    /// <summary>A <see cref="float"/> or <see cref="double"/> <typeparamref name="T"/> as <c>double</c> (the 8.3.3 conversion).</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static double ToDouble<T>(T value) => KindOf<T>() == NumberKind.Single ? As<T, float>(value) : As<T, double>(value);

    /// <summary>A <c>double</c> result as a <see cref="float"/> or <see cref="double"/> <typeparamref name="T"/> (a cast, as <see cref="Convert.ToSingle(double)"/>).</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T FromDouble<T>(double value) => KindOf<T>() == NumberKind.Single ? As<float, T>((float)value) : As<double, T>(value);

    /// <summary>Removes trailing zeros (1.2100m becomes 1.21m), which the <c>double</c> round trip of 8.3.3 never produced.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static decimal Normalize(decimal value) => value / 1.0000000000000000000000000000m;

    /// <summary>A <see cref="decimal"/> result converted to <typeparamref name="T"/> like a <c>double</c> result was (rounded half to even for integers, <c>default</c> when out of range).</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? FromDecimal<T>(decimal value) => Normalize(value).ParseImplement<T?>();

    /// <summary>
    /// The shortest decimal that round-trips to <paramref name="value"/> (0.1 becomes 0.1m, not 0.1000000000000000055...); <c>false</c>
    /// for NaN, infinities and magnitudes from <see cref="decimal.MaxValue"/> on.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryToDecimal(double value, out decimal result)
    {
        if (!double.IsFinite(value) || Math.Abs(value) >= (double)decimal.MaxValue)
        {
            result = default;

            return false;
        }

        // the cast keeps 15 significant digits; the slower text round trip is only needed when that loses information
        result = (decimal)value;

        if ((double)result != value)
        {
            result = decimal.Parse(value.ToString("R", InvariantCulture), NumberStyles.Float, InvariantCulture);
        }

        return true;
    }

    /// <summary>
    /// Converts an element of the object path to <see cref="decimal"/>: integers and decimals exactly, <c>double</c> and
    /// <see cref="float"/> through their shortest round-trip text, strings with the same styles and culture as the 8.3.3
    /// <c>double</c> parse, everything else through that <c>double</c> parse (enum values, <c>true</c> = 1, unparsable = 0);
    /// <c>null</c> is 0. <c>false</c> when the value has no <see cref="decimal"/> equivalent (NaN, infinity, out of range).
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryToDecimal(object? input, out decimal result)
    {
        switch (input)
        {
            case null:
                result = 0;

                return true;
            case decimal value:
                result = value;

                return true;
            case int value:
                result = value;

                return true;
            case long value:
                result = value;

                return true;
            case uint value:
                result = value;

                return true;
            case ulong value:
                result = value;

                return true;
            case short value:
                result = value;

                return true;
            case ushort value:
                result = value;

                return true;
            case byte value:
                result = value;

                return true;
            case sbyte value:
                result = value;

                return true;
            case nint value:
                result = value;

                return true;
            case nuint value:
                result = value;

                return true;
            case double value:
                return TryToDecimal(value, out result);
            case float value:
                return TryToDecimal(double.Parse(value.ToString("R", InvariantCulture), InvariantCulture), out result);
            case string text:
                // double.TryParse(text, CurrentCulture) uses Float | AllowThousands; accepting the same strings keeps "5-" and "(5)" at 0
                return decimal.TryParse(text, NumberStyles.Float | NumberStyles.AllowThousands, CurrentCulture, out result) || TryToDecimal(text.ParseImplement<double>(), out result);
            default:
                return TryToDecimal(input.ParseImplement<double>(), out result);
        }
    }

    /// <summary>The elements of an array or a <see cref="List{T}"/> as a span, which the aggregates loop over without an enumerator.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryGetSpan<T>(IEnumerable<T> input, out ReadOnlySpan<T> span)
    {
        switch (input)
        {
            case T[] array:
                span = array;

                return true;
            case List<T> list:
                span = CollectionsMarshal.AsSpan(list);

                return true;
            default:
                span = default;

                return false;
        }
    }

    #endregion

    #region Aggregates

    /// <summary>
    /// The smallest (<paramref name="max"/> = <c>false</c>) or largest non-null value, or <c>default</c> when there is none.
    /// </summary>
    /// <remarks>
    /// Compares like <see cref="Enumerable.Min{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>, which 8.3.3 called:
    /// <see cref="Comparer{T}.Default"/>, the first of equal values wins, and NaN is the smallest double. LINQ throws
    /// "Sequence contains no elements" for a value type when every element is null; this returns <c>default</c>, as for empty input.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? MinMax<T>(IEnumerable<T?> values, bool max)
    {
        var comparer = Comparer<T?>.Default;
        var found = false;
        T? result = default;

        foreach (var value in values)
        {
            if (value is null)
            {
                continue;
            }

            if (!found)
            {
                result = value;
                found = true;

                continue;
            }

            var order = comparer.Compare(value, result);

            if (max ? order > 0 : order < 0)
            {
                result = value;
            }
        }

        return result;
    }

    /// <summary>
    /// The mean of <paramref name="values"/> computed like <see cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, double})"/>
    /// (the sum starts from the first value), or <c>false</c> when there are no values (LINQ throws).
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryAverage(IEnumerable<double> values, out double average)
    {
        using var enumerator = values.GetEnumerator();

        if (!enumerator.MoveNext())
        {
            average = default;

            return false;
        }

        var sum = enumerator.Current;
        var count = 1L;

        while (enumerator.MoveNext())
        {
            sum += enumerator.Current;
            count++;
        }

        average = sum / count;

        return true;
    }

    /// <summary>Exact sum of integer elements; 64 bits per element and fewer than 2^63 elements cannot overflow <see cref="Int128"/>.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Int128 SumInt128<T>(IEnumerable<T> input, out long count)
    {
        Int128 sum = 0;

        if (TryGetSpan(input, out var span))
        {
            foreach (var value in span)
            {
                sum += ToInt128(value);
            }

            count = span.Length;

            return sum;
        }

        count = 0;

        foreach (var value in input)
        {
            sum += ToInt128(value);
            count++;
        }

        return sum;
    }

    /// <summary>
    /// Sum of <see cref="float"/>/<see cref="double"/> elements in <c>double</c>, in order, like 8.3.3: from 0 for Sum
    /// (<see cref="Enumerable.Sum{TSource}(IEnumerable{TSource}, Func{TSource, double})"/>), from the first element for Average.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static double SumDouble<T>(IEnumerable<T> input, bool fromFirst, out long count)
    {
        if (TryGetSpan(input, out var span))
        {
            count = span.Length;

            if (span.IsEmpty)
            {
                return 0;
            }

            var sum = fromFirst ? ToDouble(span[0]) : 0d + ToDouble(span[0]);

            for (var i = 1; i < span.Length; i++)
            {
                sum += ToDouble(span[i]);
            }

            return sum;
        }

        using var enumerator = input.GetEnumerator();

        if (!enumerator.MoveNext())
        {
            count = 0;

            return 0;
        }

        var total = fromFirst ? ToDouble(enumerator.Current) : 0d + ToDouble(enumerator.Current);

        count = 1;

        while (enumerator.MoveNext())
        {
            total += ToDouble(enumerator.Current);
            count++;
        }

        return total;
    }

    /// <summary>Exact sum of <see cref="decimal"/> elements; <c>false</c> when an intermediate sum overflows.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TrySumDecimal(IEnumerable<decimal> input, out decimal sum, out long count)
    {
        sum = 0;
        count = 0;

        try
        {
            if (TryGetSpan(input, out var span))
            {
                foreach (var value in span)
                {
                    sum += value;
                }

                count = span.Length;

                return true;
            }

            foreach (var value in input)
            {
                sum += value;
                count++;
            }

            return true;
        }
        catch (OverflowException)
        {
            return false;
        }
    }

    /// <summary>Exact sum of object-path elements converted with <see cref="TryToDecimal(object, out decimal)"/>; <c>false</c> on a failed conversion or an overflow.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TrySumDecimal(IEnumerable<object?> input, out decimal sum, out long count)
    {
        sum = 0;
        count = 0;

        try
        {
            foreach (var value in input)
            {
                if (!TryToDecimal(value, out var number))
                {
                    return false;
                }

                sum += number;
                count++;
            }

            return true;
        }
        catch (OverflowException)
        {
            return false;
        }
    }

    /// <summary><paramref name="sum"/> / <paramref name="count"/> rounded half to even, as the <c>double</c> average was when converted to an integer.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Int128 DivideToEven(Int128 sum, long count)
    {
        var (quotient, remainder) = Int128.DivRem(sum, count);
        var twice = Int128.Abs(remainder) * 2;

        return twice > count || twice == count && !Int128.IsEvenInteger(quotient) ? quotient + Int128.Sign(remainder) : quotient;
    }

    /// <summary>Sum of a typed, non-empty collection; see the class remarks.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? SumNumber<T>(IEnumerable<T?> input)
    {
        var kind = KindOf<T>();

        if (IsInteger(kind))
        {
            return TryFromInt128(SumInt128(input!, out _), out T value) ? value : default;
        }

        if (IsBinaryFloatingPoint(kind))
        {
            return FromDouble<T>(SumDouble(input!, false, out _));
        }

        if (kind == NumberKind.Decimal)
        {
            return TrySumDecimal((IEnumerable<decimal>)(object)input, out var sum, out _) ? As<decimal, T>(Normalize(sum)) : SumObjectDouble<T>(input.Cast<object?>());
        }

        return SumObject<T>(input.Cast<object?>());
    }

    /// <summary>Sum of a non-empty object-path collection; see the class remarks.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? SumObject<T>(IEnumerable<object?> input)
        => NumberTarget<T>.IsDecimal && TrySumDecimal(input, out var sum, out _) ? FromDecimal<T>(sum) : SumObjectDouble<T>(input);

    /// <summary>The 8.3.3 sum: every element (null = 0) as <c>double</c>.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? SumObjectDouble<T>(IEnumerable<object?> input) => input.Sum(static x => x.ParseImplement<double>()).ParseImplement<T?>();

    /// <summary>Average of the non-null elements of a typed, non-empty collection; see the class remarks.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? AverageNumber<T>(IEnumerable<T?> input)
    {
        var kind = KindOf<T>();

        if (IsInteger(kind))
        {
            var sum = SumInt128(input!, out var count);

            return TryFromInt128(DivideToEven(sum, count), out T value) ? value : default;
        }

        if (IsBinaryFloatingPoint(kind))
        {
            var sum = SumDouble(input!, true, out var count);

            return FromDouble<T>(sum / count);
        }

        if (kind == NumberKind.Decimal)
        {
            return TrySumDecimal((IEnumerable<decimal>)(object)input, out var sum, out var count) ? As<decimal, T>(Normalize(sum / count)) : AverageObjectDouble<T>(input.Cast<object?>());
        }

        return AverageObject<T>(input.Cast<object?>());
    }

    /// <summary>Average of the non-null elements of a non-empty object-path collection; <c>default</c> when all are null.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? AverageObject<T>(IEnumerable<object?> input)
    {
        var values = input.Where(static x => x is not null);

        return NumberTarget<T>.IsDecimal && TrySumDecimal(values, out var sum, out var count) && count > 0 ? FromDecimal<T>(sum / count) : AverageObjectDouble<T>(values);
    }

    /// <summary>The 8.3.3 average: the non-null elements as <c>double</c>; <c>default</c> when there are none.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? AverageObjectDouble<T>(IEnumerable<object?> input)
        => TryAverage(input.Where(static x => x is not null).Select(static x => x.ParseImplement<double>()), out var average) ? average.ParseImplement<T?>() : default;

    #endregion

    #region Rounding and powers

    /// <summary><c>null</c> digits as given, otherwise parsed like 8.3.3 (<c>digits.ParseImplement&lt;int&gt;()</c>).</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static int? ParseDigits(object? digits) => digits is null ? null : digits.ParseImplement<int>();

    /// <summary>Whether <see cref="Math.Round(double, int, MidpointRounding)"/> would accept the arguments (it throws for digits outside 0-15 and undefined modes).</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsValidRound(int? digits, MidpointRounding mode) => digits is not (< 0 or > 15) && mode is >= ToEven and <= ToPositiveInfinity;

    /// <summary><see cref="Math.Round(double, int, MidpointRounding)"/>, or <see cref="Math.Round(double, MidpointRounding)"/> without digits.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static double RoundDouble(double value, int? digits, MidpointRounding mode) => digits is int places ? Math.Round(value, places, mode) : Math.Round(value, mode);

    /// <summary><see cref="decimal.Round(decimal, int, MidpointRounding)"/> for valid arguments (see <see cref="IsValidRound"/>); more than 28 digits means 28.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static decimal RoundDecimal(decimal value, int? digits, MidpointRounding mode) => digits is int places ? decimal.Round(value, Math.Min(places, 28), mode) : decimal.Round(value, mode);

    /// <summary>The 8.3.3 power: the input as <c>double</c>, <see cref="Math.Pow(double, double)"/>, the result converted to <typeparamref name="T"/>.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? PowDouble<T>(object? input, double exponent) => Math.Pow(input.ParseImplement<double>(), exponent).ParseImplement<T?>();

    /// <summary>Whether <paramref name="exponent"/> is a whole number that <see cref="int"/> can hold.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsWholeExponent(double exponent, out int whole)
    {
        if (exponent == Math.Floor(exponent) && Math.Abs(exponent) <= int.MaxValue)
        {
            whole = (int)exponent;

            return true;
        }

        whole = default;

        return false;
    }

    /// <summary>
    /// Exact <paramref name="value"/>^<paramref name="exponent"/> for a whole exponent, by squaring. Magnitudes above 2^65 are clamped
    /// there (out of range for every 64-bit target). A negative exponent gives 1/x^n rounded half to even, as the <c>double</c>
    /// result was: 0 unless |x| is 1. <c>false</c> for a fractional exponent and for 0 to a negative power (<c>double</c> gives infinity).
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryPowInteger(Int128 value, double exponent, out Int128 result)
    {
        if (!IsWholeExponent(exponent, out var n) || n < 0 && value == 0)
        {
            result = default;

            return false;
        }

        var negative = value < 0 && (n & 1) != 0;

        if (n < 0)
        {
            result = Int128.Abs(value) == 1 ? negative ? -1 : 1 : 0;

            return true;
        }

        var cap = (UInt128)1 << 65;
        var power = (UInt128)Int128.Abs(value);
        UInt128 magnitude = 1;

        for (var e = (uint)n; e > 0; e >>= 1)
        {
            if ((e & 1) != 0)
            {
                magnitude = MultiplyCapped(magnitude, power, cap);
            }

            if (e > 1)
            {
                power = MultiplyCapped(power, power, cap);
            }
        }

        result = negative ? -(Int128)magnitude : (Int128)magnitude;

        return true;

        static UInt128 MultiplyCapped(UInt128 left, UInt128 right, UInt128 cap) => left == 0 || right == 0 ? 0 : left > cap / right ? cap : left * right;
    }

    /// <summary>
    /// <paramref name="value"/>^<paramref name="exponent"/> in <see cref="decimal"/> for a whole exponent, by squaring: 1/x^n for a
    /// negative exponent (or (1/x)^n when |x| &lt; 1, which keeps more digits). <c>false</c> for a fractional exponent, for 0 to a
    /// negative power and on overflow, where the caller falls back to <see cref="Math.Pow(double, double)"/>.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryPowDecimal(decimal value, double exponent, out decimal result)
    {
        if (!IsWholeExponent(exponent, out var n) || n < 0 && value == 0)
        {
            result = default;

            return false;
        }

        try
        {
            var invert = n < 0 && Math.Abs(value) >= 1;
            var power = n < 0 && !invert ? 1 / value : value;
            var magnitude = 1m;

            for (var e = (uint)Math.Abs((long)n); e > 0; e >>= 1)
            {
                if ((e & 1) != 0)
                {
                    magnitude *= power;
                }

                if (e > 1)
                {
                    power *= power;
                }
            }

            result = invert ? 1 / magnitude : magnitude;

            return true;
        }
        catch (Exception ex) when (ex is OverflowException or DivideByZeroException)
        {
            result = default;

            return false;
        }
    }

    #endregion

    #region Unary dispatch

    /// <summary>
    /// A function that is inherently <c>double</c> (Sqrt, Sin, Log, ...): computed directly for a <see cref="float"/>/<see cref="double"/>
    /// <typeparamref name="T"/>, and through the 8.3.3 object path for every other type.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? Unary<T>(T? input, Func<double, double> function)
        => input is null ? input : IsBinaryFloatingPoint(KindOf<T>()) ? FromDouble<T>(function(ToDouble(input))) : UnaryObject<T>(input, function);

    /// <summary>The 8.3.3 computation: the input as <c>double</c>, the result converted to <typeparamref name="T"/>.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? UnaryObject<T>(object? input, Func<double, double> function) => input is null ? default : function(input.ParseImplement<double>()).ParseImplement<T?>();

    /// <summary>
    /// Truncate, Ceiling, Floor and Abs of a typed value: identity for integers (Abs: exact, out of range = <c>default</c>),
    /// <see cref="decimal"/> natively, <see cref="float"/>/<see cref="double"/> in <c>double</c>, other types through the object path.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? Exact<T>(T? input, Func<double, double> function, Func<decimal, decimal> decimalFunction, bool abs)
    {
        if (input is null)
        {
            return input;
        }

        var kind = KindOf<T>();

        return IsInteger(kind) ? abs ? TryFromInt128(Int128.Abs(ToInt128(input)), out T value) ? value : default : input
            : IsBinaryFloatingPoint(kind) ? FromDouble<T>(function(ToDouble(input)))
            : kind == NumberKind.Decimal ? As<decimal, T>(Normalize(decimalFunction(As<T, decimal>(input))))
            : ExactObject<T>(input, function, decimalFunction);
    }

    /// <summary>Truncate, Ceiling, Floor and Abs on the object path: in <see cref="decimal"/> for integer and decimal targets, otherwise as 8.3.3.</summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? ExactObject<T>(object? input, Func<double, double> function, Func<decimal, decimal> decimalFunction)
        => input is null ? default : NumberTarget<T>.IsDecimal && TryToDecimal(input, out var number) ? FromDecimal<T>(decimalFunction(number)) : UnaryObject<T>(input, function);

    #endregion
}
