using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANText
{
    #region NullEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty(this IEnumerable<char?>? input) => input.AllNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty(params char?[] input) => input.AllNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty(this IEnumerable<char?>? input) => input.AnyNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty(params char?[] input) => input.AnyNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty(this IEnumerable<char?>? input) => input.AllNotNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty(params char?[] input) => input.AllNotNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty(this IEnumerable<char?>? input) => input.AnyNotNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty(params char?[] input) => input.AnyNotNullEmptyImplement();

    #endregion

    #region NullWhiteSpace

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullWhiteSpace(this IEnumerable<char?>? input) => input.AllNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullWhiteSpace(params char?[] input) => input.AllNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullWhiteSpace(this IEnumerable<char?>? input) => input.AnyNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullWhiteSpace(params char?[] input) => input.AnyNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullWhiteSpace(this IEnumerable<char?>? input) => input.AllNotNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullWhiteSpace(params char?[] input) => input.AllNotNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullWhiteSpace(this IEnumerable<char?>? input) => input.AnyNotNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullWhiteSpace(params char?[] input) => input.AnyNotNullWhiteSpaceImplement();

    #endregion

    #region Alphabetic

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphabetic(this IEnumerable<char?>? input) => input.AllAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphabetic(params char?[] input) => input.AllAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphabetic(this IEnumerable<char?>? input) => input.AnyAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphabetic(params char?[] input) => input.AnyAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphabetic(this IEnumerable<char?>? input) => input.AllNotAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphabetic(params char?[] input) => input.AllNotAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphabetic(this IEnumerable<char?>? input) => input.AnyNotAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphabetic(params char?[] input) => input.AnyNotAlphabeticImplement();

    #endregion

    #region Punctuation

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPunctuation(this IEnumerable<char?>? input) => input.AllPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPunctuation(params char?[] input) => input.AllPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPunctuation(this IEnumerable<char?>? input) => input.AnyPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPunctuation(params char?[] input) => input.AnyPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotPunctuation(this IEnumerable<char?>? input) => input.AllNotPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotPunctuation(params char?[] input) => input.AllNotPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotPunctuation(this IEnumerable<char?>? input) => input.AnyNotPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotPunctuation(params char?[] input) => input.AnyNotPunctuationImplement();

    #endregion

    #region Number

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNumber(this IEnumerable<char?>? input) => input.AllNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNumber(params char?[] input) => input.AllNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNumber(this IEnumerable<char?>? input) => input.AnyNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNumber(params char?[] input) => input.AnyNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNumber(this IEnumerable<char?>? input) => input.AllNotNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNumber(params char?[] input) => input.AllNotNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNumber(this IEnumerable<char?>? input) => input.AnyNotNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNumber(params char?[] input) => input.AnyNotNumberImplement();

    #endregion

    #region Alphanumeric

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphanumeric(this IEnumerable<char?>? input) => input.AllAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllAlphanumeric(params char?[] input) => input.AllAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphanumeric(this IEnumerable<char?>? input) => input.AnyAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyAlphanumeric(params char?[] input) => input.AnyAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphanumeric(this IEnumerable<char?>? input) => input.AllNotAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotAlphanumeric(params char?[] input) => input.AllNotAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphanumeric(this IEnumerable<char?>? input) => input.AnyNotAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotAlphanumeric(params char?[] input) => input.AnyNotAlphanumericImplement();

    #endregion

    #region EqualsIgnoreCase

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(this IEnumerable<char?>? input) => input.AllEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(params char?[] input) => input.AllEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(this IEnumerable<char?>? input) => input.AnyEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(params char?[] input) => input.AnyEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(this IEnumerable<char?>? input) => input.AllNotEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(params char?[] input) => input.AllNotEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<char?>? input) => input.AnyNotEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(params char?[] input) => input.AnyNotEqualsIgnoreCaseImplement();

    #endregion

    #region Lower

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Lower(this List<char?>? input) => input.LowerImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? Lowers(this IEnumerable<char?>? input) => input.LowersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? Lowers(params char?[]? input) => input.LowersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void LowerInvariant(this List<char?>? input) => input.LowerInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? LowerInvariants(this IEnumerable<char?>? input) => input.LowerInvariantsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? LowerInvariants(params char?[]? input) => input.LowerInvariantsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllLowers(this IEnumerable<char?>? input) => input.AllLowersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllLowers(params char?[]? input) => input.AllLowersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyLowers(this IEnumerable<char?>? input) => input.AnyLowersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyLowers(params char?[]? input) => input.AnyLowersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotLowers(this IEnumerable<char?>? input) => input.AllNotLowersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotLowers(params char?[]? input) => input.AllNotLowersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotLowers(this IEnumerable<char?>? input) => input.AnyNotLowersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotLowers(params char?[]? input) => input.AnyNotLowersImplement();

    #endregion

    #region Upper

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Upper(this List<char?>? input) => input.UpperImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? Uppers(this IEnumerable<char?>? input) => input.UppersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? Uppers(params char?[]? input) => input.UppersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void UpperInvariant(this List<char?>? input) => input.UpperInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? UpperInvariants(this IEnumerable<char?>? input) => input.UpperInvariantsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<char?>? UpperInvariants(params char?[]? input) => input.UpperInvariantsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllUppers(this IEnumerable<char?>? input) => input.AllUppersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllUppers(params char?[] input) => input.AllUppersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyUppers(this IEnumerable<char?>? input) => input.AnyUppersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyUppers(params char?[] input) => input.AnyUppersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotUppers(this IEnumerable<char?>? input) => input.AllNotUppersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotUppers(params char?[] input) => input.AllNotUppersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotUppers(this IEnumerable<char?>? input) => input.AnyNotUppersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotUppers(params char?[] input) => input.AnyNotUppersImplement();

    #endregion
}
