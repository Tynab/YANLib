using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified object to a native integer (nint) value.
    /// If the conversion fails, attempts to use the provided default value for conversion.
    /// If both conversions fail, returns the default value of a native integer.
    /// </summary>
    /// <param name="val">The object to be converted to a native integer. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>The native integer value of the converted object, or the converted default value, or the default value of a native integer if both conversions fail.</returns>
    public static nint ToNint(this object? val, object? dfltVal = null)
    {
        try
        {
            return new IntPtr(Convert.ToInt64(val));
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToNint();
        }
    }

    /// <summary>
    /// Converts a collection of objects to their respective native integer (nint) values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a native integer; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to native integers. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of native integers representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<nint>? ToNints(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNint(dfltVal));

    /// <summary>
    /// Converts a collection (ICollection) of objects to their respective native integer (nint) values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a native integer; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be converted to native integers. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of native integers representing the converted values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<nint>? ToNints(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNint(dfltVal));

    /// <summary>
    /// Converts an array of objects to their respective native integer (nint) values.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the array is converted to a native integer; if conversion fails, uses the provided default value.
    /// </summary>
    /// <param name="vals">The array of objects to be converted to native integers. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An array of native integers representing the converted values, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<nint>? ToNints(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNint(dfltVal));

    /// <summary>
    /// Generates a random native integer (nint) value within the specified minimum and maximum bounds.
    /// If the minimum or maximum values are invalid or unspecified, defaults to the minimum and maximum limits of a native integer.
    /// If the minimum value is greater than the maximum, returns the default native integer value.
    /// </summary>
    /// <param name="min">The minimum bound for the native integer value. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the native integer value. Can be <see langword="null"/>.</param>
    /// <returns>A randomly generated native integer value within the specified bounds, or the default value of a native integer if bounds are invalid.</returns>
    public static nint GenerateRandomNint(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? nint.MinValue : min.ToNint();
        var maxValue = max.IsNull() ? nint.MaxValue : max.ToNint();

        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue).ToNint();
    }

    /// <summary>
    /// Generates a collection of random native integer values within specified minimum and maximum bounds, and of a specified size.
    /// If the minimum or maximum values are invalid or unspecified, uses the minimum and maximum limits of a native integer.
    /// If the size is unspecified, defaults to a collection of size 0.
    /// </summary>
    /// <param name="min">The minimum bound for the native integer values. Can be <see langword="null"/>.</param>
    /// <param name="max">The maximum bound for the native integer values. Can be <see langword="null"/>.</param>
    /// <param name="size">The number of random native integer values to generate. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of randomly generated native integer values within the specified bounds and of the specified size.</returns>
    public static IEnumerable<nint> GenerateRandomNints(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomNint(min, max));
}
