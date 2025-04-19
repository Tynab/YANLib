using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using YANLib.Implementation.Unmanaged;
using static System.Reflection.BindingFlags;

namespace YANLib.Implementation.Object;

internal static partial class YANObject
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();

    #region Private
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static PropertyInfo[] GetCachedProperties(Type type) => PropertyCache.GetOrAdd(type, t => t.GetProperties(Public | Instance | DeclaredOnly));
    #endregion

    #region Is
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsDefaultImplement<T>(this T input) => EqualityComparer<T>.Default.Equals(input.ParseImplement<T>(), default);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotDefaultImplement<T>(this T input) => !input.IsDefaultImplement<T>();

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
    internal static bool IsNotNullEmptyImplement<T>([NotNullWhen(true)] this IEnumerable<T>? input) => input.IsNotNullImplement() && input.IsExistItemImplement();
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
    internal static IEnumerable<T?>? ChangeTimeZoneAllPropertiesImplement<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) where T : class
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(x => x.ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst)) : input.AsParallel().Select(x => x.ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst));
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsExistItemImplement(this IEnumerable? input) => input.IsNotNullImplement() && input switch
    {
        Array array => array.Length.IsNotDefaultImplement(),
        BlockingCollection<object?> blockingCollection => blockingCollection.Count.IsNotDefaultImplement(),
        ConcurrentBag<object?> concurrentBag => !concurrentBag.IsEmpty,
        ConcurrentQueue<object?> concurrentQueue => !concurrentQueue.IsEmpty,
        ConcurrentStack<object?> concurrentStack => !concurrentStack.IsEmpty,
        ConcurrentDictionary<object, object?> concurrentDictionary => !concurrentDictionary.IsEmpty,
        ICollection nonGenericCollection => nonGenericCollection.Count.IsNotDefaultImplement(),
        ICollection<object?> genericCollection => genericCollection.Count.IsNotDefaultImplement(),
        IImmutableSet<object?> immutableSet => immutableSet.Count.IsNotDefaultImplement(),
        IImmutableList<object?> immutableList => immutableList.Count.IsNotDefaultImplement(),
        IImmutableQueue<object?> immutableQueue => !immutableQueue.IsEmpty,
        IImmutableStack<object?> immutableStack => !immutableStack.IsEmpty,
        IImmutableDictionary<object, object?> immutableDictionary => immutableDictionary.Count.IsNotDefaultImplement(),
        IReadOnlyCollection<object?> readOnlyCollection => readOnlyCollection.Count.IsNotDefaultImplement(),
        _ => input.Cast<object?>().Any()
    };

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotExistItemImplement(this IEnumerable? input) => !input.IsExistItemImplement();
}
