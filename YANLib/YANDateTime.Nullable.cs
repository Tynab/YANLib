using static System.DateTime;

namespace YANLib;

public static partial class YANDateTime
{
    /// <summary>
    /// Parses a string representation of a date and time to a <see cref="DateTime"/> value. If the parsing fails, returns the default value specified.
    /// </summary>
    /// <param name="str">The string representation of the date and time to parse.</param>
    /// <param name="fmt">The format of the string representation of the date and time.</param>
    /// <param name="dfltVal">The default value to return if the parsing fails.</param>
    /// <returns>The parsed <see cref="DateTime"/> value or the default value if the parsing fails.</returns>
    public static DateTime ParseDateTime(this string str, string fmt, DateTime? dfltVal) => dfltVal.HasValue ? str.ParseDateTime(fmt, dfltVal.Value) : Today;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> between the specified minimum and maximum values. If no minimum value is provided, the current date will be used as the minimum.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value to be used (optional).</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value to be used.</param>
    /// <returns>A random <see cref="DateTime"/> value between the specified <paramref name="min"/> and <paramref name="max"/> values.</returns>
    public static DateTime RandomDateTime(DateTime? min, DateTime max) => min.HasValue ? RandomDateTime(min.Value, max) : Today;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> between the specified minimum and maximum values. If no maximum value is provided, the current date will be used as the maximum.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value to be used.</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value to be used (optional).</param>
    /// <returns>A random <see cref="DateTime"/> value between the specified <paramref name="min"/> and <paramref name="max"/> values.</returns>
    public static DateTime RandomDateTime(DateTime min, DateTime? max) => max.HasValue ? RandomDateTime(min, max.Value) : Today;

    /// <summary>
    /// Generates a random <see cref="DateTime"/> between the specified minimum and maximum values. If no minimum value is provided, the maximum value will be used as the minimum. If no maximum value is provided, the current date will be used as the maximum.
    /// </summary>
    /// <param name="min">The minimum <see cref="DateTime"/> value to be used (optional).</param>
    /// <param name="max">The maximum <see cref="DateTime"/> value to be used (optional).</param>
    /// <returns>A random <see cref="DateTime"/> value between the specified <paramref name="min"/> and <paramref name="max"/> values.</returns>
    public static DateTime RandomDateTime(DateTime? min, DateTime? max) => min.HasValue ? RandomDateTime(min.Value, max) : RandomDateTime(max);

    /// <summary>
    /// Generates a random <see cref="DateTime"/> before the specified maximum value. If no maximum value is provided, the current date will be used as the maximum.
    /// </summary>
    /// <param name="max">The maximum <see cref="DateTime"/> value to be used (optional).</param>
    /// <returns>A random <see cref="DateTime"/> value before the specified <paramref name="max"/> value.</returns>
    public static DateTime RandomDateTime(DateTime? max) => max.HasValue ? RandomDateTime(max.Value) : Today;

    /// <summary>
    /// Gets the week of the year for the specified <see cref="DateTime"/>. If no <see cref="DateTime"/> is provided, returns 0.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to get the week of the year for (optional).</param>
    /// <returns>The week of the year for the specified <paramref name="dt"/>, or 0 if no <see cref="DateTime"/> is provided.</returns>
    public static int GetWeekOfYear(this DateTime? dt) => dt.HasValue ? dt.Value.GetWeekOfYear() : 0;

