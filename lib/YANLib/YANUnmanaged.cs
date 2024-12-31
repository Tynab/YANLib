using YANLib.Core;

namespace YANLib;

public static partial class YANUnmanaged
{
    public static T To<T>(this object? input, object? defaultValue = null) where T : unmanaged
    {
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

    public static IEnumerable<T>? Tos<T>(this IEnumerable<object?>? input, object? defaultValue = null) where T : unmanaged => input.IsEmptyOrNull() ? default : input.Select(x => x.To<T>(defaultValue));

    public static IEnumerable<T>? Tos<T>(this ICollection<object?>? input, object? defaultValue = null) where T : unmanaged => input.IsEmptyOrNull() ? default : input.Select(x => x.To<T>(defaultValue));

    public static IEnumerable<T>? Tos<T>(this object?[]? input, object? defaultValue = null) where T : unmanaged => input.IsEmptyOrNull() ? default : input.Select(x => x.To<T>(defaultValue));
}
