using static YANLib.YANNum;

namespace YANLib;

public static partial class YANBool
{
    /// <summary>
    /// Generates a random boolean value.
    /// Returns <see langword="true"/> or <see langword="false"/> with equal probability.
    /// </summary>
    /// <returns>A random boolean value.</returns>
    public static bool GenerateRandomBool() => GenerateRandomByte(0, 2) is 1;

    /// <summary>
    /// Generates an <see cref="IEnumerable{bool}"/> containing random boolean values.
    /// The number of boolean values generated is determined by the value of <paramref name="size"/>.
    /// </summary>
    /// <typeparam name="T">
    /// The type of <paramref name="size"/>.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="size">The number of boolean values to generate.</param>
    /// <returns>An <see cref="IEnumerable{bool}"/> containing random boolean values.</returns>
    public static IEnumerable<bool> GenerateRandomBools<T>(T size) where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomBool();
        }
    }
}
