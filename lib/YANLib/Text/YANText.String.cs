using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using YANLib.Object;
using static System.Linq.Enumerable;
using static System.StringComparison;

namespace YANLib.Text;

public static partial class YANText
{
    public static bool AllNull(this IEnumerable<string?> input) => !input.Any(x => x.IsNotNull());

    public static bool AllNull(this ICollection<string?> input) => !input.Any(x => x.IsNotNull());

    public static bool AllNull(params string?[] input) => !input.Any(x => x.IsNotNull());

    public static bool AnyNull(this IEnumerable<string?> input) => input.Any(x => x.IsNull());

    public static bool AnyNull(this ICollection<string?> input) => input.Any(x => x.IsNull());

    public static bool AnyNull(params string?[] input) => input.Any(x => x.IsNull());

    public static bool IsNullEmpty([NotNullWhen(false)] this string? input) => string.IsNullOrEmpty(input);

    public static bool AllNullEmpty(this IEnumerable<string?> input) => !input.Any(x => x.IsNotNullEmpty());

    public static bool AllNullEmpty(this ICollection<string?> input) => !input.Any(x => x.IsNotNullEmpty());

    public static bool AllNullEmpty(params string?[] input) => !input.Any(x => x.IsNotNullEmpty());

    public static bool AnyNullEmpty(this IEnumerable<string?> input) => input.Any(x => x.IsNullEmpty());

    public static bool AnyNullEmpty(this ICollection<string?> input) => input.Any(x => x.IsNullEmpty());

    public static bool AnyNullEmpty(params string?[] input) => input.Any(x => x.IsNullEmpty());

    public static bool IsNullWhiteSpace([NotNullWhen(false)] this string? input) => string.IsNullOrWhiteSpace(input);

    public static bool AllNullWhiteSpace(this IEnumerable<string?> input) => !input.Any(x => x.IsNotNullWhiteSpace());

    public static bool AllNullWhiteSpace(this ICollection<string?> input) => !input.Any(x => x.IsNotNullWhiteSpace());

    public static bool AllNullWhiteSpace(params string?[] input) => !input.Any(x => x.IsNotNullWhiteSpace());

    public static bool AnyNullWhiteSpace(this IEnumerable<string?> input) => input.Any(x => x.IsNullWhiteSpace());

    public static bool AnyNullWhiteSpace(this ICollection<string?> input) => input.Any(x => x.IsNullWhiteSpace());

    public static bool AnyNullWhiteSpace(params string?[] input) => input.Any(x => x.IsNullWhiteSpace());

    public static bool EqualsIgnoreCase(this string input1, string? input2) => AllNull(input1, input2) || input1.IsNotNull() && input1.IsNotNull() && string.Equals(input1, input2, OrdinalIgnoreCase);

