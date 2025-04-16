using System.Diagnostics;
using YANLib.Implementation.Object;

namespace YANLib.Object;

/// <summary>
/// Provides extension methods for evaluating the states of object properties,
/// including determining whether properties are set to default values, non-default values,
/// or a combination of both across single objects or collections.
/// </summary>
public static partial class YANObject
{
    #region AllPropertiesNotDefault
    /// <summary>
    /// Determines whether all properties of the specified object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if all properties are not set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefault<T>(this T? input) where T : class => input.AllPropertiesNotDefaultImplement();

    /// <summary>
    /// Determines whether all elements in the specified collection have all properties not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements have all properties not set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AllPropertiesNotDefaultsImplement();

    /// <summary>
    /// Determines whether all elements in the specified array have all properties not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements have all properties not set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(params T?[]? input) where T : class => input.AllPropertiesNotDefaultsImplement();

    /// <summary>
    /// Determines whether all specified properties of an object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if all specified properties are not set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesNotDefaultImplement(names);

    /// <summary>
    /// Determines whether all elements in the specified collection have the specified properties not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if all elements have the specified properties not set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesNotDefaultsImplement(names);

    /// <summary>
    /// Determines whether all specified properties of an object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if all specified properties are not set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefault<T>(this T? input, params string?[]? names) where T : class => input.AllPropertiesNotDefaultImplement(names);

    /// <summary>
    /// Determines whether all elements in the specified collection have the specified properties not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if all elements have the specified properties not set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AllPropertiesNotDefaultsImplement(names);
    #endregion

    #region AllPropertiesDefault
    /// <summary>
    /// Determines whether all properties of the specified object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if all properties are set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefault<T>(this T? input) where T : class => input.AllPropertiesDefaultImplement();

    /// <summary>
    /// Determines whether all elements in the specified collection have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements have all properties set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AllPropertiesDefaultsImplement();

    /// <summary>
    /// Determines whether all elements in the specified array have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements have all properties set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(params T?[]? input) where T : class => input.AllPropertiesDefaultsImplement();

    /// <summary>
    /// Determines whether all specified properties of an object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if all specified properties are set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesDefaultImplement(names);

    /// <summary>
    /// Determines whether all elements in the specified collection have the specified properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if all elements have the specified properties set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesDefaultsImplement(names);

    /// <summary>
    /// Determines whether all specified properties of an object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if all specified properties are set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefault<T>(this T? input, params string?[]? names) where T : class => input.AllPropertiesDefaultImplement(names);

    /// <summary>
    /// Determines whether all elements in the specified collection have the specified properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if all elements have the specified properties set to their default values; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AllPropertiesDefaultsImplement(names);
    #endregion

    #region AnyPropertiesNotDefault
    /// <summary>
    /// Determines whether any properties of the specified object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if at least one property is not set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefault<T>(this T? input) where T : class => input.AnyPropertiesNotDefaultImplement();

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one property that is not set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element has a property that is not set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AnyPropertiesNotDefaultsImplement();

    /// <summary>
    /// Determines whether any elements in the specified array have at least one property that is not set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element has a property that is not set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(params T?[]? input) where T : class => input.AnyPropertiesNotDefaultsImplement();

    /// <summary>
    /// Determines whether any specified properties of an object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if at least one specified property is not set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesNotDefaultImplement(names);

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one of the specified properties that is not set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if at least one element has a specified property that is not set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesNotDefaultsImplement(names);

    /// <summary>
    /// Determines whether any specified properties of an object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if at least one specified property is not set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefault<T>(this T? input, params string?[]? names) where T : class => input.AnyPropertiesNotDefaultImplement(names);

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one of the specified properties that is not set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if at least one element has a specified property that is not set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AnyPropertiesNotDefaultsImplement(names);
    #endregion

    #region AnyPropertiesDefault
    /// <summary>
    /// Determines whether any properties of the specified object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if at least one property is set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefault<T>(this T? input) where T : class => input.AnyPropertiesDefaultImplement();

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one property set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element has a property set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AnyPropertiesDefaultsImplement();

    /// <summary>
    /// Determines whether any elements in the specified array have at least one property set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element has a property set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(params T?[]? input) where T : class => input.AnyPropertiesDefaultsImplement();

    /// <summary>
    /// Determines whether any specified properties of an object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if at least one specified property is set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesDefaultImplement(names);

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one of the specified properties set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if at least one element has a specified property set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesDefaultsImplement(names);

    /// <summary>
    /// Determines whether any specified properties of an object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if at least one specified property is set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefault<T>(this T? input, params string?[]? names) where T : class => input.AnyPropertiesDefaultImplement(names);

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one of the specified properties set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if at least one element has a specified property set to its default value; otherwise, <see langword="false"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AnyPropertiesDefaultsImplement(names);
    #endregion
}
