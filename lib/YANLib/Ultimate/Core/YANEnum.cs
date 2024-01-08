using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANEnum
{
    /// <summary>
    /// Converts a collection of strings to their respective enum values of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each string in the collection is attempted to be converted to an enum value of type <typeparamref name="T"/>; if conversion fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The enum type to which the strings are to be converted. Must be a value type.</typeparam>
    /// <param name="vals">The collection of strings to be converted to enum values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable enum values of type <typeparamref name="T"/>.</returns>
    public static IEnumerable<T?> ToEnums<T>(this IEnumerable<string?>? vals) where T : struct
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToEnum<T>();
        }
    }

    /// <summary>
    /// Converts a collection (ICollection) of strings to their respective enum values of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each string in the collection is attempted to be converted to an enum value of type <typeparamref name="T"/>; if conversion fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The enum type to which the strings are to be converted. Must be a value type.</typeparam>
    /// <param name="vals">The ICollection of strings to be converted to enum values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable enum values of type <typeparamref name="T"/>.</returns>
    public static IEnumerable<T?> ToEnums<T>(this ICollection<string?>? vals) where T : struct
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToEnum<T>();
        }
    }

    /// <summary>
    /// Converts an array of strings to their respective enum values of type <typeparamref name="T"/>.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each string in the array is attempted to be converted to an enum value of type <typeparamref name="T"/>; if conversion fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The enum type to which the strings are to be converted. Must be a value type.</typeparam>
    /// <param name="vals">The array of strings to be converted to enum values. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of nullable enum values of type <typeparamref name="T"/>.</returns>
    public static IEnumerable<T?> ToEnums<T>(this string?[]? vals) where T : struct
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToEnum<T>();
        }
    }
}
