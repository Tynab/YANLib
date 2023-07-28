namespace YANLib;

public static partial class YANNum
{

    public static decimal ToDecimal<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToDecimal(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<decimal> ToDecimal<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }

        foreach (var num in nums)
        {
            yield return num.ToDecimal();
        }
    }

    public static decimal ToDecimal(this string str) => decimal.TryParse(str, out var num) ? num : default;

    public static IEnumerable<decimal> ToDecimal(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }

        foreach (var num in strs)
        {
            yield return num.ToDecimal();
        }
    }

    public static decimal ToDecimal<T>(this string str, T dfltVal) where T : struct => decimal.TryParse(str, out var num) ? num : dfltVal.ToDecimal();

    public static IEnumerable<decimal> ToDecimal<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }

        foreach (var num in strs)
        {
            yield return num.ToDecimal(dfltVal);
        }
    }

    public static decimal GenerateRandomDecimal<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToDecimal();
        var maxValue = max.ToDecimal();

        return minValue > maxValue ? default : new Random().NextDecimal(minValue, maxValue);
    }

    public static IEnumerable<decimal> GenerateRandomDecimals<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomDecimal(min, max);
        }
    }

    public static decimal GenerateRandomDecimal() => GenerateRandomDecimal(decimal.MinValue, decimal.MaxValue);

    public static decimal GenerateRandomDecimal<T>(T max) where T : struct => GenerateRandomDecimal(decimal.MinValue, max);
}
