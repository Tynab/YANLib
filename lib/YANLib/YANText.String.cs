using System.Globalization;
using static System.StringComparison;
using static System.Globalization.CultureInfo;

namespace YANLib;

public static partial class YANText
{
    
    public static bool IsNull(this string str) => str is null;

    public static bool AllNull(params string[] strs) => strs is not null && !strs.Any(s => s.IsNotNull());

    public static bool AnyNull(params string[] strs) => strs is not null && strs.Any(s => s.IsNull());

    public static bool AllNull(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNotNull());

    public static bool AnyNull(this IEnumerable<string> strs) => strs is not null && strs.Any(s => s.IsNull());

    public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

    public static bool AllNullOrEmpty(params string[] strs) => strs is not null && !strs.Any(s => s.IsNotNullAndEmpty());

    public static bool AnyNullOrEmpty(params string[] strs) => strs is not null && strs.Any(s => s.IsNullOrEmpty());

    public static bool AllNullOrEmpty(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullAndEmpty());

    public static bool AnyNullOrEmpty(this IEnumerable<string> strs) => strs is not null && strs.Any(s => s.IsNullOrEmpty());

    public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

    public static bool AllNullOrWhiteSpace(params string[] strs) => strs is not null && !strs.Any(s => s.IsNotNullAndWhiteSpace());

    public static bool AnyNullOrWhiteSpace(params string[] strs) => strs is not null && strs.Any(s => s.IsNullOrWhiteSpace());

    public static bool AllNullOrWhiteSpace(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNotNullAndWhiteSpace());

    public static bool AnyNullOrWhiteSpace(this IEnumerable<string> strs) => strs is not null && strs.Any(s => s.IsNullOrWhiteSpace());

    public static bool EqualsIgnoreCase(this string str1, string str2) => AllNull(str1, str2) || str1.IsNotNull() && str1.IsNotNull() && string.Equals(str1, str2, OrdinalIgnoreCase);

    public static bool AllEqualsIgnoreCase(params string[] strs) => strs is not null && !strs.Any(s => s.NotEqualsIgnoreCase(strs[0]));

    public static bool AnyEqualsIgnoreCase(params string[] strs) => !strs.AllNotEqualsIgnoreCase();

    public static bool AllEqualsIgnoreCase(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.NotEqualsIgnoreCase(strs.First()));

    public static bool AnyEqualsIgnoreCase(this IEnumerable<string> strs) => !strs.AllNotEqualsIgnoreCase();

    public static bool IsNotNull(this string str) => str is not null;

    public static bool AllNotNull(params string[] strs) => strs is not null && !strs.Any(s => s.IsNull());

    public static bool AnyNotNull(params string[] strs) => strs is not null && strs.Any(s => s.IsNotNull());

    public static bool AllNotNull(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNull());

    public static bool AnyNotNull(this IEnumerable<string> strs) => strs is not null && strs.Any(s => s.IsNotNull());

    public static bool IsNotNullAndEmpty(this string str) => !string.IsNullOrEmpty(str);

    public static bool AllNotNullAndEmpty(params string[] strs) => strs is not null && !strs.Any(s => s.IsNullOrEmpty());

    public static bool AnyNotNullAndEmpty(params string[] strs) => strs is not null && strs.Any(s => s.IsNotNullAndEmpty());

    public static bool AllNotNullAndEmpty(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrEmpty());

    public static bool AnyNotNullAndEmpty(this IEnumerable<string> strs) => strs is not null && strs.Any(s => s.IsNotNullAndEmpty());

    public static bool IsNotNullAndWhiteSpace(this string str) => !string.IsNullOrWhiteSpace(str);

    public static bool AllNotNullAndWhiteSpace(params string[] strs) => strs is not null && !strs.Any(s => s.IsNullOrWhiteSpace());

    public static bool AnyNotNullAndWhiteSpace(params string[] strs) => strs is not null && strs.Any(s => s.IsNotNullAndWhiteSpace());

    public static bool AllNotNullAndWhiteSpace(this IEnumerable<string> strs) => strs is not null && !strs.Any(s => s.IsNullOrWhiteSpace());

    public static bool AnyNotNullAndWhiteSpace(this IEnumerable<string> strs) => strs is not null && strs.Any(s => s.IsNotNullAndWhiteSpace());

    public static bool NotEqualsIgnoreCase(this string str1, string str2) => AllNotNull(str1, str2) && !string.Equals(str1, str2, OrdinalIgnoreCase);

    public static bool AllNotEqualsIgnoreCase(params string[] strs)
    {
        if (strs is null || strs.Length < 2)
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

    public static bool AnyNotEqualsIgnoreCase(params string[] strs) => !strs.AllEqualsIgnoreCase();

    public static bool AllNotEqualsIgnoreCase(this IEnumerable<string> strs)
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

    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<string> strs) => !strs.AllEqualsIgnoreCase();

    public static string GetValue(this string str) => str ?? string.Empty;

    public static string GetValue(this string str, string dfltVal) => str ?? dfltVal;

    public static string GetValue(this string str, char dfltVal) => str ?? (dfltVal.IsNotEmpty() ? dfltVal.ToString() : string.Empty);

    public static string ToLower(this string str) => str.IsNotNullAndWhiteSpace() ? str.ToLower() : str;

    public static IEnumerable<string> ToLower(this IEnumerable<string> strs)
    {
        if (strs.IsNullOrEmpty())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return ToLower(str);
        }
    }

    public static void ToLower(this ICollection<string> strs)
    {
        if (strs.IsNotNullAndEmpty())
        {
            foreach (var str in strs)
            {
                _ = ToLower(str);
            }
        }
    }

    public static string ToLowerInvariant(this string str) => str.IsNotNullAndWhiteSpace() ? str.ToLower(CultureInfo.InvariantCulture) : str;

    public static IEnumerable<string> ToLowerInvariant(this IEnumerable<string> strs)
    {
        if (strs.IsNullOrEmpty())
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
        if (strs.IsNotNullAndEmpty())
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
        if (strs.IsNullOrEmpty())
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
        if (strs.IsNotNullAndEmpty())
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
        if (strs.IsNullOrEmpty())
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
        if (strs.IsNotNullAndEmpty())
        {
            for (var i = 0; i < strs.Count; i++)
            {
                strs[i] = ToUpperInvariant(strs[i]);
            }
        }
    }
}
