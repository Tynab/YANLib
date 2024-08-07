using System.Collections;
using System.Diagnostics.CodeAnalysis;
using static System.Reflection.BindingFlags;

namespace YANLib.Core;

public static partial class YANObject
{
    public static bool IsNull([NotNullWhen(false)] this object? obj) => obj is null;

    public static bool IsNotNull([NotNullWhen(true)] this object? obj) => obj is not null;

    /// <summary>
    /// Determines whether the specified IEnumerable collection is <see langword="null"/> or contains no elements.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the collection is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmptyOrNull<T>([NotNullWhen(false)] this IEnumerable<T>? srcs) => srcs.IsNull() || !srcs.Any();

    /// <summary>
    /// Determines whether the specified ICollection collection is <see langword="null"/> or contains no elements.
    /// </summary>
    /// <param name="srcs">The ICollection collection to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the collection is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmptyOrNull<T>([NotNullWhen(false)] this ICollection<T>? srcs) => srcs.IsNull() || srcs.Count is 0;

    /// <summary>
    /// Determines whether the specified array is <see langword="null"/> or contains no elements.
    /// </summary>
    /// <param name="srcs">The array to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the array is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmptyOrNull<T>([NotNullWhen(false)] params T[]? srcs) => srcs.IsNull() || srcs.Length is 0;

    /// <summary>
    /// Determines whether the specified IEnumerable collection is not <see langword="null"/> and contains at least one element.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the collection is not <see langword="null"/> and not empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyAndNull<T>([NotNullWhen(true)] this IEnumerable<T>? srcs) => srcs.IsNotNull() && srcs.Any();

    /// <summary>
    /// Determines whether the specified ICollection collection is not <see langword="null"/> and contains at least one element.
    /// </summary>
    /// <param name="srcs">The ICollection collection to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the collection is not <see langword="null"/> and not empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyAndNull<T>([NotNullWhen(true)] this ICollection<T>? srcs) => srcs.IsNotNull() && srcs.Count is not 0;

    /// <summary>
    /// Determines whether the specified array is not <see langword="null"/> and contains at least one element.
    /// </summary>
    /// <param name="srcs">The array to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the array is not <see langword="null"/> and not empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyAndNull<T>([NotNullWhen(true)] params T[]? srcs) => srcs.IsNotNull() && srcs.Length is not 0;

    public static bool AllNull<T>(this IEnumerable<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNotNull());

    public static bool AllNull<T>(this ICollection<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNotNull());

    public static bool AllNull<T>(params T[]? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNotNull());

