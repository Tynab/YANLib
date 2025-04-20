using YANLib.Implementation;

namespace YANLib;

public static partial class YANMath
{
    public static T? Min<T>(this IEnumerable<T?>? input) => input.MinImplement();

    public static T? Min<T>(params T?[]? input) => input.MinImplement();

    public static T? Max<T>(this IEnumerable<T?>? input) => input.MaxImplement();

    public static T? Max<T>(params T?[]? input) => input.MaxImplement();

    public static T? Average<T>(this IEnumerable<T?>? input) => input.AverageImplement();

    public static T? Average<T>(params T?[]? input) => input.AverageImplement();

    public static T? Sum<T>(this IEnumerable<T?>? input) => input.SumImplement();

    public static T? Sum<T>(params T?[]? input) => input.SumImplement();

    public static T? Truncate<T>(this T? input) => input.TruncateImplement();

    public static IEnumerable<T?>? Truncates<T>(this IEnumerable<T?>? input) => input.TruncatesImplement();

    public static IEnumerable<T?>? Truncates<T>(params T?[]? input) => input.TruncatesImplement();

    public static T? Ceiling<T>(this T? input) => input.CeilingImplement();

    public static IEnumerable<T?>? Ceilings<T>(this IEnumerable<T?>? input) => input.CeilingsImplement();

    public static IEnumerable<T?>? Ceilings<T>(params T?[]? input) => input.CeilingsImplement();

    public static T? Floor<T>(this T? input) => input.FloorImplement();

    public static IEnumerable<T?>? Floors<T>(this IEnumerable<T?>? input) => input.FloorsImplement();

    public static IEnumerable<T?>? Floors<T>(params T?[]? input) => input.FloorsImplement();

    public static T? Round<T>(this T? input, object? digits = null) => input.RoundImplement(digits);

    public static IEnumerable<T?>? Rounds<T>(this IEnumerable<T?>? input, object? digits = null) => input.RoundsImplement(digits);

    public static IEnumerable<T?>? Rounds<T>(params T?[]? input) => input.RoundsImplement();

    public static T? Sqrt<T>(this T? input) => input.SqrtImplement();

    public static IEnumerable<T?>? Sqrts<T>(this IEnumerable<T?>? input) => input.SqrtsImplement();

    public static IEnumerable<T?>? Sqrts<T>(params T?[]? input) => input.SqrtsImplement();

    public static T? Pow<T>(this T? input, object? power) => input.PowImplement(power);

    public static IEnumerable<T?>? Pows<T>(this IEnumerable<T?>? input, object? power) => input.PowsImplement(power);

    public static T? Abs<T>(this T? input) => input.AbsImplement();

    public static IEnumerable<T?>? Abss<T>(this IEnumerable<T?>? input) => input.AbssImplement();

    public static IEnumerable<T?>? Abss<T>(params T?[]? input) => input.AbssImplement();

    public static T? Log<T>(this T? input, object? baseValue = null) => input.LogImplement(baseValue);

    public static IEnumerable<T?>? Logs<T>(this IEnumerable<T?>? input, object? baseValue = null) => input.LogsImplement(baseValue);

    public static IEnumerable<T?>? Logs<T>(params T?[]? input) => input.LogsImplement();

    public static T? Log10<T>(this T? input) => input.Log10Implement();

    public static IEnumerable<T?>? Log10s<T>(this IEnumerable<T?>? input) => input.Log10sImplement();

    public static IEnumerable<T?>? Log10s<T>(params T?[]? input) => input.Log10sImplement();

    public static T? Log2<T>(this T? input) => input.Log2Implement();

    public static IEnumerable<T?>? Log2s<T>(this IEnumerable<T?>? input) => input.Log2sImplement();

    public static IEnumerable<T?>? Log2s<T>(params T?[]? input) => input.Log2sImplement();

    public static T? Sin<T>(this T? input) => input.SinImplement();

    public static IEnumerable<T?>? Sins<T>(this IEnumerable<T?>? input) => input.SinsImplement();

    public static IEnumerable<T?>? Sins<T>(params T?[]? input) => input.SinsImplement();

    public static T? Cos<T>(this T? input) => input.CosImplement();

    public static IEnumerable<T?>? Coss<T>(this IEnumerable<T?>? input) => input.CossImplement();

    public static IEnumerable<T?>? Coss<T>(params T?[]? input) => input.CossImplement();

    public static T? Tan<T>(this T? input) => input.TanImplement();

    public static IEnumerable<T?>? Tans<T>(this IEnumerable<T?>? input) => input.TansImplement();

    public static IEnumerable<T?>? Tans<T>(params T?[]? input) => input.TansImplement();

    public static T? Asin<T>(this T? input) => input.AsinImplement();

    public static IEnumerable<T?>? Asins<T>(this IEnumerable<T?>? input) => input.AsinsImplement();

    public static IEnumerable<T?>? Asins<T>(params T?[]? input) => input.AsinsImplement();

    public static T? Acos<T>(this T? input) => input.AcosImplement();

    public static IEnumerable<T?>? Acoss<T>(this IEnumerable<T?>? input) => input.AcossImplement();

    public static IEnumerable<T?>? Acoss<T>(params T?[]? input) => input.AcossImplement();

    public static T? Atan<T>(this T? input) => input.AtanImplement();

    public static IEnumerable<T?>? Atans<T>(this IEnumerable<T?>? input) => input.AtansImplement();

    public static IEnumerable<T?>? Atans<T>(params T?[]? input) => input.AtansImplement();

    public static T? Cbrt<T>(this T? input) => input.CbrtImplement();

    public static IEnumerable<T?>? Cbrts<T>(this IEnumerable<T?>? input) => input.CbrtsImplement();

    public static IEnumerable<T?>? Cbrts<T>(params T?[]? input) => input.CbrtsImplement();

    public static T? Exp<T>(this T? input) => input.ExpImplement();

    public static IEnumerable<T?>? Exps<T>(this IEnumerable<T?>? input) => input.ExpsImplement();

    public static IEnumerable<T?>? Exps<T>(params T?[]? input) => input.ExpsImplement();

    public static T? Exp2<T>(this T? input) => input.Exp2Implement();

    public static IEnumerable<T?>? Exp2s<T>(this IEnumerable<T?>? input) => input.Exp2sImplement();

    public static IEnumerable<T?>? Exp2s<T>(params T?[]? input) => input.Exp2sImplement();

    public static T? ILogB<T>(this T? input) => input.ILogBImplement();

    public static IEnumerable<T?>? ILogBs<T>(this IEnumerable<T?>? input) => input.ILogBsImplement();

    public static IEnumerable<T?>? ILogBs<T>(params T?[]? input) => input.ILogBsImplement();
}
