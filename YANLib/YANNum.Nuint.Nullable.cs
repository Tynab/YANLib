namespace YANLib;

public static partial class YANNum
{
    
    public static nuint ToNuint<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToNuint(dfltVal.Value) : default;

    
    public static nuint GenRandomNuint<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomNuint(min.Value, max) : default;

    
    public static nuint GenRandomNuint<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomNuint(min, max.Value) : default;

    
    public static nuint GenRandomNuint<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomNuint(min.Value, max) : default;

    
    public static nuint GenRandomNuint<T>(T? max) where T : struct => max.HasValue ? GenRandomNuint(nuint.MinValue, max.Value) : default;
}
