using System.Diagnostics;
using static System.MidpointRounding;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MinImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Where(static x => x is not null).Min(x => x.ParseImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MaxImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Where(static x => x is not null).Max(x => x.ParseImplement<T?>());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AverageImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Where(static x => x is not null).Average(x => x.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SumImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Sum(static x => x.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TruncateImplement<T>(this object? input) => input is null ? default : Math.Truncate(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CeilingImplement<T>(this object? input) => input is null ? default : Math.Ceiling(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? FloorImplement<T>(this object? input) => input is null ? default : Math.Floor(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? RoundImplement<T>(this object? input, object? digits = null, MidpointRounding mode = AwayFromZero)
        => input is null ? default : digits is null ? Math.Round(input.ParseImplement<double>(), mode).ParseImplement<T?>() : Math.Round(input.ParseImplement<double>(), digits.ParseImplement<int>(), mode).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SqrtImplement<T>(this object? input) => input is null ? default : Math.Sqrt(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? PowImplement<T>(this object? input, object? power) => input is null || power is null ? default : Math.Pow(input.ParseImplement<double>(), power.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AbsImplement<T>(this object? input) => input is null ? default : Math.Abs(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SinImplement<T>(this object? input) => input is null ? default : Math.Sin(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CosImplement<T>(this object? input) => input is null ? default : Math.Cos(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TanImplement<T>(this object? input) => input is null ? default : Math.Tan(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AsinImplement<T>(this object? input) => input is null ? default : Math.Asin(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AcosImplement<T>(this object? input) => input is null ? default : Math.Acos(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AtanImplement<T>(this object? input) => input is null ? default : Math.Atan(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CbrtImplement<T>(this object? input) => input is null ? default : Math.Cbrt(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ExpImplement<T>(this object? input) => input is null ? default : Math.Exp(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Exp2Implement<T>(this object? input) => input is null ? default : Math.Pow(2, input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? LogImplement<T>(this object? input, object? baseValue = null)
        => input is null ? default : baseValue is null ? Math.Log(input.ParseImplement<double>()).ParseImplement<T?>() : Math.Log(input.ParseImplement<double>(), baseValue.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log10Implement<T>(this object? input) => input is null ? default : Math.Log10(input.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log2Implement<T>(this object? input) => input is null ? default : Math.Log(input.ParseImplement<double>(), 2).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ILogBImplement<T>(this object? input) => input is null ? default : Math.ILogB(input.ParseImplement<double>()).ParseImplement<T?>();
}
