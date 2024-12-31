using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using static System.Linq.Enumerable;
using static System.StringComparison;
using static YANLib.Core.YANUnmanaged;

namespace YANLib.Core;

public static partial class YANText
{
    public static bool AllNull(this IEnumerable<string?> strs) => !strs.Any(x => x.IsNotNull());

    public static bool AllNull(this ICollection<string?> strs) => !strs.Any(x => x.IsNotNull());

    public static bool AllNull(params string?[] strs) => !strs.Any(x => x.IsNotNull());

    public static bool AnyNull(this IEnumerable<string?> strs) => strs.Any(x => x.IsNull());

    public static bool AnyNull(this ICollection<string?> strs) => strs.Any(x => x.IsNull());

    public static bool AnyNull(params string?[] strs) => strs.Any(x => x.IsNull());

    public static bool IsEmptyOrNull([NotNullWhen(false)] this string? str) => string.IsNullOrEmpty(str);

    public static bool AllEmptyOrNull(this IEnumerable<string?> strs) => !strs.Any(x => x.IsNotEmptyAndNull());

    public static bool AllEmptyOrNull(this ICollection<string?> strs) => !strs.Any(x => x.IsNotEmptyAndNull());

    public static bool AllEmptyOrNull(params string?[] strs) => !strs.Any(x => x.IsNotEmptyAndNull());

    public static bool AnyEmptyOrNull(this IEnumerable<string?> strs) => strs.Any(x => x.IsEmptyOrNull());

    public static bool AnyEmptyOrNull(this ICollection<string?> strs) => strs.Any(x => x.IsEmptyOrNull());

    public static bool AnyEmptyOrNull(params string?[] strs) => strs.Any(x => x.IsEmptyOrNull());

    public static bool IsWhiteSpaceOrNull([NotNullWhen(false)] this string? str) => string.IsNullOrWhiteSpace(str);

    public static bool AllWhiteSpaceOrNull(this IEnumerable<string?> strs) => !strs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AllWhiteSpaceOrNull(this ICollection<string?> strs) => !strs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AllWhiteSpaceOrNull(params string?[] strs) => !strs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AnyWhiteSpaceOrNull(this IEnumerable<string?> strs) => strs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AnyWhiteSpaceOrNull(this ICollection<string?> strs) => strs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AnyWhiteSpaceOrNull(params string?[] strs) => strs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool EqualsIgnoreCase(this string str1, string? str2) => AllNull(str1, str2) || str1.IsNotNull() && str1.IsNotNull() && string.Equals(str1, str2, OrdinalIgnoreCase);

    public static bool AllEqualsIgnoreCase(this IEnumerable<string?> strs) => !strs.Any(x => x.NotEqualsIgnoreCase(strs.First()));

    public static bool AllEqualsIgnoreCase(this ICollection<string?> strs) => !strs.Any(x => x.NotEqualsIgnoreCase(strs.First()));

    public static bool AllEqualsIgnoreCase(params string?[] strs) => !strs.Any(x => x.NotEqualsIgnoreCase(strs[0]));

    public static bool AnyEqualsIgnoreCase(this IEnumerable<string?> strs) => !strs.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(this ICollection<string?> strs) => !strs.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(params string?[] strs) => !strs.AllNotEqualsIgnoreCase();

    public static bool AllNotNull(this IEnumerable<string?> strs) => !strs.Any(x => x.IsNull());

    public static bool AllNotNull(this ICollection<string?> strs) => !strs.Any(x => x.IsNull());

    public static bool AllNotNull(params string?[] strs) => !strs.Any(x => x.IsNull());

    public static bool AnyNotNull(this IEnumerable<string?> strs) => strs.Any(x => x.IsNotNull());

    public static bool AnyNotNull(this ICollection<string?> strs) => strs.Any(x => x.IsNotNull());

    public static bool AnyNotNull(params string?[] strs) => strs.Any(x => x.IsNotNull());

    public static bool IsNotEmptyAndNull([NotNullWhen(true)] this string? str) => !string.IsNullOrEmpty(str);

    public static bool AllNotEmptyAndNull(this IEnumerable<string?> strs) => !strs.Any(x => x.IsEmptyOrNull());

    public static bool AllNotEmptyAndNull(this ICollection<string?> strs) => !strs.Any(x => x.IsEmptyOrNull());

    public static bool AllNotEmptyAndNull(params string?[] strs) => !strs.Any(x => x.IsEmptyOrNull());

