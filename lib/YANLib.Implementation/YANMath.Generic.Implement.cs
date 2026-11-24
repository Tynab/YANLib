using static System.MidpointRounding;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    internal static T? MinImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : MinMax(input.Where(static x => x is not null).Select(static x => x.ParseImplement<T?>()), false);

    internal static T? MaxImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : MinMax(input.Where(static x => x is not null).Select(static x => x.ParseImplement<T?>()), true);

    internal static T? AverageImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : AverageObject<T>(input);

    internal static T? SumImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : SumObject<T>(input);

    internal static T? TruncateImplement<T>(this object? input) => ExactObject<T>(input, Math.Truncate, decimal.Truncate);

    internal static T? CeilingImplement<T>(this object? input) => ExactObject<T>(input, Math.Ceiling, decimal.Ceiling);

    internal static T? FloorImplement<T>(this object? input) => ExactObject<T>(input, Math.Floor, decimal.Floor);

    internal static T? RoundImplement<T>(this object? input, object? digits = null, MidpointRounding mode = AwayFromZero)
    {
        if (input is null)
        {
            return default;
        }

        var places = ParseDigits(digits);

        if (!NumberTarget<T>.IsDecimal || !IsValidRound(places, mode))
        {
            // a decimal input goes through the 8.3.3 cast to double, which can land next to its value (see RoundDouble)
            return RoundDouble(input.ParseImplement<double>(), places, mode, input is decimal).ParseImplement<T?>();
        }

        // rounding a double or float to a whole number needs no text round trip (see TryToWholeDecimal). For more than 15 digits a double or
        // float whose shortest text has more than the 28 decimal places of decimal (every such value is below 1e-11; a float through its own
        // text, as TryToDecimal converts it) is rounded exactly on that text by digit shifting, as RoundDouble does, and any other input with
        // more than 28 decimal places (a string such as "1e-30") is rounded to 28 places first; the decimal result keeps all its digits
        return places is null && IsDoubleOrFloat(input, out var value) && TryToWholeDecimal(Math.Round(value, mode), out var whole) ? whole.ParseImplement<T?>()
            : TryToDecimal(input, out var number, places > 15 && input is not (double or float)) ? FromDecimal<T>(RoundDecimal(number, places, mode))
            : places is int count and > 15 && TryGetShortestDouble(input, out value) && Math.Abs(value) < 1e-11 ? FromDecimal<T>(RoundShortestTextToDecimal(value, count, mode))
            : RoundDouble(input.ParseImplement<double>(), places, mode).ParseImplement<T?>();
    }

    internal static T? SqrtImplement<T>(this object? input) => UnaryObject<T>(input, Math.Sqrt);

    internal static T? PowImplement<T>(this object? input, object? power)
    {
        if (input is null || power is null)
        {
            return default;
        }

        var exponent = power.ParseImplement<double>();

        return NumberTarget<T>.IsDecimal && TryToDecimal(input, out var number) && TryPowDecimal(number, exponent, out var result) ? FromDecimal<T>(result) : PowDouble<T>(input, exponent);
    }

    internal static T? AbsImplement<T>(this object? input) => ExactObject<T>(input, Math.Abs, Math.Abs);

    internal static T? SinImplement<T>(this object? input) => UnaryObject<T>(input, Math.Sin);

    internal static T? CosImplement<T>(this object? input) => UnaryObject<T>(input, Math.Cos);

    internal static T? TanImplement<T>(this object? input) => UnaryObject<T>(input, Math.Tan);

    internal static T? AsinImplement<T>(this object? input) => UnaryObject<T>(input, Math.Asin);

    internal static T? AcosImplement<T>(this object? input) => UnaryObject<T>(input, Math.Acos);

    internal static T? AtanImplement<T>(this object? input) => UnaryObject<T>(input, Math.Atan);

    internal static T? CbrtImplement<T>(this object? input) => UnaryObject<T>(input, Math.Cbrt);

    internal static T? ExpImplement<T>(this object? input) => UnaryObject<T>(input, Math.Exp);

    internal static T? Exp2Implement<T>(this object? input) => UnaryObject<T>(input, static x => Math.Pow(2, x));

    internal static T? LogImplement<T>(this object? input, object? baseValue = null)
        => input is null ? default : baseValue is null ? Math.Log(input.ParseImplement<double>()).ParseImplement<T?>() : Math.Log(input.ParseImplement<double>(), baseValue.ParseImplement<double>()).ParseImplement<T?>();

    internal static T? Log10Implement<T>(this object? input) => UnaryObject<T>(input, Math.Log10);

    internal static T? Log2Implement<T>(this object? input) => UnaryObject<T>(input, Math.Log2);

    internal static T? ILogBImplement<T>(this object? input) => input is null ? default : Math.ILogB(input.ParseImplement<double>()).ParseImplement<T?>();
}
