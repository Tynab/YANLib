namespace YANLib;

public partial class YANNum
{
    
    public static decimal ToDecimal<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToDecimal(dfltVal.Value) : default;

    
    public static decimal GenRandomDecimal<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomDecimal(min.Value, max) : default;

    
    public static decimal GenRandomDecimal<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomDecimal(min, max.Value) : default;

    
    public static decimal GenRandomDecimal<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomDecimal(min.Value, max) : default;

    
    public static decimal GenRandomDecimal<T>(T? max) where T : struct => max.HasValue ? GenRandomDecimal(decimal.MinValue, max.Value) : default;
}
