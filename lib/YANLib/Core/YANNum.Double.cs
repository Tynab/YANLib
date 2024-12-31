using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANUnmanaged
{
    /// <summary>
    /// Generates a random double value within the specified minimum and maximum bounds.
    /// If the minimum or maximum values are invalid or unspecified, the full range of double values is considered.
    /// </summary>
    /// <param name="min">The minimum bound for the double value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the double value. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated double value within the specified bounds.</returns>
    public static double GenerateRandomDouble(object? min = null, object? max = null) => new Random().NextDouble(min, max);

    /// <summary>
    /// Generates a collection of random double values within specified minimum and maximum bounds, and of a specified size.
    /// If the minimum or maximum values are invalid or unspecified, uses the full range of double values.
    /// If the size is unspecified, defaults to a collection of size 0.
    /// </summary>
    /// <param name="min">The minimum bound for the double values. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the double values. Can be <see langword="null"/>.</param>
    /// <param name="size">The number of random double values to generate. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated double values within the specified bounds and of the specified size.</returns>
    public static IEnumerable<double> GenerateRandomDoubles(object? min = null, object? max = null, object? size = null) => Range(0, size.To<uint>().To<int>()).Select(i => GenerateRandomDouble(min, max));
}
