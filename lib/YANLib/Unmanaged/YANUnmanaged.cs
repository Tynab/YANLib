using YANLib.Object;
using YANLib.Text;
using static System.Convert;
using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;
using static System.Nullable;

namespace YANLib.Unmanaged;

public static partial class YANUnmanaged
{
    #region Private
    private static readonly Dictionary<Type, Type?> UnderlyingTypeCache = [];

    private static DateTime ParseDateTime(this string? input, DateTime defaultValue = default, IEnumerable<string?>? format = null) => input.IsNullWhiteSpace()
        ? defaultValue
        : format.IsNullEmpty()
        ? TryParse(input, out var dt)
            ? dt
            : defaultValue
        : TryParseExact(input, [.. format], InvariantCulture, None, out dt)
        ? dt
        : defaultValue;

    private static DateTime ParseDateTime(this string? input) => input.IsNullWhiteSpace() ? default : TryParse(input, out var dt) ? dt : default;

    private static DateTime? ParseDateTimeNullable(this string? input) => input.IsNullWhiteSpace() ? default : TryParse(input, out var dt) ? dt : default(DateTime?);

    private static T ParseHelper<T>(object? input, object? defaultValue, IEnumerable<string?>? format) where T : unmanaged
    {
        if (typeof(T) == typeof(DateTime))
        {
            return (T)(object)(input?.ToString() ?? default).ParseDateTime((defaultValue?.ToString() ?? default).ParseDateTime(default, format), format);
        }

        if (input.IsNull())
        {
            if (defaultValue.IsNull())
            {
                return default;
            }

            try
            {
                return (T)ChangeType(defaultValue, typeof(T));
            }
            catch
            {
                return default;
            }
        }

        try
        {
            return (T)ChangeType(input, typeof(T));
        }
        catch
        {
            if (defaultValue.IsNull())
            {
                return default;
            }

            try
            {
                return (T)ChangeType(defaultValue, typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }

    private static Type? GetUnderlyingTypeCached(Type type)
    {
        if (!UnderlyingTypeCache.TryGetValue(type, out var underlyingType))
        {
            underlyingType = GetUnderlyingType(type);
            UnderlyingTypeCache[type] = underlyingType;
        }

        return underlyingType;
    }
    #endregion

    /// <summary>
    /// Parses an input object to a value of type <typeparamref name="T"/>.
    /// If the input is <see langword="null"/> or cannot be converted, returns the specified default value or the default value of <typeparamref name="T"/>.
    /// If the type is <see cref="DateTime"/>, uses the provided formats for parsing.
    /// </summary>
    /// <typeparam name="T">The type to which the input object is parsed. Must be an unmanaged type.</typeparam>
    /// <param name="input">The input object to parse. Can be <see langword="null"/>.</param>
    /// <param name="defaultValue">The default value to return if the input is <see langword="null"/> or cannot be converted. Can be <see langword="null"/>.</param>
    /// <param name="format">An optional enumerable collection of date and time formats to use if the type is <see cref="DateTime"/>. If <see langword="null"/>, uses the default format.</param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or the specified/default value if parsing fails.</returns>
    public static T Parse<T>(this object? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => ParseHelper<T>(input, defaultValue, format);

    /// <summary>
    /// Parses an input object to a value of type <typeparamref name="T"/>.
    /// If the input is <see langword="null"/> or cannot be converted, returns the specified default value or the default value of <typeparamref name="T"/>.
    /// If the type is <see cref="DateTime"/>, uses the provided formats for parsing.
    /// </summary>
    /// <typeparam name="T">The type to which the input object is parsed. Must be an unmanaged type.</typeparam>
    /// <param name="input">The input object to parse. Can be <see langword="null"/>.</param>
    /// <param name="defaultValue">The default value to return if the input is <see langword="null"/> or cannot be converted. Can be <see langword="null"/>.</param>
    /// <param name="format">An optional array of date and time formats to use if the type is <see cref="DateTime"/>. If <see langword="null"/>, uses the default format.</param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or the specified/default value if parsing fails.</returns>
    public static T Parse<T>(this object? input, object? defaultValue = null, params string?[]? format) where T : unmanaged
        => ParseHelper<T>(input, defaultValue, format);

    /// <summary>
    /// Parses a collection of input objects to a collection of values of type <typeparamref name="T"/>.
    /// If the input collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object is parsed using the specified default value and formats.
    /// </summary>
    /// <typeparam name="T">The type to which the input objects are parsed. Must be an unmanaged type.</typeparam>
    /// <param name="input">The collection of input objects to parse. Can be <see langword="null"/> or empty.</param>
    /// <param name="defaultValue">The default value to use for each object if it is <see langword="null"/> or cannot be converted. Can be <see langword="null"/>.</param>
    /// <param name="format">An optional enumerable collection of date and time formats to use if the type is <see cref="DateTime"/>. If <see langword="null"/>, uses the default format.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => input.IsNullEmpty() ? default : input.Select(x => x.Parse<T>(defaultValue, format));

    /// <summary>
    /// Parses a collection of input objects to a collection of values of type <typeparamref name="T"/>.
    /// If the input collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object is parsed using the specified default value and formats.
    /// </summary>
    /// <typeparam name="T">The type to which the input objects are parsed. Must be an unmanaged type.</typeparam>
    /// <param name="input">The collection of input objects to parse. Can be <see langword="null"/> or empty.</param>
    /// <param name="defaultValue">The default value to use for each object if it is <see langword="null"/> or cannot be converted. Can be <see langword="null"/>.</param>
    /// <param name="format">An optional array of date and time formats to use if the type is <see cref="DateTime"/>. If <see langword="null"/>, uses the default format.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, params string?[]? format) where T : unmanaged
        => input.IsNullEmpty() ? default : input.Select(x => x.Parse<T>(defaultValue, format));
}
