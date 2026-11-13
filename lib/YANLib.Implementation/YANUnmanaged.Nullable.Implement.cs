using System.Diagnostics;
using static System.Nullable;

namespace YANLib.Implementation;

internal static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ParseImplement<T>(this object? input)
    {
        return input is null
            ? default
            : typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>) && GetUnderlyingType(typeof(T)) is Type enumUnderlying && enumUnderlying.IsEnum
            ? Enum.TryParse(enumUnderlying, input.ToString(), true, out var enumResult) ? (T?)enumResult : default
            : typeof(T) switch
            {
                Type stringType when stringType == typeof(string) => (T?)(object?)input.ToString(),
                Type dateTimeType when dateTimeType == typeof(DateTime) => (T)(object)input.ToString().ParseDateTime(),
                Type nullableDateTimeType when nullableDateTimeType == typeof(DateTime?) => (T?)(object?)input.ToString().ParseDateTimeNullable(),
                Type guidType when guidType == typeof(Guid) => (T)(object)input.ToString().ParseGuid(),
                Type nullableGuidType when nullableGuidType == typeof(Guid?) => (T?)(object?)input.ToString().ParseGuidNullable(),
                Type timeSpanType when timeSpanType == typeof(TimeSpan) => (T)(object)input.ToString().ParseTimeSpan(),
                Type nullableTimeSpanType when nullableTimeSpanType == typeof(TimeSpan?) => (T?)(object?)input.ToString().ParseTimeSpanNullable(),
                Type enumType when enumType.IsEnum && Enum.TryParse(enumType, input.ToString(), true, out var e) => (T)e,
                _ => ConvertOrDefault(input)
            };

        static T? ConvertOrDefault(object input)
        {
            // the one-argument overload turns non-string input into text for char targets (5 -> '5', not '\u0005')
            if (ParseCache<T>.Kind == ParseKind.Char && input is not string)
            {
                if (input.SafeToString() is not string text)
                {
                    return default;
                }

                input = text;
            }

            return TryChangeType(input, ParseCache<T>.Target, ParseCache<T>.Kind, ParseCache<T>.FloorFractions, out var result) && result is T value ? value : default;
        }
    }
}
