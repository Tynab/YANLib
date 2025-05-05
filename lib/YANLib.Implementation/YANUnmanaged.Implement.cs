using System.Diagnostics;
using static System.Convert;
using static System.DateTime;
using static System.Globalization.CultureInfo;
using static System.Globalization.DateTimeStyles;
using static System.Nullable;

namespace YANLib.Implementation;

internal static partial class YANUnmanaged
{
    private static readonly Dictionary<Type, Type?> UnderlyingTypeCache = [];

    #region Private

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static DateTime ParseDateTime(this string? input, DateTime defaultValue = default, IEnumerable<string?>? format = null)
        => input.IsNullWhiteSpaceImplement() ? defaultValue : format.IsNullEmptyImplement() ? TryParse(input, out var dt) ? dt : defaultValue : TryParseExact(input, [.. format], InvariantCulture, None, out dt) ? dt : defaultValue;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Guid ParseGuid(this string? input, Guid defaultValue = default) => input.IsNullWhiteSpaceImplement() ? defaultValue : Guid.TryParse(input, out var guidResult) ? guidResult : defaultValue;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T ParseEnum<T>(this string? input, T defaultValue = default) where T : unmanaged
        => input.IsNullWhiteSpaceImplement() ? defaultValue : Enum.TryParse(typeof(T), input, true, out var enumResult) ? enumResult.ParseImplement<T>() : defaultValue;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static DateTime ParseDateTime(this string? input) => input.IsNullWhiteSpaceImplement() ? default : TryParse(input, out var dt) ? dt : default;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static DateTime? ParseDateTimeNullable(this string? input) => input.IsNullWhiteSpaceImplement() ? default : TryParse(input, out var dt) ? dt : default(DateTime?);

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T ParseHelper<T>(object? input, object? defaultValue, IEnumerable<string?>? format) where T : unmanaged
    {
        if (typeof(T) == typeof(DateTime))
        {
            return (input?.ToString() ?? default).ParseDateTime((defaultValue?.ToString() ?? default).ParseDateTime(default, format), format).ParseImplement<T>();
        }

        if (typeof(T) == typeof(Guid))
        {
            return (input?.ToString() ?? default).ParseGuid((defaultValue?.ToString() ?? default).ParseGuid(default)).ParseImplement<T>();
        }

        if (typeof(T).IsEnum)
        {
            return (input?.ToString() ?? default).ParseEnum((defaultValue?.ToString() ?? default).ParseEnum<T>(default));
        }

        if (input.IsNullImplement())
        {
            if (defaultValue.IsNullImplement())
            {
                return default;
            }

            try
            {
                return ChangeType(defaultValue, typeof(T)).ParseImplement<T>();
            }
            catch
            {
                return default;
            }
        }

        try
        {
            return ChangeType(input, typeof(T)).ParseImplement<T>();
        }
        catch
        {
            if (defaultValue.IsNullImplement())
            {
                return default;
            }

            try
            {
                return ChangeType(defaultValue, typeof(T)).ParseImplement<T>();
            }
            catch
            {
                return default;
            }
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static Type? GetUnderlyingTypeCached(Type type)
    {
        if (!UnderlyingTypeCache.TryGetValue(type, out var underlyingType))
        {
            underlyingType = GetUnderlyingType(type);
            UnderlyingTypeCache[type] = underlyingType;
        }

        return underlyingType;
    }

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T ParseImplement<T>(this object? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged
        => ParseHelper<T>(input, defaultValue, format);
}
