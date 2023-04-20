namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Finds the minimum value in an array of values that implement the <see cref="IComparable{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of the values in the array.</typeparam>
    /// <param name="nums">The array of values to find the minimum value in.</param>
    /// <returns>The minimum value in the array.</returns>
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

    /// <summary>
    /// Finds the maximum value in an array of values that implement the <see cref="IComparable{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of the values in the array.</typeparam>
    /// <param name="nums">The array of values to find the maximum value in.</param>
    /// <returns>The maximum value in the array.</returns>
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
