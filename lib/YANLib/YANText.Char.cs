using static YANLib.YANNum;

namespace YANLib;

public static partial class YANText
{
    
    public static bool IsEmpty(this char c) => c is char.MinValue;

    public static bool IsEmpty(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    public static bool IsEmpty(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    public static bool IsWhiteSpace(this char c) => char.IsWhiteSpace(c);

    public static bool IsWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    public static bool IsWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    public static bool IsNullOrWhiteSpace(this char c) => c.IsEmpty() || c.IsWhiteSpace();

    public static bool IsNullOrWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotEmptyAndWhiteSpace());

    public static bool IsNullOrWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmptyAndWhiteSpace());

    public static bool IsAlphabetic(this char c) => char.IsLetter(c);

    public static bool IsAlphabetic(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    public static bool IsAlphabetic(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    public static bool IsPunctuation(this char c) => char.IsPunctuation(c);

    public static bool IsPunctuation(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    public static bool IsPunctuation(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    public static bool IsNumber(this char c) => char.IsDigit(c);

    public static bool IsNumber(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    public static bool IsNumber(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    public static bool Equals(this char c1, char c2) => c1 == c2;

    public static bool Equals(params char[] cs) => cs is not null && !cs.Any(s => s.NotEquals(cs[0]));

    public static bool Equals(this IEnumerable<char> cs) => cs is not null && !cs.Any(s => s.NotEquals(cs.First()));

    public static bool EqualsIgnoreCase(this char c1, char c2) => c1.ToLowerInvariant() == c2.ToLowerInvariant();

    public static bool EqualsIgnoreCase(params char[] cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs[0]));

    public static bool EqualsIgnoreCase(this IEnumerable<char> cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs.First()));

    public static bool IsNotEmpty(this char c) => c is not char.MinValue;

    public static bool IsNotEmpty(params char[] cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    public static bool IsNotEmpty(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    public static bool IsNotWhiteSpace(this char c) => !char.IsWhiteSpace(c);

    public static bool IsNotWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    public static bool IsNotWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    public static bool IsNotEmptyAndWhiteSpace(this char c) => c.IsNotEmpty() && c.IsNotWhiteSpace();

    public static bool IsNotEmptyAndWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    public static bool IsNotEmptyAndWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    public static bool IsNotAlphabetic(this char c) => !char.IsLetter(c);

    public static bool IsNotAlphabetic(params char[] cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    public static bool IsNotAlphabetic(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    public static bool IsNotPunctuation(this char c) => !char.IsPunctuation(c);

    public static bool IsNotPunctuation(params char[] cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    public static bool IsNotPunctuation(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    public static bool IsNotNumber(this char c) => !char.IsDigit(c);

    public static bool IsNotNumber(params char[] cs) => cs is not null && !cs.Any(c => c.IsNumber());

    public static bool IsNotNumber(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNumber());

    public static bool NotEquals(this char c1, char c2) => c1 != c2;

    public static bool NotEquals(params char[] cs)
    {
        if (cs is null || cs.Length < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Length);
        for (var i = 0; i < cs.Length; i++)
        {
            if (!hashSet.Add(cs[i]))
            {
                return false;
            }
        }
        return true;
    }

    public static bool NotEquals(this IEnumerable<char> cs)
    {
        if (cs is null || cs.Count() < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Count());
        foreach (var c in cs)
        {
            if (!hashSet.Add(c))
            {
                return false;
            }
        }
        return true;
    }

    public static bool NotEqualsIgnoreCase(this char c1, char c2) => c1.ToLowerInvariant() != c2.ToLowerInvariant();

    public static bool NotEqualsIgnoreCase(params char[] cs)
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

    public static bool NotEqualsIgnoreCase(this IEnumerable<char> cs)
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

    public static char GetValue(this char c) => c.IsEmpty() ? char.MinValue : c;

    public static char GetValue(this char c, char dfltVal) => c.IsEmpty() ? dfltVal : c;

    public static char GenerateRandomCharacter()
    {
        var chars = "abcdefghijklmnopqrstuvwxyz";
        return chars[GenerateRandomByte(chars.Length)];
    }

    public static char ToLower(this char c) => c.IsNotEmptyAndWhiteSpace() ? char.ToLower(c) : c;

    public static IEnumerable<char> ToLower(this IEnumerable<char> cs)
    {
        if (cs is null || !cs.Any())
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
        if (cs is not null && cs.Count > 0)
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
        if (cs is null || !cs.Any())
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
        if (cs is not null && cs.Count > 0)
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
        if (cs is null || !cs.Any())
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
        if (cs is not null && cs.Count > 0)
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
        if (cs is null || !cs.Any())
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
        if (cs is not null && cs.Count > 0)
        {
            for (var i = 0; i < cs.Count; i++)
            {
                cs[i] = ToUpperInvariant(cs[i]);
            }
        }
    }
}
