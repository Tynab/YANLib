using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANText
{
    public static IEnumerable<string?> Titles(this IEnumerable<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Title();
        }
    }

    public static IEnumerable<string?> Titles(this ICollection<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Title();
        }
    }

    public static IEnumerable<string?> Titles(params string?[]? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Title();
        }
    }

    public static IEnumerable<string?> Capitalizes(this IEnumerable<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Capitalize();
        }
    }

    public static IEnumerable<string?> Capitalizes(this ICollection<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Capitalize();
        }
    }

    public static IEnumerable<string?> Capitalizes(params string?[]? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Capitalize();
        }
    }

    public static IEnumerable<string?> CleanSpaces(this IEnumerable<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.CleanSpace();
        }
    }

    public static IEnumerable<string?> CleanSpaces(this ICollection<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.CleanSpace();
        }
    }

    public static IEnumerable<string?> CleanSpaces(params string?[]? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.CleanSpace();
        }
    }

    public static IEnumerable<string?> FormatNames(this IEnumerable<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FormatName();
        }
    }

    public static IEnumerable<string?> FormatNames(this ICollection<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FormatName();
        }
    }

    public static IEnumerable<string?> FormatNames(params string?[]? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FormatName();
        }
    }

    public static IEnumerable<string?> FilterAlphabetics(this IEnumerable<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FilterAlphabetic();
        }
    }

    public static IEnumerable<string?> FilterAlphabetics(this ICollection<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FilterAlphabetic();
        }
    }

    public static IEnumerable<string?> FilterAlphabetics(params string?[]? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FilterAlphabetic();
        }
    }

    public static IEnumerable<string?> FilterNumbers(this IEnumerable<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FilterNumber();
        }
    }

    public static IEnumerable<string?> FilterNumbers(this ICollection<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FilterNumber();
        }
    }

    public static IEnumerable<string?> FilterNumbers(params string?[]? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FilterNumber();
        }
    }

    public static IEnumerable<string?> FilterAlphanumerics(this IEnumerable<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FilterAlphanumeric();
        }
    }

    public static IEnumerable<string?> FilterAlphanumerics(this ICollection<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FilterAlphanumeric();
        }
    }

    public static IEnumerable<string?> FilterAlphanumerics(params string?[]? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.FilterAlphanumeric();
        }
    }
}
