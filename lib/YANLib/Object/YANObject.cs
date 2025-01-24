using System.Collections;
using System.Diagnostics.CodeAnalysis;
using static System.Reflection.BindingFlags;

namespace YANLib.Object;

public static partial class YANObject
{
    public static bool IsNull([NotNullWhen(false)] this object? input) => input is null;

    public static bool IsNotNull([NotNullWhen(true)] this object? input) => input is not null;

    public static bool IsNullEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? input) => input.IsNull() || !input.Any();

    public static bool IsNotNullEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? input) => input.IsNotNull() && input.Any();

    public static bool AllNull<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNotNull());

    public static bool AllNull<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNotNull());

    public static bool AllNullEmpty<T>(this IEnumerable<T?>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNotNull() && x.AnyPropertiesNotDefault());

    public static bool AllNullEmpty<T>(params T?[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNotNull() && x.AnyPropertiesNotDefault());

    public static bool AnyNull<T>(this IEnumerable<T>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNull());

    public static bool AnyNull<T>(params T[]? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNull());

    public static bool AnyNullEmpty<T>(this IEnumerable<T>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNull() || x.AllPropertiesDefault());

    public static bool AnyNullEmpty<T>(params T[]? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNull() || x.AllPropertiesDefault());

    public static bool AllNotNull<T>(this IEnumerable<T>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNull());

    public static bool AllNotNull<T>(params T[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNull());

    public static bool AllNotNullEmpty<T>(this IEnumerable<T>? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNull() || x.AllPropertiesDefault());

    public static bool AllNotNullEmpty<T>(params T[]? input) where T : class => input.IsNotNullEmpty() && !input.Any(x => x.IsNull() || x.AllPropertiesDefault());

    public static bool AnyNotNull<T>(this IEnumerable<T>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNotNull());

    public static bool AnyNotNullEmpty<T>(this IEnumerable<T>? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNotNull() || x.AnyPropertiesNotDefault());

    public static bool AnyNotNullEmpty<T>(params T[]? input) where T : class => input.IsNotNullEmpty() && input.Any(x => x.IsNotNull() || x.AnyPropertiesNotDefault());

    public static List<T> AsList<T>(this T input) => [input];

    public static HashSet<T> AsHashSet<T>(this T input) => [input];

    public static T[] AsArray<T>(this T input) => [input];

    public static T Copy<T>(this T input) where T : new()
    {
        if (input.IsNull())
        {
            return input;
        }

        var result = new T();
        var props = typeof(T).GetProperties(Public | Instance);

        foreach (var prop in props)
        {
            if (prop.CanRead && prop.CanWrite)
            {
                var val = prop.GetValue(input);

                prop.SetValue(result, val);
            }
        }

        return result;
    }

    public static T? ChangeTimeZoneAllProperty<T>(this T? input, object? tzSrc = null, object? tzDst = null) where T : class
    {
        if (input.IsNull())
        {
            return input;
        }

        var props = typeof(T).GetProperties(Public | Instance).Where(x => x.CanRead && x.CanWrite);

        if (props.Any())
        {
            foreach (var prop in props)
            {
                if (prop.IsNull())
                {
                    continue;
                }

                var val = prop.GetValue(input);

                if (val.IsNull())
                {
                    continue;
                }

                if (val is DateTime dt)
                {
                    prop.SetValue(input, dt.ChangeTimeZone(tzSrc, tzDst));
                }
                else if (val.GetType().IsClass)
                {
                    var changedVal = val.ChangeTimeZoneAllProperty(tzSrc, tzDst);

                    if (changedVal.IsNotNull())
                    {
                        prop.SetValue(input, changedVal);
                    }
                }
                else if (val.GetType().IsGenericType && val.GetType().GetGenericTypeDefinition() == typeof(IList<>))
                {
                    var list = (IList)val;

                    if (list.Count is not 0)
                    {
                        for (var i = 0; i < list.Count; i++)
                        {
                            if (list[i].IsNull())
                            {
                                continue;
                            }

                            var changedItem = list[i].ChangeTimeZoneAllProperty(tzSrc, tzDst);

                            if (changedItem.IsNotNull())
                            {
                                list[i] = changedItem;
                            }
                        }
                    }
                }
            }
        }

        return input;
    }

    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this IEnumerable<T?>? input, object? tzSrc = null, object? tzDst = null) where T : class => input.IsNullEmpty()
        ? input
        : input.Select(x => x.ChangeTimeZoneAllProperty(tzSrc, tzDst));

    public static IEnumerable<T?>? ChangeTimeZoneAllProperties<T>(this T?[]? input, object? tzSrc = null, object? tzDst = null) where T : class => input.IsNullEmpty()
        ? input
        : input.Select(x => x.ChangeTimeZoneAllProperty(tzSrc, tzDst));
}
