using System.Numerics;

namespace YANLib.Nullable;

public static partial class YANNum
{
    
    public static nuint? ToNuint<T>(this T num) where T : struct
    {
        try
        {
            return new UIntPtr(Convert.ToUInt64(num));
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<nuint?> ToNuint<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToNuint();
        }
    }

    public static nuint? ToNuint(this string str) => nuint.TryParse(str, out var num) ? num : default;

    public static IEnumerable<nuint?> ToNuint(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNuint();
        }
    }

    public static nuint? ToNuint<T>(this string str, T dfltVal) where T : struct => nuint.TryParse(str, out var num) ? num : dfltVal.ToNuint();

    public static IEnumerable<nuint?> ToNuint<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNuint(dfltVal);
        }
    }

    public static nuint? GenerateRandomNuint<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToNuint();
        var maxValue = max.ToNuint();
        return minValue.HasValue && maxValue.HasValue ? minValue > maxValue ? default : (new Random().NextInt64(nint.MinValue, (long)(maxValue - (minValue - (BigInteger)nint.MinValue))) - nint.MinValue).ToNuint() + minValue : default;
    }

    public static IEnumerable<nuint?> GenerateRandomNuints<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomNuint(min, max);
        }
    }

    public static nuint? GenerateRandomNuint() => GenerateRandomNuint(nuint.MinValue, nuint.MaxValue);

    public static nuint? GenerateRandomNuint<T>(T max) where T : struct => GenerateRandomNuint(nuint.MinValue, max);
}
