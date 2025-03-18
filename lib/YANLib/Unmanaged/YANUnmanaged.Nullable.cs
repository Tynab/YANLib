using YANLib.Object;
using YANLib.Text;
using static System.Convert;

namespace YANLib.Unmanaged;

public static partial class YANUnmanaged
{
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
        return input.IsNull() ? default : typeof(T) switch
        {
            Type stringType when stringType == typeof(string) => (T?)(object?)input.ToString(),
            Type dateTimeType when dateTimeType == typeof(DateTime) => (T)(object)input.ToString().ParseDateTime(),
            Type nullableDateTimeType when nullableDateTimeType == typeof(DateTime?) => (T?)(object?)input.ToString().ParseDateTimeNullable(),
            Type guidType when guidType == typeof(Guid) && Guid.TryParse(input.ToString(), out var guidValue) => (T)(object)guidValue,
            Type nullableGuidType when nullableGuidType == typeof(Guid?) && Guid.TryParse(input.ToString(), out var guidValue) => (T?)(object?)guidValue,
            _ => GetUnderlyingTypeCached(typeof(T)) is Type underlyingType ? ChangeTypeOrDefault(input, underlyingType) : ChangeTypeOrDefault(input, typeof(T))
        };

        static T? ChangeTypeOrDefault(object input, Type targetType)
        {
            try
            {
                return (T?)ChangeType(input, targetType);
            }
            catch
            {
                return default;
            }
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
