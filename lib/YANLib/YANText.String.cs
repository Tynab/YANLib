using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANText
{
    #region NullEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullEmpty([NotNullWhen(false)] this string? input) => input.IsNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullEmpty([NotNullWhen(true)] this string? input) => input.IsNotNullEmptyImplement();

    #endregion

    #region NullWhiteSpace

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullWhiteSpace([NotNullWhen(false)] this string? input) => input.IsNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullWhiteSpace([NotNullWhen(true)] this string? input) => input.IsNotNullWhiteSpaceImplement();

    #endregion

    #region EqualsIgnoreCase

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool EqualsIgnoreCase(this string? input1, string? input2) => input1.EqualsIgnoreCaseImplement(input2);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool NotEqualsIgnoreCase(this string? input1, string? input2) => input1.NotEqualsIgnoreCaseImplement(input2);

    #endregion

    #region Lower

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Lower(this string? input) => input.LowerImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? LowerInvariant(this string? input) => input.LowerInvariantImplement();

    #endregion

    #region Upper

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Upper(this string? input) => input.UpperImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? UpperInvariant(this string? input) => input.UpperInvariantImplement();

    #endregion
}
