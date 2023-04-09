namespace YANLib;

public partial class YANNum
{
    
    public static long ToLong<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToLong(dfltVal.Value) : default;

    
    public static long GenRandomLong<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomLong(min.Value, max) : default;

    
    public static long GenRandomLong<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomLong(min, max.Value) : default;

    
    public static long GenRandomLong<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomLong(min.Value, max) : default;

    
    public static long GenRandomLong<T>(T? max) where T : struct => max.HasValue ? GenRandomLong(long.MinValue, max.Value) : default;
}
