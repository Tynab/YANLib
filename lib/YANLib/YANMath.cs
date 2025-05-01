using System.Diagnostics;
using YANLib.Implementation;
using static System.MidpointRounding;

namespace YANLib;

/// <summary>
/// Provides extension methods for mathematical operations.
/// </summary>
/// <remarks>
/// This class contains methods for performing various mathematical operations on values,
/// including basic arithmetic, trigonometric functions, logarithms, and more.
/// All methods handle null values gracefully and support generic type parameters.
/// </remarks>
public static partial class YANMath
{
    /// <summary>
    /// Returns the minimum value in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to find the minimum value in. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The minimum value in the collection, or <c>default(T)</c> if the collection is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method ignores <c>null</c> elements in the collection when determining the minimum value.
    /// The type <typeparamref name="T"/> must support comparison operations.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Min<T>(this IEnumerable<T?>? input) => input.MinImplement();

    /// <summary>
    /// Returns the minimum value in an array of values.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to find the minimum value in. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The minimum value in the array, or <c>default(T)</c> if the array is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the minimum value in an array without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method ignores <c>null</c> elements in the array when determining the minimum value.
    /// The type <typeparamref name="T"/> must support comparison operations.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Min<T>(params T?[]? input) => input.MinImplement();

    /// <summary>
    /// Returns the minimum value in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to before finding the minimum.</typeparam>
    /// <param name="input">The non-generic collection to find the minimum value in. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The minimum value in the collection, or <c>default(T)</c> if the collection is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the minimum value.
    /// This method ignores <c>null</c> elements in the collection when determining the minimum value.
    /// The type <typeparamref name="T"/> must support comparison operations.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Min<T>(this System.Collections.IEnumerable? input) => input.MinImplement<T>();

    /// <summary>
    /// Returns the maximum value in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="input">The collection to find the maximum value in. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The maximum value in the collection, or <c>default(T)</c> if the collection is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method ignores <c>null</c> elements in the collection when determining the maximum value.
    /// The type <typeparamref name="T"/> must support comparison operations.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Max<T>(this IEnumerable<T?>? input) => input.MaxImplement();

    /// <summary>
    /// Returns the maximum value in an array of values.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="input">The array to find the maximum value in. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The maximum value in the array, or <c>default(T)</c> if the array is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the maximum value in an array without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method ignores <c>null</c> elements in the array when determining the maximum value.
    /// The type <typeparamref name="T"/> must support comparison operations.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Max<T>(params T?[]? input) => input.MaxImplement();

    /// <summary>
    /// Returns the maximum value in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements to before finding the maximum.</typeparam>
    /// <param name="input">The non-generic collection to find the maximum value in. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The maximum value in the collection, or <c>default(T)</c> if the collection is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the maximum value.
    /// This method ignores <c>null</c> elements in the collection when determining the maximum value.
    /// The type <typeparamref name="T"/> must support comparison operations.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Max<T>(this System.Collections.IEnumerable? input) => input.MaxImplement<T>();

    /// <summary>
    /// Returns the average of all values in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return value.</typeparam>
    /// <param name="input">The collection to calculate the average of. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The average of all values in the collection, or <c>default(T)</c> if the collection is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method ignores <c>null</c> elements in the collection when calculating the average.
    /// The elements are converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Average<T>(this IEnumerable<T?>? input) => input.AverageImplement();

    /// <summary>
    /// Returns the average of all values in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return value.</typeparam>
    /// <param name="input">The array to calculate the average of. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The average of all values in the array, or <c>default(T)</c> if the array is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to calculate the average of an array without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method ignores <c>null</c> elements in the array when calculating the average.
    /// The elements are converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Average<T>(params T?[]? input) => input.AverageImplement();

    /// <summary>
    /// Returns the average of all values in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the result to.</typeparam>
    /// <param name="input">The non-generic collection to calculate the average of. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The average of all values in the collection, or <c>default(T)</c> if the collection is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before calculating the average.
    /// This method ignores <c>null</c> elements in the collection when calculating the average.
    /// The elements are converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Average<T>(this System.Collections.IEnumerable? input) => input.AverageImplement<T>();

    /// <summary>
    /// Returns the sum of all values in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return value.</typeparam>
    /// <param name="input">The collection to calculate the sum of. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The sum of all values in the collection, or <c>default(T)</c> if the collection is <c>null</c> or empty.</returns>
    /// <remarks>
    /// The elements are converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Sum<T>(this IEnumerable<T?>? input) => input.SumImplement();

    /// <summary>
    /// Returns the sum of all values in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return value.</typeparam>
    /// <param name="input">The array to calculate the sum of. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The sum of all values in the array, or <c>default(T)</c> if the array is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to calculate the sum of an array without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// The elements are converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Sum<T>(params T?[]? input) => input.SumImplement();

    /// <summary>
    /// Returns the sum of all values in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the result to.</typeparam>
    /// <param name="input">The non-generic collection to calculate the sum of. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The sum of all values in the collection, or <c>default(T)</c> if the collection is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before calculating the sum.
    /// The elements are converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Sum<T>(this System.Collections.IEnumerable? input) => input.SumImplement<T>();

    /// <summary>
    /// Returns the integer part of a number by removing any fractional digits.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The value to truncate. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The integer part of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Truncate(double)"/> to remove the fractional part of the number.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Truncate<T>(this T? input) => input.TruncateImplement();

    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to the specified number.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The value to find the ceiling of. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The ceiling of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Ceiling(double)"/> to find the ceiling of the number.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Ceiling<T>(this T? input) => input.CeilingImplement();

