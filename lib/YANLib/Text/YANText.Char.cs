using YANLib.Object;
using static System.Linq.Enumerable;

namespace YANLib.Text;

public static partial class YANText
{
    public static bool IsEmpty(this char input) => input is char.MinValue;

    public static bool AllEmpty(this IEnumerable<char> input) => !input.Any(x => x.IsNotEmpty());

    public static bool AllEmpty(this ICollection<char> input) => !input.Any(x => x.IsNotEmpty());

    public static bool AllEmpty(params char[] input) => !input.Any(x => x.IsNotEmpty());

    public static bool AnyEmpty(this IEnumerable<char> input) => input.Any(x => x.IsEmpty());

    public static bool AnyEmpty(this ICollection<char> input) => input.Any(x => x.IsEmpty());

    public static bool AnyEmpty(params char[] input) => input.Any(x => x.IsEmpty());

    public static bool IsWhiteSpace(this char input) => char.IsWhiteSpace(input);

    public static bool AllWhiteSpace(this IEnumerable<char> input) => !input.Any(x => x.IsNotWhiteSpace());

    public static bool AllWhiteSpace(this ICollection<char> input) => !input.Any(x => x.IsNotWhiteSpace());

    public static bool AllWhiteSpace(params char[] input) => !input.Any(x => x.IsNotWhiteSpace());

    public static bool AnyWhiteSpace(this IEnumerable<char> input) => input.Any(x => x.IsWhiteSpace());

    public static bool AnyWhiteSpace(this ICollection<char> input) => input.Any(x => x.IsWhiteSpace());

    public static bool AnyWhiteSpace(params char[] input) => input.Any(x => x.IsWhiteSpace());

    public static bool IsWhiteSpaceOrEmpty(this char input) => input.IsEmpty() || input.IsWhiteSpace();

    public static bool AllWhiteSpaceOrEmpty(this IEnumerable<char> input) => !input.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool AllWhiteSpaceOrEmpty(this ICollection<char> input) => !input.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool AllWhiteSpaceOrEmpty(params char[] input) => !input.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool AnyWhiteSpaceOrEmpty(this IEnumerable<char> input) => input.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool AnyWhiteSpaceOrEmpty(this ICollection<char> input) => input.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool AnyWhiteSpaceOrEmpty(params char[] input) => input.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool IsAlphabetic(this char input) => char.IsLetter(input);

    public static bool AllAlphabetic(this IEnumerable<char> input) => !input.Any(x => x.IsNotAlphabetic());

    public static bool AllAlphabetic(this ICollection<char> input) => !input.Any(x => x.IsNotAlphabetic());

    public static bool AllAlphabetic(params char[] input) => !input.Any(x => x.IsNotAlphabetic());

    public static bool AnyAlphabetic(this IEnumerable<char> input) => input.Any(x => x.IsAlphabetic());

    public static bool AnyAlphabetic(this ICollection<char> input) => input.Any(x => x.IsAlphabetic());

    public static bool AnyAlphabetic(params char[] input) => input.Any(x => x.IsAlphabetic());

    public static bool IsPunctuation(this char input) => char.IsPunctuation(input);

    public static bool AllPunctuation(this IEnumerable<char> input) => !input.Any(x => x.IsNotPunctuation());

    public static bool AllPunctuation(this ICollection<char> input) => !input.Any(x => x.IsNotPunctuation());

    public static bool AllPunctuation(params char[] input) => !input.Any(x => x.IsNotPunctuation());

    public static bool AnyPunctuation(this IEnumerable<char> input) => input.Any(x => x.IsPunctuation());

    public static bool AnyPunctuation(this ICollection<char> input) => input.Any(x => x.IsPunctuation());

    public static bool AnyPunctuation(params char[] input) => input.Any(x => x.IsPunctuation());

    public static bool IsNumber(this char input) => char.IsDigit(input);

    public static bool AllNumber(this IEnumerable<char> input) => !input.Any(x => x.IsNotNumber());

    public static bool AllNumber(this ICollection<char> input) => !input.Any(x => x.IsNotNumber());

    public static bool AllNumber(params char[] input) => !input.Any(x => x.IsNotNumber());

    public static bool AnyNumber(this IEnumerable<char> input) => input.Any(x => x.IsNumber());

    public static bool AnyNumber(this ICollection<char> input) => input.Any(x => x.IsNumber());

    public static bool AnyNumber(params char[] input) => input.Any(x => x.IsNumber());

    public static bool EqualsIgnoreCase(this char input1, char input2) => input1.LowerInvariant() == input2.LowerInvariant();

