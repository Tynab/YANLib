using System.Globalization;
using static System.StringComparison;
using static System.Globalization.CultureInfo;

namespace YANLib;

public static partial class YANText
{
    
    public static bool IsNull(this string str) => str is null;

    public static bool IsNull(params string[] strs) => strs is not null && !strs.Any(s => s.IsNotNull());

    public static bool IsNull(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNotNull());

    public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

    public static bool IsNullOrEmpty(params string[] strs) => strs is not null && !strs.Any(s => s.IsNotNullAndEmpty());

    public static bool IsNullOrEmpty(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullAndEmpty());

    public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

    public static bool IsNullOrWhiteSpace(params string[] strs) => strs is not null && !strs.Any(s => s.IsNotNullAndWhiteSpace());

    public static bool IsNullOrWhiteSpace(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullAndWhiteSpace());

    public static bool Equals(this string str1, string str2) => str1 == str2;

    public static bool Equals(params string[] strs) => strs is not null && !strs.Any(s => s.NotEquals(strs[0]));

    public static bool Equals(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.NotEquals(strs.First()));

    public static bool EqualsIgnoreCase(this string str1, string str2) => IsNull(str1, str2) || str1.IsNotNull() && str1.IsNotNull() && string.Equals(str1, str2, OrdinalIgnoreCase);

    public static bool EqualsIgnoreCase(params string[] strs) => strs is not null && !strs.Any(s => s.NotEqualsIgnoreCase(strs[0]));

    public static bool EqualsIgnoreCase(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.NotEqualsIgnoreCase(strs.First()));

    public static bool IsNotNull(this string str) => str is not null;

    public static bool IsNotNull(params string[] strs) => strs is not null && !strs.Any(s => s.IsNull());

    public static bool IsNotNull(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNull());

    public static bool IsNotNullAndEmpty(this string str) => !string.IsNullOrEmpty(str);

    public static bool IsNotNullAndEmpty(params string[] strs) => strs is not null && !strs.Any(s => s.IsNullOrEmpty());

    public static bool IsNotNullAndEmpty(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrEmpty());

    public static bool IsNotNullAndWhiteSpace(this string str) => !string.IsNullOrWhiteSpace(str);

    public static bool IsNotNullAndWhiteSpace(params string[] strs) => strs is not null && !strs.Any(s => s.IsNullOrWhiteSpace());

    public static bool IsNotNullAndWhiteSpace(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrWhiteSpace());

    public static bool NotEquals(this string str1, string str2) => str1 != str2;

    public static bool NotEquals(params string[] strs)
    {
        if (strs is null || strs.Length < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Length);
        for (var i = 0; i < strs.Length; i++)
        {
            if (!hashSet.Add(strs[i]))
            {
                return false;
            }
        }
        return true;
    }

    public static bool NotEquals(this IEnumerable<string> strs)
    {
        if (strs is null || strs.Count() < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Count());
        foreach (var str in strs)
        {
            if (!hashSet.Add(str))
            {
                return false;
            }
        }
        return true;
    }

    public static bool NotEqualsIgnoreCase(this string str1, string str2) => IsNotNull(str1, str2) && !string.Equals(str1, str2, OrdinalIgnoreCase);

    public static bool NotEqualsIgnoreCase(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Length, StringComparer.OrdinalIgnoreCase);
        for (var i = 0; i < strs.Length; i++)
        {
            if (!hashSet.Add(strs[i]))
            {
                return false;
            }
        }
        return true;
    }

    public static bool NotEqualsIgnoreCase(this IEnumerable<string> strs)
    {
        if (strs is null || strs.Count() < 2)
        {
            return false;
        }
        var hashSet = new HashSet<string>(strs.Count(), StringComparer.OrdinalIgnoreCase);
        foreach (var str in strs)
        {
            if (!hashSet.Add(str))
            {
                return false;
            }
        }
        return true;
    }

    public static string GetValue(this string str) => str ?? string.Empty;

    public static string GetValue(this string str, string dfltVal) => str ?? dfltVal;

    public static string GetValue(this string str, char dfltVal) => str ?? (dfltVal.IsNotEmpty() ? dfltVal.ToString() : string.Empty);

    public static string ToLower(this string str) => str.IsNotNullAndWhiteSpace() ? str.ToLower() : str;

    public static IEnumerable<string> ToLower(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToLower(str);
        }
    }

    public static void ToLower(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = ToLower(strs[i]);
            }
        }
    }

    public static string ToLowerInvariant(this string str) => str.IsNotNullAndWhiteSpace() ? str.ToLower(CultureInfo.InvariantCulture) : str;

    public static IEnumerable<string> ToLowerInvariant(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToLowerInvariant(str);
        }
    }

    public static void ToLowerInvariant(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = ToLowerInvariant(strs[i]);
            }
        }
    }

    public static string ToUpper(this string str) => str.IsNotNullAndWhiteSpace() ? str.ToUpper() : str;

    public static IEnumerable<string> ToUpper(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToUpper(str);
        }
    }

    public static void ToUpper(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = ToUpper(strs[i]);
            }
        }
    }

    public static string ToUpperInvariant(this string str) => str.IsNotNullAndWhiteSpace() ? str.ToUpper(CultureInfo.InvariantCulture) : str;

    public static IEnumerable<string> ToUpperInvariant(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToUpperInvariant(str);
        }
    }

    public static void ToUpperInvariant(this IList<string> strs)
    {
        if (strs is not null && strs.Count > 0)
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = ToUpperInvariant(strs[i]);
            }
        }
    }
}
