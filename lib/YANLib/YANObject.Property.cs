using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for property-based object operations and validation.
/// </summary>
/// <remarks>
/// This partial class extends <see cref="YANObject"/> with methods for working with object properties.
/// It includes methods for checking if properties have default values, if all or any properties meet certain conditions,
/// and for working with specific named properties of objects and collections.
/// </remarks>
public static partial class YANObject
{
    #region Valid Field

    /// <summary>
    /// Determines whether the specified string represents a valid field (property) name for type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The target type to validate the field against.</typeparam>
    /// <param name="input">The string to validate. May contain additional tokens separated by spaces; the first token is used as the property name.</param>
    /// <returns><c>true</c> if the string corresponds to an existing public instance property on <typeparamref name="T"/>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsValidField<T>(this string? input) where T : class => input.IsValidFieldImplement<T>();

    /// <summary>
    /// Determines whether all strings in the specified sequence represent valid field (property) names for type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The target type to validate the fields against.</typeparam>
    /// <param name="input">The sequence of strings to validate. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if every string corresponds to an existing public instance property on <typeparamref name="T"/>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllValidFields<T>(this IEnumerable<string?>? input) where T : class => input.AllValidFieldsImplement<T>();

    /// <summary>
    /// Determines whether any string in the specified sequence represents a valid field (property) name for type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The target type to validate the fields against.</typeparam>
    /// <param name="input">The sequence of strings to validate. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if at least one string corresponds to an existing public instance property on <typeparamref name="T"/>; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyValidField<T>(this IEnumerable<string?>? input) where T : class => input.AnyValidFieldImplement<T>();

    #endregion

    #region AllPropertiesDefault

    /// <summary>
    /// Determines whether all properties of the specified object have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all properties have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefault<T>(this T? input) where T : class => input.AllPropertiesDefaultImplement();

    /// <summary>
    /// Determines whether all properties of all objects in the specified collection have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all properties of all objects have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AllPropertiesDefaultsImplement();

    /// <summary>
    /// Determines whether all properties of all objects in the specified array have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the array.</typeparam>
    /// <param name="input">The array of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all properties of all objects have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(params T?[]? input) where T : class => input.AllPropertiesDefaultsImplement();

    /// <summary>
    /// Determines whether all specified properties of the object have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all specified properties have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesDefaultImplement(names);

    /// <summary>
    /// Determines whether all specified properties of all objects in the collection have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all specified properties of all objects have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesDefaultsImplement(names);

    /// <summary>
    /// Determines whether all specified properties of the object have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all specified properties have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefault<T>(this T? input, params string?[]? names) where T : class => input.AllPropertiesDefaultImplement(names);

    /// <summary>
    /// Determines whether all specified properties of all objects in the collection have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all specified properties of all objects have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AllPropertiesDefaultsImplement(names);

    #endregion

    #region AllPropertiesNotDefault

    /// <summary>
    /// Determines whether all properties of the specified object do not have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all properties do not have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefault<T>(this T? input) where T : class => input.AllPropertiesNotDefaultImplement();

    /// <summary>
    /// Determines whether all properties of all objects in the specified collection do not have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all properties of all objects do not have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AllPropertiesNotDefaultsImplement();

    /// <summary>
    /// Determines whether all properties of all objects in the specified array do not have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the array.</typeparam>
    /// <param name="input">The array of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all properties of all objects do not have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(params T?[]? input) where T : class => input.AllPropertiesNotDefaultsImplement();

    /// <summary>
    /// Determines whether all specified properties of the object do not have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all specified properties do not have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesNotDefaultImplement(names);

    /// <summary>
    /// Determines whether all specified properties of all objects in the collection do not have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all specified properties of all objects do not have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesNotDefaultsImplement(names);

    /// <summary>
    /// Determines whether all specified properties of the object do not have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all specified properties do not have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefault<T>(this T? input, params string?[]? names) where T : class => input.AllPropertiesNotDefaultImplement(names);

    /// <summary>
    /// Determines whether all specified properties of all objects in the collection do not have their default values.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if all specified properties of all objects do not have their default values; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AllPropertiesNotDefaultsImplement(names);

    #endregion

    #region AnyPropertiesDefault

    /// <summary>
    /// Determines whether any property of the specified object has its default value.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any property has its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefault<T>(this T? input) where T : class => input.AnyPropertiesDefaultImplement();

    /// <summary>
    /// Determines whether any property of any object in the specified collection has its default value.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any property of any object has its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AnyPropertiesDefaultsImplement();

    /// <summary>
    /// Determines whether any property of any object in the specified array has its default value.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the array.</typeparam>
    /// <param name="input">The array of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any property of any object has its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(params T?[]? input) where T : class => input.AnyPropertiesDefaultsImplement();

    /// <summary>
    /// Determines whether any of the specified properties of the object has its default value.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any of the specified properties has its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesDefaultImplement(names);

    /// <summary>
    /// Determines whether any of the specified properties of any object in the collection has its default value.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any of the specified properties of any object has its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesDefaultsImplement(names);

    /// <summary>
    /// Determines whether any of the specified properties of the object has its default value.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any of the specified properties has its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefault<T>(this T? input, params string?[]? names) where T : class => input.AnyPropertiesDefaultImplement(names);

    /// <summary>
    /// Determines whether any of the specified properties of any object in the collection has its default value.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any of the specified properties of any object has its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AnyPropertiesDefaultsImplement(names);

    #endregion

    #region AnyPropertiesNotDefault

    /// <summary>
    /// Determines whether any property of the specified object does not have its default value.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any property does not have its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefault<T>(this T? input) where T : class => input.AnyPropertiesNotDefaultImplement();

    /// <summary>
    /// Determines whether any property of any object in the specified collection does not have its default value.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any property of any object does not have its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AnyPropertiesNotDefaultsImplement();

    /// <summary>
    /// Determines whether any property of any object in the specified array does not have its default value.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the array.</typeparam>
    /// <param name="input">The array of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any property of any object does not have its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(params T?[]? input) where T : class => input.AnyPropertiesNotDefaultsImplement();

    /// <summary>
    /// Determines whether any of the specified properties of the object does not have its default value.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any of the specified properties does not have its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesNotDefaultImplement(names);

    /// <summary>
    /// Determines whether any of the specified properties of any object in the collection does not have its default value.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any of the specified properties of any object does not have its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesNotDefaultsImplement(names);

    /// <summary>
    /// Determines whether any of the specified properties of the object does not have its default value.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check. If <c>null</c>, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any of the specified properties does not have its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefault<T>(this T? input, params string?[]? names) where T : class => input.AnyPropertiesNotDefaultImplement(names);

    /// <summary>
    /// Determines whether any of the specified properties of any object in the collection does not have its default value.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to check. If <c>null</c> or empty, returns <c>false</c>.</param>
    /// <param name="names">The names of the properties to check. If <c>null</c>, empty, or contains only whitespace, returns <c>false</c>.</param>
    /// <returns><c>true</c> if any of the specified properties of any object does not have its default value; otherwise, <c>false</c>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AnyPropertiesNotDefaultsImplement(names);

    #endregion
}
