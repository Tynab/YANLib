using System.Diagnostics;
using static System.MidpointRounding;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MinImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : MinMax(input, false);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MinImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().MinImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MaxImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : MinMax(input, true);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MaxImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().MaxImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AverageImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : AverageNumber(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AverageImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().AverageImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SumImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? default : SumNumber(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SumImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().SumImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TruncateImplement<T>(this T? input) => Exact(input, Math.Truncate, decimal.Truncate, false);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CeilingImplement<T>(this T? input) => Exact(input, Math.Ceiling, decimal.Ceiling, false);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? FloorImplement<T>(this T? input) => Exact(input, Math.Floor, decimal.Floor, false);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? RoundImplement<T>(this T? input, object? digits = null, MidpointRounding mode = AwayFromZero)
    {
        if (input is null)
        {
            return input;
        }

        var kind = KindOf<T>();

        if (kind == NumberKind.Other)
        {
            return ((object?)input).RoundImplement<T>(digits, mode);
        }

        var places = ParseDigits(digits);

        if (IsBinaryFloatingPoint(kind))
        {
            return FromDouble<T>(RoundDouble(ToDouble(input), places, mode));
        }

        if (!IsValidRound(places, mode))
        {
            // Math.Round throws the ArgumentOutOfRangeException or ArgumentException that 8.3.3 threw for every type
            _ = RoundDouble(0, places, mode);
        }

        // an integer is already rounded to any number of digits
        return kind == NumberKind.Decimal ? As<decimal, T>(Normalize(RoundDecimal(As<T, decimal>(input), places, mode))) : input;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SqrtImplement<T>(this T? input) => Unary(input, Math.Sqrt);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? PowImplement<T>(this T? input, object? power)
    {
        if (input is null || power is null)
        {
            return default;
        }

        var kind = KindOf<T>();

        if (kind == NumberKind.Other)
        {
            return ((object?)input).PowImplement<T>(power);
        }

        var exponent = power.ParseImplement<double>();

        if (IsBinaryFloatingPoint(kind))
        {
            return FromDouble<T>(Math.Pow(ToDouble(input), exponent));
        }

        if (IsInteger(kind))
        {
            return TryPowInteger(ToInt128(input), exponent, out var result) ? TryFromInt128(result, out T value) ? value : default : PowDouble<T>(input, exponent);
        }

        return TryPowDecimal(As<T, decimal>(input), exponent, out var number) ? As<decimal, T>(Normalize(number)) : PowDouble<T>(input, exponent);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AbsImplement<T>(this T? input) => Exact(input, Math.Abs, Math.Abs, true);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SinImplement<T>(this T? input) => Unary(input, Math.Sin);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CosImplement<T>(this T? input) => Unary(input, Math.Cos);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TanImplement<T>(this T? input) => Unary(input, Math.Tan);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AsinImplement<T>(this T? input) => Unary(input, Math.Asin);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AcosImplement<T>(this T? input) => Unary(input, Math.Acos);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AtanImplement<T>(this T? input) => Unary(input, Math.Atan);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CbrtImplement<T>(this T? input) => Unary(input, Math.Cbrt);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ExpImplement<T>(this T? input) => Unary(input, Math.Exp);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Exp2Implement<T>(this T? input) => Unary(input, static x => Math.Pow(2, x));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? LogImplement<T>(this T? input, object? baseValue = null)
        => input is null ? input
        : !IsBinaryFloatingPoint(KindOf<T>()) ? ((object?)input).LogImplement<T>(baseValue)
        : baseValue is null ? FromDouble<T>(Math.Log(ToDouble(input)))
        : FromDouble<T>(Math.Log(ToDouble(input), baseValue.ParseImplement<double>()));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log10Implement<T>(this T? input) => Unary(input, Math.Log10);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log2Implement<T>(this T? input) => Unary(input, Math.Log2);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ILogBImplement<T>(this T? input)
        => input is null ? input : IsBinaryFloatingPoint(KindOf<T>()) ? FromDouble<T>(Math.ILogB(ToDouble(input))) : ((object?)input).ILogBImplement<T>();
}
