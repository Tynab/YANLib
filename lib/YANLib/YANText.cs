using System.Text;
using static System.Globalization.CultureInfo;

namespace YANLib;

public static partial class YANText
{

    public static string ToTitle(this string str) => str.IsWhiteSpaceOrNull() ? str : CurrentCulture.TextInfo.ToTitleCase(str);

    public static IEnumerable<string> ToTitle(this IEnumerable<string> strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToTitle();
        }
    }

    public static string ToCapitalize(this string str)
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
                sb[i] = sb[i].ToUpper();
                is1stChar = false;
            }
            else
            {
                sb[i] = sb[i].ToLower();
            }
        }

        return sb.ToString();
    }

    public static IEnumerable<string> ToCapitalize(this IEnumerable<string> strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.ToCapitalize();
        }
    }

    public static string CleanSpace(this string str)
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

    public static IEnumerable<string> CleanSpace(this IEnumerable<string> strs)
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

    public static string FormatName(this string str)
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

            _ = isPrevCharWhtSp ? sb.Append(str[i].ToUpper()) : sb.Append(str[i].ToLower());
            isPrevCharWhtSp = str[i].IsWhiteSpace();
        }

        return sb.ToString();
    }

    public static IEnumerable<string> FormatName(this IEnumerable<string> strs)
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

    public static string FilterAlphabetic(this string str)
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

    public static IEnumerable<string> FilterAlphabetic(this IEnumerable<string> strs)
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

    public static string FilterNumber(this string str)
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

    public static IEnumerable<string> FilterNumber(this IEnumerable<string> strs)
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

    public static string FilterAlphanumeric(this string str)
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

    public static IEnumerable<string> FilterAlphanumeric(this IEnumerable<string> strs)
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