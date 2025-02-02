using System.Collections;
using System.Diagnostics.CodeAnalysis;
using static System.Reflection.BindingFlags;

namespace YANLib.Object;

public static partial class YANObject
{
    /// <summary>
    /// Checks if the specified object is <see langword="null"/>.
    /// </summary>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if the object is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNull([NotNullWhen(false)] this object? input) => input is null;

    /// <summary>
    /// Checks if the specified object is not <see langword="null"/>.
    /// </summary>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if the object is not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNull([NotNullWhen(true)] this object? input) => input is not null;

    /// <summary>
    /// Checks if a collection is <see langword="null"/> or empty.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if the collection is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? input) => input.IsNull() || !input.Any();

    /// <summary>
    /// Checks if a collection is not <see langword="null"/> and contains elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if the collection is not <see langword="null"/> and contains elements; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? input) => input.IsNotNull() && input.Any();

    /// <summary>
    /// Determines whether all elements in a collection are <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AllNull<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNotNull());

    /// <summary>
    /// Determines whether all elements in the specified array are <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AllNull<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNotNull());

    /// <summary>
    /// Determines whether all elements in the specified collection are <see langword="null"/> or have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/> or have default properties; otherwise, <see langword="false"/>.</returns>
    public static bool AllNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNotNull() && x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether all elements in the specified array are <see langword="null"/> or have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/> or have default properties; otherwise, <see langword="false"/>.</returns>
    public static bool AllNullEmpty<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNotNull() && x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether any element in a collection is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNull<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNull());

    /// <summary>
    /// Determines whether at least one element in the specified array is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element is <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNull<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNull());

    /// <summary>
    /// Determines whether any element in the specified collection is <see langword="null"/> or has all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element is <see langword="null"/> or has default properties; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNull() || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether any element in the specified array is <see langword="null"/> or has all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element is <see langword="null"/> or has default properties; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNullEmpty<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNull() || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether all elements in the specified collection are not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNull<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNull());

    /// <summary>
    /// Determines whether all elements in the specified array are not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements are not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNull<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNull());

    /// <summary>
    /// Determines whether all elements in the specified collection are not <see langword="null"/> and do not have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements are not <see langword="null"/> and have at least one non-default property; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNull() || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether all elements in the specified array are not <see langword="null"/> and do not have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements are not <see langword="null"/> and have at least one non-default property; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNullEmpty<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNull() || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether at least one element in the specified collection is not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element is not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNull<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNotNull());

    /// <summary>
    /// Determines whether at least one element in the specified array is not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element is not <see langword="null"/>; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNull<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNotNull());

    /// <summary>
    /// Determines whether at least one element in the specified collection is not <see langword="null"/> or has properties that are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element is not <see langword="null"/> or has properties that are not set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNotNull() || x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether at least one element in the specified array is not <see langword="null"/> or has properties that are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element is not <see langword="null"/> or has properties that are not set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNullEmpty<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNotNull() || x.AnyPropertiesNotDefault());

    /// <summary>
    /// Creates a <see cref="List{T}"/> containing a single element.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <param name="input">The element to be added to the list.</param>
    /// <returns>A list containing the specified element.</returns>
    public static List<T> AsList<T>(this T input) => [input];

    /// <summary>
    /// Creates a <see cref="HashSet{T}"/> containing a single element.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <param name="input">The element to be added to the hash set.</param>
    /// <returns>A hash set containing the specified element.</returns>
    public static HashSet<T> AsHashSet<T>(this T input) => [input];

    /// <summary>
    /// Creates an array containing a single element.
    /// </summary>
    /// <typeparam name="T">The type of the element.</typeparam>
    /// <param name="input">The element to be added to the array.</param>
    /// <returns>An array containing the specified element.</returns>
    public static T[] AsArray<T>(this T input) => [input];

    /// <summary>
    /// Creates a copy of an object by copying its properties.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to copy.</param>
    /// <returns>A new object with the same values as the input object.</returns>
    public static T Copy<T>(this T input) where T : new()
    {
        if (input.IsNull())
        {
            return input;
        }

        var result = new T();
        var props = input.GetType().GetProperties(Public | Instance);

        foreach (var prop in props)
        {
            if (prop.CanRead && prop.CanWrite)
            {
                var val = prop.GetValue(input);

                prop.SetValue(result, val);
            }
        }

        return result;
    }

    /// <summary>
    /// Adjusts all <see cref="DateTime"/> properties of an object to a specified time zone.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object containing date-time properties.</param>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <returns>The updated object with adjusted time zones.</returns>
    public static T? ChangeTimeZoneAllProperty<T>(this T? input, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (input.IsNull())
        {
            return input;
        }

        if (input is IList list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].IsNotNull())
                {
                    var updatedItem = list[i].ChangeTimeZoneAllProperty(tzSrc, tzDst);

                    if (updatedItem.IsNotNull())
                    {
                        list[i] = updatedItem;
                    }
                }
            }

            return input;
        }

        var props = input.GetType().GetProperties(Public | Instance).Where(x => x.CanRead && x.CanWrite);

        foreach (var prop in props)
        {
            if (prop.IsNull())
            {
                continue;
            }

            var val = prop.GetValue(input);

            if (val.IsNull())
            {
                continue;
            }

            if (val is DateTime dt)
            {
                prop.SetValue(input, dt.ChangeTimeZone(tzSrc, tzDst));
            }
            else
            {
                var updated = val.ChangeTimeZoneAllProperty(tzSrc, tzDst);

                if (updated.IsNotNull())
                {
                    prop.SetValue(input, updated);
                }
            }
        }

        return input;
    }

    /// <summary>
    /// Adjusts all <see cref="DateTime"/> properties of objects within a collection to a specified time zone.
    /// </summary>
    /// <typeparam name="T">The type of objects in the collection.</typeparam>
    /// <param name="input">The collection of objects containing date-time properties.</param>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <returns>A collection of objects with adjusted time zones. Returns <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) where T : class => input.IsNullEmpty() ? input : input.Select(x => x.ChangeTimeZoneAllProperty(tzSrc, tzDst));
}