    /// <summary>
    /// Determines whether all elements in the specified IEnumerable collection of class type are either <see langword="null"/> or have all properties set to default values.
    /// Returns <see langword="true"/> only if the collection is not <see langword="null"/>, not empty, and all elements are <see langword="null"/> or have default property values.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/> or have default property values; otherwise, <see langword="false"/>.</returns>
    public static bool AllEmptyOrNull<T>(this IEnumerable<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNotNull() || x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether all elements in the specified ICollection collection of class type are either <see langword="null"/> or have all properties set to default values.
    /// Returns <see langword="true"/> only if the collection is not <see langword="null"/>, not empty, and all elements are <see langword="null"/> or have default property values.
    /// </summary>
    /// <param name="srcs">The ICollection collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/> or have default property values; otherwise, <see langword="false"/>.</returns>
    public static bool AllEmptyOrNull<T>(this ICollection<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNotNull() || x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether all elements in the specified array of class type are either <see langword="null"/> or have all properties set to default values.
    /// Returns <see langword="true"/> only if the array is not <see langword="null"/>, not empty, and all elements are <see langword="null"/> or have default property values.
    /// </summary>
    /// <param name="srcs">The array of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/> or have default property values; otherwise, <see langword="false"/>.</returns>
    public static bool AllEmptyOrNull<T>(params T[]? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNotNull() || x.AnyPropertiesNotDefault());

    public static bool AnyNull<T>(this IEnumerable<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x.IsNull());

    public static bool AnyNull<T>(this ICollection<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x.IsNull());

    public static bool AnyNull<T>(params T[]? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x.IsNull());

    /// <summary>
    /// Determines whether any element in the specified IEnumerable collection of class type is either <see langword="null"/> or has all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and any element is <see langword="null"/> or has default property values.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEmptyOrNull<T>(this IEnumerable<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x.IsNull() || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether any element in the specified ICollection collection of class type is either <see langword="null"/> or has all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and any element is <see langword="null"/> or has default property values.
    /// </summary>
    /// <param name="srcs">The ICollection collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEmptyOrNull<T>(this ICollection<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x.IsNull() || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether any element in the specified array of class type is either <see langword="null"/> or has all properties set to default values.
    /// Returns <see langword="true"/> if the array is not <see langword="null"/>, not empty, and any element is <see langword="null"/> or has default property values.
    /// </summary>
    /// <param name="srcs">The array of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEmptyOrNull<T>(params T[]? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x.IsNull() || x.AllPropertiesDefault());

    public static bool AllNotNull<T>(this IEnumerable<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNull());

    public static bool AllNotNull<T>(this ICollection<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNull());

    public static bool AllNotNull<T>(params T[]? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNull());

    /// <summary>
    /// Determines whether all elements in the specified IEnumerable collection of class type are not <see langword="null"/> and do not have all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and no element is <see langword="null"/> or has all properties set to default values.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if no element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEmptyAndNull<T>(this IEnumerable<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNull() || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether all elements in the specified ICollection collection of class type are not <see langword="null"/> and do not have all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and no element is <see langword="null"/> or has all properties set to default values.
    /// </summary>
    /// <param name="srcs">The ICollection collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if no element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEmptyAndNull<T>(this ICollection<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNull() || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether all elements in the specified array of class type are not <see langword="null"/> and do not have all properties set to default values.
    /// Returns <see langword="true"/> if the array is not <see langword="null"/>, not empty, and no element is <see langword="null"/> or has all properties set to default values.
    /// </summary>
    /// <param name="srcs">The array of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if no element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEmptyAndNull<T>(params T[]? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x.IsNull() || x.AllPropertiesDefault());

    public static bool AnyNotNull<T>(this IEnumerable<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x.IsNotNull());

    /// <summary>
    /// Determines whether any element in the specified IEnumerable collection of class type is not <see langword="null"/> or does not have all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and any element is not <see langword="null"/> or does not have all properties set to default values.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is not <see langword="null"/> or does not have all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEmptyAndNull<T>(this IEnumerable<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x.IsNotNull() || x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether any element in the specified ICollection collection of class type is not <see langword="null"/> or does not have all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and any element is not <see langword="null"/> or does not have all properties set to default values.
    /// </summary>
    /// <param name="srcs">The ICollection collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is not <see langword="null"/> or does not have all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEmptyAndNull<T>(this ICollection<T>? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x.IsNotNull() || x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether any element in the specified array of class type is not <see langword="null"/> or does not have all properties set to default values.
    /// Returns <see langword="true"/> if the array is not <see langword="null"/>, not empty, and any element is not <see langword="null"/> or does not have all properties set to default values.
    /// </summary>
    /// <param name="srcs">The array of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is not <see langword="null"/> or does not have all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEmptyAndNull<T>(params T[]? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x.IsNotNull() || x.AnyPropertiesNotDefault());

    public static List<T> AsList<T>(this T obj) => [obj];

    public static HashSet<T> AsHashSet<T>(this T obj) => [obj];

    public static T[] AsArray<T>(this T obj) => [obj];

    public static T Copy<T>(this T src) where T : new()
    {
        if (src.IsNull())
        {
            return src;
        }

        var rslt = new T();
        var props = typeof(T).GetProperties(Public | Instance);

        foreach (var prop in props)
        {
            if (prop.CanRead && prop.CanWrite)
            {
                var val = prop.GetValue(src);

                prop.SetValue(rslt, val);
            }
        }

        return rslt;
    }

    public static T? ChangeTimeZoneAllProperty<T>(this T? obj, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (obj.IsNull())
        {
            return obj;
        }

        var props = typeof(T).GetProperties(Public | Instance).Where(x => x.CanRead && x.CanWrite);

        if (props.Any())
        {
            foreach (var prop in props)
            {
                if (prop.IsNull())
                {
                    continue;
                }

                var val = prop.GetValue(obj);

                if (val.IsNull())
                {
                    continue;
                }

                if (val is DateTime dt)
                {
                    prop.SetValue(obj, dt.ChangeTimeZone(tzSrc, tzDst));
                }
                else if (val.GetType().IsClass)
                {
                    var chgedVal = ChangeTimeZoneAllProperty(val, tzSrc, tzDst);

                    if (chgedVal.IsNotNull())
                    {
                        prop.SetValue(obj, chgedVal);
                    }
                }
                else if (val.GetType().IsGenericType && val.GetType().GetGenericTypeDefinition() == typeof(IList<>))
                {
                    var list = (IList)val;

                    if (list.Count is not 0)
                    {
                        for (var i = 0; i < list.Count; i++)
                        {
                            if (list[i].IsNull())
                            {
                                continue;
                            }

                            var chgedItem = ChangeTimeZoneAllProperty(list[i], tzSrc, tzDst);

                            if (chgedItem.IsNotNull())
                            {
                                list[i] = chgedItem;
                            }
                        }
                    }
                }
            }
        }

        return obj;
    }

    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this IEnumerable<T?>? objs, object? tzSrc = null, object? tzDst = null) where T : class => objs.IsEmptyOrNull()
        ? objs
        : objs.Select(x => x.ChangeTimeZoneAllProperty(tzSrc, tzDst));

    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this ICollection<T?>? objs, object? tzSrc = null, object? tzDst = null) where T : class => objs.IsEmptyOrNull()
        ? objs
        : objs.Select(x => x.ChangeTimeZoneAllProperty(tzSrc, tzDst));

    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this T?[]? objs, object? tzSrc = null, object? tzDst = null) where T : class => objs.IsEmptyOrNull()
        ? objs
        : objs.Select(x => x.ChangeTimeZoneAllProperty(tzSrc, tzDst));
}
