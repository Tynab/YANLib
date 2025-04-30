using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANRandom
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int NextInt32(this Random random) => random.NextInt32Implement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static decimal NextDecimal(this Random random) => random.NextDecimalImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool NextBool(this Random random) => random.NextBoolImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static byte NextByte(this Random random, object? min = null, object? max = null) => random.NextByteImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static sbyte NextSbyte(this Random random, object? min = null, object? max = null) => random.NextSbyteImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static short NextShort(this Random random, object? min = null, object? max = null) => random.NextShortImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ushort NextUshort(this Random random, object? min = null, object? max = null) => random.NextUshortImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int NextInt(this Random random, object? min = null, object? max = null) => random.NextIntImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static uint NextUint(this Random random, object? min = null, object? max = null) => random.NextUintImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static long NextLong(this Random random, object? min = null, object? max = null) => random.NextLongImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ulong NextUlong(this Random random, object? min = null, object? max = null) => random.NextUlongImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static nint NextNint(this Random random, object? min = null, object? max = null) => random.NextNintImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static nuint NextNuint(this Random random, object? min = null, object? max = null) => random.NextNuintImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static float NextSingle(this Random random, object? min = null, object? max = null) => random.NextSingleImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static double NextDouble(this Random random, object? min = null, object? max = null) => random.NextDoubleImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static decimal NextDecimal(this Random random, object? min = null, object? max = null) => random.NextDecimalImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static DateTime NextDateTime(this Random random, object? min = null, object? max = null) => random.NextDateTimeImplement(min, max);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char NextChar(this Random random) => random.NextCharImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string NextString(this Random random, object? size = null) => random.NextStringImplement(size);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T GenerateRandom<T>(object? min = null, object? max = null) where T : unmanaged => Implementation.YANRandom.GenerateRandomImplement<T>(min, max);
}
