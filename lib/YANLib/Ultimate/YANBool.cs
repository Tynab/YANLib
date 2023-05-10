namespace YANLib.Ultimate;

public static partial class YANBool
{
    public static IEnumerable<bool> GenerateRandomBools<T>(T size) where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.YANBool.GenerateRandomBool();
        }
    }
}
