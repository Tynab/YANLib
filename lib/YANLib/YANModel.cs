using System.Collections;
using static System.Reflection.BindingFlags;

namespace YANLib;

public static partial class YANModel
{
    /// <summary>
    /// Changes the time zone of all properties of the specified object with nullable value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to change the time zone.</typeparam>
    /// <param name="mdl">The nullable object to change the time zone.</param>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <returns>The nullable object with all its properties having the specified time zone; or <see langword="null"/> if the object is <see langword="null"/>.</returns>
    public static T? ChangeTimeZoneAllProperties<T, T1, T2>(this T? mdl, T1 tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdl is not null)
        {
            var properties = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);
            if (properties.Any())
            {
                foreach (var prop in properties)
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
                        var changedVal = ChangeTimeZoneAllProperties(val, tzSrc, tzDst);
                        if (changedVal is not null)
                        {
                            prop.SetValue(mdl, changedVal);
                        }
                    }
                    else if (val.GetType().IsGenericType && val.GetType().GetGenericTypeDefinition() == typeof(IList<>))
                    {
                        var list = (IList)val;
                        if (list.Count > 0)
                        {
                            for (var i = 0; i < list.Count; i++)
                            {
                                if (list[i] is null)
                                {
                                    continue;
                                }
                                var changedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);
                                if (changedItem is not null)
                                {
                                    list[i] = changedItem;
                                }
                            }
                        }
                    }
                }
            }
        }
        return mdl;
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(T1 tzSrc, T2 tzDst, params T?[] mdls) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Length; i++)
        {
            yield return mdls[i].ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IEnumerable<T?> mdls, T1 tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlyCollection<T?> mdls, T1 tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlyList<T?> mdls, T1 tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Count; i++)
        {
            yield return mdls[i].ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlySet<T?> mdls, T1 tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified object with nullable value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to change the time zone.</typeparam>
    /// <param name="mdl">The nullable object to change the time zone.</param>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <returns>The nullable object with all its properties having the specified time zone; or <see langword="null"/> if the object is <see langword="null"/>.</returns>
    public static T? ChangeTimeZoneAllProperties<T, T1, T2>(this T? mdl, T1? tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdl is not null)
        {
            var properties = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);
            if (properties.Any())
            {
                foreach (var prop in properties)
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
                        var changedVal = ChangeTimeZoneAllProperties(val, tzSrc, tzDst);
                        if (changedVal is not null)
                        {
                            prop.SetValue(mdl, changedVal);
                        }
                    }
                    else if (val.GetType().IsGenericType && val.GetType().GetGenericTypeDefinition() == typeof(IList<>))
                    {
                        var list = (IList)val;
                        if (list.Count > 0)
                        {
                            for (var i = 0; i < list.Count; i++)
                            {
                                if (list[i] is null)
                                {
                                    continue;
                                }
                                var changedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);
                                if (changedItem is not null)
                                {
                                    list[i] = changedItem;
                                }
                            }
                        }
                    }
                }
            }
        }
        return mdl;
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(T1? tzSrc, T2 tzDst, params T?[] mdls) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Length; i++)
        {
            yield return mdls[i].ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IEnumerable<T?> mdls, T1? tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlyCollection<T?> mdls, T1? tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlyList<T?> mdls, T1? tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Count; i++)
        {
            yield return mdls[i].ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlySet<T?> mdls, T1? tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified object with nullable value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to change the time zone.</typeparam>
    /// <param name="mdl">The nullable object to change the time zone.</param>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <returns>The nullable object with all its properties having the specified time zone; or <see langword="null"/> if the object is <see langword="null"/>.</returns>
    public static T? ChangeTimeZoneAllProperties<T, T1, T2>(this T? mdl, T1 tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdl is not null)
        {
            var properties = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);
            if (properties.Any())
            {
                foreach (var prop in properties)
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
                        var changedVal = ChangeTimeZoneAllProperties(val, tzSrc, tzDst);
                        if (changedVal is not null)
                        {
                            prop.SetValue(mdl, changedVal);
                        }
                    }
                    else if (val.GetType().IsGenericType && val.GetType().GetGenericTypeDefinition() == typeof(IList<>))
                    {
                        var list = (IList)val;
                        if (list.Count > 0)
                        {
                            for (var i = 0; i < list.Count; i++)
                            {
                                if (list[i] is null)
                                {
                                    continue;
                                }
                                var changedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);
                                if (changedItem is not null)
                                {
                                    list[i] = changedItem;
                                }
                            }
                        }
                    }
                }
            }
        }
        return mdl;
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(T1 tzSrc, T2? tzDst, params T?[] mdls) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Length; i++)
        {
            yield return mdls[i].ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IEnumerable<T?> mdls, T1 tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlyCollection<T?> mdls, T1 tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlyList<T?> mdls, T1 tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Count; i++)
        {
            yield return mdls[i].ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlySet<T?> mdls, T1 tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified object with nullable value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to change the time zone.</typeparam>
    /// <param name="mdl">The nullable object to change the time zone.</param>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <returns>The nullable object with all its properties having the specified time zone; or <see langword="null"/> if the object is <see langword="null"/>.</returns>
    public static T? ChangeTimeZoneAllProperties<T, T1, T2>(this T? mdl, T1? tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdl is not null)
        {
            var properties = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);
            if (properties.Any())
            {
                foreach (var prop in properties)
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
                        var changedVal = ChangeTimeZoneAllProperties(val, tzSrc, tzDst);
                        if (changedVal is not null)
                        {
                            prop.SetValue(mdl, changedVal);
                        }
                    }
                    else if (val.GetType().IsGenericType && val.GetType().GetGenericTypeDefinition() == typeof(IList<>))
                    {
                        var list = (IList)val;
                        if (list.Count > 0)
                        {
                            for (var i = 0; i < list.Count; i++)
                            {
                                if (list[i] is null)
                                {
                                    continue;
                                }
                                var changedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);
                                if (changedItem is not null)
                                {
                                    list[i] = changedItem;
                                }
                            }
                        }
                    }
                }
            }
        }
        return mdl;
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(T1? tzSrc, T2? tzDst, params T?[] mdls) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Length; i++)
        {
            yield return mdls[i].ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IEnumerable<T?> mdls, T1? tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlyCollection<T?> mdls, T1? tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlyList<T?> mdls, T1? tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Count; i++)
        {
            yield return mdls[i].ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }

    /// <summary>
    /// Changes the time zone of all properties of the specified objects in the enumerable with nullable values, including all their nested properties and properties in lists.
    /// If any of the objects is <see langword="null"/>, returns <see langword="null"/> for that object.
    /// </summary>
    /// <typeparam name="T">The type of the objects to change the time zone.</typeparam>
    /// <typeparam name="T1">The type of the source time zone.</typeparam>
    /// <typeparam name="T2">The type of the destination time zone.</typeparam>
    /// <param name="tzSrc">The source time zone.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <param name="mdls">The nullable objects to change the time zone.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the nullable objects with all their properties having the specified time zone; or <see langword="null"/> for each object that is <see langword="null"/> in the enumerable.</returns>
    public static IEnumerable<T?> ChangeTimeZoneAllProperties<T, T1, T2>(this IReadOnlySet<T?> mdls, T1? tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.ChangeTimeZoneAllProperties(tzSrc, tzDst);
        }
    }
}
