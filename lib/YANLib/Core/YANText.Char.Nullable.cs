using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YANLib.Core;

public static partial class YANText
{
    public static bool IsEmptyOrNull([NotNullWhen(false)] this char? c) => c.IsNull() || c.Value.IsEmpty();

    public static bool AllEmptyOrNull(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotEmptyAndNull());

    public static bool AllEmptyOrNull(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotEmptyAndNull());

    public static bool AllEmptyOrNull(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotEmptyAndNull());

    public static bool AnyEmptyOrNull(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsEmptyOrNull());

    public static bool AnyEmptyOrNull(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsEmptyOrNull());

    public static bool AnyEmptyOrNull(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsEmptyOrNull());

    public static bool IsWhiteSpaceOrNull([NotNullWhen(false)] this char? c) => c.IsNull() || c.Value.IsEmpty() || c.Value.IsWhiteSpace();

    public static bool AllWhiteSpaceOrNull(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AllWhiteSpaceOrNull(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AllWhiteSpaceOrNull(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AnyWhiteSpaceOrNull(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AnyWhiteSpaceOrNull(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AnyWhiteSpaceOrNull(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool IsAlphabetic([NotNullWhen(true)] this char? c) => c.HasValue && c.Value.IsAlphabetic();

    public static bool AllAlphabetic(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotAlphabetic());

    public static bool AllAlphabetic(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotAlphabetic());

    public static bool AllAlphabetic(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotAlphabetic());

    public static bool AnyAlphabetic(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsAlphabetic());

    public static bool AnyAlphabetic(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsAlphabetic());

    public static bool AnyAlphabetic(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsAlphabetic());

    public static bool IsPunctuation([NotNullWhen(true)] this char? c) => c.HasValue && c.Value.IsPunctuation();

    public static bool AllPunctuation(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotPunctuation());

    public static bool AllPunctuation(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotPunctuation());

    public static bool AllPunctuation(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotPunctuation());

    public static bool AnyPunctuation(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsPunctuation());

    public static bool AnyPunctuation(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsPunctuation());

    public static bool AnyPunctuation(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsPunctuation());

    public static bool IsNumber([NotNullWhen(true)] this char? c) => c.HasValue && c.Value.IsNumber();

    public static bool AllNumber(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotNumber());

    public static bool AllNumber(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotNumber());

    public static bool AllNumber(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotNumber());

    public static bool AnyNumber(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNumber());

    public static bool AnyNumber(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNumber());

    public static bool AnyNumber(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNumber());

    public static bool EqualsIgnoreCase(this char? c1, char? c2) => c1.LowerInvariant() == c2.LowerInvariant();

    public static bool AllEqualsIgnoreCase(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.NotEqualsIgnoreCase(cs.First()));

    public static bool AllEqualsIgnoreCase(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.NotEqualsIgnoreCase(cs.First()));

    public static bool AllEqualsIgnoreCase(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.NotEqualsIgnoreCase(cs.First()));

    public static bool AnyEqualsIgnoreCase(this IEnumerable<char?>? cs) => !cs.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(this ICollection<char?>? cs) => !cs.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(this char?[]? cs) => !cs.AllNotEqualsIgnoreCase();

    public static bool IsNotEmptyAndNull([NotNullWhen(true)] this char? c) => c.HasValue && c.Value.IsNotEmpty();

    public static bool AllNotEmptyAndNull(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsEmptyOrNull());
    
    public static bool AllNotEmptyAndNull(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsEmptyOrNull());
    
    public static bool AllNotEmptyAndNull(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsEmptyOrNull());

    public static bool AnyNotEmptyAndNull(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotEmptyAndNull());
    
    public static bool AnyNotEmptyAndNull(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotEmptyAndNull());
    
    public static bool AnyNotEmptyAndNull(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotEmptyAndNull());

    public static bool IsNotWhiteSpaceAndNull([NotNullWhen(true)] this char? c) => c.HasValue && c.Value.IsNotEmpty() && c.Value.IsNotWhiteSpace();

    public static bool AllNotWhiteSpaceAndNull(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AllNotWhiteSpaceAndNull(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AllNotWhiteSpaceAndNull(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsWhiteSpaceOrNull());

    public static bool AnyNotWhiteSpaceAndNull(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AnyNotWhiteSpaceAndNull(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool AnyNotWhiteSpaceAndNull(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotWhiteSpaceAndNull());

    public static bool IsNotAlphabetic(this char? c) => c.HasValue && c.Value.IsNotAlphabetic();

    public static bool AllNotAlphabetic(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsAlphabetic());

    public static bool AllNotAlphabetic(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsAlphabetic());

    public static bool AllNotAlphabetic(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsAlphabetic());

    public static bool AnyNotAlphabetic(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotAlphabetic());

    public static bool AnyNotAlphabetic(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotAlphabetic());

    public static bool AnyNotAlphabetic(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotAlphabetic());

    public static bool IsNotPunctuation(this char? c) => c.HasValue && c.Value.IsNotPunctuation();

    public static bool AllNotPunctuation(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsPunctuation());

    public static bool AllNotPunctuation(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsPunctuation());

    public static bool AllNotPunctuation(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsPunctuation());

    public static bool AnyNotPunctuation(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotPunctuation());

    public static bool AnyNotPunctuation(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotPunctuation());

    public static bool AnyNotPunctuation(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotPunctuation());

    public static bool IsNotNumber(this char? c) => c.HasValue && c.Value.IsNotNumber();

    public static bool AllNotNumber(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNumber());

    public static bool AllNotNumber(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNumber());

    public static bool AllNotNumber(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNumber());

    public static bool AnyNotNumber(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotNumber());

    public static bool AnyNotNumber(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotNumber());

    public static bool AnyNotNumber(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotNumber());

    public static bool NotEqualsIgnoreCase(this char? c1, char? c2) => c1.LowerInvariant() != c2.LowerInvariant();

    public static bool AllNotEqualsIgnoreCase(this IEnumerable<char?>? cs)
    {
        if (cs.IsEmptyOrNull() || cs.Count() < 2)
        {
            return default;
        }

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

    public static bool AllNotEqualsIgnoreCase(this ICollection<char?>? cs)
    {
        if (cs.IsEmptyOrNull() || cs.Count < 2)
        {
            return default;
        }

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

    public static bool AllNotEqualsIgnoreCase(this char?[]? cs)
    {
        if (cs.IsEmptyOrNull() || cs.Length < 2)
        {
            return default;
        }

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

    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<char?>? cs) => !cs.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(this ICollection<char?>? cs) => !cs.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(this char?[]? cs) => !cs.AllEqualsIgnoreCase();

    public static char? GetValue(this char? c, char dfltVal = default) => c.IsEmptyOrNull() ? dfltVal : c.Value;

    public static char? Lower(this char? c) => c.IsWhiteSpaceOrNull() ? default : char.ToLower(c.Value);

    public static IEnumerable<char?>? Lowers(this IEnumerable<char?>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Lower());

    public static IEnumerable<char?>? Lowers(this ICollection<char?>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Lower());

    public static IEnumerable<char?>? Lowers(this char?[]? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Lower());

    public static char? LowerInvariant(this char? c) => c.IsWhiteSpaceOrNull() ? default : char.ToLowerInvariant(c.Value);

    public static IEnumerable<char?>? LowerInvariants(this IEnumerable<char?>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.LowerInvariant());

    public static IEnumerable<char?>? LowerInvariants(this ICollection<char?>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.LowerInvariant());

    public static IEnumerable<char?>? LowerInvariants(this char?[]? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.LowerInvariant());

    public static char? Upper(this char? c) => c.IsWhiteSpaceOrNull() ? default : char.ToUpper(c.Value);

    public static IEnumerable<char?>? Upper(this IEnumerable<char?>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Upper());

    public static IEnumerable<char?>? Upper(this ICollection<char?>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Upper());

    public static IEnumerable<char?>? Upper(this char?[]? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Upper());

    public static char? UpperInvariant(this char? c) => c.IsWhiteSpaceOrNull() ? default : char.ToUpperInvariant(c.Value);

    public static IEnumerable<char?>? UpperInvariants(this IEnumerable<char?>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.UpperInvariant());

    public static IEnumerable<char?>? UpperInvariants(this ICollection<char?>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.UpperInvariant());

    public static IEnumerable<char?>? UpperInvariants(this char?[]? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.UpperInvariant());

    public static bool IsLower(this char? c) => c.IsNotWhiteSpaceAndEmpty() && char.IsLower(c);

    public static bool AllLowers(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotLower());

    public static bool AllLowers(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotLower());

    public static bool AllLowers(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotLower());

    public static bool AnyLowers(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsLower());

    public static bool AnyLowers(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsLower());

    public static bool AnyLowers(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsLower());

    public static bool IsNotLower(this char? c) => c.IsNotWhiteSpaceAndEmpty() && !char.IsLower(c);

    public static bool AllNotLowers(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsLower());

    public static bool AllNotLowers(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsLower());

    public static bool AllNotLowers(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsLower());

    public static bool AnyNotLowers(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotLower());

    public static bool AnyNotLowers(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotLower());

    public static bool AnyNotLowers(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotLower());

    public static bool IsUpper(this char? c) => c.IsNotWhiteSpaceAndEmpty() && char.IsUpper(c);

    public static bool AllUppers(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotUpper());

    public static bool AllUppers(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotUpper());

    public static bool AllUppers(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotUpper());

    public static bool AnyUppers(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsUpper());

    public static bool AnyUppers(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsUpper());

    public static bool AnyUppers(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsUpper());

    public static bool IsNotUpper(this char? c) => c.IsNotWhiteSpaceAndEmpty() && !char.IsUpper(c);

    public static bool AllNotUppers(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsUpper());

    public static bool AllNotUppers(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsUpper());

    public static bool AllNotUppers(this char?[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsUpper());

    public static bool AnyNotUppers(this IEnumerable<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotUpper());

    public static bool AnyNotUppers(this ICollection<char?>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotUpper());

    public static bool AnyNotUppers(this char?[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotUpper());
}
