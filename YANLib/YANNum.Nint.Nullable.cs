namespace YANLib;

public static partial class YANNum
{
    
    public static nint ToNint<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToNint(dfltVal.Value) : default;

    
    public static nint GenRandomNint<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomNint(min.Value, max) : default;

    
    public static nint GenRandomNint<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomNint(min, max.Value) : default;

    
    public static nint GenRandomNint<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomNint(min.Value, max) : default;

    
    public static nint GenRandomNint<T>(T? max) where T : struct => max.HasValue ? GenRandomNint(nint.MinValue, max.Value) : default;
}
