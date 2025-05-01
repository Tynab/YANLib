using System.Diagnostics;
using YANLib.Implementation;
using static System.MidpointRounding;

namespace YANLib;

/// <summary>
/// Provides generic extension methods for mathematical operations on objects.
/// </summary>
/// <remarks>
/// This partial class contains methods for performing various mathematical operations on objects,
/// including basic arithmetic, trigonometric functions, logarithms, and more.
/// All methods handle null values gracefully and support generic type parameters.
/// </remarks>
public static partial class YANMath
{
    /// <summary>
    /// Returns the minimum value in a collection of objects, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The collection of objects to find the minimum value in. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The minimum value in the collection, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if the collection is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method ignores <c>null</c> elements in the collection when determining the minimum value.
    /// Each element is converted to type <typeparamref name="T"/> before comparison.
    /// The type <typeparamref name="T"/> must support comparison operations.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Min<T>(this IEnumerable<object?>? input) => input.MinImplement<T>();

    /// <summary>
    /// Returns the minimum value in an array of objects, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The array of objects to find the minimum value in. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The minimum value in the array, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if the array is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the minimum value in an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method ignores <c>null</c> elements in the array when determining the minimum value.
    /// Each element is converted to type <typeparamref name="T"/> before comparison.
    /// The type <typeparamref name="T"/> must support comparison operations.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Min<T>(params object?[]? input) => input.MinImplement<T>();

    /// <summary>
    /// Returns the maximum value in a collection of objects, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The collection of objects to find the maximum value in. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The maximum value in the collection, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if the collection is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method ignores <c>null</c> elements in the collection when determining the maximum value.
    /// Each element is converted to type <typeparamref name="T"/> before comparison.
    /// The type <typeparamref name="T"/> must support comparison operations.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Max<T>(this IEnumerable<object?>? input) => input.MaxImplement<T>();

    /// <summary>
    /// Returns the maximum value in an array of objects, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The array of objects to find the maximum value in. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The maximum value in the array, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if the array is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the maximum value in an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method ignores <c>null</c> elements in the array when determining the maximum value.
    /// Each element is converted to type <typeparamref name="T"/> before comparison.
    /// The type <typeparamref name="T"/> must support comparison operations.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Max<T>(params object?[]? input) => input.MaxImplement<T>();

    /// <summary>
    /// Returns the average of all values in a collection of objects, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The collection of objects to calculate the average of. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The average of all values in the collection, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if the collection is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method ignores <c>null</c> elements in the collection when calculating the average.
    /// Each element is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Average<T>(this IEnumerable<object?>? input) => input.AverageImplement<T>();

    /// <summary>
    /// Returns the average of all values in an array of objects, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The array of objects to calculate the average of. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The average of all values in the array, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if the array is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to calculate the average of an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method ignores <c>null</c> elements in the array when calculating the average.
    /// Each element is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Average<T>(params object?[]? input) => input.AverageImplement<T>();

    /// <summary>
    /// Returns the sum of all values in a collection of objects, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The collection of objects to calculate the sum of. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The sum of all values in the collection, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if the collection is <c>null</c> or empty.</returns>
    /// <remarks>
    /// Each element is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Sum<T>(this IEnumerable<object?>? input) => input.SumImplement<T>();

    /// <summary>
    /// Returns the sum of all values in an array of objects, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The array of objects to calculate the sum of. If <c>null</c> or empty, returns <c>default(T)</c>.</param>
    /// <returns>The sum of all values in the array, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if the array is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to calculate the sum of an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// Each element is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Sum<T>(params object?[]? input) => input.SumImplement<T>();

    /// <summary>
    /// Returns the integer part of an object by removing any fractional digits, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object to truncate. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The integer part of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Truncate(double)"/> to remove the fractional part of the number.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Truncate<T>(this object? input) => input.TruncateImplement<T>();

    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to the specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object to find the ceiling of. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The ceiling of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Ceiling(double)"/> to find the ceiling of the number.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Ceiling<T>(this object? input) => input.CeilingImplement<T>();

    /// <summary>
    /// Returns the largest integral value that is less than or equal to the specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object to find the floor of. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The floor of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Floor(double)"/> to find the floor of the number.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Floor<T>(this object? input) => input.FloorImplement<T>();

    /// <summary>
    /// Rounds an object to a specified number of fractional digits, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object to round. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <param name="digits">The number of fractional digits in the return value. If <c>null</c>, rounds to the nearest integer.</param>
    /// <param name="mode">The rounding mode to use. Default is <see cref="MidpointRounding.AwayFromZero"/>.</param>
    /// <returns>The rounded value, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Round(double, int, MidpointRounding)"/> to round the number.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Round<T>(this object? input, object? digits = null, MidpointRounding mode = AwayFromZero) => input.RoundImplement<T>(digits, mode);

