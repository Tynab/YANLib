namespace YANLib.Ultimate;

public static partial class YANBytes
{
    public static IEnumerable<byte[]?>? ToByteArray<T>(this IEnumerable<T> objs)
    {
        if (objs.IsEmptyOrNull())
        {
            yield break;
        }
        foreach (var obj in objs)
        {
            yield return obj.ToByteArray();
        }
    }

    public static IEnumerable<byte[]?>? ToByteArrayCamel<T>(this IEnumerable<T> objs)
    {
        if (objs.IsEmptyOrNull())
        {
            yield break;
        }
        foreach (var obj in objs)
        {
            yield return obj.ToByteArrayCamel();
        }
    }

    public static IEnumerable<T?>? FromByteArray<T>(this IEnumerable<byte[]> arrs)
    {
        if (arrs.IsEmptyOrNull())
        {
            yield break;
        }
        foreach(var arr in arrs)
        {
            yield return arr.FromByteArray<T>();
        }
    }

    public static IEnumerable<T?>? FromByteArrayCamel<T>(this IEnumerable<byte[]> arrs)
    {
        if (arrs.IsEmptyOrNull())
        {
            yield break;
        }
        foreach (var arr in arrs)
        {
            yield return arr.FromByteArrayCamel<T>();
        }
    }
}
