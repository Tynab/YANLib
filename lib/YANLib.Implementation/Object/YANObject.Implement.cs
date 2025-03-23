using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using static System.Reflection.BindingFlags;

namespace YANLib.Implementation.Object;

internal static partial class YANObject
{
    #region Private
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();

    private static PropertyInfo[] GetCachedProperties(Type type) => PropertyCache.GetOrAdd(type, t => t.GetProperties(Public | Instance | DeclaredOnly));
    #endregion

    #region Is
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullImplement([NotNullWhen(false)] this object? input) => input is null;

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullImplement([NotNullWhen(true)] this object? input) => input is not null;

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullEmptyImplement<T>([NotNullWhen(false)] this IEnumerable<T>? input) => input.IsNullImplement() || !input.Any();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullEmptyImplement<T>([NotNullWhen(true)] this IEnumerable<T>? input) => input.IsNotNullImplement() && input.Any();
    #endregion

    #region All
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotNullImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotNullImplement() && x.AnyPropertiesNotDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNullImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNullImplement() || x.AllPropertiesDefaultImplement());
    #endregion

    #region Any
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNullImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNullImplement() || x.AllPropertiesDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotNullImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotNullImplement() || x.AnyPropertiesNotDefaultImplement());
    #endregion

    #region DateTimeZone
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ChangeTimeZoneAllPropertyImplement<T>(this T? input, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (input.IsNullImplement())
        {
            return input;
        }

        if (input is IList list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].IsNotNullImplement())
                {
                    var updatedItem = list[i].ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst);

                    if (updatedItem.IsNotNullImplement())
                    {
                        list[i] = updatedItem;
                    }
                }
            }

            return input;
        }

        var props = input.GetType().GetProperties(Public | Instance).Where(x => x.CanRead && x.CanWrite);

        foreach (var prop in props)
        {
            if (prop.IsNullImplement())
            {
                continue;
            }

            var val = prop.GetValue(input);

            if (val.IsNullImplement())
            {
                continue;
            }

            if (val is DateTime dt)
            {
                prop.SetValue(input, dt.ChangeTimeZoneImplement(tzSrc, tzDst));
            }
            else
            {
                var updated = val.ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst);

                if (updated.IsNotNullImplement())
                {
                    prop.SetValue(input, updated);
                }
            }
        }

        return input;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ChangeTimeZoneAllPropertiesImplement<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) where T : class => input.IsNullEmptyImplement()
            ? input
            : input is ICollection<T?> collection && collection.Count >= 1_000 || input is T?[] array && array.Length >= 1_000
            ? input.AsParallel().Select(x => x.ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst))
            : input.Select(x => x.ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst));
    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T CopyImplement<T>(this T input) where T : new()
    {
        if (input.IsNullImplement())
        {
            return input;
        }

        var result = new T();
        var props = input.GetType().GetProperties(Public | Instance);

        foreach (var prop in props)
        {
            if (prop.CanRead && prop.CanWrite)
            {
                var val = prop.GetValue(input);

                prop.SetValue(result, val);
            }
        }

        return result;
    }
}
