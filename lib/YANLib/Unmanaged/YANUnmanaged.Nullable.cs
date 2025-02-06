using YANLib.Object;
using YANLib.Text;
using static System.DateTime;
using static System.Nullable;
using static System.Convert;

namespace YANLib.Unmanaged;

public static partial class YANUnmanaged
{
    #region Private
    private static DateTime ParseDateTime(this string? input) => input.IsNullWhiteSpace() ? default : TryParse(input, out var dt) ? dt : default;

    private static DateTime? ParseDateTimeNullable (this string? input) => input.IsNullWhiteSpace() ? default : TryParse(input, out var dt) ? dt : default(DateTime?);
    #endregion

    /// <summary>
    /// Parses an input object to a value of type <typeparamref name="T"/>.
    /// Supports parsing for common types such as <see cref="string"/>, <see cref="DateTime"/>, nullable <see cref="DateTime"/>, <see cref="Guid"/>, and nullable <see cref="Guid"/>.
    /// For other types, attempts to convert the input using the underlying type or specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the input object is parsed.</typeparam>
    /// <param name="input">The input object to parse. Can be <see langword="null"/>.</param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or <see langword="null"/> if parsing fails or the input is <see langword="null"/>.</returns>
    public static T? Parse<T>(this object? input)
    {
        if (typeof(T) == typeof(string))
        {
            return (T?)(object?)(input?.ToString() ?? default);
        }

        if (typeof(T) == typeof(DateTime))
        {
            return (T)(object)(input?.ToString() ?? default).ParseDateTime();
        }
        
        if (typeof(T) == typeof(DateTime?))
        {
            return (T?)(object?)(input?.ToString() ?? default).ParseDateTimeNullable();
        }

        if (typeof(T) == typeof(Guid))
        {
            return Guid.TryParse(input?.ToString(), out var guidValue) ? (T)(object)guidValue : default;
        }
        
        if (typeof(T) == typeof(Guid?))
        {
            return Guid.TryParse(input?.ToString(), out var guidValue) ? (T?)(object?)guidValue : default;
        }

        if (GetUnderlyingType(typeof(T)) is Type underlyingType)
        {
            try
            {
                return input.IsNull() ? default : (T?)ChangeType(input, underlyingType);
            }
            catch
            {
                return default;
            }
        }

        try
        {
            return input.IsNull() ? default : (T)ChangeType(input, typeof(T));
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Parses a collection of input objects to a collection of values of type <typeparamref name="T"/>.
    /// For each object, supports parsing for common types such as <see cref="string"/>, <see cref="DateTime"/>, nullable <see cref="DateTime"/>, <see cref="Guid"/>, and nullable <see cref="Guid"/>.
    /// For other types, attempts to convert the input using the underlying type or specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the input objects are parsed.</typeparam>
    /// <param name="input">The collection of input objects to parse. Can be <see langword="null"/> or empty.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>.
    /// Returns <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T?>? Parses<T>(this IEnumerable<object?>? input) => input.IsNullEmpty() ? default : input.Select(x => x.Parse<T?>());

    /// <summary>
    /// Parses a collection of input objects (as parameters) to a collection of values of type <typeparamref name="T"/>.
    /// For each object, supports parsing for common types such as <see cref="string"/>, <see cref="DateTime"/>, nullable <see cref="DateTime"/>, <see cref="Guid"/>, and nullable <see cref="Guid"/>.
    /// For other types, attempts to convert the input using the underlying type or specified type.
    /// </summary>
    /// <typeparam name="T">The type to which the input objects are parsed.</typeparam>
    /// <param name="input">The collection of input objects as parameters. Can be <see langword="null"/> or empty.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>.
    /// Returns <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>

    public static IEnumerable<T?>? Parses<T>(params object?[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.Parse<T?>());
}
