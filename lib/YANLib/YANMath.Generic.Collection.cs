using System.Diagnostics;
using YANLib.Implementation;
using static System.MidpointRounding;

namespace YANLib;

/// <summary>
/// Provides generic extension methods for mathematical operations on collections of objects.
/// </summary>
/// <remarks>
/// This partial class contains methods for performing various mathematical operations on collections of objects,
/// including truncation, rounding, trigonometric functions, logarithms, and more.
/// All methods handle null values and empty collections gracefully and support generic type parameters.
/// </remarks>
public static partial class YANMath
{
    /// <summary>
    /// Returns the integer part of each object in a collection by removing any fractional digits, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects to truncate. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the integer part of each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Truncate(double)"/> to remove the fractional part of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Truncates<T>(this IEnumerable<object?>? input) => input.TruncatesImplement<T>();

    /// <summary>
    /// Returns the integer part of each object in an array by removing any fractional digits, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects to truncate. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the integer part of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to truncate an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Truncate(double)"/> to remove the fractional part of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Truncates<T>(params object?[]? input) => input.TruncatesImplement<T>();

    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects to find the ceiling of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the ceiling of each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Ceiling(double)"/> to find the ceiling of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Ceilings<T>(this IEnumerable<object?>? input) => input.CeilingsImplement<T>();

    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects to find the ceiling of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the ceiling of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the ceiling of an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Ceiling(double)"/> to find the ceiling of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Ceilings<T>(params object?[]? input) => input.CeilingsImplement<T>();

    /// <summary>
    /// Returns the largest integral value that is less than or equal to each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects to find the floor of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the floor of each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Floor(double)"/> to find the floor of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Floors<T>(this IEnumerable<object?>? input) => input.FloorsImplement<T>();

    /// <summary>
    /// Returns the largest integral value that is less than or equal to each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects to find the floor of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the floor of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the floor of an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Floor(double)"/> to find the floor of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Floors<T>(params object?[]? input) => input.FloorsImplement<T>();

    /// <summary>
    /// Rounds each object in a collection to a specified number of fractional digits, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects to round. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="digits">The number of fractional digits in the return values. If <c>null</c>, rounds to the nearest integer.</param>
    /// <param name="mode">The rounding mode to use. Default is <see cref="MidpointRounding.AwayFromZero"/>.</param>
    /// <returns>A collection containing the rounded values, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Round(double, int, MidpointRounding)"/> to round each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Rounds<T>(this IEnumerable<object?>? input, object? digits = null, MidpointRounding mode = AwayFromZero) => input.RoundsImplement<T>(digits, mode);

    /// <summary>
    /// Rounds each object in an array to the nearest integer, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects to round. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the rounded values, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to round an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Round(double, MidpointRounding)"/> to round each number to the nearest integer.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Rounds<T>(params object?[]? input) => input.RoundsImplement<T>();

    /// <summary>
    /// Returns the square root of each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects to find the square root of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the square root of each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Sqrt(double)"/> to calculate the square root of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Sqrts<T>(this IEnumerable<object?>? input) => input.SqrtsImplement<T>();

    /// <summary>
    /// Returns the square root of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects to find the square root of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the square root of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the square root of an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Sqrt(double)"/> to calculate the square root of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Sqrts<T>(params object?[]? input) => input.SqrtsImplement<T>();

    /// <summary>
    /// Returns each object in a collection raised to the specified power, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects to raise to the power. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="power">The power to raise each object to. If <c>null</c>, returns <c>default(T)</c> for each element.</param>
    /// <returns>A collection containing each value in the input collection raised to the specified power, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Pow(double, double)"/> to calculate the power of each number.
    /// Each element and the power are converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Pows<T>(this IEnumerable<object?>? input, object? power) => input.PowsImplement<T>(power);

    /// <summary>
    /// Returns the absolute value of each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects to find the absolute value of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the absolute value of each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Abs(double)"/> to calculate the absolute value of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Abss<T>(this IEnumerable<object?>? input) => input.AbssImplement<T>();

    /// <summary>
    /// Returns the absolute value of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects to find the absolute value of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the absolute value of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the absolute value of an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Abs(double)"/> to calculate the absolute value of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Abss<T>(params object?[]? input) => input.AbssImplement<T>();

    /// <summary>
    /// Returns the sine of each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects representing angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the sine of each angle in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Sin(double)"/> to calculate the sine of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Sins<T>(this IEnumerable<object?>? input) => input.SinsImplement<T>();

    /// <summary>
    /// Returns the sine of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects representing angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the sine of each angle in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the sine of an array of angles without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Sin(double)"/> to calculate the sine of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Sins<T>(params object?[]? input) => input.SinsImplement<T>();

    /// <summary>
    /// Returns the cosine of each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects representing angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the cosine of each angle in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Cos(double)"/> to calculate the cosine of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Coss<T>(this IEnumerable<object?>? input) => input.CossImplement<T>();

    /// <summary>
    /// Returns the cosine of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects representing angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the cosine of each angle in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the cosine of an array of angles without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Cos(double)"/> to calculate the cosine of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Coss<T>(params object?[]? input) => input.CossImplement<T>();

    /// <summary>
    /// Returns the tangent of each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects representing angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the tangent of each angle in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Tan(double)"/> to calculate the tangent of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Tans<T>(this IEnumerable<object?>? input) => input.TansImplement<T>();

    /// <summary>
    /// Returns the tangent of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects representing angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the tangent of each angle in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the tangent of an array of angles without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Tan(double)"/> to calculate the tangent of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Tans<T>(params object?[]? input) => input.TansImplement<T>();

