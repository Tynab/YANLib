using static System.Activator;
using static System.Reflection.BindingFlags;

namespace YANLib;

public static partial class YANModel
{

    public static bool AllPropertiesNotDefault<T>(this T? mdl)
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

    public static bool AllPropertiesNotDefault<T>(this IEnumerable<T?> mdls) => mdls.IsNotEmptyAndNull() && !mdls.Any(x => x.AnyPropertiesDefault());

    public static bool AllPropertiesDefault<T>(this T? mdl)
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

    public static bool AllPropertiesDefault<T>(this IEnumerable<T?> mdls) => mdls.IsNotEmptyAndNull() && !mdls.Any(x => x.AnyPropertiesNotDefault());

    public static bool AnyPropertiesNotDefault<T>(this T? mdl)
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

    public static bool AnyPropertiesNotDefault<T>(this IEnumerable<T?> mdls) => mdls.IsNotEmptyAndNull() && mdls.Any(x => x.AnyPropertiesNotDefault());

    public static bool AnyPropertiesDefault<T>(this T? mdl)
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

    public static bool AnyPropertiesDefault<T>(this IEnumerable<T?> mdls) => mdls.IsNotEmptyAndNull() && mdls.Any(x => x.AnyPropertiesDefault());

    public static bool AllPropertiesNotDefault<T>(this T? mdl, params string[] names)
    {
        if (mdl is null || names.AllWhiteSpaceOrNull())
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

    public static bool AllPropertiesNotDefault<T>(this IEnumerable<T?> mdls, params string[] names) => mdls.IsNotEmptyAndNull() && !mdls.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesDefault<T>(this T? mdl, params string[] names)
    {
        if (mdl is null || names.AllWhiteSpaceOrNull())
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

    public static bool AllPropertiesDefault<T>(this IEnumerable<T?> mdls, params string[] names) => mdls.IsNotEmptyAndNull() && !mdls.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefault<T>(this T? mdl, params string[] names)
    {
        if (mdl is null || names.AllWhiteSpaceOrNull())
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

    public static bool AnyPropertiesNotDefault<T>(this IEnumerable<T?> mdls, params string[] names) => mdls.IsNotEmptyAndNull() && mdls.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesDefault<T>(this T? mdl, params string[] names)
    {
        if (mdl is null || names.AllWhiteSpaceOrNull())
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

    public static bool AnyPropertiesDefault<T>(this IEnumerable<T?> mdls, params string[] names) => mdls.IsNotEmptyAndNull() && mdls.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefault<T>(this T? mdl, IEnumerable<string> names)
    {
        if (mdl is null || names.AllWhiteSpaceOrNull())
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

    public static bool AllPropertiesNotDefault<T>(this IEnumerable<T?> mdls, IEnumerable<string> names) => mdls.IsNotEmptyAndNull() && !mdls.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesDefault<T>(this T? mdl, IEnumerable<string> names)
    {
        if (mdl is null || names.AllWhiteSpaceOrNull())
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

    public static bool AllPropertiesDefault<T>(this IEnumerable<T?> mdls, IEnumerable<string> names) => mdls.IsNotEmptyAndNull() && !mdls.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefault<T>(this T? mdl, IEnumerable<string> names)
    {
        if (mdl is null || names.AllWhiteSpaceOrNull())
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

    public static bool AnyPropertiesNotDefault<T>(this IEnumerable<T?> mdls, IEnumerable<string> names) => mdls.IsNotEmptyAndNull() && mdls.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesDefault<T>(this T? mdl, IEnumerable<string> names)
    {
        if (mdl is null || names.AllWhiteSpaceOrNull())
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

    public static bool AnyPropertiesDefault<T>(this IEnumerable<T?> mdls, IEnumerable<string> names) => mdls.IsNotEmptyAndNull() && mdls.Any(x => x.AnyPropertiesDefault(names));
}
