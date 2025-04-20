using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using YANLib.Implementation.Object;

namespace YANLib.Object;

public static partial class YANObject
{
    #region Null

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNull([NotNullWhen(false)] this object? input) => input.IsNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull<T>(this IEnumerable<T?>? input) => input.AllNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNull<T>(params T?[]? input) => input.AllNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull<T>(this IEnumerable<T?>? input) => input.AnyNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNull<T>(params T?[]? input) => input.AnyNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNull([NotNullWhen(true)] this object? input) => input.IsNotNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull<T>(this IEnumerable<T?>? input) => input.AllNotNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNull<T>(params T?[]? input) => input.AllNotNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull<T>(this IEnumerable<T?>? input) => input.AnyNotNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNull<T>(params T?[]? input) => input.AnyNotNullImplement();

    #endregion

    #region Default

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsDefault<T>(this T input) => input.IsDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllDefault<T>(this IEnumerable<T?>? input) => input.AllDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllDefault<T>(params T?[]? input) => input.AllDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyDefault<T>(this IEnumerable<T?>? input) => input.AnyDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyDefault<T>(params T?[]? input) => input.AnyDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotDefault<T>(this T input) => input.IsNotDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotDefault<T>(this IEnumerable<T?>? input) => input.AllNotDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotDefault<T>(params T?[]? input) => input.AllNotDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotDefault<T>(this IEnumerable<T?>? input) => input.AnyNotDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotDefault<T>(params T?[]? input) => input.AnyNotDefaultImplement();

    #endregion

    #region NullEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNullEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? input) => input.IsNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AllNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNullEmpty<T>(params T?[]? input) where T : class => input.AllNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AnyNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNullEmpty<T>(params T?[]? input) where T : class => input.AnyNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsNotNullEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? input) => input.IsNotNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AllNotNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllNotNullEmpty<T>(params T?[]? input) where T : class => input.AllNotNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.AnyNotNullEmptyImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyNotNullEmpty<T>(params T?[]? input) where T : class => input.AnyNotNullEmptyImplement();

    #endregion

    #region DateTimeZone

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? ChangeTimeZoneAllProperty<T>(this T? input, object? tzSrc = null, object? tzDst = null) where T : class => input.ChangeTimeZoneAllPropertyImplement(tzSrc, tzDst);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) where T : class => input.ChangeTimeZoneAllPropertiesImplement(tzSrc, tzDst);

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Copy<T>(this T input) where T : new() => input.CopyImplement();
}
