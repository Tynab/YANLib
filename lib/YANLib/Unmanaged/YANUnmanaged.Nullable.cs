using YANLib.Object;
using YANLib.Text;
using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;

namespace YANLib.Unmanaged;

public static partial class YANUnmanaged
{
    private static DateTime ToDateTime(this string? input) => input.IsNullOWhiteSpace() ? default : TryParse(input, out var dt) ? dt : default;

    public static T? To<T>(this object? input)
    {
        if (typeof(T) == typeof(string))
        {
            return (T?)(object?)(input?.ToString() ?? default);
        }

        if (typeof(T) == typeof(DateTime))
        {
            return (T?)(object?)(input?.ToString() ?? default).ToDateTime();
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

    public static IEnumerable<T?>? Tos<T>(this IEnumerable<object?>? input) => input.IsNullOEmpty() ? default : input.Select(x => x.To<T?>());

    public static IEnumerable<T?>? Tos<T>(this ICollection<object?>? input) => input.IsNullOEmpty() ? default : input.Select(x => x.To<T?>());

    public static IEnumerable<T?>? Tos<T>(this object?[]? input) => input.IsNullOEmpty() ? default : input.Select(x => x.To<T?>());
}
