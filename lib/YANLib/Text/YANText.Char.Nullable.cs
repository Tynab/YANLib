using System.Diagnostics.CodeAnalysis;
using YANLib.Object;
using YANLib.Text;

namespace YANLib.Text;

public static partial class YANText
{
    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullEmpty([NotNullWhen(false)] this char? input) => !input.HasValue || input.Value.IsEmpty();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllNullEmpty(this IEnumerable<char?> input) => !input.Any(x => x.IsNotNullEmpty());

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllNullEmpty(params char?[] input) => !input.Any(x => x.IsNotNullEmpty());

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNullEmpty(this IEnumerable<char?> input) => input.Any(x => x.IsNullEmpty());

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNullEmpty(params char?[] input) => input.Any(x => x.IsNullEmpty());

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/>, empty, or a white-space character.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/>, empty, or a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNullWhiteSpace([NotNullWhen(false)] this char? input) => !input.HasValue || input.Value.IsEmpty() || input.Value.IsWhiteSpace();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/>, empty, or white-space characters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/>, empty, or white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNullWhiteSpace(this IEnumerable<char?> input) => !input.Any(x => x.IsNotNullWhiteSpace());

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/>, empty, or white-space characters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/>, empty, or white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNullWhiteSpace(params char?[] input) => !input.Any(x => x.IsNotNullWhiteSpace());

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/>, empty, or a white-space character.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/>, empty, or a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNullWhiteSpace(this IEnumerable<char?> input) => input.Any(x => x.IsNullWhiteSpace());

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/>, empty, or a white-space character.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/>, empty, or a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNullWhiteSpace(params char?[] input) => input.Any(x => x.IsNullWhiteSpace());

    /// <summary>
    /// Determines whether the specified nullable character has a value and is a letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is a letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsAlphabetic([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsAlphabetic();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllAlphabetic(this IEnumerable<char?> input) => !input.Any(x => x.IsNotAlphabetic());

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllAlphabetic(params char?[] input) => !input.Any(x => x.IsNotAlphabetic());

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is a letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyAlphabetic(this IEnumerable<char?> input) => input.Any(x => x.IsAlphabetic());

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is a letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyAlphabetic(params char?[] input) => input.Any(x => x.IsAlphabetic());

    /// <summary>
    /// Determines whether the specified nullable character has a value and is a punctuation mark.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool IsPunctuation([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsPunctuation();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are punctuation marks.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are punctuation marks; otherwise, <see langword="false"/>.</returns>
    public static bool AllPunctuation(this IEnumerable<char?> input) => !input.Any(x => x.IsNotPunctuation());

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are punctuation marks.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are punctuation marks; otherwise, <see langword="false"/>.</returns>
    public static bool AllPunctuation(params char?[] input) => !input.Any(x => x.IsNotPunctuation());

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is a punctuation mark.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPunctuation(this IEnumerable<char?> input) => input.Any(x => x.IsPunctuation());

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is a punctuation mark.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPunctuation(params char?[] input) => input.Any(x => x.IsPunctuation());

    /// <summary>
    /// Determines whether the specified nullable character has a value and is a decimal digit.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool IsNumber([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNumber();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are decimal digits.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are decimal digits; otherwise, <see langword="false"/>.</returns>
    public static bool AllNumber(this IEnumerable<char?> input) => !input.Any(x => x.IsNotNumber());

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are decimal digits.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are decimal digits; otherwise, <see langword="false"/>.</returns>
    public static bool AllNumber(params char?[] input) => !input.Any(x => x.IsNotNumber());

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is a decimal digit.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNumber(this IEnumerable<char?> input) => input.Any(x => x.IsNumber());

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is a decimal digit.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNumber(params char?[] input) => input.Any(x => x.IsNumber());

    /// <summary>
    /// Determines whether a character and a nullable character are equal, ignoring case.
    /// </summary>
    /// <param name="input1">The character to compare.</param>
    /// <param name="input2">The nullable character to compare.</param>
    /// <returns><see langword="true"/> if the characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this char input1, char? input2) => input1.LowerInvariant() == input2.LowerInvariant();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllEqualsIgnoreCase(this IEnumerable<char?> input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    /// <summary>
    /// Determines whether all nullable characters in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllEqualsIgnoreCase(params char?[] input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    /// <summary>
    /// Determines whether any nullable characters in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if any characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEqualsIgnoreCase(this IEnumerable<char?> input) => !input.AllNotEqualsIgnoreCase();

