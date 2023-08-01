using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{

    public static byte ToByte<T>(this T? num) where T : struct
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

    public static IEnumerable<byte>? ToByte<T>(this IEnumerable<T?> nums) where T : struct => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToByte());

    public static byte ToByte<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToByte(dfltVal.Value) : default;

    public static IEnumerable<byte>? ToByte<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToByte(dfltVal));

    public static byte GenerateRandomByte<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomByte(min.Value, max) : default;

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomByte(min, max));

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomByte(min, max));

    public static byte GenerateRandomByte<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomByte(min, max.Value) : default;

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomByte(min, max));

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomByte(min, max));

    public static byte GenerateRandomByte<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomByte(min.Value, max) : default;

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomByte(min, max));

    public static IEnumerable<byte> GenerateRandomBytes<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomByte(min, max));

    public static byte GenerateRandomByte<T>(T? max) where T : struct => max.HasValue ? GenerateRandomByte(byte.MinValue, max.Value) : default;
}
