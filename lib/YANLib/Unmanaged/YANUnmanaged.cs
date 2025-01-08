using YANLib.Object;
using YANLib.Text;
using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;
using static System.Convert;

namespace YANLib.Unmanaged;

public static partial class YANUnmanaged
{
    private static DateTime ParseDateTime(this string? input, DateTime defaultValue = default, IEnumerable<string?>? format = null) => input.IsNullWhiteSpace()
        ? defaultValue
        : format.IsNullEmpty()
        ? TryParse(input, out var dt)
            ? dt
            : defaultValue
        : TryParseExact(input, format.ToArray(), InvariantCulture, None, out dt)
        ? dt
        : defaultValue;

    public static T Parse<T>(this object? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
    {
        if (typeof(T) == typeof(DateTime))
        {
            return (T)(object)(input?.ToString() ?? default).ParseDateTime((defaultValue?.ToString() ?? default).ParseDateTime(default, format), format);
        }

        try
        {
            return input.IsNull() ? defaultValue.IsNull() ? default : (T)ChangeType(defaultValue, typeof(T)) : (T)ChangeType(input, typeof(T));
        }
        catch
        {
            try
            {
                return defaultValue.IsNull() ? default : (T)ChangeType(defaultValue, typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }

    public static T Parse<T>(this object? input, object? defaultValue = null, params string?[]? format) where T : unmanaged
    {
        if (typeof(T) == typeof(DateTime))
        {
            return (T)(object)(input?.ToString() ?? default).ParseDateTime((defaultValue?.ToString() ?? default).ParseDateTime(default, format), format);
        }

        try
        {
            return input.IsNull() ? defaultValue.IsNull() ? default : (T)ChangeType(defaultValue, typeof(T)) : (T)ChangeType(input, typeof(T));
        }
        catch
        {
            try
            {
                return defaultValue.IsNull() ? default : (T)ChangeType(defaultValue, typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }

    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => input.IsNullEmpty() ? default : input.Select(x => x.Parse<T>(defaultValue, format));

    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, params string?[]? format) where T : unmanaged
        => input.IsNullEmpty() ? default : input.Select(x => x.Parse<T>(defaultValue, format));
}
