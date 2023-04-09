namespace YANLib;

public static partial class YANNum
{
    
    public static ulong ToUlong<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToUlong(dfltVal.Value) : default;

    
    public static ulong GenRandomUlong<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomUlong(min.Value, max) : default;

    
    public static ulong GenRandomUlong<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomUlong(min, max.Value) : default;

    
    public static ulong GenRandomUlong<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomUlong(min.Value, max) : default;

    
    public static ulong GenRandomUlong<T>(T? max) where T : struct => max.HasValue ? GenRandomUlong(ulong.MinValue, max.Value) : default;
}
