using YANLib.Implementation;
using static System.MidpointRounding;

namespace YANLib;

public static partial class YANMath
{
    public static T? Min<T>(this IEnumerable<object?>? input) => input.MinImplement<T>();

    public static T? Min<T>(params object?[]? input) => input.MinImplement<T>();

    public static T? Max<T>(this IEnumerable<object?>? input) => input.MaxImplement<T>();

    public static T? Max<T>(params object?[]? input) => input.MaxImplement<T>();

    public static T? Average<T>(this IEnumerable<object?>? input) => input.AverageImplement<T>();

    public static T? Average<T>(params object?[]? input) => input.AverageImplement<T>();

    public static T? Sum<T>(this IEnumerable<object?>? input) => input.SumImplement<T>();

    public static T? Sum<T>(params object?[]? input) => input.SumImplement<T>();

    public static T? Truncate<T>(this object? input) => input.TruncateImplement<T>();

    public static T? Ceiling<T>(this object? input) => input.CeilingImplement<T>();

    public static T? Floor<T>(this object? input) => input.FloorImplement<T>();

    public static T? Round<T>(this object? input, object? digits = null, MidpointRounding mode = AwayFromZero) => input.RoundImplement<T>(digits, mode);

    public static T? Sqrt<T>(this object? input) => input.SqrtImplement<T>();

    public static T? Pow<T>(this object? input, object? power) => input.PowImplement<T>(power);

    public static T? Abs<T>(this object? input) => input.AbsImplement<T>();

    public static T? Log<T>(this object? input, object? baseValue = null) => input.LogImplement<T>(baseValue);

    public static T? Log10<T>(this object? input) => input.Log10Implement<T>();

    public static T? Log2<T>(this object? input) => input.Log2Implement<T>();

    public static T? Sin<T>(this object? input) => input.SinImplement<T>();

    public static T? Cos<T>(this object? input) => input.CosImplement<T>();

    public static T? Tan<T>(this object? input) => input.TanImplement<T>();

    public static T? Asin<T>(this object? input) => input.AsinImplement<T>();

    public static T? Acos<T>(this object? input) => input.AcosImplement<T>();

    public static T? Atan<T>(this object? input) => input.AtanImplement<T>();

    public static T? Cbrt<T>(this object? input) => input.CbrtImplement<T>();

    public static T? Exp<T>(this object? input) => input.ExpImplement<T>();

    public static T? Exp2<T>(this object? input) => input.Exp2Implement<T>();

    public static T? ILogB<T>(this object? input) => input.ILogBImplement<T>();
}
