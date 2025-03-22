using System.Diagnostics;
using YANLib.Object;
using static System.Convert;

namespace YANLib.Implements.Unmanaged;

internal static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ParseImplement<T>(this object? input)
    {
        return input.IsNull() ? default : typeof(T) switch
        {
            Type stringType when stringType == typeof(string) => (T?)(object?)input.ToString(),
            Type dateTimeType when dateTimeType == typeof(DateTime) => (T)(object)input.ToString().ParseDateTime(),
            Type nullableDateTimeType when nullableDateTimeType == typeof(DateTime?) => (T?)(object?)input.ToString().ParseDateTimeNullable(),
            Type guidType when guidType == typeof(Guid) && Guid.TryParse(input.ToString(), out var guidValue) => (T)(object)guidValue,
            Type nullableGuidType when nullableGuidType == typeof(Guid?) && Guid.TryParse(input.ToString(), out var guidValue) => (T?)(object?)guidValue,
            _ => GetUnderlyingTypeCached(typeof(T)) is Type underlyingType ? ChangeTypeOrDefault(input, underlyingType) : ChangeTypeOrDefault(input, typeof(T))
        };

        static T? ChangeTypeOrDefault(object input, Type targetType)
        {
            try
            {
                return (T?)ChangeType(input, targetType);
            }
            catch
            {
                return default;
            }
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? ParsesImplement<T>(this IEnumerable<object?>? input) => input.IsNullEmpty() ? default : input.Select(x => x.ParseImplement<T?>());
}
