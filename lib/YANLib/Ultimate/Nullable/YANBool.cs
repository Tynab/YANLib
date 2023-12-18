namespace YANLib.Ultimate.Nullable;

public static partial class YANBool
{
    /// <summary>
    /// Converts a collection of objects to an enumerable collection of nullable <see cref="bool"/> values.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each object in the collection is attempted to be converted to a <see cref="bool"/>. If the conversion fails, the specified default value is used.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to nullable <see cref="bool"/> values. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to use if the conversion of an object fails. Can be <see langword="null"/>, resulting in a default value of <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable <see cref="bool"/> values, each representing the converted equivalent of an element in the input collection or the specified default value if the conversion fails.</returns>
    public static IEnumerable<bool?> ToBools(this IEnumerable<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANBool.ToBool(val, dfltVal);
        }
    }
}
