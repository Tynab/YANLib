using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified object to a float value.
    /// If the conversion fails, attempts to use the provided default value for conversion.
    /// If both conversions fail, returns the default value of a float.
    /// </summary>
    /// <param name="val">The object to be converted to a float. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>The float value of the converted object, or the converted default value, or the default value of a float if both conversions fail.</returns>
    public static float ToFloat(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToSingle(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToFloat();
        }
    }

    /// <summary>
    /// Converts a collection of objects to their respective float values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a float value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to floats. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of floats representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<float>? ToFloats(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToFloat(dfltVal));

    /// <summary>
    /// Converts a collection (ICollection) of objects to their respective float values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a float value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be converted to floats. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of floats representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<float>? ToFloats(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToFloat(dfltVal));

    /// <summary>
    /// Converts an array of objects to their respective float values.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the array is converted to a float value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The array of objects to be converted to floats. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An array of floats representing the converted values, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<float>? ToFloats(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToFloat(dfltVal));

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
