using static YANLib.YANNum;

namespace YANLib;

public static partial class YANText
{
    /// <summary>
    /// Determines whether the specified character is the null character (<see cref="char.MinValue"/>).
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is the null character (<see cref="char.MinValue"/>); otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(this char c) => c == char.MinValue;

    /// <summary>
    /// Determines whether any of the specified characters in the array is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the array is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only collection is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only collection is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only list is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only list is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only set is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only set is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    /// <summary>
    /// Determines whether the specified character is the null character (<see cref="char.MinValue"/>) or white space.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is the null character (<see cref="char.MinValue"/>) or white space; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this char c) => c.IsEmpty() || char.IsWhiteSpace(c);

    /// <summary>
    /// Determines whether any of the specified characters in the array is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the array is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotEmptyOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable collection is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable collection is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmptyOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only collection is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only collection is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmptyOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only list is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only list is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmptyOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only set is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only set is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmptyOrWhiteSpace());

    /// <summary>
    /// Determines whether the specified character is not the null character (<see cref="char.MinValue"/>).
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not the null character (<see cref="char.MinValue"/>); otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(this char c) => c is not char.MinValue;

    /// <summary>
    /// Determines whether any of the specified characters in the array is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the array is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(params char[] cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable collection is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable collection is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only collection is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only collection is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only list is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only list is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only set is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only set is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    /// <summary>
    /// Determines whether the specified character is not the null character (<see cref="char.MinValue"/>) and is not a whitespace character.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not the null character (<see cref="char.MinValue"/>) and is not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(this char c) => c.IsNotEmpty() && !char.IsWhiteSpace(c);

    /// <summary>
    /// Determines whether any of the specified characters in the array is not a white-space character or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the array is not a white-space character or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable collection is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable collection is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only collection is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only collection is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only list is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only list is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only set is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only set is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    public static bool IsWhiteSpace(this char c) => char.IsWhiteSpace(c);

