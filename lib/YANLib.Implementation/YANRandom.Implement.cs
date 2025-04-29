using System.Numerics;
using YANLib.Implementation;
using static System.Linq.Enumerable;

namespace YANLib.Implementation;

public static partial class YANRandom
{
    public static int NextInt32Implement(this Random random) => random.Next(0, 1 << 4) << 28 | random.Next(0, 1 << 28);

    public static decimal NextDecimalImplement(this Random random) => new(random.NextInt32Implement(), random.NextInt32Implement(), random.NextInt32Implement(), random.Next(2) is 1, (byte)random.Next(29));

    public static bool NextBoolImplement(this Random random) => random.NextByteImplement(0, 2) is 1;

    public static byte NextByteImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? byte.MinValue : min.ParseImplement<byte>();
        var maxValue = max.IsNullImplement() ? byte.MaxValue : max.ParseImplement<byte>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).ParseImplement<byte>();
    }

    public static sbyte NextSbyteImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? sbyte.MinValue : min.ParseImplement<sbyte>();
        var maxValue = max.IsNullImplement() ? sbyte.MaxValue : max.ParseImplement<sbyte>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).ParseImplement<sbyte>();
    }

    public static short NextShortImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? short.MinValue : min.ParseImplement<short>();
        var maxValue = max.IsNullImplement() ? short.MaxValue : max.ParseImplement<short>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).ParseImplement<short>();
    }

    public static ushort NextUshortImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? ushort.MinValue : min.ParseImplement<ushort>();
        var maxValue = max.IsNullImplement() ? ushort.MaxValue : max.ParseImplement<ushort>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).ParseImplement<ushort>();
    }

    public static int NextIntImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? int.MinValue : min.ParseImplement<int>();
        var maxValue = max.IsNullImplement() ? int.MaxValue : max.ParseImplement<int>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue);
    }

    public static uint NextUintImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? uint.MinValue : min.ParseImplement<uint>();
        var maxValue = max.IsNullImplement() ? uint.MaxValue : max.ParseImplement<uint>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue).ParseImplement<uint>();
    }

    public static long NextLongImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? long.MinValue : min.ParseImplement<long>();
        var maxValue = max.IsNullImplement() ? long.MaxValue : max.ParseImplement<long>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue);
    }

    public static ulong NextUlongImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? ulong.MinValue : min.ParseImplement<ulong>();
        var maxValue = max.IsNullImplement() ? ulong.MaxValue : max.ParseImplement<ulong>();

        return minValue > maxValue ? default : (random.NextInt64(long.MinValue, (long)(maxValue - (minValue - (BigInteger)long.MinValue))) - long.MinValue).ParseImplement<ulong>() + minValue;
    }

    public static nint NextNintImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? nint.MinValue : min.ParseImplement<nint>();
        var maxValue = max.IsNullImplement() ? nint.MaxValue : max.ParseImplement<nint>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue).ParseImplement<nint>();
    }

    public static nuint NextNuintImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? nuint.MinValue : min.ParseImplement<nuint>();
        var maxValue = max.IsNullImplement() ? nuint.MaxValue : max.ParseImplement<nuint>();

        return minValue > maxValue ? default : (random.NextInt64(nint.MinValue, (long)(maxValue - (minValue - (BigInteger)nint.MinValue))) - nint.MinValue).ParseImplement<nuint>() + minValue;
    }

    public static float NextSingleImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? float.MinValue * 1 / 100 : min.ParseImplement<float>();
        var maxValue = max.IsNullImplement() ? float.MaxValue * 1 / 100 : max.ParseImplement<float>();

        return minValue < maxValue ? random.NextSingle() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static double NextDoubleImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? double.MinValue * 1 / 100 : min.ParseImplement<double>();
        var maxValue = max.IsNullImplement() ? double.MaxValue * 1 / 100 : max.ParseImplement<double>();

        return minValue < maxValue ? random.NextDouble() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static decimal NextDecimalImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? decimal.MinValue * 1 / 100 : min.ParseImplement<decimal>();
        var maxValue = max.IsNullImplement() ? decimal.MaxValue * 1 / 100 : max.ParseImplement<decimal>();

        return minValue < maxValue ? random.NextDecimalImplement() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static DateTime NextDateTimeImplement(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNullImplement() ? DateTime.MinValue : min.ParseImplement<DateTime>();
        var maxValue = max.IsNullImplement() ? DateTime.MaxValue : max.ParseImplement<DateTime>();

        return minValue > maxValue ? default : minValue.AddTicks(random.NextUlongImplement(max: (maxValue - minValue).Ticks).ParseImplement<long>());
    }

    public static char NextCharImplement(this Random random)
    {
        var chars = "abcdefghijklmnopqrstuvwxyz";

        return chars[random.NextByteImplement(byte.MinValue, chars.Length)];
    }

    public static string NextStringImplement(this Random random, object? size = null) => string.Concat(GenerateRandomsImplement<string>(size: size ?? random.NextByteImplement()));

    public static T GenerateRandomImplement<T>(object? min = null, object? max = null) where T : unmanaged
    {
        var random = new Random();

        return typeof(T) == typeof(byte)
            ? random.NextByteImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(sbyte)
            ? random.NextSbyteImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(short)
            ? random.NextShortImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(ushort)
            ? random.NextUshortImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(int)
            ? random.NextIntImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(uint)
            ? random.NextUintImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(long)
            ? random.NextLongImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(ulong)
            ? random.NextUlongImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(nint)
            ? random.NextNintImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(nuint)
            ? random.NextNuintImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(float)
            ? random.NextSingleImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(double)
            ? random.NextDoubleImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(decimal)
            ? random.NextDecimalImplement(min, max).ParseImplement<T>()
            : typeof(T) == typeof(DateTime)
            ? random.NextDateTimeImplement(min, max).ParseImplement<T>()
            : random.NextBoolImplement().ParseImplement<T>();
    }

    public static T? GenerateRandomImplement<T>()
    {
        var random = new Random();

        return typeof(T) == typeof(byte)
            ? random.NextByteImplement().ParseImplement<T>()
            : typeof(T) == typeof(sbyte)
            ? random.NextSbyteImplement().ParseImplement<T>()
            : typeof(T) == typeof(short)
            ? random.NextShortImplement().ParseImplement<T>()
            : typeof(T) == typeof(ushort)
            ? random.NextUshortImplement().ParseImplement<T>()
            : typeof(T) == typeof(int)
            ? random.NextIntImplement().ParseImplement<T>()
            : typeof(T) == typeof(uint)
            ? random.NextUintImplement().ParseImplement<T>()
            : typeof(T) == typeof(long)
            ? random.NextLongImplement().ParseImplement<T>()
            : typeof(T) == typeof(ulong)
            ? random.NextUlongImplement().ParseImplement<T>()
            : typeof(T) == typeof(nint)
            ? random.NextNintImplement().ParseImplement<T>()
            : typeof(T) == typeof(nuint)
            ? random.NextNuintImplement().ParseImplement<T>()
            : typeof(T) == typeof(float)
            ? random.NextSingle().ParseImplement<T>()
            : typeof(T) == typeof(double)
            ? random.NextDouble().ParseImplement<T>()
            : typeof(T) == typeof(decimal)
            ? random.NextDecimalImplement().ParseImplement<T>()
            : typeof(T) == typeof(DateTime)
            ? random.NextDateTimeImplement().ParseImplement<T>()
            : typeof(T) == typeof(char)
            ? random.NextCharImplement().ParseImplement<T>()
            : typeof(T) == typeof(string)
            ? random.NextStringImplement().ParseImplement<T>()
            : random.NextBoolImplement().ParseImplement<T>();
    }

    public static IEnumerable<T> GenerateRandomsImplement<T>(object? min = null, object? max = null, object? size = null) where T : unmanaged
        => Range(0, size.ParseImplement<uint>().ParseImplement<int>()).Select(i => GenerateRandomImplement<T>(min, max));

    public static IEnumerable<T?> GenerateRandomsImplement<T>(object? size = null) => Range(0, size.ParseImplement<uint>().ParseImplement<int>()).Select(i => GenerateRandomImplement<T>());
}
