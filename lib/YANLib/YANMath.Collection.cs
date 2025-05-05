using System.Diagnostics;
using YANLib.Implementation;
using static System.MidpointRounding;

namespace YANLib;

/// <summary>
/// Provides extension methods for mathematical operations on collections.
/// </summary>
/// <remarks>
/// This partial class contains methods for performing various mathematical operations on collections of values,
/// including truncation, rounding, trigonometric functions, logarithms, and more.
/// All methods handle null values and empty collections gracefully and support generic type parameters.
/// </remarks>
public static partial class YANMath
{
    /// <summary>
    /// Returns the integer part of each number in a collection by removing any fractional digits.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of values to truncate. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the integer part of each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Truncate(double)"/> to remove the fractional part of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Truncates<T>(this IEnumerable<T?>? input) => input.TruncatesImplement();

    /// <summary>
    /// Returns the integer part of each number in an array by removing any fractional digits.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of values to truncate. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the integer part of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to truncate an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Truncate(double)"/> to remove the fractional part of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Truncates<T>(params T?[]? input) => input.TruncatesImplement();

    /// <summary>
    /// Returns the integer part of each number in a non-generic collection by removing any fractional digits.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of values to truncate. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the integer part of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before truncating each value.
    /// This method uses <see cref="Math.Truncate(double)"/> to remove the fractional part of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Truncates<T>(this System.Collections.IEnumerable? input) => input.TruncatesImplement<T>();

    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of values to find the ceiling of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the ceiling of each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Ceiling(double)"/> to find the ceiling of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Ceilings<T>(this IEnumerable<T?>? input) => input.CeilingsImplement();

    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of values to find the ceiling of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the ceiling of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the ceiling of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Ceiling(double)"/> to find the ceiling of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    public static IEnumerable<T?>? Ceilings<T>(params T?[]? input) => input.CeilingsImplement();

    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of values to find the ceiling of. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the ceiling of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the ceiling of each value.
    /// This method uses <see cref="Math.Ceiling(double)"/> to find the ceiling of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Ceilings<T>(this System.Collections.IEnumerable? input) => input.CeilingsImplement<T>();

    /// <summary>
    /// Returns the largest integral value that is less than or equal to each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of values to find the floor of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the floor of each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Floor(double)"/> to find the floor of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Floors<T>(this IEnumerable<T?>? input) => input.FloorsImplement();

    /// <summary>
    /// Returns the largest integral value that is less than or equal to each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of values to find the floor of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the floor of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the floor of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Floor(double)"/> to find the floor of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Floors<T>(params T?[]? input) => input.FloorsImplement();

    /// <summary>
    /// Returns the largest integral value that is less than or equal to each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of values to find the floor of. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the floor of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the floor of each value.
    /// This method uses <see cref="Math.Floor(double)"/> to find the floor of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Floors<T>(this System.Collections.IEnumerable? input) => input.FloorsImplement<T>();

    /// <summary>
    /// Rounds each value in a collection to a specified number of fractional digits.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of values to round. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="digits">The number of fractional digits in the return values. If <c>null</c>, rounds to the nearest integer.</param>
    /// <param name="mode">The rounding mode to use. Default is <see cref="MidpointRounding.AwayFromZero"/>.</param>
    /// <returns>A collection containing the rounded values, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Round(double, int, MidpointRounding)"/> to round each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Rounds<T>(this IEnumerable<T?>? input, object? digits = null, MidpointRounding mode = AwayFromZero) => input.RoundsImplement(digits, mode);

    /// <summary>
    /// Rounds each value in an array to the nearest integer.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of values to round. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the rounded values, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to round an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Round(double, MidpointRounding)"/> to round each number to the nearest integer.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Rounds<T>(params T?[]? input) => input.RoundsImplement();

    /// <summary>
    /// Rounds each value in a non-generic collection to a specified number of fractional digits.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of values to round. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="digits">The number of fractional digits in the return values. If <c>null</c>, rounds to the nearest integer.</param>
    /// <param name="mode">The rounding mode to use. Default is <see cref="MidpointRounding.AwayFromZero"/>.</param>
    /// <returns>A collection containing the rounded values, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before rounding each value.
    /// This method uses <see cref="Math.Round(double, int, MidpointRounding)"/> to round each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Rounds<T>(this System.Collections.IEnumerable? input, object? digits = null, MidpointRounding mode = AwayFromZero) => input.RoundsImplement<T>(digits, mode);

    /// <summary>
    /// Returns the square root of each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of numbers to find the square root of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the square root of each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Sqrt(double)"/> to calculate the square root of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Sqrts<T>(this IEnumerable<T?>? input) => input.SqrtsImplement();

