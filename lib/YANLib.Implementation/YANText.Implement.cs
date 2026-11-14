using System.Buffers;
using System.Diagnostics;
using System.Text;
using static System.Globalization.CultureInfo;

namespace YANLib.Implementation;

internal static partial class YANText
{
    #region Private

    // Filter and CleanSpace build inputs up to this length on the stack, longer ones in a pooled array.
    private const int STACKALLOC_CHAR_THRESHOLD = 256;

    // FormatName reuses one StringBuilder per thread (like the BCL's internal StringBuilderCache): with its culture-aware
    // casing calls this measured faster than a stackalloc or pooled buffer. A builder that grew past this capacity is not kept.
    private const int MAX_CACHED_BUILDER_CAPACITY = 1024;

    [ThreadStatic]
    private static StringBuilder? CachedFormatNameBuilder;

    private interface ICharFilter
    {
        static abstract bool Keep(char c);
    }

    private readonly struct AlphabeticFilter : ICharFilter
    {
        public static bool Keep(char c) => c.IsAlphabeticImplement();
    }

    private readonly struct NumberFilter : ICharFilter
    {
        public static bool Keep(char c) => c.IsNumberImplement();
    }

    private readonly struct AlphanumericFilter : ICharFilter
    {
        public static bool Keep(char c) => c.IsAlphanumericImplement();
    }

    // Copies the characters of input that TFilter keeps (a struct type argument, so the check is inlined). Returns input
    // itself when every character is kept.
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static string Filter<TFilter>(string input) where TFilter : struct, ICharFilter
    {
        char[]? rented = null;
        Span<char> buffer = input.Length <= STACKALLOC_CHAR_THRESHOLD ? stackalloc char[input.Length] : rented = ArrayPool<char>.Shared.Rent(input.Length);

        try
        {
            var count = 0;

            foreach (var c in input)
            {
                if (TFilter.Keep(c))
                {
                    buffer[count++] = c;
                }
            }

            return count == input.Length ? input : new string(buffer[..count]);
        }
        finally
        {
            if (rented is not null)
            {
                ArrayPool<char>.Shared.Return(rented);
            }
        }
    }

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? TitleImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : CurrentCulture.TextInfo.ToTitleCase(input.LowerImplement()!);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? CapitalizeImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : string.Create(input.Length, input, static (output, source) =>
    {
        var isFirstChar = true;

        for (var i = 0; i < source.Length; i++)
        {
            if (isFirstChar && source[i].IsAlphabeticImplement())
            {
                output[i] = source[i].UpperImplement();
                isFirstChar = false;
            }
            else
            {
                output[i] = source[i].LowerImplement();
            }
        }
    });

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? CleanSpaceImplement(this string? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return input;
        }

        var trimmed = input.AsSpan().Trim();

        if (trimmed.IsEmpty)
        {
            return string.Empty;
        }

        char[]? rented = null;
        Span<char> buffer = trimmed.Length <= STACKALLOC_CHAR_THRESHOLD ? stackalloc char[trimmed.Length] : rented = ArrayPool<char>.Shared.Rent(trimmed.Length);

        try
        {
            var count = 0;
            var isWhiteSpace = false;

            foreach (var c in trimmed)
            {
                if (c.IsWhiteSpaceImplement())
                {
                    if (!isWhiteSpace)
                    {
                        buffer[count++] = ' ';
                        isWhiteSpace = true;
                    }
                }
                else
                {
                    buffer[count++] = c;
                    isWhiteSpace = false;
                }
            }

            var result = buffer[..count];

            return result.SequenceEqual(input) ? input : new string(result);
        }
        finally
        {
            if (rented is not null)
            {
                ArrayPool<char>.Shared.Return(rented);
            }
        }
    }

    // Words are separated by any run of white-space and punctuation characters and joined with a single space; digits are
    // dropped without ending a word. The first character kept in each word is upper-cased and the others lower-cased (current
    // culture), so a word that starts with a symbol keeps its letters in lower case ("$john"). There is no leading or trailing space.
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? FormatNameImplement(this string? input)
    {
        if (input.IsNullWhiteSpaceImplement())
        {
            return input;
        }

        var builder = CachedFormatNameBuilder ?? new StringBuilder(input.Length);

        CachedFormatNameBuilder = null;
        _ = builder.Clear();

        var isWordStart = true;
        var isSeparatorPending = false;

        foreach (var c in input)
        {
            if (c.IsPunctuationImplement() || c.IsWhiteSpaceImplement())
            {
                isWordStart = true;
                isSeparatorPending = builder.Length > 0;

                continue;
            }

            if (c.IsNumberImplement())
            {
                continue;
            }

            if (isSeparatorPending)
            {
                _ = builder.Append(' ');
                isSeparatorPending = false;
            }

            _ = builder.Append(isWordStart ? c.UpperImplement() : c.LowerImplement());
            isWordStart = false;
        }

        var result = builder.ToString();

        if (builder.Capacity <= MAX_CACHED_BUILDER_CAPACITY)
        {
            CachedFormatNameBuilder = builder;
        }

        return result;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? FilterAlphabeticImplement(this string? input) => input.IsNullEmptyImplement() ? input : Filter<AlphabeticFilter>(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? FilterNumberImplement(this string? input) => input.IsNullEmptyImplement() ? input : Filter<NumberFilter>(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? FilterAlphanumericImplement(this string? input) => input.IsNullEmptyImplement() ? input : Filter<AlphanumericFilter>(input);
}
