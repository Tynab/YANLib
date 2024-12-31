using System.Numerics;
using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANUnmanaged
{
    /// <summary>
    /// Generates a random unsigned native integer (nuint) value within the specified minimum and maximum bounds.
    /// If the minimum or maximum values are invalid or unspecified, defaults to the minimum and maximum limits of an unsigned native integer.
    /// If the minimum value is greater than the maximum, returns the default unsigned native integer value.
    /// </summary>
    /// <param name="min">The minimum bound for the unsigned native integer value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the unsigned native integer value. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated unsigned native integer value within the specified bounds, or the default value of an unsigned native integer if bounds are invalid.</returns>
    public static nuint GenerateRandomNuint(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? nuint.MinValue : min.ToNuint();
        var maxValue = max.IsNull() ? nuint.MaxValue : max.ToNuint();

        return minValue > maxValue ? default : (new Random().NextInt64(nint.MinValue, (long)(maxValue - (minValue - (BigInteger)nint.MinValue))) - nint.MinValue).ToNuint() + minValue;
    }

    /// <summary>
    /// Generates a collection of random unsigned native integer values within specified minimum and maximum bounds, and of a specified size.
    /// If the minimum or maximum values are invalid or unspecified, uses the minimum and maximum limits of an unsigned native integer.
    /// If the size is unspecified, defaults to a collection of size 0.
    /// </summary>
    /// <param name="min">The minimum bound for the unsigned native integer values. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the unsigned native integer values. Can be <see langword="null"/>.</param>
    /// <param name="size">The number of random unsigned native integer values to generate. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated unsigned native integer values within the specified bounds and of the specified size.</returns>
    public static IEnumerable<nuint> GenerateRandomNuints(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomNuint(min, max));
}