    public static bool AllEqualsIgnoreCase(this IEnumerable<char> input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    public static bool AllEqualsIgnoreCase(this ICollection<char> input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    public static bool AllEqualsIgnoreCase(params char[] input) => !input.Any(x => x.NotEqualsIgnoreCase(input.First()));

    public static bool AnyEqualsIgnoreCase(this IEnumerable<char> input) => !input.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(this ICollection<char> input) => !input.AllNotEqualsIgnoreCase();

    public static bool AnyEqualsIgnoreCase(params char[] input) => !input.AllNotEqualsIgnoreCase();

    public static bool IsNotEmpty(this char input) => input is not char.MinValue;

    public static bool AllNotEmpty(this IEnumerable<char> input) => !input.Any(x => x.IsEmpty());

    public static bool AllNotEmpty(this ICollection<char> input) => !input.Any(x => x.IsEmpty());

    public static bool AllNotEmpty(params char[] input) => !input.Any(x => x.IsEmpty());

    public static bool AnyNotEmpty(this IEnumerable<char> input) => input.Any(x => x.IsNotEmpty());

    public static bool AnyNotEmpty(this ICollection<char> input) => input.Any(x => x.IsNotEmpty());

    public static bool AnyNotEmpty(params char[] input) => input.Any(x => x.IsNotEmpty());

    public static bool IsNotWhiteSpace(this char input) => !char.IsWhiteSpace(input);

    public static bool AllNotWhiteSpace(this IEnumerable<char> input) => !input.Any(x => x.IsWhiteSpace());

    public static bool AllNotWhiteSpace(this ICollection<char> input) => !input.Any(x => x.IsWhiteSpace());

    public static bool AllNotWhiteSpace(params char[] input) => !input.Any(x => x.IsWhiteSpace());

    public static bool AnyNotWhiteSpace(this IEnumerable<char> input) => input.Any(x => x.IsNotWhiteSpace());

    public static bool AnyNotWhiteSpace(this ICollection<char> input) => input.Any(x => x.IsNotWhiteSpace());

    public static bool AnyNotWhiteSpace(params char[] input) => input.Any(x => x.IsNotWhiteSpace());

    public static bool IsNotWhiteSpaceAndEmpty(this char input) => input.IsNotEmpty() && input.IsNotWhiteSpace();

    public static bool AllNotWhiteSpaceAndEmpty(this IEnumerable<char> input) => !input.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool AllNotWhiteSpaceAndEmpty(this ICollection<char> input) => !input.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool AllNotWhiteSpaceAndEmpty(params char[] input) => !input.Any(x => x.IsWhiteSpaceOrEmpty());

    public static bool AnyNotWhiteSpaceAndEmpty(this IEnumerable<char> input) => input.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool AnyNotWhiteSpaceAndEmpty(this ICollection<char> input) => input.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool AnyNotWhiteSpaceAndEmpty(params char[] input) => input.Any(x => x.IsNotWhiteSpaceAndEmpty());

    public static bool IsNotAlphabetic(this char input) => !char.IsLetter(input);

    public static bool AllNotAlphabetic(this IEnumerable<char> input) => !input.Any(x => x.IsAlphabetic());

    public static bool AllNotAlphabetic(this ICollection<char> input) => !input.Any(x => x.IsAlphabetic());

    public static bool AllNotAlphabetic(params char[] input) => !input.Any(x => x.IsAlphabetic());

    public static bool AnyNotAlphabetic(this IEnumerable<char> input) => input.Any(x => x.IsNotAlphabetic());

    public static bool AnyNotAlphabetic(this ICollection<char> input) => input.Any(x => x.IsNotAlphabetic());

    public static bool AnyNotAlphabetic(params char[] input) => input.Any(x => x.IsNotAlphabetic());

    public static bool IsNotPunctuation(this char input) => !char.IsPunctuation(input);

    public static bool AllNotPunctuation(this IEnumerable<char> input) => !input.Any(x => x.IsPunctuation());

    public static bool AllNotPunctuation(this ICollection<char> input) => !input.Any(x => x.IsPunctuation());

    public static bool AllNotPunctuation(params char[] input) => !input.Any(x => x.IsPunctuation());

    public static bool AnyNotPunctuation(this IEnumerable<char> input) => input.Any(x => x.IsNotPunctuation());

    public static bool AnyNotPunctuation(this ICollection<char> input) => input.Any(x => x.IsNotPunctuation());

    public static bool AnyNotPunctuation(params char[] input) => input.Any(x => x.IsNotPunctuation());

    public static bool IsNotNumber(this char input) => !char.IsDigit(input);

    public static bool AllNotNumber(this IEnumerable<char> input) => !input.Any(x => x.IsNumber());

    public static bool AllNotNumber(this ICollection<char> input) => !input.Any(x => x.IsNumber());

    public static bool AllNotNumber(params char[] input) => !input.Any(x => x.IsNumber());

    public static bool AnyNotNumber(this IEnumerable<char> input) => input.Any(x => x.IsNotNumber());

    public static bool AnyNotNumber(this ICollection<char> input) => input.Any(x => x.IsNotNumber());

    public static bool AnyNotNumber(params char[] input) => input.Any(x => x.IsNotNumber());

    public static bool NotEqualsIgnoreCase(this char input1, char input2) => input1.LowerInvariant() != input2.LowerInvariant();

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

    public static bool AllNotEqualsIgnoreCase(this ICollection<char> input)
    {
        var set = new HashSet<char>(input.Count);

        foreach (var c in input)
        {
            if (!set.Add(c.LowerInvariant()))
            {
                return false;
            }
        }

        return true;
    }

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

    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<char> input) => !input.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(this ICollection<char> input) => !input.AllEqualsIgnoreCase();

    public static bool AnyNotEqualsIgnoreCase(params char[] input) => !input.AllEqualsIgnoreCase();

    public static char Lower(this char input) => input.IsWhiteSpaceOrEmpty() ? input : char.ToLower(input);

    public static void Lower(this List<char>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.Lower());
    }

