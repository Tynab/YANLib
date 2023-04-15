using System.Globalization;
using System.Text;
using static System.Convert;

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

    public static char ToLower(this char c) => char.ToLower(c);

    public static void ToLower(ref char c) => c = ToLower(c);

    public static IEnumerable<char> ToLower(params char[] cs)
    {
        if (cs is null || cs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Length; i++)
        {
            yield return ToLower(cs[i]);
        }
    }

    public static IEnumerable<char> ToLower(this IEnumerable<char> cs)
    {
        if (cs is null || !cs.Any())
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToLower(c);
        }
    }

    public static IEnumerable<char> ToLower(this IReadOnlyCollection<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToLower(c);
        }
    }

    public static IEnumerable<char> ToLower(this IReadOnlyList<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Count; i++)
        {
            yield return ToLower(cs[i]);
        }
    }

    public static IEnumerable<char> ToLower(this IReadOnlySet<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToLower(c);
        }
    }

    public static char ToUpper(this char c) => char.ToUpper(c);

    public static void ToUpper(ref char c) => c = ToUpper(c);

    public static IEnumerable<char> ToUpper(params char[] cs)
    {
        if (cs is null || cs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Length; i++)
        {
            yield return ToUpper(cs[i]);
        }
    }

    public static IEnumerable<char> ToUpper(this IEnumerable<char> cs)
    {
        if (cs is null || !cs.Any())
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToUpper(c);
        }
    }

    public static IEnumerable<char> ToUpper(this IReadOnlyCollection<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToUpper(c);
        }
    }

    public static IEnumerable<char> ToUpper(this IReadOnlyList<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Count; i++)
        {
            yield return ToUpper(cs[i]);
        }
    }

    public static IEnumerable<char> ToUpper(this IReadOnlySet<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToUpper(c);
        }
    }
}