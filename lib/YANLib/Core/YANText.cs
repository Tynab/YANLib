using System.Text;
using static System.Globalization.CultureInfo;

namespace YANLib.Core;

public static partial class YANText
{
    public static string? Title(this string? str) => str.IsWhiteSpaceOrNull() ? str : CurrentCulture.TextInfo.ToTitleCase(str);

    public static void Titles(this List<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            return;
        }

        strs.ForEach(x => x = x.Title());
    }

    public static IEnumerable<string?>? Titles(this IEnumerable<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Title());

    public static IEnumerable<string?>? Titles(this ICollection<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Title());

    public static IEnumerable<string?>? Titles(params string?[]? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Title());

    public static string? Capitalize(this string? str)
    {
        if (str.IsWhiteSpaceOrNull())
        {
            return str;
        }

        var sb = new StringBuilder(str);
        var is1stChar = true;

        for (var i = 0; i < sb.Length; i++)
        {
            if (is1stChar && sb[i].IsAlphabetic())
            {
                sb[i] = sb[i].Upper();
                is1stChar = false;
            }
            else
            {
                sb[i] = sb[i].Lower();
            }
        }

        return sb.ToString();
    }

    public static void Capitalizes(this List<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            return;
        }

        strs.ForEach(x => x = x.Capitalize());
    }

    public static IEnumerable<string?>? Capitalizes(this IEnumerable<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Capitalize());

    public static IEnumerable<string?>? Capitalizes(this ICollection<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Capitalize());

    public static IEnumerable<string?>? Capitalizes(params string?[]? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Capitalize());

    public static string? CleanSpace(this string? str)
    {
        if (str.IsEmptyOrNull())
        {
            return str;
        }

        str = str.Trim();

        var sb = new StringBuilder();
        var isWhtSp = false;

        for (var i = 0; i < str.Length; i++)
        {
            if (str[i].IsWhiteSpace())
            {
                if (!isWhtSp)
                {
                    _ = sb.Append(str[i]);
                    isWhtSp = true;
                }
            }
            else
            {
                _ = sb.Append(str[i]);
                isWhtSp = false;
            }
        }

        return sb.ToString();
    }

    public static void CleanSpace(this List<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            return;
        }

        strs.ForEach(x => x = x.CleanSpace());
    }

    public static IEnumerable<string?>? CleanSpaces(this IEnumerable<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.CleanSpace());

    public static IEnumerable<string?>? CleanSpaces(this ICollection<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.CleanSpace());

    public static IEnumerable<string?>? CleanSpaces(params string?[]? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.CleanSpace());

    public static string? FormatName(this string? str)
    {
        if (str.IsEmptyOrNull())
        {
            return str;
        }

        str = str.Trim();

        var sb = new StringBuilder();
        var isPrevCharWhtSp = true;

        for (var i = 0; i < str.Length; i++)
        {
            if (str[i].IsPunctuation() || str[i].IsNumber() || isPrevCharWhtSp && str[i].IsWhiteSpace())
            {
                continue;
            }

            _ = isPrevCharWhtSp ? sb.Append(str[i].Upper()) : sb.Append(str[i].Lower());
            isPrevCharWhtSp = str[i].IsWhiteSpace();
        }

        return sb.ToString();
    }

    public static void FormatName(this List<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            return;
        }

        strs.ForEach(x => x = x.FormatName());
    }

    public static IEnumerable<string?>? FormatNames(this IEnumerable<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FormatName());

    public static IEnumerable<string?>? FormatNames(this ICollection<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FormatName());

    public static IEnumerable<string?>? FormatNames(params string?[]? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FormatName());

    public static string? FilterAlphabetic(this string? str)
    {
        if (str.IsEmptyOrNull())
        {
            return str;
        }

        str = str.Trim();

        var sb = new StringBuilder();

        for (var i = 0; i < str.Length; i++)
        {
            if (str[i].IsAlphabetic())
            {
                _ = sb.Append(str[i]);
            }
        }

        return sb.ToString();
    }

    public static void FilterAlphabetic(this List<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            return;
        }

        strs.ForEach(x => x = x.FilterAlphabetic());
    }

    public static IEnumerable<string?>? FilterAlphabetics(this IEnumerable<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FilterAlphabetic());

    public static IEnumerable<string?>? FilterAlphabetics(this ICollection<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FilterAlphabetic());

    public static IEnumerable<string?>? FilterAlphabetics(params string?[]? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FilterAlphabetic());

    public static string? FilterNumber(this string? str)
    {
        if (str.IsEmptyOrNull())
        {
            return str;
        }

        str = str.Trim();

        var sb = new StringBuilder();

        for (var i = 0; i < str.Length; i++)
        {
            if (str[i].IsNumber())
            {
                _ = sb.Append(str[i]);
            }
        }

        return sb.ToString();
    }

    public static void FilterNumber(this List<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            return;
        }

        strs.ForEach(x => x = x.FilterNumber());
    }

    public static IEnumerable<string?>? FilterNumbers(this IEnumerable<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FilterNumber());

    public static IEnumerable<string?>? FilterNumbers(this ICollection<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FilterNumber());

    public static IEnumerable<string?>? FilterNumbers(params string?[]? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FilterNumber());

    public static string? FilterAlphanumeric(this string? str)
    {
        if (str.IsEmptyOrNull())
        {
            return str;
        }

        str = str.Trim();

        var sb = new StringBuilder();

        for (var i = 0; i < str.Length; i++)
        {
            if (str[i].IsNumber() || str[i].IsAlphabetic())
            {
                _ = sb.Append(str[i]);
            }
        }

        return sb.ToString();
    }

    public static void FilterAlphanumeric(this List<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            return;
        }

        strs.ForEach(x => x = x.FilterAlphanumeric());
    }

    public static IEnumerable<string?>? FilterAlphanumerics(this IEnumerable<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FilterAlphanumeric());

    public static IEnumerable<string?>? FilterAlphanumerics(this ICollection<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FilterAlphanumeric());

    public static IEnumerable<string?>? FilterAlphanumerics(params string?[]? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.FilterAlphanumeric());
}