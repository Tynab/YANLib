using System.Diagnostics;

namespace YANLib.Implementation;

internal static partial class YANObject
{
    #region Null

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotNullImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNullImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNullImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotNullImplement());

    #endregion

    #region Default

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && !input.Any(x => x.IsDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotDefaultImplement<T>(this IEnumerable<T?>? input) => input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotDefaultImplement());

    #endregion

    #region NullDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullDefaultImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AllNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNotNullDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AnyNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && input.Any(x => x.IsNullDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AllNotNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && !input.Any(x => x.IsNullDefaultImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullEmptyImplement<T>(this IEnumerable<T?>? input) where T : class
        => typeof(T) == typeof(string) ? YANText.AnyNotNullEmptyImplement(input as IEnumerable<string>) : input.IsNotNullEmptyImplement() && input.Any(x => x.IsNotNullDefaultImplement());

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ChangeTimeZoneAllPropertiesImplement<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) where T : class
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(x => x.ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst)) : input.AsParallel().Select(x => x.ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst));
}