    public static bool AnyNotEmptyAndNull(this IEnumerable<string?> strs) => strs.Any(x => x.IsNotEmptyAndNull());

    public static bool AnyNotEmptyAndNull(this ICollection<string?> strs) => strs.Any(x => x.IsNotEmptyAndNull());

    public static bool AnyNotEmptyAndNull(params string?[] strs) => strs.Any(x => x.IsNotEmptyAndNull());

    public static bool IsNotWhiteSpaceAndNull([NotNullWhen(true)] this string? str) => !string.IsNullOrWhiteSpace(str);

    public static bool AllNotWhiteSpaceAndNull(this IEnumerable<string?> strs) => !strs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AllNotWhiteSpaceAndNull(this ICollection<string?> strs) => !strs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AllNotWhiteSpaceAndNull(params string?[] strs) => !strs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AnyNotWhiteSpaceAndNull(this IEnumerable<string?> strs) => strs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AnyNotWhiteSpaceAndNull(this ICollection<string?> strs) => strs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AnyNotWhiteSpaceAndNull(params string?[] strs) => strs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool NotEqualsIgnoreCase(this string? str1, string? str2) => AllNotNull(str1, str2) && !string.Equals(str1, str2, OrdinalIgnoreCase);

    public static bool AllNotEqualsIgnoreCase(this IEnumerable<string?> strs)
    {
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

    public static bool AllNotEqualsIgnoreCase(this ICollection<string?> strs)
    {
        var hashSet = new HashSet<string?>(strs.Count, StringComparer.OrdinalIgnoreCase);

        foreach (var str in strs)
        {
            if (!hashSet.Add(str))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllNotEqualsIgnoreCase(params string?[] strs)
    {
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

    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<string?> strs) => !strs.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(this ICollection<string?> strs) => !strs.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(params string?[] strs) => !strs.AllEqualsIgnoreCase();

    public static string GenerateRandomString(object? size = null) => string.Concat(GenerateRandomCharacters(size ?? GenerateRandomByte()));

    public static IEnumerable<string> GenerateRandomStrings(object? size) => Range(0, (int)size.ToUint()).Select(i => GenerateRandomString());

    public static string? Lower(this string? str) => str.IsWhiteSpaceOrNull() ? str : str.ToLower();

    public static void Lower(this List<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            return;
        }

        strs.ForEach(x => x = x.Lower());
    }

    public static IEnumerable<string?>? Lowers(this IEnumerable<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Lower());

    public static IEnumerable<string?>? Lowers(this ICollection<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Lower());

    public static IEnumerable<string?>? Lowers(params string?[]? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Lower());

    public static string? LowerInvariant(this string? str) => str.IsWhiteSpaceOrNull() ? str : str.ToLower(CultureInfo.InvariantCulture);

    public static void LowerInvariant(this List<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            return;
        }

        strs.ForEach(x => x = x.LowerInvariant());
    }

    public static IEnumerable<string?>? LowerInvariants(this IEnumerable<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.LowerInvariant());

    public static IEnumerable<string?>? LowerInvariants(this ICollection<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.LowerInvariant());

    public static IEnumerable<string?>? LowerInvariants(params string?[]? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.LowerInvariant());

    public static string? Upper(this string? str) => str.IsWhiteSpaceOrNull() ? str : str.ToUpper();

    public static void Upper(this List<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            return;
        }

        strs.ForEach(x => x = x.Upper());
    }

    public static IEnumerable<string?>? Uppers(this IEnumerable<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Upper());

    public static IEnumerable<string?>? Uppers(this ICollection<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Upper());

    public static IEnumerable<string?>? Uppers(params string?[]? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.Upper());

    public static string? UpperInvariant(this string? str) => str.IsWhiteSpaceOrNull() ? str : str.ToUpper(CultureInfo.InvariantCulture);

    public static void UpperInvariant(this List<string?>? strs)
    {
        if (strs.IsEmptyOrNull())
        {
            return;
        }

        strs.ForEach(x => x = x.UpperInvariant());
    }

    public static IEnumerable<string?>? UpperInvariants(this IEnumerable<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.UpperInvariant());

    public static IEnumerable<string?>? UpperInvariants(this ICollection<string?>? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.UpperInvariant());

    public static IEnumerable<string?>? UpperInvariants(params string?[]? strs) => strs.IsEmptyOrNull() ? strs : strs.Select(x => x.UpperInvariant());
}
