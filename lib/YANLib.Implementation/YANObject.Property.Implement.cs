using System.Diagnostics;
using static System.Reflection.BindingFlags;
using static System.StringSplitOptions;

namespace YANLib.Implementation;

internal static partial class YANObject
{
    #region ValidField

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsValidFieldImplement<T>(this string? input) where T : class => input.IsNotNullWhiteSpaceImplement() && typeof(T).GetProperty(input.Split(' ', RemoveEmptyEntries)[0], Instance | Public | IgnoreCase) is not null;

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllValidFieldsImplement<T>(this IEnumerable<string?>? input) where T : class => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotValidFieldImplement<T>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyValidFieldImplement<T>(this IEnumerable<string?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsValidFieldImplement<T>());

    #endregion

    #region NotValidField

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotValidFieldImplement<T>(this string? input) where T : class => input.IsNotNullWhiteSpaceImplement() && typeof(T).GetProperty(input.Split(' ', RemoveEmptyEntries)[0], Instance | Public | IgnoreCase) is null;

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotValidFieldsImplement<T>(this IEnumerable<string?>? input) where T : class => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsValidFieldImplement<T>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotValidFieldImplement<T>(this IEnumerable<string?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotValidFieldImplement<T>());

    #endregion

    #region AllPropertiesDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesDefaultImplement<T>(this T? input) where T : class
    {
        if (input is null)
        {
            return default;
        }

        foreach (var prop in GetCachedProperties(input.GetType()))
        {
            if (!prop.IsDefaultValue(input))
            {
                return false;
            }
        }

        return true;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.All(static x => x.AllPropertiesDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesDefaultImplement<T>(this T? input, IEnumerable<string?>? names) where T : class
    {
        if (input is null || names.IsNullEmptyImplement() || names.AllNullWhiteSpaceImplement())
        {
            return false;
        }

        var props = GetCachedProperties(input.GetType(), names);

        if (props.Length is 0)
        {
            return false;
        }

        foreach (var prop in props)
        {
            if (!prop.IsDefaultValue(input))
            {
                return false;
            }
        }

        return true;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmptyImplement() && names.IsNotNullEmptyImplement() && names.AllNotNullWhiteSpaceImplement() && input.All(x => x.AllPropertiesDefaultImplement(names));

    #endregion

    #region AllPropertiesNotDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesNotDefaultImplement<T>(this T? input) where T : class
    {
        if (input is null)
        {
            return default;
        }

        foreach (var prop in GetCachedProperties(input.GetType()))
        {
            if (prop.IsDefaultValue(input))
            {
                return false;
            }
        }

        return true;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.All(static x => x.AllPropertiesNotDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesNotDefaultImplement<T>(this T? input, IEnumerable<string?>? names) where T : class
    {
        if (input is null || names.IsNullEmptyImplement() || names.AllNullWhiteSpaceImplement())
        {
            return false;
        }

        var props = GetCachedProperties(input.GetType(), names);

        if (props.Length is 0)
        {
            return false;
        }

        foreach (var prop in props)
        {
            if (prop.IsDefaultValue(input))
            {
                return false;
            }
        }

        return true;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmptyImplement() && names.IsNotNullEmptyImplement() && names.AllNotNullWhiteSpaceImplement() && input.All(x => x.AllPropertiesNotDefaultImplement(names));

    #endregion

    #region AnyPropertiesDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPropertiesDefaultImplement<T>(this T? input) where T : class
    {
        if (input is null)
        {
            return default;
        }

        foreach (var prop in GetCachedProperties(input.GetType()))
        {
            if (prop.IsDefaultValue(input))
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
        if (input is null || names.IsNullEmptyImplement() || names.AllNullWhiteSpaceImplement())
        {
            return false;
        }

        foreach (var prop in GetCachedProperties(input.GetType(), names))
        {
            if (prop.IsDefaultValue(input))
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
        if (input is null)
        {
            return default;
        }

        foreach (var prop in GetCachedProperties(input.GetType()))
        {
            if (!prop.IsDefaultValue(input))
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
        if (input is null || names.IsNullEmptyImplement() || names.AllNullWhiteSpaceImplement())
        {
            return false;
        }

        foreach (var prop in GetCachedProperties(input.GetType(), names))
        {
            if (!prop.IsDefaultValue(input))
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
