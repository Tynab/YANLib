using static System.Linq.Enumerable;
using static YANLib.Core.YANUnmanaged;

namespace YANLib.Core;

public static partial class YANBool
{
    /// <summary>
    /// Generates a random <see cref="bool"/> value.
    /// The method randomly chooses between true and false.
    /// </summary>
    /// <returns>A randomly generated <see cref="bool"/> value.</returns>
    public static bool GenerateRandomBool() => GenerateRandomByte(0, 2) is 1;

    /// <summary>
    /// Generates a collection of random <see cref="bool"/> values of the specified size.
    /// The size is determined by converting the provided object to an unsigned integer. 
    /// If the conversion results in a negative value or <see langword="null"/>, it defaults to 0, resulting in no generated values.
    /// </summary>
    /// <param name="size">The object representing the number of random <see cref="bool"/> values to generate. If <see langword="null"/> or not convertible to a non-negative integer, defaults to a size of 0.</param>
    /// <returns>An enumerable collection of randomly generated <see cref="bool"/> values.</returns>
    public static IEnumerable<bool> GenerateRandomBools(object? size) => Range(0, size.To<uint>().To<int>()).Select(i => GenerateRandomBool());
}
