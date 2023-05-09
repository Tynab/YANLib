using static YANLib.YANNum;

namespace YANLib;

public static partial class YANText
{
    
    public static bool IsEmpty(this char c) => c is char.MinValue;

    public static bool AllEmpty(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    public static bool AnyEmpty(params char[] cs) => cs is not null && cs.Any(c => c.IsEmpty());

    public static bool AllEmpty(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    public static bool AnyEmpty(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsEmpty());

    public static bool IsWhiteSpace(this char c) => char.IsWhiteSpace(c);

    public static bool AllWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    public static bool AnyWhiteSpace(params char[] cs) => cs is not null && cs.Any(c => c.IsWhiteSpace());

    public static bool AllWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    public static bool AnyWhiteSpace(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsWhiteSpace());

    public static bool IsWhiteSpaceOrNull(this char c) => c.IsEmpty() || c.IsWhiteSpace();

    public static bool AllWhiteSpaceOrNull(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotEmptyAndWhiteSpace());

    public static bool AnyWhiteSpaceOrNull(params char[] cs) => cs is not null && cs.Any(c => c.IsWhiteSpaceOrNull());

    public static bool AllWhiteSpaceOrNull(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmptyAndWhiteSpace());

    public static bool AnyWhiteSpaceOrNull(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsWhiteSpaceOrNull());

    public static bool IsAlphabetic(this char c) => char.IsLetter(c);

    public static bool AllAlphabetic(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    public static bool AnyAlphabetic(params char[] cs) => cs is not null && cs.Any(c => c.IsAlphabetic());

    public static bool AllAlphabetic(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    public static bool AnyAlphabetic(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsAlphabetic());

    public static bool IsPunctuation(this char c) => char.IsPunctuation(c);

    public static bool AllPunctuation(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    public static bool AnyPunctuation(params char[] cs) => cs is not null && cs.Any(c => c.IsPunctuation());

    public static bool AllPunctuation(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    public static bool AnyPunctuation(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsPunctuation());

    public static bool IsNumber(this char c) => char.IsDigit(c);

    public static bool AllNumber(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    public static bool AnyNumber(params char[] cs) => cs is not null && cs.Any(c => c.IsNumber());

    public static bool AllNumber(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    public static bool AnyNumber(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsNumber());

    public static bool EqualsIgnoreCase(this char c1, char c2) => c1.ToLowerInvariant() == c2.ToLowerInvariant();

    public static bool AllEqualsIgnoreCase(params char[] cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs[0]));

    public static bool AnyEqualsIgnoreCase(params char[] cs) => !cs.AllNotEqualsIgnoreCase();

    public static bool AllEqualsIgnoreCase(this IEnumerable<char> cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs.First()));

    public static bool AnyEqualsIgnoreCase(this IEnumerable<char> cs) => !cs.AllNotEqualsIgnoreCase();

    public static bool IsNotEmpty(this char c) => c is not char.MinValue;

    public static bool AllNotEmpty(params char[] cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    public static bool AnyNotEmpty(params char[] cs) => cs is not null && cs.Any(c => c.IsNotEmpty());

    public static bool AllNotEmpty(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    public static bool AnyNotEmpty(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsNotEmpty());

    public static bool IsNotWhiteSpace(this char c) => !char.IsWhiteSpace(c);

    public static bool AllNotWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    public static bool AnyNotWhiteSpace(params char[] cs) => cs is not null && cs.Any(c => c.IsNotWhiteSpace());

    public static bool AllNotWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    public static bool AnyNotWhiteSpace(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsNotWhiteSpace());

    public static bool IsNotEmptyAndWhiteSpace(this char c) => c.IsNotEmpty() && c.IsNotWhiteSpace();

    public static bool AllNotEmptyAndWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsWhiteSpaceOrNull());

    public static bool AnyNotEmptyAndWhiteSpace(params char[] cs) => cs is not null && cs.Any(c => c.IsNotEmptyAndWhiteSpace());

    public static bool AllNotEmptyAndWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsWhiteSpaceOrNull());

    public static bool AnyNotEmptyAndWhiteSpace(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsNotEmptyAndWhiteSpace());

    public static bool IsNotAlphabetic(this char c) => !char.IsLetter(c);

    public static bool AllNotAlphabetic(params char[] cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    public static bool AnyNotAlphabetic(params char[] cs) => cs is not null && cs.Any(c => c.IsNotAlphabetic());

    public static bool AllNotAlphabetic(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    public static bool AnyNotAlphabetic(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsNotAlphabetic());

    public static bool IsNotPunctuation(this char c) => !char.IsPunctuation(c);

    public static bool AllNotPunctuation(params char[] cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    public static bool AnyNotPunctuation(params char[] cs) => cs is not null && cs.Any(c => c.IsNotPunctuation());

    public static bool AllNotPunctuation(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    public static bool AnyNotPunctuation(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsNotPunctuation());

    public static bool IsNotNumber(this char c) => !char.IsDigit(c);

    public static bool AllNotNumber(params char[] cs) => cs is not null && !cs.Any(c => c.IsNumber());

    public static bool AnyNotNumber(params char[] cs) => cs is not null && cs.Any(c => c.IsNotNumber());

    public static bool AllNotNumber(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNumber());

    public static bool AnyNotNumber(this IEnumerable<char> cs) => cs is not null && cs.Any(c => c.IsNotNumber());

    public static bool NotEqualsIgnoreCase(this char c1, char c2) => c1.ToLowerInvariant() != c2.ToLowerInvariant();

    public static bool AllNotEqualsIgnoreCase(params char[] cs)
    {
        if (cs is null || cs.Length < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Length);
        for (var i = 0; i < cs.Length; i++)
        {
            if (!hashSet.Add(cs[i].ToLowerInvariant()))
            {
                return false;
            }
        }
        return true;
    }

    public static bool AnyNotEqualsIgnoreCase(params char[] cs) => !cs.AllEqualsIgnoreCase();

    public static bool AllNotEqualsIgnoreCase(this IEnumerable<char> cs)
    {
        if (cs is null || cs.Count() < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Count());
        foreach (var c in cs)
        {
            if (!hashSet.Add(c.ToLowerInvariant()))
            {
                return false;
            }
        }
        return true;
    }

    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<char> cs) => !cs.AllEqualsIgnoreCase();

    public static char GetValue(this char c) => c.IsEmpty() ? char.MinValue : c;

    public static char GetValue(this char c, char dfltVal) => c.IsEmpty() ? dfltVal : c;

    public static char GenerateRandomCharacter()
    {
        var chars = "abcdefghijklmnopqrstuvwxyz";
        return chars[GenerateRandomByte(chars.Length)];
    }

    public static IEnumerable<char> GenerateRandomCharacters<T>(T size) where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomCharacter();
        }
    }

    public static char ToLower(this char c) => c.IsNotEmptyAndWhiteSpace() ? char.ToLower(c) : c;

    public static IEnumerable<char> ToLower(this IEnumerable<char> cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToLower(c);
        }
    }

    public static void ToLower(this IList<char> cs)
    {
        if (cs.IsNotEmptyAndNull())
        {
            for (var i = 0; i < cs.Count; i++)
            {
                cs[i] = ToLower(cs[i]);
            }
        }
    }

    public static char ToLowerInvariant(this char c) => c.IsNotEmptyAndWhiteSpace() ? char.ToLowerInvariant(c) : c;

    public static IEnumerable<char> ToLowerInvariant(this IEnumerable<char> cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToLowerInvariant(c);
        }
    }

    public static void ToLowerInvariant(this IList<char> cs)
    {
        if (cs.IsNotEmptyAndNull())
        {
            for (var i = 0; i < cs.Count; i++)
            {
                cs[i] = ToLowerInvariant(cs[i]);
            }
        }
    }

    public static char ToUpper(this char c) => c.IsNotEmptyAndWhiteSpace() ? char.ToUpper(c) : c;

    public static IEnumerable<char> ToUpper(this IEnumerable<char> cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToUpper(c);
        }
    }

    public static void ToUpper(this IList<char> cs)
    {
        if (cs.IsNotEmptyAndNull())
        {
            for (var i = 0; i < cs.Count; i++)
            {
                cs[i] = ToUpper(cs[i]);
            }
        }
    }

    public static char ToUpperInvariant(this char c) => c.IsNotEmptyAndWhiteSpace() ? char.ToUpperInvariant(c) : c;

    public static IEnumerable<char> ToUpperInvariant(this IEnumerable<char> cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToUpperInvariant(c);
        }
    }

    public static void ToUpperInvariant(this IList<char> cs)
    {
        if (cs.IsNotEmptyAndNull())
        {
            for (var i = 0; i < cs.Count; i++)
            {
                cs[i] = ToUpperInvariant(cs[i]);
            }
        }
    }
}
