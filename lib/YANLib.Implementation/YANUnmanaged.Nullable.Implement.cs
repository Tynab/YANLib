using System.Diagnostics;
using static System.Convert;
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
                return typeof(T) == typeof(byte)
                    || typeof(T) == typeof(sbyte)
                    || typeof(T) == typeof(short)
                    || typeof(T) == typeof(ushort)
                    || typeof(T) == typeof(int)
                    || typeof(T) == typeof(uint)
                    || typeof(T) == typeof(long)
                    || typeof(T) == typeof(ulong)
                    || typeof(T) == typeof(nint)
                    || typeof(T) == typeof(nuint)
                    ? input.ParseImplement<decimal>(default).FloorImplement().ParseImplement<T>()
                    : default;
            }
        }
    }
}
