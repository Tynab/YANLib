using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for parsing objects to unmanaged types and collections.
/// </summary>
/// <remarks>
/// This class contains methods for converting objects to various unmanaged types such as numeric types,
/// <see cref="DateTime"/>, <see cref="Guid"/>, and enums. It supports both individual object parsing
/// and collection parsing, with options for default values and format specifications.
/// </remarks>
public static partial class YANUnmanaged
{
    /// <summary>
    /// Parses an object to the specified unmanaged type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">
    /// The object to parse. A <c>null</c> input counts as a failed parse: the method returns <paramref name="defaultValue"/>, or the default value
    /// of <typeparamref name="T"/> when <paramref name="defaultValue"/> is <c>null</c> or cannot be converted.
    /// </param>
    /// <param name="defaultValue">The default value to return if parsing fails. If <c>null</c>, returns the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or the default value if parsing fails.</returns>
    /// <remarks>
    /// This method supports parsing to various unmanaged types including numeric types (also <see cref="nint"/> and <see cref="nuint"/>),
    /// <see cref="DateTime"/>, <see cref="Guid"/>, and enums.
    /// If the input cannot be parsed to the specified type, the method will return the provided default value or the type's default value.
    /// This also applies to numbers outside the range of <typeparamref name="T"/> (for example <c>1e10</c> or <c>"99999999999"</c> for <see cref="int"/>)
    /// and to fractional strings for integer types (<c>"3.5"</c>); boxed fractional numbers are rounded half to even like <see cref="Convert.ToInt32(double)"/>.
    /// An <paramref name="input"/> that already is a <typeparamref name="T"/> is returned unchanged (a <see cref="DateTime"/> keeps its
    /// milliseconds and <see cref="DateTime.Kind"/>), and so is a <paramref name="defaultValue"/> of type <typeparamref name="T"/>, also when
    /// <paramref name="format"/> is given. For <see cref="DateTime"/>, a <paramref name="defaultValue"/> of another type (usually a string) is
    /// turned into text and parsed with <paramref name="format"/> first and, if that fails, like an input without a format (current culture):
    /// <c>"bad".Parse&lt;DateTime&gt;("2025-01-01", "dd/MM/yyyy")</c> is 1 January 2025 (before 8.4.0 it was <see cref="DateTime.MinValue"/>).
    /// The method never throws, even when <see cref="object.ToString"/> of the input throws.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Parse<T>(this object? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParseImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses an object to the specified unmanaged type using the provided format strings.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">
    /// The object to parse. A <c>null</c> input counts as a failed parse: the method returns <paramref name="defaultValue"/>, or the default value
    /// of <typeparamref name="T"/> when <paramref name="defaultValue"/> is <c>null</c> or cannot be converted.
    /// </param>
    /// <param name="defaultValue">The default value to return if parsing fails. If <c>null</c>, returns the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or the default value if parsing fails.</returns>
    /// <remarks>
    /// This overload accepts format strings as params array for convenience.
    /// Conversion rules are the same as for <see cref="Parse{T}(object, object, IEnumerable{string})"/>; the method never throws.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Parse<T>(this object? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParseImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses an object to the specified unmanaged type with the given culture-specific format information.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">
    /// The object to parse. A <c>null</c> input counts as a failed parse: the method returns <paramref name="defaultValue"/>, or the default value
    /// of <typeparamref name="T"/> when <paramref name="defaultValue"/> is <c>null</c> or cannot be converted.
    /// </param>
    /// <param name="provider">
    /// The culture-specific format information for every culture-dependent step: parsing numbers, <see cref="DateTime"/> and <see cref="TimeSpan"/>
    /// text, <see cref="Convert.ChangeType(object, Type, IFormatProvider)"/>, and turning an <paramref name="input"/> or <paramref name="defaultValue"/>
    /// that implements <see cref="IFormattable"/> into text (with <see cref="IFormattable.ToString(string, IFormatProvider)"/>, which can differ
    /// from <see cref="object.ToString"/> for a custom type). An enum is the exception: <see cref="Enum"/> ignores the provider, so a negative enum
    /// value without a name, such as <c>(DayOfWeek)(-1)</c>, gets the negative sign of the current culture (U+2212 under sv-SE). If <c>null</c>, the
    /// current culture is used exactly as by <see cref="Parse{T}(object, object, IEnumerable{string})"/>, and text comes from <see cref="object.ToString"/>.
    /// </param>
    /// <param name="defaultValue">The default value to return if parsing fails. If <c>null</c>, returns the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">
    /// The exact format strings for <see cref="DateTime"/> parsing. As with <see cref="Parse{T}(object, object, IEnumerable{string})"/>, they are always
    /// matched with the invariant culture (<c>/</c> and <c>:</c> stay literal); <paramref name="provider"/> does not change them. A
    /// <paramref name="defaultValue"/> that is not a <see cref="DateTime"/> is parsed with them first and, if they do not match, with
    /// <paramref name="provider"/> like an input without a format.
    /// </param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or the default value if parsing fails.</returns>
    /// <remarks>
    /// The conversion rules are those of <see cref="Parse{T}(object, object, IEnumerable{string})"/>; only the culture differs. For example, with
    /// <c>CultureInfo.InvariantCulture</c> the string <c>"1.5"</c> is 1.5 for <see cref="double"/> under any current culture, while
    /// <c>"1.5".Parse&lt;double&gt;(0d)</c> is 15 under de-DE or vi-VN. The method never throws, also when <paramref name="provider"/> throws: that step
    /// then counts as a failed parse.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T ParseWith<T>(this object? input, IFormatProvider? provider, object? defaultValue, IEnumerable<string?>? format) where T : unmanaged
        => input.ParseWithImplement<T>(provider, defaultValue, format);

    /// <summary>
    /// Parses an object to the specified unmanaged type with the given culture-specific format information and the provided format strings.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">
    /// The object to parse. A <c>null</c> input counts as a failed parse: the method returns <paramref name="defaultValue"/>, or the default value
    /// of <typeparamref name="T"/> when <paramref name="defaultValue"/> is <c>null</c> or cannot be converted.
    /// </param>
    /// <param name="provider">
    /// The culture-specific format information for every culture-dependent step (see <see cref="ParseWith{T}(object, IFormatProvider, object, IEnumerable{string})"/>).
    /// If <c>null</c>, the current culture is used exactly as by <see cref="Parse{T}(object, object, string[])"/>.
    /// </param>
    /// <param name="defaultValue">The default value to return if parsing fails. If <c>null</c>, returns the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">
    /// The exact format strings for <see cref="DateTime"/> parsing, always matched with the invariant culture; <paramref name="provider"/> does not change them.
    /// </param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or the default value if parsing fails.</returns>
    /// <remarks>
    /// This overload accepts format strings as params array for convenience: <c>"1.5".ParseWith&lt;double&gt;(CultureInfo.InvariantCulture, 0d)</c> is 1.5
    /// under any current culture. The conversion rules are those of <see cref="Parse{T}(object, object, string[])"/>; the method never throws, also when
    /// <paramref name="provider"/> throws.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T ParseWith<T>(this object? input, IFormatProvider? provider, object? defaultValue, params string?[]? format) where T : unmanaged
        => input.ParseWithImplement<T>(provider, defaultValue, format);
}
