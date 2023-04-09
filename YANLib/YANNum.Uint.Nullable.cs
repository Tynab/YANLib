namespace YANLib;

public static partial class YANNum
{
    
    public static uint ToUint<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToUint(dfltVal.Value) : default;

    
    public static uint GenRandomUint<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomUint(min.Value, max) : default;

    
    public static uint GenRandomUint<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomUint(min, max.Value) : default;

    
    public static uint GenRandomUint<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomUint(min.Value, max) : default;

    
    public static uint GenRandomUint<T>(T? max) where T : struct => max.HasValue ? GenRandomUint(uint.MinValue, max.Value) : default;
}
