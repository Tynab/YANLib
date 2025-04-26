using YANLib.Implementation;
using static System.MidpointRounding;

namespace YANLib;

public static partial class YANMath
{
    public static IEnumerable<T?>? Truncates<T>(this IEnumerable<object?>? input) => input.TruncatesImplement<T>();

    public static IEnumerable<T?>? Truncates<T>(params object?[]? input) => input.TruncatesImplement<T>();

    public static IEnumerable<T?>? Ceilings<T>(this IEnumerable<object?>? input) => input.CeilingsImplement<T>();

    public static IEnumerable<T?>? Ceilings<T>(params object?[]? input) => input.CeilingsImplement<T>();

    public static IEnumerable<T?>? Floors<T>(this IEnumerable<object?>? input) => input.FloorsImplement<T>();

    public static IEnumerable<T?>? Floors<T>(params object?[]? input) => input.FloorsImplement<T>();

    public static IEnumerable<T?>? Rounds<T>(this IEnumerable<object?>? input, object? digits = null, MidpointRounding mode = AwayFromZero) => input.RoundsImplement<T>(digits, mode);

    public static IEnumerable<T?>? Rounds<T>(params object?[]? input) => input.RoundsImplement<T>();

    public static IEnumerable<T?>? Sqrts<T>(this IEnumerable<object?>? input) => input.SqrtsImplement<T>();

    public static IEnumerable<T?>? Sqrts<T>(params object?[]? input) => input.SqrtsImplement<T>();

    public static IEnumerable<T?>? Pows<T>(this IEnumerable<object?>? input, object? power) => input.PowsImplement<T>(power);

    public static IEnumerable<T?>? Abss<T>(this IEnumerable<object?>? input) => input.AbssImplement<T>();

    public static IEnumerable<T?>? Abss<T>(params object?[]? input) => input.AbssImplement<T>();

    public static IEnumerable<T?>? Logs<T>(this IEnumerable<object?>? input, object? baseValue = null) => input.LogsImplement<T>(baseValue);

    public static IEnumerable<T?>? Logs<T>(params object?[]? input) => input.LogsImplement<T>();

    public static IEnumerable<T?>? Log10s<T>(this IEnumerable<object?>? input) => input.Log10sImplement<T>();

    public static IEnumerable<T?>? Log10s<T>(params object?[]? input) => input.Log10sImplement<T>();

    public static IEnumerable<T?>? Log2s<T>(this IEnumerable<object?>? input) => input.Log2sImplement<T>();

    public static IEnumerable<T?>? Log2s<T>(params object?[]? input) => input.Log2sImplement<T>();

    public static IEnumerable<T?>? Sins<T>(this IEnumerable<object?>? input) => input.SinsImplement<T>();

    public static IEnumerable<T?>? Sins<T>(params object?[]? input) => input.SinsImplement<T>();

    public static IEnumerable<T?>? Coss<T>(this IEnumerable<object?>? input) => input.CossImplement<T>();

    public static IEnumerable<T?>? Coss<T>(params object?[]? input) => input.CossImplement<T>();

    public static IEnumerable<T?>? Tans<T>(this IEnumerable<object?>? input) => input.TansImplement<T>();

    public static IEnumerable<T?>? Tans<T>(params object?[]? input) => input.TansImplement<T>();

    public static IEnumerable<T?>? Asins<T>(this IEnumerable<object?>? input) => input.AsinsImplement<T>();

    public static IEnumerable<T?>? Asins<T>(params object?[]? input) => input.AsinsImplement<T>();

    public static IEnumerable<T?>? Acoss<T>(this IEnumerable<object?>? input) => input.AcossImplement<T>();

    public static IEnumerable<T?>? Acoss<T>(params object?[]? input) => input.AcossImplement<T>();

    public static IEnumerable<T?>? Atans<T>(this IEnumerable<object?>? input) => input.AtansImplement<T>();

    public static IEnumerable<T?>? Atans<T>(params object?[]? input) => input.AtansImplement<T>();

    public static IEnumerable<T?>? Cbrts<T>(this IEnumerable<object?>? input) => input.CbrtsImplement<T>();

    public static IEnumerable<T?>? Cbrts<T>(params object?[]? input) => input.CbrtsImplement<T>();

    public static IEnumerable<T?>? Exps<T>(this IEnumerable<object?>? input) => input.ExpsImplement<T>();

    public static IEnumerable<T?>? Exps<T>(params object?[]? input) => input.ExpsImplement<T>();

    public static IEnumerable<T?>? Exp2s<T>(this IEnumerable<object?>? input) => input.Exp2sImplement<T>();

    public static IEnumerable<T?>? Exp2s<T>(params object?[]? input) => input.Exp2sImplement<T>();

    public static IEnumerable<T?>? ILogBs<T>(this IEnumerable<object?>? input) => input.ILogBsImplement<T>();

    public static IEnumerable<T?>? ILogBs<T>(params object?[]? input) => input.ILogBsImplement<T>();
}
