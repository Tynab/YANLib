using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods and utility functions for generating random values of various types.
/// </summary>
/// <remarks>
/// This class extends the functionality of the <see cref="System.Random"/> class with methods to generate
/// random values for a wide range of data types including numeric types, booleans, characters, strings, and dates.
/// All methods are designed to handle edge cases and provide consistent random distribution.
/// </remarks>
public static partial class YANRandom
{
    /// <summary>
    /// Generates a random 32-bit signed integer that includes negative values.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <returns>A random 32-bit signed integer that includes the full range of possible values.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int NextInt32(this Random random) => random.NextInt32Implement();

    /// <summary>
    /// Generates a random decimal value that is greater than or equal to 0 and less than 1.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <returns>A random decimal value in [0, 1), uniformly distributed over the multiples of 10^-28.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static decimal NextDecimal(this Random random) => random.NextDecimalImplement();

    /// <summary>
    /// Generates a random boolean value.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <returns>A random boolean value, either <c>true</c> or <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool NextBool(this Random random) => random.NextBoolImplement();

    /// <summary>
    /// Generates a random byte value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="byte.MinValue"/> is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="byte.MaxValue"/> is used.</param>
    /// <returns>A random byte value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static byte NextByte(this Random random, object? min = null, object? max = null) => random.NextByteImplement(min, max);

    /// <summary>
    /// Generates a random signed byte value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="sbyte.MinValue"/> is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="sbyte.MaxValue"/> is used.</param>
    /// <returns>A random signed byte value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static sbyte NextSbyte(this Random random, object? min = null, object? max = null) => random.NextSbyteImplement(min, max);

    /// <summary>
    /// Generates a random short value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="short.MinValue"/> is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="short.MaxValue"/> is used.</param>
    /// <returns>A random short value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static short NextShort(this Random random, object? min = null, object? max = null) => random.NextShortImplement(min, max);

    /// <summary>
    /// Generates a random unsigned short value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="ushort.MinValue"/> is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="ushort.MaxValue"/> is used.</param>
    /// <returns>A random unsigned short value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ushort NextUshort(this Random random, object? min = null, object? max = null) => random.NextUshortImplement(min, max);

    /// <summary>
    /// Generates a random integer value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="int.MinValue"/> is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="int.MaxValue"/> is used.</param>
    /// <returns>A random integer value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int NextInt(this Random random, object? min = null, object? max = null) => random.NextIntImplement(min, max);

    /// <summary>
    /// Generates a random unsigned integer value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="uint.MinValue"/> is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="uint.MaxValue"/> is used.</param>
    /// <returns>A random unsigned integer value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static uint NextUint(this Random random, object? min = null, object? max = null) => random.NextUintImplement(min, max);

    /// <summary>
    /// Generates a random long value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="long.MinValue"/> is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="long.MaxValue"/> is used.</param>
    /// <returns>A random long value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static long NextLong(this Random random, object? min = null, object? max = null) => random.NextLongImplement(min, max);

    /// <summary>
    /// Generates a random unsigned long value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="ulong.MinValue"/> is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="ulong.MaxValue"/> is used.</param>
    /// <returns>A random unsigned long value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    /// <remarks>
    /// The range is half-open and uniform, so the default range never returns <see cref="ulong.MaxValue"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ulong NextUlong(this Random random, object? min = null, object? max = null) => random.NextUlongImplement(min, max);

    /// <summary>
    /// Generates a random native integer value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="nint.MinValue"/> is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="nint.MaxValue"/> is used.</param>
    /// <returns>A random native integer value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static nint NextNint(this Random random, object? min = null, object? max = null) => random.NextNintImplement(min, max);

    /// <summary>
    /// Generates a random unsigned native integer value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="nuint.MinValue"/> is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="nuint.MaxValue"/> is used.</param>
    /// <returns>A random unsigned native integer value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static nuint NextNuint(this Random random, object? min = null, object? max = null) => random.NextNuintImplement(min, max);

