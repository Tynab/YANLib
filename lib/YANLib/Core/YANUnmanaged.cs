using static System.Guid;

namespace YANLib.Core;

public static partial class YANUnmanaged
{
    public static T To<T>(this object? input, object? defaultValue = null) where T : unmanaged
    {
        try
        {
            return input.IsNull() ? defaultValue.IsNull() ? default : (T)Convert.ChangeType(defaultValue, typeof(T)) : (T)Convert.ChangeType(input, typeof(T));
        }
        catch
        {
            try
            {
                return defaultValue.IsNull() ? default : (T)Convert.ChangeType(defaultValue, typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }

    public static IEnumerable<T>? Tos<T>(this IEnumerable<object?>? input, object? defaultValue = null) where T : unmanaged => input.IsEmptyOrNull() ? default : input.Select(x => x.To<T>(defaultValue));

    public static IEnumerable<T>? Tos<T>(this ICollection<object?>? input, object? defaultValue = null) where T : unmanaged => input.IsEmptyOrNull() ? default : input.Select(x => x.To<T>(defaultValue));

    public static IEnumerable<T>? Tos<T>(this object?[]? input, object? defaultValue = null) where T : unmanaged => input.IsEmptyOrNull() ? default : input.Select(x => x.To<T>(defaultValue));

    /// <summary>
    /// Finds the minimum value in an array of nullable elements that implement <see cref="IComparable{T}"/>.
    /// If the array is <see langword="null"/>, empty, or all elements are <see langword="null"/>, returns the default value of type <typeparamref name="T"/>.
    /// Compares elements to find the minimum value, ignoring <see langword="null"/> elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="nums">The array of nullable elements. Can be <see langword="null"/>.</param>
    /// <returns>
    /// The minimum value among the non-null elements in the array, or the default value of type <typeparamref name="T"/> if the array is <see langword="null"/>, empty, or contains only <see langword="null"/> elements.
    /// </returns>
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

    /// <summary>
    /// Finds the maximum value in an array of nullable elements that implement <see cref="IComparable{T}"/>.
    /// If the array is <see langword="null"/>, empty, or all elements are <see langword="null"/>, returns the default value of type <typeparamref name="T"/>.
    /// Compares elements to find the maximum value, ignoring <see langword="null"/> elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="nums">The array of nullable elements. Can be <see langword="null"/>.</param>
    /// <returns>
    /// The maximum value among the non-null elements in the array, or the default value of type <typeparamref name="T"/> if the array is <see langword="null"/>, empty, or contains only <see langword="null"/> elements.
    /// </returns>
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

    public static T Ceiling<T>(this object? input) where T : unmanaged => typeof(T) == typeof(double) ? Math.Ceiling(input.To<double>()).To<T>() : Math.Ceiling(input.To<decimal>()).To<T>();

    public static IEnumerable<T>? Ceilings<T>(this IEnumerable<object?>? input) where T : unmanaged => input.IsEmptyOrNull() ? default : input.Select(x => x.Ceiling<T>());

    public static IEnumerable<T>? Ceilings<T>(this ICollection<object?>? input) where T : unmanaged => input.IsEmptyOrNull() ? default : input.Select(x => x.Ceiling<T>());

    public static IEnumerable<T>? Ceilings<T>(this object?[]? input) where T : unmanaged => input.IsEmptyOrNull() ? default : input.Select(x => x.Ceiling<T>());

    // TODO: Math lib
}
