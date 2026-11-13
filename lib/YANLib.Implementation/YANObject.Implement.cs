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
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> ReadWritePropertyCache = new();
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
    /// Gets the properties of <see cref="GetCachedReadableProperties(Type)"/> that are also writable: the properties that <c>Copy</c> copies and, as in
    /// 8.3.3, that <c>ChangeTimeZoneAllProperty</c> walks in a dictionary type or a type implementing only <c>IList&lt;DateTime?&gt;</c>.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static PropertyInfo[] GetCachedReadWriteProperties(Type type)
        => ReadWritePropertyCache.GetOrAdd(type, static t => [.. GetCachedReadableProperties(t).Where(static x => x.CanWrite)]);

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
    /// The walk is depth first in property / item order, as the recursive walk of 8.3.3: a value found in a property or an item (a class instance or a
    /// boxed struct) is walked, and written back (<see cref="TimeZoneNode.Complete"/>), before the next property or item of its owner is read.
    /// The values being walked are kept on the work stack <paramref name="pending"/> (empty on entry and on return), one per level of the path from
    /// <paramref name="root"/>, each with the position where its walk resumes, instead of on the call stack, so the depth of the graph (a long linked
    /// list, a deep tree, a chain of structs) is not limited by the call stack.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static void ChangeTimeZoneRoot(object root, object? tzSrc, object? tzDst, HashSet<object> visited, List<TimeZoneNode> pending)
    {
        if (!TryVisitTimeZoneValue(root, visited))
        {
            return;
        }

        pending.Add(new TimeZoneNode(root, null, null, null, 0));

        while (pending.Count > 0)
        {
            var node = pending[^1];

            if (ChangeTimeZoneNext(node, tzSrc, tzDst, visited) is { } child)
            {
                pending.Add(child);
            }
            else
            {
                pending.RemoveAt(pending.Count - 1);
                node.Complete();
            }
        }
    }

    /// <summary>
    /// A value being walked (a class instance or a boxed struct), where it is held, and where its walk resumes. The value is held in the property
    /// <paramref name="property"/> of <paramref name="target"/>, in the item <paramref name="index"/> of the list <paramref name="target"/> (no
    /// <paramref name="property"/>), or nowhere that is written back (no <paramref name="target"/>: the root, a getter-only property, an item of a
    /// read-only list).
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="owner">The node of the value that holds <paramref name="value"/>, or <c>null</c> for the root.</param>
    /// <param name="target">The object whose property, or the list whose item, holds <paramref name="value"/>, or <c>null</c>.</param>
    /// <param name="property">The writable property of <paramref name="target"/> that holds <paramref name="value"/>, or <c>null</c> for a list item.</param>
    /// <param name="index">The index of <paramref name="value"/> in the list <paramref name="target"/>.</param>
    private sealed class TimeZoneNode(object value, TimeZoneNode? owner, object? target, PropertyInfo? property, int index)
    {
        public object Value { get; } = value;

        /// <summary>
        /// Whether a <see cref="DateTime"/> was converted in <see cref="Value"/> or in a value walked from it.
        /// </summary>
        public bool Changed { get; set; }

        /// <summary>
        /// Whether the walk of <see cref="Value"/> has started (<see cref="Properties"/> or <see cref="Items"/> and <see cref="Position"/> are set).
        /// </summary>
        public bool Started { get; set; }

        /// <summary>
        /// The properties of <see cref="Value"/> that are read, or <c>null</c> when its items are walked or it has nothing else to walk.
        /// </summary>
        public PropertyInfo[]? Properties { get; set; }

        /// <summary>
        /// The list whose items are walked: <see cref="Value"/> itself, or the array under the <see cref="ArraySegment{T}"/> <see cref="Value"/>.
        /// </summary>
        public IList? Items { get; set; }

        /// <summary>
        /// Whether the <see cref="DateTime"/> items of <see cref="Items"/> are converted and its items in which something changed are written back.
        /// </summary>
        public bool ItemsWritable { get; set; }

        /// <summary>
        /// The index of the next property of <see cref="Properties"/>, or of the next item of <see cref="Items"/>, to read.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// The end (exclusive) of the items of an <see cref="ArraySegment{T}"/> in <see cref="Items"/>, or -1 to read up to the list's count, which is
        /// read again before each item (as in 8.3.3), since the values walked in between can run setters.
        /// </summary>
        public int End { get; set; } = -1;

        /// <summary>
        /// Called once every value walked from <see cref="Value"/> is done. If something in it changed, writes it back where it is held (the
        /// property's setter or the list's indexer), so that a struct, or a property whose getter returns a copy (a defensive copy, a computed or a
        /// JSON-backed object), gets the converted value, and marks the owner as changed so that it is written back in turn.
        /// </summary>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public void Complete()
        {
            if (!Changed)
            {
                return;
            }

            if (target is not null)
            {
                if (property is not null)
                {
                    property.SetValue(target, Value);
                }
                else
                {
                    ((IList)target)[index] = Value;
                }
            }

            if (owner is not null)
            {
                owner.Changed = true;
            }
        }
    }

    /// <summary>
    /// Whether <paramref name="value"/> is to be walked: it is not a leaf and was not walked before. It is then added to <paramref name="visited"/>.
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryVisitTimeZoneValue(object value, HashSet<object> visited) => !value.GetType().IsTimeZoneLeaf() && visited.Add(value);

    /// <summary>
    /// Continues the walk of <paramref name="node"/>'s value where it stopped: converts its <see cref="DateTime"/> values in place, in property / item
    /// order, up to the next value to walk.
    /// </summary>
    /// <param name="node">The node of the value to walk.</param>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="visited">The objects already walked.</param>
    /// <returns>The node of the next value to walk (already added to <paramref name="visited"/>), or <c>null</c> when <paramref name="node"/>'s value is done.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static TimeZoneNode? ChangeTimeZoneNext(TimeZoneNode node, object? tzSrc, object? tzDst, HashSet<object> visited)
    {
        if (!node.Started)
        {
            node.Started = true;
            ChangeTimeZoneStart(node, tzSrc, tzDst);
        }

        if (node.Items is { } items)
        {
            for (; node.Position < (node.End < 0 ? items.Count : node.End); node.Position++)
            {
                var item = items[node.Position];

                if (item is DateTime dt)
                {
                    if (node.ItemsWritable)
                    {
                        items[node.Position] = dt.ChangeTimeZoneImplement(tzSrc, tzDst);
                        node.Changed = true;
                    }
                }
                else if (item is not null && TryVisitTimeZoneValue(item, visited))
                {
                    // Walked now; written back (list[i] = item) once it is done if something in it changed, as in 8.3.3, unless the list is read-only.
                    var index = node.Position++;

                    return new TimeZoneNode(item, node, node.ItemsWritable ? items : null, null, index);
                }
            }

            return null;
        }

        if (node.Properties is not { } props)
        {
            return null;
        }

        var input = node.Value;

        for (; node.Position < props.Length; node.Position++)
        {
            var prop = props[node.Position];

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
                // A getter-only collection can still be converted in place; it is not written back.
                if (!value.GetType().IsValueType && TryVisitTimeZoneValue(value, visited))
                {
                    node.Position++;

                    return new TimeZoneNode(value, node, null, null, 0);
                }
            }
            else if (value is DateTime dt)
            {
                prop.SetValue(input, dt.ChangeTimeZoneImplement(tzSrc, tzDst));
                node.Changed = true;
            }
            else if (TryVisitTimeZoneValue(value, visited))
            {
                // Walked now; written back with the setter once it is done if something in it changed, before the next property is read (as in 8.3.3).
                node.Position++;

                return new TimeZoneNode(value, node, input, prop, 0);
            }
        }

        return null;
    }

    /// <summary>
    /// Starts the walk of <paramref name="node"/>'s value: converts a list of <see cref="DateTime"/> / <c>DateTime?</c> or a dictionary with such values
    /// in one go, or sets the items (of a list or an <see cref="ArraySegment{T}"/>) or the properties that <see cref="ChangeTimeZoneNext"/> reads. After
    /// the values of a dictionary, or the items of a type that implements <c>IList&lt;DateTime?&gt;</c> but not <see cref="IList"/>, are converted, the
    /// readable and writable properties of its type are read as well (as in 8.3.3, which walked them for these types).
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static void ChangeTimeZoneStart(TimeZoneNode node, object? tzSrc, object? tzDst)
    {
        var input = node.Value;

        switch (input)
        {
            case IList<DateTime> dates:
            {
                // Arrays and array segments report IList<T>.IsReadOnly == true but their elements can be replaced.
                if (!dates.IsReadOnly || input is Array or ArraySegment<DateTime>)
                {
                    for (var i = 0; i < dates.Count; i++)
                    {
                        dates[i] = dates[i].ChangeTimeZoneImplement(tzSrc, tzDst);
                    }

                    node.Changed = dates.Count > 0;
                }

                return;
            }
            case IList<DateTime?> dates:
            {
                if (!dates.IsReadOnly || input is Array or ArraySegment<DateTime?>)
                {
                    for (var i = 0; i < dates.Count; i++)
                    {
                        if (dates[i] is DateTime dt)
                        {
                            dates[i] = dt.ChangeTimeZoneImplement(tzSrc, tzDst);
                            node.Changed = true;
                        }
                    }
                }

                if (input is not IList and not ArraySegment<DateTime?>)
                {
                    // A type that implements IList<DateTime?> but not IList also has its own readable and writable properties walked, as in 8.3.3.
                    node.Properties = GetCachedReadWriteProperties(input.GetType());
                }

                return;
            }
            case Array { Rank: > 1 }:
            {
                return;
            }
            case IList list:
            {
                try
                {
                    _ = list.Count;
                }
                catch (InvalidOperationException)
                {
                    // e.g. a default (uninitialised) ImmutableArray<T>
                    return;
                }

                node.Items = list;
                node.ItemsWritable = !list.IsReadOnly;

                return;
            }
        }

        var type = input.GetType();

        if (GetArraySegmentBounds(type) is { } getBounds)
        {
            // Like an array, a segment's items can be replaced (the writes go to the underlying array); the items outside the segment are not read.
            var (array, offset, count) = getBounds(input);

            if (array is not null)
            {
                node.Items = array;
                node.ItemsWritable = true;
                node.Position = offset;
                node.End = offset + count;
            }

            return;
        }

        if (GetDateTimeDictionaryConverter(type) is { } converter)
        {
            node.Changed = converter(input, tzSrc, tzDst);

            // The type's own readable and writable properties are walked too, as in 8.3.3, but not its getter-only ones, which can be views of the
            // values just converted.
            node.Properties = GetCachedReadWriteProperties(type);

            return;
        }

        node.Properties = GetCachedReadableProperties(type);
    }

    private static readonly ConcurrentDictionary<Type, bool> TimeZoneLeafCache = new();
    private static readonly ConcurrentDictionary<Type, bool> TimeZoneCollectionCache = new();
    private static readonly ConcurrentDictionary<Type, Func<object, object?, object?, bool>?> DateTimeDictionaryConverterCache = new();
    private static readonly ConcurrentDictionary<Type, Func<object, (IList? Array, int Offset, int Count)>?> ArraySegmentBoundsCache = new();

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
    /// but the properties that <see cref="Lazy{T}"/> declares (<see cref="Lazy{T}.Value"/>) are never read by the walk.
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
    /// Gets a function that returns the underlying array, offset and count of an <see cref="ArraySegment{T}"/>, or <c>null</c> for other types. A segment
    /// is not an <see cref="IList"/>, and its getter-only <see cref="ArraySegment{T}.Array"/> property is the whole underlying array, so the walk reads
    /// the segment's items in that array instead of walking the segment's properties, which would convert the items outside the segment too.
    /// (Segments of <see cref="DateTime"/> / <c>DateTime?</c> are converted as lists.)
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Func<object, (IList? Array, int Offset, int Count)>? GetArraySegmentBounds(Type type) => ArraySegmentBoundsCache.GetOrAdd(type, static t =>
        IsArraySegment(t)
            ? typeof(YANObject).GetMethod(nameof(ArraySegmentBounds), NonPublic | Static)!.MakeGenericMethod(t.GetGenericArguments())
                .CreateDelegate<Func<object, (IList? Array, int Offset, int Count)>>()
            : null);

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static (IList? Array, int Offset, int Count) ArraySegmentBounds<T>(object input)
    {
        var segment = (ArraySegment<T>)input;

        return (segment.Array, segment.Offset, segment.Count);
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

        foreach (var prop in GetCachedReadWriteProperties(runtimeType))
        {
            prop.SetValue(result, prop.GetValue(input));
        }

        return result;
    }

    #endregion
}
