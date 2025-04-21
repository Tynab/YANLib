using System.Diagnostics;
using YANLib.Implementation.Object;
using YANLib.Implementation.Text;
using static System.Linq.Enumerable;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation.Text;

internal static partial class YANText
{
    #region Empty

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsEmptyImplement(this char input) => input is char.MinValue;

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotEmptyImplement(this char input) => !input.IsEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotEmptyImplement());

    #endregion

    #region WhiteSpace

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsWhiteSpaceImplement(this char input) => char.IsWhiteSpace(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllWhiteSpaceImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyWhiteSpaceImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotWhiteSpaceImplement(this char input) => !input.IsWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotWhiteSpaceImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotWhiteSpaceImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotWhiteSpaceImplement());

    #endregion

    #region WhiteSpaceEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsWhiteSpaceEmptyImplement(this char input) => input.IsEmptyImplement() || input.IsWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllWhiteSpaceEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotWhiteSpaceEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyWhiteSpaceEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsWhiteSpaceEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotWhiteSpaceEmptyImplement(this char input) => !input.IsWhiteSpaceEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotWhiteSpaceEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsWhiteSpaceEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotWhiteSpaceEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotWhiteSpaceEmptyImplement());

    #endregion

    #region Alphabetic

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsAlphabeticImplement(this char input) => char.IsLetter(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllAlphabeticImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotAlphabeticImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyAlphabeticImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsAlphabeticImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotAlphabeticImplement(this char input) => !input.IsAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotAlphabeticImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsAlphabeticImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotAlphabeticImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotAlphabeticImplement());

    #endregion

    #region Punctuation

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsPunctuationImplement(this char input) => char.IsPunctuation(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllPunctuationImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotPunctuationImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyPunctuationImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsPunctuationImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotPunctuationImplement(this char input) => !input.IsPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotPunctuationImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsPunctuationImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotPunctuationImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotPunctuationImplement());

    #endregion

    #region Number

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNumberImplement(this char input) => char.IsDigit(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNumberImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotNumberImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNumberImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNumberImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNumberImplement(this char input) => !input.IsNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNumberImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNumberImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNumberImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotNumberImplement());

    #endregion

    #region Alphanumeric

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsAlphanumericImplement(this char input) => char.IsLetterOrDigit(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllAlphanumericImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotAlphanumericImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyAlphanumericImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsAlphanumericImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotAlphanumericImplement(this char input) => !input.IsAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotAlphanumericImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsAlphanumericImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotAlphanumericImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotAlphanumericImplement());

    #endregion

    #region EqualsIgnoreCase

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool EqualsIgnoreCaseImplement(this char input1, char input2) => input1.LowerInvariantImplement() == input2.LowerInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllEqualsIgnoreCaseImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Select(x => x.LowerInvariantImplement()).Distinct().Count() is 1;

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyEqualsIgnoreCaseImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.GetCountImplement() != input.Select(x => x.LowerInvariantImplement()).Distinct().Count();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool NotEqualsIgnoreCaseImplement(this char input1, char input2) => !input1.NotEqualsIgnoreCaseImplement(input2);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotEqualsIgnoreCaseImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.GetCountImplement() == input.Select(x => x.LowerInvariantImplement()).Distinct().Count();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotEqualsIgnoreCaseImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Select(x => x.LowerInvariantImplement()).Distinct().Count() is not 1;

    #endregion

    #region Lower

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char LowerImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToLower(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void LowerImplement(this List<char>? input)
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
    internal static IEnumerable<char>? LowersImplement(this IEnumerable<char>? input)
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.LowerImplement()) : input.AsParallel().Select(x => x.LowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char LowerInvariantImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToLowerInvariant(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void LowerInvariantImplement(this List<char>? input)
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
    internal static IEnumerable<char>? LowerInvariantsImplement(this IEnumerable<char>? input)
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.LowerInvariantImplement()) : input.AsParallel().Select(x => x.LowerInvariantImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsLowerImplement(this char input) => input.IsNotWhiteSpaceEmptyImplement() && char.IsLower(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllLowersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotLowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyLowersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsLowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotLowerImplement(this char input) => !input.IsLowerImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotLowersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsLowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotLowersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotLowerImplement());

    #endregion

    #region Upper

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char UpperImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToUpper(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void UpperImplement(this List<char>? input)
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
    internal static IEnumerable<char>? UppersImplement(this IEnumerable<char>? input)
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.UpperImplement()) : input.AsParallel().Select(x => x.UpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char UpperInvariantImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToUpperInvariant(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void UpperInvariantImplement(this List<char>? input)
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
    internal static IEnumerable<char>? UpperInvariantsImplement(this IEnumerable<char>? input)
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.UpperInvariantImplement()) : input.AsParallel().Select(x => x.UpperInvariantImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsUpperImplement(this char input) => input.IsNotWhiteSpaceEmptyImplement() && char.IsUpper(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllUppersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotUpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyUppersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsUpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotUpperImplement(this char input) => input.IsNotWhiteSpaceEmptyImplement() && !char.IsUpper(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotUppersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsUpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotUppersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotUpperImplement());

    #endregion
}