    /// <summary>
    /// Determines whether any nullable characters in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if any characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEqualsIgnoreCase(params char?[] input) => !input.AllNotEqualsIgnoreCase();

    /// <summary>
    /// Determines whether the specified nullable character has a value and is not empty.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is not empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullEmpty([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNotEmpty();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are not empty.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are not empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNullEmpty(this IEnumerable<char?> input) => !input.Any(x => x.IsNullEmpty());

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are not empty.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are not empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNullEmpty(params char?[] input) => !input.Any(x => x.IsNullEmpty());

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is not empty.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is not empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNullEmpty(this IEnumerable<char?> input) => input.Any(x => x.IsNotNullEmpty());

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is not empty.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is not empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNullEmpty(params char?[] input) => input.Any(x => x.IsNotNullEmpty());

    /// <summary>
    /// Determines whether the specified nullable character has a value, is not empty, and is not a white-space character.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value, is not empty, and is not a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNullWhiteSpace([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNotEmpty() && input.Value.IsNotWhiteSpace();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values, are not empty, and are not white-space characters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values, are not empty, and are not white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNullWhiteSpace(this IEnumerable<char?> input) => !input.Any(x => x.IsNullWhiteSpace());

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values, are not empty, and are not white-space characters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values, are not empty, and are not white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNullWhiteSpace(params char?[] input) => !input.Any(x => x.IsNullWhiteSpace());

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value, is not empty, and is not a white-space character.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value, is not empty, and is not a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNullWhiteSpace(this IEnumerable<char?> input) => input.Any(x => x.IsNotNullWhiteSpace());

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value, is not empty, and is not a white-space character.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value, is not empty, and is not a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNullWhiteSpace(params char?[] input) => input.Any(x => x.IsNotNullWhiteSpace());

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or not a letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or not a letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotAlphabetic(this char? input) => !input.HasValue || input.Value.IsNotAlphabetic();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or not letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotAlphabetic(this IEnumerable<char?> input) => !input.Any(x => x.IsAlphabetic());

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or not letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotAlphabetic(params char?[] input) => !input.Any(x => x.IsAlphabetic());

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or not a letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotAlphabetic(this IEnumerable<char?> input) => input.Any(x => x.IsNotAlphabetic());

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or not a letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotAlphabetic(params char?[] input) => input.Any(x => x.IsNotAlphabetic());

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or not a punctuation mark.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or not a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotPunctuation(this char? input) => !input.HasValue || input.Value.IsNotPunctuation();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or not punctuation marks.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not punctuation marks; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotPunctuation(this IEnumerable<char?> input) => !input.Any(x => x.IsPunctuation());

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or not punctuation marks.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not punctuation marks; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotPunctuation(params char?[] input) => !input.Any(x => x.IsPunctuation());

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or not a punctuation mark.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotPunctuation(this IEnumerable<char?> input) => input.Any(x => x.IsNotPunctuation());

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or not a punctuation mark.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotPunctuation(params char?[] input) => input.Any(x => x.IsNotPunctuation());

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or not a decimal digit.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or not a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNumber(this char? input) => !input.HasValue || input.Value.IsNotNumber();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or not decimal digits.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not decimal digits; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNumber(this IEnumerable<char?> input) => !input.Any(x => x.IsNumber());

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or not decimal digits.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not decimal digits; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNumber(params char?[] input) => !input.Any(x => x.IsNumber());

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or not a decimal digit.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNumber(this IEnumerable<char?> input) => input.Any(x => x.IsNotNumber());

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or not a decimal digit.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNumber(params char?[] input) => input.Any(x => x.IsNotNumber());

