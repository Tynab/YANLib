using static YANLib.YANNum;

namespace YANLib;

public static partial class YANBool
{
    public static bool GenerateRandomBool() => GenerateRandomByte(0, 2) == 1;
}
