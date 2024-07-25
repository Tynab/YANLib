namespace YANLib.Core;

public static partial class YANNum
{
    public static T To<T>(this object? val, object? dfltVal = null) where T : unmanaged
    {
        try
        {
            return val.IsNull() ? dfltVal.IsNull() ? default : (T)Convert.ChangeType(dfltVal, typeof(T)) : (T)Convert.ChangeType(val, typeof(T));
        }
        catch
        {
            try
            {
                return dfltVal.IsNull() ? default : (T)Convert.ChangeType(dfltVal, typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }

    public static IEnumerable<T>? Tos<T>(this IEnumerable<object?>? vals, object? dfltVal = null) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.To<T>(dfltVal));

    public static IEnumerable<T>? Tos<T>(this ICollection<object?>? vals, object? dfltVal = null) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.To<T>(dfltVal));

    public static IEnumerable<T>? Tos<T>(this object?[]? vals, object? dfltVal = null) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.To<T>(dfltVal));

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

    public static T Ceiling<T>(this object? val) where T : unmanaged => typeof(T) == typeof(double) ? Math.Ceiling(val.ToDouble()).To<T>() : Math.Ceiling(val.ToDecimal()).To<T>();

    public static IEnumerable<T>? Ceilings<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Ceiling<T>());

    public static IEnumerable<T>? Ceilings<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Ceiling<T>());

    public static IEnumerable<T>? Ceilings<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Ceiling<T>());

    public static T Floor<T>(this object? val) where T : unmanaged => typeof(T) == typeof(double) ? Math.Floor(val.ToDouble()).To<T>() : Math.Floor(val.ToDecimal()).To<T>();

    public static IEnumerable<T>? Floors<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Floor<T>());

    public static IEnumerable<T>? Floors<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Floor<T>());

    public static IEnumerable<T>? Floors<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Floor<T>());

    public static T Round<T>(this object? val, object? digits = null) where T : unmanaged => typeof(T) == typeof(double)
        ? (digits.IsNull() ? Math.Round(val.ToDouble()) : Math.Round(val.ToDouble(), digits.ToInt())).To<T>()
        : (digits.IsNull() ? Math.Round(val.ToDecimal()) : Math.Round(val.ToDecimal(), digits.ToInt())).To<T>();

    public static IEnumerable<T>? Rounds<T>(this IEnumerable<object?>? vals, object? digits = null) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Round<T>(digits));

    public static IEnumerable<T>? Rounds<T>(this ICollection<object?>? vals, object? digits = null) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Round<T>(digits));

    public static IEnumerable<T>? Rounds<T>(this object?[]? vals, object? digits = null) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Round<T>(digits));

    public static T Abs<T>(this object? val) where T : unmanaged => typeof(T) == typeof(double) ? Math.Abs(val.ToDouble()).To<T>() : Math.Abs(val.ToDecimal()).To<T>();

    public static IEnumerable<T>? Abses<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Abs<T>());

    public static IEnumerable<T>? Abses<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Abs<T>());

    public static IEnumerable<T>? Abses<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Abs<T>());

    public static T Pow<T>(this object? val, object? power) where T : unmanaged => Math.Pow(val.ToDouble(), power.ToDouble()).To<T>();

    public static IEnumerable<T>? Pows<T>(this IEnumerable<object?>? vals, object power) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Pow<T>(power));

    public static IEnumerable<T>? Pows<T>(this ICollection<object?>? vals, object power) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Pow<T>(power));

    public static IEnumerable<T>? Pows<T>(this object?[]? vals, object power) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Pow<T>(power));

    public static T Sqrt<T>(this object? val) where T : unmanaged => Math.Sqrt(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Sqrts<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Sqrt<T>());

    public static IEnumerable<T>? Sqrts<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Sqrt<T>());

    public static IEnumerable<T>? Sqrts<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Sqrt<T>());

    public static T Log<T>(this object? val, object? newBase = null) where T : unmanaged => (newBase.IsNull() ? Math.Log(val.ToDouble()) : Math.Log(val.ToDouble(), newBase.ToDouble())).To<T>();

    public static IEnumerable<T>? Logs<T>(this IEnumerable<object?>? vals, object? newBase = null) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Log<T>(newBase));

    public static IEnumerable<T>? Logs<T>(this ICollection<object?>? vals, object? newBase = null) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Log<T>(newBase));

    public static IEnumerable<T>? Logs<T>(this object?[]? vals, object? newBase = null) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Log<T>(newBase));

    public static T Log2<T>(this object? val) where T : unmanaged => Math.Log2(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Log2s<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Log2<T>());

    public static IEnumerable<T>? Log2s<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Log2<T>());

    public static IEnumerable<T>? Log2s<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Log2<T>());

    public static T Log10<T>(this object? val) where T : unmanaged => Math.Log10(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Log10s<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Log10<T>());

    public static IEnumerable<T>? Log10s<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Log10<T>());

    public static IEnumerable<T>? Log10s<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Log10<T>());

    public static T Sin<T>(this object? val) where T : unmanaged => Math.Sin(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Sins<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Sin<T>());

    public static IEnumerable<T>? Sins<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Sin<T>());

    public static IEnumerable<T>? Sins<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Sin<T>());

    public static T Cos<T>(this object? val) where T : unmanaged => Math.Cos(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Coss<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Cos<T>());

    public static IEnumerable<T>? Coss<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Cos<T>());

    public static IEnumerable<T>? Coss<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Cos<T>());

    public static T Tan<T>(this object? val) where T : unmanaged => Math.Tan(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Tans<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Tan<T>());

    public static IEnumerable<T>? Tans<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Tan<T>());

    public static IEnumerable<T>? Tans<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Tan<T>());

    public static T Asin<T>(this object? val) where T : unmanaged => Math.Asin(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Asins<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Asin<T>());

    public static IEnumerable<T>? Asins<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Asin<T>());

    public static IEnumerable<T>? Asins<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Asin<T>());

    public static T Acos<T>(this object? val) where T : unmanaged => Math.Acos(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Acoss<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Acos<T>());

    public static IEnumerable<T>? Acoss<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Acos<T>());

    public static IEnumerable<T>? Acoss<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Acos<T>());

    public static T Atan<T>(this object? val) where T : unmanaged => Math.Atan(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Atans<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Atan<T>());

    public static IEnumerable<T>? Atans<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Atan<T>());

    public static IEnumerable<T>? Atans<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Atan<T>());

    public static T Sinh<T>(this object? val) where T : unmanaged => Math.Sinh(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Sinhs<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Sinh<T>());

    public static IEnumerable<T>? Sinhs<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Sinh<T>());

    public static IEnumerable<T>? Sinhs<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Sinh<T>());

    public static T Cosh<T>(this object? val) where T : unmanaged => Math.Cosh(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Coshs<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Cosh<T>());

    public static IEnumerable<T>? Coshs<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Cosh<T>());

    public static IEnumerable<T>? Coshs<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Cosh<T>());

    public static T Tanh<T>(this object? val) where T : unmanaged => Math.Tanh(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Tanhs<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Tanh<T>());

    public static IEnumerable<T>? Tanhs<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Tanh<T>());

    public static IEnumerable<T>? Tanhs<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Tanh<T>());

    public static T Asinh<T>(this object? val) where T : unmanaged => Math.Asinh(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Asinhs<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Asinh<T>());

    public static IEnumerable<T>? Asinhs<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Asinh<T>());

    public static IEnumerable<T>? Asinhs<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Asinh<T>());

    public static T Acosh<T>(this object? val) where T : unmanaged => Math.Acosh(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Acoshs<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Acosh<T>());

    public static IEnumerable<T>? Acoshs<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Acosh<T>());

    public static IEnumerable<T>? Acoshs<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Acosh<T>());

    public static T Atanh<T>(this object? val) where T : unmanaged => Math.Atanh(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Atanhs<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Atanh<T>());

    public static IEnumerable<T>? Atanhs<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Atanh<T>());

    public static IEnumerable<T>? Atanhs<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Atanh<T>());

    public static T Truncate<T>(this object? val) where T : unmanaged => typeof(T) == typeof(double) ? Math.Truncate(val.ToDouble()).To<T>() : Math.Truncate(val.ToDecimal()).To<T>();

    public static IEnumerable<T>? Truncates<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Truncate<T>());

    public static IEnumerable<T>? Truncates<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Truncate<T>());

    public static IEnumerable<T>? Truncates<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Truncate<T>());

    public static T Exp<T>(this object? val) where T : unmanaged => Math.Exp(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Exps<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Exp<T>());

    public static IEnumerable<T>? Exps<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Exp<T>());

    public static IEnumerable<T>? Exps<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Exp<T>());

    public static T Clamp<T>(this object? val, object? min, object? max) where T : unmanaged => typeof(T) == typeof(double)
        ? Math.Clamp(val.ToDouble(), min.ToDouble(), max.ToDouble()).To<T>()
        : Math.Clamp(val.ToDecimal(), min.ToDecimal(), max.ToDecimal()).To<T>();

    public static IEnumerable<T>? Clamps<T>(this IEnumerable<object?>? vals, object? min, object? max) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Clamp<T>(min, max));

    public static IEnumerable<T>? Clamps<T>(this ICollection<object?>? vals, object? min, object? max) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Clamp<T>(min, max));

    public static IEnumerable<T>? Clamps<T>(this object?[]? vals, object? min, object? max) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Clamp<T>(min, max));

    public static T Cbrt<T>(this object? val) where T : unmanaged => Math.Cbrt(val.ToDouble()).To<T>();

    public static IEnumerable<T>? Cbrts<T>(this IEnumerable<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Cbrt<T>());

    public static IEnumerable<T>? Cbrts<T>(this ICollection<object?>? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Cbrt<T>());

    public static IEnumerable<T>? Cbrts<T>(this object?[]? vals) where T : unmanaged => vals.IsEmptyOrNull() ? default : vals.Select(x => x.Cbrt<T>());
}