    /// <summary>
    /// Returns the square root of a specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object to find the square root of. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The square root of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Sqrt(double)"/> to calculate the square root.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Sqrt<T>(this object? input) => input.SqrtImplement<T>();

    /// <summary>
    /// Returns a specified object raised to the specified power, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object to raise to the power. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <param name="power">The power to raise the object to. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The result of raising <paramref name="input"/> to the <paramref name="power"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if either <paramref name="input"/> or <paramref name="power"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Pow(double, double)"/> to calculate the power.
    /// Both the input and power are converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Pow<T>(this object? input, object? power) => input.PowImplement<T>(power);

    /// <summary>
    /// Returns the absolute value of a specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object to find the absolute value of. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The absolute value of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Abs(double)"/> to calculate the absolute value.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Abs<T>(this object? input) => input.AbsImplement<T>();

    /// <summary>
    /// Returns the sine of the specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">An object representing an angle, measured in radians. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The sine of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Sin(double)"/> to calculate the sine.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Sin<T>(this object? input) => input.SinImplement<T>();

    /// <summary>
    /// Returns the cosine of the specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">An object representing an angle, measured in radians. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The cosine of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Cos(double)"/> to calculate the cosine.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Cos<T>(this object? input) => input.CosImplement<T>();

    /// <summary>
    /// Returns the tangent of the specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">An object representing an angle, measured in radians. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The tangent of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Tan(double)"/> to calculate the tangent.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Tan<T>(this object? input) => input.TanImplement<T>();

    /// <summary>
    /// Returns the angle whose sine is the specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">An object representing a sine, where the value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>An angle, measured in radians, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Asin(double)"/> to calculate the arcsine.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Asin<T>(this object? input) => input.AsinImplement<T>();

    /// <summary>
    /// Returns the angle whose cosine is the specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">An object representing a cosine, where the value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>An angle, measured in radians, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Acos(double)"/> to calculate the arccosine.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Acos<T>(this object? input) => input.AcosImplement<T>();

    /// <summary>
    /// Returns the angle whose tangent is the specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">An object representing a tangent. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>An angle, measured in radians, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Atan(double)"/> to calculate the arctangent.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Atan<T>(this object? input) => input.AtanImplement<T>();

    /// <summary>
    /// Returns the cube root of a specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object whose cube root is to be found. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The cube root of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Cbrt(double)"/> to calculate the cube root.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Cbrt<T>(this object? input) => input.CbrtImplement<T>();

    /// <summary>
    /// Returns e raised to the power of the specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object representing the power to which e is raised. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The number e raised to the power <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Exp(double)"/> to calculate the exponential.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Exp<T>(this object? input) => input.ExpImplement<T>();

    /// <summary>
    /// Returns 2 raised to the power of the specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object representing the power to which 2 is raised. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The number 2 raised to the power <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Pow(double, double)"/> with a base of 2 to calculate the exponential.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Exp2<T>(this object? input) => input.Exp2Implement<T>();

    /// <summary>
    /// Returns the logarithm of a specified object in a specified base, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object whose logarithm is to be found. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <param name="baseValue">The base of the logarithm. If <c>null</c>, returns the natural logarithm (base e).</param>
    /// <returns>The logarithm of <paramref name="input"/> in the specified base, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log(double, double)"/> or <see cref="Math.Log(double)"/> to calculate the logarithm.
    /// The input and base are converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Log<T>(this object? input, object? baseValue = null) => input.LogImplement<T>(baseValue);

    /// <summary>
    /// Returns the base 10 logarithm of a specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object whose logarithm is to be found. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The base 10 logarithm of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log10(double)"/> to calculate the logarithm.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Log10<T>(this object? input) => input.Log10Implement<T>();

    /// <summary>
    /// Returns the base 2 logarithm of a specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object whose logarithm is to be found. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The base 2 logarithm of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log(double, double)"/> with a base of 2 to calculate the logarithm.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Log2<T>(this object? input) => input.Log2Implement<T>();

    /// <summary>
    /// Returns the base-2 integer logarithm of a specified object, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the result to.</typeparam>
    /// <param name="input">The object whose logarithm is to be found. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The base-2 integer logarithm of <paramref name="input"/>, converted to type <typeparamref name="T"/>, or <c>default(T)</c> if <paramref name="input"/> is <c>null</c>.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.ILogB(double)"/> to calculate the integer logarithm.
    /// The input is converted to <c>double</c> for the calculation, and the result is converted to type <typeparamref name="T"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? ILogB<T>(this object? input) => input.ILogBImplement<T>();
}
