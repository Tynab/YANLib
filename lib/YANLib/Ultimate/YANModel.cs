namespace YANLib.Ultimate;

public static partial class YANModel
{
    /// <summary>
    /// Changes the time zone of all <see cref="DateTime"/> properties and nested class properties within each object in a collection.
    /// This method recursively adjusts <see cref="DateTime"/> properties and iterates through collections to apply the time zone change.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <typeparam name="T">The class type of the objects in the collection whose properties are to be modified. Must be a class type.</typeparam>
    /// <param name="mdls">The collection of objects whose properties are to be modified. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects with their <see cref="DateTime"/> properties and nested class properties adjusted to the new time zone.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T>(this IEnumerable<T?>? mdls, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (mdls.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperty(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all <see cref="DateTime"/> properties and nested class properties within each object in a collection (ICollection).
    /// This method recursively adjusts <see cref="DateTime"/> properties and iterates through collections to apply the time zone change.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <typeparam name="T">The class type of the objects in the collection whose properties are to be modified. Must be a class type.</typeparam>
    /// <param name="mdls">The ICollection of objects whose properties are to be modified. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects with their <see cref="DateTime"/> properties and nested class properties adjusted to the new time zone.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T>(this ICollection<T?>? mdls, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (mdls.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperty(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all <see cref="DateTime"/> properties and nested class properties within each object in an array.
    /// This method recursively adjusts <see cref="DateTime"/> properties and iterates through collections to apply the time zone change.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// </summary>
    /// <typeparam name="T">The class type of the objects in the array whose properties are to be modified. Must be a class type.</typeparam>
    /// <param name="mdls">The array of objects whose properties are to be modified. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects with their <see cref="DateTime"/> properties and nested class properties adjusted to the new time zone.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T>(this T?[]? mdls, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (mdls.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperty(tzSrc, tzDst);
        }
    }
}
