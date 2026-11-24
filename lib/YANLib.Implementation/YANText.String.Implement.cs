using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using static System.StringComparison;

namespace YANLib.Implementation;

internal static partial class YANText
{
    #region NullEmpty

    internal static bool IsNullEmptyImplement([NotNullWhen(false)] this string? input) => string.IsNullOrEmpty(input);

    internal static bool IsNotNullEmptyImplement([NotNullWhen(true)] this string? input) => !string.IsNullOrEmpty(input);

    #endregion

    #region NullWhiteSpace

    internal static bool IsNullWhiteSpaceImplement([NotNullWhen(false)] this string? input) => string.IsNullOrWhiteSpace(input);

    internal static bool IsNotNullWhiteSpaceImplement([NotNullWhen(true)] this string? input) => !string.IsNullOrWhiteSpace(input);

    #endregion

    #region EqualsIgnoreCase

    internal static bool EqualsIgnoreCaseImplement(this string? input1, string? input2) => string.Equals(input1, input2, OrdinalIgnoreCase);

    internal static bool NotEqualsIgnoreCaseImplement(this string? input1, string? input2) => !string.Equals(input1, input2, OrdinalIgnoreCase);

    #endregion

    #region Lower

    internal static string? LowerImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToLower();

    internal static string? LowerInvariantImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToLower(CultureInfo.InvariantCulture);

    #endregion

    #region Upper

    internal static string? UpperImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToUpper();

    internal static string? UpperInvariantImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToUpper(CultureInfo.InvariantCulture);

    #endregion
}
