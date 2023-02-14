namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Returns the minimum value in a sequence of values.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the array.</typeparam>
    /// <param name="arr">An array of values to determine the minimum value of. Must not be null.</param>
    /// <returns>The minimum value in the sequence represented by <paramref name="arr"/>.</returns>
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
    /// Returns the maximum value in a sequence of values.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the array.</typeparam>
    /// <param name="arr">An array of values to determine the maximum value of. Must not be null.</param>
    /// <returns>The maximum value in the sequence represented by <paramref name="arr"/>.</returns>
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
