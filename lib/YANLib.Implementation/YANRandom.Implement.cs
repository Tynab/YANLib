using System.Diagnostics;

namespace YANLib.Implementation;

internal static partial class YANRandom
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static int NextInt32Implement(this Random random) => random.Next(0, 1 << 4) << 28 | random.Next(0, 1 << 28);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static decimal NextDecimalImplement(this Random random)
    {
        // a mantissa uniform over [0, 10^28) from two independent 14-digit halves, read with 28 decimal places: uniform over [0, 1).
        // 8.3.3 read 96 random bits at scale 28 (0 to 7.92) and divided values above 1 by 10, so 87% of the draws fell in (0.1, 0.792].
        const long halfRange = 100_000_000_000_000;

        var mantissa = (UInt128)(ulong)random.NextInt64(halfRange) * (ulong)halfRange + (ulong)random.NextInt64(halfRange);

        return new decimal((int)(uint)mantissa, (int)(uint)(mantissa >> 32), (int)(uint)(mantissa >> 64), false, 28);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool NextBoolImplement(this Random random) => random.Next(0, 2) == 1;

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static byte NextByteImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? byte.MinValue : min.ParseImplement<byte>();
        var maxValue = max is null ? byte.MaxValue : max.ParseImplement<byte>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).ParseImplement<byte>();
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static sbyte NextSbyteImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? sbyte.MinValue : min.ParseImplement<sbyte>();
        var maxValue = max is null ? sbyte.MaxValue : max.ParseImplement<sbyte>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).ParseImplement<sbyte>();
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static short NextShortImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? short.MinValue : min.ParseImplement<short>();
        var maxValue = max is null ? short.MaxValue : max.ParseImplement<short>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).ParseImplement<short>();
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ushort NextUshortImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? ushort.MinValue : min.ParseImplement<ushort>();
        var maxValue = max is null ? ushort.MaxValue : max.ParseImplement<ushort>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).ParseImplement<ushort>();
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static int NextIntImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? int.MinValue : min.ParseImplement<int>();
        var maxValue = max is null ? int.MaxValue : max.ParseImplement<int>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static uint NextUintImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? uint.MinValue : min.ParseImplement<uint>();
        var maxValue = max is null ? uint.MaxValue : max.ParseImplement<uint>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue).ParseImplement<uint>();
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static long NextLongImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? long.MinValue : min.ParseImplement<long>();
        var maxValue = max is null ? long.MaxValue : max.ParseImplement<long>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ulong NextUlongImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? ulong.MinValue : min.ParseImplement<ulong>();
        var maxValue = max is null ? ulong.MaxValue : max.ParseImplement<ulong>();

        if (minValue > maxValue)
        {
            return default;
        }

        // the offset in [0, max - min) drawn as a signed 64-bit value shifted down by 2^63 (as NextNuint does): uniform, and max is
        // exclusive as documented (8.3.3 returned rand % (max - min + 1) + min, which included max and was biased)
        var range = maxValue - minValue;
        var offset = unchecked((ulong)(random.NextInt64(long.MinValue, long.MinValue + (long)range) - long.MinValue));

        return minValue + offset;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static nint NextNintImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? nint.MinValue : min.ParseImplement<nint>();
        var maxValue = max is null ? nint.MaxValue : max.ParseImplement<nint>();

        return minValue > maxValue ? default : (nint)random.NextInt64(minValue, maxValue);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static nuint NextNuintImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? nuint.MinValue : min.ParseImplement<nuint>();
        var maxValue = max is null ? nuint.MaxValue : max.ParseImplement<nuint>();

        if (minValue > maxValue)
        {
            return default;
        }

        // draw the offset in [0, max - min) as a signed 64-bit value shifted down by 2^63, so that Random.NextInt64 covers the whole
        // unsigned range (8.3.3 produced a negative value about half of the time, which then became 0)
        var range = (ulong)(maxValue - minValue);
        var offset = unchecked((ulong)(random.NextInt64(long.MinValue, long.MinValue + (long)range) - long.MinValue));

        return minValue + (nuint)offset;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static float NextSingleImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? float.MinValue / 100 : min.ParseImplement<float>();
        var maxValue = max is null ? float.MaxValue / 100 : max.ParseImplement<float>();

        if (!(minValue < maxValue))
        {
            return minValue == maxValue ? minValue : default;
        }

        var sample = random.NextSingle();
        var range = maxValue - minValue;

        // a range wider than float.MaxValue is interpolated without overflowing; rounding can reach max, which is exclusive
        var result = float.IsFinite(range) ? sample * range + minValue : sample * maxValue + (1 - sample) * minValue;

        return result < maxValue ? result : MathF.BitDecrement(maxValue);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static double NextDoubleImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? double.MinValue / 100 : min.ParseImplement<double>();
        var maxValue = max is null ? double.MaxValue / 100 : max.ParseImplement<double>();

        if (!(minValue < maxValue))
        {
            return minValue == maxValue ? minValue : default;
        }

        var sample = random.NextDouble();
        var range = maxValue - minValue;

        // a range wider than double.MaxValue is interpolated without overflowing; rounding can reach max, which is exclusive
        var result = double.IsFinite(range) ? sample * range + minValue : sample * maxValue + (1 - sample) * minValue;

        return result < maxValue ? result : Math.BitDecrement(maxValue);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static decimal NextDecimalImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? decimal.MinValue / 100 : min.ParseImplement<decimal>();
        var maxValue = max is null ? decimal.MaxValue / 100 : max.ParseImplement<decimal>();

        if (minValue >= maxValue)
        {
            return minValue == maxValue ? minValue : default;
        }

        // max - min overflows when the bounds have opposite signs and the range is wider than decimal.MaxValue
        var interpolate = minValue < 0 && maxValue > decimal.MaxValue + minValue;

        // rounding can reach max, which is exclusive: draw again (each draw does so with probability at most 1/2)
        for (var attempt = 0; attempt < 64; attempt++)
        {
            var sample = random.NextDecimalImplement();
            var result = interpolate ? sample * maxValue + (1 - sample) * minValue : sample * (maxValue - minValue) + minValue;

            if (result >= minValue && result < maxValue)
            {
                return result;
            }
        }

        return minValue;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static DateTime NextDateTimeImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? DateTime.MinValue : min.ParseImplement<DateTime>();
        var maxValue = max is null ? DateTime.MaxValue : max.ParseImplement<DateTime>();

        // whole ticks in [min, max), with the Kind of min (8.3.3 drew from [0, max - min] and so could return max)
        return minValue > maxValue ? default : minValue.AddTicks(random.NextInt64((maxValue - minValue).Ticks));
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char NextCharImplement(this Random random)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz";

        return chars[random.Next(0, chars.Length)];
    }

    /// <summary>
    /// A character in [<paramref name="min"/>, <paramref name="max"/>); without either bound, a lowercase letter like <see cref="NextCharImplement(Random)"/>.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char NextCharImplement(this Random random, object? min, object? max)
    {
        if (min is null && max is null)
        {
            return random.NextCharImplement();
        }

        var minValue = min is null ? char.MinValue : min.ParseImplement<char>();
        var maxValue = max is null ? char.MaxValue : max.ParseImplement<char>();

        return minValue > maxValue ? default : (char)random.Next(minValue, maxValue);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string NextStringImplement(this Random random, object? size = null) => string.Concat(GenerateRandomsImplement<char>(size: size ?? random.NextByteImplement()));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T GenerateRandomImplement<T>(object? min = null, object? max = null) where T : unmanaged
    {
        // thread-safe and shared; 8.3.3 created and seeded a new Random for every value
        var random = Random.Shared;

        return typeof(T) switch
        {
            Type byteType when byteType == typeof(byte) => random.NextByteImplement(min, max).ParseImplement<T>(),
            Type sbyteType when sbyteType == typeof(sbyte) => random.NextSbyteImplement(min, max).ParseImplement<T>(),
            Type shortType when shortType == typeof(short) => random.NextShortImplement(min, max).ParseImplement<T>(),
            Type ushortType when ushortType == typeof(ushort) => random.NextUshortImplement(min, max).ParseImplement<T>(),
            Type intType when intType == typeof(int) => random.NextIntImplement(min, max).ParseImplement<T>(),
            Type uintType when uintType == typeof(uint) => random.NextUintImplement(min, max).ParseImplement<T>(),
            Type longType when longType == typeof(long) => random.NextLongImplement(min, max).ParseImplement<T>(),
            Type ulongType when ulongType == typeof(ulong) => random.NextUlongImplement(min, max).ParseImplement<T>(),
            Type nintType when nintType == typeof(nint) => random.NextNintImplement(min, max).ParseImplement<T>(),
            Type nuintType when nuintType == typeof(nuint) => random.NextNuintImplement(min, max).ParseImplement<T>(),
            Type floatType when floatType == typeof(float) => random.NextSingleImplement(min, max).ParseImplement<T>(),
            Type doubleType when doubleType == typeof(double) => random.NextDoubleImplement(min, max).ParseImplement<T>(),
            Type decimalType when decimalType == typeof(decimal) => random.NextDecimalImplement(min, max).ParseImplement<T>(),
            Type dateTimeType when dateTimeType == typeof(DateTime) => random.NextDateTimeImplement(min, max).ParseImplement<T>(),
            Type charType when charType == typeof(char) => random.NextCharImplement(min, max).ParseImplement<T>(),
            _ => random.NextBoolImplement().ParseImplement<T>(),
        };
    }

    /// <summary>
    /// The typed-bounds overload: a value in [<paramref name="min"/>, <paramref name="max"/>) for the types that have ranges, otherwise one
    /// of the two values with equal probability (what the params overload returned for these calls).
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T GenerateRandomRangeImplement<T>(T min, T max) where T : unmanaged
        => HasRange<T>() ? GenerateRandomImplement<T>(min, max) : Random.Shared.Next(0, 2) == 0 ? min : max;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool HasRange<T>() where T : unmanaged
        => typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(double) || typeof(T) == typeof(decimal) || typeof(T) == typeof(float)
        || typeof(T) == typeof(DateTime) || typeof(T) == typeof(char) || typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte) || typeof(T) == typeof(short)
        || typeof(T) == typeof(ushort) || typeof(T) == typeof(uint) || typeof(T) == typeof(ulong) || typeof(T) == typeof(nint) || typeof(T) == typeof(nuint);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T GenerateRandomImplement<T>(this IEnumerable<T>? input) where T : unmanaged
    {
        if (input.IsNullEmptyImplement())
        {
            return default;
        }

        var list = input as IList<T> ?? [.. input];

        return list[GenerateRandomImplement<int>(0, list.Count)];
    }
}
