using System.Buffers;
using System.Globalization;
using System.Text;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation;

internal static partial class YANText
{
    #region Private

    // How a word-case style writes the words it found: the separator between words ('\0' for none) and whether the first
    // letter of a word (by its index, 0 for the first word) and the other letters are written in upper case.
    private interface IWordCase
    {
        static abstract char Separator { get; }

        static abstract bool UpperFirst(int wordIndex);

        static abstract bool UpperRest { get; }
    }

    private readonly struct CamelWordCase : IWordCase
    {
        public static char Separator => '\0';

        public static bool UpperFirst(int wordIndex) => wordIndex > 0;

        public static bool UpperRest => false;
    }

    private readonly struct PascalWordCase : IWordCase
    {
        public static char Separator => '\0';

        public static bool UpperFirst(int wordIndex) => true;

        public static bool UpperRest => false;
    }

    private readonly struct SnakeLowerWordCase : IWordCase
    {
        public static char Separator => '_';

        public static bool UpperFirst(int wordIndex) => false;

        public static bool UpperRest => false;
    }

    private readonly struct SnakeUpperWordCase : IWordCase
    {
        public static char Separator => '_';

        public static bool UpperFirst(int wordIndex) => true;

        public static bool UpperRest => true;
    }

    private readonly struct KebabLowerWordCase : IWordCase
    {
        public static char Separator => '-';

        public static bool UpperFirst(int wordIndex) => false;

        public static bool UpperRest => false;
    }

    private readonly struct KebabUpperWordCase : IWordCase
    {
        public static char Separator => '-';

        public static bool UpperFirst(int wordIndex) => true;

        public static bool UpperRest => true;
    }

    private enum WordCharKind
    {
        Separator,
        Upper,
        Lower,
        Digit,
        OtherLetter,
        Mark
    }

    // Letters and decimal digits form words; combining marks belong to the letter before them (decomposed text such as
    // "e" + U+0301 stays one word); everything else separates words and is dropped.
    private static WordCharKind GetWordCharKind(Rune rune) => Rune.GetUnicodeCategory(rune) switch
    {
        UnicodeCategory.UppercaseLetter or UnicodeCategory.TitlecaseLetter => WordCharKind.Upper,
        UnicodeCategory.LowercaseLetter => WordCharKind.Lower,
        UnicodeCategory.DecimalDigitNumber => WordCharKind.Digit,
        UnicodeCategory.ModifierLetter or UnicodeCategory.OtherLetter => WordCharKind.OtherLetter,
        UnicodeCategory.NonSpacingMark or UnicodeCategory.SpacingCombiningMark or UnicodeCategory.EnclosingMark => WordCharKind.Mark,
        _ => WordCharKind.Separator
    };

    // The kind of the next rune at or after index that is not a combining mark (Separator at the end of the input).
    private static WordCharKind GetNextWordCharKind(ReadOnlySpan<char> source, int index)
    {
        while (index < source.Length)
        {
            _ = Rune.DecodeFromUtf16(source[index..], out var rune, out var consumed);

            var kind = GetWordCharKind(rune);

            if (kind is not WordCharKind.Mark)
            {
                return kind;
            }

            index += consumed;
        }

        return WordCharKind.Separator;
    }

