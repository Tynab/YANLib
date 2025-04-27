using YANLib.Implementation;
using static System.MidpointRounding;

namespace YANLib;

public static partial class YANMath
{
    public static IEnumerable<T?>? Truncates<T>(this IEnumerable<T?>? input) => input.TruncatesImplement();

    public static IEnumerable<T?>? Truncates<T>(params T?[]? input) => input.TruncatesImplement();

    public static IEnumerable<T?>? Truncates<T>(this System.Collections.IEnumerable? input) => input.TruncatesImplement<T>();

    public static IEnumerable<T?>? Ceilings<T>(this IEnumerable<T?>? input) => input.CeilingsImplement();

    public static IEnumerable<T?>? Ceilings<T>(params T?[]? input) => input.CeilingsImplement();

    public static IEnumerable<T?>? Ceilings<T>(this System.Collections.IEnumerable? input) => input.CeilingsImplement<T>();

    public static IEnumerable<T?>? Floors<T>(this IEnumerable<T?>? input) => input.FloorsImplement();

    public static IEnumerable<T?>? Floors<T>(params T?[]? input) => input.FloorsImplement();

    public static IEnumerable<T?>? Floors<T>(this System.Collections.IEnumerable? input) => input.FloorsImplement<T>();

    public static IEnumerable<T?>? Rounds<T>(this IEnumerable<T?>? input, object? digits = null, MidpointRounding mode = AwayFromZero) => input.RoundsImplement(digits, mode);

    public static IEnumerable<T?>? Rounds<T>(params T?[]? input) => input.RoundsImplement();

    public static IEnumerable<T?>? Rounds<T>(this System.Collections.IEnumerable? input, object? digits = null, MidpointRounding mode = AwayFromZero) => input.RoundsImplement<T>(digits, mode);

    public static IEnumerable<T?>? Sqrts<T>(this IEnumerable<T?>? input) => input.SqrtsImplement();

    public static IEnumerable<T?>? Sqrts<T>(params T?[]? input) => input.SqrtsImplement();

    public static IEnumerable<T?>? Sqrts<T>(this System.Collections.IEnumerable? input) => input.SqrtsImplement<T>();

    public static IEnumerable<T?>? Pows<T>(this IEnumerable<T?>? input, object? power) => input.PowsImplement(power);

    public static IEnumerable<T?>? Pows<T>(this System.Collections.IEnumerable? input, object? power) => input.PowsImplement<T>(power);

    public static IEnumerable<T?>? Abss<T>(this IEnumerable<T?>? input) => input.AbssImplement();

    public static IEnumerable<T?>? Abss<T>(params T?[]? input) => input.AbssImplement();

    public static IEnumerable<T?>? Abss<T>(this System.Collections.IEnumerable? input) => input.AbssImplement<T>();

    public static IEnumerable<T?>? Logs<T>(this IEnumerable<T?>? input, object? baseValue = null) => input.LogsImplement(baseValue);

    public static IEnumerable<T?>? Logs<T>(params T?[]? input) => input.LogsImplement();

    public static IEnumerable<T?>? Logs<T>(this System.Collections.IEnumerable? input) => input.LogsImplement<T>();

    public static IEnumerable<T?>? Log10s<T>(this IEnumerable<T?>? input) => input.Log10sImplement();

    public static IEnumerable<T?>? Log10s<T>(params T?[]? input) => input.Log10sImplement();

    public static IEnumerable<T?>? Log10s<T>(this System.Collections.IEnumerable? input) => input.Log10sImplement<T>();

    public static IEnumerable<T?>? Log2s<T>(this IEnumerable<T?>? input) => input.Log2sImplement();

    public static IEnumerable<T?>? Log2s<T>(params T?[]? input) => input.Log2sImplement();

    public static IEnumerable<T?>? Log2s<T>(this System.Collections.IEnumerable? input) => input.Log2sImplement<T>();

    public static IEnumerable<T?>? Sins<T>(this IEnumerable<T?>? input) => input.SinsImplement();

    public static IEnumerable<T?>? Sins<T>(params T?[]? input) => input.SinsImplement();

    public static IEnumerable<T?>? Sins<T>(this System.Collections.IEnumerable? input) => input.SinsImplement<T>();

    public static IEnumerable<T?>? Coss<T>(this IEnumerable<T?>? input) => input.CossImplement();

    public static IEnumerable<T?>? Coss<T>(params T?[]? input) => input.CossImplement();

    public static IEnumerable<T?>? Coss<T>(this System.Collections.IEnumerable? input) => input.CossImplement<T>();

    public static IEnumerable<T?>? Tans<T>(this IEnumerable<T?>? input) => input.TansImplement();

    public static IEnumerable<T?>? Tans<T>(params T?[]? input) => input.TansImplement();

    public static IEnumerable<T?>? Tans<T>(this System.Collections.IEnumerable? input) => input.TansImplement<T>();

    public static IEnumerable<T?>? Asins<T>(this IEnumerable<T?>? input) => input.AsinsImplement();

    public static IEnumerable<T?>? Asins<T>(params T?[]? input) => input.AsinsImplement();

    public static IEnumerable<T?>? Asins<T>(this System.Collections.IEnumerable? input) => input.AsinsImplement<T>();

    public static IEnumerable<T?>? Acoss<T>(this IEnumerable<T?>? input) => input.AcossImplement();

    public static IEnumerable<T?>? Acoss<T>(params T?[]? input) => input.AcossImplement();

    public static IEnumerable<T?>? Acoss<T>(this System.Collections.IEnumerable? input) => input.AcossImplement<T>();

    public static IEnumerable<T?>? Atans<T>(this IEnumerable<T?>? input) => input.AtansImplement();

    public static IEnumerable<T?>? Atans<T>(params T?[]? input) => input.AtansImplement();

    public static IEnumerable<T?>? Atans<T>(this System.Collections.IEnumerable? input) => input.AtansImplement<T>();

    public static IEnumerable<T?>? Cbrts<T>(this IEnumerable<T?>? input) => input.CbrtsImplement();

    public static IEnumerable<T?>? Cbrts<T>(params T?[]? input) => input.CbrtsImplement();

    public static IEnumerable<T?>? Cbrts<T>(this System.Collections.IEnumerable? input) => input.CbrtsImplement<T>();

    public static IEnumerable<T?>? Exps<T>(this IEnumerable<T?>? input) => input.ExpsImplement();

    public static IEnumerable<T?>? Exps<T>(params T?[]? input) => input.ExpsImplement();

    public static IEnumerable<T?>? Exps<T>(this System.Collections.IEnumerable? input) => input.ExpsImplement<T>();

    public static IEnumerable<T?>? Exp2s<T>(this IEnumerable<T?>? input) => input.Exp2sImplement();

    public static IEnumerable<T?>? Exp2s<T>(params T?[]? input) => input.Exp2sImplement();

    public static IEnumerable<T?>? Exp2s<T>(this System.Collections.IEnumerable? input) => input.Exp2sImplement<T>();

    public static IEnumerable<T?>? ILogBs<T>(this IEnumerable<T?>? input) => input.ILogBsImplement();

    public static IEnumerable<T?>? ILogBs<T>(params T?[]? input) => input.ILogBsImplement();

    public static IEnumerable<T?>? ILogBs<T>(this System.Collections.IEnumerable? input) => input.ILogBsImplement<T>();
}
