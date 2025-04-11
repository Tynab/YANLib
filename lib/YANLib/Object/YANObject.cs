using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation.Object;

namespace YANLib.Object;

public static partial class YANObject
{
    #region Is
    /// <summary>
    /// Checks if the specified object is <see langword="null"/>.
    /// </summary>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if the object is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNull([NotNullWhen(false)] this object? input) => input.IsNullImplement();

    /// <summary>
    /// Checks if the specified object is not <see langword="null"/>.
    /// </summary>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if the object is not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNull([NotNullWhen(true)] this object? input) => input.IsNotNullImplement();

    /// <summary>
    /// Checks if a collection is <see langword="null"/> or empty.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if the collection is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? input) => input.IsNullEmptyImplement();

    /// <summary>
    /// Checks if a collection is not <see langword="null"/> and contains elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if the collection is not <see langword="null"/> and contains elements; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? input) => input.IsNotNullEmptyImplement();
    #endregion

    #region All
    /// <summary>
    /// Determines whether all elements in a collection are <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull<T>(this IEnumerable<T?>? input) where T : class => input.AllNullImplement();

    /// <summary>
    /// Determines whether all elements in the specified array are <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull<T>(params T?[]? input) where T : class => input.AllNullImplement();

    /// <summary>
    /// Determines whether all elements in the specified collection are <see langword="null"/> or have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/> or have default properties; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AllNullEmptyImplement();

    /// <summary>
    /// Determines whether all elements in the specified array are <see langword="null"/> or have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/> or have default properties; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty<T>(params T?[]? input) where T : class => input.AllNullEmptyImplement();

    /// <summary>
    /// Determines whether all elements in the specified collection are not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull<T>(this IEnumerable<T?>? input) where T : class => input.AllNotNullImplement();

    /// <summary>
    /// Determines whether all elements in the specified array are not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull<T>(params T?[]? input) where T : class => input.AllNotNullImplement();

    /// <summary>
    /// Determines whether all elements in the specified collection are not <see langword="null"/> and do not have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements are not <see langword="null"/> and have at least one non-default property; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AllNotNullEmptyImplement();

    /// <summary>
    /// Determines whether all elements in the specified array are not <see langword="null"/> and do not have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements are not <see langword="null"/> and have at least one non-default property; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty<T>(params T?[]? input) where T : class => input.AllNotNullEmptyImplement();
    #endregion

    #region Any
    /// <summary>
    /// Determines whether any element in a collection is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull<T>(this IEnumerable<T?>? input) where T : class => input.AnyNullImplement();

    /// <summary>
    /// Determines whether at least one element in the specified array is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull<T>(params T?[]? input) where T : class => input.AnyNullImplement();

    /// <summary>
    /// Determines whether any element in the specified collection is <see langword="null"/> or has all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element is <see langword="null"/> or has default properties; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AnyNullEmptyImplement();

    /// <summary>
    /// Determines whether any element in the specified array is <see langword="null"/> or has all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element is <see langword="null"/> or has default properties; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty<T>(params T?[]? input) where T : class => input.AnyNullEmptyImplement();

    /// <summary>
    /// Determines whether at least one element in the specified collection is not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element is not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull<T>(this IEnumerable<T?>? input) where T : class => input.AnyNotNullImplement();

    /// <summary>
    /// Determines whether at least one element in the specified array is not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element is not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull<T>(params T?[]? input) where T : class => input.AnyNotNullImplement();

    /// <summary>
    /// Determines whether at least one element in the specified collection is not <see langword="null"/> or has properties that are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element is not <see langword="null"/> or has properties that are not set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AnyNotNullEmptyImplement();

    /// <summary>
    /// Determines whether at least one element in the specified array is not <see langword="null"/> or has properties that are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element is not <see langword="null"/> or has properties that are not set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty<T>(params T?[]? input) where T : class => input.AnyNotNullEmptyImplement();
    #endregion

    #region DateTimeZone
    /// <summary>
    /// Adjusts all <see cref="DateTime"/> properties of an object to a specified time zone.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object containing date-time properties.</param>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <returns>The updated object with adjusted time zones.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? ChangeTimeZoneAllProperty<T>(this T? input, object? tzSrc = null, object? tzDst = null) where T : class => input.ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst);

    /// <summary>
    /// Adjusts all <see cref="DateTime"/> properties of objects within a collection to a specified time zone.
    /// </summary>
    /// <typeparam name="T">The type of objects in the collection.</typeparam>
    /// <param name="input">The collection of objects containing date-time properties.</param>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <returns>A collection of objects with adjusted time zones. Returns <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) where T : class => input.ChangeTimeZoneAllPropertiesImplement(tzSrc, tzDst);
    #endregion

    /// <summary>
    /// Creates a copy of an object by copying its properties.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to copy.</param>
    /// <returns>A new object with the same values as the input object.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Copy<T>(this T input) where T : new() => input.CopyImplement();

    /// <summary>
    /// Gets the count of elements in the specified enumerable collection.
    /// Optimized to use the most efficient counting method based on the collection type.
    /// </summary>
    /// <param name="input">The enumerable collection to count. Can be <see langword="null"/>.</param>
    /// <returns>The number of elements in the collection, or 0 if the collection is <see langword="null"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int GetCount(this IEnumerable? input) => input.GetCountImplement();
}
