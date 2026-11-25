using System.Diagnostics.CodeAnalysis;

namespace YANLib.Implementation;

internal static partial class YANText
{
    #region NullEmpty

    internal static bool IsNullEmptyImplement([NotNullWhen(false)] this char? input) => !input.HasValue || input.Value.IsEmptyImplement();

    internal static bool IsNotNullEmptyImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNotEmptyImplement();

    #endregion

    #region NullWhiteSpace

    internal static bool IsNullWhiteSpaceImplement([NotNullWhen(false)] this char? input) => !input.HasValue || input.Value.IsEmptyImplement() || input.Value.IsWhiteSpaceImplement();

    internal static bool IsNotNullWhiteSpaceImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNotEmptyImplement() && input.Value.IsNotWhiteSpaceImplement();

    #endregion

    #region Alphabetic

    internal static bool IsAlphabeticImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsAlphabeticImplement();

    internal static bool IsNotAlphabeticImplement(this char? input) => !input.IsAlphabeticImplement();

    #endregion

    #region Punctuation

    internal static bool IsPunctuationImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsPunctuationImplement();

    internal static bool IsNotPunctuationImplement(this char? input) => !input.IsPunctuationImplement();

    #endregion

    #region Number

    internal static bool IsNumberImplement([NotNullWhen(true)] this char? input) => input.HasValue && input.Value.IsNumberImplement();

    internal static bool IsNotNumberImplement(this char? input) => !input.IsNumberImplement();

    #endregion

    #region Alphanumeric

    internal static bool IsAlphanumericImplement(this char? input) => input.HasValue && input.Value.IsAlphanumericImplement();

    internal static bool IsNotAlphanumericImplement(this char? input) => !input.IsAlphanumericImplement();

    #endregion

    #region EqualsIgnoreCase

    internal static bool EqualsIgnoreCaseImplement(this char? input1, char? input2) => input1.LowerInvariantImplement() == input2.LowerInvariantImplement();

    internal static bool NotEqualsIgnoreCaseImplement(this char? input1, char? input2) => input1.LowerInvariantImplement() != input2.LowerInvariantImplement();

    #endregion

    #region Lower

    internal static char? LowerImplement(this char? input) => input.IsNullEmptyImplement() ? input : char.ToLower(input.Value);

    internal static char? LowerInvariantImplement(this char? input) => input.IsNullEmptyImplement() ? input : char.ToLowerInvariant(input.Value);

    internal static bool IsLowerImplement(this char? input) => input.HasValue && char.IsLower(input.Value);

    internal static bool IsNotLowerImplement(this char? input) => !input.IsLowerImplement();

    #endregion

    #region Upper

    internal static char? UpperImplement(this char? input) => input.IsNullEmptyImplement() ? input : char.ToUpper(input.Value);

    internal static char? UpperInvariantImplement(this char? input) => input.IsNullEmptyImplement() ? input : char.ToUpperInvariant(input.Value);

    internal static bool IsUpperImplement(this char? input) => input.HasValue && char.IsUpper(input.Value);

    internal static bool IsNotUpperImplement(this char? input) => !input.IsUpperImplement();

    #endregion
}
