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
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> ReadablePropertyCache = new();
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();
    private static readonly ConcurrentDictionary<Type, object> DefaultValueCache = new();

    #region Private

    /// <summary>
    /// Gets the public instance properties of <paramref name="type"/> that can be read through reflection, in the order <see cref="Type.GetProperties(BindingFlags)"/>
    /// returns them: inherited ones included, indexers, write-only and by-ref-like (<c>Span&lt;T&gt;</c>) properties excluded. A base property hidden with <c>new</c>
    /// by a property of another type is kept (reflection already leaves out one hidden by a property of the same type), so <c>Copy</c> and
    /// <c>ChangeTimeZoneAllProperty</c> handle both, as 8.3.3 did.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static PropertyInfo[] GetCachedReadableProperties(Type type) => ReadablePropertyCache.GetOrAdd(type, static t =>
        [.. t.GetProperties(Public | Instance).Where(static x => x.CanRead && !x.PropertyType.IsByRefLike && x.GetIndexParameters().Length is 0)]);

    /// <summary>
    /// Gets the properties of <see cref="GetCachedReadableProperties(Type)"/>, keeping for a name hidden with <c>new</c> only the most-derived property.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static PropertyInfo[] GetCachedProperties(Type type) => PropertyCache.GetOrAdd(type, static t =>
    {
        var result = new List<PropertyInfo>();

        foreach (var prop in GetCachedReadableProperties(t))
        {
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
            ChangeTimeZoneRoot(input, tzSrc, tzDst, new HashSet<object>(ReferenceEqualityComparer.Instance), []);
        }

        return input;
    }

    /// <summary>
    /// Converts, in place, the <see cref="DateTime"/> values reachable from <paramref name="root"/>, skipping the objects in <paramref name="visited"/>.
    /// Class instances are walked from the work stack <paramref name="pending"/> (empty on entry and on return) instead of recursively, so the depth
    /// of the graph (a long linked list, a deep tree) is not limited by the call stack. Each object's own properties are converted first, then the
    /// objects it references, in property / item order, depth first.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static void ChangeTimeZoneRoot(object root, object? tzSrc, object? tzDst, HashSet<object> visited, List<object> pending)
    {
        var next = root;

        while (true)
        {
            var start = pending.Count;

            _ = ChangeTimeZoneGraph(next, tzSrc, tzDst, visited, pending);

            // The objects referenced by `next` were pushed in property / item order; reverse them so that the first one is walked first.
            pending.Reverse(start, pending.Count - start);

            if (pending.Count is 0)
            {
                return;
            }

            next = pending[^1];
            pending.RemoveAt(pending.Count - 1);
        }
    }

    /// <summary>
    /// Walks a value found in the graph: a boxed struct right away, so that its owner can write it back, and a class instance (changed in place,
    /// never written back) later, by adding it to <paramref name="pending"/>.
    /// </summary>
    /// <returns><c>true</c> if <paramref name="value"/> is a boxed struct that changed and must be written back by its owner.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool ChangeTimeZoneValue(object value, object? tzSrc, object? tzDst, HashSet<object> visited, List<object> pending)
    {
        var type = value.GetType();

        if (type.IsValueType)
        {
            return ChangeTimeZoneGraph(value, tzSrc, tzDst, visited, pending);
        }

        if (!type.IsTimeZoneLeaf() && !visited.Contains(value))
        {
            pending.Add(value);
        }

        return false;
    }

    /// <summary>
    /// Converts, in place, the <see cref="DateTime"/> values of <paramref name="input"/>; every object is visited once. Boxed structs inside it
    /// are walked recursively, class instances are added to <paramref name="pending"/>.
    /// </summary>
    /// <returns><c>true</c> if a value was written into <paramref name="input"/> itself (a boxed struct must then be written back by its owner).</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool ChangeTimeZoneGraph(object input, object? tzSrc, object? tzDst, HashSet<object> visited, List<object> pending)
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
                // Arrays and array segments report IList<T>.IsReadOnly == true but their elements can be replaced.
                if (dates.IsReadOnly && input is not (Array or ArraySegment<DateTime>))
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
                if (dates.IsReadOnly && input is not (Array or ArraySegment<DateTime?>))
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
                    else if (item is not null && ChangeTimeZoneValue(item, tzSrc, tzDst, visited, pending) && writable)
                    {
                        list[i] = item;
                        changed = true;
                    }
                }

                return changed;
            }
        }

        if (GetArraySegmentConverter(type) is { } segmentConverter)
        {
            return segmentConverter(input, tzSrc, tzDst, visited, pending);
        }

        if (GetDateTimeDictionaryConverter(type) is { } converter)
        {
            return converter(input, tzSrc, tzDst);
        }

        var written = false;

        foreach (var prop in GetCachedReadableProperties(type))
        {
            if (!prop.CanWrite && (!prop.PropertyType.IsTimeZoneCollection() || IsLazy(prop.DeclaringType)))
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
                    _ = ChangeTimeZoneValue(value, tzSrc, tzDst, visited, pending);
                }

                continue;
            }

            if (value is DateTime dt)
            {
                prop.SetValue(input, dt.ChangeTimeZoneImplement(tzSrc, tzDst));
                written = true;
            }
            else if (ChangeTimeZoneValue(value, tzSrc, tzDst, visited, pending))
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
    private static readonly ConcurrentDictionary<Type, Func<object, object?, object?, HashSet<object>, List<object>, bool>?> ArraySegmentConverterCache = new();

    private static readonly Type[] TimeZoneLeafBaseTypes =
    [
        typeof(MemberInfo), typeof(Assembly), typeof(Module), typeof(ParameterInfo), typeof(Delegate), typeof(Stream), typeof(TextReader), typeof(TextWriter),
        typeof(Task), typeof(WaitHandle), typeof(Thread), typeof(CancellationTokenSource), typeof(SafeHandle), typeof(Pointer)
    ];

    /// <summary>
    /// Whether a value of <paramref name="type"/> is not walked into: primitives, enums, strings, date / time / number value types and other
    /// non-data types (reflection, delegates, streams, tasks, threads, handles, pointers, <see cref="Lazy{T}"/>, whose value the walk must not create),
    /// or an array / list / <see cref="ArraySegment{T}"/> whose elements are all such values.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsTimeZoneLeaf(this Type type) => TimeZoneLeafCache.GetOrAdd(type, static t => IsTimeZoneLeaf(t, []));

    /// <summary>
    /// Computes <see cref="IsTimeZoneLeaf(Type)"/>. <paramref name="listTypes"/> holds the list types whose element type is being checked, so a list type
    /// whose element type leads back to it (<c>class Node : List&lt;Node&gt;</c>, or <c>class A : List&lt;B&gt;</c> with <c>class B : List&lt;A&gt;</c>)
    /// ends the recursion instead of overflowing the stack.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsTimeZoneLeaf(Type type, HashSet<Type> listTypes)
    {
        if (TimeZoneLeafCache.TryGetValue(type, out var cached))
        {
            return cached;
        }

        if (type.IsPrimitive || type.IsEnum || type.IsPointer || type.IsByRefLike || type == typeof(string) || type == typeof(decimal) || type == typeof(DateTime)
            || type == typeof(DateTimeOffset) || type == typeof(TimeSpan) || type == typeof(DateOnly) || type == typeof(TimeOnly) || type == typeof(Guid) || type == typeof(Uri)
            || type == typeof(Version) || type == typeof(object) || type == typeof(CancellationToken) || type == typeof(ValueTask)
            || type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ValueTask<>) || Array.Exists(TimeZoneLeafBaseTypes, x => x.IsAssignableFrom(type)) || IsLazy(type))
        {
            return true;
        }

        if (Nullable.GetUnderlyingType(type) is { } underlying)
        {
            return IsTimeZoneLeaf(underlying, listTypes);
        }

        // Only lists and array segments, whose items the walk visits instead of their properties, are skipped by element type;
        // any other type implementing IEnumerable<string> (say) still has its own DateTime properties converted.
        if (!type.IsArray && !typeof(IList).IsAssignableFrom(type) && !IsArraySegment(type))
        {
            return false;
        }

        // A list type reached again through its own element type is not a leaf; the walk's visited set ends the walk of such data.
        if (!listTypes.Add(type))
        {
            return false;
        }

        var elementType = type.IsArray ? type.GetElementType() : GetSequenceElementType(type);

        return elementType is not null && elementType != typeof(DateTime) && elementType != typeof(DateTime?) && elementType != typeof(object) && IsTimeZoneLeaf(elementType, listTypes);
    }

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
    private static bool IsArraySegment(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ArraySegment<>);

    /// <summary>
    /// Whether <paramref name="type"/> is a <see cref="Lazy{T}"/>. A class deriving from it (<see cref="Lazy{T, TMetadata}"/> included) is walked,
    /// but the properties that <see cref="Lazy{T}"/> declares (<see cref="Lazy{T}.Value"/>) are never read, so the walk never creates a lazy value.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsLazy(Type? type) => type is { IsGenericType: true } && type.GetGenericTypeDefinition() == typeof(Lazy<>);

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

    /// <summary>
    /// Gets a converter that walks only the items of an <see cref="ArraySegment{T}"/>, or <c>null</c> for other types. A segment is not an
    /// <see cref="IList"/>, and its getter-only <see cref="ArraySegment{T}.Array"/> property is the whole underlying array, so walking the segment's
    /// properties would convert the items outside the segment too. (Segments of <see cref="DateTime"/> / <c>DateTime?</c> are converted as lists.)
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Func<object, object?, object?, HashSet<object>, List<object>, bool>? GetArraySegmentConverter(Type type) => ArraySegmentConverterCache.GetOrAdd(type, static t =>
        IsArraySegment(t)
            ? typeof(YANObject).GetMethod(nameof(ChangeTimeZoneArraySegment), NonPublic | Static)!.MakeGenericMethod(t.GetGenericArguments()).CreateDelegate<Func<object, object?, object?, HashSet<object>, List<object>, bool>>()
            : null);

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool ChangeTimeZoneArraySegment<T>(object input, object? tzSrc, object? tzDst, HashSet<object> visited, List<object> pending)
    {
        // Like an array, a segment's items can be replaced (the writes go to the underlying array).
        var segment = (ArraySegment<T>)input;
        var changed = false;

        for (var i = 0; i < segment.Count; i++)
        {
            object? item = segment[i];

            if (item is DateTime dt)
            {
                segment[i] = (T)(object)dt.ChangeTimeZoneImplement(tzSrc, tzDst);
                changed = true;
            }
            else if (item is not null && ChangeTimeZoneValue(item, tzSrc, tzDst, visited, pending))
            {
                segment[i] = (T)item;
                changed = true;
            }
        }

        return changed;
    }

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

        foreach (var prop in CopyPropertyCache.GetOrAdd(runtimeType, static t => [.. GetCachedReadableProperties(t).Where(static x => x.CanWrite)]))
        {
            prop.SetValue(result, prop.GetValue(input));
        }

        return result;
    }

    #endregion
}
