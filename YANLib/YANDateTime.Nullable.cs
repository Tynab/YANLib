using static System.DateTime;

namespace YANLib;

public static partial class YANDateTime
{
    /// <summary>
    /// Parses the string representation of a date and time using <paramref name="fmt"/>.
    /// Returns the parsed <see cref="DateTime"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// If <paramref name="dfltVal"/> is not specified, returns the current date instead.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="fmt">The format of the string representation.</param>
    /// <param name="dfltVal">The default value to return if the parsing fails.</param>
    /// <returns>The parsed <see cref="DateTime"/> value, <paramref name="dfltVal"/> if the parsing succeeds, or the current date if <paramref name="dfltVal"/> is not specified or <see langword="null"/>.</returns>
    public static DateTime ParseDateTime(this string str, string fmt, DateTime? dfltVal) => dfltVal.HasValue ? str.ParseDateTime(fmt, dfltVal.Value) : Today;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, <see cref="Today"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static DateTime RandomDateTime(DateTime? min, DateTime max) => min.HasValue ? RandomDateTime(min.Value, max) : Today;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see cref="Today"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static DateTime RandomDateTime(DateTime min, DateTime? max) => max.HasValue ? RandomDateTime(min, max.Value) : Today;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, <see cref="Today"/> is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, a random date is generated between <see cref="MinValue"/> and <paramref name="max"/>.
    /// If only <paramref name="max"/> is <see langword="null"/>, a random date is generated between <paramref name="min"/> and <see cref="Today"/>.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random <see cref="DateTime"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static DateTime RandomDateTime(DateTime? min, DateTime? max) => min.HasValue ? RandomDateTime(min.Value, max) : RandomDateTime(max);

    /// <summary>
    /// Generates a random <see cref="DateTime"/> value between <see cref="MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see cref="Today"/> is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="DateTime"/> value.</param>
    /// <returns>A random <see cref="DateTime"/> value between <see cref="MinValue"/> and <paramref name="max"/>.</returns>
    public static DateTime RandomDateTime(DateTime? max) => max.HasValue ? RandomDateTime(max.Value) : Today;

    /// <summary>
    /// Returns the week of the year that the specified <see cref="DateTime"/> value falls in, according to the current culture's calendar, week rule, and first day of the week settings.
    /// If the input value is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value.</param>
    /// <returns>The week of the year that the specified <see cref="DateTime"/> value falls in, or 0 if the input value is <see langword="null"/>.</returns>
    public static int GetWeekOfYear(this DateTime? dt) => dt.HasValue ? dt.Value.GetWeekOfYear() : 0;

