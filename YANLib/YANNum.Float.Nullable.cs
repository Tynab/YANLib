namespace YANLib;

public partial class YANNum
{
    
    public static float ToFloat<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToFloat(dfltVal.Value) : default;

    
    public static float GenRandomFloat<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomFloat(min.Value, max) : default;

    
    public static float GenRandomFloat<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomFloat(min, max.Value) : default;

    
    public static float GenRandomFloat<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomFloat(min.Value, max) : default;

    
    public static float GenRandomFloat<T>(T? max) where T : struct => max.HasValue ? GenRandomFloat(float.MinValue, max.Value) : default;
}
