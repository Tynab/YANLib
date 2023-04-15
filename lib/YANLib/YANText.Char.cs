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
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmpty());

    /// <summary>
    /// Determines whether the specified character is a white space character, including space, tab, and line break characters.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsWhiteSpace(this char c) => char.IsWhiteSpace(c);

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a white space character, including space, tab, and line break characters.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a white space character, including space, tab, and line break characters.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a white space character, including space, tab, and line break characters.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsWhiteSpace(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a white space character, including space, tab, and line break characters.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsWhiteSpace(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a white space character, including space, tab, and line break characters.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsWhiteSpace(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotWhiteSpace());

    /// <summary>
    /// Determines whether the specified character is the null character (<see cref="char.MinValue"/>) or white space.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is the null character (<see cref="char.MinValue"/>) or white space; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this char c) => c.IsEmpty() || char.IsWhiteSpace(c);

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotEmptyOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmptyOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmptyOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmptyOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotEmptyOrWhiteSpace());

    /// <summary>
    /// Determines whether the specified character is an alphabetic character, which includes letters from any language, or is the null character (<see cref="char.MinValue"/>) or a white space character.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is an alphabetic character, or is the null character (<see cref="char.MinValue"/>) or a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsAlphabetic(this char c) => char.IsLetter(c);

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is an alphabetic character, which includes letters from any language, or is <see langword="null"/>, or is the null character (<see cref="char.MinValue"/>), or is a white space character.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is an alphabetic character, or is <see langword="null"/>, or is the null character (<see cref="char.MinValue"/>), or is a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsAlphabetic(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is an alphabetic character, which includes letters from any language, or is <see langword="null"/>, or is the null character (<see cref="char.MinValue"/>), or is a white space character.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is an alphabetic character, or is <see langword="null"/>, or is the null character (<see cref="char.MinValue"/>), or is a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsAlphabetic(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is an alphabetic character, which includes letters from any language, or is <see langword="null"/>, or is the null character (<see cref="char.MinValue"/>), or is a white space character.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is an alphabetic character, or is <see langword="null"/>, or is the null character (<see cref="char.MinValue"/>), or is a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsAlphabetic(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is an alphabetic character, which includes letters from any language, or is <see langword="null"/>, or is the null character (<see cref="char.MinValue"/>), or is a white space character.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is an alphabetic character, or is <see langword="null"/>, or is the null character (<see cref="char.MinValue"/>), or is a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsAlphabetic(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is an alphabetic character, which includes letters from any language, or is <see langword="null"/>, or is the null character (<see cref="char.MinValue"/>), or is a white space character.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is an alphabetic character, or is <see langword="null"/>, or is the null character (<see cref="char.MinValue"/>), or is a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsAlphabetic(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotAlphabetic());

    /// <summary>
    /// Determines whether the specified character is a punctuation character, such as period, comma, exclamation mark, etc., or is the null character (<see cref="char.MinValue"/>) or a white space character.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is a punctuation character, or is the null character (<see cref="char.MinValue"/>) or a white space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsPunctuation(this char c) => char.IsPunctuation(c);

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a punctuation character, such as period, comma, exclamation mark, etc., or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a punctuation character, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsPunctuation(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a punctuation character, such as period, comma, exclamation mark, etc., or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a punctuation character, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsPunctuation(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a punctuation character, such as period, comma, exclamation mark, etc., or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a punctuation character, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsPunctuation(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a punctuation character, such as period, comma, exclamation mark, etc., or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a punctuation character, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsPunctuation(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a punctuation character, such as period, comma, exclamation mark, etc., or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a punctuation character, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsPunctuation(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotPunctuation());

    /// <summary>
    /// Determines whether the specified character is a numeric character, such as 0-9, or is the null character (<see cref="char.MinValue"/>) or a punctuation character, such as period, comma, exclamation mark, etc.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is a numeric character, or is the null character (<see cref="char.MinValue"/>) or a punctuation character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNumber(this char c) => char.IsDigit(c);

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a numeric character, such as 0-9, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace, or is a punctuation character, such as period, comma, exclamation mark, etc.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a numeric character, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace, or is a punctuation character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNumber(params char[] cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a numeric character, such as 0-9, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace, or is a punctuation character, such as period, comma, exclamation mark, etc.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a numeric character, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace, or is a punctuation character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNumber(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a numeric character, such as 0-9, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace, or is a punctuation character, such as period, comma, exclamation mark, etc.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a numeric character, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace, or is a punctuation character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNumber(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a numeric character, such as 0-9, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace, or is a punctuation character, such as period, comma, exclamation mark, etc.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a numeric character, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace, or is a punctuation character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNumber(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is a numeric character, such as 0-9, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace, or is a punctuation character, such as period, comma, exclamation mark, etc.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is a numeric character, or is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace, or is a punctuation character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNumber(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNotNumber());

    /// <summary>
    /// Determines whether the specified characters are equal, comparing their Unicode values.
    /// </summary>
    /// <param name="c1">The first character to compare.</param>
    /// <param name="c2">The second character to compare.</param>
    /// <returns><see langword="true"/> if the characters are equal, comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(this char c1, char c2) => c1 == c2;

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable are equal to the first character in the enumerable, comparing their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to compare.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable are equal to the first character in the enumerable, comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(params char[] cs) => cs is not null && !cs.Any(s => s.NotEquals(cs[0]));

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable are equal to the first character in the enumerable, comparing their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to compare.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable are equal to the first character in the enumerable, comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(this IEnumerable<char> cs) => cs is not null && !cs.Any(s => s.NotEquals(cs.First()));

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable are equal to the first character in the enumerable, comparing their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to compare.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable are equal to the first character in the enumerable, comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(s => s.NotEquals(cs.First()));

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable are equal to the first character in the enumerable, comparing their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to compare.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable are equal to the first character in the enumerable, comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(s => s.NotEquals(cs[0]));

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable are equal to the first character in the enumerable, comparing their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to compare.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable are equal to the first character in the enumerable, comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool Equals(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(s => s.NotEquals(cs.First()));

    /// <summary>
    /// Determines whether the specified characters are equal, ignoring their casing, and comparing their Unicode values.
    /// </summary>
    /// <param name="c1">The first character to compare.</param>
    /// <param name="c2">The second character to compare.</param>
    /// <returns><see langword="true"/> if the characters are equal, ignoring their casing, and comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this char c1, char c2) => char.ToLowerInvariant(c1) == char.ToLowerInvariant(c2);

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable are equal to the first character in the enumerable, ignoring their casing, and comparing their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to compare.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable are equal to the first character in the enumerable, ignoring their casing, and comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(params char[] cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs[0]));

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable are equal to the first character in the enumerable, ignoring their casing, and comparing their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to compare.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable are equal to the first character in the enumerable, ignoring their casing, and comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this IEnumerable<char> cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs.First()));

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable are equal to the first character in the enumerable, ignoring their casing, and comparing their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to compare.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable are equal to the first character in the enumerable, ignoring their casing, and comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs.First()));

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable are equal to the first character in the enumerable, ignoring their casing, and comparing their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to compare.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable are equal to the first character in the enumerable, ignoring their casing, and comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs[0]));

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable are equal to the first character in the enumerable, ignoring their casing, and comparing their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to compare.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable are equal to the first character in the enumerable, ignoring their casing, and comparing their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(s => s.NotEqualsIgnoreCase(cs.First()));

    /// <summary>
    /// Determines whether the specified character is not the null character (<see cref="char.MinValue"/>).
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not the null character (<see cref="char.MinValue"/>); otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(this char c) => c is not char.MinValue;

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(params char[] cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsEmpty());

    /// <summary>
    /// Determines whether the specified character is not a whitespace character, including space, tab, newline, carriage return, form feed, or vertical tab.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotWhiteSpace(this char c) => !char.IsWhiteSpace(c);

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a whitespace character, including space, tab, newline, carriage return, form feed, or vertical tab.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a whitespace character, including space, tab, newline, carriage return, form feed, or vertical tab.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a whitespace character, including space, tab, newline, carriage return, form feed, or vertical tab.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotWhiteSpace(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a whitespace character, including space, tab, newline, carriage return, form feed, or vertical tab.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotWhiteSpace(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a whitespace character, including space, tab, newline, carriage return, form feed, or vertical tab.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotWhiteSpace(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsWhiteSpace());

    /// <summary>
    /// Determines whether the specified character is not the null character (<see cref="char.MinValue"/>) and is not a whitespace character.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not the null character (<see cref="char.MinValue"/>) and is not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(this char c) => c.IsNotEmpty() && !char.IsWhiteSpace(c);

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a white-space character or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a white-space character or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(params char[] cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a white-space character or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a white-space character or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a white-space character or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a white-space character or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a white-space character or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a white-space character or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a white-space character or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a white-space character or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyOrWhiteSpace(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether the specified character is not an alphabetic character and is not the null character (<see cref="char.MinValue"/>) and is not a whitespace character.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not an alphabetic character and is not the null character (<see cref="char.MinValue"/>) and is not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotAlphabetic(this char c) => !char.IsLetter(c);

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotAlphabetic(params char[] cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotAlphabetic(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotAlphabetic(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotAlphabetic(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotAlphabetic(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsAlphabetic());

    /// <summary>
    /// Determines whether the specified character is not a punctuation character, not an alphabetic character, not the null character (<see cref="char.MinValue"/>), and not a whitespace character.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not a punctuation character, not an alphabetic character, not the null character (<see cref="char.MinValue"/>), and not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotPunctuation(this char c) => !char.IsPunctuation(c);

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotPunctuation(params char[] cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotPunctuation(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotPunctuation(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotPunctuation(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotPunctuation(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsPunctuation());

    /// <summary>
    /// Determines whether the specified character is not a numeric character, not a punctuation character, not an alphabetic character, not the null character (<see cref="char.MinValue"/>), and not a whitespace character.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not a numeric character, not a punctuation character, not an alphabetic character, not the null character (<see cref="char.MinValue"/>), and not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNumber(this char c) => !char.IsDigit(c);

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a numeric character, not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a numeric character, not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNumber(params char[] cs) => cs is not null && !cs.Any(c => c.IsNumber());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a numeric character, not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a numeric character, not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNumber(this IEnumerable<char> cs) => cs is not null && !cs.Any(c => c.IsNumber());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a numeric character, not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a numeric character, not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNumber(this IReadOnlyCollection<char> cs) => cs is not null && !cs.Any(c => c.IsNumber());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a numeric character, not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a numeric character, not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNumber(this IReadOnlyList<char> cs) => cs is not null && !cs.Any(c => c.IsNumber());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is not a numeric character, not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is not a numeric character, not a punctuation character, not an alphabetic character, not a white-space character, or not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNumber(this IReadOnlySet<char> cs) => cs is not null && !cs.Any(c => c.IsNumber());

    /// <summary>
    /// Determines whether two specified characters are not equal, based on their Unicode values.
    /// </summary>
    /// <param name="c1">The first character to compare.</param>
    /// <param name="c2">The second character to compare.</param>
    /// <returns><see langword="true"/> if the two characters are not equal, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool NotEquals(this char c1, char c2) => c1 != c2;

    /// <summary>
    /// Determines whether all the characters in the specified enumerable are distinct, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if all the characters in the specified enumerable are distinct, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
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

    /// <summary>
    /// Determines whether all the characters in the specified enumerable are distinct, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if all the characters in the specified enumerable are distinct, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
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

    /// <summary>
    /// Determines whether all the characters in the specified enumerable are distinct, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if all the characters in the specified enumerable are distinct, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
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

    /// <summary>
    /// Determines whether all the characters in the specified enumerable are distinct, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if all the characters in the specified enumerable are distinct, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
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

    /// <summary>
    /// Determines whether all the characters in the specified enumerable are distinct, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if all the characters in the specified enumerable are distinct, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
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

    /// <summary>
    /// Determines whether two specified characters are not equal, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="c1">The first character to compare.</param>
    /// <param name="c2">The second character to compare.</param>
    /// <returns><see langword="true"/> if the two characters are not equal, ignoring their casing, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this char c1, char c2) => char.ToLowerInvariant(c1) != char.ToLowerInvariant(c2);

    /// <summary>
    /// Determines whether all the characters in the specified enumerable are distinct, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if all the characters in the specified enumerable are distinct, ignoring their casing, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
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

    /// <summary>
    /// Determines whether all the characters in the specified enumerable are distinct, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if all the characters in the specified enumerable are distinct, ignoring their casing, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
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

    /// <summary>
    /// Determines whether all the characters in the specified enumerable are distinct, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if all the characters in the specified enumerable are distinct, ignoring their casing, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this IReadOnlyCollection<char> cs)
    {
        if (cs is null || cs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Count);
        foreach (var c in cs)
        {
            if (!hashSet.Add(c.ToLowerInvariant()))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determines whether all the characters in the specified enumerable are distinct, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if all the characters in the specified enumerable are distinct, ignoring their casing, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this IReadOnlyList<char> cs)
    {
        if (cs is null || cs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Count);
        for (var i = 0; i < cs.Count; i++)
        {
            if (!hashSet.Add(cs[i].ToLowerInvariant()))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Determines whether all the characters in the specified enumerable are distinct, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if all the characters in the specified enumerable are distinct, ignoring their casing, based on their Unicode values; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this IReadOnlySet<char> cs)
    {
        if (cs is null || cs.Count < 2)
        {
            return false;
        }
        var hashSet = new HashSet<char>(cs.Count);
        foreach (var c in cs)
        {
            if (!hashSet.Add(c.ToLowerInvariant()))
            {
                return false;
            }
        }
        return true;
    }

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

    /// <summary>
    /// Generates a random lowercase character from the English alphabet.
    /// </summary>
    /// <returns>A randomly generated lowercase character from the English alphabet.</returns>
    public static char GenerateRandomCharacter()
    {
        var chars = "abcdefghijklmnopqrstuvwxyz";
        return chars[GenerateRandomByte(chars.Length)];
    }

    /// <summary>
    /// Converts the character to lowercase if it is not empty or whitespace; otherwise, returns the original character.
    /// </summary>
    /// <param name="c">The character to convert to lowercase.</param>
    /// <returns>The lowercase version of the character if it is not empty or whitespace; otherwise, the original character.</returns>
    public static char ToLower(this char c) => c.IsNotEmptyOrWhiteSpace() ? char.ToLower(c) : c;

    /// <summary>
    /// Converts the character to lowercase and updates the input character reference to the lowercase version, if it is not empty or whitespace; otherwise, returns the original character.
    /// </summary>
    /// <param name="c">The character to convert to lowercase.</param>
    public static void ToLower(ref char c) => c = ToLower(c);

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to lowercase,
    /// ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to convert to lowercase.</param>
    /// <returns>An enumerable of characters converted to lowercase, ignoring their casing, based on their Unicode values.</returns>
    public static IEnumerable<char> ToLower(params char[] cs)
    {
        if (cs is null || cs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Length; i++)
        {
            yield return ToLower(cs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to lowercase,
    /// ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to convert to lowercase.</param>
    /// <returns>An enumerable of characters converted to lowercase, ignoring their casing, based on their Unicode values.</returns>
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

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to lowercase,
    /// ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to convert to lowercase.</param>
    /// <returns>An enumerable of characters converted to lowercase, ignoring their casing, based on their Unicode values.</returns>
    public static IEnumerable<char> ToLower(this IReadOnlyCollection<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToLower(c);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to lowercase,
    /// ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to convert to lowercase.</param>
    /// <returns>An enumerable of characters converted to lowercase, ignoring their casing, based on their Unicode values.</returns>
    public static IEnumerable<char> ToLower(this IReadOnlyList<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Count; i++)
        {
            yield return ToLower(cs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to lowercase,
    /// ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The characters to convert to lowercase.</param>
    /// <returns>An enumerable of characters converted to lowercase, ignoring their casing, based on their Unicode values.</returns>
    public static IEnumerable<char> ToLower(this IReadOnlySet<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToLower(c);
        }
    }

    /// <summary>
    /// Converts the characters in the specified list to lowercase, ignoring their casing, based on their Unicode values.
    /// </summary>
    /// <param name="cs">The list of characters to convert to lowercase.</param>
    public static void ToLowerRef(this IList<char> cs)
    {
        if (cs is not null && cs.Count > 0)
        {
            for (var i = 0; i < cs.Count; i++)
            {
                cs[i] = ToLower(cs[i]);
            }
        }
    }

    /// <summary>
    /// Converts the character to lowercase using the invariant culture, if it is not empty or whitespace; otherwise, returns the original character.
    /// </summary>
    /// <param name="c">The character to convert to lowercase.</param>
    /// <returns>The lowercase version of the character using the invariant culture if it is not empty or whitespace; otherwise, the original character.</returns>
    public static char ToLowerInvariant(this char c) => c.IsNotEmptyOrWhiteSpace() ? char.ToLowerInvariant(c) : c;

    /// <summary>
    /// Converts the character to lowercase using the invariant culture, if it is not empty or whitespace; otherwise, returns the original character.
    /// </summary>
    /// <param name="c">The character to convert to lowercase.</param>
    public static void ToLowerInvariant(ref char c) => c = ToLowerInvariant(c);

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to lowercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to lowercase.</param>
    /// <returns>An enumerable of characters converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<char> ToLowerInvariant(params char[] cs)
    {
        if (cs is null || cs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Length; i++)
        {
            yield return ToLowerInvariant(cs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to lowercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to lowercase.</param>
    /// <returns>An enumerable of characters converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
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

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to lowercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to lowercase.</param>
    /// <returns>An enumerable of characters converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<char> ToLowerInvariant(this IReadOnlyCollection<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToLowerInvariant(c);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to lowercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to lowercase.</param>
    /// <returns>An enumerable of characters converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<char> ToLowerInvariant(this IReadOnlyList<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Count; i++)
        {
            yield return ToLowerInvariant(cs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to lowercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to lowercase.</param>
    /// <returns>An enumerable of characters converted to lowercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<char> ToLowerInvariant(this IReadOnlySet<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToLowerInvariant(c);
        }
    }

    /// <summary>
    /// Converts all characters in the specified character list to lowercase using the invariant culture, by modifying the list in-place.
    /// </summary>
    /// <param name="cs">The character list to convert to lowercase.</param>
    public static void ToLowerInvariantRef(this IList<char> cs)
    {
        if (cs is not null && cs.Count > 0)
        {
            for (var i = 0; i < cs.Count; i++)
            {
                cs[i] = ToLowerInvariant(cs[i]);
            }
        }
    }

    /// <summary>
    /// Converts the character to uppercase using the invariant culture, if it is not empty or whitespace; otherwise, returns the original character.
    /// </summary>
    /// <param name="c">The character to convert to uppercase.</param>
    /// <returns>The uppercase version of the character using the invariant culture if it is not empty or whitespace; otherwise, the original character.</returns>
    public static char ToUpper(this char c) => c.IsNotEmptyOrWhiteSpace() ? char.ToUpper(c) : c;

    /// <summary>
    /// Converts the character to uppercase using the invariant culture and updates the input character reference to the uppercase version.
    /// </summary>
    /// <param name="c">The character to convert to uppercase.</param>
    public static void ToUpper(ref char c) => c = ToUpper(c);

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to uppercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to uppercase.</param>
    /// <returns>An enumerable of characters converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<char> ToUpper(params char[] cs)
    {
        if (cs is null || cs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Length; i++)
        {
            yield return ToUpper(cs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to uppercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to uppercase.</param>
    /// <returns>An enumerable of characters converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
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

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to uppercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to uppercase.</param>
    /// <returns>An enumerable of characters converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<char> ToUpper(this IReadOnlyCollection<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToUpper(c);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to uppercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to uppercase.</param>
    /// <returns>An enumerable of characters converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<char> ToUpper(this IReadOnlyList<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Count; i++)
        {
            yield return ToUpper(cs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to uppercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to uppercase.</param>
    /// <returns>An enumerable of characters converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<char> ToUpper(this IReadOnlySet<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToUpper(c);
        }
    }

    /// <summary>
    /// Converts all characters in the specified character list to uppercase, by modifying the list in-place.
    /// </summary>
    /// <param name="cs">The character list to convert to uppercase.</param>
    public static void ToUpperRef(this IList<char> cs)
    {
        if (cs is not null && cs.Count > 0)
        {
            for (var i = 0; i < cs.Count; i++)
            {
                cs[i] = ToUpper(cs[i]);
            }
        }
    }

    /// <summary>
    /// Converts the character to uppercase using the invariant culture, if it is not empty or whitespace; otherwise, returns the original character.
    /// </summary>
    /// <param name="c">The character to convert to uppercase.</param>
    /// <returns>The uppercase version of the character using the invariant culture if it is not empty or whitespace; otherwise, the original character.</returns>
    public static char ToUpperInvariant(this char c) => c.IsNotEmptyOrWhiteSpace() ? char.ToUpperInvariant(c) : c;

    /// <summary>
    /// Converts the character to uppercase using the invariant culture, if it is not empty or whitespace; otherwise, updates the original character to its uppercase version.
    /// </summary>
    /// <param name="c">The character to convert to uppercase.</param>
    public static void ToUpperInvariant(ref char c) => c = ToUpperInvariant(c);

    public static IEnumerable<char> ToUpperInvariant(params char[] cs)
    {
        if (cs is null || cs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Length; i++)
        {
            yield return ToUpperInvariant(cs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to uppercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to uppercase.</param>
    /// <returns>An enumerable of characters converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
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

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to uppercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to uppercase.</param>
    /// <returns>An enumerable of characters converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<char> ToUpperInvariant(this IReadOnlyCollection<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToUpperInvariant(c);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to uppercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to uppercase.</param>
    /// <returns>An enumerable of characters converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<char> ToUpperInvariant(this IReadOnlyList<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < cs.Count; i++)
        {
            yield return ToUpperInvariant(cs[i]);
        }
    }

    /// <summary>
    /// Enumerates through an enumerable of characters and returns a new enumerable of characters converted to uppercase,
    /// ignoring their casing, based on their Unicode values using the invariant culture.
    /// </summary>
    /// <param name="cs">The characters to convert to uppercase.</param>
    /// <returns>An enumerable of characters converted to uppercase, ignoring their casing, based on their Unicode values using the invariant culture.</returns>
    public static IEnumerable<char> ToUpperInvariant(this IReadOnlySet<char> cs)
    {
        if (cs is null || cs.Count < 1)
        {
            yield break;
        }
        foreach (var c in cs)
        {
            yield return ToUpperInvariant(c);
        }
    }

    /// <summary>
    /// Converts all characters in the specified character list to uppercase using the invariant culture, by modifying the list in-place.
    /// </summary>
    /// <param name="cs">The character list to convert to uppercase.</param>
    public static void ToUpperInvariantRef(this IList<char> cs)
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