    /// <summary>
    /// Returns the square root of each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of numbers to find the square root of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the square root of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the square root of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Sqrt(double)"/> to calculate the square root of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Sqrts<T>(params T?[]? input) => input.SqrtsImplement();

    /// <summary>
    /// Returns the square root of each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of numbers to find the square root of. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the square root of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the square root of each value.
    /// This method uses <see cref="Math.Sqrt(double)"/> to calculate the square root of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Sqrts<T>(this System.Collections.IEnumerable? input) => input.SqrtsImplement<T>();

    /// <summary>
    /// Returns each number in a collection raised to the specified power.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of numbers to raise to the power. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="power">The power to raise each number to. If <c>null</c>, returns <c>default(T)</c> for each element.</param>
    /// <returns>A collection containing each value in the input collection raised to the specified power, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Pow(double, double)"/> to calculate the power of each number.
    /// Each element and the power are converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Pows<T>(this IEnumerable<T?>? input, object? power) => input.PowsImplement(power);

    /// <summary>
    /// Returns each number in a non-generic collection raised to the specified power.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of numbers to raise to the power. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="power">The power to raise each number to. If <c>null</c>, returns <c>default(T)</c> for each element.</param>
    /// <returns>A collection containing each value in the input collection raised to the specified power, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before raising each value to the power.
    /// This method uses <see cref="Math.Pow(double, double)"/> to calculate the power of each number.
    /// Each element and the power are converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Pows<T>(this System.Collections.IEnumerable? input, object? power) => input.PowsImplement<T>(power);

    /// <summary>
    /// Returns the absolute value of each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of numbers to find the absolute value of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the absolute value of each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Abs(double)"/> to calculate the absolute value of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Abss<T>(this IEnumerable<T?>? input) => input.AbssImplement();

    /// <summary>
    /// Returns the absolute value of each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of numbers to find the absolute value of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the absolute value of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the absolute value of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Abs(double)"/> to calculate the absolute value of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Abss<T>(params T?[]? input) => input.AbssImplement();

    /// <summary>
    /// Returns the absolute value of each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of numbers to find the absolute value of. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the absolute value of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the absolute value of each value.
    /// This method uses <see cref="Math.Abs(double)"/> to calculate the absolute value of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Abss<T>(this System.Collections.IEnumerable? input) => input.AbssImplement<T>();

    /// <summary>
    /// Returns the sine of each angle in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the sine of each angle in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Sin(double)"/> to calculate the sine of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Sins<T>(this IEnumerable<T?>? input) => input.SinsImplement();

    /// <summary>
    /// Returns the sine of each angle in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the sine of each angle in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the sine of an array of angles without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Sin(double)"/> to calculate the sine of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Sins<T>(params T?[]? input) => input.SinsImplement();

    /// <summary>
    /// Returns the sine of each angle in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of angles, measured in radians. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the sine of each angle in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the sine of each angle.
    /// This method uses <see cref="Math.Sin(double)"/> to calculate the sine of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Sins<T>(this System.Collections.IEnumerable? input) => input.SinsImplement<T>();

    /// <summary>
    /// Returns the cosine of each angle in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the cosine of each angle in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Cos(double)"/> to calculate the cosine of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Coss<T>(this IEnumerable<T?>? input) => input.CossImplement();

    /// <summary>
    /// Returns the cosine of each angle in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the cosine of each angle in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the cosine of an array of angles without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Cos(double)"/> to calculate the cosine of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Coss<T>(params T?[]? input) => input.CossImplement();

    /// <summary>
    /// Returns the cosine of each angle in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of angles, measured in radians. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the cosine of each angle in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the cosine of each angle.
    /// This method uses <see cref="Math.Cos(double)"/> to calculate the cosine of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Coss<T>(this System.Collections.IEnumerable? input) => input.CossImplement<T>();

    /// <summary>
    /// Returns the tangent of each angle in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the tangent of each angle in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Tan(double)"/> to calculate the tangent of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Tans<T>(this IEnumerable<T?>? input) => input.TansImplement();

    /// <summary>
    /// Returns the tangent of each angle in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of angles, measured in radians. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the tangent of each angle in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the tangent of an array of angles without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Tan(double)"/> to calculate the tangent of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Tans<T>(params T?[]? input) => input.TansImplement();

    /// <summary>
    /// Returns the tangent of each angle in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of angles, measured in radians. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the tangent of each angle in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the tangent of each angle.
    /// This method uses <see cref="Math.Tan(double)"/> to calculate the tangent of each angle.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Tans<T>(this System.Collections.IEnumerable? input) => input.TansImplement<T>();

