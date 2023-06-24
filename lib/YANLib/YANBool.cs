using static System.Linq.Enumerable;
using static YANLib.YANNum;

namespace YANLib;

public static partial class YANBool
{
    public static bool ToBool<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToBoolean(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<bool> ToBool<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToBool();
        }
    }

    public static bool ToBool(this string str) => bool.TryParse(str, out var num) && num;

    public static IEnumerable<bool> ToBool(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToBool();
        }
    }

    public static bool ToBool<T>(this string str, T dfltVal) where T : struct => bool.TryParse(str, out var num) ? num : dfltVal.ToBool();

    public static IEnumerable<bool> ToBool<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToBool(dfltVal);
        }
    }

    public static bool GenerateRandomBool() => GenerateRandomByte(0, 2) is 1;

    public static IEnumerable<bool> GenerateRandomBools<T>(T size) where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomBool());
}
