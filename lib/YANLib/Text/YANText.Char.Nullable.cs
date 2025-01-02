using System.Diagnostics.CodeAnalysis;
using YANLib.Object;
using YANLib.Text;

namespace YANLib.Text;

public static partial class YANText
{
    public static bool IsNullOEmpty([NotNullWhen(false)] this char? input) => !input.HasValue || input.Value.IsEmpty();

    public static bool AllNullOEmpty(this IEnumerable<char?> input) => !input.Any(x => x.IsNotNullNEmpty());

    public static bool AllNullOEmpty(this ICollection<char?> input) => !input.Any(x => x.IsNotNullNEmpty());

    public static bool AllNullOEmpty(params char?[] input) => !input.Any(x => x.IsNotNullNEmpty());

    public static bool AnyNullOEmpty(this IEnumerable<char?> input) => input.Any(x => x.IsNullOEmpty());

    public static bool AnyNullOEmpty(this ICollection<char?> input) => input.Any(x => x.IsNullOEmpty());

    public static bool AnyNullOEmpty(params char?[] input) => input.Any(x => x.IsNullOEmpty());

    public static bool IsNullOWhiteSpace([NotNullWhen(false)] this char? input) => !input.HasValue || input.Value.IsEmpty() || input.Value.IsWhiteSpace();

    public static bool AllNullOWhiteSpace(this IEnumerable<char?> input) => !input.Any(x => x.IsNotNullNWhiteSpace());

    public static bool AllNullOWhiteSpace(this ICollection<char?> input) => !input.Any(x => x.IsNotNullNWhiteSpace());

    public static bool AllNullOWhiteSpace(params char?[] input) => !input.Any(x => x.IsNotNullNWhiteSpace());

    public static bool AnyNullOWhiteSpace(this IEnumerable<char?> input) => input.Any(x => x.IsNullOWhiteSpace());

    public static bool AnyNullOWhiteSpace(this ICollection<char?> input) => input.Any(x => x.IsNullOWhiteSpace());

    public static bool AnyNullOWhiteSpace(params char?[] input) => input.Any(x => x.IsNullOWhiteSpace());

