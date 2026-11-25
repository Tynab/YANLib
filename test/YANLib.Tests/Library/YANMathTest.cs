using System.Numerics;

namespace YANLib.Tests.Library;

public partial class YANMathTest
{
    #region Min

    [Fact]
    public void Min_NullCollection_ReturnsDefault_Math()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Min<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Min_EmptyCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?>();

        // Act
        var result = input.Min<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Min_CollectionWithValues_ReturnsMinValue_Math()
    {
        // Arrange
        var input = new List<int?> { 5, 2, 8, 1, 9 };

        // Act
        int? result = input.Min<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_CollectionWithNullValues_IgnoresNullValues_Math()
    {
        // Arrange
        var input = new List<int?> { 5, null, 8, 1, null };

        // Act
        int? result = input.Min<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_ParamsOverload_ReturnsMinValue_Math()
    {
        // Act
        int? result = YANMath.Min(5, 2, 8, 1, 9);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_CollectionWithMixedTypes_ConvertsTypes_Math()
    {
        // Arrange
        var input = new List<int?> { 5, 2, 8, 1, 9 };

        // Act
        int? result = input.Min<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_AllNullCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?> { null, null };

        // Act
        var result = input.Min<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Min_AllNullNullableCollection_ReturnsNull_Math()
    {
        // pin: a nullable target already returned null in 8.3.3; only non-nullable targets threw
        // Arrange
        IEnumerable<int?> input = [null, null];

        // Act
        var result = YANMath.Min<int?>(input);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Min_DoubleWithNaN_ReturnsNaN_Math()
    {
        // pin: the LINQ ordering of NaN that 8.3.3 had, which MinMax keeps
        // Act
        var result = YANMath.Min(1.0, double.NaN, -1.0);

        // Assert
        Assert.True(double.IsNaN(result));
    }

    #endregion

    #region Max

    [Fact]
    public void Max_NullCollection_ReturnsDefault_Math()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Max<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Max_EmptyCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?>();

        // Act
        var result = input.Max<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Max_CollectionWithValues_ReturnsMaxValue_Math()
    {
        // Arrange
        var input = new List<int?> { 5, 2, 8, 1, 9 };

        // Act
        int? result = input.Max<int>();

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_CollectionWithNullValues_IgnoresNullValues_Math()
    {
        // Arrange
        var input = new List<int?> { 5, null, 8, 1, null };

        // Act
        int? result = input.Max<int>();

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Max_ParamsOverload_ReturnsMaxValue_Math()
    {
        // Act
        int? result = YANMath.Max(5, 2, 8, 1, 9);

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_CollectionWithMixedTypes_ConvertsTypes_Math()
    {
        // Arrange
        var input = new List<int?> { 5, 2, 8, 1, 9 };

        // Act
        int? result = input.Max<int>();

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_AllNullCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?> { null, null };

        // Act
        var result = input.Max<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Max_DoubleWithNaN_IgnoresNaN_Math()
    {
        // pin: the LINQ ordering of NaN that 8.3.3 had, which MinMax keeps
        // Act
        var result = YANMath.Max(double.NaN, 1.0, -1.0);

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Max_DateTimes_KeepMillisecondsAndKind_Math()
    {
        // pin: already correct before area C (the parse fast path returns a DateTime unchanged); guards the native comparison
        // Arrange
        var earlier = new DateTime(2024, 1, 1, 10, 0, 0, 123, DateTimeKind.Utc);
        var later = new DateTime(2024, 1, 1, 10, 0, 0, 456, DateTimeKind.Utc);

        // Act
        var max = YANMath.Max(earlier, later);
        var min = YANMath.Min(later, earlier);

        // Assert
        Assert.Equal(later, max);
        Assert.Equal(DateTimeKind.Utc, max.Kind);
        Assert.Equal(earlier, min);
        Assert.Equal(DateTimeKind.Utc, min.Kind);
    }

    #endregion

    #region Average

    [Fact]
    public void Average_NullCollection_ReturnsDefault_Math()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Average_EmptyCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?>();

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Average_CollectionWithValues_ReturnsAverage_Math()
    {
        // Arrange
        var input = new List<int?> { 2, 4, 6, 8, 10 };

        // Act
        double? result = input.Average<double>();

        // Assert
        Assert.Equal(6.0, result);
    }

    [Fact]
    public void Average_CollectionWithNullValues_IgnoresNullValues_Math()
    {
        // Arrange
        var input = new List<int?> { 2, null, 6, 8, null };

        // Act
        double? result = input.Average<double>();

        // Assert
        Assert.Equal(5.333333333333333, result.Value, 15);
    }

    [Fact]
    public void Average_ParamsOverload_ReturnsAverage_Math()
    {
        // Act
        double? result = YANMath.Average<double>(2, 4, 6, 8, 10);

        // Assert
        Assert.Equal(6.0, result);
    }

    [Fact]
    public void Average_CollectionWithMixedTypes_ConvertsTypes_Math()
    {
        // Arrange
        var input = new List<int?> { 2, 4, 6, 8, 10 };

        // Act
        double? result = input.Average<double>();

        // Assert
        Assert.Equal(6.0, result);
    }

    [Fact]
    public void Average_AllNullCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?> { null, null };

        // Act
        var result = input.Average<int>();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Average_AllNullNullableCollection_ReturnsNull_Math()
    {
        // Arrange
        var input = new List<int?> { null };

        // Act
        var result = input.Average<int?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Average_Int_RoundsHalfToEven_Math()
    {
        // pin: the 8.3.3 rounding of an integer average, which the Int128 path keeps
        // Act
        var twoAndThree = YANMath.Average(2, 3);
        var oneAndTwo = YANMath.Average(1, 2);

        // Assert
        Assert.Equal(2, twoAndThree);
        Assert.Equal(2, oneAndTwo);
    }

    [Fact]
    public void Average_Decimal_KeepsAllDigits_Math()
    {
        // Act
        var result = YANMath.Average(1m, 0m, 0m);

        // Assert
        Assert.Equal(1m / 3m, result);
    }

    [Fact]
    public void Average_DoubleNegativeZero_KeepsSign_Math()
    {
        // pin: the 8.3.3 result, which the typed double path keeps
        // Act
        var result = YANMath.Average(-0.0);

        // Assert
        Assert.True(double.IsNegative(result));
    }

    [Fact]
    public void Average_LazySequences_MatchArrays_Math()
    {
        // pin: the enumerator path must give what the span path gives
        // Arrange
        var ints = Enumerable.Range(1, 1_000).Select(static x => x * 3);
        IEnumerable<long> longs = new HashSet<long> { 9007199254740993, 9007199254740995 };
        var doubles = Enumerable.Range(1, 100).Select(static x => x / 7.0);
        var decimals = Enumerable.Range(1, 100).Select(static x => x / 7m);
        var negativeZero = new[] { -0.0 }.Select(static x => x);

        // Act & Assert
        Assert.Equal(YANMath.Average(ints.ToArray()), YANMath.Average<int>(ints));
        Assert.Equal(9007199254740994L, YANMath.Average<long>(longs));
        Assert.Equal(YANMath.Average(doubles.ToArray()), YANMath.Average<double>(doubles));
        Assert.Equal(YANMath.Average(decimals.ToArray()), YANMath.Average<decimal>(decimals));
        Assert.True(double.IsNegative(YANMath.Average<double>(negativeZero)));
    }

    [Fact]
    public void Average_SequenceEmptyOnSecondEnumeration_ReturnsDefault_Math()
    {
        // Act
        var intResult = YANMath.Average<int>(new OneShot<int>(5, 1, 3));
        var decimalResult = YANMath.Average<decimal>(new OneShot<decimal>(1m));
        var doubleResult = YANMath.Average<double>(new OneShot<double>(1.0));

        // Assert
        Assert.Equal(0, intResult);
        Assert.Equal(0m, decimalResult);
        Assert.Equal(0.0, doubleResult);
    }

    // Before 8.4.0 an overflowing decimal sum fell back to the double average, which is 0 here (the double mean of two decimal.MaxValue
    // values does not convert back to decimal) or lost the small terms.
    [Fact]
    public void Average_DecimalSumOverflows_ReturnsExactMean_Math()
    {
        // Arrange
        const decimal max = decimal.MaxValue;
        var third = 1m / 3m;

        // Act & Assert: typed span path (array, params, List<T>) and enumerator path
        Assert.Equal(max, YANMath.Average(max, max));
        Assert.Equal(max, YANMath.Average<decimal>(new[] { max, max, max }));
        Assert.Equal(third, YANMath.Average<decimal>(new List<decimal> { max, 1m, -max }));
        Assert.Equal(third, YANMath.Average<decimal>(new[] { max, 1m, -max }.Select(static x => x)));
        Assert.Equal(max - 1, YANMath.Average<decimal>(new HashSet<decimal> { max, max - 1, max - 2 }));
        Assert.Equal(-max, YANMath.Average(-max, -max));

        // object path: nullable and boxed elements, the non-generic overload and an integer result computed in decimal
        Assert.Equal(max, YANMath.Average<decimal?>(max, null, max));
        Assert.Equal(max, YANMath.Average<decimal>(new object?[] { max, "79228162514264337593543950335", null }));
        Assert.Equal(max, new System.Collections.ArrayList { max, max }.Average<decimal>());
        Assert.Equal(1L, YANMath.Average<long>(new object?[] { max, 3m, -max }));
        Assert.Equal(1, YANMath.Average<int?>(new object?[] { max, 3, -max }));
    }

    [Fact]
    public void Average_DecimalSumOverflows_RoundsHalfToEven_Math()
    {
        // Arrange (the means are 79228162514264337593543950334.5 and ...333.5: no decimal place is left, so they round to even)
        const decimal max = decimal.MaxValue;

        // Act
        var down = YANMath.Average(max, max - 1);
        var up = YANMath.Average(max, max - 3);
        var negative = YANMath.Average(-max, -(max - 1));
        var objectPath = YANMath.Average<decimal?>(max, max - 3);

        // Assert
        Assert.Equal(79228162514264337593543950334m, down);
        Assert.Equal(79228162514264337593543950334m, up);
        Assert.Equal(-79228162514264337593543950334m, negative);
        Assert.Equal(79228162514264337593543950334m, objectPath);
    }

    [Fact]
    public void Average_DecimalSumOverflowsToZeroMean_IsPositiveZero_Math()
    {
        // Arrange
        const decimal max = decimal.MaxValue;

        // Act
        var typed = YANMath.Average(max, max, -max, -max);
        var boxed = YANMath.Average<decimal>(new object?[] { -max, -max, max, max });

        // Assert
        Assert.Equal(0m, typed);
        Assert.False(decimal.IsNegative(typed));
        Assert.Equal(0m, boxed);
        Assert.False(decimal.IsNegative(boxed));
    }

    [Fact]
    public void Average_DecimalOverflowThenFailedConversion_KeepsDoubleFallback_Math()
    {
        // pin: a value without a decimal equivalent (NaN) still sends the object path to the 8.3.3 double average, also after an overflow
        // Arrange
        const decimal max = decimal.MaxValue;

        // Act
        var nanLast = YANMath.Average<decimal>(new object?[] { max, max, double.NaN });
        var nanFirst = YANMath.Average<decimal>(new object?[] { double.NaN, max, max });
        var convertible = YANMath.Average<decimal>(new object?[] { max, max, 1e20 });

        // Assert (a double that converts to decimal after the overflow keeps the exact path: (2 * max + 1e20) / 3)
        Assert.Equal(0m, nanLast);
        Assert.Equal(0m, nanFirst);
        Assert.Equal(52818775042842891729029300223m, convertible);
    }

    [Fact]
    public void Average_DecimalSumOverflows_EnumeratesSequenceOnceMore_Math()
    {
        // pin of the documented counts: the emptiness check and the decimal pass start an iterator source twice, as 8.3.3 (which computed
        // only in double) did; an overflow adds a third, exact pass, and an object element without a decimal value one more, double pass
        // Arrange
        const decimal max = decimal.MaxValue;
        var plain = new CountingSequence<decimal>(1m, 2m, 3m);
        var typed = new CountingSequence<decimal>(max, max, 1m);
        var nullable = new CountingSequence<decimal?>(max, null, max);
        var boxed = new CountingSequence<object?>(max, max, 1m);
        var nonGeneric = new CountingSequence<decimal>(max, max, 1m);
        var integer = new CountingSequence<object?>(max, 3m, -max);
        var nanAfterOverflow = new CountingSequence<object?>(max, max, double.NaN);
        var nanFirst = new CountingSequence<object?>(double.NaN, max, max);

        // Act
        var plainResult = YANMath.Average<decimal>(plain);
        var typedResult = YANMath.Average<decimal>(typed);
        var nullableResult = YANMath.Average<decimal?>(nullable);
        var boxedResult = YANMath.Average<decimal>(boxed);
        var nonGenericResult = ((System.Collections.IEnumerable)nonGeneric).Average<decimal>();
        var integerResult = YANMath.Average<long>(integer);
        var nanResult = YANMath.Average<decimal>(nanAfterOverflow);
        var nanFirstResult = YANMath.Average<decimal>(nanFirst);

        // Assert
        Assert.Equal((2m, 2), (plainResult, plain.Enumerations));
        Assert.Equal(3, typed.Enumerations);
        Assert.Equal((max, 3), (nullableResult, nullable.Enumerations));
        Assert.Equal(3, boxed.Enumerations);
        Assert.Equal((typedResult, 3), (nonGenericResult, nonGeneric.Enumerations));
        Assert.Equal(boxedResult, typedResult);
        Assert.Equal((1L, 3), (integerResult, integer.Enumerations));
        Assert.Equal((0m, 4), (nanResult, nanAfterOverflow.Enumerations));
        Assert.Equal((0m, 3), (nanFirstResult, nanFirst.Enumerations));
    }

    [Fact]
    public void Sum_DecimalPassFails_EnumeratesSequenceThreeTimes_Math()
    {
        // pin of the documented counts: with an integer or decimal result, a failed decimal pass (an object element without a decimal value,
        // an overflow) is followed by the double pass that gives the result, as in 8.3.3, so an iterator source is started three times (8.3.3:
        // twice); an Average over only nulls takes the same three passes, also in the typed overloads with any nullable integer or decimal
        // result; with a double result both start it twice, and an Average with a float result too
        // Arrange
        const decimal max = decimal.MaxValue;
        var nan = new CountingSequence<object?>(1, double.NaN, 2);
        var infinity = new CountingSequence<object?>(1, double.NegativeInfinity);
        var outOfRange = new CountingSequence<object?>(1, 1e30);
        var nonGeneric = new CountingSequence<object?>(1, double.NaN, 2);
        var boxedOverflow = new CountingSequence<object?>(max, max);
        var typedOverflow = new CountingSequence<decimal>(max, max);
        var nullableOverflow = new CountingSequence<decimal?>(max, null, max);
        var doubleSum = new CountingSequence<object?>(1, double.NaN, 2);
        var allNull = new CountingSequence<object?>(null, null);
        var typedAllNull = new CountingSequence<int?>(null, null);
        var typedLongAllNull = new CountingSequence<long?>(null, null);
        var typedNintAllNull = new CountingSequence<nint?>(null, null);
        var typedFloatAllNull = new CountingSequence<float?>(null, null);
        var doubleAllNull = new CountingSequence<object?>(null, null);

        // Act
        var nanResult = YANMath.Sum<int>(nan);
        var infinityResult = YANMath.Sum<decimal?>(infinity);
        var outOfRangeResult = YANMath.Sum<long>(outOfRange);
        var nonGenericResult = ((System.Collections.IEnumerable)nonGeneric).Sum<long>();
        var boxedOverflowResult = YANMath.Sum<decimal>(boxedOverflow);
        var typedOverflowResult = YANMath.Sum<decimal>(typedOverflow);
        var nullableOverflowResult = YANMath.Sum<decimal?>(nullableOverflow);
        var doubleSumResult = YANMath.Sum<double>(doubleSum);
        var allNullResult = YANMath.Average<decimal>(allNull);
        var typedAllNullResult = YANMath.Average<int?>(typedAllNull);
        var typedLongAllNullResult = YANMath.Average<long?>(typedLongAllNull);
        var typedNintAllNullResult = YANMath.Average<nint?>(typedNintAllNull);
        var typedFloatAllNullResult = YANMath.Average<float?>(typedFloatAllNull);
        var doubleAllNullResult = YANMath.Average<double>(doubleAllNull);

        // Assert
        Assert.Equal((0, 3), (nanResult, nan.Enumerations));
        Assert.Equal(((decimal?)null, 3), (infinityResult, infinity.Enumerations));
        Assert.Equal((0L, 3), (outOfRangeResult, outOfRange.Enumerations));
        Assert.Equal((0L, 3), (nonGenericResult, nonGeneric.Enumerations));
        Assert.Equal((0m, 3), (boxedOverflowResult, boxedOverflow.Enumerations));
        Assert.Equal((0m, 3), (typedOverflowResult, typedOverflow.Enumerations));
        Assert.Equal(((decimal?)null, 3), (nullableOverflowResult, nullableOverflow.Enumerations));
        Assert.Equal((double.NaN, 2), (doubleSumResult, doubleSum.Enumerations));
        Assert.Equal((0m, 3), (allNullResult, allNull.Enumerations));
        Assert.Equal(((int?)null, 3), (typedAllNullResult, typedAllNull.Enumerations));
        Assert.Equal(((long?)null, 3), (typedLongAllNullResult, typedLongAllNull.Enumerations));
        Assert.Equal(((nint?)null, 3), (typedNintAllNullResult, typedNintAllNull.Enumerations));
        Assert.Equal(((float?)null, 2), (typedFloatAllNullResult, typedFloatAllNull.Enumerations));
        Assert.Equal((0d, 2), (doubleAllNullResult, doubleAllNull.Enumerations));
    }

    [Fact]
    public void Average_DecimalSumOverflows_MatchesExactOracle_Math()
    {
        // Arrange: seeded inputs whose decimal sum overflows, with values of every scale
        var random = new Random(20261125);

        for (var round = 0; round < 300; round++)
        {
            var count = random.Next(2, 9);
            var values = new decimal[count];

            for (var i = 0; i < count; i++)
            {
                var scale = (byte)(i == 0 ? 0 : random.Next(0, 29));
                var high = i == 0 ? (int)(0xC0000000u | (uint)random.Next()) : random.Next();
                values[i] = new decimal(random.Next(), random.Next(), high, random.Next(4) == 0, scale);
            }

            values[0] = decimal.Abs(values[0]);
            values[1] = new decimal(-1, -1, -1 - random.Next(16), false, 0);

            // Act & Assert
            AssertEveryAveragePath(values, ExactMean(values));
        }
    }

    // decimal.MaxValue + 0.4m is decimal.MaxValue: the decimal running sum can round before it overflows, so the exact sum cannot start from
    // it. Before this was fixed, only arrays and List<T> added every element exactly; the other paths lost what the rounding dropped.
    [Fact]
    public void Average_DecimalSumRoundsBeforeOverflow_ReturnsExactMeanOnEveryPath_Math()
    {
        // Arrange
        const decimal max = decimal.MaxValue;
        decimal[] fractionLost = [max, 0.4m, max, 4m];
        decimal[] cancelled = [max, .. Enumerable.Repeat(0.4m, 10), max, -max, -max, 4m];

        // Act & Assert: (2 * max + 4.4) / 4 = 39614081257132168796771975168.6 rounds to ...169, and 8 / 15
        AssertEveryAveragePath(fractionLost, 39614081257132168796771975169m);
        AssertEveryAveragePath(cancelled, 8m / 15m);
        Assert.Equal(1L, YANMath.Average<long>(cancelled.Cast<object?>().ToArray()));
    }

    [Fact]
    public void Average_DecimalSumRoundsBeforeOverflow_MatchesExactOracleOnEveryPath_Math()
    {
        // Arrange: seeded inputs whose decimal sum rounds before it overflows: a large whole value, fractions that a sum of that size cannot
        // hold, a value near decimal.MaxValue that overflows the sum, mostly two values that nearly cancel the first and the third (so the
        // dropped fractions matter), then more fractions
        var random = new Random(20261126);

        for (var round = 0; round < 300; round++)
        {
            var large = new decimal(random.Next(), random.Next(), (int)(0xC0000000u | (uint)random.Next()), false, 0);
            var nearMax = new decimal(-1, -1, -1 - random.Next(16), false, 0);
            var values = new List<decimal> { large };

            AddFractions(values, random, random.Next(1, 5));
            values.Add(nearMax);

            if (random.Next(4) != 0)
            {
                values.Add(-large + random.Next(-3, 4));
                values.Add(-nearMax + random.Next(0, 4));
            }

            AddFractions(values, random, random.Next(0, 4));

            // Act & Assert
            AssertEveryAveragePath([.. values], ExactMean(values));
        }

        static void AddFractions(List<decimal> values, Random random, int count)
        {
            for (var i = 0; i < count; i++)
            {
                values.Add(new decimal(random.Next(), random.Next(), random.Next(1 << 20), random.Next(2) == 0, (byte)random.Next(1, 29)));
            }
        }
    }

    [Fact]
    public void Sum_DecimalOverflow_KeepsDocumentedResult_Math()
    {
        // pin: Sum keeps its overflow semantics (the double fallback), only Average became exact
        // Act
        var sum = YANMath.Sum(decimal.MaxValue, decimal.MaxValue);
        var objectSum = YANMath.Sum<decimal?>(decimal.MaxValue, decimal.MaxValue);

        // Assert
        Assert.Equal(0m, sum);
        Assert.Null(objectSum);
    }

    /// <summary>
    /// Asserts that every Average overload with a <see cref="decimal"/> result gives the bits of <paramref name="expected"/> for
    /// <paramref name="values"/>: the span paths, the enumerator path, and the object paths (nullable, boxed, non-generic).
    /// </summary>
    private static void AssertEveryAveragePath(decimal[] values, decimal expected)
    {
        var results = new (string Path, decimal? Result)[]
        {
            ("decimal[]", YANMath.Average(values)),
            ("List<decimal>", YANMath.Average<decimal>(values.ToList())),
            ("Select", YANMath.Average<decimal>(values.Select(static x => x))),
            ("ReadOnlyCollection", YANMath.Average<decimal>(new System.Collections.ObjectModel.ReadOnlyCollection<decimal>(values))),
            ("decimal?[]", YANMath.Average<decimal?>(values.Select(static x => (decimal?)x).ToArray())),
            ("object[]", YANMath.Average<decimal>(values.Cast<object?>().ToArray())),
            ("ArrayList", new System.Collections.ArrayList(values).Average<decimal>())
        };

        foreach (var (path, result) in results)
        {
            Assert.True(result.HasValue && decimal.GetBits(expected).SequenceEqual(decimal.GetBits(result.Value)), $"{path} [{string.Join(", ", values)}]: {result} != {expected}");
        }
    }

    /// <summary>
    /// The mean of <paramref name="values"/> as <see cref="decimal"/> division would give it if the sum fitted: the exact rational mean,
    /// rounded half to even at the largest scale (up to 28) whose mantissa fits in 96 bits, without trailing zeros.
    /// </summary>
    private static decimal ExactMean(IReadOnlyList<decimal> values)
    {
        var numerator = BigInteger.Zero;

        foreach (var value in values)
        {
            var bits = decimal.GetBits(value);
            var mantissa = (new BigInteger((uint)bits[2]) << 64) + (new BigInteger((uint)bits[1]) << 32) + new BigInteger((uint)bits[0]);
            var term = mantissa * BigInteger.Pow(10, 28 - ((bits[3] >> 16) & 0xFF));

            numerator += bits[3] < 0 ? -term : term;
        }

        var denominator = values.Count * BigInteger.Pow(10, 28);

        for (var scale = 28; scale >= 0; scale--)
        {
            var scaled = BigInteger.Abs(numerator) * BigInteger.Pow(10, scale);
            var quotient = BigInteger.DivRem(scaled, denominator, out var remainder);
            var comparison = (remainder * 2).CompareTo(denominator);

            if (comparison > 0 || comparison == 0 && !quotient.IsEven)
            {
                quotient++;
            }

            if (quotient.GetBitLength() <= 96)
            {
                var bytes = quotient.ToByteArray(isUnsigned: true, isBigEndian: false);

                Array.Resize(ref bytes, 12);

                var result = new decimal(BitConverter.ToInt32(bytes, 0), BitConverter.ToInt32(bytes, 4), BitConverter.ToInt32(bytes, 8), numerator.Sign < 0 && !quotient.IsZero, (byte)scale);

                return result / 1.0000000000000000000000000000m;
            }
        }

        throw new OverflowException("The mean does not fit decimal.");
    }

    #endregion

    #region Sum

    [Fact]
    public void Sum_NullCollection_ReturnsDefault_Math()
    {
        // Arrange
        IEnumerable<int?>? input = null;

        // Act
        var result = input.Sum<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sum_EmptyCollection_ReturnsDefault_Math()
    {
        // Arrange
        var input = new List<int?>();

        // Act
        var result = input.Sum<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sum_CollectionWithValues_ReturnsSum_Math()
    {
        // Arrange
        var input = new List<int?> { 2, 4, 6, 8, 10 };

        // Act
        int? result = input.Sum<int>();

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void Sum_CollectionWithNullValues_IgnoresNullValues_Math()
    {
        // Arrange
        var input = new List<int?> { 2, null, 6, 8, null };

        // Act
        int? result = input.Sum<int>();

        // Assert
        Assert.Equal(16, result);
    }

    [Fact]
    public void Sum_ParamsOverload_ReturnsSum_Math()
    {
        // Act
        int? result = YANMath.Sum(2, 4, 6, 8, 10);

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void Sum_CollectionWithMixedTypes_ConvertsTypes_Math()
    {
        // Arrange
        var input = new List<int?> { 2, 4, 6, 8, 10 };

        // Act
        int? result = input.Sum<int>();

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void Sum_LongAboveTwoToThe53_IsExact_Math()
    {
        // Act
        var result = YANMath.Sum(new long[] { 9007199254740993, 0 });

        // Assert
        Assert.Equal(9007199254740993, result);
    }

    [Fact]
    public void Sum_LongNearMaxValue_IsExact_Math()
    {
        // Act
        var result = YANMath.Sum(long.MaxValue, long.MaxValue, long.MinValue);

        // Assert
        Assert.Equal(long.MaxValue - 1, result);
    }

    [Fact]
    public void Sum_Decimal_HasNoTrailingZeros_Math()
    {
        // pin: 8.3.3 results had no trailing zeros, and decimal results keep that
        // Act
        var result = YANMath.Sum(1.10m, 2.20m);

        // Assert
        Assert.Equal("3.3", result.ToString(System.Globalization.CultureInfo.InvariantCulture));
    }

    [Fact]
    public void Sum_DecimalOverflow_FallsBackToDouble_Math()
    {
        // pin: the 8.3.3 result on decimal overflow, which the fallback keeps
        // Act
        var result = YANMath.Sum(decimal.MaxValue, decimal.MaxValue, decimal.MinValue);

        // Assert
        Assert.Equal(0m, result);
    }

    [Fact]
    public void Sum_IntOverflow_ReturnsDefault_Math()
    {
        // pin: the documented overflow result (default), unchanged on purpose
        // Act
        var result = YANMath.Sum(Enumerable.Range(0, 100_000).ToArray());
        var nullableResult = YANMath.Sum<int?>(int.MaxValue, 1);

        // Assert
        Assert.Equal(0, result);
        Assert.Null(nullableResult);
    }

    [Fact]
    public void Sum_Float_IsComputedInDouble_Math()
    {
        // pin: float sums stay in double, as in 8.3.3
        // Act
        var result = YANMath.Sum(0.1f, 0.2f, 0.3f);

        // Assert
        Assert.Equal((float)((double)0.1f + 0.2f + 0.3f), result);
    }

    [Fact]
    public void Sum_LazySequences_MatchArrays_Math()
    {
        // Arrange
        var ints = Enumerable.Range(1, 1_000).Select(static x => x * 3);
        IEnumerable<long> longs = new HashSet<long> { 9007199254740993, 1, 2 };
        var doubles = Enumerable.Range(1, 100).Select(static x => x / 7.0);
        var decimals = Enumerable.Range(1, 100).Select(static x => x / 7m);
        var decimalOverflow = new[] { decimal.MaxValue, decimal.MaxValue, decimal.MinValue }.Select(static x => x);

        // Act & Assert
        Assert.Equal(YANMath.Sum(ints.ToArray()), YANMath.Sum<int>(ints));
        Assert.Equal(9007199254740996L, YANMath.Sum<long>(longs));
        Assert.Equal(YANMath.Sum(doubles.ToArray()), YANMath.Sum<double>(doubles));
        Assert.Equal(YANMath.Sum(decimals.ToArray()), YANMath.Sum<decimal>(decimals));
        Assert.Equal(0, YANMath.Sum<int>(Enumerable.Range(0, 100_000)));
        Assert.Equal(0m, YANMath.Sum<decimal>(decimalOverflow));
    }

    [Fact]
    public void Sum_ListSubclassWithOwnEnumerator_FollowsTheEnumerator_Math()
    {
        // Arrange
        IEnumerable<int> input = new FilteredList { 5, -100, 3 };

        // Act
        var sum = YANMath.Sum<int>(input);
        var average = YANMath.Average<int>(input);
        var min = YANMath.Min<int>(input);

        // Assert
        Assert.Equal(8, sum);
        Assert.Equal(4, average);
        Assert.Equal(3, min);
    }

    #endregion

    #region Truncate

    [Fact]
    public void Truncate_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Truncate<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Truncate_PositiveDecimal_ReturnsTruncatedValue_Math()
    {
        // Arrange
        double? input = 3.75;

        // Act
        double? result = input.Truncate<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Truncate_NegativeDecimal_ReturnsTruncatedValue_Math()
    {
        // Arrange
        double? input = -3.75;

        // Act
        double? result = input.Truncate<double>();

        // Assert
        Assert.Equal(-3.0, result);
    }

    [Fact]
    public void Truncate_StringValue_ConvertsAndTruncates_Math()
    {
        // Arrange
        var input = "3.75";

        // Act
        double? result = input.Truncate<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Truncate_LongAboveTwoToThe53_IsExact_Math()
    {
        // Act
        var result = 9007199254740993L.Truncate();

        // Assert
        Assert.Equal(9007199254740993L, result);
    }

    #endregion

    #region Ceiling

    [Fact]
    public void Ceiling_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Ceiling<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Ceiling_PositiveDecimal_ReturnsCeilingValue_Math()
    {
        // Arrange
        double? input = 3.75;

        // Act
        double? result = input.Ceiling<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Ceiling_NegativeDecimal_ReturnsCeilingValue_Math()
    {
        // Arrange
        double? input = -3.75;

        // Act
        double? result = input.Ceiling<double>();

        // Assert
        Assert.Equal(-3.0, result);
    }

    [Fact]
    public void Ceiling_StringValue_ConvertsAndCeils_Math()
    {
        // Arrange
        var input = "3.75";

        // Act
        double? result = input.Ceiling<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    #endregion

    #region Floor

    [Fact]
    public void Floor_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Floor<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Floor_PositiveDecimal_ReturnsFloorValue_Math()
    {
        // Arrange
        double? input = 3.75;

        // Act
        double? result = input.Floor<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Floor_NegativeDecimal_ReturnsFloorValue_Math()
    {
        // Arrange
        double? input = -3.75;

        // Act
        double? result = input.Floor<double>();

        // Assert
        Assert.Equal(-4.0, result);
    }

    [Fact]
    public void Floor_StringValue_ConvertsAndFloors_Math()
    {
        // Arrange
        var input = "3.75";

        // Act
        double? result = input.Floor<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    #endregion

    #region Round

    [Fact]
    public void Round_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Round<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Round_PositiveDecimalNoDigits_ReturnsRoundedValue_Math()
    {
        // Arrange
        double? input = 3.75;

        // Act
        double? result = input.Round<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Round_NegativeDecimalNoDigits_ReturnsRoundedValue_Math()
    {
        // Arrange
        double? input = -3.75;

        // Act
        double? result = input.Round<double>();

        // Assert
        Assert.Equal(-4.0, result);
    }

    [Fact]
    public void Round_PositiveDecimalWithDigits_ReturnsRoundedValue_Math()
    {
        // Arrange
        double? input = 3.14159;

        // Act
        double? result = input.Round<double>(2);

        // Assert
        Assert.Equal(3.14, result);
    }

    [Fact]
    public void Round_WithMidpointRoundingToEven_ReturnsRoundedValue_Math()
    {
        // Arrange
        double? input = 2.5;

        // Act
        double? result = input.Round<double>(0, MidpointRounding.ToEven);

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Round_StringValue_ConvertsAndRounds_Math()
    {
        // Arrange
        var input = "3.75";

        // Act
        double? result = input.Round<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Round_DecimalMidpoint_RoundsTheDecimalValue_Math()
    {
        // Act
        var result = 1.005m.Round(2);

        // Assert
        Assert.Equal(1.01m, result);
    }

    [Fact]
    public void Round_DecimalToPositiveInfinity_KeepsExactValue_Math()
    {
        // Act
        var result = 1.10m.Round(2, MidpointRounding.ToPositiveInfinity);

        // Assert
        Assert.Equal(1.1m, result);
    }

    [Fact]
    public void Round_LongMaxValue_ReturnsInput_Math()
    {
        // Act
        var result = long.MaxValue.Round(2);

        // Assert
        Assert.Equal(long.MaxValue, result);
    }

    [Fact]
    public void Round_NegativeDigits_Throws_Math()
    {
        // pin: the 8.3.3 exception, which the decimal path keeps
        // Act & Assert
        _ = Assert.Throws<ArgumentOutOfRangeException>(static () => 5m.Round(-1));
        _ = Assert.Throws<ArgumentOutOfRangeException>(static () => 5.Round(-1));
    }

    [Fact]
    public void Round_DoubleMoreThan15Digits_RoundsAsDecimal_Math()
    {
        // Act
        var tiny = 1e-16.Round(20);
        var half = 1.5.Round(16);
        var sum = (0.1 + 0.2).Round(17);
        var cut = (0.1 + 0.2).Round(16);
        var belowDecimalScale = 1e-30.Round(20);
        var seventeenDigits = 30490906.876740474.Round(20);
        var negativeZero = (-0.0).Round(20);

        // Assert
        Assert.Equal(30490906.876740474, seventeenDigits);
        Assert.True(double.IsNegative(negativeZero));
        Assert.Equal(1e-16, tiny);
        Assert.Equal(1.5, half);
        Assert.Equal(0.30000000000000004, sum);
        Assert.Equal(0.3, cut);
        Assert.Equal(0.0, belowDecimalScale);
    }

    [Fact]
    public void Round_DoubleMoreThan15DigitsOutsideDecimalRange_RoundsTo15Digits_Math()
    {
        // Act
        var huge = 1e300.Round(20);
        var notANumber = double.NaN.Round(16);

        // Assert
        Assert.Equal(1e300, huge);
        Assert.True(double.IsNaN(notANumber));
    }

    [Fact]
    public void Round_DoubleMoreThan28DecimalPlaces_RoundsExactlyOnShortestText_Math()
    {
        // the shortest text of this double has 29 decimal places, more than decimal holds: digit-shift rounding is exact at any number of
        // digits (until 8.4.0 development it was rounded to 28 places first and returned 2E-13 for 20 digits ToZero)
        // Act
        var result = 1.9999999999999998e-13.Round(20, MidpointRounding.ToZero);
        var twentyEight = 1.9999999999999998e-13.Round(28, MidpointRounding.ToZero);
        var beyondTheText = 1.9999999999999998e-13.Round(30, MidpointRounding.ToZero);
        var thousand = 1.9999999999999998e-13.Round(1000);
        var directed = 4.4444444444444444e-13.Round(28, MidpointRounding.ToPositiveInfinity);
        var negative = (-1.9999999999999998e-13).Round(20, MidpointRounding.ToNegativeInfinity);
        var fifteenDigits = 1.9999999999999998e-13.Round(15, MidpointRounding.ToZero);

        // Assert
        Assert.Equal(1.9999999e-13, result);
        Assert.Equal(1.999999999999999e-13, twentyEight);
        Assert.Equal(1.9999999999999998e-13, beyondTheText);
        Assert.Equal(1.9999999999999998e-13, thousand);
        Assert.Equal(4.444444444444445e-13, directed);
        Assert.Equal(-2e-13, negative);
        Assert.Equal(1.99e-13, fifteenDigits);
    }

    [Fact]
    public void Round_DoubleMoreThan28DecimalPlaces_DecidesTiesOnShortestText_Math()
    {
        // 3.5e-28 is 3.49999...e-28 in binary and 2.5e-28 is 2.50000...1e-28: the ties are decided on the text, as decimal decides them
        // Act
        var awayFromZero = 3.5e-28.Round(28);
        var toEven = 2.5e-28.Round(28, MidpointRounding.ToEven);
        var negativeToEven = (-3.5e-28).Round(28, MidpointRounding.ToEven);

        // Assert
        Assert.Equal(4e-28, awayFromZero);
        Assert.Equal(2e-28, toEven);
        Assert.Equal(-4e-28, negativeToEven);
    }

    [Fact]
    public void Round_TinyDoubleDirected_KeepsTheStep_Math()
    {
        // Act
        var up = 1e-30.Round(20, MidpointRounding.ToPositiveInfinity);
        var down = (-1e-30).Round(20, MidpointRounding.ToNegativeInfinity);
        var nearest = 1e-30.Round(20);
        var exact = 1e-30.Round(30);
        var smallest = double.Epsilon.Round(16, MidpointRounding.ToPositiveInfinity);
        var negativeSmallest = (-double.Epsilon).Round(16, MidpointRounding.ToPositiveInfinity);
        var tiny = 1e-300.Round(20, MidpointRounding.ToNegativeInfinity);
        var single = 1e-30f.Round(30);

        // Assert
        Assert.Equal(1e-20, up);
        Assert.Equal(-1e-20, down);
        Assert.Equal(0.0, nearest);
        Assert.Equal(1e-30, exact);
        Assert.Equal(1e-16, smallest);
        Assert.True(negativeSmallest == 0 && double.IsNegative(negativeSmallest));
        Assert.Equal(0.0, tiny);
        Assert.Equal(1e-30f, single);
    }

    [Fact]
    public void Rounds_DoubleMoreThan28DecimalPlaces_RoundsExactly_Math()
    {
        // Act
        var array = new[] { 1.9999999999999998e-13, -1e-30 }.Rounds(20, MidpointRounding.ToZero);
        var nullable = new double?[] { 1.9999999999999998e-13, null }.Rounds(20, MidpointRounding.ToZero);
        var nonGeneric = new System.Collections.ArrayList { 1.9999999999999998e-13 }.Rounds<double>(20, MidpointRounding.ToZero);

        // Assert
        Assert.Equal([1.9999999e-13, -0.0], array!);
        Assert.Equal([1.9999999e-13, null], nullable!);
        Assert.Equal([1.9999999e-13], nonGeneric!);
    }

    [Fact]
    public void Round_DecimalAndIntegerMoreThan15Digits_DoNotThrow_Math()
    {
        // Act
        var decimalResult = 1.23456789012345678m.Round(16);
        var cappedResult = 1.23456789012345678m.Round(40);
        var integerResult = 5.Round(20);

        // Assert
        Assert.Equal(1.2345678901234568m, decimalResult);
        Assert.Equal(1.23456789012345678m, cappedResult);
        Assert.Equal(5, integerResult);
    }

    #endregion

    #region Sqrt

    [Fact]
    public void Sqrt_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Sqrt<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sqrt_PositiveValue_ReturnsSqrtValue_Math()
    {
        // Arrange
        double? input = 16.0;

        // Act
        double? result = input.Sqrt<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Sqrt_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Sqrt<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Sqrt_StringValue_ConvertsAndCalculatesSqrt_Math()
    {
        // Arrange
        var input = "16.0";

        // Act
        double? result = input.Sqrt<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    #endregion

    #region Pow

    [Fact]
    public void Pow_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Pow<double>(2);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Pow_NullPower_ReturnsDefault_Math()
    {
        // Arrange
        double? input = 2.0;

        // Act
        var result = input.Pow<double>(null);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Pow_PositiveValueAndPower_ReturnsPowValue_Math()
    {
        // Arrange
        double? input = 2.0;

        // Act
        double? result = input.Pow<double>(3);

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void Pow_ZeroValuePositivePower_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Pow<double>(3);

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Pow_StringValueAndPower_ConvertsAndCalculatesPow_Math()
    {
        // Arrange
        var input = "2.0";

        // Act
        double? result = input.Pow<double>(3);

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void Pow_IntResultOutOfRange_ReturnsZero_Math()
    {
        // Arrange
        var input = 100_000;

        // Act (8.3.3 crashed the process with a stack overflow; overflow semantics are an open decision)
        var result = input.Pow(2);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Pow_LongWholeExponent_IsExact_Math()
    {
        // Act
        var result = 3L.Pow(39);

        // Assert
        Assert.Equal(4052555153018976267L, result);
    }

    [Fact]
    public void Pow_DecimalNegativeExponent_IsExact_Math()
    {
        // Act
        var result = 3m.Pow(-1);

        // Assert
        Assert.Equal(1m / 3m, result);
    }

    [Fact]
    public void Pow_IntOverflow_ReturnsDefault_Math()
    {
        // pin: the 8.3.3 overflow result (default), which the Int128 path keeps
        // Act
        var result = 100000.Pow(2);
        var negativeExponent = 2.Pow(-1);

        // Assert
        Assert.Equal(0, result);
        Assert.Equal(0, negativeExponent);
    }

    #endregion

    #region Abs

    [Fact]
    public void Abs_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Abs<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Abs_PositiveValue_ReturnsSameValue_Math()
    {
        // Arrange
        double? input = 5.0;

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Abs_NegativeValue_ReturnsPositiveValue_Math()
    {
        // Arrange
        double? input = -5.0;

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Abs_IntMinValue_ReturnsZero_Math()
    {
        // Arrange
        var input = int.MinValue;

        // Act (8.3.3 crashed the process with a stack overflow; overflow semantics are an open decision)
        var result = input.Abs();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Abs_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Abs_StringValue_ConvertsAndCalculatesAbs_Math()
    {
        // Arrange
        var input = "-5.0";

        // Act
        double? result = input.Abs<double>();

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Abs_LongAboveTwoToThe53_IsExact_Math()
    {
        // Act
        var result = (-9007199254740993L).Abs();

        // Assert
        Assert.Equal(9007199254740993L, result);
    }

    [Fact]
    public void Abs_IntMinValue_ReturnsDefault_Math()
    {
        // pin: the 8.3.3 overflow result (default), which the Int128 path keeps
        // Act
        var result = int.MinValue.Abs();
        var nullableResult = ((int?)int.MinValue).Abs();

        // Assert
        Assert.Equal(0, result);
        Assert.Null(nullableResult);
    }

    #endregion

    #region Sin

    [Fact]
    public void Sin_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Sin<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sin_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Sin<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Sin_PiHalfValue_ReturnsOne_Math()
    {
        // Arrange
        double? input = Math.PI / 2;

        // Act
        double? result = input.Sin<double>();

        // Assert
        Assert.Equal(1.0, result.Value, 15);
    }

    [Fact]
    public void Sin_StringValue_ConvertsAndCalculatesSin_Math()
    {
        // Arrange
        var input = "1.5707963267948966";

        // Act
        double? result = input.Sin<double>();

        // Assert
        Assert.Equal(1.0, result.Value, 15);
    }

    #endregion

    #region Cos

    [Fact]
    public void Cos_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Cos<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Cos_ZeroValue_ReturnsOne_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Cos<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Cos_PiValue_ReturnsMinusOne_Math()
    {
        // Arrange
        double? input = Math.PI;

        // Act
        double? result = input.Cos<double>();

        // Assert
        Assert.Equal(-1.0, result.Value, 15);
    }

    [Fact]
    public void Cos_StringValue_ConvertsAndCalculatesCos_Math()
    {
        // Arrange
        var input = "3.141592653589793";

        // Act
        double? result = input.Cos<double>();

        // Assert
        Assert.Equal(-1.0, result.Value, 15);
    }

    #endregion

    #region Tan

    [Fact]
    public void Tan_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Tan<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Tan_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Tan<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Tan_PiQuarterValue_ReturnsOne_Math()
    {
        // Arrange
        double? input = Math.PI / 4;

        // Act
        double? result = input.Tan<double>();

        // Assert
        Assert.Equal(1.0, result.Value, 15);
    }

    [Fact]
    public void Tan_StringValue_ConvertsAndCalculatesTan_Math()
    {
        // Arrange
        var input = "0.7853981633974483";

        // Act
        double? result = input.Tan<double>();

        // Assert
        Assert.Equal(1.0, result.Value, 15);
    }

    #endregion

    #region Asin

    [Fact]
    public void Asin_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Asin<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Asin_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Asin<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Asin_OneValue_ReturnsPiHalf_Math()
    {
        // Arrange
        double? input = 1.0;

        // Act
        double? result = input.Asin<double>();

        // Assert
        Assert.Equal(Math.PI / 2, result);
    }

    [Fact]
    public void Asin_StringValue_ConvertsAndCalculatesAsin_Math()
    {
        // Arrange
        var input = "1.0";

        // Act
        double? result = input.Asin<double>();

        // Assert
        Assert.Equal(Math.PI / 2, result);
    }

    #endregion

    #region Acos

    [Fact]
    public void Acos_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Acos<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Acos_OneValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 1.0;

        // Act
        double? result = input.Acos<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Acos_MinusOneValue_ReturnsPi_Math()
    {
        // Arrange
        double? input = -1.0;

        // Act
        double? result = input.Acos<double>();

        // Assert
        Assert.Equal(Math.PI, result);
    }

    [Fact]
    public void Acos_StringValue_ConvertsAndCalculatesAcos_Math()
    {
        // Arrange
        var input = "-1.0";

        // Act
        double? result = input.Acos<double>();

        // Assert
        Assert.Equal(Math.PI, result);
    }

    #endregion

    #region Atan

    [Fact]
    public void Atan_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Atan<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Atan_ZeroValue_ReturnsZero_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Atan<double>();

        // Assert
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void Atan_OneValue_ReturnsPiQuarter_Math()
    {
        // Arrange
        double? input = 1.0;

        // Act
        double? result = input.Atan<double>();

        // Assert
        Assert.Equal(Math.PI / 4, result);
    }

    [Fact]
    public void Atan_StringValue_ConvertsAndCalculatesAtan_Math()
    {
        // Arrange
        var input = "1.0";

        // Act
        double? result = input.Atan<double>();

        // Assert
        Assert.Equal(Math.PI / 4, result);
    }

    #endregion

    #region Cbrt

    [Fact]
    public void Cbrt_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Cbrt<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Cbrt_PositiveValue_ReturnsCubeRoot_Math()
    {
        // Arrange
        double? input = 27.0;

        // Act
        double? result = input.Cbrt<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3.0, result.Value, 15);
    }

    [Fact]
    public void Cbrt_NegativeValue_ReturnsNegativeCubeRoot_Math()
    {
        // Arrange
        double? input = -27.0;

        // Act
        double? result = input.Cbrt<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(-3.0, result.Value, 15);
    }

    [Fact]
    public void Cbrt_StringValue_ConvertsAndCalculatesCbrt_Math()
    {
        // Arrange
        var input = "27.0";

        // Act
        double? result = input.Cbrt<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3.0, result.Value, 15);
    }

    #endregion

    #region Exp

    [Fact]
    public void Exp_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Exp<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Exp_ZeroValue_ReturnsOne_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Exp<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Exp_OneValue_ReturnsE_Math()
    {
        // Arrange
        double? input = 1.0;

        // Act
        double? result = input.Exp<double>();

        // Assert
        Assert.Equal(Math.E, result);
    }

    [Fact]
    public void Exp_StringValue_ConvertsAndCalculatesExp_Math()
    {
        // Arrange
        var input = "1.0";

        // Act
        double? result = input.Exp<double>();

        // Assert
        Assert.Equal(Math.E, result);
    }

    #endregion

    #region Exp2

    [Fact]
    public void Exp2_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Exp2_ZeroValue_ReturnsOne_Math()
    {
        // Arrange
        double? input = 0.0;

        // Act
        double? result = input.Exp2<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Exp2_PositiveValue_ReturnsPowerOfTwo_Math()
    {
        // Arrange
        double? input = 3.0;

        // Act
        double? result = input.Exp2<double>();

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void Exp2_StringValue_ConvertsAndCalculatesExp2_Math()
    {
        // Arrange
        var input = "3.0";

        // Act
        double? result = input.Exp2<double>();

        // Assert
        Assert.Equal(8.0, result);
    }

    #endregion

    #region Log

    [Fact]
    public void Log_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log_PositiveValueNoBase_ReturnsNaturalLog_Math()
    {
        // Arrange
        double? input = Math.E;

        // Act
        double? result = input.Log<double>();

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void Log_PositiveValueWithBase_ReturnsLogWithBase_Math()
    {
        // Arrange
        double? input = 100.0;

        // Act
        double? result = input.Log<double>(10);

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Log_StringValue_ConvertsAndCalculatesLog_Math()
    {
        // Arrange
        var input = "100.0";

        // Act
        double? result = input.Log<double>(10);

        // Assert
        Assert.Equal(2.0, result);
    }

    #endregion

    #region Log10

    [Fact]
    public void Log10_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log10<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log10_PositiveValue_ReturnsLog10Value_Math()
    {
        // Arrange
        double? input = 100.0;

        // Act
        double? result = input.Log10<double>();

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Log10_StringValue_ConvertsAndCalculatesLog10_Math()
    {
        // Arrange
        var input = "100.0";

        // Act
        double? result = input.Log10<double>();

        // Assert
        Assert.Equal(2.0, result);
    }

    [Fact]
    public void Log10_FractionalValue_ReturnsCorrectValue_Math()
    {
        // Arrange
        double? input = 0.1;

        // Act
        double? result = input.Log10<double>();

        // Assert
        Assert.Equal(-1.0, result);
    }

    #endregion

    #region Log2

    [Fact]
    public void Log2_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log2<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log2_PositiveValue_ReturnsLog2Value_Math()
    {
        // Arrange
        double? input = 8.0;

        // Act
        double? result = input.Log2<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Log2_StringValue_ConvertsAndCalculatesLog2_Math()
    {
        // Arrange
        var input = "8.0";

        // Act
        double? result = input.Log2<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Log2_FractionalValue_ReturnsCorrectValue_Math()
    {
        // Arrange
        double? input = 0.5;

        // Act
        double? result = input.Log2<double>();

        // Assert
        Assert.Equal(-1.0, result);
    }

    [Fact]
    public void Log2_PowerOfTwo_IsExact_Math()
    {
        // Act
        var result = 536870912.0.Log2();

        // Assert
        Assert.Equal(29.0, result);
    }

    #endregion

    #region ILogB

    [Fact]
    public void ILogB_NullValue_ReturnsDefault_Math()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void ILogB_PowerOfTwo_ReturnsExponent_Math()
    {
        // Arrange
        double? input = 8.0;

        // Act
        int? result = input.ILogB<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void ILogB_StringValue_ConvertsAndCalculatesILogB_Math()
    {
        // Arrange
        var input = "8.0";

        // Act
        int? result = input.ILogB<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void ILogB_LargeValue_ReturnsCorrectExponent_Math()
    {
        // Arrange
        double? input = 1024.0;

        // Act
        int? result = input.ILogB<int>();

        // Assert
        Assert.Equal(10, result);
    }

    #endregion

    #region Helpers

    /// <summary>A sequence that yields its items on the first enumeration only, as a consumed stream does.</summary>
    private sealed class OneShot<T>(params T[] items) : IEnumerable<T>
    {
        private bool _enumerated;

        public IEnumerator<T> GetEnumerator()
        {
            var first = !_enumerated;

            _enumerated = true;

            return first ? ((IEnumerable<T>)items).GetEnumerator() : Enumerable.Empty<T>().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>A sequence that counts how often it is enumerated, as an iterator source would be started.</summary>
    private sealed class CountingSequence<T>(params T[] items) : IEnumerable<T>
    {
        public int Enumerations { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            Enumerations++;

            return ((IEnumerable<T>)items).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>A <see cref="List{T}"/> whose own <see cref="IEnumerable{T}"/> implementation skips negative items.</summary>
    private sealed class FilteredList : List<int>, IEnumerable<int>
    {
        IEnumerator<int> IEnumerable<int>.GetEnumerator() => ToArray().Where(static x => x >= 0).GetEnumerator();
    }

    #endregion
}
