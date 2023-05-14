using static System.Text.Encoding;

namespace YANLib;

public static partial class YANBytes
{
    public static byte[]? ToByteArray<T>(this T obj) => obj is null ? default : UTF8.GetBytes(obj.Serialize());

    public static IEnumerable<byte[]?>? ToByteArray<T>(this IEnumerable<T> objs) => objs.IsEmptyOrNull() ? default : objs.Select(o => o.ToByteArray());

    public static T? FromByteArray<T>(this byte[] arr) => arr is null ? default : UTF8.GetString(arr).Deserialize<T>();

    public static IEnumerable<T?>? FromByteArray<T>(this IEnumerable<byte[]> arrs) => arrs.IsEmptyOrNull() ? default : arrs.Select(a => a.FromByteArray<T>());
}
