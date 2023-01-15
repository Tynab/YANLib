namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Returns the smallest item in params.
    /// </summary>
    /// <typeparam name="T">Object type.</typeparam>
    /// <param name="arr">Params.</param>
    /// <returns>Smallest item.</returns>
    public static T Min<T>(params T[] arr)
    {
        dynamic min = 0;
        try
        {
            foreach (var item in arr)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }
        catch
        {
            return arr[0];
        }
    }

    /// <summary>
    /// Returns the largest item in params.
    /// </summary>
    /// <typeparam name="T">Object type.</typeparam>
    /// <param name="arr">Params.</param>
    /// <returns>Largest item.</returns>
    public static T Max<T>(params T[] arr)
    {
        dynamic max = 0;
        try
        {
            foreach (var item in arr)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }
        catch
        {
            return arr[0];
        }
    }
}
