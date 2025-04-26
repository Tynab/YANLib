using System.Diagnostics;
using static System.MidpointRounding;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? TruncatesImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.TruncateImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CeilingsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.CeilingImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? FloorsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.FloorImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? RoundsImplement<T>(this IEnumerable<object?>? input, object? digits = null, MidpointRounding mode = AwayFromZero)
        => input.IsNullEmptyImplement() ? default : input.Select(x => x.RoundImplement<T>(digits, mode));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? SqrtsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.SqrtImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? PowsImplement<T>(this IEnumerable<object?>? input, object? power) => input.IsNullEmptyImplement() ? default : input.Select(x => x.PowImplement<T>(power));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AbssImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.AbsImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? LogsImplement<T>(this IEnumerable<object?>? input, object? baseValue = null) => input.IsNullEmptyImplement() ? default : input.Select(x => x.LogImplement<T>(baseValue));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Log10sImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.Log10Implement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Log2sImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.Log2Implement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? SinsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.SinImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CossImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.CosImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? TansImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.TanImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AsinsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.AsinImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AcossImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.AcosImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AtansImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.AtanImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CbrtsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.CbrtImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ExpsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.ExpImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Exp2sImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.Exp2Implement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ILogBsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.ILogBImplement<T?>());
}
