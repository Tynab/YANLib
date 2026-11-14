using System.Diagnostics;
using static System.MidpointRounding;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MinImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : MinMax(input.Where(static x => x is not null).Select(static x => x.ParseImplement<T?>()), false);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? MaxImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : MinMax(input.Where(static x => x is not null).Select(static x => x.ParseImplement<T?>()), true);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AverageImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : AverageObject<T>(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SumImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : SumObject<T>(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TruncateImplement<T>(this object? input) => ExactObject<T>(input, Math.Truncate, decimal.Truncate);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CeilingImplement<T>(this object? input) => ExactObject<T>(input, Math.Ceiling, decimal.Ceiling);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? FloorImplement<T>(this object? input) => ExactObject<T>(input, Math.Floor, decimal.Floor);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? RoundImplement<T>(this object? input, object? digits = null, MidpointRounding mode = AwayFromZero)
    {
        if (input is null)
        {
            return default;
        }

        var places = ParseDigits(digits);

        if (!NumberTarget<T>.IsDecimal || !IsValidRound(places, mode))
        {
            return RoundDouble(input.ParseImplement<double>(), places, mode).ParseImplement<T?>();
        }

        // rounding a double or float to a whole number needs no text round trip (see TryToWholeDecimal)
        return places is null && IsDoubleOrFloat(input, out var value) && TryToWholeDecimal(Math.Round(value, mode), out var whole) ? whole.ParseImplement<T?>()
            : TryToDecimal(input, out var number) ? FromDecimal<T>(RoundDecimal(number, places, mode))
            : RoundDouble(input.ParseImplement<double>(), places, mode).ParseImplement<T?>();
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SqrtImplement<T>(this object? input) => UnaryObject<T>(input, Math.Sqrt);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? PowImplement<T>(this object? input, object? power)
    {
        if (input is null || power is null)
        {
            return default;
        }

        var exponent = power.ParseImplement<double>();

        return NumberTarget<T>.IsDecimal && TryToDecimal(input, out var number) && TryPowDecimal(number, exponent, out var result) ? FromDecimal<T>(result) : PowDouble<T>(input, exponent);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AbsImplement<T>(this object? input) => ExactObject<T>(input, Math.Abs, Math.Abs);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? SinImplement<T>(this object? input) => UnaryObject<T>(input, Math.Sin);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CosImplement<T>(this object? input) => UnaryObject<T>(input, Math.Cos);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? TanImplement<T>(this object? input) => UnaryObject<T>(input, Math.Tan);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AsinImplement<T>(this object? input) => UnaryObject<T>(input, Math.Asin);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AcosImplement<T>(this object? input) => UnaryObject<T>(input, Math.Acos);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? AtanImplement<T>(this object? input) => UnaryObject<T>(input, Math.Atan);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? CbrtImplement<T>(this object? input) => UnaryObject<T>(input, Math.Cbrt);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ExpImplement<T>(this object? input) => UnaryObject<T>(input, Math.Exp);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Exp2Implement<T>(this object? input) => UnaryObject<T>(input, static x => Math.Pow(2, x));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? LogImplement<T>(this object? input, object? baseValue = null)
        => input is null ? default : baseValue is null ? Math.Log(input.ParseImplement<double>()).ParseImplement<T?>() : Math.Log(input.ParseImplement<double>(), baseValue.ParseImplement<double>()).ParseImplement<T?>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log10Implement<T>(this object? input) => UnaryObject<T>(input, Math.Log10);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? Log2Implement<T>(this object? input) => UnaryObject<T>(input, Math.Log2);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ILogBImplement<T>(this object? input) => input is null ? default : Math.ILogB(input.ParseImplement<double>()).ParseImplement<T?>();
}
