using System.Numerics;

namespace YANLib.Implementation;

internal static partial class YANMath
{
    internal static bool IsEvenImplement<T>(this T input) where T : INumberBase<T> => T.IsEvenInteger(input);

    internal static bool IsEvenImplement<T>(this T? input) where T : struct, INumberBase<T> => input.HasValue && T.IsEvenInteger(input.GetValueOrDefault());

    internal static bool IsOddImplement<T>(this T input) where T : INumberBase<T> => T.IsOddInteger(input);

    internal static bool IsOddImplement<T>(this T? input) where T : struct, INumberBase<T> => input.HasValue && T.IsOddInteger(input.GetValueOrDefault());
}
