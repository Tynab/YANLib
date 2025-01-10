using YANLib.Text;
using static System.Activator;
using static System.Reflection.BindingFlags;

namespace YANLib.Object;

public static partial class YANObject
{
    public static bool AllPropertiesNotDefault<T>(this T input) where T : class
    {
        if (input.IsNull())
        {
            return default;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesDefault());

    public static bool AllPropertiesNotDefaults<T>(this ICollection<T>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesDefault());

    public static bool AllPropertiesNotDefaults<T>(params T[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesDefault());

    public static bool AllPropertiesDefault<T>(this T input) where T : class
    {
        if (input.IsNull())
        {
            return default;
        }

        foreach (var prop in typeof(T).GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default(T)))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesDefaults<T>(this IEnumerable<T>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesNotDefault());

    public static bool AllPropertiesDefaults<T>(this ICollection<T>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesNotDefault());

    public static bool AllPropertiesDefaults<T>(params T[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesNotDefault());

    public static bool AnyPropertiesNotDefault<T>(this T? input) where T : class
    {
        if (input.IsNull())
        {
            return default;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : null))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesNotDefault());

    public static bool AnyPropertiesNotDefaults<T>(this ICollection<T>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesNotDefault());

    public static bool AnyPropertiesNotDefaults<T>(params T[]? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesNotDefault());

    public static bool AnyPropertiesDefault<T>(this T input) where T : class
    {
        if (input.IsNull())
        {
            return default;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesDefault());

    public static bool AnyPropertiesDefaults<T>(this ICollection<T>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesDefault());

    public static bool AnyPropertiesDefaults<T>(params T[]? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesDefault());

    public static bool AllPropertiesNotDefault<T>(this T input, params string?[]? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return default;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T>? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this ICollection<T>? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this T[]? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesDefault<T>(this T input, params string?[]? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return default;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesDefaults<T>(this IEnumerable<T>? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this ICollection<T>? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this T[]? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefault<T>(this T input, params string?[]? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T>? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this ICollection<T>? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this T[]? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesDefault<T>(this T input, params string?[]? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T>? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this ICollection<T>? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this T[]? input, params string?[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefault<T>(this T input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this ICollection<T>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this T[]? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesDefault<T>(this T input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesDefaults<T>(this IEnumerable<T>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this ICollection<T>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this T[]? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefault<T>(this T input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this ICollection<T>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this T[]? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesDefault<T>(this T input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this ICollection<T>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this T[]? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefault<T>(this T input, ICollection<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T>? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this ICollection<T>? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesNotDefaults<T>(this T[]? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AllPropertiesDefault<T>(this T input, ICollection<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllPropertiesDefaults<T>(this IEnumerable<T>? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this ICollection<T>? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AllPropertiesDefaults<T>(this T[]? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefault<T>(this T input, ICollection<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T>? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this ICollection<T>? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesNotDefaults<T>(this T[]? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefault(names));

    public static bool AnyPropertiesDefault<T>(this T input, ICollection<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        foreach (var prop in input.GetType().GetProperties(Public | Instance | DeclaredOnly).Where(x => names.Contains(x.Name)))
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T>? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this ICollection<T>? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefault(names));

    public static bool AnyPropertiesDefaults<T>(this T[]? input, ICollection<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefault(names));
}
