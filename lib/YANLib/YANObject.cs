using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for object operations.
/// </summary>
/// <remarks>
/// This class contains methods for checking object state, comparing objects, and manipulating object properties.
/// </remarks>
public static partial class YANObject
{
    #region Null

    /// <summary>
    /// Determines whether the specified object is <c>null</c>.
    /// </summary>
    /// <param name="input">The object to check.</param>
    /// <returns><c>true</c> if the object is <c>null</c>; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This method was removed in 8.3.3 by mistake and is restored as an obsolete shim so that code written for 8.3.2 keeps compiling.
    /// Use the <c>is null</c> pattern instead.
    /// </remarks>
    [Obsolete("Use the 'is null' pattern instead. IsNull() was removed in 8.3.3 by mistake and is kept only for compatibility.")]
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNull([NotNullWhen(false)] this object? input) => input is null;

    /// <summary>
    /// Determines whether the specified object is not <c>null</c>.
    /// </summary>
    /// <param name="input">The object to check.</param>
    /// <returns><c>true</c> if the object is not <c>null</c>; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This method was removed in 8.3.3 by mistake and is restored as an obsolete shim so that code written for 8.3.2 keeps compiling.
    /// Use the <c>is not null</c> pattern instead.
    /// </remarks>
    [Obsolete("Use the 'is not null' pattern instead. IsNotNull() was removed in 8.3.3 by mistake and is kept only for compatibility.")]
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNull([NotNullWhen(true)] this object? input) => input is not null;

    #endregion

    #region Default

    /// <summary>
    /// Determines whether the specified value is the default value for its type.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="input">The value to check.</param>
    /// <returns><c>true</c> if the value is the default value for its type; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsDefault<T>(this T input) => input.IsDefaultImplement();

    /// <summary>
    /// Determines whether the specified value is not the default value for its type.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="input">The value to check.</param>
    /// <returns><c>true</c> if the value is not the default value for its type; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotDefault<T>(this T input) => input.IsNotDefaultImplement();

    #endregion

    #region NullDefault

    /// <summary>
    /// Determines whether the specified object is <c>null</c> or has all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <returns><c>true</c> if the object is <c>null</c> or has all properties set to their default values; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This method checks if the object is <c>null</c> or if all of its properties have their default values.
    /// The public instance properties of the runtime type are checked, inherited ones included; indexers and write-only properties are skipped,
    /// and for a property hidden with <c>new</c> only the most-derived one is checked. The getters are called until the result is known (the first property that is not
    /// default decides); an exception thrown by a getter that is called propagates.
    /// For string properties, this means they are <c>null</c> (an empty string is not a default value).
    /// For reference type properties, this means they are <c>null</c>.
    /// For value type properties, this means they have their default value (e.g., 0 for numeric types, false for bool), compared with <c>default(T)</c>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullDefault<T>(this T? input) where T : class => input.IsNullDefaultImplement();

    /// <summary>
    /// Determines whether the specified object is not <c>null</c> and has at least one property not set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <returns><c>true</c> if the object is not <c>null</c> and has at least one property not set to its default value; otherwise, <c>false</c>.</returns>
    /// <remarks>
    /// This method checks if the object is not <c>null</c> and if at least one of its properties does not have its default value.
    /// The properties are selected as in <see cref="IsNullDefault{T}(T)"/>.
    /// For string properties, this means they are not <c>null</c> (an empty string counts as not default).
    /// For reference type properties, this means they are not <c>null</c>.
    /// For value type properties, this means they do not have their default value (e.g., not 0 for numeric types, not false for bool).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullDefault<T>(this T? input) where T : class => input.IsNotNullDefaultImplement();

    #endregion

    #region NullEmpty

    /// <summary>
    /// Determines whether the specified collection is <c>null</c> or empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><c>true</c> if the collection is <c>null</c> or empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? input) => input.IsNullEmptyImplement();

    /// <summary>
    /// Determines whether the specified collection is not <c>null</c> and not empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><c>true</c> if the collection is not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? input) => input.IsNotNullEmptyImplement();

    #endregion

