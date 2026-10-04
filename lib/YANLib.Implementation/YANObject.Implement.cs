using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using static System.Reflection.BindingFlags;

namespace YANLib.Implementation;

internal static partial class YANObject
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();

    #region Private

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static PropertyInfo[] GetCachedProperties(Type type)
        => PropertyCache.GetOrAdd(type, static t => t.GetProperties(Public | Instance).Where(static x => x.CanRead && x.GetIndexParameters().Length is 0 && !x.PropertyType.IsByRefLike).ToArray());

    // Arrays and ArraySegment<T> report ICollection<T>.IsReadOnly as true although their indexer writes
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsReadOnlyList<T>(ICollection<T> list) => list is IList nonGenericList ? nonGenericList.IsReadOnly : list is not ArraySegment<T> && list.IsReadOnly;

    // Returns true only when the caller must write value back: a DateTime that actually changed or a mutated struct box.
    // Reference types are mutated in place, so unchanged properties and elements are never re-assigned.
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool ChangeTimeZoneAllPropertyHelper(ref object value, object? tzSrc, object? tzDst, HashSet<object> visited)
    {
        if (value is DateTime dt)
        {
            var shifted = dt.ChangeTimeZoneImplement(tzSrc, tzDst);

            if (shifted == dt)
            {
                return false;
            }

            value = shifted;

            return true;
        }

        var type = value.GetType();

        if (value is string || type.IsPrimitive || type.IsEnum || (!type.IsValueType && !visited.Add(value)))
        {
            return false;
        }

        var mutated = false;

        if (value is IList<DateTime> dateList)
        {
            if (!IsReadOnlyList(dateList))
            {
                for (var i = 0; i < dateList.Count; i++)
                {
                    var current = dateList[i];
                    var next = current.ChangeTimeZoneImplement(tzSrc, tzDst);

                    if (next != current)
                    {
                        dateList[i] = next;
                        mutated = true;
                    }
                }
            }
        }
        else if (value is IList list)
        {
            // read-only lists are still walked so reference-type elements are converted in place
            var isReadOnly = list.IsReadOnly;

            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] is not { } item || (isReadOnly && item is ValueType))
                {
                    continue;
                }

                if (ChangeTimeZoneAllPropertyHelper(ref item, tzSrc, tzDst, visited) && !isReadOnly)
                {
                    list[i] = item;
                    mutated = true;
                }
            }
        }
        else
        {
            foreach (var prop in GetCachedProperties(type))
            {
                if (prop.CanWrite && prop.GetValue(value) is { } propValue && ChangeTimeZoneAllPropertyHelper(ref propValue, tzSrc, tzDst, visited))
                {
                    prop.SetValue(value, propValue);
                    mutated = true;
                }
            }
        }

        return mutated && type.IsValueType;
    }

    #endregion

    #region Internal

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool? AllDistinctImplement<T>(this IEnumerable<T>? input, Func<T, T> selector)
    {
        if (input is null)
        {
            return default;
        }

        var seen = new HashSet<T>();

        foreach (var item in input)
        {
            if (!seen.Add(selector(item)))
            {
                return false;
            }
        }

        return seen.Count is 0 ? null : true;
    }

    #endregion

    #region Default

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsDefaultImplement<T>(this T input) => EqualityComparer<T>.Default.Equals(input.ParseImplement<T>(), default);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotDefaultImplement<T>(this T input) => !EqualityComparer<T>.Default.Equals(input.ParseImplement<T>(), default);

    #endregion

    #region NullDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullDefaultImplement<T>(this T? input) where T : class => input is null || input.AllPropertiesDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullDefaultImplement<T>(this T? input) where T : class => input is not null && input.AnyPropertiesNotDefaultImplement();

    #endregion

    #region NullEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullEmptyImplement<T>([NotNullWhen(false)] this IEnumerable<T>? input) => input is null || !input.Any();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullEmptyImplement<T>([NotNullWhen(true)] this IEnumerable<T>? input) => input is not null && input.Any();

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ChangeTimeZoneAllPropertyImplement<T>(this T? input, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (input is null)
        {
            return input;
        }

        object value = input;

        _ = ChangeTimeZoneAllPropertyHelper(ref value, tzSrc, tzDst, new HashSet<object>(ReferenceEqualityComparer.Instance));

        return (T)value;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T CopyImplement<T>(this T input) where T : new()
    {
        if (input is null)
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
