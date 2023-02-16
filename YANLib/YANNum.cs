namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Returns the minimum element in <paramref name="arr"/>, as determined by the default comparer, which is the element with the smallest value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="arr">An array of elements of type <typeparamref name="T"/>.</param>
    /// <returns>The minimum element in <paramref name="arr"/>, or the default value for type <typeparamref name="T"/> if <paramref name="arr"/> is empty.</returns>
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
    /// Returns the maximum element in <paramref name="arr"/>, as determined by the default comparer, which is the element with the largest value.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="arr">An array of elements of type <typeparamref name="T"/>.</param>
    /// <returns>The maximum element in <paramref name="arr"/>, or the default value for type <typeparamref name="T"/> if <paramref name="arr"/> is empty.</returns>
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
