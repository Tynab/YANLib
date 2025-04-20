using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation.Object;
using YANLib.Implementation.Text;

namespace YANLib.Text;

public static partial class YANText
{
    #region Null

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull(this IEnumerable<string?> input) => input.AllNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull(params string?[] input) => input.AllNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull(this IEnumerable<string?> input) => input.AnyNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull(params string?[] input) => input.AnyNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull(this IEnumerable<string?> input) => input.AllNotNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull(params string?[] input) => input.AllNotNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull(this IEnumerable<string?> input) => input.AnyNotNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull(params string?[] input) => input.AnyNotNullImplement();

    #endregion

    #region NullEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullEmpty([NotNullWhen(false)] this string? input) => input.IsNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty(this IEnumerable<string?> input) => input.AllNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty(params string?[] input) => input.AllNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty(this IEnumerable<string?> input) => input.AnyNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty(params string?[] input) => input.AnyNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullEmpty([NotNullWhen(true)] this string? input) => input.IsNotNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty(this IEnumerable<string?> input) => input.AllNotNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty(params string?[] input) => input.AllNotNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty(this IEnumerable<string?> input) => input.AnyNotNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty(params string?[] input) => input.AnyNotNullEmptyImplement();

    #endregion

    #region NullWhiteSpace

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullWhiteSpace([NotNullWhen(false)] this string? input) => input.IsNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullWhiteSpace(this IEnumerable<string?> input) => input.AllNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullWhiteSpace(params string?[] input) => input.AllNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullWhiteSpace(this IEnumerable<string?> input) => input.AnyNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullWhiteSpace(params string?[] input) => input.AnyNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullWhiteSpace([NotNullWhen(true)] this string? input) => input.IsNotNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullWhiteSpace(this IEnumerable<string?> input) => input.AllNotNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullWhiteSpace(params string?[] input) => input.AllNotNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullWhiteSpace(this IEnumerable<string?> input) => input.AnyNotNullWhiteSpaceImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullWhiteSpace(params string?[] input) => input.AnyNotNullWhiteSpaceImplement();

    #endregion

    #region EqualsIgnoreCase

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool EqualsIgnoreCase(this string? input1, string? input2) => input1.EqualsIgnoreCaseImplement(input2);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(this IEnumerable<string?> input) => input.AllEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllEqualsIgnoreCase(params string?[] input) => input.AllEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(this IEnumerable<string?> input) => input.AnyEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyEqualsIgnoreCase(params string?[] input) => input.AnyEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool NotEqualsIgnoreCase(this string? input1, string? input2) => input1.NotEqualsIgnoreCaseImplement(input2);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(this IEnumerable<string?> input) => input.AllNotEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotEqualsIgnoreCase(params string?[] input) => input.AllNotEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(this IEnumerable<string?> input) => input.AnyNotEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotEqualsIgnoreCase(params string?[] input) => input.AnyNotEqualsIgnoreCaseImplement();

    #endregion

    #region Lower

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Lower(this string? input) => input.LowerImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Lower(this List<string?>? input) => input.LowerImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Lowers(this IEnumerable<string?>? input) => input.LowersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Lowers(params string?[]? input) => input.LowersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? LowerInvariant(this string? input) => input.LowerInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void LowerInvariant(this List<string?>? input) => input.LowerInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? LowerInvariants(this IEnumerable<string?>? input) => input.LowerInvariantsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? LowerInvariants(params string?[]? input) => input.LowerInvariantsImplement();

    #endregion

    #region Upper

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Upper(this string? input) => input.UpperImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Upper(this List<string?>? input) => input.UpperImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Uppers(this IEnumerable<string?>? input) => input.UppersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Uppers(params string?[]? input) => input.UppersImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? UpperInvariant(this string? input) => input.UpperInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void UpperInvariant(this List<string?>? input) => input.UpperInvariantImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? UpperInvariants(this IEnumerable<string?>? input) => input.UpperInvariantsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? UpperInvariants(params string?[]? input) => input.UpperInvariantsImplement();

    #endregion
}
