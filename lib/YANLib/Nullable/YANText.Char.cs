using System.Diagnostics.CodeAnalysis;
using YANLib.Object;
using YANLib.Text;

namespace YANLib.Nullable;

public static partial class YANText
{
    public static bool IsEmptyOrNull([NotNullWhen(false)] this char? c) => !c.HasValue || c.Value.IsEmpty();

    public static bool AllEmptyOrNull(this IEnumerable<char?> cs) => !cs.Any(x => x.IsNotEmptyAndNull());

    public static bool AllEmptyOrNull(this ICollection<char?> cs) => !cs.Any(x => x.IsNotEmptyAndNull());

    public static bool AllEmptyOrNull(params char?[] cs) => !cs.Any(x => x.IsNotEmptyAndNull());

    public static bool AnyEmptyOrNull(this IEnumerable<char?> cs) => cs.Any(x => x.IsEmptyOrNull());

    public static bool AnyEmptyOrNull(this ICollection<char?> cs) => cs.Any(x => x.IsEmptyOrNull());

    public static bool AnyEmptyOrNull(params char?[] cs) => cs.Any(x => x.IsEmptyOrNull());

    public static bool IsWhiteSpaceOrNull([NotNullWhen(false)] this char? c) => !c.HasValue || c.Value.IsEmpty() || c.Value.IsWhiteSpace();

    public static bool AllWhiteSpaceOrNull(this IEnumerable<char?> cs) => !cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AllWhiteSpaceOrNull(this ICollection<char?> cs) => !cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AllWhiteSpaceOrNull(params char?[] cs) => !cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AnyWhiteSpaceOrNull(this IEnumerable<char?> cs) => cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AnyWhiteSpaceOrNull(this ICollection<char?> cs) => cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AnyWhiteSpaceOrNull(params char?[] cs) => cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool IsAlphabetic([NotNullWhen(true)] this char? c) => c.HasValue && c.Value.IsAlphabetic();

    public static bool AllAlphabetic(this IEnumerable<char?> cs) => !cs.Any(x => x.IsNotAlphabetic());

    public static bool AllAlphabetic(this ICollection<char?> cs) => !cs.Any(x => x.IsNotAlphabetic());

    public static bool AllAlphabetic(params char?[] cs) => !cs.Any(x => x.IsNotAlphabetic());

    public static bool AnyAlphabetic(this IEnumerable<char?> cs) => cs.Any(x => x.IsAlphabetic());

    public static bool AnyAlphabetic(this ICollection<char?> cs) => cs.Any(x => x.IsAlphabetic());

    public static bool AnyAlphabetic(params char?[] cs) => cs.Any(x => x.IsAlphabetic());

    public static bool IsPunctuation([NotNullWhen(true)] this char? c) => c.HasValue && c.Value.IsPunctuation();

    public static bool AllPunctuation(this IEnumerable<char?> cs) => !cs.Any(x => x.IsNotPunctuation());

    public static bool AllPunctuation(this ICollection<char?> cs) => !cs.Any(x => x.IsNotPunctuation());

    public static bool AllPunctuation(params char?[] cs) => !cs.Any(x => x.IsNotPunctuation());

    public static bool AnyPunctuation(this IEnumerable<char?> cs) => cs.Any(x => x.IsPunctuation());

    public static bool AnyPunctuation(this ICollection<char?> cs) => cs.Any(x => x.IsPunctuation());

    public static bool AnyPunctuation(params char?[] cs) => cs.Any(x => x.IsPunctuation());

    public static bool IsNumber([NotNullWhen(true)] this char? c) => c.HasValue && c.Value.IsNumber();

    public static bool AllNumber(this IEnumerable<char?> cs) => !cs.Any(x => x.IsNotNumber());

    public static bool AllNumber(this ICollection<char?> cs) => !cs.Any(x => x.IsNotNumber());

    public static bool AllNumber(params char?[] cs) => !cs.Any(x => x.IsNotNumber());