    /// <summary>
    /// Gets the total number of months between two specified <see cref="DateTime"/> values. If no starting <see cref="DateTime"/> is provided, returns 0.
    /// </summary>
    /// <param name="dt1">The starting <see cref="DateTime"/> value (optional).</param>
    /// <param name="dt2">The ending <see cref="DateTime"/> value.</param>
    /// <returns>The total number of months between the two specified <paramref name="dt1"/> and <paramref name="dt2"/> values, or 0 if no starting <see cref="DateTime"/> is provided.</returns>
    public static int TotalMonths(DateTime? dt1, DateTime dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : 0;

    /// <summary>
    /// Gets the total number of months between two specified <see cref="DateTime"/> values. If no ending <see cref="DateTime"/> is provided, returns 0.
    /// </summary>
    /// <param name="dt1">The starting <see cref="DateTime"/> value.</param>
    /// <param name="dt2">The ending <see cref="DateTime"/> value (optional).</param>
    /// <returns>The total number of months between the two specified <paramref name="dt1"/> and <paramref name="dt2"/> values, or 0 if no ending <see cref="DateTime"/> is provided.</returns>
    public static int TotalMonths(DateTime dt1, DateTime? dt2) => dt2.HasValue ? TotalMonths(dt1, dt2.Value) : 0;

    /// <summary>
    /// Gets the total number of months between two specified <see cref="DateTime"/> values. If no starting or ending <see cref="DateTime"/> is provided, returns 0.
    /// </summary>
    /// <param name="dt1">The starting <see cref="DateTime"/> value (optional).</param>
    /// <param name="dt2">The ending <see cref="DateTime"/> value (optional).</param>
    /// <returns>The total number of months between the two specified <paramref name="dt1"/> and <paramref name="dt2"/> values, or 0 if no starting or ending <see cref="DateTime"/> is provided.</returns>
    public static int TotalMonths(DateTime? dt1, DateTime? dt2) => dt1.HasValue ? TotalMonths(dt1.Value, dt2) : 0;

    /// <summary>
    /// Converts a nullable <see cref="DateTime"/> value from a source timezone to a destination timezone. The source timezone offset and destination timezone offset are provided in hours. If the input value is null, the method returns the current date in the destination timezone.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzSrc">The timezone offset, in hours, of the source timezone.</param>
    /// <param name="tzDst">The timezone offset, in hours, of the destination timezone.</param>
    /// <returns>The converted <see cref="DateTime"/> value. If the input value is null, the method returns the current date in the destination timezone.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int tzSrc, int tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : Today;

    /// <summary>
    /// Converts a <see cref="DateTime"/> value from a source timezone to a destination timezone. The source timezone offset, if provided, and destination timezone offset are provided in hours. If the source timezone offset is null, it is assumed to be 0.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzSrc">The timezone offset, in hours, of the source timezone. If null, it is assumed to be 0.</param>
    /// <param name="tzDst">The timezone offset, in hours, of the destination timezone.</param>
    /// <returns>The converted <see cref="DateTime"/> value.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int? tzSrc, int tzDst) => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    /// <summary>
    /// Converts a <see cref="DateTime"/> value from a source timezone to a destination timezone. The source timezone offset and destination timezone offset, if provided, are provided in hours. If the destination timezone offset is null, the method returns the input value unchanged.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzSrc">The timezone offset, in hours, of the source timezone.</param>
    /// <param name="tzDst">The timezone offset, in hours, of the destination timezone. If null, the input value is returned unchanged.</param>
    /// <returns>The converted <see cref="DateTime"/> value.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int tzSrc, int? tzDst) => tzDst.HasValue ? dt.ChangeTimeZone(tzSrc, tzDst.Value) : dt;

    /// <summary>
    /// Converts a nullable <see cref="DateTime"/> value from a source timezone to a destination timezone. The source timezone offset, if provided, and destination timezone offset are provided in hours. If the source timezone offset is null, it is assumed to be 0. If the input value is null, the method returns the current date.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> value to convert. If null, the method returns the current date.</param>
    /// <param name="tzSrc">The timezone offset, in hours, of the source timezone. If null, it is assumed to be 0.</param>
    /// <param name="tzDst">The timezone offset, in hours, of the destination timezone.</param>
    /// <returns>The converted <see cref="DateTime"/> value.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int? tzSrc, int tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : Today;

    /// <summary>
    /// Converts a nullable <see cref="DateTime"/> value from a source timezone to a destination timezone. The source timezone offset and destination timezone offset, if provided, are specified in hours. If the source timezone offset is null, it is assumed to be 0. If the destination timezone offset is null, it is assumed to be the same as the source timezone offset. If the input value is null, the method returns the current date.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> value to convert. If null, the method returns the current date.</param>
    /// <param name="tzSrc">The timezone offset, in hours, of the source timezone. If null, it is assumed to be 0.</param>
    /// <param name="tzDst">The timezone offset, in hours, of the destination timezone. If null, it is assumed to be the same as the source timezone offset.</param>
    /// <returns>The converted <see cref="DateTime"/> value.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int tzSrc, int? tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : Today;

    /// <summary>
    /// Converts a DateTime value from a source time zone to a destination time zone.
    /// </summary>
    /// <param name="dt">The DateTime value to convert.</param>
    /// <param name="tzSrc">The source time zone offset in hours.</param>
    /// <param name="tzDst">The destination time zone offset in hours.</param>
    /// <returns>A new DateTime value in the destination time zone.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int? tzSrc, int? tzDst) => tzSrc.HasValue ? dt.ChangeTimeZone(tzSrc.Value, tzDst) : dt.ChangeTimeZone(tzDst);

    /// <summary>
    /// Converts the given <paramref name="dt"/> to the target time zone offset by <paramref name="tzDst"/> hours, adjusting for the difference in time zone offset between <paramref name="tzSrc"/> and <paramref name="tzDst"/>. If <paramref name="tzSrc"/> is null, the source time zone offset is assumed to be 0. If <paramref name="tzDst"/> is null, the output is in the same time zone as the input.
    /// </summary>
    /// <param name="dt">The DateTime to convert</param>
    /// <param name="tzSrc">The source time zone offset in hours. If null, the default value of 0 is used.</param>
    /// <param name="tzDst">The target time zone offset in hours. If null, the output is in the same time zone as the input.</param>
    /// <returns>The DateTime in the target time zone, adjusted for the difference in time zone offset between <paramref name="tzSrc"/> and <paramref name="tzDst"/>.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int? tzSrc, int? tzDst) => dt.HasValue ? dt.Value.ChangeTimeZone(tzSrc, tzDst) : Today;

    /// <summary>
    /// Converts the given nullable <see cref="DateTime"/> value to the specified destination time zone <paramref name="tzDst"/>.
    /// </summary>
    /// <param name="dt">The nullable <see cref="DateTime"/> value to convert.</param>
    /// <param name="tzDst">The destination time zone.</param>
    /// <returns>The converted <see cref="DateTime"/> value in the destination time zone if the input is not null; otherwise, the current date in the destination time zone.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int tzDst) => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Converts the given <see cref="DateTime"/> to a new time zone specified by the destination time zone offset while keeping the same date and time value. If the source time zone offset is not specified, the local time zone is used. If the destination time zone offset is not specified, the original date and time value is returned.
    /// </summary>
    /// <param name="dt">The <see cref="DateTime"/> to convert.</param>
    /// <param name="tzDst">The destination time zone offset, in hours relative to Coordinated Universal Time (UTC).</param>
    /// <returns>A new <see cref="DateTime"/> object representing the same date and time value in the new time zone.</returns>
    public static DateTime ChangeTimeZone(this DateTime dt, int? tzDst) => dt.ChangeTimeZone(0, tzDst);

    /// <summary>
    /// Converts the date and time of the current instance to a specified time zone.
    /// </summary>
    /// <param name="dt">The date and time to convert.</param>
    /// <param name="tzDst">The time zone to convert to.</param>
    /// <returns>The converted date and time.</returns>
    public static DateTime ChangeTimeZone(this DateTime? dt, int? tzDst) => dt.ChangeTimeZone(0, tzDst);
}
