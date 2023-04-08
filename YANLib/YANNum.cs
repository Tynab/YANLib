namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Finds the minimum value in an array of values that implement the <see cref="IComparable{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of the values in the array.</typeparam>
    /// <param name="arr">The array of values to find the minimum value in.</param>
    /// <returns>The minimum value in the array.</returns>
    public static T Min<T>(params T[] arr) where T : IComparable<T>
    {
        var min = arr[0];
        for (var i = 1; i < arr?.Length; i++)
        {
            if (arr[i]?.CompareTo(min) < 0)
            {
                min = arr[i];
            }
        }
        return min;
    }

    /// <summary>
    /// Finds the maximum value in an array of values that implement the <see cref="IComparable{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of the values in the array.</typeparam>
    /// <param name="arr">The array of values to find the maximum value in.</param>
    /// <returns>The maximum value in the array.</returns>
    public static T Max<T>(params T[] arr) where T : IComparable<T>
    {
        var max = arr[0];
        for (var i = 1; i < arr?.Length; i++)
        {
            if (arr[i]?.CompareTo(max) > 0)
            {
                max = arr[i];
            }
        }
        return max;
    }
}
