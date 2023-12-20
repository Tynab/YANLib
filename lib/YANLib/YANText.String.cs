using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using static System.StringComparison;

namespace YANLib;

public static partial class YANText
{

    public static bool IsNull([NotNullWhen(false)] this string? str) => str is null;

    public static bool AllNull(params string?[] strs) => strs is not null && !strs.Any(x => x.IsNotNull());

    public static bool AnyNull(params string?[] strs) => strs is not null && strs.Any(x => x.IsNull());

    public static bool AllNull(this IEnumerable<string?> strs) => strs is not null && !strs.Any(x => x.IsNotNull());

    public static bool AnyNull(this IEnumerable<string?> strs) => strs is not null && strs.Any(x => x.IsNull());

    public static bool IsEmptyOrNull([NotNullWhen(false)] this string? str) => string.IsNullOrEmpty(str);

    public static bool AllEmptyOrNull(params string?[] strs) => strs is not null && !strs.Any(x => x.IsNotEmptyAndNull());

    public static bool AnyEmptyOrNull(params string?[] strs) => strs is not null && strs.Any(x => x.IsEmptyOrNull());

    public static bool AllEmptyOrNull(this IEnumerable<string?> strs) => strs is not null && !strs.Any(x => x.IsNotEmptyAndNull());

    public static bool AnyEmptyOrNull(this IEnumerable<string?> strs) => strs is not null && strs.Any(x => x.IsEmptyOrNull());

    public static bool IsWhiteSpaceOrNull([NotNullWhen(false)] this string? str) => string.IsNullOrWhiteSpace(str);

    public static bool AllWhiteSpaceOrNull(params string?[] strs) => strs is not null && !strs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AnyWhiteSpaceOrNull(params string?[] strs) => strs is not null && strs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AllWhiteSpaceOrNull(this IEnumerable<string?> strs) => strs is not null && !strs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AnyWhiteSpaceOrNull(this IEnumerable<string?> strs) => strs is not null && strs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool EqualsIgnoreCase(this string? str1, string? str2) => AllNull(str1, str2) || str1.IsNotNull() && str1.IsNotNull() && string.Equals(str1, str2, OrdinalIgnoreCase);

    public static bool AllEqualsIgnoreCase(params string?[] strs) => strs is not null && !strs.Any(x => x.NotEqualsIgnoreCase(strs[0]));

    public static bool AnyEqualsIgnoreCase(params string?[] strs) => !strs.AllNotEqualsIgnoreCase();

    public static bool AllEqualsIgnoreCase(this IEnumerable<string?> strs) => strs is not null && !strs.Any(x => x.NotEqualsIgnoreCase(strs.First()));

    public static bool AnyEqualsIgnoreCase(this IEnumerable<string?> strs) => !strs.AllNotEqualsIgnoreCase();

    public static bool IsNotNull([NotNullWhen(true)] this string? str) => str is not null;

    public static bool AllNotNull(params string?[] strs) => strs is not null && !strs.Any(x => x.IsNull());

    public static bool AnyNotNull(params string?[] strs) => strs is not null && strs.Any(x => x.IsNotNull());

    public static bool AllNotNull(this IEnumerable<string?> strs) => strs is not null && !strs.Any(x => x.IsNull());

    public static bool AnyNotNull(this IEnumerable<string?> strs) => strs is not null && strs.Any(x => x.IsNotNull());

    public static bool IsNotEmptyAndNull([NotNullWhen(true)] this string? str) => !string.IsNullOrEmpty(str);

    public static bool AllNotEmptyAndNull(params string?[] strs) => strs is not null && !strs.Any(x => x.IsEmptyOrNull());

    public static bool AnyNotEmptyAndNull(params string?[] strs) => strs is not null && strs.Any(x => x.IsNotEmptyAndNull());

    public static bool AllNotEmptyAndNull(this IEnumerable<string?> strs) => strs is not null && !strs.Any(x => x.IsEmptyOrNull());

    public static bool AnyNotEmptyAndNull(this IEnumerable<string?> strs) => strs is not null && strs.Any(x => x.IsNotEmptyAndNull());

    public static bool IsNotWhiteSpaceAndNull([NotNullWhen(true)] this string? str) => !string.IsNullOrWhiteSpace(str);

    public static bool AllNotWhiteSpaceAndNull(params string?[] strs) => strs is not null && !strs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AnyNotWhiteSpaceAndNull(params string?[] strs) => strs is not null && strs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AllNotWhiteSpaceAndNull(this IEnumerable<string?> strs) => strs is not null && !strs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AnyNotWhiteSpaceAndNull(this IEnumerable<string?> strs) => strs is not null && strs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool NotEqualsIgnoreCase(this string? str1, string? str2) => AllNotNull(str1, str2) && !string.Equals(str1, str2, OrdinalIgnoreCase);

    public static bool AllNotEqualsIgnoreCase(params string?[] strs)
    {
        if (strs is null || strs.Length < 2)
        {
            return false;
        }

        var hashSet = new HashSet<string?>(strs.Length, StringComparer.OrdinalIgnoreCase);

        for (var i = 0; i < strs.Length; i++)
        {
            if (!hashSet.Add(strs[i]))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AnyNotEqualsIgnoreCase(params string?[] strs) => !strs.AllEqualsIgnoreCase();

    public static bool AllNotEqualsIgnoreCase(this IEnumerable<string?> strs)
    {
        if (strs is null || strs.Count() < 2)
        {
            return false;
        }

        var hashSet = new HashSet<string?>(strs.Count(), StringComparer.OrdinalIgnoreCase);

        foreach (var str in strs)
        {
            if (!hashSet.Add(str))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<string?> strs) => !strs.AllEqualsIgnoreCase();

    public static string GetValue(this string? str) => str ?? string.Empty;

    public static string GetValue(this string? str, string dfltVal) => str ?? dfltVal;

    public static string GetValue(this string? str, char dfltVal) => str ?? (dfltVal.IsNotEmpty() ? dfltVal.ToString() : string.Empty);

    public static string? ToLower(this string? str) => str.IsNotWhiteSpaceAndNull() ? str.ToLower() : str;

    public static IEnumerable<string?> ToLower(this IEnumerable<string?> strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return ToLower(str);
        }
    }

    public static string? ToLowerInvariant(this string? str) => str.IsNotWhiteSpaceAndNull() ? str.ToLower(CultureInfo.InvariantCulture) : str;

    public static IEnumerable<string?> ToLowerInvariant(this IEnumerable<string?> strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return ToLowerInvariant(str);
        }
    }

    public static string? ToUpper(this string? str) => str.IsNotWhiteSpaceAndNull() ? str.ToUpper() : str;

    public static IEnumerable<string?> ToUpper(this IEnumerable<string?> strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return ToUpper(str);
        }
    }

    public static string? ToUpperInvariant(this string? str) => str.IsNotWhiteSpaceAndNull() ? str.ToUpper(CultureInfo.InvariantCulture) : str;

    public static IEnumerable<string?> ToUpperInvariant(this IEnumerable<string?> strs)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return ToUpperInvariant(str);
        }
    }
}
