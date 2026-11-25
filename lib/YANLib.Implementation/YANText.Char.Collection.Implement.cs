using static System.Linq.Enumerable;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation;

internal static partial class YANText
{
    #region Empty

    internal static bool AllEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotEmptyImplement());

    internal static bool AnyEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsEmptyImplement());

    internal static bool AllNotEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsEmptyImplement());

    internal static bool AnyNotEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotEmptyImplement());

    #endregion

    #region WhiteSpace

    internal static bool AllWhiteSpaceImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotWhiteSpaceImplement());

    internal static bool AnyWhiteSpaceImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsWhiteSpaceImplement());

    internal static bool AllNotWhiteSpaceImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsWhiteSpaceImplement());

    internal static bool AnyNotWhiteSpaceImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotWhiteSpaceImplement());

    #endregion

    #region WhiteSpaceEmpty

    internal static bool AllWhiteSpaceEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotWhiteSpaceEmptyImplement());

    internal static bool AnyWhiteSpaceEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsWhiteSpaceEmptyImplement());

    internal static bool AllNotWhiteSpaceEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsWhiteSpaceEmptyImplement());

    internal static bool AnyNotWhiteSpaceEmptyImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotWhiteSpaceEmptyImplement());

    #endregion

    #region Alphabetic

    internal static bool AllAlphabeticImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotAlphabeticImplement());

    internal static bool AnyAlphabeticImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsAlphabeticImplement());

    internal static bool AllNotAlphabeticImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsAlphabeticImplement());

    internal static bool AnyNotAlphabeticImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotAlphabeticImplement());

    #endregion

    #region Punctuation

    internal static bool AllPunctuationImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotPunctuationImplement());

    internal static bool AnyPunctuationImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsPunctuationImplement());

    internal static bool AllNotPunctuationImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsPunctuationImplement());

    internal static bool AnyNotPunctuationImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotPunctuationImplement());

    #endregion

    #region Number

    internal static bool AllNumberImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotNumberImplement());

    internal static bool AnyNumberImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNumberImplement());

    internal static bool AllNotNumberImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNumberImplement());

    internal static bool AnyNotNumberImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotNumberImplement());

    #endregion

    #region Alphanumeric

    internal static bool AllAlphanumericImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotAlphanumericImplement());

    internal static bool AnyAlphanumericImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsAlphanumericImplement());

    internal static bool AllNotAlphanumericImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsAlphanumericImplement());

    internal static bool AnyNotAlphanumericImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotAlphanumericImplement());

    #endregion

    #region EqualsIgnoreCase

    internal static bool AllEqualsIgnoreCaseImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Select(static x => x.LowerInvariantImplement()).Distinct().Count() is 1;

    internal static bool AnyEqualsIgnoreCaseImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.GetCountImplement() != input.Select(static x => x.LowerInvariantImplement()).Distinct().Count();

    internal static bool AllNotEqualsIgnoreCaseImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.GetCountImplement() == input.Select(static x => x.LowerInvariantImplement()).Distinct().Count();

    internal static bool AnyNotEqualsIgnoreCaseImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Select(static x => x.LowerInvariantImplement()).Distinct().Count() is not 1;

    #endregion

    #region Lower

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

    internal static IEnumerable<char>? LowersImplement(this IEnumerable<char>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.LowerImplement());

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

    internal static IEnumerable<char>? LowerInvariantsImplement(this IEnumerable<char>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.LowerInvariantImplement());

    internal static bool AllLowersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotLowerImplement());

    internal static bool AnyLowersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsLowerImplement());

    internal static bool AllNotLowersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsLowerImplement());

    internal static bool AnyNotLowersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotLowerImplement());

    #endregion

    #region Upper

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

    internal static IEnumerable<char>? UppersImplement(this IEnumerable<char>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.UpperImplement());

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

    internal static IEnumerable<char>? UpperInvariantsImplement(this IEnumerable<char>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.UpperInvariantImplement());

    internal static bool AllUppersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotUpperImplement());

    internal static bool AnyUppersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsUpperImplement());

    internal static bool AllNotUppersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsUpperImplement());

    internal static bool AnyNotUppersImplement(this IEnumerable<char>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotUpperImplement());

    #endregion
}
