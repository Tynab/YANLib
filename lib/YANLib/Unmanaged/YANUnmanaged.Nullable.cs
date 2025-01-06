using YANLib.Object;
using YANLib.Text;
using static System.DateTime;

namespace YANLib.Unmanaged;

public static partial class YANUnmanaged
{
    private static DateTime ParseDateTime(this string? input) => input.IsNullWhiteSpace() ? default : TryParse(input, out var dt) ? dt : default;

    public static T? Parse<T>(this object? input)
    {
        if (typeof(T) == typeof(string))
        {
            return (T?)(object?)(input?.ToString() ?? default);
        }

        if (typeof(T) == typeof(DateTime))
        {
            return (T?)(object?)(input?.ToString() ?? default).ParseDateTime();
        }

        try
        {
            return input.IsNull() ? default : (T?)Convert.ChangeType(input, typeof(T?));
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<T?>? Parses<T>(this IEnumerable<object?>? input) => input.IsNullEmpty() ? default : input.Select(x => x.Parse<T?>());

    public static IEnumerable<T?>? Parses<T>(this ICollection<object?>? input) => input.IsNullEmpty() ? default : input.Select(x => x.Parse<T?>());

    public static IEnumerable<T?>? Parses<T>(this object?[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.Parse<T?>());
}
