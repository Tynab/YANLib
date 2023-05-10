using static System.Text.Encoding;

namespace YANLib;

public static partial class YANBytes
{
    public static byte[]? ToByteArray<T>(this T obj) => obj is null ? default : UTF8.GetBytes(obj.Serialize());

    public static T? FromByteArray<T>(this byte[] bytes) => bytes is null ? default : UTF8.GetString(bytes).DeserializeDuo<T>();

    public static byte[]? ToByteArrayCamel<T>(this T obj) => obj is null ? default : UTF8.GetBytes(obj.SerializeCamel());

    public static T? FromByteArrayCamel<T>(this byte[] bytes) => bytes is null ? default : UTF8.GetString(bytes).DeserializeDuoCamelPriority<T>();
}
