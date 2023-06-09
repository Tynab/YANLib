namespace YANLib;

public static partial class YANNum
{

    public static T? Min<T>(params T[] nums) where T : IComparable<T>
    {
        if (nums is null || nums.Length < 1)
        {
            return default;
        }
        var min = nums[0];
        for (var i = 1; i < nums?.Length; i++)
        {
            if (nums[i] is not null && nums[i].CompareTo(min) < 0)
            {
                min = nums[i];
            }
        }
        return min;
    }

    public static T? Max<T>(params T[] nums) where T : IComparable<T>
    {
        if (nums is null || nums.Length < 1)
        {
            return default;
        }
        var max = nums[0];
        for (var i = 1; i < nums?.Length; i++)
        {
            if (nums[i]?.CompareTo(max) > 0)
            {
                max = nums[i];
            }
        }
        return max;
    }
}