    /// <summary>
    /// Determines whether two nullable characters are not equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first nullable character to compare.</param>
    /// <param name="input2">The second nullable character to compare.</param>
    /// <returns><see langword="true"/> if the characters are not equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this char? input1, char? input2) => input1.LowerInvariant() != input2.LowerInvariant();

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are different from each other, ignoring case.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are different from each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEqualsIgnoreCase(this IEnumerable<char?> input)
    {
        var set = new HashSet<char?>(input.Count());

        foreach (var c in input)
        {
            if (!set.Add(c.LowerInvariant()))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether all nullable characters in the specified array are different from each other, ignoring case.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are different from each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEqualsIgnoreCase(params char?[] input)
    {
        var set = new HashSet<char?>(input.Length);

        foreach (var c in input)
        {
            if (!set.Add(c.LowerInvariant()))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether any nullable characters in the specified collection are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not equal to another, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<char?> input) => !input.AllEqualsIgnoreCase();

    /// <summary>
    /// Determines whether any nullable characters in the specified array are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not equal to another, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEqualsIgnoreCase(params char?[] input) => !input.AllEqualsIgnoreCase();

    /// <summary>
    /// Converts the specified nullable character to lowercase.
    /// </summary>
    /// <param name="input">The nullable character to convert.</param>
    /// <returns>The lowercase equivalent of the specified character, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static char? Lower(this char? input) => input.IsNullEmpty() ? default(char?) : char.ToLower(input.Value);

    /// <summary>
    /// Converts all nullable characters in the specified list to lowercase.
    /// </summary>
    /// <param name="input">The list of nullable characters to convert.</param>
    public static void Lower(this List<char?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].Lower();
        }
    }

    /// <summary>
    /// Converts all nullable characters in the specified collection to lowercase.
    /// </summary>
    /// <param name="input">The collection of nullable characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char?>? Lowers(this IEnumerable<char?>? input) => input.IsNullEmpty() ? default : input.Select(x => x.Lower());

    /// <summary>
    /// Converts all nullable characters in the specified array to lowercase.
    /// </summary>
    /// <param name="input">The array of nullable characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char?>? Lowers(params char?[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.Lower());

    /// <summary>
    /// Converts the specified nullable character to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The nullable character to convert.</param>
    /// <returns>The lowercase equivalent of the specified character, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static char? LowerInvariant(this char? input) => input.IsNullEmpty() ? default(char?) : char.ToLowerInvariant(input.Value);

    /// <summary>
    /// Converts all nullable characters in the specified list to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list of nullable characters to convert.</param>
    public static void LowerInvariant(this List<char?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].LowerInvariant();
        }
    }

    /// <summary>
    /// Converts all nullable characters in the specified collection to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection of nullable characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char?>? LowerInvariants(this IEnumerable<char?>? input) => input.IsNullEmpty() ? default : input.Select(x => x.LowerInvariant());

    /// <summary>
    /// Converts all nullable characters in the specified array to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array of nullable characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char?>? LowerInvariants(params char?[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.LowerInvariant());

    /// <summary>
    /// Converts the specified nullable character to uppercase.
    /// </summary>
    /// <param name="input">The nullable character to convert.</param>
    /// <returns>The uppercase equivalent of the specified character, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static char? Upper(this char? input) => input.IsNullEmpty() ? default(char?) : char.ToUpper(input.Value);

    /// <summary>
    /// Converts all nullable characters in the specified list to uppercase.
    /// </summary>
    /// <param name="input">The list of nullable characters to convert.</param>
    public static void Upper(this List<char?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].Upper();
        }
    }

    /// <summary>
    /// Converts all nullable characters in the specified collection to uppercase.
    /// </summary>
    /// <param name="input">The collection of nullable characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char?>? Uppers(this IEnumerable<char?>? input) => input.IsNullEmpty() ? default : input.Select(x => x.Upper());

    /// <summary>
    /// Converts all nullable characters in the specified array to uppercase.
    /// </summary>
    /// <param name="input">The array of nullable characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char?>? Uppers(params char?[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.Upper());

    /// <summary>
    /// Converts the specified nullable character to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The nullable character to convert.</param>
    /// <returns>The uppercase equivalent of the specified character, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static char? UpperInvariant(this char? input) => input.IsNullEmpty() ? default(char?) : char.ToUpperInvariant(input.Value);

    /// <summary>
    /// Converts all nullable characters in the specified list to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list of nullable characters to convert.</param>
    public static void UpperInvariant(this List<char?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        for (var i = 0; i < input.Count; i++)
        {
            input[i] = input[i].UpperInvariant();
        }
    }

    /// <summary>
    /// Converts all nullable characters in the specified collection to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection of nullable characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char?>? UpperInvariants(this IEnumerable<char?>? input) => input.IsNullEmpty() ? default : input.Select(x => x.UpperInvariant());

    /// <summary>
    /// Converts all nullable characters in the specified array to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array of nullable characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char?>? UpperInvariants(params char?[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.UpperInvariant());

    /// <summary>
    /// Determines whether the specified nullable character has a value and is a lowercase letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsLower(this char? input) => input.HasValue && char.IsLower(input.Value);

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are lowercase letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are lowercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllLowers(this IEnumerable<char?> input) => !input.Any(x => x.IsNotLower());

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are lowercase letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are lowercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllLowers(params char?[] input) => !input.Any(x => x.IsNotLower());

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is a lowercase letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyLowers(this IEnumerable<char?> input) => input.Any(x => x.IsLower());

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is a lowercase letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyLowers(params char?[] input) => input.Any(x => x.IsLower());

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or not a lowercase letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or not a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotLower(this char? input) => !input.HasValue || !char.IsLower(input.Value);

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or not lowercase letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not lowercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotLowers(this IEnumerable<char?> input) => !input.Any(x => x.IsLower());

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or not lowercase letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not lowercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotLowers(params char?[] input) => !input.Any(x => x.IsLower());

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or not a lowercase letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotLowers(this IEnumerable<char?> input) => input.Any(x => x.IsNotLower());

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or not a lowercase letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotLowers(params char?[] input) => input.Any(x => x.IsNotLower());

    /// <summary>
    /// Determines whether the specified nullable character has a value and is an uppercase letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character has a value and is an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsUpper(this char? input) => input.HasValue && char.IsUpper(input.Value);

    /// <summary>
    /// Determines whether all nullable characters in the specified collection have values and are uppercase letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are uppercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllUppers(this IEnumerable<char?> input) => !input.Any(x => x.IsNotUpper());

    /// <summary>
    /// Determines whether all nullable characters in the specified array have values and are uppercase letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters have values and are uppercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllUppers(params char?[] input) => !input.Any(x => x.IsNotUpper());

    /// <summary>
    /// Determines whether any nullable character in the specified collection has a value and is an uppercase letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyUppers(this IEnumerable<char?> input) => input.Any(x => x.IsUpper());

    /// <summary>
    /// Determines whether any nullable character in the specified array has a value and is an uppercase letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character has a value and is an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyUppers(params char?[] input) => input.Any(x => x.IsUpper());

    /// <summary>
    /// Determines whether the specified nullable character is <see langword="null"/> or not an uppercase letter.
    /// </summary>
    /// <param name="input">The nullable character to check.</param>
    /// <returns><see langword="true"/> if the character is <see langword="null"/> or not an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotUpper(this char? input) => !input.HasValue || !char.IsUpper(input.Value);

    /// <summary>
    /// Determines whether all nullable characters in the specified collection are <see langword="null"/> or not uppercase letters.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not uppercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotUppers(this IEnumerable<char?> input) => !input.Any(x => x.IsUpper());

    /// <summary>
    /// Determines whether all nullable characters in the specified array are <see langword="null"/> or not uppercase letters.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if all characters are <see langword="null"/> or not uppercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotUppers(params char?[] input) => !input.Any(x => x.IsUpper());

    /// <summary>
    /// Determines whether any nullable character in the specified collection is <see langword="null"/> or not an uppercase letter.
    /// </summary>
    /// <param name="input">The collection of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotUppers(this IEnumerable<char?> input) => input.Any(x => x.IsNotUpper());

    /// <summary>
    /// Determines whether any nullable character in the specified array is <see langword="null"/> or not an uppercase letter.
    /// </summary>
    /// <param name="input">The array of nullable characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is <see langword="null"/> or not an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotUppers(params char?[] input) => input.Any(x => x.IsNotUpper());
}
