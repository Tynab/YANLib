using YANLib.Text;
using static System.Activator;

namespace YANLib.Object;

public static partial class YANObject
{
    #region AllPropertiesNotDefault
    /// <summary>
    /// Determines whether all properties of the specified object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if all properties are not set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotDefault<T>(this T? input) where T : class
    {
        if (input.IsNull())
        {
            return default;
        }

        var props = GetCachedProperties(input.GetType());

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether all elements in the specified collection have all properties not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements have all properties not set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesDefault());

    /// <summary>
    /// Determines whether all elements in the specified array have all properties not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements have all properties not set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotDefaults<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesDefault());

    /// <summary>
    /// Determines whether all specified properties of an object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if all specified properties are not set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotDefault<T>(this T? input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        var props = GetCachedProperties(input.GetType()).Where(x => names.Contains(x.Name));

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether all elements in the specified collection have the specified properties not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if all elements have the specified properties not set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefault(names));

    /// <summary>
    /// Determines whether all specified properties of an object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if all specified properties are not set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotDefault<T>(this T? input, params string[]? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return default;
        }

        var props = GetCachedProperties(input.GetType()).Where(x => names.Contains(x.Name));

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether all elements in the specified collection have the specified properties not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if all elements have the specified properties not set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input, params string[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefault(names));
    #endregion

    #region AllPropertiesDefault
    /// <summary>
    /// Determines whether all properties of the specified object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if all properties are set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesDefault<T>(this T? input) where T : class
    {
        if (input.IsNull())
        {
            return default;
        }

        var props = GetCachedProperties(input.GetType());

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether all elements in the specified collection have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if all elements have all properties set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether all elements in the specified array have all properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if all elements have all properties set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesDefaults<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether all specified properties of an object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if all specified properties are set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesDefault<T>(this T? input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        var props = GetCachedProperties(input.GetType()).Where(x => names.Contains(x.Name));

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether all elements in the specified collection have the specified properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if all elements have the specified properties set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefault(names));

    /// <summary>
    /// Determines whether all specified properties of an object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if all specified properties are set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesDefault<T>(this T? input, params string[]? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return default;
        }

        var props = GetCachedProperties(input.GetType()).Where(x => names.Contains(x.Name));

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether all elements in the specified collection have the specified properties set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if all elements have the specified properties set to their default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input, params string[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefault(names));
    #endregion

    #region AnyPropertiesNotDefault
    /// <summary>
    /// Determines whether any properties of the specified object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if at least one property is not set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotDefault<T>(this T? input) where T : class
    {
        if (input.IsNull())
        {
            return default;
        }

        var props = GetCachedProperties(input.GetType());

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one property that is not set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element has a property that is not set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether any elements in the specified array have at least one property that is not set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element has a property that is not set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotDefaults<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether any specified properties of an object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if at least one specified property is not set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotDefault<T>(this T? input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        var props = GetCachedProperties(input.GetType()).Where(x => names.Contains(x.Name));

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one of the specified properties that is not set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if at least one element has a specified property that is not set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefault(names));

    /// <summary>
    /// Determines whether any specified properties of an object are not set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if at least one specified property is not set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotDefault<T>(this T? input, params string[]? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        var props = GetCachedProperties(input.GetType()).Where(x => names.Contains(x.Name));

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (!EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one of the specified properties that is not set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if at least one element has a specified property that is not set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input, params string[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefault(names));
    #endregion

    #region AnyPropertiesDefault
    /// <summary>
    /// Determines whether any properties of the specified object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <returns><see langword="true"/> if at least one property is set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesDefault<T>(this T? input) where T : class
    {
        if (input.IsNull())
        {
            return default;
        }

        var props = GetCachedProperties(input.GetType());

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one property set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <returns><see langword="true"/> if at least one element has a property set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesDefault());

    /// <summary>
    /// Determines whether any elements in the specified array have at least one property set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to check.</param>
    /// <returns><see langword="true"/> if at least one element has a property set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesDefaults<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesDefault());

    /// <summary>
    /// Determines whether any specified properties of an object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if at least one specified property is set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesDefault<T>(this T? input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        var props = GetCachedProperties(input.GetType()).Where(x => names.Contains(x.Name));

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one of the specified properties set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The collection of property names to check.</param>
    /// <returns><see langword="true"/> if at least one element has a specified property set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefault(names));

    /// <summary>
    /// Determines whether any specified properties of an object are set to their default values.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="input">The object to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if at least one specified property is set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesDefault<T>(this T? input, params string[]? names) where T : class
    {
        if (input.IsNull() || names.IsNullEmpty() || names.AllNullWhiteSpace())
        {
            return false;
        }

        var props = GetCachedProperties(input.GetType()).Where(x => names.Contains(x.Name));

        foreach (var prop in props)
        {
            var type = prop.PropertyType;

            if (EqualityComparer<object>.Default.Equals(prop.GetValue(input), type.IsValueType ? CreateInstance(type) : default))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether any elements in the specified collection have at least one of the specified properties set to its default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="input">The collection to check.</param>
    /// <param name="names">The array of property names to check.</param>
    /// <returns><see langword="true"/> if at least one element has a specified property set to its default value; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input, params string[]? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefault(names));
    #endregion
}
