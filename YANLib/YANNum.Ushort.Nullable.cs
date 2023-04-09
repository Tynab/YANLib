namespace YANLib;

public static partial class YANNum
{
    
    public static ushort ToUshort<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToUshort(dfltVal.Value) : default;

    
    public static ushort GenRandomUshort<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomUshort(min.Value, max) : default;

    
    public static ushort GenRandomUshort<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomUshort(min, max.Value) : default;

    
    public static ushort GenRandomUshort<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomUshort(min.Value, max) : default;

    
    public static ushort GenRandomUshort<T>(T? max) where T : struct => max.HasValue ? GenRandomUshort(ushort.MinValue, max.Value) : default;
}
