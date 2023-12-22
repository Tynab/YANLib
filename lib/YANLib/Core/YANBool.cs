using static System.Linq.Enumerable;
using static YANLib.Core.YANNum;

namespace YANLib.Core;

public static partial class YANBool
{
    /// <summary>
    /// Converts the specified object to its <see cref="bool"/> equivalent.
    /// Returns the resulting <see cref="bool"/> object if the conversion is successful, otherwise returns the default value if provided, or false.
    /// </summary>
    /// <param name="val">The object to be converted to <see cref="bool"/>.</param>
    /// <param name="dfltVal">The default value to return if the conversion fails. If not provided, defaults to false.</param>
    /// <returns>The <see cref="bool"/> equivalent of the input object, or the specified default value if the conversion fails.</returns>
    public static bool ToBool(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToBoolean(val);
        }
        catch
        {
            return dfltVal.IsNotNull() && dfltVal.ToBool();
        }
    }

    /// <summary>
    /// Converts a collection of objects to an enumerable collection of <see cref="bool"/> values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is attempted to be converted to a <see cref="bool"/>. If the conversion fails, the specified default value is used.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to <see cref="bool"/> values. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if the conversion of an object fails. Can be <see langword="null"/>, resulting in a default value of false.</param>
    /// <returns>An enumerable collection of <see cref="bool"/> values, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<bool>? ToBools(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToBool(dfltVal));

    /// <summary>
    /// Converts a collection (ICollection) of objects to an enumerable collection of <see cref="bool"/> values.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is attempted to be converted to a <see cref="bool"/>. If the conversion fails, the specified default value is used.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be converted to <see cref="bool"/> values. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if the conversion of an object fails. Can be <see langword="null"/>, resulting in a default value of false.</param>
    /// <returns>An enumerable collection of <see cref="bool"/> values, or <see langword="null"/> if the input ICollection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<bool>? ToBools(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToBool(dfltVal));

    /// <summary>
    /// Converts an array of objects to an enumerable collection of <see cref="bool"/> values.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the array is attempted to be converted to a <see cref="bool"/>. If the conversion fails, the specified default value is used.
    /// </summary>
    /// <param name="vals">The array of objects to be converted to <see cref="bool"/> values. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if the conversion of an object fails. Can be <see langword="null"/>, resulting in a default value of false.</param>
    /// <returns>An enumerable collection of <see cref="bool"/> values, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<bool>? ToBools(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToBool(dfltVal));

    /// <summary>
    /// Generates a random <see cref="bool"/> value.
    /// The method randomly chooses between true and false.
    /// </summary>
    /// <returns>A randomly generated <see cref="bool"/> value.</returns>
    public static bool GenerateRandomBool() => GenerateRandomByte(0, 2) is 1;

    /// <summary>
    /// Generates a collection of random <see cref="bool"/> values of the specified size.
    /// The size is determined by converting the provided object to an unsigned integer. 
    /// If the conversion results in a negative value or <see langword="null"/>, it defaults to 0, resulting in no generated values.
    /// </summary>
    /// <param name="size">The object representing the number of random <see cref="bool"/> values to generate. If <see langword="null"/> or not convertible to a non-negative integer, defaults to a size of 0.</param>
    /// <returns>An enumerable collection of randomly generated <see cref="bool"/> values.</returns>
    public static IEnumerable<bool> GenerateRandomBools(object? size) => Range(0, (int)size.ToUint()).Select(i => GenerateRandomBool());
}
