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
    /// and for a property hidden with <c>new</c> only the most-derived one is checked. An exception thrown by a getter propagates.
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
    /// The object graph is changed in place and every object is converted at most once, so cycles (parent/child back-references) and shared references are safe.
    /// <list type="bullet">
    /// <item><description>Readable and writable public instance properties are walked. A <see cref="DateTime"/> or <c>DateTime?</c> value is converted and written back;
    /// a struct is walked and written back when something in it changed. No other property is written.</description></item>
    /// <item><description>A getter-only property is walked only when its declared type is an array, a list or a dictionary; the collection is converted in place.</description></item>
    /// <item><description>Lists and arrays of <see cref="DateTime"/> / <c>DateTime?</c> and dictionaries with <see cref="DateTime"/> / <c>DateTime?</c> values are converted when they are writable;
    /// read-only ones (<c>ReadOnlyCollection&lt;T&gt;</c>, <c>ImmutableArray&lt;T&gt;</c>, <c>ReadOnlyDictionary&lt;TKey, TValue&gt;</c>, ...) are left unchanged.
    /// The elements of other lists (<see cref="System.Collections.IList"/>) are walked.</description></item>
    /// <item><description>Other collections (<c>HashSet&lt;T&gt;</c>, <c>Queue&lt;T&gt;</c>, ...), multi-dimensional arrays and dictionary values that are not <see cref="DateTime"/> are left unchanged.</description></item>
    /// <item><description>Strings, primitives, enums, date, time and number types and non-data types (reflection objects such as <see cref="Type"/>, delegates, streams, tasks, threads,
    /// wait handles, cancellation tokens, safe handles, pointers) are not walked into.</description></item>
    /// <item><description>A property whose getter throws is skipped; an exception thrown by a setter propagates.</description></item>
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
    /// otherwise a new <typeparamref name="T"/>. The readable and writable public instance properties of that type (inherited ones included, indexers excluded)
    /// are copied; reference values are shared, not cloned. For a value type, the value itself is returned, since assigning a struct already copies all of its fields.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Copy<T>(this T input) where T : new() => input.CopyImplement();
}
