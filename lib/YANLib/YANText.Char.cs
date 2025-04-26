using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANText
{
    #region Empty

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsEmpty(this char input) => input.IsEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotEmpty(this char input) => input.IsNotEmptyImplement();

    #endregion

    #region WhiteSpace

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsWhiteSpace(this char input) => input.IsWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotWhiteSpace(this char input) => input.IsNotWhiteSpaceImplement();

    #endregion

    #region WhiteSpaceEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsWhiteSpaceEmpty(this char input) => input.IsWhiteSpaceEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotWhiteSpaceEmpty(this char input) => input.IsNotWhiteSpaceEmptyImplement();

    #endregion

    #region Alphabetic

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsAlphabetic(this char input) => input.IsAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotAlphabetic(this char input) => input.IsNotAlphabeticImplement();

    #endregion

    #region Punctuation

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsPunctuation(this char input) => input.IsPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotPunctuation(this char input) => input.IsNotPunctuationImplement();

    #endregion

    #region Number

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNumber(this char input) => input.IsNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNumber(this char input) => input.IsNotNumberImplement();

    #endregion

    #region Alphanumeric

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsAlphanumeric(this char input) => input.IsAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotAlphanumeric(this char input) => input.IsNotAlphanumericImplement();

    #endregion

    #region EqualsIgnoreCase

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool EqualsIgnoreCase(this char input1, char input2) => input1.EqualsIgnoreCaseImplement(input2);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool NotEqualsIgnoreCase(this char input1, char input2) => input1.NotEqualsIgnoreCaseImplement(input2);

    #endregion

    #region Lower

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char Lower(this char input) => input.LowerImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char LowerInvariant(this char input) => input.LowerInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsLower(this char input) => input.IsLowerImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotLower(this char input) => input.IsNotLowerImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsLower(this char? input) => input.IsLowerImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotLower(this char? input) => input.IsNotLowerImplement();

    #endregion

    #region Upper

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char Upper(this char input) => input.UpperImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char UpperInvariant(this char input) => input.UpperInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsUpper(this char input) => input.IsUpperImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotUpper(this char input) => input.IsNotUpperImplement();

    #endregion
}
