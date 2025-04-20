using System.Diagnostics;
using YANLib.Implementation.Object;

namespace YANLib.Object;

public static partial class YANObject
{
    #region AllPropertiesDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefault<T>(this T? input) where T : class => input.AllPropertiesDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AllPropertiesDefaultsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(params T?[]? input) where T : class => input.AllPropertiesDefaultsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesDefaultImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesDefaultsImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefault<T>(this T? input, params string?[]? names) where T : class => input.AllPropertiesDefaultImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AllPropertiesDefaultsImplement(names);

    #endregion

    #region AllPropertiesNotDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefault<T>(this T? input) where T : class => input.AllPropertiesNotDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AllPropertiesNotDefaultsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(params T?[]? input) where T : class => input.AllPropertiesNotDefaultsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesNotDefaultImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AllPropertiesNotDefaultsImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefault<T>(this T? input, params string?[]? names) where T : class => input.AllPropertiesNotDefaultImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AllPropertiesNotDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AllPropertiesNotDefaultsImplement(names);

    #endregion

    #region AnyPropertiesDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefault<T>(this T? input) where T : class => input.AnyPropertiesDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AnyPropertiesDefaultsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(params T?[]? input) where T : class => input.AnyPropertiesDefaultsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesDefaultImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesDefaultsImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefault<T>(this T? input, params string?[]? names) where T : class => input.AnyPropertiesDefaultImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AnyPropertiesDefaultsImplement(names);

    #endregion

    #region AnyPropertiesNotDefault

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefault<T>(this T? input) where T : class => input.AnyPropertiesNotDefaultImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input) where T : class => input.AnyPropertiesNotDefaultsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(params T?[]? input) where T : class => input.AnyPropertiesNotDefaultsImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefault<T>(this T? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesNotDefaultImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input, IEnumerable<string?>? names) where T : class => input.AnyPropertiesNotDefaultsImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefault<T>(this T? input, params string?[]? names) where T : class => input.AnyPropertiesNotDefaultImplement(names);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool AnyPropertiesNotDefaults<T>(this IEnumerable<T?>? input, params string?[]? names) where T : class => input.AnyPropertiesNotDefaultsImplement(names);

    #endregion
}
