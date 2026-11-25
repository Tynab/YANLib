
namespace YANLib.Implementation;

internal static partial class YANUnmanaged
{
    internal static T? ParseImplement<T>(this object? input) => input.ParseWithImplement<T>(null);

    /// <param name="input">The object to parse.</param>
    /// <param name="provider">The culture for every culture-dependent step; <c>null</c> keeps the 8.3.3 behaviour (current culture).</param>
    internal static T? ParseWithImplement<T>(this object? input, IFormatProvider? provider)
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

        return typeof(T) == typeof(string) ? (T?)(object?)input.SafeToString(provider)
            : typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?) ? input.SafeToString(provider).ParseDateTimeNullable(provider) is T dateTime ? dateTime : default
            : typeof(T) == typeof(Guid) || typeof(T) == typeof(Guid?) ? input.SafeToString(provider).ParseGuidNullable() is T guid ? guid : default
            : typeof(T) == typeof(TimeSpan) || typeof(T) == typeof(TimeSpan?) ? input.SafeToString(provider).ParseTimeSpanNullable(provider) is T timeSpan ? timeSpan : default
            : ParseCache<T>.Kind == ParseKind.Enum ? Enum.TryParse(ParseCache<T>.Target, input.SafeToString(provider), true, out var enumValue) && enumValue is T parsedEnum ? parsedEnum : default
            : ConvertOrDefault(input, provider);

        static T? ConvertOrDefault(object input, IFormatProvider? provider)
        {
            // the one-argument overload turns non-string input into text for char targets (5 -> '5', not '\u0005')
            if (ParseCache<T>.Kind == ParseKind.Char && input is not string)
            {
                if (input.SafeToString(provider) is not string text)
                {
                    return default;
                }

                input = text;
            }

            return TryChangeType(input, ParseCache<T>.Target, ParseCache<T>.Kind, ParseCache<T>.FloorFractions, provider, out var result) && result is T value ? value : default;
        }
    }
}
