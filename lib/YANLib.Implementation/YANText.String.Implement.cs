using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using static System.StringComparison;

namespace YANLib.Implementation;

internal static partial class YANText
{
    #region NullEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullEmptyImplement([NotNullWhen(false)] this string? input) => string.IsNullOrEmpty(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullEmptyImplement([NotNullWhen(true)] this string? input) => !input.IsNullEmptyImplement();

    #endregion

    #region NullWhiteSpace

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullWhiteSpaceImplement([NotNullWhen(false)] this string? input) => string.IsNullOrWhiteSpace(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullWhiteSpaceImplement([NotNullWhen(true)] this string? input) => !input.IsNullWhiteSpaceImplement();

    #endregion

    #region EqualsIgnoreCase

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool EqualsIgnoreCaseImplement(this string? input1, string? input2) => string.Equals(input1, input2, OrdinalIgnoreCase);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool NotEqualsIgnoreCaseImplement(this string? input1, string? input2) => !input1.EqualsIgnoreCaseImplement(input2);

    #endregion

    #region Lower

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? LowerImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToLower();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? LowerInvariantImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToLower(CultureInfo.InvariantCulture);

    #endregion

    #region Upper

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? UpperImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToUpper();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? UpperInvariantImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToUpper(CultureInfo.InvariantCulture);

    #endregion
}