    /// <summary>
    /// Generates a random single-precision floating-point value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="float.MinValue"/> / 100 is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="float.MaxValue"/> / 100 is used.</param>
    /// <returns>A random single-precision floating-point value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    /// <remarks>
    /// The range is half-open: when rounding would produce <paramref name="max"/>, the largest <see cref="float"/> below it is returned instead.
    /// A range wider than <see cref="float.MaxValue"/> (for example from <see cref="float.MinValue"/> to <see cref="float.MaxValue"/>) is supported.
    /// If <paramref name="min"/> equals <paramref name="max"/>, <paramref name="min"/> is returned.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static float NextSingle(this Random random, object? min = null, object? max = null) => random.NextSingleImplement(min, max);

    /// <summary>
    /// Generates a random double-precision floating-point value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="double.MinValue"/> / 100 is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="double.MaxValue"/> / 100 is used.</param>
    /// <returns>A random double-precision floating-point value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    /// <remarks>
    /// The range is half-open: when rounding would produce <paramref name="max"/>, the largest <see cref="double"/> below it is returned instead.
    /// A range wider than <see cref="double.MaxValue"/> (for example from <see cref="double.MinValue"/> to <see cref="double.MaxValue"/>) is supported.
    /// If <paramref name="min"/> equals <paramref name="max"/>, <paramref name="min"/> is returned.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static double NextDouble(this Random random, object? min = null, object? max = null) => random.NextDoubleImplement(min, max);

    /// <summary>
    /// Generates a random decimal value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random number returned. If <c>null</c>, <see cref="decimal.MinValue"/> / 100 is used.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. If <c>null</c>, <see cref="decimal.MaxValue"/> / 100 is used.</param>
    /// <returns>A random decimal value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    /// <remarks>
    /// The range is half-open: a value that rounding brings to <paramref name="max"/> is drawn again. A range wider than
    /// <see cref="decimal.MaxValue"/> (for example from <see cref="decimal.MinValue"/> to <see cref="decimal.MaxValue"/>) is supported.
    /// If <paramref name="min"/> equals <paramref name="max"/>, <paramref name="min"/> is returned.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static decimal NextDecimal(this Random random, object? min = null, object? max = null) => random.NextDecimalImplement(min, max);

    /// <summary>
    /// Generates a random DateTime value within the specified range.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="min">The inclusive lower bound of the random date returned. If <c>null</c>, <see cref="DateTime.MinValue"/> is used.</param>
    /// <param name="max">The exclusive upper bound of the random date returned. If <c>null</c>, <see cref="DateTime.MaxValue"/> is used.</param>
    /// <returns>A random DateTime value within the specified range, or the default value if <paramref name="min"/> is greater than <paramref name="max"/>.</returns>
    /// <remarks>
    /// The result is a whole number of ticks in [<paramref name="min"/>, <paramref name="max"/>), so it keeps sub-second precision, and it has
    /// the <see cref="DateTime.Kind"/> of <paramref name="min"/>. If <paramref name="min"/> equals <paramref name="max"/>, <paramref name="min"/> is returned.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static DateTime NextDateTime(this Random random, object? min = null, object? max = null) => random.NextDateTimeImplement(min, max);

    /// <summary>
    /// Generates a random lowercase letter character.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <returns>A random lowercase letter character from 'a' to 'z'.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char NextChar(this Random random) => random.NextCharImplement();

    /// <summary>
    /// Generates a random string of lowercase letters with the specified size.
    /// </summary>
    /// <param name="random">The random number generator.</param>
    /// <param name="size">The length of the string to generate. If <c>null</c>, a random length is used.</param>
    /// <returns>A random string of lowercase letters with the specified size.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string NextString(this Random random, object? size = null) => random.NextStringImplement(size);

