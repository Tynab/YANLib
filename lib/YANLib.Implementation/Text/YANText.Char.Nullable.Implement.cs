using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation.Object;
using YANLib.Implementation.Text;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation.Text;

internal static partial class YANText
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullEmptyImplement([NotNullWhen(false)] this char? input) => !input.HasValue || input.Value.IsEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullEmptyImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsNotNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullEmptyImplement(this IEnumerable<char?> input) => input.Any(x => x.IsNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullWhiteSpaceImplement([NotNullWhen(false)] this char? input) => !input.HasValue || input.Value.IsEmptyImplement() || input.Value.IsWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullWhiteSpaceImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsNotNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullWhiteSpaceImplement(this IEnumerable<char?> input) => input.Any(x => x.IsNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsAlphabeticImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllAlphabeticImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsNotAlphabeticImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyAlphabeticImplement(this IEnumerable<char?> input) => input.Any(x => x.IsAlphabeticImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsPunctuationImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPunctuationImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsNotPunctuationImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPunctuationImplement(this IEnumerable<char?> input) => input.Any(x => x.IsPunctuationImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNumberImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNumberImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsNotNumberImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNumberImplement(this IEnumerable<char?> input) => input.Any(x => x.IsNumberImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsAlphanumericImplement(this char? input) => input.HasValue && input.Value.IsAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllAlphanumericImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsNotAlphanumericImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyAlphanumericImplement(this IEnumerable<char?> input) => input.Any(x => x.IsAlphanumericImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool EqualsIgnoreCaseImplement(this char input1, char? input2) => input1.LowerInvariantImplement() == input2.LowerInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllEqualsIgnoreCaseImplement(this IEnumerable<char?> input) => !input.Any(x => x.NotEqualsIgnoreCaseImplement(input.First()));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyEqualsIgnoreCaseImplement(this IEnumerable<char?> input) => !input.AllNotEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullEmptyImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNotEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullEmptyImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullEmptyImplement(this IEnumerable<char?> input) => input.Any(x => x.IsNotNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullWhiteSpaceImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNotEmptyImplement() && input.Value.IsNotWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullWhiteSpaceImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullWhiteSpaceImplement(this IEnumerable<char?> input) => input.Any(x => x.IsNotNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotAlphabeticImplement(this char? input) => !input.HasValue || input.Value.IsNotAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotAlphabeticImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsAlphabeticImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotAlphabeticImplement(this IEnumerable<char?> input) => input.Any(x => x.IsNotAlphabeticImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotPunctuationImplement(this char? input) => !input.HasValue || input.Value.IsNotPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotPunctuationImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsPunctuationImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotPunctuationImplement(this IEnumerable<char?> input) => input.Any(x => x.IsNotPunctuationImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNumberImplement(this char? input) => !input.HasValue || input.Value.IsNotNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNumberImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsNumberImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNumberImplement(this IEnumerable<char?> input) => input.Any(x => x.IsNotNumberImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotAlphanumericImplement(this char? input) => !input.HasValue || input.Value.IsNotAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotAlphanumericImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsAlphanumericImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotAlphanumericImplement(this IEnumerable<char?> input) => input.Any(x => x.IsNotAlphanumericImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool NotEqualsIgnoreCaseImplement(this char? input1, char? input2) => input1.LowerInvariantImplement() != input2.LowerInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotEqualsIgnoreCaseImplement(this IEnumerable<char?> input)
    {
        var set = new HashSet<char?>(input.Count());

        foreach (var c in input)
        {
            if (!set.Add(c.LowerInvariantImplement()))
            {
                return false;
            }
        }

        return true;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotEqualsIgnoreCaseImplement(this IEnumerable<char?> input) => !input.AllEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char? LowerImplement(this char? input) => input.IsNullEmptyImplement() ? default(char?) : char.ToLower(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void LowerImplement(this List<char?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].LowerImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].LowerImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<char?>? LowersImplement(this IEnumerable<char?>? input)
        => input.IsNullEmptyImplement() ? default : input.Count() < 1_000 ? input.Select(x => x.LowerImplement()) : input.AsParallel().Select(x => x.LowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char? LowerInvariantImplement(this char? input) => input.IsNullEmptyImplement() ? default(char?) : char.ToLowerInvariant(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void LowerInvariantImplement(this List<char?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].LowerInvariantImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].LowerInvariantImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<char?>? LowerInvariantsImplement(this IEnumerable<char?>? input)
        => input.IsNullEmptyImplement() ? default : input.Count() < 1_000 ? input.Select(x => x.LowerInvariantImplement()) : input.AsParallel().Select(x => x.LowerInvariantImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char? UpperImplement(this char? input) => input.IsNullEmptyImplement() ? default(char?) : char.ToUpper(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void UpperImplement(this List<char?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].UpperImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].UpperImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<char?>? UppersImplement(this IEnumerable<char?>? input)
        => input.IsNullEmptyImplement() ? default : input.Count() < 1_000 ? input.Select(x => x.UpperImplement()) : input.AsParallel().Select(x => x.UpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char? UpperInvariantImplement(this char? input) => input.IsNullEmptyImplement() ? default(char?) : char.ToUpperInvariant(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void UpperInvariantImplement(this List<char?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].UpperInvariantImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].UpperInvariantImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<char?>? UpperInvariantsImplement(this IEnumerable<char?>? input)
        => input.IsNullEmptyImplement() ? default : input.Count() < 1_000 ? input.Select(x => x.UpperInvariantImplement()) : input.AsParallel().Select(x => x.UpperInvariantImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsLowerImplement(this char? input) => input.HasValue && char.IsLower(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllLowersImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsNotLowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyLowersImplement(this IEnumerable<char?> input) => input.Any(x => x.IsLowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotLowerImplement(this char? input) => !input.HasValue || !char.IsLower(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotLowersImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsLowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotLowersImplement(this IEnumerable<char?> input) => input.Any(x => x.IsNotLowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsUpperImplement(this char? input) => input.HasValue && char.IsUpper(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllUppersImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsNotUpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyUppersImplement(this IEnumerable<char?> input) => input.Any(x => x.IsUpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotUpperImplement(this char? input) => !input.HasValue || !char.IsUpper(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotUppersImplement(this IEnumerable<char?> input) => !input.Any(x => x.IsUpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotUppersImplement(this IEnumerable<char?> input) => input.Any(x => x.IsNotUpperImplement());
}