    public static IEnumerable<char>? Lowers(this IEnumerable<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.Lower());

    public static IEnumerable<char>? Lowers(this ICollection<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.Lower());

    public static IEnumerable<char>? Lowers(params char[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.Lower());

    public static char LowerInvariant(this char input) => input.IsWhiteSpaceOrEmpty() ? input : char.ToLowerInvariant(input);

    public static void LowerInvariant(this List<char>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.LowerInvariant());
    }

    public static IEnumerable<char>? LowerInvariants(this IEnumerable<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.LowerInvariant());

    public static IEnumerable<char>? LowerInvariants(this ICollection<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.LowerInvariant());

    public static IEnumerable<char>? LowerInvariants(params char[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.LowerInvariant());

    public static char Upper(this char input) => input.IsWhiteSpaceOrEmpty() ? input : char.ToUpper(input);

    public static void Upper(this List<char>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.Upper());
    }

    public static IEnumerable<char>? Uppers(this IEnumerable<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.Upper());

    public static IEnumerable<char>? Uppers(this ICollection<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.Upper());

    public static IEnumerable<char>? Uppers(params char[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.Upper());

    public static char UpperInvariant(this char input) => input.IsWhiteSpaceOrEmpty() ? input : char.ToUpperInvariant(input);

    public static void UpperInvariant(this List<char>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.UpperInvariant());
    }

    public static IEnumerable<char>? UpperInvariants(this IEnumerable<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.UpperInvariant());

    public static IEnumerable<char>? UpperInvariants(this ICollection<char>? input) => input.IsNullEmpty() ? default : input.Select(x => x.UpperInvariant());

    public static IEnumerable<char>? UpperInvariants(params char[]? input) => input.IsNullEmpty() ? default : input.Select(x => x.UpperInvariant());

    public static bool IsLower(this char input) => input.IsNotWhiteSpaceAndEmpty() && char.IsLower(input);

    public static bool AllLowers(this IEnumerable<char> input) => !input.Any(x => x.IsNotLower());

    public static bool AllLowers(this ICollection<char> input) => !input.Any(x => x.IsNotLower());

    public static bool AllLowers(params char[] input) => !input.Any(x => x.IsNotLower());

    public static bool AnyLowers(this IEnumerable<char> input) => input.Any(x => x.IsLower());

    public static bool AnyLowers(this ICollection<char> input) => input.Any(x => x.IsLower());

    public static bool AnyLowers(params char[] input) => input.Any(x => x.IsLower());

    public static bool IsNotLower(this char input) => input.IsNotWhiteSpaceAndEmpty() && !char.IsLower(input);

    public static bool AllNotLowers(this IEnumerable<char> input) => !input.Any(x => x.IsLower());

    public static bool AllNotLowers(this ICollection<char> input) => !input.Any(x => x.IsLower());

    public static bool AllNotLowers(params char[] input) => !input.Any(x => x.IsLower());

    public static bool AnyNotLowers(this IEnumerable<char> input) => input.Any(x => x.IsNotLower());

    public static bool AnyNotLowers(this ICollection<char> input) => input.Any(x => x.IsNotLower());

    public static bool AnyNotLowers(params char[] input) => input.Any(x => x.IsNotLower());

    public static bool IsUpper(this char input) => input.IsNotWhiteSpaceAndEmpty() && char.IsUpper(input);

    public static bool AllUppers(this IEnumerable<char> input) => !input.Any(x => x.IsNotUpper());

    public static bool AllUppers(this ICollection<char> input) => !input.Any(x => x.IsNotUpper());

    public static bool AllUppers(params char[] input) => !input.Any(x => x.IsNotUpper());

    public static bool AnyUppers(this IEnumerable<char> input) => input.Any(x => x.IsUpper());

    public static bool AnyUppers(this ICollection<char> input) => input.Any(x => x.IsUpper());

    public static bool AnyUppers(params char[] input) => input.Any(x => x.IsUpper());

    public static bool IsNotUpper(this char input) => input.IsNotWhiteSpaceAndEmpty() && !char.IsUpper(input);

    public static bool AllNotUppers(this IEnumerable<char> input) => !input.Any(x => x.IsUpper());

    public static bool AllNotUppers(this ICollection<char> input) => !input.Any(x => x.IsUpper());

    public static bool AllNotUppers(params char[] input) => !input.Any(x => x.IsUpper());

    public static bool AnyNotUppers(this IEnumerable<char> input) => input.Any(x => x.IsNotUpper());

    public static bool AnyNotUppers(this ICollection<char> input) => input.Any(x => x.IsNotUpper());

    public static bool AnyNotUppers(params char[] input) => input.Any(x => x.IsNotUpper());
}
