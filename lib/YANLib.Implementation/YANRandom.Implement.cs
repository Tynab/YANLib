using System.Diagnostics;
using System.Numerics;
using static System.BitConverter;

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
        var bytes = new byte[16];

        random.NextBytes(bytes);

        var dec = new decimal(ToInt32(bytes, 0), ToInt32(bytes, 4), ToInt32(bytes, 8), false, 28);

        return dec > 1 ? dec / 10 : dec;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool NextBoolImplement(this Random random) => random.NextByteImplement(0, 2) is 1;

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
        else
        {
            var buffer = new byte[8];

            random.NextBytes(buffer);

            var rand = ToUInt64(buffer, 0);
            var r = maxValue - minValue;

            return r == ulong.MaxValue ? rand : rand % (r + 1) + minValue;
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static nint NextNintImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? nint.MinValue : min.ParseImplement<nint>();
        var maxValue = max is null ? nint.MaxValue : max.ParseImplement<nint>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue).ParseImplement<nint>();
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static nuint NextNuintImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? nuint.MinValue : min.ParseImplement<nuint>();
        var maxValue = max is null ? nuint.MaxValue : max.ParseImplement<nuint>();

        return minValue > maxValue ? default : (random.NextInt64(nint.MinValue, (long)(maxValue - (minValue - (BigInteger)nint.MinValue))) - nint.MinValue).ParseImplement<nuint>() + minValue;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static float NextSingleImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? float.MinValue / 100 : min.ParseImplement<float>();
        var maxValue = max is null ? float.MaxValue / 100 : max.ParseImplement<float>();

        return minValue < maxValue ? random.NextSingle() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static double NextDoubleImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? double.MinValue / 100 : min.ParseImplement<double>();
        var maxValue = max is null ? double.MaxValue / 100 : max.ParseImplement<double>();

        return minValue < maxValue ? random.NextDouble() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static decimal NextDecimalImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? decimal.MinValue / 100 : min.ParseImplement<decimal>();
        var maxValue = max is null ? decimal.MaxValue / 100 : max.ParseImplement<decimal>();

        return minValue < maxValue ? random.NextDecimalImplement() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static DateTime NextDateTimeImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min is null ? DateTime.MinValue : min.ParseImplement<DateTime>();
        var maxValue = max is null ? DateTime.MaxValue : max.ParseImplement<DateTime>();

        return minValue > maxValue ? default : minValue.AddTicks(random.NextUlongImplement(max: (maxValue - minValue).Ticks).ParseImplement<long>());
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char NextCharImplement(this Random random)
    {
        var chars = "abcdefghijklmnopqrstuvwxyz";

        return chars[random.NextByteImplement(byte.MinValue, chars.Length)];
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string NextStringImplement(this Random random, object? size = null) => string.Concat(GenerateRandomsImplement<char>(size: size ?? random.NextByteImplement()));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T GenerateRandomImplement<T>(object? min = null, object? max = null) where T : unmanaged
    {
        var random = new Random();

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
            _ => random.NextBoolImplement().ParseImplement<T>(),
        };
    }

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
