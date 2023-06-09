using static System.Linq.Enumerable;
using static YANLib.YANNum;

namespace YANLib;

public static partial class YANBool
{

    public static bool GenerateRandomBool() => GenerateRandomByte(0, 2) is 1;


    public static IEnumerable<bool> GenerateRandomBools<T>(T size) where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomBool());
}