    public static bool AllEqualsIgnoreCase(this IEnumerable<string?> input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    public static bool AllEqualsIgnoreCase(this ICollection<string?> input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    public static bool AllEqualsIgnoreCase(params string?[] input) => !input.Any(x => x.NotEqualsIgnoreCase(input[0]));

    public static bool AnyEqualsIgnoreCase(this IEnumerable<string?> input) => !input.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(this ICollection<string?> input) => !input.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(params string?[] input) => !input.AllNotEqualsIgnoreCase();

    public static bool AllNotNull(this IEnumerable<string?> input) => !input.Any(x => x.IsNull());

    public static bool AllNotNull(this ICollection<string?> input) => !input.Any(x => x.IsNull());

    public static bool AllNotNull(params string?[] input) => !input.Any(x => x.IsNull());

    public static bool AnyNotNull(this IEnumerable<string?> input) => input.Any(x => x.IsNotNull());

    public static bool AnyNotNull(this ICollection<string?> input) => input.Any(x => x.IsNotNull());

    public static bool AnyNotNull(params string?[] input) => input.Any(x => x.IsNotNull());

    public static bool IsNotNullEmpty([NotNullWhen(true)] this string? input) => !string.IsNullOrEmpty(input);

    public static bool AllNotNullEmpty(this IEnumerable<string?> input) => !input.Any(x => x.IsNullEmpty());

    public static bool AllNotNullEmpty(this ICollection<string?> input) => !input.Any(x => x.IsNullEmpty());

    public static bool AllNotNullEmpty(params string?[] input) => !input.Any(x => x.IsNullEmpty());

    public static bool AnyNotNullEmpty(this IEnumerable<string?> input) => input.Any(x => x.IsNotNullEmpty());

    public static bool AnyNotNullEmpty(this ICollection<string?> input) => input.Any(x => x.IsNotNullEmpty());

    public static bool AnyNotNullEmpty(params string?[] input) => input.Any(x => x.IsNotNullEmpty());

    public static bool IsNotNullWhiteSpace([NotNullWhen(true)] this string? input) => !string.IsNullOrWhiteSpace(input);

    public static bool AllNotNullWhiteSpace(this IEnumerable<string?> input) => !input.Any(x => x.IsNullWhiteSpace());

    public static bool AllNotNullWhiteSpace(this ICollection<string?> input) => !input.Any(x => x.IsNullWhiteSpace());

    public static bool AllNotNullWhiteSpace(params string?[] input) => !input.Any(x => x.IsNullWhiteSpace());

    public static bool AnyNotNullWhiteSpace(this IEnumerable<string?> input) => input.Any(x => x.IsNotNullWhiteSpace());

    public static bool AnyNotNullWhiteSpace(this ICollection<string?> input) => input.Any(x => x.IsNotNullWhiteSpace());

    public static bool AnyNotNullWhiteSpace(params string?[] input) => input.Any(x => x.IsNotNullWhiteSpace());

    public static bool NotEqualsIgnoreCase(this string? input1, string? input2) => AllNotNull(input1, input2) && !string.Equals(input1, input2, OrdinalIgnoreCase);

    public static bool AllNotEqualsIgnoreCase(this IEnumerable<string?> input)
    {
        var set = new HashSet<string?>(input.Count(), StringComparer.OrdinalIgnoreCase);

        foreach (var str in input)
        {
            if (!set.Add(str))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllNotEqualsIgnoreCase(this ICollection<string?> input)
    {
        var set = new HashSet<string?>(input.Count, StringComparer.OrdinalIgnoreCase);

        foreach (var str in input)
        {
            if (!set.Add(str))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllNotEqualsIgnoreCase(params string?[] input)
    {
        var set = new HashSet<string?>(input.Length, StringComparer.OrdinalIgnoreCase);

        for (var i = 0; i < input.Length; i++)
        {
            if (!set.Add(input[i]))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<string?> input) => !input.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(this ICollection<string?> input) => !input.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(params string?[] input) => !input.AllEqualsIgnoreCase();

    public static string? Lower(this string? input) => input.IsNullWhiteSpace() ? input : input.ToLower();

    public static void Lower(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.Lower());
    }

    public static IEnumerable<string?>? Lowers(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Lower());

    public static IEnumerable<string?>? Lowers(this ICollection<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Lower());

    public static IEnumerable<string?>? Lowers(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.Lower());

    public static string? LowerInvariant(this string? input) => input.IsNullWhiteSpace() ? input : input.ToLower(CultureInfo.InvariantCulture);

    public static void LowerInvariant(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.LowerInvariant());
    }

    public static IEnumerable<string?>? LowerInvariants(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.LowerInvariant());

    public static IEnumerable<string?>? LowerInvariants(this ICollection<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.LowerInvariant());

    public static IEnumerable<string?>? LowerInvariants(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.LowerInvariant());

    public static string? Upper(this string? input) => input.IsNullWhiteSpace() ? input : input.ToUpper();

    public static void Upper(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.Upper());
    }

    public static IEnumerable<string?>? Uppers(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Upper());

    public static IEnumerable<string?>? Uppers(this ICollection<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Upper());

    public static IEnumerable<string?>? Uppers(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.Upper());

    public static string? UpperInvariant(this string? input) => input.IsNullWhiteSpace() ? input : input.ToUpper(CultureInfo.InvariantCulture);

    public static void UpperInvariant(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.UpperInvariant());
    }

    public static IEnumerable<string?>? UpperInvariants(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.UpperInvariant());

    public static IEnumerable<string?>? UpperInvariants(this ICollection<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.UpperInvariant());

    public static IEnumerable<string?>? UpperInvariants(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.UpperInvariant());
}
