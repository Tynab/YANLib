using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANObject
{
    /// <summary>
    /// Changes the time zone of all <see cref="DateTime"/> properties and nested class properties within each object in a collection.
    /// This method recursively adjusts <see cref="DateTime"/> properties and iterates through collections to apply the time zone change.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <typeparam name="T">The class type of the objects in the collection whose properties are to be modified. Must be a class type.</typeparam>
    /// <param name="objs">The collection of objects whose properties are to be modified. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects with their <see cref="DateTime"/> properties and nested class properties adjusted to the new time zone.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T>(this IEnumerable<T?>? objs, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (objs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var obj in objs)
        {
            yield return obj.ChangeTimeZoneAllProperty(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all <see cref="DateTime"/> properties and nested class properties within each object in a collection (ICollection).
    /// This method recursively adjusts <see cref="DateTime"/> properties and iterates through collections to apply the time zone change.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <typeparam name="T">The class type of the objects in the collection whose properties are to be modified. Must be a class type.</typeparam>
    /// <param name="objs">The ICollection of objects whose properties are to be modified. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects with their <see cref="DateTime"/> properties and nested class properties adjusted to the new time zone.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T>(this ICollection<T?>? objs, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (objs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var obj in objs)
        {
            yield return obj.ChangeTimeZoneAllProperty(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all <see cref="DateTime"/> properties and nested class properties within each object in an array.
    /// This method recursively adjusts <see cref="DateTime"/> properties and iterates through collections to apply the time zone change.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <typeparam name="T">The class type of the objects in the array whose properties are to be modified. Must be a class type.</typeparam>
    /// <param name="objs">The array of objects whose properties are to be modified. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects with their <see cref="DateTime"/> properties and nested class properties adjusted to the new time zone.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T>(this T?[]? objs, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (objs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var obj in objs)
        {
            yield return obj.ChangeTimeZoneAllProperty(tzSrc, tzDst);
        }
    }
}