    /// <summary>
    /// Returns the angle whose sine is each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of numbers representing sines, where each value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose sine is each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Asin(double)"/> to calculate the arcsine of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Asins<T>(this IEnumerable<T?>? input) => input.AsinsImplement();

    /// <summary>
    /// Returns the angle whose sine is each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of numbers representing sines, where each value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose sine is each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the arcsine of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Asin(double)"/> to calculate the arcsine of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Asins<T>(params T?[]? input) => input.AsinsImplement();

    /// <summary>
    /// Returns the angle whose sine is each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of numbers representing sines, where each value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose sine is each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the arcsine of each value.
    /// This method uses <see cref="Math.Asin(double)"/> to calculate the arcsine of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Asins<T>(this System.Collections.IEnumerable? input) => input.AsinsImplement<T>();

    /// <summary>
    /// Returns the angle whose cosine is each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of numbers representing cosines, where each value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose cosine is each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Acos(double)"/> to calculate the arccosine of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Acoss<T>(this IEnumerable<T?>? input) => input.AcossImplement();

    /// <summary>
    /// Returns the angle whose cosine is each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of numbers representing cosines, where each value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose cosine is each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the arccosine of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Acos(double)"/> to calculate the arccosine of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Acoss<T>(params T?[]? input) => input.AcossImplement();

    /// <summary>
    /// Returns the angle whose cosine is each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of numbers representing cosines, where each value must be greater than or equal to -1, but less than or equal to 1. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose cosine is each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the arccosine of each value.
    /// This method uses <see cref="Math.Acos(double)"/> to calculate the arccosine of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Acoss<T>(this System.Collections.IEnumerable? input) => input.AcossImplement<T>();

    /// <summary>
    /// Returns the angle whose tangent is each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of numbers representing tangents. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose tangent is each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Atan(double)"/> to calculate the arctangent of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Atans<T>(this IEnumerable<T?>? input) => input.AtansImplement();

    /// <summary>
    /// Returns the angle whose tangent is each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of numbers representing tangents. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose tangent is each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the arctangent of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Atan(double)"/> to calculate the arctangent of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Atans<T>(params T?[]? input) => input.AtansImplement();

    /// <summary>
    /// Returns the angle whose tangent is each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of numbers representing tangents. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the angle (in radians) whose tangent is each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the arctangent of each value.
    /// This method uses <see cref="Math.Atan(double)"/> to calculate the arctangent of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Atans<T>(this System.Collections.IEnumerable? input) => input.AtansImplement<T>();

    /// <summary>
    /// Returns the cube root of each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of numbers to find the cube root of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the cube root of each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Cbrt(double)"/> to calculate the cube root of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Cbrts<T>(this IEnumerable<T?>? input) => input.CbrtsImplement();

    /// <summary>
    /// Returns the cube root of each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of numbers to find the cube root of. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the cube root of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the cube root of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Cbrt(double)"/> to calculate the cube root of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Cbrts<T>(params T?[]? input) => input.CbrtsImplement();

    /// <summary>
    /// Returns the cube root of each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of numbers to find the cube root of. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the cube root of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the cube root of each value.
    /// This method uses <see cref="Math.Cbrt(double)"/> to calculate the cube root of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Cbrts<T>(this System.Collections.IEnumerable? input) => input.CbrtsImplement<T>();

    /// <summary>
    /// Returns e raised to the power of each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of powers to which e is raised. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing e raised to the power of each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Exp(double)"/> to calculate the exponential of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Exps<T>(this IEnumerable<T?>? input) => input.ExpsImplement();

    /// <summary>
    /// Returns e raised to the power of each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of powers to which e is raised. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing e raised to the power of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to calculate the exponential of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Exp(double)"/> to calculate the exponential of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Exps<T>(params T?[]? input) => input.ExpsImplement();

    /// <summary>
    /// Returns e raised to the power of each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of powers to which e is raised. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing e raised to the power of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before calculating the exponential of each value.
    /// This method uses <see cref="Math.Exp(double)"/> to calculate the exponential of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Exps<T>(this System.Collections.IEnumerable? input) => input.ExpsImplement<T>();

    /// <summary>
    /// Returns 2 raised to the power of each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of powers to which 2 is raised. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing 2 raised to the power of each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Pow(double, double)"/> with a base of 2 to calculate the exponential of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Exp2s<T>(this IEnumerable<T?>? input) => input.Exp2sImplement();

    /// <summary>
    /// Returns 2 raised to the power of each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of powers to which 2 is raised. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing 2 raised to the power of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to calculate the exponential of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Pow(double, double)"/> with a base of 2 to calculate the exponential of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Exp2s<T>(params T?[]? input) => input.Exp2sImplement();

