using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for parsing objects to nullable types.
/// </summary>
/// <remarks>
/// This partial class extends the functionality of <see cref="YANUnmanaged"/> to support parsing
/// to nullable types, including both nullable value types and reference types. Unlike the non-nullable
/// parsing methods, these methods return null instead of default values when parsing fails.
/// </remarks>
public static partial class YANUnmanaged
{
    /// <summary>
    /// Parses an object to the specified nullable type.
    /// </summary>
    /// <typeparam name="T">The type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The object to parse. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or <c>null</c> if parsing fails or the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method supports parsing to various types including strings, numeric types (also <see cref="nint"/> and <see cref="nuint"/>),
    /// <see cref="DateTime"/>, <see cref="Guid"/>, and enums.
    /// Unlike the non-nullable version, this method returns <c>null</c> instead of a default value when parsing fails.
    /// <para>
    /// When <typeparamref name="T"/> is a non-nullable integer type, a fractional or out-of-range string is floored using its exact
    /// decimal value (<c>"3.7"</c> → 3, <c>"-3.5"</c> → -4); if the floored value is still outside the range of <typeparamref name="T"/>,
    /// the result is 0. Boxed fractional numbers are rounded half to even (<c>2.5</c> → 2, <c>3.5</c> → 4). For a nullable
    /// <typeparamref name="T"/> such as <c>int?</c>, invalid, fractional or out-of-range input returns <c>null</c>.
    /// </para>
    /// <para>
    /// An <paramref name="input"/> that already is a <typeparamref name="T"/> is returned unchanged: a derived instance typed as its base
    /// class or interface stays the same instance, and a <see cref="DateTime"/> keeps its milliseconds and <see cref="DateTime.Kind"/>.
    /// The method never throws, even when <see cref="object.ToString"/> of the input throws.
    /// </para>
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Parse<T>(this object? input) => input.ParseImplement<T>();
}
