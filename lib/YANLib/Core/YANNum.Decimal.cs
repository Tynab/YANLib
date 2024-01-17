using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified object to a decimal value.
    /// If the conversion fails, attempts to use the provided default value for conversion.
    /// If both conversions fail, returns the default value of a decimal.
    /// </summary>
    /// <param name="val">The object to be converted to a decimal. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>The decimal value of the converted object, or the converted default value, or the default value of a decimal if both conversions fail.</returns>
    public static decimal ToDecimal(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToDecimal(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToDecimal();
        }
    }

    /// <summary>
    /// Converts a collection of objects to their respective decimal values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a decimal value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to decimals. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of decimals representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<decimal>? ToDecimals(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDecimal(dfltVal));

    /// <summary>
    /// Converts a collection (ICollection) of objects to their respective decimal values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a decimal value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be converted to decimals. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of decimals representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<decimal>? ToDecimals(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDecimal(dfltVal));

    /// <summary>
    /// Converts an array of objects to their respective decimal values.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the array is converted to a decimal value; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The array of objects to be converted to decimals. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An array of decimals representing the converted values, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<decimal>? ToDecimals(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDecimal(dfltVal));

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
    public static IEnumerable<decimal> GenerateRandomDecimals(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDecimal(min, max));
}
