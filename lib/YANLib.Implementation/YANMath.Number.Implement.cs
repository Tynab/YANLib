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
// exception; a decimal overflow falls back to the 8.3.3 double computation (except in Average, whose elements are added again
// exactly in BigInteger since 8.4.0, see DecimalUnits); a result converted to an integer target is rounded half to even; decimal
// results carry no trailing zeros, as the double round trip produced.
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
    private static T? FromDecimal<T>(decimal value) => Normalize(value).ParseImplement<T?>();

    /// <summary>
    /// A <see cref="float"/> as the <c>double</c> that the object path converts to <see cref="decimal"/>: a whole <see cref="float"/>
    /// exactly, any other through its own shortest round-trip text (the text of 123456792f, 1.2345679E+08, is not exact).
    /// </summary>
    private static double ToShortestDouble(float value) => float.IsInteger(value) ? value : double.Parse(value.ToString("R", InvariantCulture), InvariantCulture);

    /// <summary>Whether <paramref name="input"/> is a boxed <c>double</c> or <see cref="float"/>, and its value.</summary>
    private static bool IsDoubleOrFloat(object? input, out double value)
    {
        switch (input)
        {
            case double number:
                value = number;

                return true;
            case float number:
                value = number;

                return true;
            default:
                value = default;

                return false;
        }
    }

    /// <summary>
    /// Whether <paramref name="input"/> is a boxed <c>double</c> or <see cref="float"/>, and its value as the object path converts it to
    /// <see cref="decimal"/> (a <see cref="float"/> through <see cref="ToShortestDouble"/>).
    /// </summary>
    private static bool TryGetShortestDouble(object? input, out double value)
    {
        switch (input)
        {
            case double number:
                value = number;

                return true;
            case float number:
                value = ToShortestDouble(number);

                return true;
            default:
                value = default;

                return false;
        }
    }

    /// <summary>
    /// <paramref name="value"/> exactly when it is a whole number in the <see cref="decimal"/> range. Truncate, Ceiling, Floor and Round to
    /// a whole number give the same result for a <c>double</c> or <see cref="float"/> as for its shortest round-trip text, so the object
    /// path computes them in <c>double</c> and converts a whole result this way, without the slower text round trip.
    /// </summary>
    private static bool TryToWholeDecimal(double value, out decimal result)
    {
        if (double.IsInteger(value) && Math.Abs(value) < (double)decimal.MaxValue)
        {
            // below 2^96, so Int128 and decimal hold it exactly
            result = (decimal)(Int128)value;

            return true;
        }

        result = default;

        return false;
    }

    /// <summary>
    /// A whole <paramref name="value"/> exactly (2^60 stays 1152921504606846976, not the 1152921504606847000 of its shortest text), any
    /// other the shortest decimal that round-trips to it (0.1 becomes 0.1m, not 0.1000000000000000055...); <c>false</c> for NaN,
    /// infinities, magnitudes from <see cref="decimal.MaxValue"/> on, and values whose shortest text has more than the 28 decimal
    /// places of <see cref="decimal"/> (1e-30 would become 0), unless <paramref name="rounded"/> accepts them rounded to 28 places (Sum and
    /// Average do; Round to more than 15 digits rounds such a value exactly on its text instead, see <see cref="TryRoundShortestText"/>).
    /// </summary>
    private static bool TryToDecimal(double value, out decimal result, bool rounded = false)
    {
        if (!double.IsFinite(value) || Math.Abs(value) >= (double)decimal.MaxValue)
        {
            result = default;

            return false;
        }

        if (TryToWholeDecimal(value, out result))
        {
            return true;
        }

        // the cast keeps 15 significant digits; the slower text round trip is only needed when that loses information
        result = (decimal)value;

        if (IsExactly(result, value))
        {
            return true;
        }

        Span<char> text = stackalloc char[32];

        _ = value.TryFormat(text, out var length, "R", InvariantCulture);
        result = decimal.Parse(text[..length], NumberStyles.Float, InvariantCulture);

        // a scale below 28 means the parse kept every digit
        return rounded || result.Scale < 28 || RoundTrips(result, value);
    }

    /// <summary>Whether <paramref name="number"/> reads back as <paramref name="value"/>, through text (the <see cref="decimal"/>-to-<c>double</c> cast is not correctly rounded).</summary>
    private static bool RoundTrips(decimal number, double value) => double.Parse(number.ToString(InvariantCulture), InvariantCulture) == value;

    /// <summary>Powers of ten that <c>double</c> represents exactly.</summary>
    private static readonly double[] ExactPowersOfTen = [1e0, 1e1, 1e2, 1e3, 1e4, 1e5, 1e6, 1e7, 1e8, 1e9, 1e10, 1e11, 1e12, 1e13, 1e14, 1e15, 1e16, 1e17, 1e18, 1e19, 1e20, 1e21, 1e22];

    /// <summary>
    /// Whether <paramref name="number"/> converts to exactly <paramref name="value"/>. <c>(double)number</c> cannot decide that: the
    /// <see cref="decimal"/>-to-<c>double</c> cast is not correctly rounded and can hit <paramref name="value"/> from a neighbouring
    /// decimal. A mantissa below 2^53 divided by an exact power of ten is a single, correctly rounded operation; other numbers answer
    /// <c>false</c> and take the text round trip.
    /// </summary>
    private static bool IsExactly(decimal number, double value)
    {
        Span<int> bits = stackalloc int[4];

        _ = decimal.GetBits(number, bits);

        if (bits[2] != 0)
        {
            return false;
        }

        var mantissa = (ulong)(uint)bits[1] << 32 | (uint)bits[0];
        var scale = (bits[3] >> 16) & 0xFF;

        while (scale > 0 && mantissa % 10 == 0)
        {
            mantissa /= 10;
            scale--;
        }

        if (mantissa >= 1UL << 53 || scale >= ExactPowersOfTen.Length)
        {
            return false;
        }

        var exact = mantissa / ExactPowersOfTen[scale];

        return (bits[3] < 0 ? -exact : exact) == value;
    }

    /// <summary>
    /// Converts an element of the object path to <see cref="decimal"/>: integers, decimals and whole <c>double</c> and
    /// <see cref="float"/> values exactly, other <c>double</c> and <see cref="float"/> values through their shortest round-trip text,
    /// strings with the same styles and culture as the 8.3.3 <c>double</c> parse, everything else through that <c>double</c> parse
    /// (enum values, <c>true</c> = 1, unparsable = 0); <c>null</c> is 0. <c>false</c> when the value has no <see cref="decimal"/>
    /// equivalent (NaN, infinity, out of range), or needs more than 28 decimal places (1e-30) and <paramref name="rounded"/> is
    /// <c>false</c>: the caller then takes the 8.3.3 <c>double</c> path, which keeps the sign of such a value for Floor and Ceiling (Round
    /// to more than 15 digits rounds such a <c>double</c> or <see cref="float"/> exactly on its text, see <see cref="TryRoundShortestText"/>).
    /// </summary>
    private static bool TryToDecimal(object? input, out decimal result, bool rounded = false)
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
                return TryToDecimal(value, out result, rounded);
            case float value:
                return TryToDecimal(ToShortestDouble(value), out result, rounded);
            case string text:
                // double.TryParse(text, CurrentCulture) uses Float | AllowThousands; accepting the same strings keeps "5-" and "(5)" at 0.
                // A scale of 28 can mean the parse rounded ("1e-30" to 0): kept only when that is the double the text stands for.
                return decimal.TryParse(text, NumberStyles.Float | NumberStyles.AllowThousands, CurrentCulture, out result)
                    ? rounded || result.Scale < 28 || RoundTrips(result, text.ParseImplement<double>())
                    : TryToDecimal(text.ParseImplement<double>(), out result, rounded);
            default:
                return TryToDecimal(input.ParseImplement<double>(), out result, rounded);
        }
    }

    /// <summary>
    /// The elements of a <typeparamref name="T"/>[] or a <see cref="List{T}"/> as a span, which the aggregates loop over without an
    /// enumerator. Exact types only, as LINQ does: a subclass of <see cref="List{T}"/> can enumerate differently.
    /// </summary>
    private static bool TryGetSpan<T>(IEnumerable<T> input, out ReadOnlySpan<T> span)
    {
        switch (input)
        {
            case T[] array when array.GetType() == typeof(T[]):
                span = array;

                return true;
            case List<T> list when list.GetType() == typeof(List<T>):
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

    /// <summary>
    /// Exact sum of object-path elements converted with <see cref="TryToDecimal(object, out decimal, bool)"/>, a value with more than 28
    /// decimal places rounded to 28 (the precision of the <see cref="decimal"/> sum); <c>false</c> on a failed conversion or an overflow
    /// (<paramref name="overflowed"/>: an <see cref="OverflowException"/> of the sum or of the sequence itself).
    /// </summary>
    private static bool TrySumDecimal(IEnumerable<object?> input, out decimal sum, out long count, out bool overflowed)
    {
        sum = 0;
        count = 0;
        overflowed = false;

        try
        {
            foreach (var value in input)
            {
                if (!TryToDecimal(value, out var number, true))
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
            overflowed = true;

            return false;
        }
    }

    /// <summary>
    /// The exact sum behind an Average with a <see cref="decimal"/> result once its <see cref="decimal"/> running sum has overflowed: a
    /// <see cref="BigInteger"/> count of 10^-28 units (every <see cref="decimal"/> is a whole number of them). Before 8.4.0 such an Average took
    /// the 8.3.3 <c>double</c> path, so the average of <see cref="decimal.MaxValue"/> and <see cref="decimal.MaxValue"/> was 0. Only the overflow
    /// path uses this class, so its powers of ten are computed on the first overflow.
    /// </summary>
    private static class DecimalUnits
    {
        private const int MaxScale = 28;

        private static readonly BigInteger[] PowersOfTen = [.. Enumerable.Range(0, MaxScale + 1).Select(static x => BigInteger.Pow(10, x))];

        private static readonly BigInteger MaxMantissa = (BigInteger.One << 96) - 1;

        /// <summary><paramref name="value"/> as a whole number of 10^-28 units.</summary>
        internal static BigInteger From(decimal value)
        {
            Span<int> bits = stackalloc int[4];

            _ = decimal.GetBits(value, bits);

            var mantissa = (BigInteger)((UInt128)(uint)bits[2] << 64 | (UInt128)(uint)bits[1] << 32 | (uint)bits[0]);
            var units = mantissa * PowersOfTen[MaxScale - ((bits[3] >> 16) & 0xFF)];

            return bits[3] < 0 ? -units : units;
        }

        /// <summary>
        /// <paramref name="units"/> / <paramref name="count"/> 10^-28 units as <see cref="decimal"/>, rounded as <see cref="decimal"/> division
        /// rounds: half to even, at the largest scale (at most 28) whose mantissa fits in 96 bits. A mean of decimals is never larger than the
        /// largest of them, so scale 0 always fits. A zero mean is positive.
        /// </summary>
        internal static decimal Mean(BigInteger units, long count)
        {
            var magnitude = BigInteger.Abs(units);

            for (var scale = MaxScale; scale >= 0; scale--)
            {
                // mean * 10^scale = units / (count * 10^(28 - scale))
                var divisor = count * PowersOfTen[MaxScale - scale];
                var quotient = BigInteger.DivRem(magnitude, divisor, out var remainder);
                var half = (remainder << 1).CompareTo(divisor);

                if (half > 0 || half == 0 && !quotient.IsEven)
                {
                    quotient++;
                }

                if (quotient <= MaxMantissa)
                {
                    var mantissa = (UInt128)quotient;

                    return new decimal((int)(uint)mantissa, (int)(uint)(mantissa >> 32), (int)(uint)(mantissa >> 64), units.Sign < 0 && !quotient.IsZero, (byte)scale);
                }
            }

            throw new UnreachableException();
        }
    }

    /// <summary>
    /// The average of typed <see cref="decimal"/> elements: their <see cref="decimal"/> sum divided by the count, as before 8.4.0, or, when an
    /// addition overflows, the exact mean of all elements, added again (<see cref="DecimalUnits"/>); <paramref name="count"/> 0 when there are
    /// no elements. <c>false</c> only when the sequence itself throws <see cref="OverflowException"/>: the caller then takes the 8.3.3
    /// <c>double</c> path, as before.
    /// </summary>
    private static bool TryAverageDecimal(IEnumerable<decimal> input, out decimal average, out long count)
    {
        decimal sum = 0;

        if (TryGetSpan(input, out var span))
        {
            try
            {
                foreach (var value in span)
                {
                    sum += value;
                }
            }
            catch (OverflowException)
            {
                // only the addition throws here: add the span again, exactly
                var units = BigInteger.Zero;

                foreach (var value in span)
                {
                    units += DecimalUnits.From(value);
                }

                count = span.Length;
                average = DecimalUnits.Mean(units, count);

                return true;
            }

            count = span.Length;
            average = count > 0 ? sum / count : default;

            return true;
        }

        // the 8.3.3 loop, into a separate local: passing sum by reference made the span loop above about twice as slow
        if (!TrySumDecimal(input, out var total, out count))
        {
            // the running sum may have been rounded before it overflowed, so it cannot be continued: enumerate the sequence again and add
            // every element exactly, as the 8.3.3 double path enumerated it again (an OverflowException of the sequence itself ends there)
            return TryAverageExactly(input, out average, out count);
        }

        average = count > 0 ? total / count : default;

        return true;
    }

    /// <summary>
    /// The exact mean of <paramref name="input"/>, enumerated again after its <see cref="decimal"/> sum overflowed; <paramref name="count"/> 0
    /// when it has no elements left. <c>false</c> when the sequence itself throws <see cref="OverflowException"/>.
    /// </summary>
    private static bool TryAverageExactly(IEnumerable<decimal> input, out decimal average, out long count)
    {
        var units = BigInteger.Zero;

        average = default;
        count = 0;

        try
        {
            foreach (var value in input)
            {
                units += DecimalUnits.From(value);
                count++;
            }
        }
        catch (OverflowException)
        {
            count = 0;

            return false;
        }

        if (count > 0)
        {
            average = DecimalUnits.Mean(units, count);
        }

        return true;
    }

    /// <summary>
    /// The average of object-path elements converted with <see cref="TryToDecimal(object, out decimal, bool)"/>: their <see cref="decimal"/>
    /// sum divided by the count, as before 8.4.0, or, when an addition overflows, the exact mean of all elements, added again
    /// (<see cref="DecimalUnits"/>). <c>false</c> on a failed conversion (also in that second pass), when there are no elements, or when the
    /// sequence itself throws <see cref="OverflowException"/>: the 8.3.3 <c>double</c> path then decides, as before.
    /// </summary>
    private static bool TryAverageDecimal(IEnumerable<object?> input, out decimal average)
    {
        average = default;

        if (TrySumDecimal(input, out var sum, out var count, out var overflowed))
        {
            if (count == 0)
            {
                return false;
            }

            average = sum / count;

            return true;
        }

        // as in the typed path: the rounded running sum cannot be continued, so every element is added again, exactly
        return overflowed && TryAverageExactly(input, out average);
    }

    /// <summary>The second, exact pass of <see cref="TryAverageDecimal(IEnumerable{object}, out decimal)"/> after an overflow.</summary>
    private static bool TryAverageExactly(IEnumerable<object?> input, out decimal average)
    {
        var units = BigInteger.Zero;
        var count = 0L;

        average = default;

        try
        {
            foreach (var value in input)
            {
                if (!TryToDecimal(value, out var number, true))
                {
                    return false;
                }

                units += DecimalUnits.From(number);
                count++;
            }
        }
        catch (OverflowException)
        {
            return false;
        }

        if (count == 0)
        {
            return false;
        }

        average = DecimalUnits.Mean(units, count);

        return true;
    }

    /// <summary><paramref name="sum"/> / <paramref name="count"/> rounded half to even, as the <c>double</c> average was when converted to an integer.</summary>
    private static Int128 DivideToEven(Int128 sum, long count)
    {
        var (quotient, remainder) = Int128.DivRem(sum, count);
        var twice = Int128.Abs(remainder) * 2;

        return twice > count || twice == count && !Int128.IsEvenInteger(quotient) ? quotient + Int128.Sign(remainder) : quotient;
    }

    /// <summary>Sum of a typed, non-empty collection; see the class remarks.</summary>
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
    private static T? SumObject<T>(IEnumerable<object?> input)
        => NumberTarget<T>.IsDecimal && TrySumDecimal(input, out var sum, out _, out _) ? FromDecimal<T>(sum) : SumObjectDouble<T>(input);

    /// <summary>The 8.3.3 sum: every element (null = 0) as <c>double</c>.</summary>
    private static T? SumObjectDouble<T>(IEnumerable<object?> input) => input.Sum(static x => x.ParseImplement<double>()).ParseImplement<T?>();

    /// <summary>
    /// Average of the non-null elements of a typed collection that was not empty when checked; <c>default</c> when it has no elements
    /// left by now (a sequence that can be enumerated only once). See the class remarks.
    /// </summary>
    private static T? AverageNumber<T>(IEnumerable<T?> input)
    {
        var kind = KindOf<T>();

        if (IsInteger(kind))
        {
            var sum = SumInt128(input!, out var count);

            return count > 0 && TryFromInt128(DivideToEven(sum, count), out T value) ? value : default;
        }

        if (IsBinaryFloatingPoint(kind))
        {
            var sum = SumDouble(input!, true, out var count);

            return count > 0 ? FromDouble<T>(sum / count) : default;
        }

        if (kind == NumberKind.Decimal)
        {
            return !TryAverageDecimal((IEnumerable<decimal>)(object)input, out var average, out var count) ? AverageObjectDouble<T>(input.Cast<object?>())
                : count > 0 ? As<decimal, T>(Normalize(average))
                : default;
        }

        return AverageObject<T>(input.Cast<object?>());
    }

    /// <summary>Average of the non-null elements of a non-empty object-path collection; <c>default</c> when all are null.</summary>
    private static T? AverageObject<T>(IEnumerable<object?> input)
    {
        var values = input.Where(static x => x is not null);

        return NumberTarget<T>.IsDecimal && TryAverageDecimal(values, out var average) ? FromDecimal<T>(average) : AverageObjectDouble<T>(values);
    }

    /// <summary>The 8.3.3 average: the non-null elements as <c>double</c>; <c>default</c> when there are none.</summary>
    private static T? AverageObjectDouble<T>(IEnumerable<object?> input)
        => TryAverage(input.Where(static x => x is not null).Select(static x => x.ParseImplement<double>()), out var average) ? average.ParseImplement<T?>() : default;

    #endregion

    #region Rounding and powers

    /// <summary><c>null</c> digits as given, otherwise parsed like 8.3.3 (<c>digits.ParseImplement&lt;int&gt;()</c>).</summary>
    private static int? ParseDigits(object? digits) => digits is null ? null : digits.ParseImplement<int>();

    /// <summary>Whether <see cref="Math.Round(double, int, MidpointRounding)"/> would accept the arguments (it throws for negative digits and undefined modes).</summary>
    private static bool IsValidRound(int? digits, MidpointRounding mode) => digits is not < 0 && mode is >= ToEven and <= ToPositiveInfinity;

    /// <summary>
    /// <see cref="Math.Round(double, int, MidpointRounding)"/>, which only accepts 0-15 digits: for more digits a finite value in the
    /// <see cref="decimal"/> range is rounded exactly on its shortest round-trip text, as <see cref="decimal"/> (up to 28 digits) and
    /// converted back exactly, or by digit shifting (<see cref="TryRoundShortestText"/>) when that text has more decimal places than
    /// <see cref="decimal"/> holds; any other value to 15 digits. Negative digits and undefined modes still throw the 8.3.3 exceptions.
    /// <paramref name="fromDecimal"/>: <paramref name="value"/> is a <see cref="decimal"/> input converted with the 8.3.3 cast, which is
    /// not correctly rounded (1e-28m becomes 1.0000000000000001E-28, a text with 44 decimal places that the decimal does not have); such a
    /// value is rounded to 28 places first, as before, instead of digit shifting.
    /// </summary>
    private static double RoundDouble(double value, int? digits, MidpointRounding mode, bool fromDecimal = false)
    {
        if (digits is not int places)
        {
            return Math.Round(value, mode);
        }

        if (places <= 15 || !IsValidRound(places, mode))
        {
            return Math.Round(value, Math.Min(places, 15), mode);
        }

        if (!TryToDecimal(value, out var number, fromDecimal))
        {
            // a value whose shortest text has more than the 28 decimal places of decimal (1.9999999999999998E-13 has 29; every such value
            // is below 1e-11) is rounded on that text by digit shifting, NaN, the infinities and magnitudes from decimal.MaxValue on to 15 digits
            return !fromDecimal && Math.Abs(value) < 1e-11 ? RoundShortestTextToDouble(value, places, mode) : Math.Round(value, 15, mode);
        }

        var rounded = decimal.Round(number, Math.Min(places, 28), mode);

        // the decimal-to-double cast is not correctly rounded (it can be one unit in the last place off), the text round trip is;
        // a zero keeps the sign of the input, as Math.Round does
        return rounded == 0 ? Math.CopySign(0d, value) : double.Parse(rounded.ToString(InvariantCulture), InvariantCulture);
    }

    /// <summary>
    /// Digit-shift rounding of a finite <paramref name="value"/> whose shortest round-trip text has more than the 28 decimal places of
    /// <see cref="decimal"/>, which converting it to <see cref="decimal"/> would round first (1.9999999999999998E-13 rounded to 20 places
    /// toward zero would become 2E-13 instead of 1.9999999E-13). The digits of that text, at most 17, become a <see cref="decimal"/> shifted
    /// so that rounding it to a whole number rounds exactly at <paramref name="places"/> decimal places of the text; ties are decided on the
    /// text, as <see cref="decimal"/> decides them for shorter texts. <paramref name="quotient"/> is that whole number q, with the sign of
    /// <paramref name="value"/>: the result is q × 10^-<paramref name="places"/>. <c>false</c> when the text has no more than
    /// <paramref name="places"/> decimal places, so <paramref name="value"/> is already rounded.
    /// </summary>
    private static bool TryRoundShortestText(double value, int places, MidpointRounding mode, out decimal quotient)
    {
        Span<char> buffer = stackalloc char[32];

        _ = value.TryFormat(buffer, out var length, "R", InvariantCulture);

        // "-1.9999999999999998E-13": the 17 digits stand for 16 + 13 = 29 decimal places
        var text = buffer[..length];
        var e = text.IndexOf('E');
        var exponent = e < 0 ? 0 : int.Parse(text[(e + 1)..], NumberStyles.AllowLeadingSign, InvariantCulture);
        var mantissa = e < 0 ? text : text[..e];
        var point = mantissa.IndexOf('.');
        var digits = 0UL;

        foreach (var character in mantissa)
        {
            if (char.IsAsciiDigit(character))
            {
                digits = (digits * 10) + (ulong)(character - '0');
            }
        }

        var shift = (point < 0 ? 0 : mantissa.Length - point - 1) - exponent - places;

        if (shift <= 0)
        {
            quotient = default;

            return false;
        }

        // shifted by more than 28 places the digits (below 10^17) are below 10^-11, which every mode rounds like the smallest decimal, 10^-28
        var shifted = shift > 28
            ? new decimal(1, 0, 0, value < 0, 28)
            : new decimal((int)(uint)digits, (int)(uint)(digits >> 32), 0, value < 0, (byte)shift);

        quotient = decimal.Round(shifted, 0, mode);

        return true;
    }

    /// <summary>
    /// <see cref="TryRoundShortestText"/> as the nearest <c>double</c> (the text round trip is correctly rounded); a zero keeps the sign of
    /// <paramref name="value"/>, as <see cref="Math.Round(double, int, MidpointRounding)"/> does. Any number of places is honoured.
    /// </summary>
    private static double RoundShortestTextToDouble(double value, int places, MidpointRounding mode)
        => !TryRoundShortestText(value, places, mode, out var quotient) ? value
        : quotient == 0 ? Math.CopySign(0d, value)
        : double.Parse(string.Create(InvariantCulture, $"{quotient}E-{places}"), InvariantCulture);

    /// <summary>
    /// <see cref="TryRoundShortestText"/> as a <see cref="decimal"/>, exactly. More than 28 places round at the 28th, the most a
    /// <see cref="decimal"/> holds, with <paramref name="mode"/> (the text has more than 28 decimal places, so there is always a digit to round).
    /// </summary>
    private static decimal RoundShortestTextToDecimal(double value, int places, MidpointRounding mode)
    {
        var scale = Math.Min(places, 28);

        _ = TryRoundShortestText(value, scale, mode, out var quotient);

        // q × 10^-scale: q has at most 18 digits, so the product is exact
        return quotient * new decimal(1, 0, 0, false, (byte)scale);
    }

    /// <summary><see cref="decimal.Round(decimal, int, MidpointRounding)"/> for valid arguments (see <see cref="IsValidRound"/>); more than 28 digits means 28.</summary>
    private static decimal RoundDecimal(decimal value, int? digits, MidpointRounding mode) => digits is int places ? decimal.Round(value, Math.Min(places, 28), mode) : decimal.Round(value, mode);

    /// <summary>The 8.3.3 power: the input as <c>double</c>, <see cref="Math.Pow(double, double)"/>, the result converted to <typeparamref name="T"/>.</summary>
    private static T? PowDouble<T>(object? input, double exponent) => Math.Pow(input.ParseImplement<double>(), exponent).ParseImplement<T?>();

    /// <summary>Whether <paramref name="exponent"/> is a whole number that <see cref="int"/> can hold.</summary>
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
    private static T? Unary<T>(T? input, Func<double, double> function)
        => input is null ? input : IsBinaryFloatingPoint(KindOf<T>()) ? FromDouble<T>(function(ToDouble(input))) : UnaryObject<T>(input, function);

    /// <summary>The 8.3.3 computation: the input as <c>double</c>, the result converted to <typeparamref name="T"/>.</summary>
    private static T? UnaryObject<T>(object? input, Func<double, double> function) => input is null ? default : function(input.ParseImplement<double>()).ParseImplement<T?>();

    /// <summary>
    /// Truncate, Ceiling, Floor and Abs of a typed value: identity for integers (Abs: exact, out of range = <c>default</c>),
    /// <see cref="decimal"/> natively, <see cref="float"/>/<see cref="double"/> in <c>double</c>, other types through the object path.
    /// </summary>
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
    private static T? ExactObject<T>(object? input, Func<double, double> function, Func<decimal, decimal> decimalFunction)
        => input is null ? default
        : !NumberTarget<T>.IsDecimal ? UnaryObject<T>(input, function)
        : IsDoubleOrFloat(input, out var value) && TryToWholeDecimal(function(value), out var whole) ? whole.ParseImplement<T?>()
        : TryToDecimal(input, out var number) ? FromDecimal<T>(decimalFunction(number))
        : UnaryObject<T>(input, function);

    #endregion
}
