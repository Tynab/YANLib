namespace YANLib;

public partial class YANNum
{
    
    public static short ToShort<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToShort(dfltVal.Value) : default;

    
    public static short GenRandomShort<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomShort(min.Value, max) : default;

    
    public static short GenRandomShort<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomShort(min, max.Value) : default;

    
    public static short GenRandomShort<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomShort(min.Value, max) : default;

    
    public static short GenRandomShort<T>(T? max) where T : struct => max.HasValue ? GenRandomShort(short.MinValue, max.Value) : default;
}
