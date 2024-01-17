using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified object to a signed byte (sbyte) value.
    /// If the conversion fails, attempts to use the provided default value for conversion.
    /// If both conversions fail, returns the default value of a signed byte.
    /// </summary>
    /// <param name="val">The object to be converted to a signed byte. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>The signed byte value of the converted object, or the converted default value, or the default value of a signed byte if both conversions fail.</returns>
    public static sbyte ToSbyte(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToSByte(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToSbyte();
        }
    }

    /// <summary>
    /// Converts a collection of objects to their respective signed byte (sbyte) values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a signed byte; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to signed bytes. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of signed bytes representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<sbyte>? ToSbytes(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToSbyte(dfltVal));

    /// <summary>
    /// Converts a collection (ICollection) of objects to their respective signed byte (sbyte) values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a signed byte; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be converted to signed bytes. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of signed bytes representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<sbyte>? ToSbytes(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToSbyte(dfltVal));

    /// <summary>
    /// Converts an array of objects to their respective signed byte (sbyte) values.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the array is converted to a signed byte; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The array of objects to be converted to signed bytes. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An array of signed bytes representing the converted values, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<sbyte>? ToSbytes(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToSbyte(dfltVal));

    /// <summary>
    /// Generates a random signed byte (sbyte) value within the specified minimum and maximum bounds.
    /// If the minimum or maximum values are invalid or unspecified, defaults to the minimum and maximum limits of a signed byte.
    /// If the minimum value is greater than the maximum, returns the default signed byte value.
    /// </summary>
    /// <param name="min">The minimum bound for the signed byte value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the signed byte value. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated signed byte value within the specified bounds, or the default value of a signed byte if bounds are invalid.</returns>
    public static sbyte GenerateRandomSbyte(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? sbyte.MinValue : min.ToSbyte();
        var maxValue = max.IsNull() ? sbyte.MaxValue : max.ToSbyte();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToSbyte();
    }

    /// <summary>
    /// Generates a collection of random signed byte values within specified minimum and maximum bounds, and of a specified size.
    /// If the minimum or maximum values are invalid or unspecified, uses the minimum and maximum limits of a signed byte.
    /// If the size is unspecified, defaults to a collection of size 0.
    /// </summary>
    /// <param name="min">The minimum bound for the signed byte values. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the signed byte values. Can be <see langword="null"/>.</param>
    /// <param name="size">The number of random signed byte values to generate. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated signed byte values within the specified bounds and of the specified size.</returns>
    public static IEnumerable<sbyte> GenerateRandomSbytes(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomSbyte(min, max));
}
