using static System.Linq.Enumerable;
using static YANLib.YANNum;

namespace YANLib;

public static partial class YANBool
{
    public static bool ToBool(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToBoolean(num);
        }
        catch
        {
            return dfltVal is not null && dfltVal.ToBool();
        }
    }

    public static IEnumerable<bool>? ToBool(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToBool(dfltVal));

    public static bool GenerateRandomBool() => GenerateRandomByte(0, 2) is 1;

    public static IEnumerable<bool> GenerateRandomBools(object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomBool());
}
