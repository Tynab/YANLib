namespace YANLib;

public partial class YANNum
{
    
    public static sbyte ToSbyte<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToSbyte(dfltVal.Value) : default;

    
    public static sbyte GenRandomSbyte<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomSbyte(min.Value, max) : default;

    
    public static sbyte GenRandomSbyte<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomSbyte(min, max.Value) : default;

    
    public static sbyte GenRandomSbyte<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomSbyte(min.Value, max) : default;

    
    public static sbyte GenRandomSbyte<T>(T? max) where T : struct => max.HasValue ? GenRandomSbyte(sbyte.MinValue, max.Value) : default;
}
