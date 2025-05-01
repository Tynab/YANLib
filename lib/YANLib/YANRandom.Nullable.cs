using System.Diagnostics;

namespace YANLib;

/// <summary>
/// Provides methods for generating random nullable values of various types.
/// </summary>
/// <remarks>
/// This class extends the <see cref="YANRandom"/> class with methods to generate random nullable values
/// for a wide range of data types including numeric types, booleans, characters, strings, and dates.
/// The generated values are non-null and follow the same distribution as their non-nullable counterparts.
/// </remarks>
public static partial class YANRandom
{
    /// <summary>
    /// Generates a random nullable value of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to generate a random nullable value for.</typeparam>
    /// <returns>A random non-null value of the specified nullable type.</returns>
    /// <remarks>
    /// This method supports generating random values for built-in types including numeric types,
    /// booleans, characters, strings, and dates. For unsupported types, a random boolean value is returned.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? GenerateRandom<T>() => Implementation.YANRandom.GenerateRandomImplement<T>();
}
