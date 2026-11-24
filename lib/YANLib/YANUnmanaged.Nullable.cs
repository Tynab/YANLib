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
    /// <typeparamref name="T"/> such as <c>int?</c>, invalid or out-of-range input and fractional strings return <c>null</c>.
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

    /// <summary>
    /// Parses an object to the specified nullable type with the given culture-specific format information.
    /// </summary>
    /// <typeparam name="T">The type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The object to parse. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="provider">
    /// The culture-specific format information for every culture-dependent step: parsing numbers, <see cref="DateTime"/> and <see cref="TimeSpan"/>
    /// text, <see cref="Convert.ChangeType(object, Type, IFormatProvider)"/>, and turning an <paramref name="input"/> that implements
    /// <see cref="IFormattable"/> into text, also for <see cref="string"/> targets (with <see cref="IFormattable.ToString(string, IFormatProvider)"/>,
    /// which can differ from <see cref="object.ToString"/> for a custom type). An enum is the exception: <see cref="Enum"/> ignores the provider,
    /// so a negative enum value without a name, such as <c>(DayOfWeek)(-1)</c>, gets the negative sign of the current culture (U+2212 under sv-SE).
    /// If <c>null</c>, the current culture is used exactly as by <see cref="Parse{T}(object)"/>, and text comes from <see cref="object.ToString"/>.
    /// </param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or <c>null</c> if parsing fails or the input is <c>null</c>.</returns>
    /// <remarks>
    /// The conversion rules are those of <see cref="Parse{T}(object)"/> (for example a fractional string is floored for a non-nullable integer
    /// <typeparamref name="T"/>); only the culture differs. Under any current culture, <c>"1.5".ParseWith&lt;double&gt;(CultureInfo.InvariantCulture)</c>
    /// is 1.5 and <c>1.5.ParseWith&lt;string&gt;(CultureInfo.InvariantCulture)</c> is <c>"1.5"</c>, while <c>"1.5".Parse&lt;double&gt;()</c> is 15 and
    /// <c>1.5.Parse&lt;string&gt;()</c> is <c>"1,5"</c> under de-DE or vi-VN. For the rules of
    /// <see cref="Parse{T}(object, object, IEnumerable{string})"/> instead (no flooring), pass a default value:
    /// <c>"3.7".ParseWith&lt;int&gt;(CultureInfo.InvariantCulture)</c> is 3, <c>"3.7".ParseWith&lt;int&gt;(CultureInfo.InvariantCulture, null)</c> is 0.
    /// The method never throws, also when <paramref name="provider"/> throws: that step then counts as a failed parse.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? ParseWith<T>(this object? input, IFormatProvider? provider) => input.ParseWithImplement<T>(provider);
}
