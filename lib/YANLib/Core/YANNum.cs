﻿namespace YANLib.Core;

public static partial class YANNum
{
    /// <summary>
    /// Finds the minimum value in an array of nullable elements that implement <see cref="IComparable{T}"/>.
    /// If the array is <see langword="null"/>, empty, or all elements are <see langword="null"/>, returns the default value of type <typeparamref name="T"/>.
    /// Compares elements to find the minimum value, ignoring <see langword="null"/> elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="nums">The array of nullable elements. Can be <see langword="null"/>.</param>
    /// <returns>The minimum value among the non-null elements in the array, or the default value of type <typeparamref name="T"/> if the array is <see langword="null"/>, empty, or contains only <see langword="null"/> elements.</returns>
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
    /// <returns>The maximum value among the non-null elements in the array, or the default value of type <typeparamref name="T"/> if the array is <see langword="null"/>, empty, or contains only <see langword="null"/> elements.</returns>
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