    /// <summary>
    /// Returns the angle whose sine is each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects representing sines, where each value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose sine is each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Asin(double)"/> to calculate the arcsine of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Asins<T>(this IEnumerable<object?>? input) => input.AsinsImplement<T>();

    /// <summary>
    /// Returns the angle whose sine is each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects representing sines, where each value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose sine is each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the arcsine of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Asin(double)"/> to calculate the arcsine of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Asins<T>(params object?[]? input) => input.AsinsImplement<T>();

    /// <summary>
    /// Returns the angle whose cosine is each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects representing cosines, where each value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose cosine is each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Acos(double)"/> to calculate the arccosine of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Acoss<T>(this IEnumerable<object?>? input) => input.AcossImplement<T>();

    /// <summary>
    /// Returns the angle whose cosine is each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects representing cosines, where each value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose cosine is each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the arccosine of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Acos(double)"/> to calculate the arccosine of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Acoss<T>(params object?[]? input) => input.AcossImplement<T>();

    /// <summary>
    /// Returns the angle whose tangent is each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects representing tangents. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose tangent is each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Atan(double)"/> to calculate the arctangent of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Atans<T>(this IEnumerable<object?>? input) => input.AtansImplement<T>();

    /// <summary>
    /// Returns the angle whose tangent is each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects representing tangents. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose tangent is each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the arctangent of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Atan(double)"/> to calculate the arctangent of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Atans<T>(params object?[]? input) => input.AtansImplement<T>();

    /// <summary>
    /// Returns the cube root of each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects to find the cube root of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the cube root of each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Cbrt(double)"/> to calculate the cube root of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Cbrts<T>(this IEnumerable<object?>? input) => input.CbrtsImplement<T>();

    /// <summary>
    /// Returns the cube root of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects to find the cube root of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the cube root of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the cube root of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Cbrt(double)"/> to calculate the cube root of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Cbrts<T>(params object?[]? input) => input.CbrtsImplement<T>();

    /// <summary>
    /// Returns e raised to the power of each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects representing powers to which e is raised. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing e raised to the power of each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Exp(double)"/> to calculate the exponential of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Exps<T>(this IEnumerable<object?>? input) => input.ExpsImplement<T>();

    /// <summary>
    /// Returns e raised to the power of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects representing powers to which e is raised. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing e raised to the power of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to calculate the exponential of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Exp(double)"/> to calculate the exponential of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Exps<T>(params object?[]? input) => input.ExpsImplement<T>();

    /// <summary>
    /// Returns 2 raised to the power of each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects representing powers to which 2 is raised. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing 2 raised to the power of each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Pow(double, double)"/> with a base of 2 to calculate the exponential of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Exp2s<T>(this IEnumerable<object?>? input) => input.Exp2sImplement<T>();

    /// <summary>
    /// Returns 2 raised to the power of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects representing powers to which 2 is raised. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing 2 raised to the power of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to calculate the exponential of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Pow(double, double)"/> with a base of 2 to calculate the exponential of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Exp2s<T>(params object?[]? input) => input.Exp2sImplement<T>();

    /// <summary>
    /// Returns the logarithm of each object in a collection in a specified base, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="baseValue">The base of the logarithm. If <c>null</c>, returns the natural logarithm (base e) for each element.</param>
    /// <returns>A collection containing the logarithm of each value in the input collection in the specified base, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log(double, double)"/> or <see cref="Math.Log(double)"/> to calculate the logarithm of each number.
    /// Each element and the base are converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Logs<T>(this IEnumerable<object?>? input, object? baseValue = null) => input.LogsImplement<T>(baseValue);

    /// <summary>
    /// Returns the natural logarithm (base e) of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the natural logarithm of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the logarithm of an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Log(double)"/> to calculate the natural logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Logs<T>(params object?[]? input) => input.LogsImplement<T>();

    /// <summary>
    /// Returns the base 10 logarithm of each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base 10 logarithm of each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log10(double)"/> to calculate the base 10 logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Log10s<T>(this IEnumerable<object?>? input) => input.Log10sImplement<T>();

    /// <summary>
    /// Returns the base 10 logarithm of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base 10 logarithm of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the base 10 logarithm of an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Log10(double)"/> to calculate the base 10 logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Log10s<T>(params object?[]? input) => input.Log10sImplement<T>();

    /// <summary>
    /// Returns the base 2 logarithm of each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base 2 logarithm of each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log(double, double)"/> with a base of 2 to calculate the base 2 logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Log2s<T>(this IEnumerable<object?>? input) => input.Log2sImplement<T>();

    /// <summary>
    /// Returns the base 2 logarithm of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base 2 logarithm of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the base 2 logarithm of an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Log(double, double)"/> with a base of 2 to calculate the base 2 logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Log2s<T>(params object?[]? input) => input.Log2sImplement<T>();

    /// <summary>
    /// Returns the base-2 integer logarithm of each object in a collection, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The collection of objects whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base-2 integer logarithm of each value in the input collection, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.ILogB(double)"/> to calculate the integer logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? ILogBs<T>(this IEnumerable<object?>? input) => input.ILogBsImplement<T>();

    /// <summary>
    /// Returns the base-2 integer logarithm of each object in an array, converted to type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to convert the results to.</typeparam>
    /// <param name="input">The array of objects whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base-2 integer logarithm of each value in the input array, converted to type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the integer logarithm of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.ILogB(double)"/> to calculate the integer logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? ILogBs<T>(params object?[]? input) => input.ILogBsImplement<T>();
}
