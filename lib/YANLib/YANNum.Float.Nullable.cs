﻿using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{

    public static float ToFloat<T>(this T? num) where T : struct
    {
        try
        {
            return Convert.ToSingle(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<float>? ToFloat<T>(this IEnumerable<T?> nums) where T : struct => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToFloat());

    public static float ToFloat<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToFloat(dfltVal.Value) : default;

    public static IEnumerable<float>? ToFloat<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToFloat(dfltVal));

    public static float GenerateRandomFloat<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomFloat(min.Value, max) : default;

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomFloat(min, max));

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomFloat(min, max));

    public static float GenerateRandomFloat<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomFloat(min, max.Value) : default;

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomFloat(min, max));

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomFloat(min, max));

    public static float GenerateRandomFloat<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomFloat(min.Value, max) : default;

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomFloat(min, max));

    public static IEnumerable<float> GenerateRandomFloats<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomFloat(min, max));

    public static float GenerateRandomFloat<T>(T? max) where T : struct => max.HasValue ? GenerateRandomFloat(float.MinValue, max.Value) : default;
}