    /// <summary>
    /// Generates a random value of the specified unmanaged type within the specified range.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to generate a random value for.</typeparam>
    /// <param name="min">The inclusive lower bound of the random value returned. If <c>null</c>, the minimum value for the type is used.</param>
    /// <param name="max">The exclusive upper bound of the random value returned. If <c>null</c>, the maximum value for the type is used.</param>
    /// <returns>A random value of the specified type within the specified range.</returns>
    /// <remarks>
    /// Ranges are supported for the 13 numeric types, <see cref="DateTime"/> and <see cref="char"/> (a lowercase letter when both
    /// bounds are <c>null</c>), with the same rules as the corresponding <c>Next...</c> method. <see cref="bool"/> gets a random value; any
    /// other type ignores the bounds and gets a random <see cref="bool"/> converted to <typeparamref name="T"/>, which for <see cref="Guid"/>,
    /// <see cref="TimeSpan"/> and most enums is always <c>default(T)</c> (<see cref="Guid.Empty"/>, <see cref="DayOfWeek.Sunday"/>), not a
    /// random value. Values come from <see cref="Random.Shared"/>, so concurrent calls are safe.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T GenerateRandom<T>(object? min = null, object? max = null) where T : unmanaged => Implementation.YANRandom.GenerateRandomImplement<T>(min, max);

    /// <summary>
    /// Generates a random value of the specified unmanaged type in the range [<paramref name="min"/>, <paramref name="max"/>).
    /// </summary>
    /// <typeparam name="T">The unmanaged type to generate a random value for.</typeparam>
    /// <param name="min">The inclusive lower bound of the random value returned.</param>
    /// <param name="max">The exclusive upper bound of the random value returned.</param>
    /// <returns>
    /// A random value in [<paramref name="min"/>, <paramref name="max"/>) for the 13 numeric types, <see cref="DateTime"/> and <see cref="char"/>
    /// (<c>default(T)</c> if <paramref name="min"/> is greater than <paramref name="max"/>, <paramref name="min"/> if they are equal);
    /// for any other unmanaged type (<see cref="bool"/>, <see cref="Guid"/>, enums, ...), <paramref name="min"/> or <paramref name="max"/> with equal probability.
    /// </returns>
    /// <remarks>
    /// The range rules are those of <see cref="GenerateRandom{T}(object, object)"/>. This overload makes calls with two typed bounds, such as
    /// <c>YANRandom.GenerateRandom&lt;int&gt;(18, 80)</c>, generate a value in the range: up to 8.3.3 they bound to
    /// <see cref="GenerateRandom{T}(T[])"/>, which returns one of its arguments. A two-bound call that names one or both bounds, such as
    /// <c>YANRandom.GenerateRandom&lt;Guid&gt;(min: a, max: b)</c> or <c>(a, max: b)</c>, bound to <see cref="GenerateRandom{T}(object, object)"/>
    /// instead, which ignores the bounds of a <see cref="bool"/>, <see cref="Guid"/> or enum (a random <see cref="bool"/>, <see cref="Guid.Empty"/>,
    /// the zero value of most enums); such a call now returns <paramref name="min"/> or <paramref name="max"/> as well. To pick one of two values,
    /// pass them as an array: <c>YANRandom.GenerateRandom(new[] { a, b })</c>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T GenerateRandom<T>(T min, T max) where T : unmanaged => Implementation.YANRandom.GenerateRandomRangeImplement(min, max);

    /// <summary>
    /// Generates a random value from the specified input collection.
    /// </summary>
    /// <typeparam name="T">The unmanaged type of elements in the collection.</typeparam>
    /// <param name="input">The source collection to select a random value from. If <c>null</c> or empty, returns the default value for the type.</param>
    /// <returns>A random value selected from the input collection, or the default value if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method selects a single random element from the input collection.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T GenerateRandom<T>(this IEnumerable<T>? input) where T : unmanaged => input.GenerateRandomImplement();

    /// <summary>
    /// Generates a random value from the specified array of values.
    /// </summary>
    /// <typeparam name="T">The unmanaged type of elements in the array.</typeparam>
    /// <param name="input">The source array to select a random value from. If <c>null</c> or empty, returns the default value for the type.</param>
    /// <returns>A random value selected from the input array, or the default value if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to select a random value from an array without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// A call with exactly two separate arguments binds to <see cref="GenerateRandom{T}(T, T)"/> instead, which returns a value in the range
    /// between them for numeric types, <see cref="DateTime"/> and <see cref="char"/>; to pick one of two such values, pass an array.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T GenerateRandom<T>(params T[]? input) where T : unmanaged => input.GenerateRandomImplement();
}
