using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANUnmanaged
{
    /// <summary>
    /// Generates a random signed byte (sbyte) value within the specified minimum and maximum bounds.
    /// If the minimum or maximum values are invalid or unspecified, defaults to the minimum and maximum limits of a signed byte.
    /// If the minimum value is greater than the maximum, returns the default signed byte value.
    /// </summary>
    /// <param name="min">The minimum bound for the signed byte value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the signed byte value. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated signed byte value within the specified bounds, or the default value of a signed byte if bounds are invalid.</returns>
    public static sbyte GenerateRandomSbyte(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? sbyte.MinValue : min.ToSbyte();
        var maxValue = max.IsNull() ? sbyte.MaxValue : max.ToSbyte();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToSbyte();
    }

    /// <summary>
    /// Generates a collection of random signed byte values within specified minimum and maximum bounds, and of a specified size.
    /// If the minimum or maximum values are invalid or unspecified, uses the minimum and maximum limits of a signed byte.
    /// If the size is unspecified, defaults to a collection of size 0.
    /// </summary>
    /// <param name="min">The minimum bound for the signed byte values. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the signed byte values. Can be <see langword="null"/>.</param>
    /// <param name="size">The number of random signed byte values to generate. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated signed byte values within the specified bounds and of the specified size.</returns>
    public static IEnumerable<sbyte> GenerateRandomSbytes(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomSbyte(min, max));
}
