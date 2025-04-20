using YANLib.Implementation;

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

    public static IEnumerable<T?>? Truncates<T>(this IEnumerable<object?>? input) => input.TruncatesImplement<T>();

    public static IEnumerable<T?>? Truncates<T>(params object?[]? input) => input.TruncatesImplement<T>();

    public static T? Ceiling<T>(this object? input) => input.CeilingImplement<T>();

    public static IEnumerable<T?>? Ceilings<T>(this IEnumerable<object?>? input) => input.CeilingsImplement<T>();

    public static IEnumerable<T?>? Ceilings<T>(params object?[]? input) => input.CeilingsImplement<T>();

    public static T? Floor<T>(this object? input) => input.FloorImplement<T>();

    public static IEnumerable<T?>? Floors<T>(this IEnumerable<object?>? input) => input.FloorsImplement<T>();

    public static IEnumerable<T?>? Floors<T>(params object?[]? input) => input.FloorsImplement<T>();

    public static T? Round<T>(this object? input, object? digits = null) => input.RoundImplement<T>(digits);

    public static IEnumerable<T?>? Rounds<T>(this IEnumerable<object?>? input, object? digits = null) => input.RoundsImplement<T>(digits);

    public static IEnumerable<T?>? Rounds<T>(params object?[]? input) => input.RoundsImplement<T>();

    public static T? Sqrt<T>(this object? input) => input.SqrtImplement<T>();

    public static IEnumerable<T?>? Sqrts<T>(this IEnumerable<object?>? input) => input.SqrtsImplement<T>();

    public static IEnumerable<T?>? Sqrts<T>(params object?[]? input) => input.SqrtsImplement<T>();

    public static T? Pow<T>(this object? input, object? power) => input.PowImplement<T>(power);

    public static IEnumerable<T?>? Pows<T>(this IEnumerable<object?>? input, object? power) => input.PowsImplement<T>(power);

    public static T? Abs<T>(this object? input) => input.AbsImplement<T>();

    public static IEnumerable<T?>? Abss<T>(this IEnumerable<object?>? input) => input.AbssImplement<T>();

    public static IEnumerable<T?>? Abss<T>(params object?[]? input) => input.AbssImplement<T>();

    public static T? Log<T>(this object? input, object? baseValue = null) => input.LogImplement<T>(baseValue);

    public static IEnumerable<T?>? Logs<T>(this IEnumerable<object?>? input, object? baseValue = null) => input.LogsImplement<T>(baseValue);

    public static IEnumerable<T?>? Logs<T>(params object?[]? input) => input.LogsImplement<T>();

    public static T? Log10<T>(this object? input) => input.Log10Implement<T>();

    public static IEnumerable<T?>? Log10s<T>(this IEnumerable<object?>? input) => input.Log10sImplement<T>();

    public static IEnumerable<T?>? Log10s<T>(params object?[]? input) => input.Log10sImplement<T>();

    public static T? Log2<T>(this object? input) => input.Log2Implement<T>();

    public static IEnumerable<T?>? Log2s<T>(this IEnumerable<object?>? input) => input.Log2sImplement<T>();

    public static IEnumerable<T?>? Log2s<T>(params object?[]? input) => input.Log2sImplement<T>();

    public static T? Sin<T>(this object? input) => input.SinImplement<T>();

    public static IEnumerable<T?>? Sins<T>(this IEnumerable<object?>? input) => input.SinsImplement<T>();

    public static IEnumerable<T?>? Sins<T>(params object?[]? input) => input.SinsImplement<T>();

    public static T? Cos<T>(this object? input) => input.CosImplement<T>();

    public static IEnumerable<T?>? Coss<T>(this IEnumerable<object?>? input) => input.CossImplement<T>();

    public static IEnumerable<T?>? Coss<T>(params object?[]? input) => input.CossImplement<T>();

    public static T? Tan<T>(this object? input) => input.TanImplement<T>();

    public static IEnumerable<T?>? Tans<T>(this IEnumerable<object?>? input) => input.TansImplement<T>();

    public static IEnumerable<T?>? Tans<T>(params object?[]? input) => input.TansImplement<T>();

    public static T? Asin<T>(this object? input) => input.AsinImplement<T>();

    public static IEnumerable<T?>? Asins<T>(this IEnumerable<object?>? input) => input.AsinsImplement<T>();

    public static IEnumerable<T?>? Asins<T>(params object?[]? input) => input.AsinsImplement<T>();

    public static T? Acos<T>(this object? input) => input.AcosImplement<T>();

    public static IEnumerable<T?>? Acoss<T>(this IEnumerable<object?>? input) => input.AcossImplement<T>();

    public static IEnumerable<T?>? Acoss<T>(params object?[]? input) => input.AcossImplement<T>();

    public static T? Atan<T>(this object? input) => input.AtanImplement<T>();

    public static IEnumerable<T?>? Atans<T>(this IEnumerable<object?>? input) => input.AtansImplement<T>();

    public static IEnumerable<T?>? Atans<T>(params object?[]? input) => input.AtansImplement<T>();

    public static T? Cbrt<T>(this object? input) => input.CbrtImplement<T>();

    public static IEnumerable<T?>? Cbrts<T>(this IEnumerable<object?>? input) => input.CbrtsImplement<T>();

    public static IEnumerable<T?>? Cbrts<T>(params object?[]? input) => input.CbrtsImplement<T>();

    public static T? Exp<T>(this object? input) => input.ExpImplement<T>();

    public static IEnumerable<T?>? Exps<T>(this IEnumerable<object?>? input) => input.ExpsImplement<T>();

    public static IEnumerable<T?>? Exps<T>(params object?[]? input) => input.ExpsImplement<T>();

    public static T? Exp2<T>(this object? input) => input.Exp2Implement<T>();

    public static IEnumerable<T?>? Exp2s<T>(this IEnumerable<object?>? input) => input.Exp2sImplement<T>();

    public static IEnumerable<T?>? Exp2s<T>(params object?[]? input) => input.Exp2sImplement<T>();

    public static T? ILogB<T>(this object? input) => input.ILogBImplement<T>();

    public static IEnumerable<T?>? ILogBs<T>(this IEnumerable<object?>? input) => input.ILogBsImplement<T>();

    public static IEnumerable<T?>? ILogBs<T>(params object?[]? input) => input.ILogBsImplement<T>();
}
