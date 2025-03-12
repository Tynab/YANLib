using YANLib.Object;
using static System.Linq.Enumerable;

namespace YANLib.Text;

public static partial class YANText
{
    /// <summary>
    /// Determines whether the specified character is empty (has the default value of <see cref="char.MinValue"/>).
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmpty(this char input) => input is char.MinValue;

    /// <summary>
    /// Determines whether all characters in the specified collection are empty.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllEmpty(this IEnumerable<char> input) => !input.Any(x => x.IsNotEmpty());

    /// <summary>
    /// Determines whether all characters in the specified array are empty.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllEmpty(params char[] input) => !input.Any(x => x.IsNotEmpty());

    /// <summary>
    /// Determines whether any character in the specified collection is empty.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEmpty(this IEnumerable<char> input) => input.Any(x => x.IsEmpty());

    /// <summary>
    /// Determines whether any character in the specified array is empty.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEmpty(params char[] input) => input.Any(x => x.IsEmpty());

    /// <summary>
    /// Determines whether the specified character is a white-space character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsWhiteSpace(this char input) => char.IsWhiteSpace(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are white-space characters.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllWhiteSpace(this IEnumerable<char> input) => !input.Any(x => x.IsNotWhiteSpace());

    /// <summary>
    /// Determines whether all characters in the specified array are white-space characters.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllWhiteSpace(params char[] input) => !input.Any(x => x.IsNotWhiteSpace());

    /// <summary>
    /// Determines whether any character in the specified collection is a white-space character.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyWhiteSpace(this IEnumerable<char> input) => input.Any(x => x.IsWhiteSpace());

    /// <summary>
    /// Determines whether any character in the specified array is a white-space character.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyWhiteSpace(params char[] input) => input.Any(x => x.IsWhiteSpace());

    /// <summary>
    /// Determines whether the specified character is empty or a white-space character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is empty or a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsWhiteSpaceEmpty(this char input) => input.IsEmpty() || input.IsWhiteSpace();

    /// <summary>
    /// Determines whether all characters in the specified collection are empty or white-space characters.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are empty or white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllWhiteSpaceEmpty(this IEnumerable<char> input) => !input.Any(x => x.IsNotWhiteSpaceEmpty());

    /// <summary>
    /// Determines whether all characters in the specified array are empty or white-space characters.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are empty or white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllWhiteSpaceEmpty(params char[] input) => !input.Any(x => x.IsNotWhiteSpaceEmpty());

    /// <summary>
    /// Determines whether any character in the specified collection is empty or a white-space character.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is empty or a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyWhiteSpaceEmpty(this IEnumerable<char> input) => input.Any(x => x.IsWhiteSpaceEmpty());

    /// <summary>
    /// Determines whether any character in the specified array is empty or a white-space character.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is empty or a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyWhiteSpaceEmpty(params char[] input) => input.Any(x => x.IsWhiteSpaceEmpty());

    /// <summary>
    /// Determines whether the specified character is a letter.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is a letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsAlphabetic(this char input) => char.IsLetter(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are letters.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllAlphabetic(this IEnumerable<char> input) => !input.Any(x => x.IsNotAlphabetic());

    /// <summary>
    /// Determines whether all characters in the specified array are letters.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllAlphabetic(params char[] input) => !input.Any(x => x.IsNotAlphabetic());

    /// <summary>
    /// Determines whether any character in the specified collection is a letter.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is a letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyAlphabetic(this IEnumerable<char> input) => input.Any(x => x.IsAlphabetic());

    /// <summary>
    /// Determines whether any character in the specified array is a letter.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is a letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyAlphabetic(params char[] input) => input.Any(x => x.IsAlphabetic());

    /// <summary>
    /// Determines whether the specified character is a punctuation mark.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool IsPunctuation(this char input) => char.IsPunctuation(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are punctuation marks.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are punctuation marks; otherwise, <see langword="false"/>.</returns>
    public static bool AllPunctuation(this IEnumerable<char> input) => !input.Any(x => x.IsNotPunctuation());

