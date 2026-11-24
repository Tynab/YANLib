using static System.MidpointRounding;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    internal static IEnumerable<T?>? TruncatesImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.TruncateImplement());

    internal static IEnumerable<T?>? TruncatesImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().TruncatesImplement<T?>();

    internal static IEnumerable<T?>? CeilingsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.CeilingImplement());

    internal static IEnumerable<T?>? CeilingsImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().CeilingsImplement<T?>();

    internal static IEnumerable<T?>? FloorsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.FloorImplement());

    internal static IEnumerable<T?>? FloorsImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().FloorsImplement<T?>();

    internal static IEnumerable<T?>? RoundsImplement<T>(this IEnumerable<T?>? input, object? digits = null, MidpointRounding mode = AwayFromZero)
        => input.IsNullEmptyImplement() ? input : input.Select(x => x.RoundImplement(digits, mode));

    internal static IEnumerable<T?>? RoundsImplement<T>(this System.Collections.IEnumerable? input, object? digits = null, MidpointRounding mode = AwayFromZero)
        => input is null ? default : input.Cast<object?>().RoundsImplement<T?>(digits, mode);

    internal static IEnumerable<T?>? SqrtsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.SqrtImplement());

    internal static IEnumerable<T?>? SqrtsImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().SqrtsImplement<T?>();

    internal static IEnumerable<T?>? PowsImplement<T>(this IEnumerable<T?>? input, object? power) => input.IsNullEmptyImplement() ? input : input.Select(x => x.PowImplement(power));

    internal static IEnumerable<T?>? PowsImplement<T>(this System.Collections.IEnumerable? input, object? power) => input is null ? default : input.Cast<object?>().PowsImplement<T?>(power);

    internal static IEnumerable<T?>? AbssImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AbsImplement());

    internal static IEnumerable<T?>? AbssImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().AbssImplement<T?>();

    internal static IEnumerable<T?>? SinsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.SinImplement());

    internal static IEnumerable<T?>? SinsImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().SinsImplement<T?>();

    internal static IEnumerable<T?>? CossImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.CosImplement());

    internal static IEnumerable<T?>? CossImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().CossImplement<T?>();

    internal static IEnumerable<T?>? TansImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.TanImplement());

    internal static IEnumerable<T?>? TansImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().TansImplement<T?>();

    internal static IEnumerable<T?>? AsinsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AsinImplement());

    internal static IEnumerable<T?>? AsinsImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().AsinsImplement<T?>();

    internal static IEnumerable<T?>? AcossImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AcosImplement());

    internal static IEnumerable<T?>? AcossImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().AcossImplement<T?>();

    internal static IEnumerable<T?>? AtansImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.AtanImplement());

    internal static IEnumerable<T?>? AtansImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().AtansImplement<T?>();

    internal static IEnumerable<T?>? CbrtsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.CbrtImplement());

    internal static IEnumerable<T?>? CbrtsImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().CbrtsImplement<T?>();

    internal static IEnumerable<T?>? ExpsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.ExpImplement());

    internal static IEnumerable<T?>? ExpsImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().ExpsImplement<T?>();

    internal static IEnumerable<T?>? Exp2sImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.Exp2Implement());

    internal static IEnumerable<T?>? Exp2sImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().Exp2sImplement<T?>();

    internal static IEnumerable<T?>? LogsImplement<T>(this IEnumerable<T?>? input, object? baseValue = null) => input.IsNullEmptyImplement() ? input : input.Select(x => x.LogImplement(baseValue));

    internal static IEnumerable<T?>? LogsImplement<T>(this System.Collections.IEnumerable? input, object? baseValue = null) => input is null ? default : input.Cast<object?>().LogsImplement<T?>(baseValue);

    internal static IEnumerable<T?>? Log10sImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.Log10Implement());

    internal static IEnumerable<T?>? Log10sImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().Log10sImplement<T?>();

    internal static IEnumerable<T?>? Log2sImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.Log2Implement());

    internal static IEnumerable<T?>? Log2sImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().Log2sImplement<T?>();

    internal static IEnumerable<T?>? ILogBsImplement<T>(this IEnumerable<T?>? input) => input.IsNullEmptyImplement() ? input : input.Select(static x => x.ILogBImplement());

    internal static IEnumerable<T?>? ILogBsImplement<T>(this System.Collections.IEnumerable? input) => input is null ? default : input.Cast<object?>().ILogBsImplement<T?>();
}
