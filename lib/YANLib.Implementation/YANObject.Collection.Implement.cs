using System.Diagnostics;

namespace YANLib.Implementation;

internal static partial class YANObject
{
    #region Null

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x is not null);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x is null);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x is null);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x is not null);

    #endregion

    #region Default

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotDefaultImplement());

    #endregion

    #region NullDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullDefaultImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AllNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotNullDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AnyNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNullDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AllNotNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNullDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AnyNotNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotNullDefaultImplement());

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ChangeTimeZoneAllPropertiesImplement<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) where T : class
    {
        var items = input?.ToArray();

        if (items is null || items.Length is 0)
        {
            return input;
        }

        // One visited set for the whole call: an object shared by several elements (or listed twice) is converted once.
        var visited = new HashSet<object>(ReferenceEqualityComparer.Instance);

        foreach (var item in items)
        {
            if (item is not null)
            {
                _ = ChangeTimeZoneGraph(item, tzSrc, tzDst, visited);
            }
        }

        return items;
    }
}
