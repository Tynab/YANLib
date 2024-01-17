using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified object to a long (Int64) value.
    /// If the conversion fails, attempts to use the provided default value for conversion.
    /// If both conversions fail, returns the default value of a long.
    /// </summary>
    /// <param name="val">The object to be converted to a long. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>The long value of the converted object, or the converted default value, or the default value of a long if both conversions fail.</returns>
    public static long ToLong(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt64(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToLong();
        }
    }

    /// <summary>
    /// Converts a collection of objects to their respective long (Int64) values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a long value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to longs. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of longs representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<long>? ToLongs(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToLong(dfltVal));

    /// <summary>
    /// Converts a collection (ICollection) of objects to their respective long (Int64) values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a long value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be converted to longs. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of longs representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<long>? ToLongs(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToLong(dfltVal));

    /// <summary>
    /// Converts an array of objects to their respective long (Int64) values.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the array is converted to a long value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The array of objects to be converted to longs. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An array of longs representing the converted values, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<long>? ToLongs(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToLong(dfltVal));

    /// <summary>
    /// Generates a random long (Int64) value within the specified minimum and maximum bounds.
    /// If the minimum or maximum values are invalid or unspecified, defaults to the minimum and maximum limits of a long.
    /// If the minimum value is greater than the maximum, returns the default long value.
    /// </summary>
    /// <param name="min">The minimum bound for the long value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the long value. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated long value within the specified bounds, or the default value of a long if bounds are invalid.</returns>
    public static long GenerateRandomLong(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? long.MinValue : min.ToLong();
        var maxValue = max.IsNull() ? long.MaxValue : max.ToLong();

        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue);
    }

    /// <summary>
    /// Generates a collection of random long values within specified minimum and maximum bounds, and of a specified size.
    /// If the minimum or maximum values are invalid or unspecified, uses the minimum and maximum limits of a long.
    /// If the size is unspecified, defaults to a collection of size 0.
    /// </summary>
    /// <param name="min">The minimum bound for the long values. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the long values. Can be <see langword="null"/>.</param>
    /// <param name="size">The number of random long values to generate. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated long values within the specified bounds and of the specified size.</returns>
    public static IEnumerable<long> GenerateRandomLongs(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomLong(min, max));
}