    public static bool AnyNumber(this IEnumerable<char?> cs) => cs.Any(x => x.IsNumber());

    public static bool AnyNumber(this ICollection<char?> cs) => cs.Any(x => x.IsNumber());

    public static bool AnyNumber(params char?[] cs) => cs.Any(x => x.IsNumber());

    public static bool EqualsIgnoreCase(this char c1, char? c2) => c1.LowerInvariant() == c2.LowerInvariant();

    public static bool AllEqualsIgnoreCase(this IEnumerable<char?> cs) => !cs.Any(x => x.NotEqualsIgnoreCase(cs.First()));

    public static bool AllEqualsIgnoreCase(this ICollection<char?> cs) => !cs.Any(x => x.NotEqualsIgnoreCase(cs.First()));

    public static bool AllEqualsIgnoreCase(params char?[] cs) => !cs.Any(x => x.NotEqualsIgnoreCase(cs.First()));

    public static bool AnyEqualsIgnoreCase(this IEnumerable<char?> cs) => !cs.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(this ICollection<char?> cs) => !cs.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(params char?[] cs) => !cs.AllNotEqualsIgnoreCase();

    public static bool IsNotEmptyAndNull([NotNullWhen(true)] this char? c) => c.HasValue && c.Value.IsNotEmpty();

    public static bool AllNotEmptyAndNull(this IEnumerable<char?> cs) => !cs.Any(x => x.IsEmptyOrNull());

    public static bool AllNotEmptyAndNull(this ICollection<char?> cs) => !cs.Any(x => x.IsEmptyOrNull());

    public static bool AllNotEmptyAndNull(params char?[] cs) => !cs.Any(x => x.IsEmptyOrNull());

    public static bool AnyNotEmptyAndNull(this IEnumerable<char?> cs) => cs.Any(x => x.IsNotEmptyAndNull());

    public static bool AnyNotEmptyAndNull(this ICollection<char?> cs) => cs.Any(x => x.IsNotEmptyAndNull());

    public static bool AnyNotEmptyAndNull(params char?[] cs) => cs.Any(x => x.IsNotEmptyAndNull());

    public static bool IsNotWhiteSpaceAndNull([NotNullWhen(true)] this char? c) => c.HasValue && c.Value.IsNotEmpty() && c.Value.IsNotWhiteSpace();

    public static bool AllNotWhiteSpaceAndNull(this IEnumerable<char?> cs) => !cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AllNotWhiteSpaceAndNull(this ICollection<char?> cs) => !cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AllNotWhiteSpaceAndNull(params char?[] cs) => !cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AnyNotWhiteSpaceAndNull(this IEnumerable<char?> cs) => cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AnyNotWhiteSpaceAndNull(this ICollection<char?> cs) => cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AnyNotWhiteSpaceAndNull(params char?[] cs) => cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool IsNotAlphabetic(this char? c) => c.HasValue && c.Value.IsNotAlphabetic();

    public static bool AllNotAlphabetic(this IEnumerable<char?> cs) => !cs.Any(x => x.IsAlphabetic());

    public static bool AllNotAlphabetic(this ICollection<char?> cs) => !cs.Any(x => x.IsAlphabetic());

    public static bool AllNotAlphabetic(params char?[] cs) => !cs.Any(x => x.IsAlphabetic());

    public static bool AnyNotAlphabetic(this IEnumerable<char?> cs) => cs.Any(x => x.IsNotAlphabetic());

    public static bool AnyNotAlphabetic(this ICollection<char?> cs) => cs.Any(x => x.IsNotAlphabetic());

    public static bool AnyNotAlphabetic(params char?[] cs) => cs.Any(x => x.IsNotAlphabetic());

    public static bool IsNotPunctuation(this char? c) => c.HasValue && c.Value.IsNotPunctuation();

    public static bool AllNotPunctuation(this IEnumerable<char?> cs) => !cs.Any(x => x.IsPunctuation());

