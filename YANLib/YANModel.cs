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
        if (mdl != null)
        {
            var properties = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);
            if (properties.Any())
            {
                foreach (var prop in properties)
                {
                    if (prop == null)
                    {
                        continue;
                    }
                    var val = prop.GetValue(mdl);
                    if (val == null)
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
                        if (changedVal != null)
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
                                if (list[i] == null)
                                {
                                    continue;
                                }
                                var changedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);
                                if (changedItem != null)
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
        if (mdl != null)
        {
            var properties = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);
            if (properties.Any())
            {
                foreach (var prop in properties)
                {
                    if (prop == null)
                    {
                        continue;
                    }
                    var val = prop.GetValue(mdl);
                    if (val == null)
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
                        if (changedVal != null)
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
                                if (list[i] == null)
                                {
                                    continue;
                                }
                                var changedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);
                                if (changedItem != null)
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
        if (mdl != null)
        {
            var properties = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);
            if (properties.Any())
            {
                foreach (var prop in properties)
                {
                    if (prop == null)
                    {
                        continue;
                    }
                    var val = prop.GetValue(mdl);
                    if (val == null)
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
                        if (changedVal != null)
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
                                if (list[i] == null)
                                {
                                    continue;
                                }
                                var changedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);
                                if (changedItem != null)
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
        if (mdl != null)
        {
            var properties = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);
            if (properties.Any())
            {
                foreach (var prop in properties)
                {
                    if (prop == null)
                    {
                        continue;
                    }
                    var val = prop.GetValue(mdl);
                    if (val == null)
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
                        if (changedVal != null)
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
                                if (list[i] == null)
                                {
                                    continue;
                                }
                                var changedItem = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);
                                if (changedItem != null)
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
    /// Checks whether all properties of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <returns><see langword="true"/> if all properties of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotNull<T>(this T mdl) where T : class => mdl != null && mdl.GetType().GetProperties().All(prop => prop.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether all properties of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <returns><see langword="true"/> if all properties of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNull<T>(this T mdl) where T : class => mdl != null && mdl.GetType().GetProperties().All(prop => prop.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether any property of the specified object has a non-null value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <returns><see langword="true"/> if any property of the specified object has a non-null value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotNull<T>(this T mdl) where T : class => mdl != null && mdl.GetType().GetProperties().Any(prop => prop.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether any property of the specified object has a null value, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <returns><see langword="true"/> if any property of the specified object has a null value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNull<T>(this T mdl) where T : class => mdl != null && mdl.GetType().GetProperties().Any(prop => prop.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotNull<T>(this T mdl, params string[] names) where T : class => mdl != null && names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNull<T>(this T mdl, params string[] names) where T : class => mdl == null || names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotNull<T>(this T mdl, params string[] names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNull<T>(this T mdl, params string[] names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotNull<T>(this T mdl, IEnumerable<string> names) where T : class => mdl != null && names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNull<T>(this T mdl, IEnumerable<string> names) where T : class => mdl == null || names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotNull<T>(this T mdl, IEnumerable<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNull<T>(this T mdl, IEnumerable<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotNull<T>(this T mdl, ICollection<string> names) where T : class => mdl != null && names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNull<T>(this T mdl, ICollection<string> names) where T : class => mdl == null || names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotNull<T>(this T mdl, ICollection<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNull<T>(this T mdl, ICollection<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotNull<T>(this T mdl, IList<string> names) where T : class => mdl != null && names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNull<T>(this T mdl, IList<string> names) where T : class => mdl == null || names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotNull<T>(this T mdl, IList<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNull<T>(this T mdl, IList<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotNull<T>(this T mdl, ISet<string> names) where T : class => mdl != null && names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNull<T>(this T mdl, ISet<string> names) where T : class => mdl == null || names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotNull<T>(this T mdl, ISet<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNull<T>(this T mdl, ISet<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotNull<T>(this T mdl, IReadOnlyCollection<string> names) where T : class => mdl != null && names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNull<T>(this T mdl, IReadOnlyCollection<string> names) where T : class => mdl == null || names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotNull<T>(this T mdl, IReadOnlyCollection<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNull<T>(this T mdl, IReadOnlyCollection<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotNull<T>(this T mdl, IReadOnlyList<string> names) where T : class => mdl != null && names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNull<T>(this T mdl, IReadOnlyList<string> names) where T : class => mdl == null || names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotNull<T>(this T mdl, IReadOnlyList<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNull<T>(this T mdl, IReadOnlyList<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotNull<T>(this T mdl, IReadOnlySet<string> names) where T : class => mdl != null && names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNull<T>(this T mdl, IReadOnlySet<string> names) where T : class => mdl == null || names.All(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotNull<T>(this T mdl, IReadOnlySet<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) != null);

    /// <summary>
    /// Checks whether any properties with the specified names of the specified object have null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if any properties with the specified names of the specified object have null values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNull<T>(this T mdl, IReadOnlySet<string> names) where T : class => mdl != null && names.Any(name => mdl.GetType().GetProperty(name)?.GetValue(mdl) == null);
}
