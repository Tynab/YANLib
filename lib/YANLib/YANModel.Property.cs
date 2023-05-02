using static System.Activator;
using static System.Reflection.BindingFlags;

namespace YANLib;

public static partial class YANModel
{
    
    public static bool AllPropertiesNotDefault<T>(this T mdl) where T : class
    {
        if (mdl is null)
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }
        return true;
    }

    public static IEnumerable<bool> AllPropertiesNotDefault<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesNotDefault();
        }
    }

    public static bool AllPropertiesDefault<T>(this T mdl) where T : class
    {
        if (mdl is null)
        {
            return false;
        }
        foreach (var prop in typeof(T).GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default(T)))
            {
                return false;
            }
        }
        return true;
    }

    public static IEnumerable<bool> AllPropertiesDefault<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesDefault();
        }
    }

    public static bool AnyPropertiesNotDefault<T>(this T mdl) where T : class
    {
        if (mdl is null)
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    public static IEnumerable<bool> AnyPropertiesNotDefault<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesNotDefault();
        }
    }

    public static bool AnyPropertiesDefault<T>(this T mdl) where T : class
    {
        if (mdl is null)
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    public static IEnumerable<bool> AnyPropertiesDefault<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesDefault();
        }
    }

    public static bool AllPropertiesNotDefault<T>(this T mdl, params string[] names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }
        return true;
    }

    public static IEnumerable<bool> AllPropertiesNotDefault<T>(this IEnumerable<T> mdls, params string[] names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesNotDefault(names);
        }
    }

    public static bool AllPropertiesDefault<T>(this T mdl, params string[] names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }
        return true;
    }

    public static IEnumerable<bool> AllPropertiesDefault<T>(this IEnumerable<T> mdls, params string[] names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesDefault(names);
        }
    }

    public static bool AnyPropertiesNotDefault<T>(this T mdl, params string[] names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    public static IEnumerable<bool> AnyPropertiesNotDefault<T>(this IEnumerable<T> mdls, params string[] names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesNotDefault(names);
        }
    }

    public static bool AnyPropertiesDefault<T>(this T mdl, params string[] names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    public static IEnumerable<bool> AnyPropertiesDefault<T>(this IEnumerable<T> mdls, params string[] names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesDefault(names);
        }
    }

    public static bool AllPropertiesNotDefault<T>(this T mdl, IEnumerable<string> names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }
        return true;
    }

    public static IEnumerable<bool> AllPropertiesNotDefault<T>(this IEnumerable<T> mdls, IEnumerable<string> names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesNotDefault(names);
        }
    }

    public static bool AllPropertiesDefault<T>(this T mdl, IEnumerable<string> names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }
        return true;
    }

    public static IEnumerable<bool> AllPropertiesDefault<T>(this IEnumerable<T> mdls, IEnumerable<string> names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AllPropertiesDefault(names);
        }
    }

    public static bool AnyPropertiesNotDefault<T>(this T mdl, IEnumerable<string> names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    public static IEnumerable<bool> AnyPropertiesNotDefault<T>(this IEnumerable<T> mdls, IEnumerable<string> names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesNotDefault(names);
        }
    }

    public static bool AnyPropertiesDefault<T>(this T mdl, IEnumerable<string> names) where T : class
    {
        if (mdl is null || names.IsNullOrWhiteSpace())
        {
            return false;
        }
        foreach (var prop in mdl.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(p => names.Contains(p.Name)))
        {
            var type = prop.PropertyType;
            if (EqualityComparer<object>.Default.Equals(prop.GetValue(mdl), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }
        return false;
    }

    public static IEnumerable<bool> AnyPropertiesDefault<T>(this IEnumerable<T> mdls, IEnumerable<string> names) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.AnyPropertiesDefault(names);
        }
    }
}
