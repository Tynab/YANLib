using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{

    public static byte ToByte<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToByte(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<byte>? ToByte<T>(this IEnumerable<T> nums) where T : struct => nums is null || !nums.Any() ? default : nums.Select(n => n.ToByte());

    public static byte ToByte(this string str) => byte.TryParse(str, out var num) ? num : default;

    public static IEnumerable<byte>? ToByte(this IEnumerable<string> strs) => strs is null || !strs.Any() ? default : strs.Select(s => s.ToByte());

    public static byte ToByte<T>(this string str, T dfltVal) where T : struct => byte.TryParse(str, out var num) ? num : dfltVal.ToByte();

    public static IEnumerable<byte>? ToByte<T>(this IEnumerable<string> strs, T dfltVal) where T : struct => strs is null || !strs.Any() ? default : strs.Select(s => s.ToByte(dfltVal));

    public static byte GenerateRandomByte<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToByte();
        var maxValue = max.ToByte();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToByte();
    }

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomByte(min, max));

    public static byte GenerateRandomByte() => GenerateRandomByte(byte.MinValue, byte.MaxValue);

    public static byte GenerateRandomByte<T>(T max) where T : struct => GenerateRandomByte(byte.MinValue, max);
}
