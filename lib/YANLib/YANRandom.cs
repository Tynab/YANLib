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
        var minValue = min.IsNull() ? byte.MinValue : min.To<byte>();
        var maxValue = max.IsNull() ? byte.MaxValue : max.To<byte>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).To<byte>();
    }

    public static sbyte NextSbyte(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? sbyte.MinValue : min.To<sbyte>();
        var maxValue = max.IsNull() ? sbyte.MaxValue : max.To<sbyte>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).To<sbyte>();
    }

    public static short NextShort(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? short.MinValue : min.To<short>();
        var maxValue = max.IsNull() ? short.MaxValue : max.To<short>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).To<short>();
    }

    public static ushort NextUshort(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? ushort.MinValue : min.To<ushort>();
        var maxValue = max.IsNull() ? ushort.MaxValue : max.To<ushort>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue).To<ushort>();
    }

    public static int NextInt(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? int.MinValue : min.To<int>();
        var maxValue = max.IsNull() ? int.MaxValue : max.To<int>();

        return minValue > maxValue ? default : random.Next(minValue, maxValue);
    }

    public static uint NextUint(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? uint.MinValue : min.To<uint>();
        var maxValue = max.IsNull() ? uint.MaxValue : max.To<uint>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue).To<uint>();
    }

    public static long NextLong(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? long.MinValue : min.To<long>();
        var maxValue = max.IsNull() ? long.MaxValue : max.To<long>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue);
    }

    public static ulong NextUlong(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? ulong.MinValue : min.To<ulong>();
        var maxValue = max.IsNull() ? ulong.MaxValue : max.To<ulong>();

        return minValue > maxValue ? default : (random.NextInt64(long.MinValue, (long)(maxValue - (minValue - (BigInteger)long.MinValue))) - long.MinValue).To<ulong>() + minValue;
    }

    public static nint NextNint(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? nint.MinValue : min.To<nint>();
        var maxValue = max.IsNull() ? nint.MaxValue : max.To<nint>();

        return minValue > maxValue ? default : random.NextInt64(minValue, maxValue).To<nint>();
    }

    public static nuint NextNuint(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? nuint.MinValue : min.To<nuint>();
        var maxValue = max.IsNull() ? nuint.MaxValue : max.To<nuint>();

        return minValue > maxValue ? default : (random.NextInt64(nint.MinValue, (long)(maxValue - (minValue - (BigInteger)nint.MinValue))) - nint.MinValue).To<nuint>() + minValue;
    }

    public static float NextSingle(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? float.MinValue * 1 / 100 : min.To<float>();
        var maxValue = max.IsNull() ? float.MaxValue * 1 / 100 : max.To<float>();

        return minValue < maxValue ? random.NextSingle() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static double NextDouble(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? double.MinValue * 1 / 100 : min.To<double>();
        var maxValue = max.IsNull() ? double.MaxValue * 1 / 100 : max.To<double>();

        return minValue < maxValue ? random.NextDouble() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
    }

    public static decimal NextDecimal(this Random random, object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? decimal.MinValue * 1 / 100 : min.To<decimal>();
        var maxValue = max.IsNull() ? decimal.MaxValue * 1 / 100 : max.To<decimal>();

        return minValue < maxValue ? random.NextDecimal() * (maxValue - minValue) + minValue : minValue == maxValue ? minValue : default;
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
            ? random.NextByte(min, max).To<T>()
            : typeof(T) == typeof(sbyte)
            ? random.NextSbyte(min, max).To<T>()
            : typeof(T) == typeof(short)
            ? random.NextShort(min, max).To<T>()
            : typeof(T) == typeof(ushort)
            ? random.NextUshort(min, max).To<T>()
            : typeof(T) == typeof(int)
            ? random.NextInt(min, max).To<T>()
            : typeof(T) == typeof(uint)
            ? random.NextUint(min, max).To<T>()
            : typeof(T) == typeof(long)
            ? random.NextLong(min, max).To<T>()
            : typeof(T) == typeof(ulong)
            ? random.NextUlong(min, max).To<T>()
            : typeof(T) == typeof(nint)
            ? random.NextNint(min, max).To<T>()
            : typeof(T) == typeof(nuint)
            ? random.NextNuint(min, max).To<T>()
            : typeof(T) == typeof(float)
            ? random.NextSingle(min, max).To<T>()
            : typeof(T) == typeof(double)
            ? random.NextDouble(min, max).To<T>()
            : typeof(T) == typeof(decimal)
            ? random.NextDecimal(min, max).To<T>()
            : random.NextBool().To<T>();
    }

    public static T? GenerateRandom<T>()
    {
        var random = new Random();

        return typeof(T) == typeof(byte)
            ? random.NextByte().To<T>()
            : typeof(T) == typeof(sbyte)
            ? random.NextSbyte().To<T>()
            : typeof(T) == typeof(short)
            ? random.NextShort().To<T>()
            : typeof(T) == typeof(ushort)
            ? random.NextUshort().To<T>()
            : typeof(T) == typeof(int)
            ? random.NextInt().To<T>()
            : typeof(T) == typeof(uint)
            ? random.NextUint().To<T>()
            : typeof(T) == typeof(long)
            ? random.NextLong().To<T>()
            : typeof(T) == typeof(ulong)
            ? random.NextUlong().To<T>()
            : typeof(T) == typeof(nint)
            ? random.NextNint().To<T>()
            : typeof(T) == typeof(nuint)
            ? random.NextNuint().To<T>()
            : typeof(T) == typeof(float)
            ? random.NextSingle().To<T>()
            : typeof(T) == typeof(double)
            ? random.NextDouble().To<T>()
            : typeof(T) == typeof(decimal)
            ? random.NextDecimal().To<T>()
            : typeof(T) == typeof(char)
            ? random.NextChar().To<T>()
            : typeof(T) == typeof(string)
            ? random.NextString().To<T>()
            : random.NextBool().To<T>();
    }

    public static IEnumerable<T> GenerateRandoms<T>(object? min = null, object? max = null, object? size = null) where T : unmanaged => Range(0, size.To<uint>().To<int>()).Select(i => GenerateRandom<T>(min, max));

    public static IEnumerable<T?> GenerateRandoms<T>(object? size = null) => Range(0, size.To<uint>().To<int>()).Select(i => GenerateRandom<T>());
}
