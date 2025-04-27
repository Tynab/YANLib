using YANLib.Implementation;
using static System.MidpointRounding;

namespace YANLib;

public static partial class YANMath
{
    public static T? Min<T>(this IEnumerable<T?>? input) => input.MinImplement();

    public static T? Min<T>(params T?[]? input) => input.MinImplement();

    public static T? Min<T>(this System.Collections.IEnumerable? input) => input.MinImplement<T>();

    public static T? Max<T>(this IEnumerable<T?>? input) => input.MaxImplement();

    public static T? Max<T>(params T?[]? input) => input.MaxImplement();

    public static T? Max<T>(this System.Collections.IEnumerable? input) => input.MaxImplement<T>();

    public static T? Average<T>(this IEnumerable<T?>? input) => input.AverageImplement();

    public static T? Average<T>(params T?[]? input) => input.AverageImplement();

    public static T? Average<T>(this System.Collections.IEnumerable? input) => input.AverageImplement<T>();

    public static T? Sum<T>(this IEnumerable<T?>? input) => input.SumImplement();

    public static T? Sum<T>(params T?[]? input) => input.SumImplement();

    public static T? Sum<T>(this System.Collections.IEnumerable? input) => input.SumImplement<T>();

    public static T? Truncate<T>(this T? input) => input.TruncateImplement();

    public static T? Ceiling<T>(this T? input) => input.CeilingImplement();

    public static T? Floor<T>(this T? input) => input.FloorImplement();

    public static T? Round<T>(this T? input, object? digits = null, MidpointRounding mode = AwayFromZero) => input.RoundImplement(digits, mode);

    public static T? Sqrt<T>(this T? input) => input.SqrtImplement();

    public static T? Pow<T>(this T? input, object? power) => input.PowImplement(power);

    public static T? Abs<T>(this T? input) => input.AbsImplement();

    public static T? Log<T>(this T? input, object? baseValue = null) => input.LogImplement(baseValue);

    public static T? Log10<T>(this T? input) => input.Log10Implement();

    public static T? Log2<T>(this T? input) => input.Log2Implement();

    public static T? Sin<T>(this T? input) => input.SinImplement();

    public static T? Cos<T>(this T? input) => input.CosImplement();

    public static T? Tan<T>(this T? input) => input.TanImplement();

    public static T? Asin<T>(this T? input) => input.AsinImplement();

    public static T? Acos<T>(this T? input) => input.AcosImplement();

    public static T? Atan<T>(this T? input) => input.AtanImplement();

    public static T? Cbrt<T>(this T? input) => input.CbrtImplement();

    public static T? Exp<T>(this T? input) => input.ExpImplement();

    public static T? Exp2<T>(this T? input) => input.Exp2Implement();

    public static T? ILogB<T>(this T? input) => input.ILogBImplement();
}
