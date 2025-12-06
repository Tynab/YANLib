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
    /// For string properties, this means they are <c>null</c> or empty.
    /// For reference type properties, this means they are <c>null</c>.
    /// For value type properties, this means they have their default value (e.g., 0 for numeric types, false for bool).
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
    /// For string properties, this means they are not <c>null</c> and not empty.
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
    /// Changes the time zone of all <see cref="DateTime"/> properties in the specified object.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to process. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="tzSrc">The source time zone offset. If <c>null</c>, no conversion is performed.</param>
    /// <param name="tzDst">The destination time zone offset. If <c>null</c>, no conversion is performed.</param>
    /// <returns>The object with all <see cref="DateTime"/> properties converted to the destination time zone.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? ChangeTimeZoneAllProperty<T>(this T? input, object? tzSrc = null, object? tzDst = null) where T : class => input.ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst);

    /// <summary>
    /// Creates a shallow copy of the specified object.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to copy. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A new object with the same property values as the input object.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Copy<T>(this T input) where T : new() => input.CopyImplement();
}