    public static bool AllNotPunctuation(this ICollection<char?> cs) => !cs.Any(x => x.IsPunctuation());

    public static bool AllNotPunctuation(params char?[] cs) => !cs.Any(x => x.IsPunctuation());

    public static bool AnyNotPunctuation(this IEnumerable<char?> cs) => cs.Any(x => x.IsNotPunctuation());

    public static bool AnyNotPunctuation(this ICollection<char?> cs) => cs.Any(x => x.IsNotPunctuation());

    public static bool AnyNotPunctuation(params char?[] cs) => cs.Any(x => x.IsNotPunctuation());

    public static bool IsNotNumber(this char? c) => c.HasValue && c.Value.IsNotNumber();

    public static bool AllNotNumber(this IEnumerable<char?> cs) => !cs.Any(x => x.IsNumber());

    public static bool AllNotNumber(this ICollection<char?> cs) => !cs.Any(x => x.IsNumber());

    public static bool AllNotNumber(params char?[] cs) => !cs.Any(x => x.IsNumber());

    public static bool AnyNotNumber(this IEnumerable<char?> cs) => cs.Any(x => x.IsNotNumber());

    public static bool AnyNotNumber(this ICollection<char?> cs) => cs.Any(x => x.IsNotNumber());

    public static bool AnyNotNumber(params char?[] cs) => cs.Any(x => x.IsNotNumber());

    public static bool NotEqualsIgnoreCase(this char? c1, char? c2) => c1.LowerInvariant() != c2.LowerInvariant();

