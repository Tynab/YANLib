
namespace YANLib.Implementation;

internal static partial class YANObject
{
    #region Null

    internal static bool AllNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x is not null);

    internal static bool AnyNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x is null);

    internal static bool AllNotNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x is null);

    internal static bool AnyNotNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x is not null);

    #endregion

    #region Default

    internal static bool AllDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotDefaultImplement());

    internal static bool AnyDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsDefaultImplement());

    internal static bool AllNotDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsDefaultImplement());

    internal static bool AnyNotDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotDefaultImplement());

    #endregion

    #region NullDefault

    internal static bool AllNullDefaultImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AllNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotNullDefaultImplement());

    internal static bool AnyNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AnyNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNullDefaultImplement());

    internal static bool AllNotNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AllNotNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNullDefaultImplement());

    internal static bool AnyNotNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AnyNotNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotNullDefaultImplement());

    #endregion

    internal static IEnumerable<T?>? ChangeTimeZoneAllPropertiesImplement<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) where T : class
    {
        var items = input?.ToArray();

        if (items is null || items.Length is 0)
        {
            return input;
        }

        // One visited set for the whole call: an object shared by several elements (or listed twice) is converted once.
        // Each element's graph is finished before the next element starts, so the elements are converted in input order.
        var visited = new HashSet<object>(ReferenceEqualityComparer.Instance);
        var pending = new List<TimeZoneNode>();

        foreach (var item in items)
        {
            if (item is not null)
            {
                ChangeTimeZoneRoot(item, tzSrc, tzDst, visited, pending);
            }
        }

        return items;
    }
}
