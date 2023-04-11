using System.Text;
using static System.Convert;
using static System.StringComparison;

namespace YANLib;

public static partial class YANText
{
    public static bool Equal(this string str1, string str2) => string.Equals(str1, str2, OrdinalIgnoreCase);

    public static bool Compare(params string[] strs) => strs?.Length > 0 && !strs.Any(s => s != strs.FirstOrDefault());

    public static string ToTitle(this string str)
    {
        if (str.IsNullOrWhiteSpace())
        {
            return str;
        }
        var sb = new StringBuilder(str);
        var isNewWord = true;
        for (var i = 0; i < sb.Length; i++)
        {
            sb[i] = isNewWord && sb[i].IsAlphabetic() ? sb[i].ToUpper() : sb[i].ToLower();
            isNewWord = sb[i].IsWhiteSpace();
        }
        return sb.ToString();
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
                    sb.Append(' ');
                    isWhtSp = true;
                }
            }
            else
            {
                sb.Append(str[i]);
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
            if (isPrevCharWhtSp)
            {
                sb.Append(str[i].ToUpper());
            }
            else
            {
                sb.Append(str[i].ToLower());
            }
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
                sb.Append(str[i]);
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
                sb.Append(str[i]);
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
                sb.Append(str[i]);
            }
        }
        return sb.ToString();
    }

    public static string RemoveSpacesAroundCharacter(this string str, char c)
    {
        if (str.IsNullOrWhiteSpace())
        {
            return str;
        }
        var sb = new StringBuilder();
        for (var i = 0; i < str.Length; i++)
        {
            if (str[i] == c && (i > 0 && str[i - 1].IsWhiteSpace() || i < str.Length - 1 && str[i + 1].IsWhiteSpace()))
            {
                continue;
            }
            sb.Append(str[i]);
        }
        return sb.ToString();
    }

    public static string FixBullet(this string str)
    {
        if (str.IsNullOrWhiteSpace())
        {
            return str;
        }
        var sb = new StringBuilder();
        for (var i = 0; i < str.Length; i++)
        {
            if (i > 0 && str[i - 1] is '-' or '+' && (i == 1 || i > 1 && str[i - 2] == '\n'))
            {
                sb.Append(' ');
            }
            sb.Append(str[i]);
        }
        return sb.ToString();
    }

    public static bool IsWhiteSpace(this char c) => char.IsWhiteSpace(c);

    public static bool IsNotWhiteSpace(this char c) => !char.IsWhiteSpace(c);

    public static bool IsAlphabetic(this char c) => char.IsLetter(c);

    public static bool IsNotAlphabetic(this char c) => !char.IsLetter(c);

    public static bool IsPunctuation(this char c) => char.IsPunctuation(c);

    public static bool IsNotPunctuation(this char c) => !char.IsPunctuation(c);

    public static bool IsNumber(this char c) => char.IsDigit(c);

    public static bool IsNotNumber(this char c) => !char.IsDigit(c);

    public static char ToLower(this char c) => char.ToLower(c);

    public static char ToUpper(this char c) => char.ToUpper(c);

    public static int ToUnicode(this char c) => ToInt32(c);

    public static bool Equal(this char c1, char c2) => char.ToLower(c1) == char.ToLower(c2);

    public static bool Compare(params char[] cs) => cs?.Length > 0 && !cs.Any(s => s != cs.FirstOrDefault());
}