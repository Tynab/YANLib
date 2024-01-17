using System.Numerics;
using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified object to an unsigned native integer (nuint) value.
    /// If the conversion fails, attempts to use the provided default value for conversion.
    /// If both conversions fail, returns the default value of an unsigned native integer.
    /// </summary>
    /// <param name="val">The object to be converted to an unsigned native integer. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>The unsigned native integer value of the converted object, or the converted default value, or the default value of an unsigned native integer if both conversions fail.</returns>
    public static nuint ToNuint(this object? val, object? dfltVal = null)
    {
        try
        {
            return new UIntPtr(Convert.ToUInt64(val));
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToNuint();
        }
    }

    /// <summary>
    /// Converts a collection of objects to their respective unsigned native integer (nuint) values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to an unsigned native integer; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to unsigned native integers. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of unsigned native integers representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<nuint>? ToNuints(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNuint(dfltVal));

    /// <summary>
    /// Converts a collection (ICollection) of objects to their respective unsigned native integer (nuint) values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to an unsigned native integer; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be converted to unsigned native integers. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of unsigned native integers representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<nuint>? ToNuints(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNuint(dfltVal));

    /// <summary>
    /// Converts an array of objects to their respective unsigned native integer (nuint) values.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the array is converted to an unsigned native integer; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The array of objects to be converted to unsigned native integers. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An array of unsigned native integers representing the converted values, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<nuint>? ToNuints(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNuint(dfltVal));

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
