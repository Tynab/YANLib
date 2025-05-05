using System.Diagnostics;

namespace YANLib.Implementation;

internal static partial class YANText
{
    #region Empty

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsEmptyImplement(this char input) => input is char.MinValue;

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotEmptyImplement(this char input) => input is not char.MinValue;

    #endregion

    #region WhiteSpace

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsWhiteSpaceImplement(this char input) => char.IsWhiteSpace(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotWhiteSpaceImplement(this char input) => !char.IsWhiteSpace(input);

    #endregion

    #region WhiteSpaceEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsWhiteSpaceEmptyImplement(this char input) => input.IsEmptyImplement() || input.IsWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotWhiteSpaceEmptyImplement(this char input) => input.IsNotEmptyImplement() && input.IsNotWhiteSpaceImplement();

    #endregion

    #region Alphabetic

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsAlphabeticImplement(this char input) => char.IsLetter(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotAlphabeticImplement(this char input) => !char.IsLetter(input);

    #endregion

    #region Punctuation

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsPunctuationImplement(this char input) => char.IsPunctuation(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotPunctuationImplement(this char input) => !char.IsPunctuation(input);

    #endregion

    #region Number

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNumberImplement(this char input) => char.IsDigit(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNumberImplement(this char input) => !char.IsDigit(input);

    #endregion

    #region Alphanumeric

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsAlphanumericImplement(this char input) => char.IsLetterOrDigit(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotAlphanumericImplement(this char input) => !char.IsLetterOrDigit(input);

    #endregion

    #region EqualsIgnoreCase

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool EqualsIgnoreCaseImplement(this char input1, char input2) => input1.LowerInvariantImplement() == input2.LowerInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool NotEqualsIgnoreCaseImplement(this char input1, char input2) => input1.LowerInvariantImplement() != input2.LowerInvariantImplement();

    #endregion

    #region Lower

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char LowerImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToLower(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char LowerInvariantImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToLowerInvariant(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsLowerImplement(this char input) => input.IsNotWhiteSpaceEmptyImplement() && char.IsLower(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotLowerImplement(this char input) => !input.IsLowerImplement();

    #endregion

    #region Upper

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char UpperImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToUpper(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char UpperInvariantImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToUpperInvariant(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsUpperImplement(this char input) => input.IsNotWhiteSpaceEmptyImplement() && char.IsUpper(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotUpperImplement(this char input) => !input.IsUpperImplement();

    #endregion
}
