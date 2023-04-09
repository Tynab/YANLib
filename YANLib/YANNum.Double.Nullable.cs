namespace YANLib;

public static partial class YANNum
{
    
    public static double ToDouble<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToDouble(dfltVal.Value) : default;

    
    public static double GenRandomDouble<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomDouble(min.Value, max) : default;

    
    public static double GenRandomDouble<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomDouble(min, max.Value) : default;

    
    public static double GenRandomDouble<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomDouble(min.Value, max) : default;

    
    public static double GenRandomDouble<T>(T? max) where T : struct => max.HasValue ? GenRandomDouble(double.MinValue, max.Value) : default;
}
