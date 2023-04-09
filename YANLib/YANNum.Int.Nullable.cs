namespace YANLib;

public partial class YANNum
{
    
    public static int ToInt<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToInt(dfltVal.Value) : default;

    
    public static int GenRandomInt<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomInt(min.Value, max) : default;

    
    public static int GenRandomInt<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomInt(min, max.Value) : default;

    
    public static int GenRandomInt<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomInt(min.Value, max) : default;

    
    public static int GenRandomInt<T>(T? max) where T : struct => max.HasValue ? GenRandomInt(int.MinValue, max.Value) : default;
}
