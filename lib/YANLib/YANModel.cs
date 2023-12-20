using System.Collections;
using static System.Reflection.BindingFlags;

namespace YANLib;

public static partial class YANModel
{
    /// <summary>
    /// Wraps a single instance of a class type into a <see cref="List{T}"/>.
    /// </summary>
    /// <typeparam name="T">The class type of the object to be wrapped in a list. Must be a class type.</typeparam>
    /// <param name="mdl">The object to be wrapped in the list. Can be <see langword="null"/>.</param>
    /// <returns>A new <see cref="List{T}"/> containing the provided object as its only element.</returns>
    public static List<T?> AsList<T>(this T? mdl) where T : class => new() { mdl };

    /// <summary>
    /// Wraps a single instance of a class type into a <see cref="HashSet{T}"/>.
    /// </summary>
    /// <typeparam name="T">The class type of the object to be wrapped in a hash set. Must be a class type.</typeparam>
    /// <param name="mdl">The object to be wrapped in the hash set. Can be <see langword="null"/>.</param>
    /// <returns>A new <see cref="HashSet{T}"/> containing the provided object as its only element.</returns>
    public static HashSet<T?> AsHashSet<T>(this T? mdl) where T : class => new() { mdl };

    /// <summary>
    /// Wraps a single instance of a class type into an array.
    /// </summary>
    /// <typeparam name="T">The class type of the object to be wrapped in an array. Must be a class type.</typeparam>
    /// <param name="mdl">The object to be wrapped in the array. Can be <see langword="null"/>.</param>
    /// <returns>An array containing the provided object as its only element.</returns>
    public static T?[] AsArray<T>(this T? mdl) where T : class => new T?[1] { mdl };

    /// <summary>
    /// Creates a shallow copy of the provided object if it is not <see langword="null"/>.
    /// The copy is made by copying the public instance properties from the source object to a new object of the same type.
    /// </summary>
    /// <typeparam name="T">The type of object to be copied. Must have a parameterless constructor.</typeparam>
    /// <param name="src">The source object to be copied. Can be <see langword="null"/>.</param>
    /// <returns>A shallow copy of the source object, or <see langword="null"/> if the source object is <see langword="null"/>.</returns>
    public static T? Copy<T>(this T? src) where T : new()
    {
        if (src is null)
        {
            return default;
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

    /// <summary>
    /// Changes the time zone of all <see cref="DateTime"/> properties and nested class properties within an object.
    /// This method recursively adjusts <see cref="DateTime"/> properties and iterates through collections to apply the time zone change.
    /// </summary>
    /// <typeparam name="T">The class type of the object whose properties are to be modified. Must be a class type.</typeparam>
    /// <param name="mdl">The object whose properties are to be modified. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>The object with its <see cref="DateTime"/> properties and nested class properties adjusted to the new time zone, or <see langword="null"/> if the input object is null.</returns>
    public static T? ChangeTimeZoneAllProperty<T>(this T? mdl, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (mdl is null)
        {
            return default;
        }

        var props = typeof(T).GetProperties(Public | Instance).Where(x => x.CanRead && x.CanWrite);

        if (props.Any())
        {
            foreach (var prop in props)
            {
                if (prop is null)
                {
                    continue;
                }

                var val = prop.GetValue(mdl);

                if (val is null)
                {
                    continue;
                }

                if (val is DateTime dt)
                {
                    prop.SetValue(mdl, dt.ChangeTimeZone(tzSrc, tzDst));
                }
                else if (val.GetType().IsClass)
                {
                    var chgedVal = ChangeTimeZoneAllProperty(val, tzSrc, tzDst);

                    if (chgedVal is not null)
                    {
                        prop.SetValue(mdl, chgedVal);
                    }
                }
                else if (val.GetType().IsGenericType && val.GetType().GetGenericTypeDefinition() == typeof(IList<>))
                {
                    var list = (IList)val;

                    if (list.Count is not 0)
                    {
                        for (var i = 0; i < list.Count; i++)
                        {
                            if (list[i] is null)
                            {
                                continue;
                            }

                            var chgedItem = ChangeTimeZoneAllProperty(list[i], tzSrc, tzDst);

                            if (chgedItem is not null)
                            {
                                list[i] = chgedItem;
                            }
                        }
                    }
                }
            }
        }

        return mdl;
    }

    /// <summary>
    /// Changes the time zone of all <see cref="DateTime"/> properties and nested class properties within each object in a collection.
    /// The method applies the time zone change recursively and iterates through collections within each object.
    /// </summary>
    /// <typeparam name="T">The class type of the objects in the collection whose properties are to be modified. Must be a class type.</typeparam>
    /// <param name="mdls">The collection of objects whose properties are to be modified. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects with their <see cref="DateTime"/> properties and nested class properties adjusted to the new time zone, or <see langword="null"/> if the input collection is null.</returns>
    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this IEnumerable<T?>? mdls, object? tzSrc = null, object? tzDst = null) where T : class => mdls.IsEmptyOrNull()
        ? default
        : mdls.Select(x => x.ChangeTimeZoneAllProperty(tzSrc, tzDst));

    /// <summary>
    /// Changes the time zone of all <see cref="DateTime"/> properties and nested class properties within each object in a collection (ICollection).
    /// The method applies the time zone change recursively and iterates through collections within each object.
    /// </summary>
    /// <typeparam name="T">The class type of the objects in the collection whose properties are to be modified. Must be a class type.</typeparam>
    /// <param name="mdls">The ICollection of objects whose properties are to be modified. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects with their <see cref="DateTime"/> properties and nested class properties adjusted to the new time zone, or <see langword="null"/> if the input collection is null.</returns>
    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this ICollection<T?>? mdls, object? tzSrc = null, object? tzDst = null) where T : class => mdls.IsEmptyOrNull()
        ? default
        : mdls.Select(x => x.ChangeTimeZoneAllProperty(tzSrc, tzDst));

    /// <summary>
    /// Changes the time zone of all <see cref="DateTime"/> properties and nested class properties within each object in an array.
    /// The method applies the time zone change recursively and iterates through collections within each object.
    /// </summary>
    /// <typeparam name="T">The class type of the objects in the array whose properties are to be modified. Must be a class type.</typeparam>
    /// <param name="mdls">The array of objects whose properties are to be modified. Can be <see langword="null"/>.</param>
    /// <param name="tzSrc">The source time zone offset. Can be <see langword="null"/>.</param>
    /// <param name="tzDst">The destination time zone offset. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects with their <see cref="DateTime"/> properties and nested class properties adjusted to the new time zone, or <see langword="null"/> if the input array is null.</returns>
    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this T?[]? mdls, object? tzSrc = null, object? tzDst = null) where T : class => mdls.IsEmptyOrNull()
        ? default
        : mdls.Select(x => x.ChangeTimeZoneAllProperty(tzSrc, tzDst));
}
