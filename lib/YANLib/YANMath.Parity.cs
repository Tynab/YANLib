using System.Diagnostics;
using System.Numerics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANMath
{
    #region IsEven

    /// <summary>
    /// Determines whether the specified number is an even integer.
    /// </summary>
    /// <typeparam name="T">The number type: any type that implements <see cref="INumberBase{TSelf}"/>, such as <see cref="int"/>, <see cref="long"/>, <see cref="BigInteger"/>, <see cref="double"/> or <see cref="decimal"/>.</typeparam>
    /// <param name="input">The number to check.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="input"/> is an even integer (<c>4</c>, <c>0</c>, <c>-2</c>, <c>4.0</c>, <c>4.0m</c>); otherwise, <c>false</c>,
    /// also for a number with a fractional part (<c>4.5</c>), <see cref="double.NaN"/> and infinity.
    /// </returns>
    /// <remarks>This is <see cref="INumberBase{TSelf}.IsEvenInteger(TSelf)"/> of <typeparamref name="T"/>.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsEven<T>(this T input) where T : INumberBase<T> => input.IsEvenImplement();

    /// <summary>
    /// Determines whether the specified nullable number has a value that is an even integer.
    /// </summary>
    /// <typeparam name="T">The number type: any value type that implements <see cref="INumberBase{TSelf}"/>, such as <see cref="int"/>, <see cref="long"/>, <see cref="double"/> or <see cref="decimal"/>.</typeparam>
    /// <param name="input">The number to check.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="input"/> has a value that is an even integer; otherwise, <c>false</c>, also when it is <c>null</c>.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsEven<T>(this T? input) where T : struct, INumberBase<T> => input.IsEvenImplement();

    #endregion

    #region IsOdd

    /// <summary>
    /// Determines whether the specified number is an odd integer.
    /// </summary>
    /// <typeparam name="T">The number type: any type that implements <see cref="INumberBase{TSelf}"/>, such as <see cref="int"/>, <see cref="long"/>, <see cref="BigInteger"/>, <see cref="double"/> or <see cref="decimal"/>.</typeparam>
    /// <param name="input">The number to check.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="input"/> is an odd integer (<c>3</c>, <c>-1</c>, <c>3.0</c>, <c>3.0m</c>); otherwise, <c>false</c>,
    /// also for a number with a fractional part (<c>3.5</c>), <see cref="double.NaN"/> and infinity.
    /// </returns>
    /// <remarks>This is <see cref="INumberBase{TSelf}.IsOddInteger(TSelf)"/> of <typeparamref name="T"/>.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsOdd<T>(this T input) where T : INumberBase<T> => input.IsOddImplement();

    /// <summary>
    /// Determines whether the specified nullable number has a value that is an odd integer.
    /// </summary>
    /// <typeparam name="T">The number type: any value type that implements <see cref="INumberBase{TSelf}"/>, such as <see cref="int"/>, <see cref="long"/>, <see cref="double"/> or <see cref="decimal"/>.</typeparam>
    /// <param name="input">The number to check.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="input"/> has a value that is an odd integer; otherwise, <c>false</c>, also when it is <c>null</c>.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static bool IsOdd<T>(this T? input) where T : struct, INumberBase<T> => input.IsOddImplement();

    #endregion
}
