namespace YANLib.Core;

public static partial class YANNum
{

    public static T? Min<T>(params T?[]? nums) where T : IComparable<T>
    {
        if (nums.IsEmptyOrNull())
        {
            return default;
        }

        var min = nums.FirstOrDefault();

        foreach (var item in nums)
        {
            if (item?.CompareTo(min) < 0)
            {
                min = item;
            }
        }

        return min;
    }

    public static T? Max<T>(params T?[]? nums) where T : IComparable<T>
    {
        if (nums.IsEmptyOrNull())
        {
            return default;
        }

        var max = nums.FirstOrDefault();

        foreach (var item in nums)
        {
            if (item?.CompareTo(max) > 0)
            {
                max = item;
            }
        }

        return max;
    }
}
