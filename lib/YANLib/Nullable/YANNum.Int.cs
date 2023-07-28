namespace YANLib.Nullable;

public static partial class YANNum
{

    public static int? ToInt<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToInt32(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<int?> ToInt<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }

        foreach (var num in nums)
        {
            yield return num.ToInt();
        }
    }

    public static int? ToInt(this string str) => int.TryParse(str, out var num) ? num : default;

    public static IEnumerable<int?> ToInt(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }

        foreach (var num in strs)
        {
            yield return num.ToInt();
        }
    }

    public static int? ToInt<T>(this string str, T dfltVal) where T : struct => int.TryParse(str, out var num) ? num : dfltVal.ToInt();

    public static IEnumerable<int?> ToInt<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }

        foreach (var num in strs)
        {
            yield return num.ToInt(dfltVal);
        }
    }

    public static int? GenerateRandomInt<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToInt();
        var maxValue = max.ToInt();

        return minValue.HasValue && maxValue.HasValue ? minValue > maxValue ? default : new Random().Next(minValue.Value, maxValue.Value) : default;
    }

    public static IEnumerable<int?> GenerateRandomInts<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomInt(min, max);
        }
    }

    public static int? GenerateRandomInt() => GenerateRandomInt(int.MinValue, int.MaxValue);

    public static int? GenerateRandomInt<T>(T max) where T : struct => GenerateRandomInt(int.MinValue, max);
}