    // Splits input into words and writes them in the TCase style, with invariant-culture casing. A word starts after a
    // separator, at an upper-case letter whose last letter before it in the word is lower-case or uncased, digits in between
    // included ("helloWorld", "version2Update"), and at the last upper-case letter of a run that is followed by a lower-case
    // letter ("HTTPServer" -> HTTP|Server, "HTML5Parser" -> HTML5|Parser). Digits belong to the word before them, so an
    // upper-case word with digits stays one word ("FOO123BAR", "BASE64URL") and an upper-case style can be converted again.
    // Returns input itself when the result is equal to it, and an empty string when input has no letter or digit.
    private static string? ConvertWordCase<TCase>(string? input) where TCase : struct, IWordCase
    {
        if (input.IsNullWhiteSpaceImplement())
        {
            return input;
        }

        var source = input.AsSpan();

        // Each input char gives at most one rune of at most two chars, plus at most one separator.
        var capacity = (int)Math.Min(source.Length * 3L, Array.MaxLength);
        char[]? rented = null;
        Span<char> buffer = capacity <= STACKALLOC_CHAR_THRESHOLD ? stackalloc char[capacity] : rented = ArrayPool<char>.Shared.Rent(capacity);

        try
        {
            var count = 0;
            var wordIndex = -1;
            var positionInWord = 0;
            var inWord = false;

            // The kind of the last letter of the current word (digits do not change it); Upper for a word that starts with
            // digits, so an upper-case letter after them starts a new word only before a lower-case letter ("123Abc").
            var previousLetter = WordCharKind.Upper;
            var index = 0;

            while (index < source.Length)
            {
                _ = Rune.DecodeFromUtf16(source[index..], out var rune, out var consumed);

                var kind = GetWordCharKind(rune);

                if (kind is WordCharKind.Separator)
                {
                    inWord = false;
                }
                else if (kind is WordCharKind.Mark)
                {
                    // A mark keeps its place in the current word; a mark with no letter before it is dropped.
                    if (inWord)
                    {
                        count += rune.EncodeToUtf16(buffer[count..]);
                    }
                }
                else
                {
                    var startsWord = !inWord
                        || kind is WordCharKind.Upper
                        && (previousLetter is WordCharKind.Lower or WordCharKind.OtherLetter
                            || previousLetter is WordCharKind.Upper && GetNextWordCharKind(source, index + consumed) is WordCharKind.Lower);

                    if (startsWord)
                    {
                        wordIndex++;

                        if (wordIndex > 0 && TCase.Separator is not '\0')
                        {
                            buffer[count++] = TCase.Separator;
                        }

                        positionInWord = 0;
                        inWord = true;
                        previousLetter = WordCharKind.Upper;
                    }

                    var upper = positionInWord is 0 ? TCase.UpperFirst(wordIndex) : TCase.UpperRest;

                    count += (upper ? Rune.ToUpperInvariant(rune) : Rune.ToLowerInvariant(rune)).EncodeToUtf16(buffer[count..]);
                    positionInWord++;

                    if (kind is not WordCharKind.Digit)
                    {
                        previousLetter = kind;
                    }
                }

                index += consumed;
            }

            var result = buffer[..count];

            return result.SequenceEqual(source) ? input : new string(result);
        }
        finally
        {
            if (rented is not null)
            {
                ArrayPool<char>.Shared.Return(rented);
            }
        }
    }

    private static void ConvertWordCase<TCase>(List<string?>? input) where TCase : struct, IWordCase
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = ConvertWordCase<TCase>(input[i]);
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = ConvertWordCase<TCase>(input[i]));
        }
    }

    private static IEnumerable<string?>? ConvertWordCases<TCase>(IEnumerable<string?>? input) where TCase : struct, IWordCase
        => input.IsNullEmptyImplement() ? input : input.Select(static x => ConvertWordCase<TCase>(x));

    #endregion

    internal static string? CamelCaseImplement(this string? input) => ConvertWordCase<CamelWordCase>(input);

    internal static void CamelCaseImplement(this List<string?>? input) => ConvertWordCase<CamelWordCase>(input);

    internal static IEnumerable<string?>? CamelCasesImplement(this IEnumerable<string?>? input) => ConvertWordCases<CamelWordCase>(input);

    internal static string? PascalCaseImplement(this string? input) => ConvertWordCase<PascalWordCase>(input);

    internal static void PascalCaseImplement(this List<string?>? input) => ConvertWordCase<PascalWordCase>(input);

    internal static IEnumerable<string?>? PascalCasesImplement(this IEnumerable<string?>? input) => ConvertWordCases<PascalWordCase>(input);

    internal static string? SnakeLowerCaseImplement(this string? input) => ConvertWordCase<SnakeLowerWordCase>(input);

    internal static void SnakeLowerCaseImplement(this List<string?>? input) => ConvertWordCase<SnakeLowerWordCase>(input);

    internal static IEnumerable<string?>? SnakeLowerCasesImplement(this IEnumerable<string?>? input) => ConvertWordCases<SnakeLowerWordCase>(input);

    internal static string? SnakeUpperCaseImplement(this string? input) => ConvertWordCase<SnakeUpperWordCase>(input);

    internal static void SnakeUpperCaseImplement(this List<string?>? input) => ConvertWordCase<SnakeUpperWordCase>(input);

    internal static IEnumerable<string?>? SnakeUpperCasesImplement(this IEnumerable<string?>? input) => ConvertWordCases<SnakeUpperWordCase>(input);

    internal static string? KebabLowerCaseImplement(this string? input) => ConvertWordCase<KebabLowerWordCase>(input);

    internal static void KebabLowerCaseImplement(this List<string?>? input) => ConvertWordCase<KebabLowerWordCase>(input);

    internal static IEnumerable<string?>? KebabLowerCasesImplement(this IEnumerable<string?>? input) => ConvertWordCases<KebabLowerWordCase>(input);

    internal static string? KebabUpperCaseImplement(this string? input) => ConvertWordCase<KebabUpperWordCase>(input);

    internal static void KebabUpperCaseImplement(this List<string?>? input) => ConvertWordCase<KebabUpperWordCase>(input);

    internal static IEnumerable<string?>? KebabUpperCasesImplement(this IEnumerable<string?>? input) => ConvertWordCases<KebabUpperWordCase>(input);
}
