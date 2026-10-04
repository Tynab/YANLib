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
        if (input is null)
        {
            return input;
        }

        var list = input as IList<T?> ?? [.. input];

        // One identity set for the whole call, seeded with the list so an item pointing back at it neither recurses into it nor writes into it
        var visited = new HashSet<object>(ReferenceEqualityComparer.Instance) { list };
        var isReadOnly = IsReadOnlyList(list);

        for (var i = 0; i < list.Count; i++)
        {
            if (list[i] is not { } item || (isReadOnly && item is ValueType))
            {
                continue;
            }

            object value = item;

            // only a boxed DateTime or struct item needs to be written back
            if (ChangeTimeZoneAllPropertyHelper(ref value, tzSrc, tzDst, visited) && !isReadOnly)
            {
                list[i] = (T)value;
            }
        }

        return list;
    }
}
