using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

    /// <summary>
    /// Finds the readable, non-indexer public instance property named <paramref name="name"/>: an exact (ordinal) match wins over a
    /// case-insensitive one, and within each group the most-derived declaration wins (so <c>new</c>-hidden properties are not ambiguous).
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static PropertyInfo? GetPropertyImplement(this Type type, string name)
    {
        PropertyInfo? exact = null;
        PropertyInfo? ignoreCase = null;

        foreach (var prop in GetCachedProperties(type))
        {
            if (prop.Name.Equals(name, StringComparison.Ordinal))
            {
                if (exact is null || prop.DeclaringType!.IsSubclassOf(exact.DeclaringType!))
                {
                    exact = prop;
                }
            }
            else if (prop.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && (ignoreCase is null || prop.DeclaringType!.IsSubclassOf(ignoreCase.DeclaringType!)))
            {
                ignoreCase = prop;
            }
        }

        return exact ?? ignoreCase;
    }

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

    #region ChangeTimeZoneAllProperty

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ChangeTimeZoneAllPropertyImplement<T>(this T? input, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (input is not null)
        {
            _ = ChangeTimeZoneGraph(input, tzSrc, tzDst, new HashSet<object>(ReferenceEqualityComparer.Instance));
        }

        return input;
    }

    /// <summary>
    /// Converts, in place, the <see cref="DateTime"/> values reachable from <paramref name="input"/>; every object is visited once.
    /// </summary>
    /// <returns><c>true</c> if a value was written into <paramref name="input"/> itself (a boxed struct must then be written back by its owner).</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool ChangeTimeZoneGraph(object input, object? tzSrc, object? tzDst, HashSet<object> visited)
    {
        var type = input.GetType();

        if (type.IsTimeZoneLeaf() || !visited.Add(input))
        {
            return false;
        }

        switch (input)
        {
            case IList<DateTime> dates:
            {
                // Arrays report IList<T>.IsReadOnly == true but their elements can be replaced.
                if (dates.IsReadOnly && input is not Array)
                {
                    return false;
                }

                for (var i = 0; i < dates.Count; i++)
                {
                    dates[i] = dates[i].ChangeTimeZoneImplement(tzSrc, tzDst);
                }

                return dates.Count > 0;
            }
            case IList<DateTime?> dates:
            {
                if (dates.IsReadOnly && input is not Array)
                {
                    return false;
                }

                var changed = false;

                for (var i = 0; i < dates.Count; i++)
                {
                    if (dates[i] is DateTime dt)
                    {
                        dates[i] = dt.ChangeTimeZoneImplement(tzSrc, tzDst);
                        changed = true;
                    }
                }

                return changed;
            }
            case Array { Rank: > 1 }:
            {
                return false;
            }
            case IList list:
            {
                int count;

                try
                {
                    count = list.Count;
                }
                catch (InvalidOperationException)
                {
                    // e.g. a default (uninitialised) ImmutableArray<T>
                    return false;
                }

                var writable = !list.IsReadOnly;
                var changed = false;

                for (var i = 0; i < count; i++)
                {
                    var item = list[i];

                    if (item is DateTime dt)
                    {
                        if (writable)
                        {
                            list[i] = dt.ChangeTimeZoneImplement(tzSrc, tzDst);
                            changed = true;
                        }
                    }
                    else if (item is not null && ChangeTimeZoneGraph(item, tzSrc, tzDst, visited) && writable && item.GetType().IsValueType)
                    {
                        list[i] = item;
                        changed = true;
                    }
                }

                return changed;
            }
        }

        if (GetDateTimeDictionaryConverter(type) is { } converter)
        {
            return converter(input, tzSrc, tzDst);
        }

        var written = false;

        foreach (var prop in GetCachedProperties(type))
        {
            if (!prop.CanWrite && !prop.PropertyType.IsTimeZoneCollection())
            {
                continue;
            }

            object? value;

            try
            {
                value = prop.GetValue(input);
            }
            catch (TargetInvocationException)
            {
                // A getter that throws (e.g. Stream.ReadTimeout) is skipped instead of failing the whole walk.
                continue;
            }

            if (value is null)
            {
                continue;
            }

            if (!prop.CanWrite)
            {
                // A getter-only collection can still be converted in place; nothing is written back.
                if (!value.GetType().IsValueType)
                {
                    _ = ChangeTimeZoneGraph(value, tzSrc, tzDst, visited);
                }

                continue;
            }

            if (value is DateTime dt)
            {
                prop.SetValue(input, dt.ChangeTimeZoneImplement(tzSrc, tzDst));
                written = true;
            }
            else if (ChangeTimeZoneGraph(value, tzSrc, tzDst, visited) && value.GetType().IsValueType)
            {
                prop.SetValue(input, value);
                written = true;
            }
        }

        return written;
    }

    private static readonly ConcurrentDictionary<Type, bool> TimeZoneLeafCache = new();
    private static readonly ConcurrentDictionary<Type, bool> TimeZoneCollectionCache = new();
    private static readonly ConcurrentDictionary<Type, Func<object, object?, object?, bool>?> DateTimeDictionaryConverterCache = new();

    private static readonly Type[] TimeZoneLeafBaseTypes =
    [
        typeof(MemberInfo), typeof(Assembly), typeof(Module), typeof(ParameterInfo), typeof(Delegate), typeof(Stream), typeof(TextReader), typeof(TextWriter),
        typeof(Task), typeof(WaitHandle), typeof(Thread), typeof(CancellationTokenSource), typeof(SafeHandle), typeof(Pointer)
    ];

    /// <summary>
    /// Whether a value of <paramref name="type"/> is not walked into: primitives, enums, strings, date / time / number value types and other
    /// non-data types (reflection, delegates, streams, tasks, threads, handles, pointers), or an array / list whose elements are all such values.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsTimeZoneLeaf(this Type type) => TimeZoneLeafCache.GetOrAdd(type, static t =>
    {
        if (t.IsPrimitive || t.IsEnum || t.IsPointer || t.IsByRefLike || t == typeof(string) || t == typeof(decimal) || t == typeof(DateTime) || t == typeof(DateTimeOffset)
            || t == typeof(TimeSpan) || t == typeof(DateOnly) || t == typeof(TimeOnly) || t == typeof(Guid) || t == typeof(Uri) || t == typeof(Version) || t == typeof(object)
            || t == typeof(CancellationToken) || t == typeof(ValueTask) || t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ValueTask<>)
            || Array.Exists(TimeZoneLeafBaseTypes, x => x.IsAssignableFrom(t)) || Nullable.GetUnderlyingType(t) is { } underlying && underlying.IsTimeZoneLeaf())
        {
            return true;
        }

        // Only lists, which the walk would otherwise enumerate instead of walking their properties, are skipped by element type;
        // any other type implementing IEnumerable<string> (say) still has its own DateTime properties converted.
        if (!t.IsArray && !typeof(IList).IsAssignableFrom(t))
        {
            return false;
        }

        var elementType = t.IsArray ? t.GetElementType() : GetSequenceElementType(t);

        return elementType is not null && elementType != typeof(DateTime) && elementType != typeof(DateTime?) && elementType != typeof(object) && elementType.IsTimeZoneLeaf();
    });

    /// <summary>
    /// Whether <paramref name="type"/> is a collection that the walk converts in place (an array, a list or a dictionary), so a getter-only property
    /// of this type is still walked.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsTimeZoneCollection(this Type type) => TimeZoneCollectionCache.GetOrAdd(type, static t =>
        !t.IsValueType && !t.IsTimeZoneLeaf() && (t.IsArray || typeof(IList).IsAssignableFrom(t) || typeof(IDictionary).IsAssignableFrom(t)
        || IsGenericInterface(t, typeof(IList<>)) || IsGenericInterface(t, typeof(IDictionary<,>)) || Array.Exists(t.GetInterfaces(), x => IsGenericInterface(x, typeof(IList<>)) || IsGenericInterface(x, typeof(IDictionary<,>)))));

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsGenericInterface(Type type, Type definition) => type.IsInterface && type.IsGenericType && type.GetGenericTypeDefinition() == definition;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Type? GetSequenceElementType(Type type)
    {
        Type? elementType = null;

        foreach (var itf in type.IsInterface ? [type, .. type.GetInterfaces()] : type.GetInterfaces())
        {
            if (IsGenericInterface(itf, typeof(IEnumerable<>)))
            {
                if (elementType is not null)
                {
                    return null;
                }

                elementType = itf.GetGenericArguments()[0];
            }
        }

        return elementType;
    }

    /// <summary>
    /// Gets a converter for a type that implements <c>IDictionary&lt;TKey, DateTime&gt;</c> or <c>IDictionary&lt;TKey, DateTime?&gt;</c>, or <c>null</c>.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Func<object, object?, object?, bool>? GetDateTimeDictionaryConverter(Type type) => DateTimeDictionaryConverterCache.GetOrAdd(type, static t =>
    {
        foreach (var itf in t.GetInterfaces())
        {
            if (!IsGenericInterface(itf, typeof(IDictionary<,>)))
            {
                continue;
            }

            var args = itf.GetGenericArguments();
            var name = args[1] == typeof(DateTime) ? nameof(ChangeTimeZoneDictionary) : args[1] == typeof(DateTime?) ? nameof(ChangeTimeZoneNullableDictionary) : null;

            if (name is not null)
            {
                return typeof(YANObject).GetMethod(name, NonPublic | Static)!.MakeGenericMethod(args[0]).CreateDelegate<Func<object, object?, object?, bool>>();
            }
        }

        return null;
    });

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool ChangeTimeZoneDictionary<TKey>(object input, object? tzSrc, object? tzDst)
    {
        var dictionary = (IDictionary<TKey, DateTime>)input;

        if (dictionary.IsReadOnly)
        {
            return false;
        }

        foreach (var key in dictionary.Keys.ToArray())
        {
            dictionary[key] = dictionary[key].ChangeTimeZoneImplement(tzSrc, tzDst);
        }

        return dictionary.Count > 0;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool ChangeTimeZoneNullableDictionary<TKey>(object input, object? tzSrc, object? tzDst)
    {
        var dictionary = (IDictionary<TKey, DateTime?>)input;

        if (dictionary.IsReadOnly)
        {
            return false;
        }

        var changed = false;

        foreach (var key in dictionary.Keys.ToArray())
        {
            if (dictionary[key] is DateTime dt)
            {
                dictionary[key] = dt.ChangeTimeZoneImplement(tzSrc, tzDst);
                changed = true;
            }
        }

        return changed;
    }

    #endregion

    #region Copy

    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> CopyPropertyCache = new();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T CopyImplement<T>(this T input) where T : new()
    {
        if (input is null || typeof(T).IsValueType)
        {
            // Assigning a value type already copies every field; copying only its settable properties into a new instance would turn
            // DateTime, Guid, int, ... into their default values.
            return input;
        }

        var runtimeType = input.GetType();

        if (runtimeType.IsValueType)
        {
            // A boxed struct typed as object: return a new box holding a copy of the value.
            return (T)RuntimeHelpers.GetObjectValue(input);
        }

        T result;

        if (runtimeType != typeof(T) && runtimeType.GetConstructor(Type.EmptyTypes) is not null)
        {
            result = (T)Activator.CreateInstance(runtimeType)!;
        }
        else
        {
            result = new T();
            runtimeType = typeof(T);
        }

        foreach (var prop in CopyPropertyCache.GetOrAdd(runtimeType, static t => [.. GetCachedProperties(t).Where(static x => x.CanWrite)]))
        {
            prop.SetValue(result, prop.GetValue(input));
        }

        return result;
    }

    #endregion
}
