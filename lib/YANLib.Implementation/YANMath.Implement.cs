using System.Diagnostics;
using static System.MidpointRounding;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MinImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : input.Where(static x => x is not null).Min(x => x.ParseImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MinImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().MinImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MaxImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : input.Where(static x => x is not null).Max(x => x.ParseImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MaxImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().MaxImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AverageImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : input.Where(static x => x is not null).Average(x => x.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AverageImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().AverageImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SumImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : input.Sum(static x => x.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SumImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().SumImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TruncateImplement<T>(this T? input) => input is null ? input : Math.Truncate(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CeilingImplement<T>(this T? input) => input is null ? input : Math.Ceiling(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? FloorImplement<T>(this T? input) => input is null ? input : Math.Floor(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? RoundImplement<T>(this T? input, object? digits = null, MidpointRounding mode = AwayFromZero)
        => input is null ? input : digits is null ? Math.Round(input.ParseImplement<double>(), mode).ParseImplement<T?>() : Math.Round(input.ParseImplement<double>(), digits.ParseImplement<int>(), mode).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SqrtImplement<T>(this T? input) => input is null ? input : Math.Sqrt(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? PowImplement<T>(this T? input, object? power) => input is null || power is null ? default : Math.Pow(input.ParseImplement<double>(), power.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AbsImplement<T>(this T? input) => input is null ? input : Math.Abs(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SinImplement<T>(this T? input) => input is null ? input : Math.Sin(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CosImplement<T>(this T? input) => input is null ? input : Math.Cos(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TanImplement<T>(this T? input) => input is null ? input : Math.Tan(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AsinImplement<T>(this T? input) => input is null ? input : Math.Asin(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AcosImplement<T>(this T? input) => input is null ? input : Math.Acos(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AtanImplement<T>(this T? input) => input is null ? input : Math.Atan(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CbrtImplement<T>(this T? input) => input is null ? input : Math.Cbrt(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ExpImplement<T>(this T? input) => input is null ? input : Math.Exp(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Exp2Implement<T>(this T? input) => input is null ? input : Math.Pow(2, input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? LogImplement<T>(this T? input, object? baseValue = null)
        => input is null ? input : baseValue is null ? Math.Log(input.ParseImplement<double>()).ParseImplement<T?>() : Math.Log(input.ParseImplement<double>(), baseValue.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log10Implement<T>(this T? input) => input is null ? input : Math.Log10(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log2Implement<T>(this T? input) => input is null ? input : Math.Log(input.ParseImplement<double>(), 2).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ILogBImplement<T>(this T? input) => input is null ? input : Math.ILogB(input.ParseImplement<double>()).ParseImplement<T?>();
}