    /// <summary>
    /// Returns the largest integral value that is less than or equal to the specified number.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The value to find the floor of. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The floor of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Floor(double)"/> to find the floor of the number.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Floor<T>(this T? input) => input.FloorImplement();

    /// <summary>
    /// Rounds a value to a specified number of fractional digits.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The value to round. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="digits">The number of fractional digits in the return value. If <c>null</c>, rounds to the nearest integer.</param>
    /// <param name="mode">The rounding mode to use. Default is <see cref="MidpointRounding.AwayFromZero"/>.</param>
    /// <returns>The rounded value, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Round(double, int, MidpointRounding)"/> to round the number.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Round<T>(this T? input, object? digits = null, MidpointRounding mode = AwayFromZero) => input.RoundImplement(digits, mode);

    /// <summary>
    /// Returns the square root of a specified number.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The number to find the square root of. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The square root of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Sqrt(double)"/> to calculate the square root.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Sqrt<T>(this T? input) => input.SqrtImplement();

    /// <summary>
    /// Returns a specified number raised to the specified power.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The number to raise to the power. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <param name="power">The power to raise the number to. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The result of raising <paramref name="input"/> to the <paramref name="power"/>, or <c>default(T)</c> if either <paramref name="input"/> or <paramref name="power"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Pow(double, double)"/> to calculate the power.
    /// Both the input and power are converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Pow<T>(this T? input, object? power) => input.PowImplement(power);

    /// <summary>
    /// Returns the absolute value of a specified number.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The number to find the absolute value of. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The absolute value of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Abs(double)"/> to calculate the absolute value.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Abs<T>(this T? input) => input.AbsImplement();

    /// <summary>
    /// Returns the sine of the specified angle.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">An angle, measured in radians. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The sine of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Sin(double)"/> to calculate the sine.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Sin<T>(this T? input) => input.SinImplement();

    /// <summary>
    /// Returns the cosine of the specified angle.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">An angle, measured in radians. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The cosine of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Cos(double)"/> to calculate the cosine.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Cos<T>(this T? input) => input.CosImplement();

    /// <summary>
    /// Returns the tangent of the specified angle.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">An angle, measured in radians. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The tangent of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Tan(double)"/> to calculate the tangent.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Tan<T>(this T? input) => input.TanImplement();

    /// <summary>
    /// Returns the angle whose sine is the specified number.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">A number representing a sine, where <paramref name="input"/> must be greater than or equal to -1, but less than or equal to 1. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>An angle, measured in radians, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Asin(double)"/> to calculate the arcsine.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Asin<T>(this T? input) => input.AsinImplement();

    /// <summary>
    /// Returns the angle whose cosine is the specified number.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">A number representing a cosine, where <paramref name="input"/> must be greater than or equal to -1, but less than or equal to 1. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>An angle, measured in radians, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Acos(double)"/> to calculate the arccosine.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Acos<T>(this T? input) => input.AcosImplement();

    /// <summary>
    /// Returns the angle whose tangent is the specified number.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">A number representing a tangent. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>An angle, measured in radians, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Atan(double)"/> to calculate the arctangent.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Atan<T>(this T? input) => input.AtanImplement();

    /// <summary>
    /// Returns the cube root of a specified number.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The number whose cube root is to be found. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The cube root of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Cbrt(double)"/> to calculate the cube root.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Cbrt<T>(this T? input) => input.CbrtImplement();

    /// <summary>
    /// Returns e raised to the specified power.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The power to which e is raised. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The number e raised to the power <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Exp(double)"/> to calculate the exponential.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Exp<T>(this T? input) => input.ExpImplement();

    /// <summary>
    /// Returns 2 raised to the specified power.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The power to which 2 is raised. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The number 2 raised to the power <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Pow(double, double)"/> with a base of 2 to calculate the exponential.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Exp2<T>(this T? input) => input.Exp2Implement();

    /// <summary>
    /// Returns the logarithm of a specified number in a specified base.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The number whose logarithm is to be found. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="baseValue">The base of the logarithm. If <c>null</c>, returns the natural logarithm (base e).</param>
    /// <returns>The logarithm of <paramref name="input"/> in the specified base, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log(double, double)"/> or <see cref="Math.Log(double)"/> to calculate the logarithm.
    /// The input and base are converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Log<T>(this T? input, object? baseValue = null) => input.LogImplement(baseValue);

    /// <summary>
    /// Returns the base 10 logarithm of a specified number.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The number whose logarithm is to be found. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The base 10 logarithm of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log10(double)"/> to calculate the logarithm.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Log10<T>(this T? input) => input.Log10Implement();

    /// <summary>
    /// Returns the base 2 logarithm of a specified number.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The number whose logarithm is to be found. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The base 2 logarithm of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log(double, double)"/> with a base of 2 to calculate the logarithm.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Log2<T>(this T? input) => input.Log2Implement();

    /// <summary>
    /// Returns the base-2 integer logarithm of a specified number.
    /// </summary>
    /// <typeparam name="T">The type of the input and return value.</typeparam>
    /// <param name="input">The number whose logarithm is to be found. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The base-2 integer logarithm of <paramref name="input"/>, or <c>null</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.ILogB(double)"/> to calculate the integer logarithm.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted back to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? ILogB<T>(this T? input) => input.ILogBImplement();
}
