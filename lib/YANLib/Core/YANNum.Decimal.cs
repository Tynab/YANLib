using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANUnmanaged
{
    /// <summary>
    /// Generates a random decimal value within the specified minimum and maximum bounds.
    /// If the minimum or maximum values are invalid or unspecified, the full range of decimal values is considered.
    /// </summary>
    /// <param name="min">The minimum bound for the decimal value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the decimal value. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated decimal value within the specified bounds.</returns>
    public static decimal GenerateRandomDecimal(object? min = null, object? max = null) => new Random().NextDecimal(min, max);

    /// <summary>
    /// Generates a collection of random decimal values within specified minimum and maximum bounds, and of a specified size.
    /// If the minimum or maximum values are invalid or unspecified, uses the full range of decimal values.
    /// If the size is unspecified, defaults to a collection of size 0.
    /// </summary>
    /// <param name="min">The minimum bound for the decimal values. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the decimal values. Can be <see langword="null"/>.</param>
    /// <param name="size">The number of random decimal values to generate. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated decimal values within the specified bounds and of the specified size.</returns>
    public static IEnumerable<decimal> GenerateRandomDecimals(object? min = null, object? max = null, object? size = null) => Range(0, size.To<uint>().To<int>()).Select(i => GenerateRandomDecimal(min, max));
}
