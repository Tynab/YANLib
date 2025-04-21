using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation.Object;

namespace YANLib.Object;

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
    /// Determines whether all elements in the specified collection are <c>null</c>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements are <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull<T>(this IEnumerable<T?>? input) => input.AllNullImplement();

    /// <summary>
    /// Determines whether all elements in the specified array are <c>null</c>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements are <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull<T>(params T?[]? input) => input.AllNullImplement();

    /// <summary>
    /// Determines whether any element in the specified collection is <c>null</c>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element is <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull<T>(this IEnumerable<T?>? input) => input.AnyNullImplement();

    /// <summary>
    /// Determines whether any element in the specified array is <c>null</c>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element is <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull<T>(params T?[]? input) => input.AnyNullImplement();

    /// <summary>
    /// Determines whether the specified object is not <c>null</c>.
    /// </summary>
    /// <param name="input">The object to check.</param>
    /// <returns><c>true</c> if the object is not <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNull([NotNullWhen(true)] this object? input) => input.IsNotNullImplement();

    /// <summary>
    /// Determines whether all elements in the specified collection are not <c>null</c>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements are not <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull<T>(this IEnumerable<T?>? input) => input.AllNotNullImplement();

    /// <summary>
    /// Determines whether all elements in the specified array are not <c>null</c>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements are not <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull<T>(params T?[]? input) => input.AllNotNullImplement();

    /// <summary>
    /// Determines whether any element in the specified collection is not <c>null</c>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element is not <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull<T>(this IEnumerable<T?>? input) => input.AnyNotNullImplement();

    /// <summary>
    /// Determines whether any element in the specified array is not <c>null</c>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element is not <c>null</c>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull<T>(params T?[]? input) => input.AnyNotNullImplement();

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
    /// Determines whether all elements in the specified collection have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllDefault<T>(this IEnumerable<T?>? input) => input.AllDefaultImplement();

    /// <summary>
    /// Determines whether all elements in the specified array have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllDefault<T>(params T?[]? input) => input.AllDefaultImplement();

    /// <summary>
    /// Determines whether any element in the specified collection has its default value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element has its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyDefault<T>(this IEnumerable<T?>? input) => input.AnyDefaultImplement();

    /// <summary>
    /// Determines whether any element in the specified array has its default value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element has its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyDefault<T>(params T?[]? input) => input.AnyDefaultImplement();

    /// <summary>
    /// Determines whether the specified value is not the default value for its type.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="input">The value to check.</param>
    /// <returns><c>true</c> if the value is not the default value for its type; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotDefault<T>(this T input) => input.IsNotDefaultImplement();

    /// <summary>
    /// Determines whether all elements in the specified collection do not have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements do not have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotDefault<T>(this IEnumerable<T?>? input) => input.AllNotDefaultImplement();

    /// <summary>
    /// Determines whether all elements in the specified array do not have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements do not have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotDefault<T>(params T?[]? input) => input.AllNotDefaultImplement();

    /// <summary>
    /// Determines whether any element in the specified collection does not have its default value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element does not have its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotDefault<T>(this IEnumerable<T?>? input) => input.AnyNotDefaultImplement();

    /// <summary>
    /// Determines whether any element in the specified array does not have its default value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element does not have its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotDefault<T>(params T?[]? input) => input.AnyNotDefaultImplement();

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
    /// Determines whether all elements in the specified collection are <c>null</c> or empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements are <c>null</c> or empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AllNullEmptyImplement();

    /// <summary>
    /// Determines whether all elements in the specified array are <c>null</c> or empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements are <c>null</c> or empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty<T>(params T?[]? input) where T : class => input.AllNullEmptyImplement();

    /// <summary>
    /// Determines whether any element in the specified collection is <c>null</c> or empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element is <c>null</c> or empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AnyNullEmptyImplement();

    /// <summary>
    /// Determines whether any element in the specified array is <c>null</c> or empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element is <c>null</c> or empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty<T>(params T?[]? input) where T : class => input.AnyNullEmptyImplement();

    /// <summary>
    /// Determines whether the specified collection is not <c>null</c> and not empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><c>true</c> if the collection is not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? input) => input.IsNotNullEmptyImplement();

    /// <summary>
    /// Determines whether all elements in the specified collection are not <c>null</c> and not empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements are not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AllNotNullEmptyImplement();

    /// <summary>
    /// Determines whether all elements in the specified array are not <c>null</c> and not empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all elements are not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty<T>(params T?[]? input) where T : class => input.AllNotNullEmptyImplement();

    /// <summary>
    /// Determines whether any element in the specified collection is not <c>null</c> and not empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element is not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AnyNotNullEmptyImplement();

    /// <summary>
    /// Determines whether any element in the specified array is not <c>null</c> and not empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any element is not <c>null</c> and not empty; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty<T>(params T?[]? input) where T : class => input.AnyNotNullEmptyImplement();

    #endregion

    #region DateTimeZone

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
    /// Changes the time zone of all <see cref="DateTime"/> properties in all objects in the specified collection.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to process. If <c>null</c> or empty, returns the input collection.</param>
    /// <param name="tzSrc">The source time zone offset. If <c>null</c>, no conversion is performed.</param>
    /// <param name="tzDst">The destination time zone offset. If <c>null</c>, no conversion is performed.</param>
    /// <returns>A new collection containing the objects with all <see cref="DateTime"/> properties converted to the destination time zone.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) where T : class => input.ChangeTimeZoneAllPropertiesImplement(tzSrc, tzDst);

    #endregion

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
