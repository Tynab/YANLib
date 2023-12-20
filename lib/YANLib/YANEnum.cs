using static System.Enum;

namespace YANLib;

public static partial class YANEnum
{
    /// <summary>
    /// Converts the specified string to its enumeration equivalent of type <typeparamref name="T"/>.
    /// If the string is null, white-space, or does not correspond to an enumeration value of type <typeparamref name="T"/>, returns the default value of <typeparamref name="T"/>.
    /// </summary>
    /// <param name="val">The string to be converted to an enumeration value of type <typeparamref name="T"/>. Can be <see langword="null"/>.</param>
    /// <returns>The enumeration value of type <typeparamref name="T"/> represented by the string, or the default value of <typeparamref name="T"/> if the conversion fails.</returns>
    public static T? ToEnum<T>(this string? val) where T : struct => val.IsWhiteSpaceOrNull() ? default : TryParse<T>(val, out var result) ? result : default;

    /// <summary>
    /// Converts a collection of strings to an enumerable collection of enumeration values of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, or any string does not correspond to an enumeration value of type <typeparamref name="T"/>, returns <see langword="null"/> for those items.
    /// </summary>
    /// <param name="vals">The collection of strings to be converted to enumeration values of type <typeparamref name="T"/>. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of enumeration values of type <typeparamref name="T"/>, or <see langword="null"/> for any string that does not correspond to a valid enumeration value.</returns>
    public static IEnumerable<T?>? ToEnums<T>(this IEnumerable<string?>? vals) where T : struct => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToEnum<T>());

    /// <summary>
    /// Converts a collection (ICollection) of strings to an enumerable collection of enumeration values of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, or any string does not correspond to an enumeration value of type <typeparamref name="T"/>, returns <see langword="null"/> for those items.
    /// </summary>
    /// <param name="vals">The ICollection of strings to be converted to enumeration values of type <typeparamref name="T"/>. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of enumeration values of type <typeparamref name="T"/>, or <see langword="null"/> for any string that does not correspond to a valid enumeration value.</returns>
    public static IEnumerable<T?>? ToEnums<T>(this ICollection<string?>? vals) where T : struct => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToEnum<T>());

    /// <summary>
    /// Converts an array of strings to an enumerable collection of enumeration values of type <typeparamref name="T"/>.
    /// If the array is <see langword="null"/> or empty, or any string does not correspond to an enumeration value of type <typeparamref name="T"/>, returns <see langword="null"/> for those items.
    /// </summary>
    /// <param name="vals">The array of strings to be converted to enumeration values of type <typeparamref name="T"/>. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of enumeration values of type <typeparamref name="T"/>, or <see langword="null"/> for any string that does not correspond to a valid enumeration value.</returns>
    public static IEnumerable<T?>? ToEnums<T>(this string?[]? vals) where T : struct => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToEnum<T>());
}
