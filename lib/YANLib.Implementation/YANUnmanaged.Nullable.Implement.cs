using System.Diagnostics;
using static System.Convert;
using static System.Guid;
using static System.Nullable;

namespace YANLib.Implementation;

internal static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ParseImplement<T>(this object? input)
    {
        return input.IsNullImplement()
            ? default
            : typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>) && GetUnderlyingType(typeof(T)) is Type enumUnderlying && enumUnderlying.IsEnum
            ? Enum.TryParse(enumUnderlying, input.ToString(), true, out var enumResult) ? (T?)enumResult : default
            : typeof(T) switch
            {
                Type stringType when stringType == typeof(string) => (T?)(object?)input.ToString(),
                Type dateTimeType when dateTimeType == typeof(DateTime) => (T)(object)input.ToString().ParseDateTime(),
                Type nullableDateTimeType when nullableDateTimeType == typeof(DateTime?) => (T?)(object?)input.ToString().ParseDateTimeNullable(),
                Type guidType when guidType == typeof(Guid) && TryParse(input.ToString(), out var guidValue) => (T)(object)guidValue,
                Type nullableGuidType when nullableGuidType == typeof(Guid?) && TryParse(input.ToString(), out var guidValue) => (T?)(object?)guidValue,
                Type enumType when enumType.IsEnum && Enum.TryParse(enumType, input.ToString(), true, out var enumValue) => (T)enumValue,
                _ => GetUnderlyingTypeCached(typeof(T)) is Type underlyingType ? ChangeTypeOrDefault(input, underlyingType) : ChangeTypeOrDefault(input, typeof(T))
            };

        static T? ChangeTypeOrDefault(object input, Type targetType)
        {
            try
            {
                if (targetType == typeof(char) && input is not string)
                {
                    input = input.ToString()!;
                }

                return (T?)ChangeType(input, targetType);
            }
            catch
            {
                return default;
            }
        }
    }
}
