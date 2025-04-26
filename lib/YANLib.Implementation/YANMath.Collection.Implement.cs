using System.Diagnostics;
using static System.MidpointRounding;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? TruncatesImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.TruncateImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? TruncatesImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().TruncatesImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CeilingsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.CeilingImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CeilingsImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().CeilingsImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? FloorsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.FloorImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? FloorsImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().FloorsImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? RoundsImplement<T>(this IEnumerable<T?>? input, object? digits = null, MidpointRounding mode = AwayFromZero)
        => input.IsNullEmptyImplement() ? input : input.Select(x => x.RoundImplement(digits, mode));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? RoundsImplement<T>(this System.Collections.IEnumerable input, object? digits = null, MidpointRounding mode = AwayFromZero)
        => input.IsNullImplement() ? default : input.Cast<object?>().RoundsImplement<T?>(digits, mode);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? SqrtsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.SqrtImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? SqrtsImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().SqrtsImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? PowsImplement<T>(this IEnumerable<T?>? input, object? power) => input.IsNullEmptyImplement() ? input : input.Select(x => x.PowImplement(power));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? PowsImplement<T>(this System.Collections.IEnumerable input, object? power) => input.IsNullImplement() ? default : input.Cast<object?>().PowsImplement<T?>(power);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AbssImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AbsImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AbssImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().AbssImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? LogsImplement<T>(this IEnumerable<T?>? input, object? baseValue = null) => input.IsNullEmptyImplement() ? input : input.Select(x => x.LogImplement(baseValue));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? LogsImplement<T>(this System.Collections.IEnumerable input, object? baseValue = null) => input.IsNullImplement() ? default : input.Cast<object?>().LogsImplement<T?>(baseValue);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Log10sImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.Log10Implement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Log10sImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().Log10sImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Log2sImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.Log2Implement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Log2sImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().Log2sImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? SinsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.SinImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? SinsImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().SinsImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CossImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.CosImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CossImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().CossImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? TansImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.TanImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? TansImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().TansImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AsinsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AsinImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AsinsImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().AsinsImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AcossImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AcosImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AcossImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().AcossImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AtansImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AtanImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AtansImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().AtansImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CbrtsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.CbrtImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CbrtsImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().CbrtsImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ExpsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.ExpImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ExpsImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().ExpsImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Exp2sImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.Exp2Implement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Exp2sImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().Exp2sImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ILogBsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.ILogBImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ILogBsImplement<T>(this System.Collections.IEnumerable input) => input.IsNullImplement() ? default : input.Cast<object?>().ILogBsImplement<T?>();
}