    /// <summary>
    /// Returns 2 raised to the power of each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of powers to which 2 is raised. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing 2 raised to the power of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before calculating the exponential of each value.
    /// This method uses <see cref="Math.Pow(double, double)"/> with a base of 2 to calculate the exponential of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Exp2s<T>(this System.Collections.IEnumerable? input) => input.Exp2sImplement<T>();

    /// <summary>
    /// Returns the logarithm of each number in a collection in a specified base.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of numbers whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="baseValue">The base of the logarithm. If <c>null</c>, returns the natural logarithm (base e) for each element.</param>
    /// <returns>A collection containing the logarithm of each value in the input collection in the specified base, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log(double, double)"/> or <see cref="Math.Log(double)"/> to calculate the logarithm of each number.
    /// Each element and the base are converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Logs<T>(this IEnumerable<T?>? input, object? baseValue = null) => input.LogsImplement(baseValue);

    /// <summary>
    /// Returns the natural logarithm (base e) of each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of numbers whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the natural logarithm of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the logarithm of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Log(double)"/> to calculate the natural logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Logs<T>(params T?[]? input) => input.LogsImplement();

    /// <summary>
    /// Returns the natural logarithm (base e) of each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of numbers whose logarithm is to be found. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the natural logarithm of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the logarithm of each value.
    /// This method uses <see cref="Math.Log(double)"/> to calculate the natural logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Logs<T>(this System.Collections.IEnumerable? input) => input.LogsImplement<T>();

    /// <summary>
    /// Returns the base 10 logarithm of each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of numbers whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base 10 logarithm of each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log10(double)"/> to calculate the base 10 logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Log10s<T>(this IEnumerable<T?>? input) => input.Log10sImplement();

    /// <summary>
    /// Returns the base 10 logarithm of each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of numbers whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base 10 logarithm of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the base 10 logarithm of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Log10(double)"/> to calculate the base 10 logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Log10s<T>(params T?[]? input) => input.Log10sImplement();

    /// <summary>
    /// Returns the base 10 logarithm of each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of numbers whose logarithm is to be found. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the base 10 logarithm of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the base 10 logarithm of each value.
    /// This method uses <see cref="Math.Log10(double)"/> to calculate the base 10 logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Log10s<T>(this System.Collections.IEnumerable? input) => input.Log10sImplement<T>();

    /// <summary>
    /// Returns the base 2 logarithm of each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of numbers whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base 2 logarithm of each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.Log(double, double)"/> with a base of 2 to calculate the base 2 logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Log2s<T>(this IEnumerable<T?>? input) => input.Log2sImplement();

    /// <summary>
    /// Returns the base 2 logarithm of each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of numbers whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base 2 logarithm of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the base 2 logarithm of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.Log(double, double)"/> with a base of 2 to calculate the base 2 logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Log2s<T>(params T?[]? input) => input.Log2sImplement();

    /// <summary>
    /// Returns the base 2 logarithm of each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of numbers whose logarithm is to be found. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the base 2 logarithm of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the base 2 logarithm of each value.
    /// This method uses <see cref="Math.Log(double, double)"/> with a base of 2 to calculate the base 2 logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Log2s<T>(this System.Collections.IEnumerable? input) => input.Log2sImplement<T>();

    /// <summary>
    /// Returns the base-2 integer logarithm of each number in a collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection and the return values.</typeparam>
    /// <param name="input">The collection of numbers whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base-2 integer logarithm of each value in the input collection, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method uses <see cref="Math.ILogB(double)"/> to calculate the integer logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? ILogBs<T>(this IEnumerable<T?>? input) => input.ILogBsImplement();

    /// <summary>
    /// Returns the base-2 integer logarithm of each number in an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array and the return values.</typeparam>
    /// <param name="input">The array of numbers whose logarithm is to be found. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection containing the base-2 integer logarithm of each value in the input array, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to find the integer logarithm of an array of values without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses <see cref="Math.ILogB(double)"/> to calculate the integer logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large arrays (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? ILogBs<T>(params T?[]? input) => input.ILogBsImplement();

    /// <summary>
    /// Returns the base-2 integer logarithm of each number in a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The type to convert the elements and the results to.</typeparam>
    /// <param name="input">The non-generic collection of numbers whose logarithm is to be found. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection containing the base-2 integer logarithm of each value in the input collection, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before finding the integer logarithm of each value.
    /// This method uses <see cref="Math.ILogB(double)"/> to calculate the integer logarithm of each number.
    /// Each element is converted to <c>double</c> for the calculation, and the results are converted back to type <typeparamref name="T"/>.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? ILogBs<T>(this System.Collections.IEnumerable? input) => input.ILogBsImplement<T>();
}
