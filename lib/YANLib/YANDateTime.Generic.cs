using System.Diagnostics;
using YANLib.Implementation;
using static YANLib.Implementation.YANDateTime;

namespace YANLib;

/// <summary>
/// Provides generic extension methods for working with DateTime objects.
/// </summary>
/// <remarks>
/// This partial class contains generic methods for DateTime operations that allow
/// for flexible return types, enabling conversion to various numeric or custom types.
/// </remarks>
public static partial class YANDateTime
{
    /// <summary>
    /// Gets the week number of the year for the specified object and returns it as the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the week number to.</typeparam>
    /// <param name="input">The object to get the week number from. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The week number of the year converted to type <typeparamref name="T"/>, or <c>default(T)</c> if the input is <c>null</c> or cannot be converted to a DateTime.</returns>
    /// <remarks>
    /// The week number is calculated based on the current culture's calendar, week rule, and first day of the week.
    /// This generic version allows for flexible return types, such as converting the week number to a string, decimal, or other numeric type.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? GetWeekOfYear<T>(this object? input) => input.GetWeekOfYearImplement<T>();

    /// <summary>
    /// Calculates the total number of months between two objects that can be converted to DateTime and returns it as the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the total months to.</typeparam>
    /// <param name="input1">The first object that can be converted to DateTime. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <param name="input2">The second object that can be converted to DateTime. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <returns>The absolute number of months between the two dates converted to type <typeparamref name="T"/>, or <c>default(T)</c> if either input is <c>null</c> or cannot be converted to a DateTime.</returns>
    /// <remarks>
    /// The calculation is based on the difference in years and months, not on the exact number of days.
    /// The result is always a positive number, regardless of which date comes first.
    /// This generic version allows for flexible return types, such as converting the total months to a string, decimal, or other numeric type.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? TotalMonth<T>(object? input1, object? input2) => TotalMonthImplement<T>(input1, input2);
}
