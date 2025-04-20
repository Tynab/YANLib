using System.Diagnostics;
using YANLib.Implementation.Object;
using YANLib.Implementation.Unmanaged;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MinImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : input.Where(x => x.IsNotNullImplement()).Min(x => x.ParseImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MaxImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : input.Where(x => x.IsNotNullImplement()).Max(x => x.ParseImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AverageImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : input.Where(x => x.IsNotNullImplement()).Average(x => x.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SumImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : input.Sum(x => x.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TruncateImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Truncate(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? TruncatesImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.TruncateImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CeilingImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Ceiling(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CeilingsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.CeilingImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? FloorImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Floor(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? FloorsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.FloorImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? RoundImplement<T>(this T? input, object? digits = null)
        => input.IsNullImplement() ? input : digits.IsNullImplement() ? Math.Round(input.ParseImplement<double>()).ParseImplement<T?>() : Math.Round(input.ParseImplement<double>(), digits.ParseImplement<int>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? RoundsImplement<T>(this IEnumerable<T?>? input, object? digits = null) => input.IsNullEmptyImplement() ? input : input.Select(x => x.RoundImplement(digits));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SqrtImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Sqrt(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? SqrtsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.SqrtImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? PowImplement<T>(this T? input, object? power) => input.IsNullImplement() || power.IsNullImplement() ? default : Math.Pow(input.ParseImplement<double>(), power.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? PowsImplement<T>(this IEnumerable<T?>? input, object? power) => input.IsNullEmptyImplement() ? input : input.Select(x => x.PowImplement(power));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AbsImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Abs(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AbssImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AbsImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? LogImplement<T>(this T? input, object? baseValue = null)
        => input.IsNullImplement() ? input : baseValue.IsNullImplement() ? Math.Log(input.ParseImplement<double>()).ParseImplement<T?>() : Math.Log(input.ParseImplement<double>(), baseValue.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? LogsImplement<T>(this IEnumerable<T?>? input, object? baseValue = null) => input.IsNullEmptyImplement() ? input : input.Select(x => x.LogImplement(baseValue));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log10Implement<T>(this T? input) => input.IsNullImplement() ? input : Math.Log10(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Log10sImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.Log10Implement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log2Implement<T>(this T? input) => input.IsNullImplement() ? input : Math.Log(input.ParseImplement<double>(), 2).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Log2sImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.Log2Implement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SinImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Sin(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? SinsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.SinImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CosImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Cos(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CossImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.CosImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TanImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Tan(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? TansImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.TanImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AsinImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Asin(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AsinsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AsinImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AcosImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Acos(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AcossImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AcosImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AtanImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Atan(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? AtansImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AtanImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CbrtImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Cbrt(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? CbrtsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.CbrtImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ExpImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.Exp(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ExpsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.ExpImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Exp2Implement<T>(this T? input) => input.IsNullImplement() ? input : Math.Pow(2, input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? Exp2sImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.Exp2Implement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ILogBImplement<T>(this T? input) => input.IsNullImplement() ? input : Math.ILogB(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ILogBsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.ILogBImplement());
}
