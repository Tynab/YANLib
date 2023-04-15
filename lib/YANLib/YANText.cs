using System.Globalization;
using System.Text;

namespace YANLib;

public static partial class YANText
{
    public static string ToTitle(this string str) => str.IsNullOrWhiteSpace() ? str : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);

    public static void ToTitle(ref string str) => str = str.ToTitle();

    public static IEnumerable<string> ToTitle(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToTitle();
        }
    }

    public static IEnumerable<string> ToTitle(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToTitle();
        }
    }

    public static IEnumerable<string> ToTitle(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToTitle();
        }
    }

    public static IEnumerable<string> ToTitle(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToTitle();
        }
    }

    public static IEnumerable<string> ToTitle(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToTitle();
        }
    }

    public static void ToTitleRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].ToTitle();
            }
        }
    }

    public static string ToCapitalize(this string str)
    {
        if (str.IsNullOrWhiteSpace())
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

    public static void ToCapitalize(ref string str) => str = str.ToCapitalize();

    public static IEnumerable<string> ToCapitalize(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToCapitalize();
        }
    }

    public static IEnumerable<string> ToCapitalize(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToCapitalize();
        }
    }

    public static IEnumerable<string> ToCapitalize(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToCapitalize();
        }
    }

    public static IEnumerable<string> ToCapitalize(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToCapitalize();
        }
    }

    public static IEnumerable<string> ToCapitalize(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.ToCapitalize();
        }
    }

    public static void ToCapitalizeRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].ToCapitalize();
            }
        }
    }

    public static string CleanSpace(this string str)
    {
        if (str.IsNullOrEmpty())
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

    public static void CleanSpace(ref string str) => str = str.CleanSpace();

    public static IEnumerable<string> CleanSpace(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].CleanSpace();
        }
    }

    public static IEnumerable<string> CleanSpace(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.CleanSpace();
        }
    }

    public static IEnumerable<string> CleanSpace(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.CleanSpace();
        }
    }

    public static IEnumerable<string> CleanSpace(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].CleanSpace();
        }
    }

    public static IEnumerable<string> CleanSpace(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.CleanSpace();
        }
    }

    public static void CleanSpaceRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].CleanSpace();
            }
        }
    }

    public static string FormatName(this string str)
    {
        if (str.IsNullOrEmpty())
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

    public static void FormatName(ref string str) => str = str.FilterAlphabetic();

    public static IEnumerable<string> FormatName(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].FormatName();
        }
    }

    public static IEnumerable<string> FormatName(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FormatName();
        }
    }

    public static IEnumerable<string> FormatName(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FormatName();
        }
    }

    public static IEnumerable<string> FormatName(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].FormatName();
        }
    }

    public static IEnumerable<string> FormatName(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FormatName();
        }
    }

    public static void FormatNameRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].FormatName();
            }
        }
    }

    public static string FilterAlphabetic(this string str)
    {
        if (str.IsNullOrEmpty())
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

    public static void FilterAlphabetic(ref string str) => str = str.FilterAlphabetic();

    public static IEnumerable<string> FilterAlphabetic(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].FilterAlphabetic();
        }
    }

    public static IEnumerable<string> FilterAlphabetic(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FilterAlphabetic();
        }
    }

    public static IEnumerable<string> FilterAlphabetic(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FilterAlphabetic();
        }
    }

    public static IEnumerable<string> FilterAlphabetic(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].FilterAlphabetic();
        }
    }

    public static IEnumerable<string> FilterAlphabetic(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.CleanSpace();
        }
    }

    public static void FilterAlphabeticRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].FilterAlphabetic();
            }
        }
    }

    public static string FilterNumber(this string str)
    {
        if (str.IsNullOrEmpty())
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

    public static void FilterNumber(ref string str) => str = str.FilterNumber();

    public static IEnumerable<string> FilterNumber(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].FilterNumber();
        }
    }

    public static IEnumerable<string> FilterNumber(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FilterNumber();
        }
    }

    public static IEnumerable<string> FilterNumber(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FilterNumber();
        }
    }

    public static IEnumerable<string> FilterNumber(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].FilterNumber();
        }
    }

    public static IEnumerable<string> FilterNumber(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FilterNumber();
        }
    }

    public static void FilterNumberRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].FilterNumber();
            }
        }
    }

    public static string FilterAlphanumeric(this string str)
    {
        if (str.IsNullOrEmpty())
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

    public static void FilterAlphanumeric(ref string str) => str = str.FilterAlphanumeric();

    public static IEnumerable<string> FilterAlphanumeric(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].FilterAlphanumeric();
        }
    }

    public static IEnumerable<string> FilterAlphanumeric(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FilterAlphanumeric();
        }
    }

    public static IEnumerable<string> FilterAlphanumeric(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FilterAlphanumeric();
        }
    }

    public static IEnumerable<string> FilterAlphanumeric(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].FilterAlphanumeric();
        }
    }

    public static IEnumerable<string> FilterAlphanumeric(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.FilterAlphanumeric();
        }
    }

    public static void FilterAlphanumericRef(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = strs[i].FilterAlphanumeric();
            }
        }
    }
}