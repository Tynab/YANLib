using System.Diagnostics;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    /// <summary>
    /// The smallest (<paramref name="max"/> = <c>false</c>) or largest non-null value, or <c>default</c> when there is none.
    /// </summary>
    /// <remarks>
    /// Compares like <see cref="Enumerable.Min{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>, which 8.3.3 called:
    /// <see cref="Comparer{T}.Default"/>, the first of equal values wins, and NaN is the smallest double. LINQ throws
    /// "Sequence contains no elements" for a value type when every element is null; this returns <c>default</c>, as for empty input.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static T? MinMax<T>(IEnumerable<T?> values, bool max)
    {
        var comparer = Comparer<T?>.Default;
        var found = false;
        T? result = default;

        foreach (var value in values)
        {
            if (value is null)
            {
                continue;
            }

            if (!found)
            {
                result = value;
                found = true;

                continue;
            }

            var order = comparer.Compare(value, result);

            if (max ? order > 0 : order < 0)
            {
                result = value;
            }
        }

        return result;
    }

    /// <summary>
    /// The mean of <paramref name="values"/> computed like <see cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, double})"/>
    /// (the sum starts from the first value), or <c>false</c> when there are no values (LINQ throws).
    /// </summary>
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryAverage(IEnumerable<double> values, out double average)
    {
        using var enumerator = values.GetEnumerator();

        if (!enumerator.MoveNext())
        {
            average = default;

            return false;
        }

        var sum = enumerator.Current;
        var count = 1L;

        while (enumerator.MoveNext())
        {
            sum += enumerator.Current;
            count++;
        }

        average = sum / count;

        return true;
    }
}
