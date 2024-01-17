using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified object to an integer value.
    /// If the conversion fails, attempts to use the provided default value for conversion.
    /// If both conversions fail, returns the default value of an integer.
    /// </summary>
    /// <param name="val">The object to be converted to an integer. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>The integer value of the converted object, or the converted default value, or the default value of an integer if both conversions fail.</returns>
    public static int ToInt(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt32(val.ToDecimal());
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToInt();
        }
    }

    /// <summary>
    /// Converts a collection of objects to their respective integer values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to an integer value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to integers. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? ToInts(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToInt(dfltVal));

    /// <summary>
    /// Converts a collection (ICollection) of objects to their respective integer values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to an integer value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be converted to integers. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of integers representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? ToInts(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToInt(dfltVal));

    /// <summary>
    /// Converts an array of objects to their respective integer values.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the array is converted to an integer value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The array of objects to be converted to integers. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An array of integers representing the converted values, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<int>? ToInts(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToInt(dfltVal));

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
