namespace YANLib;

public static partial class YANText
{
    /// <summary>
    /// Determines whether the specified character is the null character (<see cref="char.MinValue"/>).
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is the null character (<see cref="char.MinValue"/>); otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(this char c) => c == char.MinValue;

    /// <summary>
    /// Determines whether any of the specified characters in the array is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the array is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(params char[] cs) => !cs.Any(c => c.HasValue());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(IEnumerable<char> cs) => !cs.Any(c => c.HasValue());

    /// <summary>
    /// Determines whether any of the specified characters in the collection is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the collection is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(ICollection<char> cs) => !cs.Any(c => c.HasValue());

    /// <summary>
    /// Determines whether any of the specified characters in the list is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the list is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(IList<char> cs) => !cs.Any(c => c.HasValue());

    /// <summary>
    /// Determines whether any of the specified characters in the set is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the set is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(ISet<char> cs) => !cs.Any(c => c.HasValue());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only collection is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only collection is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(IReadOnlyCollection<char> cs) => !cs.Any(c => c.HasValue());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only list is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only list is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(IReadOnlyList<char> cs) => !cs.Any(c => c.HasValue());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only set is <see langword="null"/> or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only set is <see langword="null"/> or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrEmpty(IReadOnlySet<char> cs) => !cs.Any(c => c.HasValue());

    /// <summary>
    /// Determines whether the specified character is the null character (<see cref="char.MinValue"/>) or white space.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is the null character (<see cref="char.MinValue"/>) or white space; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(this char c) => c.IsNullOrEmpty() || char.IsWhiteSpace(c);

    /// <summary>
    /// Determines whether any of the specified characters in the array is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the array is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(params char[] cs) => !cs.Any(c => c.HasCharater());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable collection is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable collection is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(IEnumerable<char> cs) => !cs.Any(c => c.HasCharater());

    /// <summary>
    /// Determines whether any of the specified characters in the collection is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the collection is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(ICollection<char> cs) => !cs.Any(c => c.HasCharater());

    /// <summary>
    /// Determines whether any of the specified characters in the list is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the list is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(IList<char> cs) => !cs.Any(c => c.HasCharater());

    /// <summary>
    /// Determines whether any of the specified characters in the set is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the set is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(ISet<char> cs) => !cs.Any(c => c.HasCharater());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only collection is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only collection is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(IReadOnlyCollection<char> cs) => !cs.Any(c => c.HasCharater());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only list is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only list is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(IReadOnlyList<char> cs) => !cs.Any(c => c.HasCharater());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only set is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only set is <see langword="null"/> or <see cref="char.MinValue"/> or whitespace; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullOrWhiteSpace(IReadOnlySet<char> cs) => !cs.Any(c => c.HasCharater());

    /// <summary>
    /// Determines whether the specified character is not the null character (<see cref="char.MinValue"/>).
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not the null character (<see cref="char.MinValue"/>); otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(this char c) => c != char.MinValue;

    /// <summary>
    /// Determines whether any of the specified characters in the array is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the array is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(params char[] cs) => !cs.Any(c => c.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable collection is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable collection is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(IEnumerable<char> cs) => !cs.Any(c => c.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the collection is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the collection is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(ICollection<char> cs) => !cs.Any(c => c.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the list is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the list is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(IList<char> cs) => !cs.Any(c => c.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the set is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the set is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(ISet<char> cs) => !cs.Any(c => c.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only collection is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only collection is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(IReadOnlyCollection<char> cs) => !cs.Any(c => c.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only list is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only list is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(IReadOnlyList<char> cs) => !cs.Any(c => c.IsNullOrEmpty());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only set is not <see langword="null"/> and not <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only set is not <see langword="null"/> and not <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasValue(IReadOnlySet<char> cs) => !cs.Any(c => c.IsNullOrEmpty());

    /// <summary>
    /// Determines whether the specified character is not the null character (<see cref="char.MinValue"/>) and is not a whitespace character.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not the null character (<see cref="char.MinValue"/>) and is not a whitespace character; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(this char c) => c.HasValue() && !char.IsWhiteSpace(c);

    /// <summary>
    /// Determines whether any of the specified characters in the array is not a white-space character or <see cref="char.MinValue"/>.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the array is not a white-space character or <see cref="char.MinValue"/>; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(params char[] cs) => !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the enumerable collection is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the enumerable collection is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(IEnumerable<char> cs) => !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the collection is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the collection is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(ICollection<char> cs) => !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the list is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the list is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(IList<char> cs) => !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the set is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the set is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(ISet<char> cs) => !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only collection is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only collection is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(IReadOnlyCollection<char> cs) => !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only list is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only list is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(IReadOnlyList<char> cs) => !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Determines whether any of the specified characters in the read-only set is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space.
    /// </summary>
    /// <param name="cs">The characters to check.</param>
    /// <returns><see langword="true"/> if any of the characters in the read-only set is not <see langword="null"/> and not <see cref="char.MinValue"/> and not white space; otherwise, <see langword="false"/>.</returns>
    public static bool HasCharater(IReadOnlySet<char> cs) => !cs.Any(c => c.IsNullOrWhiteSpace());

    /// <summary>
    /// Returns the non-null character value or <see cref="char.MinValue"/> if it is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="c">The character to retrieve the value from.</param>
    /// <returns>The non-null character value or <see cref="char.MinValue"/> if it is <see langword="null"/> or empty.</returns>
    public static char GetValue(this char c) => c.IsNullOrEmpty() ? char.MinValue : c;

    /// <summary>
    /// Returns the non-null character value or the default value if it is <see langword="null"/>.
    /// </summary>
    /// <param name="c">The character to retrieve the value from.</param>
    /// <param name="dfltVal">The default value to return if the character is <see langword="null"/>.</param>
    /// <returns>The non-null character value or the default value if it is <see langword="null"/>.</returns>
    public static char GetValue(this char c, char dfltVal) => c.IsNullOrEmpty() ? char.MinValue : dfltVal;
}
