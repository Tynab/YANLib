using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANNum
{
    public static IEnumerable<byte> ToBytes(this IEnumerable<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToByte(dfltVal);
        }
    }

    public static IEnumerable<byte> ToBytes(this ICollection<object?>? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToByte(dfltVal));

    public static IEnumerable<byte> ToBytes(this object?[]? nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToByte(dfltVal));

    public static IEnumerable<byte> GenerateRandomBytes(object? min = null, object? max = null, object? size = null) => Range(0, (int)size.ToUint()).Select(i => GenerateRandomByte(min, max));
}
