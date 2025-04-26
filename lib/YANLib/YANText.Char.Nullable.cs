using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANText
{
    #region NullEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullEmpty([NotNullWhen(false)] this char? input) => input.IsNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullEmpty([NotNullWhen(true)] this char? input) => input.IsNotNullEmptyImplement();

    #endregion

    #region NullWhiteSpace

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullWhiteSpace([NotNullWhen(false)] this char? input) => input.IsNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullWhiteSpace([NotNullWhen(true)] this char? input) => input.IsNotNullWhiteSpaceImplement();

    #endregion

    #region Alphabetic

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsAlphabetic([NotNullWhen(true)] this char? input) => input.IsAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotAlphabetic(this char? input) => input.IsNotAlphabeticImplement();

    #endregion

    #region Punctuation

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsPunctuation([NotNullWhen(true)] this char? input) => input.IsPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotPunctuation(this char? input) => input.IsNotPunctuationImplement();

    #endregion

    #region Number

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNumber([NotNullWhen(true)] this char? input) => input.IsNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNumber(this char? input) => input.IsNotNumberImplement();

    #endregion

    #region Alphanumeric

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsAlphanumeric(this char? input) => input.IsAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotAlphanumeric(this char? input) => input.IsNotAlphanumericImplement();

    #endregion

    #region EqualsIgnoreCase

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool EqualsIgnoreCase(this char? input1, char? input2) => input1.EqualsIgnoreCaseImplement(input2);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool NotEqualsIgnoreCase(this char? input1, char? input2) => input1.NotEqualsIgnoreCaseImplement(input2);

    #endregion

    #region Lower

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? Lower(this char? input) => input.LowerImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? LowerInvariant(this char? input) => input.LowerInvariantImplement();

    #endregion

    #region Upper

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? Upper(this char? input) => input.UpperImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static char? UpperInvariant(this char? input) => input.UpperInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsUpper(this char? input) => input.IsUpperImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotUpper(this char? input) => input.IsNotUpperImplement();

    #endregion
}
