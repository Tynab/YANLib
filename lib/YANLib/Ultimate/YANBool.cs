using static YANLib.YANBool;

namespace YANLib.Ultimate;

public static partial class YANBool
{
    /// <summary>
    /// Converts a collection of objects to an enumerable collection of <see cref="bool"/> values.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each object in the collection is attempted to be converted to a <see cref="bool"/>. If the conversion fails, the specified default value is used.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to <see cref="bool"/> values. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if the conversion of an object fails. Can be <see langword="null"/>, resulting in a default value of false.</param>
    /// <returns>An enumerable collection of <see cref="bool"/> values, each representing the converted equivalent of an element in the input collection or the specified default value if the conversion fails.</returns>
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
