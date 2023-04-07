using System.Collections;
using System.Reflection;
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
    public static T? ChangeTimeZoneAllProperties<T>(this T? mdl, int tzSrc, int tzDst) where T : class
    {
        if (mdl != null)
        {
            var props = typeof(T).GetProperties(Public | Instance).ChgTzPropPrcYld();
            foreach (var prop in props)
            {
                var val = prop?.GetValue(mdl);
                if (val != null)
                {
                    if (val is DateTime dt)
                    {
                        prop?.SetValue(mdl, dt.ChangeTimeZone(tzSrc, tzDst));
                    }
                    else if (val.GetType().IsClass)
                    {
                        prop?.SetValue(mdl, ChangeTimeZoneAllProperties(val, tzSrc, tzDst));
                    }
                    else if (val.GetType().IsGenericType && val?.GetType()?.GetGenericTypeDefinition() == typeof(IList<>))
                    {
                        var list = (IList)val;
                        for (var i = 0; i < list?.Count; i++)
                        {
                            list[i] = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);
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
    public static bool AllPropertiesNotNull<T>(T mdl) where T : class
    {
        if (mdl == null)
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties())
        {
            if (prop.GetValue(mdl) == null)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Checks whether all properties with the specified names of the specified object have non-null values, including all its nested properties and properties in lists.
    /// If the object is <see langword="null"/>, returns <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to check.</typeparam>
    /// <param name="mdl">The object to check.</param>
    /// <param name="names">The names of the properties to check.</param>
    /// <returns><see langword="true"/> if all properties with the specified names of the specified object have non-null values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotNull<T>(T mdl, HashSet<string> names) where T : class
    {
        if (mdl == null)
        {
            return false;
        }
        foreach (var name in names)
        {
            var prop = mdl.GetType().GetProperty(name);
            if (prop == null || prop.GetValue(mdl) == null)
            {
                return false;
            }
        }
        return true;
    }

    // Change time zone properties process yield
    private static IEnumerable<PropertyInfo> ChgTzPropPrcYld(this PropertyInfo[] arrProp)
    {
        for (var i = 0; i < arrProp.Length; i++)
        {
            if (arrProp[i].CanRead && arrProp[i].CanWrite)
            {
                yield return arrProp[i];
            }
        }
    }
}
