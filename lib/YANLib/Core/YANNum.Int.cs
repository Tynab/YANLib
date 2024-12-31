using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANUnmanaged
{
    /// <summary>
    /// Generates a random integer value within the specified minimum and maximum bounds.
    /// If the minimum or maximum values are invalid or unspecified, defaults to the minimum and maximum limits of an integer.
    /// If the minimum value is greater than the maximum, returns the default integer value.
    /// </summary>
    /// <param name="min">The minimum bound for the integer value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the integer value. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated integer value within the specified bounds, or the default value of an integer if bounds are invalid.</returns>
    public static int GenerateRandomInt(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? int.MinValue : min.ToInt();
        var maxValue = max.IsNull() ? int.MaxValue : max.ToInt();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue);
    }

    /// <summary>
    /// Generates a collection of random integer values within specified minimum and maximum bounds, and of a specified size.
    /// If the minimum or maximum values are invalid or unspecified, uses the minimum and maximum limits of an integer.
    /// If the size is unspecified, defaults to a collection of size 0.
    /// </summary>
    /// <param name="min">The minimum bound for the integer values. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the integer values. Can be <see langword="null"/>.</param>
    /// <param name="size">The number of random integer values to generate. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated integer values within the specified bounds and of the specified size.</returns>
    public static IEnumerable<int> GenerateRandomInts(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomInt(min, max));
}
