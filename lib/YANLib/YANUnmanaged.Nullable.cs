using YANLib.Core;

namespace YANLib;

public static partial class YANUnmanaged
{
    public static T? To<T>(this object? input)
    {
        if (typeof(T) == typeof(string))
        {
            return (T?)(object?)(input?.ToString() ?? default);
        }
        else
        {
            try
            {
                return input.IsNull() ? default : (T?)Convert.ChangeType(input, typeof(T?));
            }
            catch
            {
                return default;
            }
        }
    }

    public static IEnumerable<T?>? Tos<T>(this IEnumerable<object?>? input) => input.IsEmptyOrNull() ? default : input.Select(x => x.To<T?>());

    public static IEnumerable<T?>? Tos<T>(this ICollection<object?>? input) => input.IsEmptyOrNull() ? default : input.Select(x => x.To<T?>());

    public static IEnumerable<T?>? Tos<T>(this object?[]? input) => input.IsEmptyOrNull() ? default : input.Select(x => x.To<T?>());
}