    public static bool IsWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    public static bool IsWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    public static bool IsWhiteSpace(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    public static bool IsWhiteSpace(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    public static bool IsWhiteSpace(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    public static bool IsNotWhiteSpace(this char c) => !char.IsWhiteSpace(c);

    public static bool IsNotWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    public static bool IsNotWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    public static bool IsNotWhiteSpace(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    public static bool IsNotWhiteSpace(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    public static bool IsNotWhiteSpace(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    public static bool IsAlphabetic(this char c) => char.IsLetter(c);

    public static bool IsAlphabetic(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    public static bool IsAlphabetic(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    public static bool IsAlphabetic(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    public static bool IsAlphabetic(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    public static bool IsAlphabetic(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    public static bool IsNotAlphabetic(this char c) => !char.IsLetter(c);

    public static bool IsNotAlphabetic(params char[] cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    public static bool IsNotAlphabetic(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    public static bool IsNotAlphabetic(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    public static bool IsNotAlphabetic(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    public static bool IsNotAlphabetic(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    public static bool IsPunctuation(this char c) => char.IsPunctuation(c);

    public static bool IsPunctuation(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    public static bool IsPunctuation(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    public static bool IsPunctuation(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    public static bool IsPunctuation(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    public static bool IsPunctuation(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    public static bool IsNotPunctuation(this char c) => !char.IsPunctuation(c);

    public static bool IsNotPunctuation(params char[] cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    public static bool IsNotPunctuation(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    public static bool IsNotPunctuation(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    public static bool IsNotPunctuation(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    public static bool IsNotPunctuation(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    public static bool IsNumber(this char c) => char.IsDigit(c);

    public static bool IsNumber(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    public static bool IsNumber(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    public static bool IsNumber(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    public static bool IsNumber(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    public static bool IsNumber(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    public static bool IsNotNumber(this char c) => !char.IsDigit(c);

    public static bool IsNotNumber(params char[] cs) => cs is not null && !cs.Any(c => c.IsNumber());

    public static bool IsNotNumber(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNumber());

    public static bool IsNotNumber(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNumber());

    public static bool IsNotNumber(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNumber());

    public static bool IsNotNumber(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNumber());

    /// <summary>
    /// Returns the non-null character value or <see cref="char.MinValue"/> if it is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="c">The character to retrieve the value from.</param>
    /// <returns>The non-null character value or <see cref="char.MinValue"/> if it is <see langword="null"/> or empty.</returns>
    public static char GetValue(this char c) => c.IsEmpty() ? char.MinValue : c;

    /// <summary>
    /// Returns the non-null character value or the default value if it is <see langword="null"/>.
    /// </summary>
    /// <param name="c">The character to retrieve the value from.</param>
    /// <param name="dfltVal">The default value to return if the character is <see langword="null"/>.</param>
    /// <returns>The non-null character value or the default value if it is <see langword="null"/>.</returns>
    public static char GetValue(this char c, char dfltVal) => c.IsEmpty() ? char.MinValue : dfltVal;

    public static char GenerateRandomCharacter()
    {
        var chars = "abcdefghijklmnopqrstuvwxyz";
        return chars[GenerateRandomByte(chars.Length)];
    }

    public static bool Equals(this char c1, char c2) => c1 == c2;

    public static bool Equals(params char[] cs) => cs is not null && !cs.Any(s => s.NotEquals(cs[0]));

    public static bool Equals(this IEnumerable<char> cs) => cs is not null && !cs.Any(s => s.NotEquals(cs.First()));

    public static bool Equals(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(s => s.NotEquals(cs.First()));

    public static bool Equals(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(s => s.NotEquals(cs[0]));

    public static bool Equals(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(s => s.NotEquals(cs.First()));

    public static bool EqualsIgnoreCase(this char c1, char c2) => char.ToLowerInvariant(c1) == char.ToLowerInvariant(c2);

    public static bool EqualsIgnoreCase(params char[] cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs[0]));

    public static bool EqualsIgnoreCase(this IEnumerable<char> cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs.First()));

    public static bool EqualsIgnoreCase(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs.First()));

    public static bool EqualsIgnoreCase(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs[0]));

    public static bool EqualsIgnoreCase(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs.First()));

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

    public static bool NotEquals(this IReadOnlyCollection<char> cs)
    {
        if (cs is null || cs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Count);
        foreach (var c in cs)
        {
            if (!hashSet.Add(c))
            {
                return false;
            }
        }
        return true;
    }

    public static bool NotEquals(this IReadOnlyList<char> cs)
    {
        if (cs is null || cs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Count);
        for (var i = 0; i < cs.Count; i++)
        {
            if (!hashSet.Add(cs[i]))
            {
                return false;
            }
        }
        return true;
    }

    public static bool NotEquals(this IReadOnlySet<char> cs)
    {
        if (cs is null || cs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Count);
        foreach (var c in cs)
        {
            if (!hashSet.Add(c))
            {
                return false;
            }
        }
        return true;
    }

    public static bool NotEqualsIgnoreCase(this char c1, char c2) => char.ToLowerInvariant(c1) != char.ToLowerInvariant(c2);

    public static bool NotEquals(params char[] cs)
    {
        if (cs is null || cs.Length < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Length);
        for (var i = 0; i < cs.Length; i++)
        {
            var temp = cs[i].tol
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

    public static bool NotEquals(this IReadOnlyCollection<char> cs)
    {
        if (cs is null || cs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Count);
        foreach (var c in cs)
        {
            if (!hashSet.Add(c))
            {
                return false;
            }
        }
        return true;
    }

    public static bool NotEquals(this IReadOnlyList<char> cs)
    {
        if (cs is null || cs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Count);
        for (var i = 0; i < cs.Count; i++)
        {
            if (!hashSet.Add(cs[i]))
            {
                return false;
            }
        }
        return true;
    }

    public static bool NotEquals(this IReadOnlySet<char> cs)
    {
        if (cs is null || cs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Count);
        foreach (var c in cs)
        {
            if (!hashSet.Add(c))
            {
                return false;
            }
        }
        return true;
    }

    public static char ToLowerInvariant(this char c) => c.IsNotWhiteSpace() ? c.ToLowerInvariant() : c;
    public static char ToLowerInvariant(this char c) => c.IsNotWhiteSpace() ? c.ToLowerInvariant() : c;
}