    public static bool IsAlphabetic([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsAlphabetic();

    public static bool AllAlphabetic(this IEnumerable<char?> input) => !input.Any(x => x.IsNotAlphabetic());

    public static bool AllAlphabetic(this ICollection<char?> input) => !input.Any(x => x.IsNotAlphabetic());

    public static bool AllAlphabetic(params char?[] input) => !input.Any(x => x.IsNotAlphabetic());

    public static bool AnyAlphabetic(this IEnumerable<char?> input) => input.Any(x => x.IsAlphabetic());

    public static bool AnyAlphabetic(this ICollection<char?> input) => input.Any(x => x.IsAlphabetic());

    public static bool AnyAlphabetic(params char?[] input) => input.Any(x => x.IsAlphabetic());

    public static bool IsPunctuation([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsPunctuation();

    public static bool AllPunctuation(this IEnumerable<char?> input) => !input.Any(x => x.IsNotPunctuation());

    public static bool AllPunctuation(this ICollection<char?> input) => !input.Any(x => x.IsNotPunctuation());

    public static bool AllPunctuation(params char?[] input) => !input.Any(x => x.IsNotPunctuation());

    public static bool AnyPunctuation(this IEnumerable<char?> input) => input.Any(x => x.IsPunctuation());

    public static bool AnyPunctuation(this ICollection<char?> input) => input.Any(x => x.IsPunctuation());

    public static bool AnyPunctuation(params char?[] input) => input.Any(x => x.IsPunctuation());

    public static bool IsNumber([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNumber();

    public static bool AllNumber(this IEnumerable<char?> input) => !input.Any(x => x.IsNotNumber());

    public static bool AllNumber(this ICollection<char?> input) => !input.Any(x => x.IsNotNumber());

    public static bool AllNumber(params char?[] input) => !input.Any(x => x.IsNotNumber());

    public static bool AnyNumber(this IEnumerable<char?> input) => input.Any(x => x.IsNumber());

    public static bool AnyNumber(this ICollection<char?> input) => input.Any(x => x.IsNumber());

    public static bool AnyNumber(params char?[] input) => input.Any(x => x.IsNumber());

    public static bool EqualsIgnoreCase(this char input1, char? input2) => input1.LowerInvariant() == input2.LowerInvariant();

    public static bool AllEqualsIgnoreCase(this IEnumerable<char?> input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    public static bool AllEqualsIgnoreCase(this ICollection<char?> input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    public static bool AllEqualsIgnoreCase(params char?[] input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    public static bool AnyEqualsIgnoreCase(this IEnumerable<char?> input) => !input.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(this ICollection<char?> input) => !input.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(params char?[] input) => !input.AllNotEqualsIgnoreCase();

    public static bool IsNotNullNEmpty([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNotEmpty();

    public static bool AllNotNullNEmpty(this IEnumerable<char?> input) => !input.Any(x => x.IsNullOEmpty());

    public static bool AllNotNullNEmpty(this ICollection<char?> input) => !input.Any(x => x.IsNullOEmpty());

    public static bool AllNotNullNEmpty(params char?[] input) => !input.Any(x => x.IsNullOEmpty());

    public static bool AnyNotNullNEmpty(this IEnumerable<char?> input) => input.Any(x => x.IsNotNullNEmpty());

    public static bool AnyNotNullNEmpty(this ICollection<char?> input) => input.Any(x => x.IsNotNullNEmpty());

    public static bool AnyNotNullNEmpty(params char?[] input) => input.Any(x => x.IsNotNullNEmpty());

    public static bool IsNotNullNWhiteSpace([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNotEmpty() && input.Value.IsNotWhiteSpace();

    public static bool AllNotNullNWhiteSpace(this IEnumerable<char?> input) => !input.Any(x => x.IsNullOWhiteSpace());

    public static bool AllNotNullNWhiteSpace(this ICollection<char?> input) => !input.Any(x => x.IsNullOWhiteSpace());

    public static bool AllNotNullNWhiteSpace(params char?[] input) => !input.Any(x => x.IsNullOWhiteSpace());

    public static bool AnyNotNullNWhiteSpace(this IEnumerable<char?> input) => input.Any(x => x.IsNotNullNWhiteSpace());

    public static bool AnyNotNullNWhiteSpace(this ICollection<char?> input) => input.Any(x => x.IsNotNullNWhiteSpace());

    public static bool AnyNotNullNWhiteSpace(params char?[] input) => input.Any(x => x.IsNotNullNWhiteSpace());

    public static bool IsNotAlphabetic(this char? input) => input.HasValue && input.Value.IsNotAlphabetic();

    public static bool AllNotAlphabetic(this IEnumerable<char?> input) => !input.Any(x => x.IsAlphabetic());

    public static bool AllNotAlphabetic(this ICollection<char?> input) => !input.Any(x => x.IsAlphabetic());

    public static bool AllNotAlphabetic(params char?[] input) => !input.Any(x => x.IsAlphabetic());

    public static bool AnyNotAlphabetic(this IEnumerable<char?> input) => input.Any(x => x.IsNotAlphabetic());

    public static bool AnyNotAlphabetic(this ICollection<char?> input) => input.Any(x => x.IsNotAlphabetic());

    public static bool AnyNotAlphabetic(params char?[] input) => input.Any(x => x.IsNotAlphabetic());

    public static bool IsNotPunctuation(this char? input) => input.HasValue && input.Value.IsNotPunctuation();

    public static bool AllNotPunctuation(this IEnumerable<char?> input) => !input.Any(x => x.IsPunctuation());

    public static bool AllNotPunctuation(this ICollection<char?> input) => !input.Any(x => x.IsPunctuation());

    public static bool AllNotPunctuation(params char?[] input) => !input.Any(x => x.IsPunctuation());

    public static bool AnyNotPunctuation(this IEnumerable<char?> input) => input.Any(x => x.IsNotPunctuation());

    public static bool AnyNotPunctuation(this ICollection<char?> input) => input.Any(x => x.IsNotPunctuation());

    public static bool AnyNotPunctuation(params char?[] input) => input.Any(x => x.IsNotPunctuation());

    public static bool IsNotNumber(this char? input) => input.HasValue && input.Value.IsNotNumber();

    public static bool AllNotNumber(this IEnumerable<char?> input) => !input.Any(x => x.IsNumber());

    public static bool AllNotNumber(this ICollection<char?> input) => !input.Any(x => x.IsNumber());

    public static bool AllNotNumber(params char?[] input) => !input.Any(x => x.IsNumber());

    public static bool AnyNotNumber(this IEnumerable<char?> input) => input.Any(x => x.IsNotNumber());

    public static bool AnyNotNumber(this ICollection<char?> input) => input.Any(x => x.IsNotNumber());

    public static bool AnyNotNumber(params char?[] input) => input.Any(x => x.IsNotNumber());

    public static bool NotEqualsIgnoreCase(this char? input1, char? input2) => input1.LowerInvariant() != input2.LowerInvariant();

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

    public static bool AllNotEqualsIgnoreCase(this ICollection<char?> input)
    {
        var set = new HashSet<char?>(input.Count);

        foreach (var c in input)
        {
            if (!set.Add(c.LowerInvariant()))
            {
                return false;
            }
        }

        return true;
    }

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

    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<char?> input) => !input.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(this ICollection<char?> input) => !input.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(params char?[] input) => !input.AllEqualsIgnoreCase();

    public static char? Lower(this char? input) => input.IsNullOWhiteSpace() ? default : char.ToLower(input.Value);

    public static void Lower(this List<char?>? input)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.Lower());
    }

    public static IEnumerable<char?>? Lowers(this IEnumerable<char?>? input) => input.IsNullOEmpty() ? default : input.Select(x => x.Lower());

    public static IEnumerable<char?>? Lowers(this ICollection<char?>? input) => input.IsNullOEmpty() ? default : input.Select(x => x.Lower());

    public static IEnumerable<char?>? Lowers(params char?[]? input) => input.IsNullOEmpty() ? default : input.Select(x => x.Lower());

    public static char? LowerInvariant(this char? input) => input.IsNullOWhiteSpace() ? default : char.ToLowerInvariant(input.Value);

    public static void LowerInvariant(this List<char?>? input)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.LowerInvariant());
    }

    public static IEnumerable<char?>? LowerInvariants(this IEnumerable<char?>? input) => input.IsNullOEmpty() ? default : input.Select(x => x.LowerInvariant());

    public static IEnumerable<char?>? LowerInvariants(this ICollection<char?>? input) => input.IsNullOEmpty() ? default : input.Select(x => x.LowerInvariant());

    public static IEnumerable<char?>? LowerInvariants(params char?[]? input) => input.IsNullOEmpty() ? default : input.Select(x => x.LowerInvariant());

    public static char? Upper(this char? input) => input.IsNullOWhiteSpace() ? default : char.ToUpper(input.Value);

    public static void Upper(this List<char?>? input)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.Upper());
    }

    public static IEnumerable<char?>? Uppers(this IEnumerable<char?>? input) => input.IsNullOEmpty() ? default : input.Select(x => x.Upper());

    public static IEnumerable<char?>? Uppers(this ICollection<char?>? input) => input.IsNullOEmpty() ? default : input.Select(x => x.Upper());

    public static IEnumerable<char?>? Uppers(params char?[]? input) => input.IsNullOEmpty() ? default : input.Select(x => x.Upper());

    public static char? UpperInvariant(this char? input) => input.IsNullOWhiteSpace() ? default : char.ToUpperInvariant(input.Value);

    public static void UpperInvariant(this List<char?>? input)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.UpperInvariant());
    }

    public static IEnumerable<char?>? UpperInvariants(this IEnumerable<char?>? input) => input.IsNullOEmpty() ? default : input.Select(x => x.UpperInvariant());

    public static IEnumerable<char?>? UpperInvariants(this ICollection<char?>? input) => input.IsNullOEmpty() ? default : input.Select(x => x.UpperInvariant());

    public static IEnumerable<char?>? UpperInvariants(params char?[]? input) => input.IsNullOEmpty() ? default : input.Select(x => x.UpperInvariant());

    public static bool IsLower(this char? input) => input.HasValue && char.IsLower(input.Value);

    public static bool AllLowers(this IEnumerable<char?> input) => !input.Any(x => x.IsNotLower());

    public static bool AllLowers(this ICollection<char?> input) => !input.Any(x => x.IsNotLower());

    public static bool AllLowers(params char?[] input) => !input.Any(x => x.IsNotLower());

    public static bool AnyLowers(this IEnumerable<char?> input) => input.Any(x => x.IsLower());

    public static bool AnyLowers(this ICollection<char?> input) => input.Any(x => x.IsLower());

    public static bool AnyLowers(params char?[] input) => input.Any(x => x.IsLower());

    public static bool IsNotLower(this char? input) => input.HasValue && !char.IsLower(input.Value);

    public static bool AllNotLowers(this IEnumerable<char?> input) => !input.Any(x => x.IsLower());

    public static bool AllNotLowers(this ICollection<char?> input) => !input.Any(x => x.IsLower());

    public static bool AllNotLowers(params char?[] input) => !input.Any(x => x.IsLower());

    public static bool AnyNotLowers(this IEnumerable<char?> input) => input.Any(x => x.IsNotLower());

    public static bool AnyNotLowers(this ICollection<char?> input) => input.Any(x => x.IsNotLower());

    public static bool AnyNotLowers(params char?[] input) => input.Any(x => x.IsNotLower());

    public static bool IsUpper(this char? input) => input.HasValue && char.IsUpper(input.Value);

    public static bool AllUppers(this IEnumerable<char?> input) => !input.Any(x => x.IsNotUpper());

    public static bool AllUppers(this ICollection<char?> input) => !input.Any(x => x.IsNotUpper());

    public static bool AllUppers(params char?[] input) => !input.Any(x => x.IsNotUpper());

    public static bool AnyUppers(this IEnumerable<char?> input) => input.Any(x => x.IsUpper());

    public static bool AnyUppers(this ICollection<char?> input) => input.Any(x => x.IsUpper());

    public static bool AnyUppers(params char?[] input) => input.Any(x => x.IsUpper());

    public static bool IsNotUpper(this char? input) => input.HasValue && !char.IsUpper(input.Value);

    public static bool AllNotUppers(this IEnumerable<char?> input) => !input.Any(x => x.IsUpper());

    public static bool AllNotUppers(this ICollection<char?> input) => !input.Any(x => x.IsUpper());

    public static bool AllNotUppers(params char?[] input) => !input.Any(x => x.IsUpper());

    public static bool AnyNotUppers(this IEnumerable<char?> input) => input.Any(x => x.IsNotUpper());

    public static bool AnyNotUppers(this ICollection<char?> input) => input.Any(x => x.IsNotUpper());

    public static bool AnyNotUppers(params char?[] input) => input.Any(x => x.IsNotUpper());
}
