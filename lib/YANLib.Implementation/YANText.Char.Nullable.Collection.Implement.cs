using System.Diagnostics;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation;

internal static partial class YANText
{
    #region NullEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullEmptyImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullEmptyImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullEmptyImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullEmptyImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotNullEmptyImplement());

    #endregion

    #region NullWhiteSpace

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullWhiteSpaceImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullWhiteSpaceImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullWhiteSpaceImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullWhiteSpaceImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotNullWhiteSpaceImplement());

    #endregion

    #region Alphabetic

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllAlphabeticImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotAlphabeticImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyAlphabeticImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsAlphabeticImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotAlphabeticImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsAlphabeticImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotAlphabeticImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotAlphabeticImplement());

    #endregion

    #region Punctuation

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPunctuationImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotPunctuationImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPunctuationImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsPunctuationImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotPunctuationImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsPunctuationImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotPunctuationImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotPunctuationImplement());

    #endregion

    #region Number

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNumberImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotNumberImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNumberImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNumberImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNumberImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNumberImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNumberImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotNumberImplement());

    #endregion

    #region Alphanumeric

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllAlphanumericImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotAlphanumericImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyAlphanumericImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsAlphanumericImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotAlphanumericImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsAlphanumericImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotAlphanumericImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotAlphanumericImplement());

    #endregion

    #region EqualsIgnoreCase

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllEqualsIgnoreCaseImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Select(x => x.LowerInvariantImplement()).Distinct().Count() is 1;

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyEqualsIgnoreCaseImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.GetCountImplement() != input.Select(x => x.LowerInvariantImplement()).Distinct().Count();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotEqualsIgnoreCaseImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.GetCountImplement() == input.Select(x => x.LowerInvariantImplement()).Distinct().Count();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotEqualsIgnoreCaseImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Select(x => x.LowerInvariantImplement()).Distinct().Count() is not 1;

    #endregion

    #region Lower

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
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.LowerImplement()) : input.AsParallel().Select(x => x.LowerImplement());

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
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.LowerInvariantImplement()) : input.AsParallel().Select(x => x.LowerInvariantImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllLowersImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotLowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyLowersImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsLowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotLowersImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsLowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotLowersImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotLowerImplement());

    #endregion

    #region Upper

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
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.UpperImplement()) : input.AsParallel().Select(x => x.UpperImplement());

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
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.UpperInvariantImplement()) : input.AsParallel().Select(x => x.UpperInvariantImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllUppersImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotUpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyUppersImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsUpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotUppersImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsUpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotUppersImplement(this IEnumerable<char?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotUpperImplement());

    #endregion
}
