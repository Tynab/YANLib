
namespace YANLib.Implementation;

internal static partial class YANText
{
    #region Empty

    internal static bool IsEmptyImplement(this char input) => input is char.MinValue;

    internal static bool IsNotEmptyImplement(this char input) => input is not char.MinValue;

    #endregion

    #region WhiteSpace

    internal static bool IsWhiteSpaceImplement(this char input) => char.IsWhiteSpace(input);

    internal static bool IsNotWhiteSpaceImplement(this char input) => !char.IsWhiteSpace(input);

    #endregion

    #region WhiteSpaceEmpty

    internal static bool IsWhiteSpaceEmptyImplement(this char input) => input.IsEmptyImplement() || input.IsWhiteSpaceImplement();

    internal static bool IsNotWhiteSpaceEmptyImplement(this char input) => input.IsNotEmptyImplement() && input.IsNotWhiteSpaceImplement();

    #endregion

    #region Alphabetic

    internal static bool IsAlphabeticImplement(this char input) => char.IsLetter(input);

    internal static bool IsNotAlphabeticImplement(this char input) => !char.IsLetter(input);

    #endregion

    #region Punctuation

    internal static bool IsPunctuationImplement(this char input) => char.IsPunctuation(input);

    internal static bool IsNotPunctuationImplement(this char input) => !char.IsPunctuation(input);

    #endregion

    #region Number

    internal static bool IsNumberImplement(this char input) => char.IsDigit(input);

    internal static bool IsNotNumberImplement(this char input) => !char.IsDigit(input);

    #endregion

    #region Alphanumeric

    internal static bool IsAlphanumericImplement(this char input) => char.IsLetterOrDigit(input);

    internal static bool IsNotAlphanumericImplement(this char input) => !char.IsLetterOrDigit(input);

    #endregion

    #region EqualsIgnoreCase

    internal static bool EqualsIgnoreCaseImplement(this char input1, char input2) => input1.LowerInvariantImplement() == input2.LowerInvariantImplement();

    internal static bool NotEqualsIgnoreCaseImplement(this char input1, char input2) => input1.LowerInvariantImplement() != input2.LowerInvariantImplement();

    #endregion

    #region Lower

    internal static char LowerImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToLower(input);

    internal static char LowerInvariantImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToLowerInvariant(input);

    internal static bool IsLowerImplement(this char input) => input.IsNotWhiteSpaceEmptyImplement() && char.IsLower(input);

    internal static bool IsNotLowerImplement(this char input) => !input.IsLowerImplement();

    #endregion

    #region Upper

    internal static char UpperImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToUpper(input);

    internal static char UpperInvariantImplement(this char input) => input.IsWhiteSpaceEmptyImplement() ? input : char.ToUpperInvariant(input);

    internal static bool IsUpperImplement(this char input) => input.IsNotWhiteSpaceEmptyImplement() && char.IsUpper(input);

    internal static bool IsNotUpperImplement(this char input) => !input.IsUpperImplement();

    #endregion
}
