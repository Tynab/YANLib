using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Immutable;
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
    private static PropertyInfo[] GetCachedProperties(Type type) => PropertyCache.GetOrAdd(type, t => t.GetProperties(Public | Instance | DeclaredOnly));

    #endregion

    #region Internal

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static int GetCountImplement(this IEnumerable? input) => input switch
    {
        null => 0,
        Array array => array.Length,
        BlockingCollection<object?> blockingCollection => blockingCollection.Count,
        ConcurrentBag<object?> concurrentBag => concurrentBag.Count,
        ConcurrentQueue<object?> concurrentQueue => concurrentQueue.Count,
        ConcurrentStack<object?> concurrentStack => concurrentStack.Count,
        ConcurrentDictionary<object, object?> concurrentDictionary => concurrentDictionary.Count,
        ICollection nonGenericCollection => nonGenericCollection.Count,
        ICollection<object?> genericCollection => genericCollection.Count,
        IImmutableSet<object?> immutableSet => immutableSet.Count,
        IImmutableList<object?> immutableList => immutableList.Count,
        IImmutableQueue<object?> immutableQueue => immutableQueue.Count(),
        IImmutableStack<object?> immutableStack => immutableStack.Count(),
        IImmutableDictionary<object, object?> immutableDictionary => immutableDictionary.Count,
        IReadOnlyCollection<object?> readOnlyCollection => readOnlyCollection.Count,
        _ => input.Cast<object?>().Count()
    };

    #endregion

    #region Null

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullImplement([NotNullWhen(false)] this object? input) => input is null;

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullImplement([NotNullWhen(true)] this object? input) => !input.IsNullImplement();

    #endregion

    #region Default

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsDefaultImplement<T>(this T input) => EqualityComparer<T>.Default.Equals(input.ParseImplement<T>(), default);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotDefaultImplement<T>(this T input) => !input.IsDefaultImplement();

    #endregion

    #region NullDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullDefaultImplement<T>(this T? input) where T : class => input.IsNullImplement() || input.AllPropertiesDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullDefaultImplement<T>(this T? input) where T : class => input.IsNotNullImplement() && input.AnyPropertiesNotDefaultImplement();

    #endregion

    #region NullEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullEmptyImplement<T>([NotNullWhen(false)] this IEnumerable<T>? input) => input.IsNullImplement() || !input.Any();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullEmptyImplement<T>([NotNullWhen(true)] this IEnumerable<T>? input) => input.IsNotNullImplement() && input.Any();

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ChangeTimeZoneAllPropertyImplement<T>(this T? input, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (input.IsNullImplement())
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
                if (list[i].IsNotNullImplement())
                {
                    var updated = list[i].ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst);

                    if (updated.IsNotNullImplement())
                    {
                        list[i] = updated;
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
