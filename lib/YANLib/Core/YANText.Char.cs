using static System.Linq.Enumerable;
using static YANLib.Core.YANNum;

namespace YANLib.Core;

public static partial class YANText
{
    public static bool IsEmpty(this char c) => c is char.MinValue;

    public static bool AllEmpty(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotEmpty());

    public static bool AllEmpty(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotEmpty());

    public static bool AllEmpty(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotEmpty());

    public static bool AnyEmpty(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsEmpty());

    public static bool AnyEmpty(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsEmpty());

    public static bool AnyEmpty(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsEmpty());

    public static bool IsWhiteSpace(this char c) => char.IsWhiteSpace(c);

    public static bool AllWhiteSpace(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotWhiteSpace());

    public static bool AllWhiteSpace(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotWhiteSpace());

    public static bool AllWhiteSpace(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotWhiteSpace());

    public static bool AnyWhiteSpace(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsWhiteSpace());

    public static bool AnyWhiteSpace(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsWhiteSpace());

    public static bool AnyWhiteSpace(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsWhiteSpace());

    public static bool IsWhiteSpaceOrEmpty(this char c) => c.IsEmpty() || c.IsWhiteSpace();

    public static bool AllWhiteSpaceOrEmpty(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool AllWhiteSpaceOrEmpty(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool AllWhiteSpaceOrEmpty(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool AnyWhiteSpaceOrEmpty(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool AnyWhiteSpaceOrEmpty(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool AnyWhiteSpaceOrEmpty(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool IsAlphabetic(this char c) => char.IsLetter(c);

    public static bool AllAlphabetic(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotAlphabetic());

    public static bool AllAlphabetic(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotAlphabetic());

    public static bool AllAlphabetic(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotAlphabetic());

    public static bool AnyAlphabetic(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsAlphabetic());

    public static bool AnyAlphabetic(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsAlphabetic());

    public static bool AnyAlphabetic(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsAlphabetic());

    public static bool IsPunctuation(this char c) => char.IsPunctuation(c);

    public static bool AllPunctuation(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotPunctuation());

    public static bool AllPunctuation(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotPunctuation());

    public static bool AllPunctuation(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotPunctuation());

    public static bool AnyPunctuation(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsPunctuation());

    public static bool AnyPunctuation(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsPunctuation());

    public static bool AnyPunctuation(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsPunctuation());

    public static bool IsNumber(this char c) => char.IsDigit(c);

    public static bool AllNumber(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotNumber());

    public static bool AllNumber(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotNumber());

    public static bool AllNumber(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotNumber());

    public static bool AnyNumber(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNumber());

    public static bool AnyNumber(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNumber());

    public static bool AnyNumber(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNumber());

    public static bool EqualsIgnoreCase(this char c1, char c2) => c1.LowerInvariant() == c2.LowerInvariant();

    public static bool AllEqualsIgnoreCase(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.NotEqualsIgnoreCase(cs.First()));

    public static bool AllEqualsIgnoreCase(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.NotEqualsIgnoreCase(cs.First()));

    public static bool AllEqualsIgnoreCase(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.NotEqualsIgnoreCase(cs.First()));

    public static bool AnyEqualsIgnoreCase(this IEnumerable<char>? cs) => !cs.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(this ICollection<char>? cs) => !cs.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(this char[]? cs) => !cs.AllNotEqualsIgnoreCase();

    public static bool IsNotEmpty(this char c) => c is not char.MinValue;

    public static bool AllNotEmpty(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsEmpty());

    public static bool AllNotEmpty(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsEmpty());

    public static bool AllNotEmpty(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsEmpty());

    public static bool AnyNotEmpty(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotEmpty());

    public static bool AnyNotEmpty(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotEmpty());

    public static bool AnyNotEmpty(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotEmpty());

    public static bool IsNotWhiteSpace(this char c) => !char.IsWhiteSpace(c);

    public static bool AllNotWhiteSpace(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsWhiteSpace());

    public static bool AllNotWhiteSpace(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsWhiteSpace());

    public static bool AllNotWhiteSpace(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsWhiteSpace());

    public static bool AnyNotWhiteSpace(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotWhiteSpace());

    public static bool AnyNotWhiteSpace(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotWhiteSpace());

    public static bool AnyNotWhiteSpace(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotWhiteSpace());

    public static bool IsNotWhiteSpaceAndEmpty(this char c) => c.IsNotEmpty() && c.IsNotWhiteSpace();

    public static bool AllNotWhiteSpaceAndEmpty(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool AllNotWhiteSpaceAndEmpty(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool AllNotWhiteSpaceAndEmpty(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool AnyNotWhiteSpaceAndEmpty(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool AnyNotWhiteSpaceAndEmpty(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool AnyNotWhiteSpaceAndEmpty(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool IsNotAlphabetic(this char c) => !char.IsLetter(c);

    public static bool AllNotAlphabetic(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsAlphabetic());

    public static bool AllNotAlphabetic(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsAlphabetic());

    public static bool AllNotAlphabetic(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsAlphabetic());

    public static bool AnyNotAlphabetic(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotAlphabetic());

    public static bool AnyNotAlphabetic(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotAlphabetic());

    public static bool AnyNotAlphabetic(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotAlphabetic());

    public static bool IsNotPunctuation(this char c) => !char.IsPunctuation(c);

    public static bool AllNotPunctuation(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsPunctuation());

    public static bool AllNotPunctuation(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsPunctuation());

    public static bool AllNotPunctuation(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsPunctuation());

    public static bool AnyNotPunctuation(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotPunctuation());

    public static bool AnyNotPunctuation(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotPunctuation());

    public static bool AnyNotPunctuation(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotPunctuation());

    public static bool IsNotNumber(this char c) => !char.IsDigit(c);

    public static bool AllNotNumber(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNumber());

    public static bool AllNotNumber(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNumber());

    public static bool AllNotNumber(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNumber());

    public static bool AnyNotNumber(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotNumber());

    public static bool AnyNotNumber(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotNumber());

    public static bool AnyNotNumber(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotNumber());

    public static bool NotEqualsIgnoreCase(this char c1, char c2) => c1.LowerInvariant() != c2.LowerInvariant();

    public static bool AllNotEqualsIgnoreCase(this IEnumerable<char>? cs)
    {
        if (cs.IsEmptyOrNull() || cs.Count() < 2)
        {
            return default;
        }

        var hashSet = new HashSet<char>(cs.Count());

        foreach (var c in cs)
        {
            if (!hashSet.Add(c.LowerInvariant()))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllNotEqualsIgnoreCase(this ICollection<char>? cs)
    {
        if (cs.IsEmptyOrNull() || cs.Count < 2)
        {
            return default;
        }

        var hashSet = new HashSet<char>(cs.Count);

        foreach (var c in cs)
        {
            if (!hashSet.Add(c.LowerInvariant()))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AllNotEqualsIgnoreCase(this char[]? cs)
    {
        if (cs.IsEmptyOrNull() || cs.Length < 2)
        {
            return default;
        }

        var hashSet = new HashSet<char>(cs.Length);

        foreach (var c in cs)
        {
            if (!hashSet.Add(c.LowerInvariant()))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<char>? cs) => !cs.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(this ICollection<char>? cs) => !cs.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(this char[]? cs) => !cs.AllEqualsIgnoreCase();

    public static char GetValue(this char c, char dfltVal = default) => c.IsEmpty() ? dfltVal : c;

    public static char GenerateRandomCharacter()
    {
        var chars = "abcdefghijklmnopqrstuvwxyz";

        return chars[GenerateRandomByte(chars.Length)];
    }

    public static IEnumerable<char> GenerateRandomCharacters(object? size) => Range(0, (int)size.ToUint()).Select(i => GenerateRandomCharacter());

    public static char Lower(this char c) => c.IsWhiteSpaceOrEmpty() ? c : char.ToLower(c);

    public static IEnumerable<char>? Lowers(this IEnumerable<char>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Lower());

    public static IEnumerable<char>? Lowers(this ICollection<char>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Lower());

    public static IEnumerable<char>? Lowers(this char[]? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Lower());

    public static char LowerInvariant(this char c) => c.IsWhiteSpaceOrEmpty() ? c : char.ToLowerInvariant(c);

    public static IEnumerable<char>? LowerInvariants(this IEnumerable<char>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.LowerInvariant());

    public static IEnumerable<char>? LowerInvariants(this ICollection<char>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.LowerInvariant());

    public static IEnumerable<char>? LowerInvariants(this char[]? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.LowerInvariant());

    public static char Upper(this char c) => c.IsWhiteSpaceOrEmpty() ? c : char.ToUpper(c);

    public static IEnumerable<char>? Upper(this IEnumerable<char>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Upper());

    public static IEnumerable<char>? Upper(this ICollection<char>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Upper());

    public static IEnumerable<char>? Upper(this char[]? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.Upper());

    public static char UpperInvariant(this char c) => c.IsWhiteSpaceOrEmpty() ? c : char.ToUpperInvariant(c);

    public static IEnumerable<char>? UpperInvariants(this IEnumerable<char>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.UpperInvariant());

    public static IEnumerable<char>? UpperInvariants(this ICollection<char>? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.UpperInvariant());

    public static IEnumerable<char>? UpperInvariants(this char[]? cs) => cs.IsEmptyOrNull() ? default : cs.Select(x => x.UpperInvariant());

    public static bool IsLower(this char c) => c.IsNotWhiteSpaceAndEmpty() && char.IsLower(c);

    public static bool AllLowers(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotLower());
    
    public static bool AllLowers(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotLower());
    
    public static bool AllLowers(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotLower());
    
    public static bool AnyLowers(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsLower());
    
    public static bool AnyLowers(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsLower());
    
    public static bool AnyLowers(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsLower());

    public static bool IsNotLower(this char c) => c.IsNotWhiteSpaceAndEmpty() && !char.IsLower(c);

    public static bool AllNotLowers(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsLower());

    public static bool AllNotLowers(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsLower());

    public static bool AllNotLowers(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsLower());

    public static bool AnyNotLowers(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotLower());

    public static bool AnyNotLowers(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotLower());

    public static bool AnyNotLowers(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotLower());

    public static bool IsUpper(this char c) => c.IsNotWhiteSpaceAndEmpty() && char.IsUpper(c);

    public static bool AllUppers(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotUpper());

    public static bool AllUppers(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotUpper());

    public static bool AllUppers(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsNotUpper());

    public static bool AnyUppers(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsUpper());

    public static bool AnyUppers(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsUpper());

    public static bool AnyUppers(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsUpper());

    public static bool IsNotUpper(this char c) => c.IsNotWhiteSpaceAndEmpty() && !char.IsUpper(c);

    public static bool AllNotUppers(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsUpper());

    public static bool AllNotUppers(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsUpper());

    public static bool AllNotUppers(this char[]? cs) => cs.IsNotEmptyAndNull() && !cs.Any(x => x.IsUpper());

    public static bool AnyNotUppers(this IEnumerable<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotUpper());

    public static bool AnyNotUppers(this ICollection<char>? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotUpper());

    public static bool AnyNotUppers(this char[]? cs) => cs.IsNotEmptyAndNull() && cs.Any(x => x.IsNotUpper());
}