    /// <summary>
    /// Changes the time zone of all <see cref="DateTime"/> properties in the specified object, in place, including those of nested objects, lists, arrays and dictionaries.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to process. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="tzSrc">The source time zone offset. If <c>null</c>, no conversion is performed.</param>
    /// <param name="tzDst">The destination time zone offset. If <c>null</c>, no conversion is performed.</param>
    /// <returns>The same object, with all reachable <see cref="DateTime"/> values converted to the destination time zone.</returns>
    /// <remarks>
    /// The object graph is changed in place and every object (class instance) is converted at most once, so cycles (parent/child back-references) and shared references are safe.
    /// The exception is items reached through <see cref="ArraySegment{T}"/> values: an array reachable both directly and through a segment over it, or through overlapping
    /// segments, has its <see cref="DateTime"/>, boxed <see cref="DateTime"/> and struct items converted once per path.
    /// <list type="bullet">
    /// <item><description>Readable and writable public instance properties are walked, inherited ones included and indexers excluded; a base property hidden with <c>new</c>
    /// by a property of another type is walked too. A <see cref="DateTime"/> or <c>DateTime?</c> value is converted and written back. Any other value that is walked
    /// (an object or a struct) is written back with the property's setter when a <see cref="DateTime"/> was converted somewhere inside it, once everything reachable
    /// from it has been walked and before the next property is read, as in 8.3.3. So a property whose getter returns a copy (a defensive copy, a computed wrapper,
    /// a JSON-backed object) receives the converted copy, and a later property that this setter writes is read, and converted, after the setter has run; state
    /// reachable through two paths is converted once per path (a copy getter over an object or field also reachable through a writable property, a getter-only list,
    /// array or dictionary property or another copy getter; a wrapper over the owner's own <see cref="DateTime"/> properties; a dictionary or <c>IList&lt;DateTime?&gt;</c>
    /// type whose own writable property holds the collection behind its interface).
    /// No other setter is called: not for values that are not walked (strings, numbers, ...), not for a value in which nothing was converted, and not for a second
    /// reference to an object already converted. (A struct item of a read-only list is converted in a copy that is then discarded, but still counts as converted,
    /// so the setter of a property holding that list is called with the unchanged list.)</description></item>
    /// <item><description>A getter-only property is walked only when its declared type is an array, list or dictionary type, either a class (an array, <see cref="List{T}"/>,
    /// <see cref="Dictionary{TKey, TValue}"/>, ...) or an interface (<see cref="IList{T}"/>, <see cref="IDictionary{TKey, TValue}"/>, ...), and its value is not a struct;
    /// the collection is converted in place. A getter-only struct value (<see cref="ArraySegment{T}"/>, <c>ImmutableArray&lt;T&gt;</c>, ...) and a getter-only property declared
    /// as another interface (<see cref="IReadOnlyList{T}"/>, <see cref="ICollection{T}"/>, <see cref="IEnumerable{T}"/>, ...) are not walked.</description></item>
    /// <item><description>Lists and arrays of <see cref="DateTime"/> / <c>DateTime?</c> and dictionaries with <see cref="DateTime"/> / <c>DateTime?</c> values are converted when they are writable;
    /// read-only ones (<c>ReadOnlyCollection&lt;T&gt;</c>, <c>ImmutableArray&lt;T&gt;</c>, <c>ReadOnlyDictionary&lt;TKey, TValue&gt;</c>, ...) are left unchanged.
    /// The elements of other lists (<see cref="System.Collections.IList"/>) are walked, and an element in which a <see cref="DateTime"/> was converted is written back
    /// into a writable list (<c>list[i] = element</c>). A type that implements <see cref="IDictionary{TKey, TValue}"/> with <see cref="DateTime"/> / <c>DateTime?</c> values,
    /// or <c>IList&lt;DateTime?&gt;</c> without <see cref="System.Collections.IList"/>, then has its own readable and writable properties walked (not its getter-only ones);
    /// a type that implements <c>IList&lt;DateTime&gt;</c> without <see cref="System.Collections.IList"/> has only its items converted.</description></item>
    /// <item><description>An <see cref="ArraySegment{T}"/> is handled like an array holding only the segment's items: they are converted or walked in the underlying
    /// array (a struct item is written back into it), and the items outside the segment are left alone.</description></item>
    /// <item><description>Other collections (<c>HashSet&lt;T&gt;</c>, <c>Queue&lt;T&gt;</c>, ...), multi-dimensional arrays and dictionary values that are not <see cref="DateTime"/> are left unchanged.</description></item>
    /// <item><description>Strings, primitives, enums, date, time and number types and non-data types (reflection objects such as <see cref="Type"/>, delegates, streams,
    /// <see cref="TextReader"/> / <see cref="TextWriter"/>, tasks, threads, wait handles, cancellation tokens and their sources, safe handles, pointers) are not walked into,
    /// nor is a class deriving from one of these types, whose own <see cref="DateTime"/> properties are therefore left unchanged. A <see cref="Lazy{T}"/> value is not walked and its
    /// <see cref="Lazy{T}.Value"/> is never read by the walk; a getter-only list property whose own getter reads a lazy value (<c>Dates =&gt; _lazy.Value</c>) is still called,
    /// which creates that value.</description></item>
    /// <item><description>A property whose getter throws is skipped; an exception thrown by a setter propagates.</description></item>
    /// <item><description>Objects and structs are walked from a work list, not recursively, so the depth of the graph is not limited by the call stack. The order is that
    /// of 8.3.3: depth first, in property / item order, a value found in a property or an item being walked, and written back, before the next property or item of
    /// its owner is read. Every object and struct walked is kept until the method returns. A graph that never ends (a getter that returns a new object on every call whose type leads back
    /// to itself) is walked until memory runs out.</description></item>
    /// </list>
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? ChangeTimeZoneAllProperty<T>(this T? input, object? tzSrc = null, object? tzDst = null) where T : class => input.ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst);

    /// <summary>
    /// Creates a shallow copy of the specified object.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to copy. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A new object with the same property values as the input object.</returns>
    /// <remarks>
    /// For a class, the copy is an instance of the input's runtime type when that type differs from <typeparamref name="T"/> and has a public parameterless constructor,
    /// otherwise a new <typeparamref name="T"/>. The readable and writable public instance properties of that type (inherited ones included, indexers excluded,
    /// and a base property hidden with <c>new</c> by a property of another type included) are copied; reference values are shared, not cloned.
    /// Only properties are copied: the items of a collection type (<see cref="List{T}"/>, <see cref="Dictionary{TKey, TValue}"/>, ...) are not.
    /// When the copy is an instance of the runtime type, its constructor runs, and an exception thrown by it surfaces as <see cref="System.Reflection.TargetInvocationException"/>.
    /// For a value type, the value itself is returned, since assigning a struct already copies all of its fields; a boxed struct passed as <see cref="object"/>
    /// is returned in a new box.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Copy<T>(this T input) where T : new() => input.CopyImplement();
}
