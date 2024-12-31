using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANUnmanaged
{
    /// <summary>
    /// Generates a random native integer (nint) value within the specified minimum and maximum bounds.
    /// If the minimum or maximum values are invalid or unspecified, defaults to the minimum and maximum limits of a native integer.
    /// If the minimum value is greater than the maximum, returns the default native integer value.
    /// </summary>
    /// <param name="min">The minimum bound for the native integer value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the native integer value. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated native integer value within the specified bounds, or the default value of a native integer if bounds are invalid.</returns>
    public static nint GenerateRandomNint(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? nint.MinValue : min.ToNint();
        var maxValue = max.IsNull() ? nint.MaxValue : max.ToNint();

        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue).ToNint();
    }

    /// <summary>
    /// Generates a collection of random native integer values within specified minimum and maximum bounds, and of a specified size.
    /// If the minimum or maximum values are invalid or unspecified, uses the minimum and maximum limits of a native integer.
    /// If the size is unspecified, defaults to a collection of size 0.
    /// </summary>
    /// <param name="min">The minimum bound for the native integer values. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the native integer values. Can be <see langword="null"/>.</param>
    /// <param name="size">The number of random native integer values to generate. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated native integer values within the specified bounds and of the specified size.</returns>
    public static IEnumerable<nint> GenerateRandomNints(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomNint(min, max));
}
