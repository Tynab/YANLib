using static System.Linq.Enumerable;
using static YANLib.YANNum;

namespace YANLib;

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
            return dfltVal is not null && dfltVal.ToBool();
        }
    }

    /// <summary>
    /// Converts a collection of objects to their <see cref="bool"/> equivalents.
    /// Returns an enumerable collection of <see cref="bool"/> objects for each successfully converted input object, and uses the specified default value or false for any objects that fail to convert.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to <see cref="bool"/>.</param>
    /// <param name="dfltVal">The default value to return for any objects that fail to convert. If not provided, defaults to false.</param>
    /// <returns>An enumerable collection of <see cref="bool"/> objects for each successfully converted input object, and the specified default value or false for any objects that fail to convert.</returns>
    public static IEnumerable<bool>? ToBools(this IEnumerable<object?> vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(n => n.ToBool(dfltVal));

    /// <summary>
    /// Generates a random <see cref="bool"/> value.
    /// </summary>
    /// <returns>A randomly generated <see cref="bool"/> value.</returns>
    public static bool GenerateRandomBool() => GenerateRandomByte(0, 2) is 1;

    /// <summary>
    /// Generates a collection of random <see cref="bool"/> values of the specified size.
    /// </summary>
    /// <param name="size">The number of random <see cref="bool"/> values to generate. If <see langword="null"/> or not convertible to a positive integer, defaults to a size of 0.</param>
    /// <returns>An enumerable collection of randomly generated <see cref="bool"/> values.</returns>
    public static IEnumerable<bool> GenerateRandomBools(object? size) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomBool());
}
