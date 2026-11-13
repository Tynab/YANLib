using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Reflection.BindingFlags;

namespace YANLib.Implementation;

internal static partial class YANObject
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();
    private static readonly ConcurrentDictionary<Type, object> DefaultValueCache = new();

    #region Private

    /// <summary>
    /// Gets the public instance properties of <paramref name="type"/> that can be read through reflection: inherited ones included, indexers,
    /// write-only and by-ref-like (<c>Span&lt;T&gt;</c>) properties excluded, and for a name hidden with <c>new</c> only the most-derived property.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static PropertyInfo[] GetCachedProperties(Type type) => PropertyCache.GetOrAdd(type, static t =>
    {
        var result = new List<PropertyInfo>();

        foreach (var prop in t.GetProperties(Public | Instance))
        {
            if (!prop.CanRead || prop.PropertyType.IsByRefLike || prop.GetIndexParameters().Length > 0)
            {
                continue;
            }

            var index = result.FindIndex(x => x.Name.Equals(prop.Name, StringComparison.Ordinal));

            if (index < 0)
            {
                result.Add(prop);
            }
            else if (prop.DeclaringType!.IsSubclassOf(result[index].DeclaringType!))
            {
                result[index] = prop;
            }
        }

        return [.. result];
    });

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static PropertyInfo[] GetCachedProperties(Type type, IEnumerable<string?> names) => [.. GetCachedProperties(type).Where(x => names.Contains(x.Name))];

    /// <summary>
    /// Gets <c>default(T)</c> for <paramref name="type"/> as an object: <c>null</c> for reference and nullable types, otherwise a cached
    /// zero-initialised box (a struct's explicit parameterless constructor is not run, unlike <see cref="Activator.CreateInstance(Type)"/>).
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static object? GetDefaultValue(Type type)
        => type.IsValueType && Nullable.GetUnderlyingType(type) is null ? DefaultValueCache.GetOrAdd(type, static t => RuntimeHelpers.GetUninitializedObject(t)) : null;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsDefaultValue(this PropertyInfo prop, object input) => EqualityComparer<object>.Default.Equals(prop.GetValue(input), GetDefaultValue(prop.PropertyType));

    #endregion

    #region Internal

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static int GetCountImplement<T>(this IEnumerable<T>? input) => input switch
    {
        null => 0,
        _ when input.TryGetNonEnumeratedCount(out var count) => count,
        IReadOnlyCollection<T> readOnlyCollection => readOnlyCollection.Count,
        _ => input.Count()
    };

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

        if (input is IList<DateTime> dateList)
        {
            for (var i = 0; i < dateList.Count; i++)
            {
                dateList[i] = dateList[i].ChangeTimeZoneImplement(tzSrc, tzDst);
            }

            return input;
        }

        if (input is IList list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] is not null)
                {
                    var updated = list[i].ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst);

                    if (updated is not null)
                    {
                        list[i] = updated;
                    }
                }
            }

            return input;
        }

        var props = input.GetType().GetProperties(Public | Instance).Where(static x => x.CanRead && x.CanWrite);

        foreach (var prop in props)
        {
            if (prop is null)
            {
                continue;
            }

            var val = prop.GetValue(input);

            if (val is null)
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

                if (updated is not null)
                {
                    prop.SetValue(input, updated);
                }
            }
        }

        return input;
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
