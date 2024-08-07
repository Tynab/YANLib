using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANBool
{
    /// <summary>
    /// Converts the specified nullable object to its <see cref="bool"/> equivalent.
    /// Returns the resulting <see cref="bool"/> object if the conversion is successful. 
    /// If the conversion fails and a default value is provided, attempts to convert the default value to a <see cref="bool"/> and returns it; otherwise, returns <see langword="null"/>.
    /// </summary>
    /// <param name="val">The object to be converted to <see cref="bool"/>. Can be <see langword="null"/>.</param>
    /// <param name="dfltVal">The default value to be used if the conversion of <paramref name="val"/> fails. Can be <see langword="null"/>.</param>
    /// <returns>
    /// The <see cref="bool"/> equivalent of the input object,
    /// or the converted default value if the input conversion fails,
    /// or <see langword="null"/> if both the input conversion fails and the default value is <see langword="null"/>.
    /// </returns>
    public static bool? ToBool(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToBoolean(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToBool();
        }
    }

    public static IEnumerable<bool?>? ToBools(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToBool(dfltVal));

    public static IEnumerable<bool?>? ToBools(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToBool(dfltVal));

    public static IEnumerable<bool?>? ToBools(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToBool(dfltVal));
}
