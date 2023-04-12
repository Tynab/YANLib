using static YANLib.YANNum;

namespace YANLib;

public static partial class YANBool
{
    public static bool GenerateRandomBool() => GenerateRandomByte(0, 2) == 1;

    public static IEnumerable<bool> GenerateRandomBools<T>(T size) where T : struct
    {
        var cnt = size.ToUlong();
        for (var i = 0ul; i < cnt; i++)
        {
            yield return GenerateRandomBool();
        }
    }
}
