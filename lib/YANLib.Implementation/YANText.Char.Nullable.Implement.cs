using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace YANLib.Implementation;

internal static partial class YANText
{
    #region NullEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullEmptyImplement([NotNullWhen(false)] this char? input) => !input.HasValue || input.Value.IsEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullEmptyImplement([NotNullWhen(true)] this char? input) => !input.IsNullEmptyImplement();

    #endregion

    #region NullWhiteSpace

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullWhiteSpaceImplement([NotNullWhen(false)] this char? input) => !input.HasValue || input.Value.IsEmptyImplement() || input.Value.IsWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullWhiteSpaceImplement([NotNullWhen(true)] this char? input) => !input.IsNullWhiteSpaceImplement();

    #endregion

    #region Alphabetic

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsAlphabeticImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsAlphabeticImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotAlphabeticImplement(this char? input) => !input.IsAlphabeticImplement();

    #endregion

    #region Punctuation

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsPunctuationImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsPunctuationImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotPunctuationImplement(this char? input) => !input.IsPunctuationImplement();

    #endregion

    #region Number

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNumberImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNumberImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNumberImplement(this char? input) => !input.IsNumberImplement();

    #endregion

    #region Alphanumeric

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsAlphanumericImplement(this char? input) => input.HasValue && input.Value.IsAlphanumericImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotAlphanumericImplement(this char? input) => !input.IsAlphanumericImplement();

    #endregion

    #region EqualsIgnoreCase

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool EqualsIgnoreCaseImplement(this char? input1, char? input2) => input1.LowerInvariantImplement() == input2.LowerInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool NotEqualsIgnoreCaseImplement(this char? input1, char? input2) => !input1.EqualsIgnoreCaseImplement(input2);

    #endregion

    #region Lower

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char? LowerImplement(this char? input) => input.IsNullEmptyImplement() ? input : char.ToLower(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char? LowerInvariantImplement(this char? input) => input.IsNullEmptyImplement() ? input : char.ToLowerInvariant(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsLowerImplement(this char? input) => input.HasValue && char.IsLower(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotLowerImplement(this char? input) => !input.IsLowerImplement();

    #endregion

    #region Upper

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char? UpperImplement(this char? input) => input.IsNullEmptyImplement() ? input : char.ToUpper(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static char? UpperInvariantImplement(this char? input) => input.IsNullEmptyImplement() ? input : char.ToUpperInvariant(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsUpperImplement(this char? input) => input.HasValue && char.IsUpper(input.Value);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotUpperImplement(this char? input) => !input.IsUpperImplement();

    #endregion
}