    /// <summary>
    /// Determines whether all characters in the specified array are punctuation marks.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are punctuation marks; otherwise, <see langword="false"/>.</returns>
    public static bool AllPunctuation(params char[] input) => !input.Any(x => x.IsNotPunctuation());

    /// <summary>
    /// Determines whether any character in the specified collection is a punctuation mark.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPunctuation(this IEnumerable<char> input) => input.Any(x => x.IsPunctuation());

    /// <summary>
    /// Determines whether any character in the specified array is a punctuation mark.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool AnyPunctuation(params char[] input) => input.Any(x => x.IsPunctuation());

    /// <summary>
    /// Determines whether the specified character is a decimal digit.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool IsNumber(this char input) => char.IsDigit(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are decimal digits.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are decimal digits; otherwise, <see langword="false"/>.</returns>
    public static bool AllNumber(this IEnumerable<char> input) => !input.Any(x => x.IsNotNumber());

    /// <summary>
    /// Determines whether all characters in the specified array are decimal digits.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are decimal digits; otherwise, <see langword="false"/>.</returns>
    public static bool AllNumber(params char[] input) => !input.Any(x => x.IsNotNumber());

    /// <summary>
    /// Determines whether any character in the specified collection is a decimal digit.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNumber(this IEnumerable<char> input) => input.Any(x => x.IsNumber());

    /// <summary>
    /// Determines whether any character in the specified array is a decimal digit.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNumber(params char[] input) => input.Any(x => x.IsNumber());

    /// <summary>
    /// Determines whether two characters are equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first character to compare.</param>
    /// <param name="input2">The second character to compare.</param>
    /// <returns><see langword="true"/> if the characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool EqualsIgnoreCase(this char input1, char input2) => input1.LowerInvariant() == input2.LowerInvariant();

    /// <summary>
    /// Determines whether all characters in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllEqualsIgnoreCase(this IEnumerable<char> input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    /// <summary>
    /// Determines whether all characters in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllEqualsIgnoreCase(params char[] input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    /// <summary>
    /// Determines whether any characters in the specified collection are equal, ignoring case.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if any characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEqualsIgnoreCase(this IEnumerable<char> input) => !input.AllNotEqualsIgnoreCase();

    /// <summary>
    /// Determines whether any characters in the specified array are equal, ignoring case.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if any characters are equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEqualsIgnoreCase(params char[] input) => !input.AllNotEqualsIgnoreCase();

    /// <summary>
    /// Determines whether the specified character is not empty (not the default value of <see cref="char.MinValue"/>).
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmpty(this char input) => input is not char.MinValue;

    /// <summary>
    /// Determines whether all characters in the specified collection are not empty.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEmpty(this IEnumerable<char> input) => !input.Any(x => x.IsEmpty());

    /// <summary>
    /// Determines whether all characters in the specified array are not empty.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not empty; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEmpty(params char[] input) => !input.Any(x => x.IsEmpty());

    /// <summary>
    /// Determines whether any character in the specified collection is not empty.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEmpty(this IEnumerable<char> input) => input.Any(x => x.IsNotEmpty());

    /// <summary>
    /// Determines whether any character in the specified array is not empty.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not empty; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEmpty(params char[] input) => input.Any(x => x.IsNotEmpty());

    /// <summary>
    /// Determines whether the specified character is not a white-space character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotWhiteSpace(this char input) => !char.IsWhiteSpace(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are not white-space characters.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotWhiteSpace(this IEnumerable<char> input) => !input.Any(x => x.IsWhiteSpace());

    /// <summary>
    /// Determines whether all characters in the specified array are not white-space characters.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotWhiteSpace(params char[] input) => !input.Any(x => x.IsWhiteSpace());

    /// <summary>
    /// Determines whether any character in the specified collection is not a white-space character.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotWhiteSpace(this IEnumerable<char> input) => input.Any(x => x.IsNotWhiteSpace());

    /// <summary>
    /// Determines whether any character in the specified array is not a white-space character.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotWhiteSpace(params char[] input) => input.Any(x => x.IsNotWhiteSpace());

