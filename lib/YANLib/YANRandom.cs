using System.Numerics;
using YANLib.Object;
using YANLib.Unmanaged;
using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANRandom
{
    public static int NextInt32(this Random random) => random.Next(0, 1 << 4) << 28 | random.Next(0, 1 << 28);

    public static decimal NextDecimal(this Random random) => new(random.NextInt32(), random.NextInt32(), random.NextInt32(), random.Next(2) is 1, (byte)random.Next(29));

    public static bool NextBool(this Random random) => random.NextByte(0, 2) is 1;

    public static byte NextByte(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? byte.MinValue : min.Parse<byte>();
        var maxValue = max.IsNull() ? byte.MaxValue : max.Parse<byte>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).Parse<byte>();
    }

    public static sbyte NextSbyte(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? sbyte.MinValue : min.Parse<sbyte>();
        var maxValue = max.IsNull() ? sbyte.MaxValue : max.Parse<sbyte>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).Parse<sbyte>();
    }

    public static short NextShort(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? short.MinValue : min.Parse<short>();
        var maxValue = max.IsNull() ? short.MaxValue : max.Parse<short>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).Parse<short>();
    }

    public static ushort NextUshort(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? ushort.MinValue : min.Parse<ushort>();
        var maxValue = max.IsNull() ? ushort.MaxValue : max.Parse<ushort>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).Parse<ushort>();
    }

    public static int NextInt(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? int.MinValue : min.Parse<int>();
        var maxValue = max.IsNull() ? int.MaxValue : max.Parse<int>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue);
    }

    public static uint NextUint(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? uint.MinValue : min.Parse<uint>();
        var maxValue = max.IsNull() ? uint.MaxValue : max.Parse<uint>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue).Parse<uint>();
    }

    public static long NextLong(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? long.MinValue : min.Parse<long>();
        var maxValue = max.IsNull() ? long.MaxValue : max.Parse<long>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue);
    }

    public static ulong NextUlong(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? ulong.MinValue : min.Parse<ulong>();
        var maxValue = max.IsNull() ? ulong.MaxValue : max.Parse<ulong>();

        return minValue > maxValue ? default : (random.NextInt64(long.MinValue, (long)(maxValue - (minValue - (BigInteger)long.MinValue))) - long.MinValue).Parse<ulong>() + minValue;
    }

    public static nint NextNint(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? nint.MinValue : min.Parse<nint>();
        var maxValue = max.IsNull() ? nint.MaxValue : max.Parse<nint>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue).Parse<nint>();
    }

    public static nuint NextNuint(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? nuint.MinValue : min.Parse<nuint>();
        var maxValue = max.IsNull() ? nuint.MaxValue : max.Parse<nuint>();

        return minValue > maxValue ? default : (random.NextInt64(nint.MinValue, (long)(maxValue - (minValue - (BigInteger)nint.MinValue))) - nint.MinValue).Parse<nuint>() + minValue;
    }

    public static float NextSingle(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? float.MinValue * 1 / 100 : min.Parse<float>();
        var maxValue = max.IsNull() ? float.MaxValue * 1 / 100 : max.Parse<float>();

        return minValue < maxValue ? random.NextSingle() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static double NextDouble(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? double.MinValue * 1 / 100 : min.Parse<double>();
        var maxValue = max.IsNull() ? double.MaxValue * 1 / 100 : max.Parse<double>();

        return minValue < maxValue ? random.NextDouble() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static decimal NextDecimal(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? decimal.MinValue * 1 / 100 : min.Parse<decimal>();
        var maxValue = max.IsNull() ? decimal.MaxValue * 1 / 100 : max.Parse<decimal>();

        return minValue < maxValue ? random.NextDecimal() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static DateTime NextDateTime(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? DateTime.MinValue : min.Parse<DateTime>();
        var maxValue = max.IsNull() ? DateTime.MaxValue : max.Parse<DateTime>();

        return minValue > maxValue ? default : minValue.AddTicks(random.NextUlong(max: (maxValue - minValue).Ticks).Parse<long>());
    }

    public static char NextChar(this Random random)
    {
        var chars = "abcdefghijklmnopqrstuvwxyz";

        return chars[random.NextByte(byte.MinValue, chars.Length)];
    }

    public static string NextString(this Random random, object? size = null) => string.Concat(GenerateRandoms<string>(size: size ?? random.NextByte()));

    public static T GenerateRandom<T>(object? min = null, object? max = null) where T : unmanaged
    {
        var random = new Random();

        return typeof(T) == typeof(byte)
            ? random.NextByte(min, max).Parse<T>()
            : typeof(T) == typeof(sbyte)
            ? random.NextSbyte(min, max).Parse<T>()
            : typeof(T) == typeof(short)
            ? random.NextShort(min, max).Parse<T>()
            : typeof(T) == typeof(ushort)
            ? random.NextUshort(min, max).Parse<T>()
            : typeof(T) == typeof(int)
            ? random.NextInt(min, max).Parse<T>()
            : typeof(T) == typeof(uint)
            ? random.NextUint(min, max).Parse<T>()
            : typeof(T) == typeof(long)
            ? random.NextLong(min, max).Parse<T>()
            : typeof(T) == typeof(ulong)
            ? random.NextUlong(min, max).Parse<T>()
            : typeof(T) == typeof(nint)
            ? random.NextNint(min, max).Parse<T>()
            : typeof(T) == typeof(nuint)
            ? random.NextNuint(min, max).Parse<T>()
            : typeof(T) == typeof(float)
            ? random.NextSingle(min, max).Parse<T>()
            : typeof(T) == typeof(double)
            ? random.NextDouble(min, max).Parse<T>()
            : typeof(T) == typeof(decimal)
            ? random.NextDecimal(min, max).Parse<T>()
            : typeof(T) == typeof(DateTime)
            ? random.NextDateTime(min, max).Parse<T>()
            : random.NextBool().Parse<T>();
    }

    public static T? GenerateRandom<T>()
    {
        var random = new Random();

        return typeof(T) == typeof(byte)
            ? random.NextByte().Parse<T>()
            : typeof(T) == typeof(sbyte)
            ? random.NextSbyte().Parse<T>()
            : typeof(T) == typeof(short)
            ? random.NextShort().Parse<T>()
            : typeof(T) == typeof(ushort)
            ? random.NextUshort().Parse<T>()
            : typeof(T) == typeof(int)
            ? random.NextInt().Parse<T>()
            : typeof(T) == typeof(uint)
            ? random.NextUint().Parse<T>()
            : typeof(T) == typeof(long)
            ? random.NextLong().Parse<T>()
            : typeof(T) == typeof(ulong)
            ? random.NextUlong().Parse<T>()
            : typeof(T) == typeof(nint)
            ? random.NextNint().Parse<T>()
            : typeof(T) == typeof(nuint)
            ? random.NextNuint().Parse<T>()
            : typeof(T) == typeof(float)
            ? random.NextSingle().Parse<T>()
            : typeof(T) == typeof(double)
            ? random.NextDouble().Parse<T>()
            : typeof(T) == typeof(decimal)
            ? random.NextDecimal().Parse<T>()
            : typeof(T) == typeof(DateTime)
            ? random.NextDateTime().Parse<T>()
            : typeof(T) == typeof(char)
            ? random.NextChar().Parse<T>()
            : typeof(T) == typeof(string)
            ? random.NextString().Parse<T>()
            : random.NextBool().Parse<T>();
    }

    public static IEnumerable<T> GenerateRandoms<T>(object? min = null, object? max = null, object? size = null) where T : unmanaged => Range(0, size.Parse<uint>().Parse<int>()).Select(i => GenerateRandom<T>(min, max));

    public static IEnumerable<T?> GenerateRandoms<T>(object? size = null) => Range(0, size.Parse<uint>().Parse<int>()).Select(i => GenerateRandom<T>());
}
