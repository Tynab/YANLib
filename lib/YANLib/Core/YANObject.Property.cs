using static System.Activator;
using static System.Reflection.BindingFlags;

namespace YANLib.Core;

public static partial class YANObject
{
    public static bool AllPropertiesNotDefault<T>(this T? obj) where T : class
    {
        if (obj.IsNull())
        {
            return default;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? objs) where T : class => objs.IsNotEmptyAndNull() && !objs.Any(x => x.AnyPropertiesDefault());

    public static bool AllPropertiesNotDefaults<T>(this ICollection<T?>? objs) where T : class => objs.IsNotEmptyAndNull() && !objs.Any(x => x.AnyPropertiesDefault());

    public static bool AllPropertiesNotDefaults<T>(params T?[]? objs) where T : class => objs.IsNotEmptyAndNull() && !objs.Any(x => x.AnyPropertiesDefault());

    public static bool AllPropertiesDefault<T>(this T? obj) where T : class
    {
        if (obj.IsNull())
        {
            return default;
        }

        foreach (var prop in typeof(T).GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default(T)))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? objs) where T : class => objs.IsNotEmptyAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault());

    public static bool AllPropertiesDefaults<T>(this ICollection<T?>? objs) where T : class => objs.IsNotEmptyAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault());

    public static bool AllPropertiesDefaults<T>(params T?[]? objs) where T : class => objs.IsNotEmptyAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault());

    public static bool AnyPropertiesNotDefault<T>(this T? obj) where T : class
    {
        if (obj.IsNull())
        {
            return default;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? objs) where T : class => objs.IsNotEmptyAndNull() && objs.Any(x => x.AnyPropertiesNotDefault());

    public static bool AnyPropertiesNotDefaults<T>(this ICollection<T?>? objs) where T : class => objs.IsNotEmptyAndNull() && objs.Any(x => x.AnyPropertiesNotDefault());

    public static bool AnyPropertiesNotDefaults<T>(params T?[]? objs) where T : class => objs.IsNotEmptyAndNull() && objs.Any(x => x.AnyPropertiesNotDefault());

    public static bool AnyPropertiesDefault<T>(this T? obj) where T : class
    {
        if (obj.IsNull())
        {
            return default;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? objs) where T : class => objs.IsNotEmptyAndNull() && objs.Any(x => x.AnyPropertiesDefault());

    public static bool AnyPropertiesDefaults<T>(this ICollection<T?>? objs) where T : class => objs.IsNotEmptyAndNull() && objs.Any(x => x.AnyPropertiesDefault());

    public static bool AnyPropertiesDefaults<T>(params T?[]? objs) where T : class => objs.IsNotEmptyAndNull() && objs.Any(x => x.AnyPropertiesDefault());

    public static bool AllPropertiesNotDefault<T>(this T? obj, params string?[]? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return default;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this ICollection<T?>? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this T?[]? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesDefault<T>(this T? obj, params string?[]? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return default;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this ICollection<T?>? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this T?[]? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefault<T>(this T? obj, params string?[]? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return false;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this ICollection<T?>? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this T?[]? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesDefault<T>(this T? obj, params string?[]? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return false;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this ICollection<T?>? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this T?[]? objs, params string?[]? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefault<T>(this T? obj, IEnumerable<string?>? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return false;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this ICollection<T?>? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this T?[]? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesDefault<T>(this T? obj, IEnumerable<string?>? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return false;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this ICollection<T?>? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this T?[]? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefault<T>(this T? obj, IEnumerable<string?>? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return false;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this ICollection<T?>? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this T?[]? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesDefault<T>(this T? obj, IEnumerable<string?>? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return false;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this ICollection<T?>? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this T?[]? objs, IEnumerable<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefault<T>(this T? obj, ICollection<string?>? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return false;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this ICollection<T?>? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this T?[]? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesDefault<T>(this T? obj, ICollection<string?>? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return false;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this ICollection<T?>? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this T?[]? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && !objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefault<T>(this T? obj, ICollection<string?>? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return false;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this ICollection<T?>? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this T?[]? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesDefault<T>(this T? obj, ICollection<string?>? names) where T : class
    {
        if (obj.IsNull() || names.IsEmptyOrNull() || names.AllWhiteSpaceOrNull())
        {
            return false;
        }

        foreach (var prop in obj.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(obj), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this ICollection<T?>? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this T?[]? objs, ICollection<string?>? names) where T : class
        => objs.IsNotEmptyAndNull() && names.IsNotEmptyAndNull() && names.AllNotWhiteSpaceAndNull() && objs.Any(x => x.AnyPropertiesDefault(names));
}