    /// <summary>
    /// Determines whether the specified character is neither empty nor a white-space character.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is neither empty nor a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotWhiteSpaceEmpty(this char input) => input.IsNotEmpty() && input.IsNotWhiteSpace();

    /// <summary>
    /// Determines whether all characters in the specified collection are neither empty nor white-space characters.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are neither empty nor white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotWhiteSpaceEmpty(this IEnumerable<char> input) => !input.Any(x => x.IsWhiteSpaceEmpty());

    /// <summary>
    /// Determines whether all characters in the specified array are neither empty nor white-space characters.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are neither empty nor white-space characters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotWhiteSpaceEmpty(params char[] input) => !input.Any(x => x.IsWhiteSpaceEmpty());

    /// <summary>
    /// Determines whether any character in the specified collection is neither empty nor a white-space character.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is neither empty nor a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotWhiteSpaceEmpty(this IEnumerable<char> input) => input.Any(x => x.IsNotWhiteSpaceEmpty());

    /// <summary>
    /// Determines whether any character in the specified array is neither empty nor a white-space character.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is neither empty nor a white-space character; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotWhiteSpaceEmpty(params char[] input) => input.Any(x => x.IsNotWhiteSpaceEmpty());

    /// <summary>
    /// Determines whether the specified character is not a letter.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not a letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotAlphabetic(this char input) => !char.IsLetter(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are not letters.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotAlphabetic(this IEnumerable<char> input) => !input.Any(x => x.IsAlphabetic());

    /// <summary>
    /// Determines whether all characters in the specified array are not letters.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotAlphabetic(params char[] input) => !input.Any(x => x.IsAlphabetic());

    /// <summary>
    /// Determines whether any character in the specified collection is not a letter.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not a letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotAlphabetic(this IEnumerable<char> input) => input.Any(x => x.IsNotAlphabetic());

    /// <summary>
    /// Determines whether any character in the specified array is not a letter.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not a letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotAlphabetic(params char[] input) => input.Any(x => x.IsNotAlphabetic());

    /// <summary>
    /// Determines whether the specified character is not a punctuation mark.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotPunctuation(this char input) => !char.IsPunctuation(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are not punctuation marks.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not punctuation marks; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotPunctuation(this IEnumerable<char> input) => !input.Any(x => x.IsPunctuation());

    /// <summary>
    /// Determines whether all characters in the specified array are not punctuation marks.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not punctuation marks; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotPunctuation(params char[] input) => !input.Any(x => x.IsPunctuation());

    /// <summary>
    /// Determines whether any character in the specified collection is not a punctuation mark.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotPunctuation(this IEnumerable<char> input) => input.Any(x => x.IsNotPunctuation());

    /// <summary>
    /// Determines whether any character in the specified array is not a punctuation mark.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not a punctuation mark; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotPunctuation(params char[] input) => input.Any(x => x.IsNotPunctuation());

    /// <summary>
    /// Determines whether the specified character is not a decimal digit.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotNumber(this char input) => !char.IsDigit(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are not decimal digits.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not decimal digits; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNumber(this IEnumerable<char> input) => !input.Any(x => x.IsNumber());

    /// <summary>
    /// Determines whether all characters in the specified array are not decimal digits.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not decimal digits; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotNumber(params char[] input) => !input.Any(x => x.IsNumber());

    /// <summary>
    /// Determines whether any character in the specified collection is not a decimal digit.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNumber(this IEnumerable<char> input) => input.Any(x => x.IsNotNumber());

    /// <summary>
    /// Determines whether any character in the specified array is not a decimal digit.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not a decimal digit; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotNumber(params char[] input) => input.Any(x => x.IsNotNumber());

    /// <summary>
    /// Determines whether two characters are not equal, ignoring case.
    /// </summary>
    /// <param name="input1">The first character to compare.</param>
    /// <param name="input2">The second character to compare.</param>
    /// <returns><see langword="true"/> if the characters are not equal, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool NotEqualsIgnoreCase(this char input1, char input2) => input1.LowerInvariant() != input2.LowerInvariant();

