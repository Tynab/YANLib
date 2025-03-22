using System.Diagnostics;
using YANLib.Object;
using YANLib.Text;
using static System.Activator;

namespace YANLib.Implements.Object;

internal static partial class YANObject
{
    #region AllPropertiesNotDefault
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesNotDefaultImplement<T>(this T? input) where T : class
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesNotDefaultImplement<T>(this T? input, IEnumerable<string?>? names) where T : class
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesDefaultImplement(names));
    #endregion

    #region AllPropertiesDefault
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesDefaultImplement<T>(this T? input) where T : class
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.AnyPropertiesNotDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesDefaultImplement<T>(this T? input, IEnumerable<string?>? names) where T : class
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && !input.Any(x => x.AnyPropertiesNotDefaultImplement(names));
    #endregion

    #region AnyPropertiesNotDefault
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesNotDefaultImplement<T>(this T? input) where T : class
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesNotDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesNotDefaultImplement<T>(this T? input, IEnumerable<string?>? names) where T : class
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesNotDefaultImplement(names));
    #endregion

    #region AnyPropertiesDefault
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesDefaultImplement<T>(this T? input) where T : class
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.AnyPropertiesDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesDefaultImplement<T>(this T? input, IEnumerable<string?>? names) where T : class
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

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmpty() && names.IsNotNullEmpty() && names.AllNotNullWhiteSpace() && input.Any(x => x.AnyPropertiesDefaultImplement(names));
    #endregion
}
