using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANObject
{
    #region Null

    /// <summary>
    /// Determines whether the specified object is <c>null</c>.
    /// </summary>
    /// <param name="input">The object to check.</param>
    /// <returns><c>true</c> if the object is <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNull([NotNullWhen(false)] this object? input) => input.IsNullImplement();

    /// <summary>
    /// Determines whether the specified object is not <c>null</c>.
    /// </summary>
    /// <param name="input">The object to check.</param>
    /// <returns><c>true</c> if the object is not <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNull([NotNullWhen(true)] this object? input) => input.IsNotNullImplement();

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