    /// <summary>
    /// Determines whether all characters in the specified collection are different from each other, ignoring case.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are different from each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEqualsIgnoreCase(this IEnumerable<char> input)
    {
        var set = new HashSet<char>(input.Count());

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
    /// Determines whether all characters in the specified array are different from each other, ignoring case.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are different from each other, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEqualsIgnoreCase(params char[] input)
    {
        var set = new HashSet<char>(input.Length);

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
    /// Determines whether any characters in the specified collection are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not equal to another, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<char> input) => !input.AllEqualsIgnoreCase();

    /// <summary>
    /// Determines whether any characters in the specified array are not equal to each other, ignoring case.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not equal to another, ignoring case; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEqualsIgnoreCase(params char[] input) => !input.AllEqualsIgnoreCase();

    /// <summary>
    /// Converts the specified character to lowercase.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The lowercase equivalent of the specified character, or the unchanged character if it is already lowercase or is not an uppercase letter.</returns>
    public static char Lower(this char input) => input.IsWhiteSpaceEmpty() ? input : char.ToLower(input);

    /// <summary>
    /// Converts all characters in the specified list to lowercase.
    /// </summary>
    /// <param name="input">The list of characters to convert.</param>
    public static void Lower(this List<char>? input)
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
    /// Converts all characters in the specified collection to lowercase.
    /// </summary>
    /// <param name="input">The collection of characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char>? Lowers(this IEnumerable<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.Lower());

    /// <summary>
    /// Converts all characters in the specified array to lowercase.
    /// </summary>
    /// <param name="input">The array of characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char>? Lowers(params char[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.Lower());

    /// <summary>
    /// Converts the specified character to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The lowercase equivalent of the specified character, or the unchanged character if it is already lowercase or is not an uppercase letter.</returns>
    public static char LowerInvariant(this char input) => input.IsWhiteSpaceEmpty() ? input : char.ToLowerInvariant(input);

    /// <summary>
    /// Converts all characters in the specified list to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list of characters to convert.</param>
    public static void LowerInvariant(this List<char>? input)
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
    /// Converts all characters in the specified collection to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection of characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char>? LowerInvariants(this IEnumerable<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.LowerInvariant());

    /// <summary>
    /// Converts all characters in the specified array to lowercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array of characters to convert.</param>
    /// <returns>A collection containing the lowercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char>? LowerInvariants(params char[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.LowerInvariant());

    /// <summary>
    /// Converts the specified character to uppercase.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The uppercase equivalent of the specified character, or the unchanged character if it is already uppercase or is not a lowercase letter.</returns>
    public static char Upper(this char input) => input.IsWhiteSpaceEmpty() ? input : char.ToUpper(input);

    /// <summary>
    /// Converts all characters in the specified list to uppercase.
    /// </summary>
    /// <param name="input">The list of characters to convert.</param>
    public static void Upper(this List<char>? input)
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
    /// Converts all characters in the specified collection to uppercase.
    /// </summary>
    /// <param name="input">The collection of characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char>? Uppers(this IEnumerable<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.Upper());

    /// <summary>
    /// Converts all characters in the specified array to uppercase.
    /// </summary>
    /// <param name="input">The array of characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char>? Uppers(params char[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.Upper());

    /// <summary>
    /// Converts the specified character to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The character to convert.</param>
    /// <returns>The uppercase equivalent of the specified character, or the unchanged character if it is already uppercase or is not a lowercase letter.</returns>
    public static char UpperInvariant(this char input) => input.IsWhiteSpaceEmpty() ? input : char.ToUpperInvariant(input);

    /// <summary>
    /// Converts all characters in the specified list to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The list of characters to convert.</param>
    public static void UpperInvariant(this List<char>? input)
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
    /// Converts all characters in the specified collection to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The collection of characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input collection, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char>? UpperInvariants(this IEnumerable<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.UpperInvariant());

    /// <summary>
    /// Converts all characters in the specified array to uppercase using the invariant culture.
    /// </summary>
    /// <param name="input">The array of characters to convert.</param>
    /// <returns>A collection containing the uppercase equivalent of each character in the input array, or <see langword="null"/> if the input is <see langword="null"/> or empty.</returns>
    public static IEnumerable<char>? UpperInvariants(params char[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.UpperInvariant());

    /// <summary>
    /// Determines whether the specified character is a lowercase letter.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsLower(this char input) => input.IsNotWhiteSpaceEmpty() && char.IsLower(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are lowercase letters.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are lowercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllLowers(this IEnumerable<char> input) => !input.Any(x => x.IsNotLower());

    /// <summary>
    /// Determines whether all characters in the specified array are lowercase letters.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are lowercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllLowers(params char[] input) => !input.Any(x => x.IsNotLower());

    /// <summary>
    /// Determines whether any character in the specified collection is a lowercase letter.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyLowers(this IEnumerable<char> input) => input.Any(x => x.IsLower());

    /// <summary>
    /// Determines whether any character in the specified array is a lowercase letter.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyLowers(params char[] input) => input.Any(x => x.IsLower());

    /// <summary>
    /// Determines whether the specified character is not a lowercase letter.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotLower(this char input) => input.IsNotWhiteSpaceEmpty() && !char.IsLower(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are not lowercase letters.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not lowercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotLowers(this IEnumerable<char> input) => !input.Any(x => x.IsLower());

    /// <summary>
    /// Determines whether all characters in the specified array are not lowercase letters.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not lowercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotLowers(params char[] input) => !input.Any(x => x.IsLower());

    /// <summary>
    /// Determines whether any character in the specified collection is not a lowercase letter.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotLowers(this IEnumerable<char> input) => input.Any(x => x.IsNotLower());

    /// <summary>
    /// Determines whether any character in the specified array is not a lowercase letter.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not a lowercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotLowers(params char[] input) => input.Any(x => x.IsNotLower());

    /// <summary>
    /// Determines whether the specified character is an uppercase letter.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsUpper(this char input) => input.IsNotWhiteSpaceEmpty() && char.IsUpper(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are uppercase letters.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are uppercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllUppers(this IEnumerable<char> input) => !input.Any(x => x.IsNotUpper());

    /// <summary>
    /// Determines whether all characters in the specified array are uppercase letters.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are uppercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllUppers(params char[] input) => !input.Any(x => x.IsNotUpper());

    /// <summary>
    /// Determines whether any character in the specified collection is an uppercase letter.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyUppers(this IEnumerable<char> input) => input.Any(x => x.IsUpper());

    /// <summary>
    /// Determines whether any character in the specified array is an uppercase letter.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyUppers(params char[] input) => input.Any(x => x.IsUpper());

    /// <summary>
    /// Determines whether the specified character is not an uppercase letter.
    /// </summary>
    /// <param name="input">The character to check.</param>
    /// <returns><see langword="true"/> if the character is not an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotUpper(this char input) => input.IsNotWhiteSpaceEmpty() && !char.IsUpper(input);

    /// <summary>
    /// Determines whether all characters in the specified collection are not uppercase letters.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not uppercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotUppers(this IEnumerable<char> input) => !input.Any(x => x.IsUpper());

    /// <summary>
    /// Determines whether all characters in the specified array are not uppercase letters.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if all characters are not uppercase letters; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotUppers(params char[] input) => !input.Any(x => x.IsUpper());

    /// <summary>
    /// Determines whether any character in the specified collection is not an uppercase letter.
    /// </summary>
    /// <param name="input">The collection of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotUppers(this IEnumerable<char> input) => input.Any(x => x.IsNotUpper());

    /// <summary>
    /// Determines whether any character in the specified array is not an uppercase letter.
    /// </summary>
    /// <param name="input">The array of characters to check.</param>
    /// <returns><see langword="true"/> if at least one character is not an uppercase letter; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotUppers(params char[] input) => input.Any(x => x.IsNotUpper());
}
