﻿using System.Collections;
using static System.Reflection.BindingFlags;

namespace YANLib;

public static partial class YANModel
{
    public static List<T> AsList<T>(this T mdl) where T : class => new() { mdl };

    public static HashSet<T> AsHashSet<T>(this T mdl) where T : class => new() { mdl };

    public static T[] AsArray<T>(this T mdl) where T : class => new T[1] { mdl };

    public static T Copy<T>(this T src) where T : new()
    {
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

    public static T? ChangeTimeZoneAllProperties<T, T1, T2>(this T? mdl, T1 tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdl is not null)
        {
            var props = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);

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
                        var chgedVal = ChangeTimeZoneAllProperties(val, tzSrc, tzDst);

                        if (chgedVal is not null)
                        {
                            prop.SetValue(mdl, chgedVal);
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

                                var chgedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);

                                if (chgedItem is not null)
                                {
                                    list[i] = chgedItem;
                                }
                            }
                        }
                    }
                }
            }
        }

        return mdl;
    }

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

    public static T? ChangeTimeZoneAllProperties<T, T1, T2>(this T? mdl, T1? tzSrc, T2 tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdl is not null)
        {
            var props = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);

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
                        var chgedVal = ChangeTimeZoneAllProperties(val, tzSrc, tzDst);

                        if (chgedVal is not null)
                        {
                            prop.SetValue(mdl, chgedVal);
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

                                var chgedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);

                                if (chgedItem is not null)
                                {
                                    list[i] = chgedItem;
                                }
                            }
                        }
                    }
                }
            }
        }
        return mdl;
    }

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

    public static T? ChangeTimeZoneAllProperties<T, T1, T2>(this T? mdl, T1 tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdl is not null)
        {
            var props = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);

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
                        var chgedVal = ChangeTimeZoneAllProperties(val, tzSrc, tzDst);

                        if (chgedVal is not null)
                        {
                            prop.SetValue(mdl, chgedVal);
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

                                var chgedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);

                                if (chgedItem is not null)
                                {
                                    list[i] = chgedItem;
                                }
                            }
                        }
                    }
                }
            }
        }

        return mdl;
    }

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

    public static T? ChangeTimeZoneAllProperties<T, T1, T2>(this T? mdl, T1? tzSrc, T2? tzDst) where T : class where T1 : struct where T2 : struct
    {
        if (mdl is not null)
        {
            var props = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);

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
                        var chgedVal = ChangeTimeZoneAllProperties(val, tzSrc, tzDst);

                        if (chgedVal is not null)
                        {
                            prop.SetValue(mdl, chgedVal);
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

                                var chgedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);

                                if (chgedItem is not null)
                                {
                                    list[i] = chgedItem;
                                }
                            }
                        }
                    }
                }
            }
        }

        return mdl;
    }

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
}
