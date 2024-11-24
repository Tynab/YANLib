using static System.Enum;

namespace YANLib.Core;

public static partial class YANEnum
{
    /// <summary>
    /// Converts the specified string to its equivalent enumeration value of type <typeparamref name="T"/>.
    /// If the string is <see langword="null"/>, empty, or consists only of white-space characters, or if the conversion fails, returns the default value of the enum type.
    /// </summary>
    /// <typeparam name="T">The enum type to which the string is to be converted. Must be a struct type.</typeparam>
    /// <param name="val">The string to convert to an enum value. Can be <see langword="null"/> or white space.</param>
    /// <returns>
    /// The equivalent enumeration value of type <typeparamref name="T"/> if the conversion is successful, or the default value of the enum type if the conversion fails or the string is <see langword="null"/> or white space.
    /// </returns>
    public static T? ToEnumeration<T>(this string? val) where T : struct => val.IsWhiteSpaceOrNull() ? default : TryParse<T>(val, out var result) ? result : default;

    /// <summary>
    /// Converts a collection of strings to an enumerable collection of enumeration values of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, or any string does not correspond to an enumeration value of type <typeparamref name="T"/>, returns <see langword="null"/> for those items.
    /// </summary>
    /// <param name="vals">The collection of strings to be converted to enumeration values of type <typeparamref name="T"/>. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of enumeration values of type <typeparamref name="T"/>, or <see langword="null"/> for any string that does not correspond to a valid enumeration value.</returns>
    public static IEnumerable<T?>? ToEnumerations<T>(this IEnumerable<string?>? vals) where T : struct => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToEnumeration<T>());

    /// <summary>
    /// Converts a collection (ICollection) of strings to an enumerable collection of enumeration values of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, or any string does not correspond to an enumeration value of type <typeparamref name="T"/>, returns <see langword="null"/> for those items.
    /// </summary>
    /// <param name="vals">The ICollection of strings to be converted to enumeration values of type <typeparamref name="T"/>. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of enumeration values of type <typeparamref name="T"/>, or <see langword="null"/> for any string that does not correspond to a valid enumeration value.</returns>
    public static IEnumerable<T?>? ToEnumerations<T>(this ICollection<string?>? vals) where T : struct => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToEnumeration<T>());

    /// <summary>
    /// Converts an array of strings to an enumerable collection of enumeration values of type <typeparamref name="T"/>.
    /// If the array is <see langword="null"/> or empty, or any string does not correspond to an enumeration value of type <typeparamref name="T"/>, returns <see langword="null"/> for those items.
    /// </summary>
    /// <param name="vals">The array of strings to be converted to enumeration values of type <typeparamref name="T"/>. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of enumeration values of type <typeparamref name="T"/>, or <see langword="null"/> for any string that does not correspond to a valid enumeration value.</returns>
    public static IEnumerable<T?>? ToEnumerations<T>(params string?[]? vals) where T : struct => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToEnumeration<T>());
}
