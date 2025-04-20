using System.Diagnostics;
using YANLib.Implementation.Object;
using YANLib.Implementation.Unmanaged;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MinImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Where(x => x.IsNotNullImplement()).Min(x => x.ParseImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MaxImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Where(x => x.IsNotNullImplement()).Max(x => x.ParseImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AverageImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Where(x => x.IsNotNullImplement()).Average(x => x.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SumImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Sum(x => x.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TruncateImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Truncate(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? TruncatesImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.TruncateImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CeilingImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Ceiling(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CeilingsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.CeilingImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? FloorImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Floor(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? FloorsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.FloorImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? RoundImplement<T>(this object? input, object? digits = null)
        => input.IsNullImplement() ? default : digits.IsNullImplement() ? Math.Round(input.ParseImplement<double>()).ParseImplement<T?>() : Math.Round(input.ParseImplement<double>(), digits.ParseImplement<int>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? RoundsImplement<T>(this IEnumerable<object?>? input, object? digits = null) => input.IsNullEmptyImplement() ? default : input.Select(x => x.RoundImplement<T>(digits));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SqrtImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Sqrt(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? SqrtsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.SqrtImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? PowImplement<T>(this object? input, object? power) => input.IsNullImplement() || power.IsNullImplement() ? default : Math.Pow(input.ParseImplement<double>(), power.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? PowsImplement<T>(this IEnumerable<object?>? input, object? power) => input.IsNullEmptyImplement() ? default : input.Select(x => x.PowImplement<T>(power));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AbsImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Abs(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AbssImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.AbsImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? LogImplement<T>(this object? input, object? baseValue = null)
        => input.IsNullImplement() ? default : baseValue.IsNullImplement() ? Math.Log(input.ParseImplement<double>()).ParseImplement<T?>() : Math.Log(input.ParseImplement<double>(), baseValue.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? LogsImplement<T>(this IEnumerable<object?>? input, object? baseValue = null) => input.IsNullEmptyImplement() ? default : input.Select(x => x.LogImplement<T>(baseValue));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log10Implement<T>(this object? input) => input.IsNullImplement() ? default : Math.Log10(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Log10sImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.Log10Implement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log2Implement<T>(this object? input) => input.IsNullImplement() ? default : Math.Log(input.ParseImplement<double>(), 2).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Log2sImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.Log2Implement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SinImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Sin(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? SinsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.SinImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CosImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Cos(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CossImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.CosImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TanImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Tan(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? TansImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.TanImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AsinImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Asin(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AsinsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.AsinImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AcosImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Acos(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AcossImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.AcosImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AtanImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Atan(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AtansImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.AtanImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CbrtImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Cbrt(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CbrtsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.CbrtImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ExpImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.Exp(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ExpsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.ExpImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Exp2Implement<T>(this object? input) => input.IsNullImplement() ? default : Math.Pow(2, input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Exp2sImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.Exp2Implement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ILogBImplement<T>(this object? input) => input.IsNullImplement() ? default : Math.ILogB(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ILogBsImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(static x => x.ILogBImplement<T?>());
}
