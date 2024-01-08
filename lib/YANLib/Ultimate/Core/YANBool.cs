using YANLib.Core;
using static YANLib.Core.YANBool;

namespace YANLib.Ultimate.Core;

public static partial class YANBool
{
    /// <summary>
    /// Converts a collection of objects to their respective <see cref="bool"/> equivalents, using a specified default value for conversions that fail.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each object in the collection is converted to a <see cref="bool"/> value; if conversion fails, the specified default value is used.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to <see cref="bool"/>. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="bool"/> values representing the converted results.</returns>
    public static IEnumerable<bool> ToBools(this IEnumerable<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToBool(dfltVal);
        }
    }

    /// <summary>
    /// Converts a collection (ICollection) of objects to their respective <see cref="bool"/> equivalents, using a specified default value for conversions that fail.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each object in the collection is converted to a <see cref="bool"/> value; if conversion fails, the specified default value is used.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be converted to <see cref="bool"/>. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="bool"/> values representing the converted results.</returns>
    public static IEnumerable<bool> ToBools(this ICollection<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToBool(dfltVal);
        }
    }

    /// <summary>
    /// Converts an array of objects to their respective <see cref="bool"/> equivalents, using a specified default value for conversions that fail.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each object in the array is converted to a <see cref="bool"/> value; if conversion fails, the specified default value is used.
    /// </summary>
    /// <param name="vals">The array of objects to be converted to <see cref="bool"/>. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if conversion fails. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of <see cref="bool"/> values representing the converted results.</returns>
    public static IEnumerable<bool> ToBools(this object?[]? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToBool(dfltVal);
        }
    }

    /// <summary>
    /// Generates a collection of random <see cref="bool"/> values of the specified size.
    /// </summary>
    /// <param name="size">The number of random <see cref="bool"/> values to generate. If <see langword="null"/> or not convertible to a positive integer, defaults to a size of 0.</param>
    /// <returns>An enumerable collection of randomly generated <see cref="bool"/> values.</returns>
    public static IEnumerable<bool> GenerateRandomBools(object? size)
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomBool();
        }
    }
}
