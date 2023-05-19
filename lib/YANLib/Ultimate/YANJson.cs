namespace YANLib.Ultimate;

public static partial class YANJson
{
    public static IEnumerable<string> Serializes<T>(this IEnumerable<T> mdls)
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.Serialize();
        }
    }

    public static IEnumerable<string> CamelSerializes<T>(this IEnumerable<T> mdls)
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.CamelSerialize();
        }
    }

    public static IEnumerable<T?> StandardDeserializes<T>(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.StandardDeserialize<T>();
        }
    }

    public static IEnumerable<T?> Deserializes<T>(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.Deserialize<T>();
        }
    }
}