    /// <summary>
    /// Returns the total number of months between the specified nullable <see cref="DateTime"/> value and the specified <see cref="DateTime"/> value, ignoring the day of the month.
    /// </summary>
    /// <param name="dt1">The nullable <see cref="DateTime"/> value.</param>
    /// <param name="dt2">The <see cref="DateTime"/> value.</param>
    /// <returns>The total number of months between the specified nullable <see cref="DateTime"/> value and the specified <see cref="DateTime"/> value, ignoring the day of the month.</returns>
    public static int TotalMonths(DateTime? dt1, DateTime dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : 0;

    /// <summary>
    /// Returns the total number of months between the specified <see cref="DateTime"/> value and the specified nullable <see cref="DateTime"/> value, ignoring the day of the month.
    /// </summary>
    /// <param name="dt1">The <see cref="DateTime"/> value.</param>
    /// <param name="dt2">The nullable <see cref="DateTime"/> value.</param>
    /// <returns>The total number of months between the specified <see cref="DateTime"/> value and the specified nullable <see cref="DateTime"/> value, ignoring the day of the month.</returns>
    public static int TotalMonths(DateTime dt1, DateTime? dt2) => dt2.HasValue ? TotalMonths(dt1, dt2.Value) : 0;

    /// <summary>
    /// Returns the total number of months between the two specified nullable <see cref="DateTime"/> values, ignoring the day of the month.
    /// </summary>
    /// <param name="dt1">The first nullable <see cref="DateTime"/> value.</param>
    /// <param name="dt2">The second nullable <see cref="DateTime"/> value.</param>
    /// <returns>The total number of months between the two specified nullable <see cref="DateTime"/> values, ignoring the day of the month.</returns>
    public static int TotalMonths(DateTime? dt1, DateTime? dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : 0;

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.
    /// </summary>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>
    /// If the input <paramref name="dt"/> has a value, returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value,
    /// but converted to a different time zone specified by the <paramref name="tzSrc"/> and <paramref name="tzDst"/> parameters.
    /// If the input <paramref name="dt"/> is <see langword="null"/>, returns a new <see cref="DateTime"/> value representing today's date in the <paramref name="tzDst"/> time zone.
    /// </returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int tzSrc, int tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : Today;

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone specified by the <paramref name="tzSrc"/> and <paramref name="tzDst"/> parameters.
    /// If the <paramref name="tzSrc"/> parameter is <see langword="null"/>, the original <paramref name="dt"/> is used as-is, otherwise it is converted from the time zone specified by the <paramref name="tzSrc"/> parameter to the time zone specified by the <paramref name="tzDst"/> parameter.
    /// </summary>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.
    /// If <see langword="null"/>, the original <paramref name="dt"/> is used as-is.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int? tzSrc, int tzDst) => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone specified by the <paramref name="tzSrc"/> and <paramref name="tzDst"/> parameters.
    /// If the <paramref name="tzDst"/> parameter is <see langword="null"/>, the original <paramref name="dt"/> is returned as-is, otherwise it is converted from the time zone specified by the <paramref name="tzSrc"/> parameter to the time zone specified by the <paramref name="tzDst"/> parameter.
    /// </summary>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.
    /// If <see langword="null"/>, the original <paramref name="dt"/> is returned as-is.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int tzSrc, int? tzDst) => tzDst.HasValue ? dt.ChangeTimeZone(tzSrc, tzDst.Value) : dt;

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original nullable <see cref="DateTime"/> value, but converted to a different time zone specified by the <paramref name="tzSrc"/> and <paramref name="tzDst"/> parameters.
    /// If the original nullable <see cref="DateTime"/> value is <see langword="null"/>, the method returns the current date, converted to the time zone specified by the <paramref name="tzDst"/> parameter.
    /// If the <paramref name="tzSrc"/> parameter is <see langword="null"/>, the original nullable <see cref="DateTime"/> value is used as-is, otherwise it is converted from the time zone specified by the <paramref name="tzSrc"/> parameter to the time zone specified by the <paramref name="tzDst"/> parameter.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.
    /// If <see langword="null"/>, the original nullable <paramref name="dt"/> is used as-is.</param>
    /// <param name="tzDst">The time zone offset to convert the original nullable <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original nullable <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int? tzSrc, int tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : Today;

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original nullable <see cref="DateTime"/> value, but converted to a different time zone specified by the <paramref name="tzSrc"/> and <paramref name="tzDst"/> parameters.
    /// If the original nullable <see cref="DateTime"/> value is <see langword="null"/>, the method returns the current date, converted to the time zone specified by the <paramref name="tzDst"/> parameter.
    /// If the <paramref name="tzDst"/> parameter is <see langword="null"/>, the original nullable <paramref name="dt"/> is returned as-is, otherwise it is converted from the time zone specified by the <paramref name="tzSrc"/> parameter to the time zone specified by the <paramref name="tzDst"/> parameter.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.</param>
    /// <param name="tzDst">The time zone offset to convert the original nullable <see cref="DateTime"/> value to, in hours.
    /// If <see langword="null"/>, the original nullable <paramref name="dt"/> is returned as-is.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original nullable <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int tzSrc, int? tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : Today;

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone specified by the <paramref name="tzSrc"/> and <paramref name="tzDst"/> parameters.
    /// If <paramref name="tzSrc"/> is not <see langword="null"/>, the original <see cref="DateTime"/> value is assumed to be in the time zone specified by the <paramref name="tzSrc"/> parameter, otherwise the local time zone is used.
    /// If <paramref name="tzDst"/> is <see langword="null"/>, the original <see cref="DateTime"/> value is returned as-is.
    /// Otherwise, the original <see cref="DateTime"/> value is converted to the time zone specified by the <paramref name="tzDst"/> parameter.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.
    /// If <see langword="null"/>, the local time zone is used.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.
    /// If <see langword="null"/>, the original <see cref="DateTime"/> value is returned as-is.
    /// If <paramref name="tzSrc"/> is also <see langword="null"/>, the local time zone is used.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int? tzSrc, int? tzDst) => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original nullable <see cref="DateTime"/> value, but converted to a different time zone specified by the <paramref name="tzSrc"/> and <paramref name="tzDst"/> parameters.
    /// If the original nullable <see cref="DateTime"/> value is <see langword="null"/>, the method returns the current date, converted to the time zone specified by the <paramref name="tzDst"/> parameter.
    /// If the <paramref name="tzDst"/> parameter is <see langword="null"/>, the original nullable <paramref name="dt"/> is returned as-is, otherwise it is converted from the time zone specified by the <paramref name="tzSrc"/> parameter to the time zone specified by the <paramref name="tzDst"/> parameter.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzSrc">The time zone offset of the original <see cref="DateTime"/> value, in hours.
    /// If <see langword="null"/>, the local time zone is used.</param>
    /// <param name="tzDst">The time zone offset to convert the original nullable <see cref="DateTime"/> value to, in hours.
    /// If <see langword="null"/>, the original nullable <paramref name="dt"/> is returned as-is.
    /// If <paramref name="tzSrc"/> is also <see langword="null"/>, the local time zone is used.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original nullable <see cref="DateTime"/> value, but converted to a different time zone.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int? tzSrc, int? tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : Today;

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original nullable <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.
    /// If the original nullable <see cref="DateTime"/> value is <see langword="null"/>, the method returns the current date, converted to the time zone specified by the <paramref name="tzDst"/> parameter with a time zone offset of 0.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzDst">The time zone offset to convert the original nullable <see cref="DateTime"/> value to, in hours.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original nullable <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset of 0.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int tzDst) => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset specified by the <paramref name="tzDst"/> parameter.
    /// </summary>
    /// <param name="dt">The original <see cref="DateTime"/> value.</param>
    /// <param name="tzDst">The time zone offset to convert the original <see cref="DateTime"/> value to, in hours.
    /// If <see langword="null"/>, a time zone offset of 0 is used.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset specified by the <paramref name="tzDst"/> parameter.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int? tzDst) => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Returns a new <see cref="DateTime"/> value representing the same point in time as the original nullable <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset specified by the <paramref name="tzDst"/> parameter.
    /// If the original nullable <see cref="DateTime"/> value is <see langword="null"/>, the method returns the current date, converted to the time zone specified by the <paramref name="tzDst"/> parameter.
    /// If the <paramref name="tzDst"/> parameter is <see langword="null"/>, a time zone offset of 0 is used.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzDst">The time zone offset to convert the original nullable <see cref="DateTime"/> value to, in hours.
    /// If <see langword="null"/>, a time zone offset of 0 is used.</param>
    /// <returns>A new <see cref="DateTime"/> value representing the same point in time as the original nullable <see cref="DateTime"/> value, but converted to a different time zone with a time zone offset specified by the <paramref name="tzDst"/> parameter.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int? tzDst) => dt.ChangeTimeZone(0, tzDst);
}