    public static bool AllNotEqualsIgnoreCase(this IEnumerable<char?> cs)
    {
        var hashSet = new HashSet<char?>(cs.Count());

        foreach (var c in cs)
        {
            if (!hashSet.Add(c.LowerInvariant()))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllNotEqualsIgnoreCase(this ICollection<char?> cs)
    {
        var hashSet = new HashSet<char?>(cs.Count);

        foreach (var c in cs)
        {
            if (!hashSet.Add(c.LowerInvariant()))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllNotEqualsIgnoreCase(params char?[] cs)
    {
        var hashSet = new HashSet<char?>(cs.Length);

        foreach (var c in cs)
        {
            if (!hashSet.Add(c.LowerInvariant()))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<char?> cs) => !cs.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(this ICollection<char?> cs) => !cs.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(params char?[] cs) => !cs.AllEqualsIgnoreCase();

    public static char? Lower(this char? c) => c.IsWhiteSpaceOrNull() ? default : char.ToLower(c.Value);

    public static void Lower(this List<char?>? cs)
    {
        if (cs.IsNullOEmpty())
        {
            return;
        }

        cs.ForEach(x => x = x.Lower());
    }

    public static IEnumerable<char?>? Lowers(this IEnumerable<char?>? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.Lower());

    public static IEnumerable<char?>? Lowers(this ICollection<char?>? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.Lower());

    public static IEnumerable<char?>? Lowers(params char?[]? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.Lower());

    public static char? LowerInvariant(this char? c) => c.IsWhiteSpaceOrNull() ? default : char.ToLowerInvariant(c.Value);

    public static void LowerInvariant(this List<char?>? cs)
    {
        if (cs.IsNullOEmpty())
        {
            return;
        }

        cs.ForEach(x => x = x.LowerInvariant());
    }

    public static IEnumerable<char?>? LowerInvariants(this IEnumerable<char?>? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.LowerInvariant());

    public static IEnumerable<char?>? LowerInvariants(this ICollection<char?>? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.LowerInvariant());

    public static IEnumerable<char?>? LowerInvariants(params char?[]? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.LowerInvariant());

    public static char? Upper(this char? c) => c.IsWhiteSpaceOrNull() ? default : char.ToUpper(c.Value);

    public static void Upper(this List<char?>? cs)
    {
        if (cs.IsNullOEmpty())
        {
            return;
        }

        cs.ForEach(x => x = x.Upper());
    }

    public static IEnumerable<char?>? Uppers(this IEnumerable<char?>? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.Upper());

    public static IEnumerable<char?>? Uppers(this ICollection<char?>? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.Upper());

    public static IEnumerable<char?>? Uppers(params char?[]? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.Upper());

    public static char? UpperInvariant(this char? c) => c.IsWhiteSpaceOrNull() ? default : char.ToUpperInvariant(c.Value);

    public static void UpperInvariant(this List<char?>? cs)
    {
        if (cs.IsNullOEmpty())
        {
            return;
        }

        cs.ForEach(x => x = x.UpperInvariant());
    }

    public static IEnumerable<char?>? UpperInvariants(this IEnumerable<char?>? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.UpperInvariant());

    public static IEnumerable<char?>? UpperInvariants(this ICollection<char?>? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.UpperInvariant());

    public static IEnumerable<char?>? UpperInvariants(params char?[]? cs) => cs.IsNullOEmpty() ? default : cs.Select(x => x.UpperInvariant());

    public static bool IsLower(this char? c) => c.HasValue && char.IsLower(c.Value);

    public static bool AllLowers(this IEnumerable<char?> cs) => !cs.Any(x => x.IsNotLower());

    public static bool AllLowers(this ICollection<char?> cs) => !cs.Any(x => x.IsNotLower());

    public static bool AllLowers(params char?[] cs) => !cs.Any(x => x.IsNotLower());

    public static bool AnyLowers(this IEnumerable<char?> cs) => cs.Any(x => x.IsLower());

    public static bool AnyLowers(this ICollection<char?> cs) => cs.Any(x => x.IsLower());

    public static bool AnyLowers(params char?[] cs) => cs.Any(x => x.IsLower());

    public static bool IsNotLower(this char? c) => c.HasValue && !char.IsLower(c.Value);

    public static bool AllNotLowers(this IEnumerable<char?> cs) => !cs.Any(x => x.IsLower());

    public static bool AllNotLowers(this ICollection<char?> cs) => !cs.Any(x => x.IsLower());

    public static bool AllNotLowers(params char?[] cs) => !cs.Any(x => x.IsLower());

    public static bool AnyNotLowers(this IEnumerable<char?> cs) => cs.Any(x => x.IsNotLower());

    public static bool AnyNotLowers(this ICollection<char?> cs) => cs.Any(x => x.IsNotLower());

    public static bool AnyNotLowers(params char?[] cs) => cs.Any(x => x.IsNotLower());

    public static bool IsUpper(this char? c) => c.HasValue && char.IsUpper(c.Value);

    public static bool AllUppers(this IEnumerable<char?> cs) => !cs.Any(x => x.IsNotUpper());

    public static bool AllUppers(this ICollection<char?> cs) => !cs.Any(x => x.IsNotUpper());

    public static bool AllUppers(params char?[] cs) => !cs.Any(x => x.IsNotUpper());

    public static bool AnyUppers(this IEnumerable<char?> cs) => cs.Any(x => x.IsUpper());

    public static bool AnyUppers(this ICollection<char?> cs) => cs.Any(x => x.IsUpper());

    public static bool AnyUppers(params char?[] cs) => cs.Any(x => x.IsUpper());

    public static bool IsNotUpper(this char? c) => c.HasValue && !char.IsUpper(c.Value);

    public static bool AllNotUppers(this IEnumerable<char?> cs) => !cs.Any(x => x.IsUpper());

    public static bool AllNotUppers(this ICollection<char?> cs) => !cs.Any(x => x.IsUpper());

    public static bool AllNotUppers(params char?[] cs) => !cs.Any(x => x.IsUpper());

    public static bool AnyNotUppers(this IEnumerable<char?> cs) => cs.Any(x => x.IsNotUpper());

    public static bool AnyNotUppers(this ICollection<char?> cs) => cs.Any(x => x.IsNotUpper());

    public static bool AnyNotUppers(params char?[] cs) => cs.Any(x => x.IsNotUpper());
}
