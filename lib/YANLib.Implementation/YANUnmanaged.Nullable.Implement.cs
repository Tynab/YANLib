using System.Diagnostics;

namespace YANLib.Implementation;

internal static partial class YANUnmanaged
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? ParseImplement<T>(this object? input)
    {
        if (input is null)
        {
            return default;
        }

        // already the requested type: return it unchanged. 8.3.3 sent it through Convert.ChangeType or ToString(), which
        // turned reference types typed as a base class or interface into null and dropped DateTime milliseconds and Kind.
        if (input is T value)
        {
            return value;
        }

        return typeof(T) == typeof(string) ? (T?)(object?)input.SafeToString()
            : typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?) ? input.SafeToString().ParseDateTimeNullable() is T dateTime ? dateTime : default
            : typeof(T) == typeof(Guid) || typeof(T) == typeof(Guid?) ? input.SafeToString().ParseGuidNullable() is T guid ? guid : default
            : typeof(T) == typeof(TimeSpan) || typeof(T) == typeof(TimeSpan?) ? input.SafeToString().ParseTimeSpanNullable() is T timeSpan ? timeSpan : default
            : ParseCache<T>.Kind == ParseKind.Enum ? Enum.TryParse(ParseCache<T>.Target, input.SafeToString(), true, out var enumValue) && enumValue is T parsedEnum ? parsedEnum : default
            : ConvertOrDefault(input);

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
