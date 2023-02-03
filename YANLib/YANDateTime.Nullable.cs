using static System.DateTime;
using static System.Math;

namespace YANLib;

public static partial class YANDateTime
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="tzSrc"></param>
    /// <param name="tzDst"></param>
    /// <returns></returns>
    public static DateTime? ChangeTimeZone(this DateTime? dt, int tzSrc, int tzDst)
    {
        if (dt.HasValue)
        {
            var diff = tzDst - tzSrc;
            if (diff < 0 && (dt.Value - MinValue).TotalHours >= Abs(diff))
            {
                dt = dt.Value.AddHours(diff);
            }
            else if (diff > 0 && (MaxValue - dt.Value).TotalHours >= diff)
            {
                dt = dt.Value.AddHours(diff);
            }
        }
        return dt;
    }
}
