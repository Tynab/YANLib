using YANLib.Object;
using YANLib.Text;
using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;

namespace YANLib.Unmanaged;

public static partial class YANUnmanaged
{
    private static DateTime ToDateTime(this string? input, DateTime defaultValue = default, IEnumerable<string?>? format = null) => input.IsNullOWhiteSpace()
        ? defaultValue
        : format.IsNullOEmpty()
        ? TryParse(input, out var dt)
            ? dt
            : defaultValue
        : TryParseExact(input, format.ToArray(), InvariantCulture, None, out dt)
        ? dt
        : defaultValue;

    private static DateTime ToDateTime(this string? input, DateTime defaultValue = default, ICollection<string?>? format = null) => input.IsNullOWhiteSpace()
        ? defaultValue
        : format.IsNullOEmpty()
        ? TryParse(input, out var dt)
            ? dt
            : defaultValue
        : TryParseExact(input, [.. format], InvariantCulture, None, out dt)
        ? dt
        : defaultValue;

    private static DateTime ToDateTime(this string? input, DateTime defaultValue = default, params string?[]? format) => input.IsNullOWhiteSpace()
        ? defaultValue
        : format.IsNullOEmpty()
        ? TryParse(input, out var dt)
            ? dt
            : defaultValue
        : TryParseExact(input, format, InvariantCulture, None, out dt)
        ? dt
        : defaultValue;

    public static T To<T>(this object? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
    {
        if (typeof(T) == typeof(DateTime))
        {
            return (T)(object)(input?.ToString() ?? default).ToDateTime((defaultValue?.ToString() ?? default).ToDateTime(default, format), format);
        }

        try
        {
            return input.IsNull() ? defaultValue.IsNull() ? default : (T)Convert.ChangeType(defaultValue, typeof(T)) : (T)Convert.ChangeType(input, typeof(T));
        }
        catch
        {
            try
            {
                return defaultValue.IsNull() ? default : (T)Convert.ChangeType(defaultValue, typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }

    public static T To<T>(this object? input, object? defaultValue = null, ICollection<string?>? format = null) where T : unmanaged
    {
        if (typeof(T) == typeof(DateTime))
        {
            return (T)(object)(input?.ToString() ?? default).ToDateTime((defaultValue?.ToString() ?? default).ToDateTime(default, format), format);
        }

        try
        {
            return input.IsNull() ? defaultValue.IsNull() ? default : (T)Convert.ChangeType(defaultValue, typeof(T)) : (T)Convert.ChangeType(input, typeof(T));
        }
        catch
        {
            try
            {
                return defaultValue.IsNull() ? default : (T)Convert.ChangeType(defaultValue, typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }

    public static T To<T>(this object? input, object? defaultValue = null, params string?[]? format) where T : unmanaged
    {
        if (typeof(T) == typeof(DateTime))
        {
            return (T)(object)(input?.ToString() ?? default).ToDateTime((defaultValue?.ToString() ?? default).ToDateTime(format: format), format);
        }

        try
        {
            return input.IsNull() ? defaultValue.IsNull() ? default : (T)Convert.ChangeType(defaultValue, typeof(T)) : (T)Convert.ChangeType(input, typeof(T));
        }
        catch
        {
            try
            {
                return defaultValue.IsNull() ? default : (T)Convert.ChangeType(defaultValue, typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }

    public static IEnumerable<T>? Tos<T>(this IEnumerable<object?>? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => input.IsNullOEmpty() ? default : input.Select(x => x.To<T>(defaultValue, format));

    public static IEnumerable<T>? Tos<T>(this ICollection<object?>? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => input.IsNullOEmpty() ? default : input.Select(x => x.To<T>(defaultValue, format));

    public static IEnumerable<T>? Tos<T>(this object?[]? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => input.IsNullOEmpty() ? default : input.Select(x => x.To<T>(defaultValue, format));

    public static IEnumerable<T>? Tos<T>(this IEnumerable<object?>? input, object? defaultValue = null, ICollection<string?>? format = null) where T : unmanaged
        => input.IsNullOEmpty() ? default : input.Select(x => x.To<T>(defaultValue, format));

    public static IEnumerable<T>? Tos<T>(this ICollection<object?>? input, object? defaultValue = null, ICollection<string?>? format = null) where T : unmanaged
        => input.IsNullOEmpty() ? default : input.Select(x => x.To<T>(defaultValue, format));

    public static IEnumerable<T>? Tos<T>(this object?[]? input, object? defaultValue = null, ICollection<string?>? format = null) where T : unmanaged
        => input.IsNullOEmpty() ? default : input.Select(x => x.To<T>(defaultValue, format));

    public static IEnumerable<T>? Tos<T>(this IEnumerable<object?>? input, object? defaultValue = null, params string?[]? format) where T : unmanaged
        => input.IsNullOEmpty() ? default : input.Select(x => x.To<T>(defaultValue, format));

    public static IEnumerable<T>? Tos<T>(this ICollection<object?>? input, object? defaultValue = null, params string?[]? format) where T : unmanaged
        => input.IsNullOEmpty() ? default : input.Select(x => x.To<T>(defaultValue, format));

    public static IEnumerable<T>? Tos<T>(this object?[]? input, object? defaultValue = null, params string?[]? format) where T : unmanaged
        => input.IsNullOEmpty() ? default : input.Select(x => x.To<T>(defaultValue, format));
}
