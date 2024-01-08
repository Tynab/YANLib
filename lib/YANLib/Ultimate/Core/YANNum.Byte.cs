using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANNum
{
    public static IEnumerable<byte> ToBytes(this IEnumerable<object?> vals, object? dfltVal = null)
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

    public static IEnumerable<byte> ToBytes(this ICollection<object?> vals, object? dfltVal = null)
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

    public static IEnumerable<byte> ToBytes(this object?[] vals, object? dfltVal = null)
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

    public static IEnumerable<byte> GenerateRandomBytes(object? min = null, object? max = null, object? size = null)
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.Core.YANNum.GenerateRandomByte(min, max);
        }
    }
}
