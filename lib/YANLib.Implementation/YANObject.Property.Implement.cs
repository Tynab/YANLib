using static System.StringSplitOptions;

namespace YANLib.Implementation;

internal static partial class YANObject
{
    #region ValidField

    public static bool IsValidFieldImplement<T>(this string? input) where T : class => input.IsNotNullWhiteSpaceImplement() && typeof(T).GetPropertyImplement(input.Split(' ', RemoveEmptyEntries)[0]) is not null;

    public static bool AllValidFieldsImplement<T>(this IEnumerable<string?>? input) where T : class => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotValidFieldImplement<T>());

    public static bool AnyValidFieldImplement<T>(this IEnumerable<string?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsValidFieldImplement<T>());

    #endregion

    #region NotValidField

    public static bool IsNotValidFieldImplement<T>(this string? input) where T : class => !input.IsValidFieldImplement<T>();

    public static bool AllNotValidFieldsImplement<T>(this IEnumerable<string?>? input) where T : class => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsValidFieldImplement<T>());

    public static bool AnyNotValidFieldImplement<T>(this IEnumerable<string?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotValidFieldImplement<T>());

    #endregion

    #region AllPropertiesDefault

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

    internal static bool AllPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.All(static x => x.AllPropertiesDefaultImplement());

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

    internal static bool AllPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmptyImplement() && names.IsNotNullEmptyImplement() && names.AllNotNullWhiteSpaceImplement() && input.All(x => x.AllPropertiesDefaultImplement(names));

    #endregion

    #region AllPropertiesNotDefault

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

    internal static bool AllPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.All(static x => x.AllPropertiesNotDefaultImplement());

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

    internal static bool AllPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmptyImplement() && names.IsNotNullEmptyImplement() && names.AllNotNullWhiteSpaceImplement() && input.All(x => x.AllPropertiesNotDefaultImplement(names));

    #endregion

    #region AnyPropertiesDefault

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

    internal static bool AnyPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(static x => x.AnyPropertiesDefaultImplement());

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

    internal static bool AnyPropertiesDefaultsImplement<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmptyImplement() && names.IsNotNullEmptyImplement() && names.AllNotNullWhiteSpaceImplement() && input.Any(x => x.AnyPropertiesDefaultImplement(names));

    #endregion

    #region AnyPropertiesNotDefault

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

    internal static bool AnyPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmptyImplement() && input.Any(static x => x.AnyPropertiesNotDefaultImplement());

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

    internal static bool AnyPropertiesNotDefaultsImplement<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class
        => input.IsNotNullEmptyImplement() && names.IsNotNullEmptyImplement() && names.AllNotNullWhiteSpaceImplement() && input.Any(x => x.AnyPropertiesNotDefaultImplement(names));

    #endregion
}
