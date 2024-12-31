using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANUnmanaged
{
    /// <summary>
    /// Generates a random float value within the specified minimum and maximum bounds.
    /// If the minimum or maximum values are invalid or unspecified, the full range of float values is considered.
    /// </summary>
    /// <param name="min">The minimum bound for the float value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the float value. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated float value within the specified bounds.</returns>
    public static float GenerateRandomFloat(object? min = null, object? max = null) => new Random().NextSingle(min, max);

    /// <summary>
    /// Generates a collection of random float values within specified minimum and maximum bounds, and of a specified size.
    /// If the minimum or maximum values are invalid or unspecified, uses the full range of float values.
    /// If the size is unspecified, defaults to a collection of size 0.
    /// </summary>
    /// <param name="min">The minimum bound for the float values. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the float values. Can be <see langword="null"/>.</param>
    /// <param name="size">The number of random float values to generate. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated float values within the specified bounds and of the specified size.</returns>
    public static IEnumerable<float> GenerateRandomFloats(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomFloat(min, max));
}
