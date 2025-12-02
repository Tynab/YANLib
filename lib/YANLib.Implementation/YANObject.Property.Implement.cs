using System.Diagnostics;
using static System.Activator;
using static System.Reflection.BindingFlags;
using static System.StringSplitOptions;

namespace YANLib.Implementation;

internal static partial class YANObject
{
    #region Valid Field

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsValidFieldImplement<T>(this string? input) where T : class => input.IsNotNullWhiteSpaceImplement() && typeof(T).GetProperty(input.Split(' ', RemoveEmptyEntries)[0], Instance | Public | IgnoreCase).IsNotNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllValidFieldsImplement<T>(this IEnumerable<string?>? input) where T : class => input.IsNotNullEmptyImplement() && input.All(static x => x.IsValidFieldImplement<T>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyValidFieldImplement<T>(this IEnumerable<string?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsValidFieldImplement<T>());

    #endregion

    #region AllPropertiesDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesDefaultImplement<T>(this T? input) where T : class
    {
        if (input.IsNullImplement())
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
    internal static bool AllPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && !input.Any(static x => x.AnyPropertiesNotDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesDefaultImplement<T>(this T? input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNullImplement() || names.IsNullEmptyImplement() || names.AllNullWhiteSpaceImplement())
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
        => input.IsNotNullEmptyImplement() && names.IsNotNullEmptyImplement() && names.AllNotNullWhiteSpaceImplement() && !input.Any(x => x.AnyPropertiesNotDefaultImplement(names));

    #endregion

    #region AllPropertiesNotDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesNotDefaultImplement<T>(this T? input) where T : class
    {
        if (input.IsNullImplement())
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
    internal static bool AllPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && !input.Any(static x => x.AnyPropertiesDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesNotDefaultImplement<T>(this T? input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNullImplement() || names.IsNullEmptyImplement() || names.AllNullWhiteSpaceImplement())
        {
            return false;
        }

        var props = GetCachedProperties(input.GetType()).Where(x => names.Contains(x.Name));

        if (props.IsNullEmptyImplement())
        {
            return false;
        }

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
        => input.IsNotNullEmptyImplement() && names.IsNotNullEmptyImplement() && names.AllNotNullWhiteSpaceImplement() && !input.Any(x => x.AnyPropertiesDefaultImplement(names));

    #endregion

    #region AnyPropertiesDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesDefaultImplement<T>(this T? input) where T : class
    {
        if (input.IsNullImplement())
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
    internal static bool AnyPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(static x => x.AnyPropertiesDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesDefaultImplement<T>(this T? input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNullImplement() || names.IsNullEmptyImplement() || names.AllNullWhiteSpaceImplement())
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
        => input.IsNotNullEmptyImplement() && names.IsNotNullEmptyImplement() && names.AllNotNullWhiteSpaceImplement() && input.Any(x => x.AnyPropertiesDefaultImplement(names));

    #endregion

    #region AnyPropertiesNotDefault
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesNotDefaultImplement<T>(this T? input) where T : class
    {
        if (input.IsNullImplement())
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
    internal static bool AnyPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(static x => x.AnyPropertiesNotDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesNotDefaultImplement<T>(this T? input, IEnumerable<string?>? names) where T : class
    {
        if (input.IsNullImplement() || names.IsNullEmptyImplement() || names.AllNullWhiteSpaceImplement())
        {
            return false;
        }

        var props = GetCachedProperties(input.GetType()).Where(x => names.Contains(x.Name));

        if (props.IsNullEmptyImplement())
        {
            return false;
        }

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
        => input.IsNotNullEmptyImplement() && names.IsNotNullEmptyImplement() && names.AllNotNullWhiteSpaceImplement() && input.Any(x => x.AnyPropertiesNotDefaultImplement(names));

    #endregion
}
