namespace YANLib.Tests.Library;

public partial class YANMathTest
{
    #region Min
    [Fact]
    public void MinGeneric_NullEnumerable_ReturnsDefault()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Min<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void MinGeneric_EmptyEnumerable_ReturnsDefault()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Min<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void MinGeneric_IntegerEnumerable_ReturnsMinimumValue()
    {
        // Arrange
        var input = new object[] { 5, 3, 9, 1, 7 };

        // Act
        var result = input.Min<int>();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void MinGeneric_DoubleEnumerable_ReturnsMinimumValue()
    {
        // Arrange
        var input = new object[] { 5.5, 3.3, 9.9, 1.1, 7.7 };

        // Act
        var result = input.Min<double>();

        // Assert
        Assert.Equal(1.1, result);
    }

    [Fact]
    public void MinGeneric_MixedTypesEnumerable_ReturnsMinimumValue()
    {
        // Arrange
        var input = new object[] { 5, 3.3, 9, 1.1, 7 };

        // Act
        var result = input.Min<double>();

        // Assert
        Assert.Equal(1.1, result);
    }

    [Fact]
    public void MinGeneric_Params_IntegerArray_ReturnsMinimumValue()
    {
        // Arrange
        var obj = 5;

        // Act
        var result = YANMath.Min<double>(obj, 3, 9, 1, 7);

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void MinGeneric_Params_NullArray_ReturnsDefault()
    {
        // Arrange
        object?[]? input = null;

        // Act
        var result = YANMath.Min<int>(input);

        // Assert
        Assert.Equal(default, result);
    }
    #endregion

    #region Max
    [Fact]
    public void MaxGeneric_NullEnumerable_ReturnsDefault()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Max<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void MaxGeneric_EmptyEnumerable_ReturnsDefault()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Max<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void MaxGeneric_IntegerEnumerable_ReturnsMaximumValue()
    {
        // Arrange
        var input = new object[] { 5, 3, 9, 1, 7 };

        // Act
        var result = input.Max<int>();

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void MaxGeneric_DoubleEnumerable_ReturnsMaximumValue()
    {
        // Arrange
        var input = new object[] { 5.5, 3.3, 9.9, 1.1, 7.7 };

        // Act
        var result = input.Max<double>();

        // Assert
        Assert.Equal(9.9, result);
    }

    [Fact]
    public void MaxGeneric_MixedTypesEnumerable_ReturnsMaximumValue()
    {
        // Arrange
        var input = new object[] { 5, 3.3, 9, 1.1, 7 };

        // Act
        var result = input.Max<double>();

        // Assert
        Assert.Equal(9.0, result);
    }

    [Fact]
    public void MaxGeneric_Params_IntegerArray_ReturnsMaximumValue()
    {
        // Arrange
        var obj = 5;

        // Act
        var result = YANMath.Max<double>(obj, 3, 9, 1, 7);

        // Assert
        Assert.Equal(9.0, result);
    }

    [Fact]
    public void MaxGeneric_Params_NullArray_ReturnsDefault()
    {
        // Arrange
        object?[]? input = null;

        // Act
        var result = YANMath.Max<int>(input);

        // Assert
        Assert.Equal(default, result);
    }
    #endregion

    #region Average
    [Fact]
    public void AverageGeneric_NullEnumerable_ReturnsDefault()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void AverageGeneric_EmptyEnumerable_ReturnsDefault()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void AverageGeneric_IntegerEnumerable_ReturnsAverageValue()
    {
        // Arrange
        var input = new object[] { 2, 4, 6, 8, 10 };

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(6.0, result);
    }

    [Fact]
    public void AverageGeneric_DoubleEnumerable_ReturnsAverageValue()
    {
        // Arrange
        var input = new object[] { 1.5, 2.5, 3.5, 4.5 };

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void AverageGeneric_MixedTypesEnumerable_ReturnsAverageValue()
    {
        // Arrange
        var input = new object[] { 2, 4.0, 6, 8.0, 10 };

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(6.0, result);
    }

    [Fact]
    public void AverageGeneric_Params_IntegerArray_ReturnsAverageValue()
    {
        // Arrange
        var obj = 2;

        // Act
        var result = YANMath.Average<double>(obj, 4, 6, 8, 10);

        // Assert
        Assert.Equal(6.0, result);
    }

    [Fact]
    public void AverageGeneric_Params_NullArray_ReturnsDefault()
    {
        // Arrange
        object?[]? input = null;

        // Act
        var result = YANMath.Average<double>(input);

        // Assert
        Assert.Equal(default, result);
    }
    #endregion

    #region Sum
    [Fact]
    public void SumGeneric_NullEnumerable_ReturnsDefault()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Sum<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void SumGeneric_EmptyEnumerable_ReturnsDefault()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Sum<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void SumGeneric_IntegerEnumerable_ReturnsSumValue()
    {
        // Arrange
        var input = new object[] { 1, 2, 3, 4, 5 };

        // Act
        var result = input.Sum<int>();

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void SumGeneric_DoubleEnumerable_ReturnsSumValue()
    {
        // Arrange
        var input = new object[] { 1.1, 2.2, 3.3 };

        // Act
        var result = input.Sum<double>();

        // Assert
        Assert.Equal(6.6, result, 0.0001);
    }

    [Fact]
    public void SumGeneric_MixedTypesEnumerable_ReturnsSumValue()
    {
        // Arrange
        var input = new object[] { 1, 2.2, 3, 4.4, 5 };

        // Act
        var result = input.Sum<double>();

        // Assert
        Assert.Equal(15.6, result, 0.0001);
    }

    [Fact]
    public void SumGeneric_Params_IntegerArray_ReturnsSumValue()
    {
        // Arrange
        var obj = 1;

        // Act
        var result = YANMath.Sum<double>(obj, 2, 3, 4, 5);

        // Assert
        Assert.Equal(15.0, result);
    }

    [Fact]
    public void SumGeneric_Params_NullArray_ReturnsDefault()
    {
        // Arrange
        object?[]? input = null;

        // Act
        var result = YANMath.Sum<int>(input);

        // Assert
        Assert.Equal(default, result);
    }
    #endregion

    #region Truncate
    [Fact]
    public void TruncateGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Truncate<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void TruncateGeneric_PositiveDouble_ReturnsTruncatedValue()
    {
        // Arrange
        object input = 3.7;

        // Act
        var result = input.Truncate<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void TruncateGeneric_NegativeDouble_ReturnsTruncatedValue()
    {
        // Arrange
        object input = -3.7;

        // Act
        var result = input.Truncate<double>();

        // Assert
        Assert.Equal(-3.0, result);
    }

    [Fact]
    public void TruncateGeneric_IntegerValue_ReturnsSameValue()
    {
        // Arrange
        object input = 5;

        // Act
        var result = input.Truncate<int>();

        // Assert
        Assert.Equal(5, result);
    }
    #endregion

    #region Truncates
    [Fact]
    public void TruncatesGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TruncatesGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TruncatesGeneric_DoubleEnumerable_ReturnsTruncatedValues()
    {
        // Arrange
        var input = new object[] { 1.1, 2.7, 3.5, -4.2 };

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1.0, 2.0, 3.0, -4.0 }, result);
    }

    [Fact]
    public void TruncatesGeneric_Params_DoubleArray_ReturnsTruncatedValues()
    {
        // Arrange
        var obj = 1.1;

        // Act
        var result = YANMath.Truncates<int>(obj, 2.7, 3.5, -4.2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1, 2, 3, -4 }, result);
    }

    [Fact]
    public void TruncatesGeneric_Params_NullArray_ReturnsNull()
    {
        // Arrange
        object?[]? input = null;

        // Act
        var result = YANMath.Truncates<double>(input);

        // Assert
        Assert.Null(result);
    }
    #endregion

    #region Ceiling
    [Fact]
    public void CeilingGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Ceiling<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void CeilingGeneric_PositiveDouble_ReturnsCeilingValue()
    {
        // Arrange
        object input = 3.2;

        // Act
        var result = input.Ceiling<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void CeilingGeneric_NegativeDouble_ReturnsCeilingValue()
    {
        // Arrange
        object input = -3.2;

        // Act
        var result = input.Ceiling<double>();

        // Assert
        Assert.Equal(-3.0, result);
    }

    [Fact]
    public void CeilingGeneric_IntegerValue_ReturnsSameValue()
    {
        // Arrange
        object input = 5;

        // Act
        var result = input.Ceiling<int>();

        // Assert
        Assert.Equal(5, result);
    }
    #endregion

    #region Ceilings
    [Fact]
    public void CeilingsGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CeilingsGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CeilingsGeneric_DoubleEnumerable_ReturnsCeilingValues()
    {
        // Arrange
        var input = new object[] { 1.1, 2.7, 3.0, -4.2 };

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 2.0, 3.0, 3.0, -4.0 }, result);
    }

    [Fact]
    public void CeilingsGeneric_Params_DoubleArray_ReturnsCeilingValues()
    {
        // Arrange
        var obj = 1.1;

        // Act
        var result = YANMath.Ceilings<int>(obj, 2.7, 3.0, -4.2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 2, 3, 3, -4 }, result);
    }

    [Fact]
    public void CeilingsGeneric_Params_NullArray_ReturnsNull()
    {
        // Arrange
        object?[]? input = null;

        // Act
        var result = YANMath.Ceilings<double>(input);

        // Assert
        Assert.Null(result);
    }
    #endregion

    #region Floor
    [Fact]
    public void FloorGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Floor<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void FloorGeneric_PositiveDouble_ReturnsFloorValue()
    {
        // Arrange
        object input = 3.7;

        // Act
        var result = input.Floor<double>();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void FloorGeneric_NegativeDouble_ReturnsFloorValue()
    {
        // Arrange
        object input = -3.2;

        // Act
        var result = input.Floor<double>();

        // Assert
        Assert.Equal(-4.0, result);
    }

    [Fact]
    public void FloorGeneric_IntegerValue_ReturnsSameValue()
    {
        // Arrange
        object input = 5;

        // Act
        var result = input.Floor<int>();

        // Assert
        Assert.Equal(5, result);
    }
    #endregion

    #region Floors
    [Fact]
    public void FloorsGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FloorsGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void FloorsGeneric_DoubleEnumerable_ReturnsFloorValues()
    {
        // Arrange
        var input = new object[] { 1.1, 2.7, 3.0, -4.2 };

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1.0, 2.0, 3.0, -5.0 }, result);
    }

    [Fact]
    public void FloorsGeneric_Params_DoubleArray_ReturnsFloorValues()
    {
        // Arrange
        var obj = 1.1;

        // Act
        var result = YANMath.Floors<int>(obj, 2.7, 3.0, -4.2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1, 2, 3, -5 }, result);
    }

    [Fact]
    public void FloorsGeneric_Params_NullArray_ReturnsNull()
    {
        // Arrange
        object?[]? input = null;

        // Act
        var result = YANMath.Floors<double>(input);

        // Assert
        Assert.Null(result);
    }
    #endregion

    #region Round
    [Fact]
    public void RoundGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Round<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void RoundGeneric_DoubleWithoutDigits_ReturnsRoundedValue()
    {
        // Arrange
        object input = 3.7;

        // Act
        var result = input.Round<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void RoundGeneric_DoubleWithDigits_ReturnsRoundedValue()
    {
        // Arrange
        object input = 3.14159;
        object digits = 2;

        // Act
        var result = input.Round<double>(digits);

        // Assert
        Assert.Equal(3.14, result);
    }

    [Fact]
    public void RoundGeneric_NegativeDoubleWithDigits_ReturnsRoundedValue()
    {
        // Arrange
        object input = -3.14159;
        object digits = 2;

        // Act
        var result = input.Round<double>(digits);

        // Assert
        Assert.Equal(-3.14, result);
    }
    #endregion

    #region Rounds
    [Fact]
    public void RoundsGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void RoundsGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void RoundsGeneric_DoubleEnumerableWithoutDigits_ReturnsRoundedValues()
    {
        // Arrange
        var input = new object[] { 1.1, 2.7, 3.5, -4.2 };

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1.0, 3.0, 4.0, -4.0 }, result);
    }

    [Fact]
    public void RoundsGeneric_DoubleEnumerableWithDigits_ReturnsRoundedValues()
    {
        // Arrange
        var input = new object[] { 1.11, 2.77, 3.55, -4.22 };
        object digits = 1;

        // Act
        var result = input.Rounds<double>(digits);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1.1, 2.8, 3.6, -4.2 }, result);
    }

    [Fact]
    public void RoundsGeneric_Params_DoubleArray_ReturnsRoundedValues()
    {
        // Arrange
        var obj = 1.1;

        // Act
        var result = YANMath.Rounds<int>(obj, 2.7, 3.5, -4.2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1, 3, 4, -4 }, result);
    }
    #endregion

    #region Sqrt
    [Fact]
    public void SqrtGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Sqrt<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void SqrtGeneric_PositiveDouble_ReturnsSqrtValue()
    {
        // Arrange
        object input = 16.0;

        // Act
        var result = input.Sqrt<double>();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void SqrtGeneric_Zero_ReturnsZero()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.Sqrt<double>();

        // Assert
        Assert.Equal(0.0, result);
    }
    #endregion

    #region Sqrts
    [Fact]
    public void SqrtsGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SqrtsGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SqrtsGeneric_DoubleEnumerable_ReturnsSqrtValues()
    {
        // Arrange
        var input = new object[] { 4.0, 9.0, 16.0, 25.0 };
        var expected = new[] { 2.0, 3.0, 4.0, 5.0 };

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SqrtsGeneric_Params_DoubleArray_ReturnsSqrtValues()
    {
        // Arrange
        var expected = new[] { 2.0, 3.0, 4.0, 5.0 };

        // Act
        var result = YANMath.Sqrts<double>(4.0, 9.0, 16.0, 25.0);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Pow
    [Fact]
    public void PowGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;
        object power = 2;

        // Act
        var result = input.Pow<double>(power);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void PowGeneric_NullPower_ReturnsDefault()
    {
        // Arrange
        object input = 2;
        object? power = null;

        // Act
        var result = input.Pow<double>(power);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void PowGeneric_DoubleWithPower_ReturnsPowValue()
    {
        // Arrange
        object input = 2.0;
        object power = 3.0;

        // Act
        var result = input.Pow<double>(power);

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void PowGeneric_NegativeBaseWithIntegerPower_ReturnsPowValue()
    {
        // Arrange
        object input = -2.0;
        object power = 2.0;

        // Act
        var result = input.Pow<double>(power);

        // Assert
        Assert.Equal(4.0, result);
    }
    #endregion

    #region Pows
    [Fact]
    public void PowsGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;
        object power = 2;

        // Act
        var result = input.Pows<double>(power);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void PowsGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();
        object power = 2;

        // Act
        var result = input.Pows<double>(power);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void PowsGeneric_DoubleEnumerable_ReturnsPowValues()
    {
        // Arrange
        var input = new object[] { 1.0, 2.0, 3.0, 4.0 };
        object power = 2;
        var expected = new[] { 1.0, 4.0, 9.0, 16.0 };

        // Act
        var result = input.Pows<double>(power);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Abs
    [Fact]
    public void AbsGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Abs<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void AbsGeneric_PositiveDouble_ReturnsSameValue()
    {
        // Arrange
        object input = 5.5;

        // Act
        var result = input.Abs<double>();

        // Assert
        Assert.Equal(5.5, result);
    }

    [Fact]
    public void AbsGeneric_NegativeDouble_ReturnsPositiveValue()
    {
        // Arrange
        object input = -5.5;

        // Act
        var result = input.Abs<double>();

        // Assert
        Assert.Equal(5.5, result);
    }

    [Fact]
    public void AbsGeneric_Zero_ReturnsZero()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.Abs<double>();

        // Assert
        Assert.Equal(0.0, result);
    }
    #endregion

    #region Abss
    [Fact]
    public void AbssGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AbssGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AbssGeneric_DoubleEnumerable_ReturnsAbsValues()
    {
        // Arrange
        var input = new object[] { 1.1, -2.2, 3.3, -4.4 };
        var expected = new[] { 1.1, 2.2, 3.3, 4.4 };

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void AbssGeneric_Params_DoubleArray_ReturnsAbsValues()
    {
        // Arrange
        var expected = new[] { 1.1, 2.2, 3.3, 4.4 };

        // Act
        var result = YANMath.Abss<double>(1.1, -2.2, 3.3, -4.4);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Log
    [Fact]
    public void LogGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Log<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void LogGeneric_PositiveDoubleWithoutBase_ReturnsNaturalLogValue()
    {
        // Arrange
        object input = Math.E;

        // Act
        var result = input.Log<double>();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }

    [Fact]
    public void LogGeneric_PositiveDoubleWithBase_ReturnsLogValue()
    {
        // Arrange
        object input = 100.0;
        object baseValue = 10.0;

        // Act
        var result = input.Log<double>(baseValue);

        // Assert
        Assert.Equal(2.0, result);
    }
    #endregion

    #region Logs
    [Fact]
    public void LogsGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LogsGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void LogsGeneric_DoubleEnumerableWithoutBase_ReturnsNaturalLogValues()
    {
        // Arrange
        var input = new object[] { 1.0, Math.E, Math.E * Math.E };

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(2.0, item, 0.0001));
    }

    [Fact]
    public void LogsGeneric_DoubleEnumerableWithBase_ReturnsLogValues()
    {
        // Arrange
        var input = new object[] { 1.0, 10.0, 100.0 };
        object baseValue = 10.0;
        var expected = new[] { 0.0, 1.0, 2.0 };

        // Act
        var result = input.Logs<double>(baseValue);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void LogsGeneric_Params_DoubleArray_ReturnsLogValues()
    {
        // Arrange
        var obj = 1;

        // Act
        var result = YANMath.Logs<double>(obj, 10, 100);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.Log(10.0), item, 0.0001), item => Assert.Equal(Math.Log(100.0), item, 0.0001));
    }
    #endregion

    #region Log10
    [Fact]
    public void Log10Generic_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Log10<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log10Generic_PositiveDouble_ReturnsLog10Value()
    {
        // Arrange
        object input = 100.0;

        // Act
        var result = input.Log10<double>();

        // Assert
        Assert.Equal(2.0, result);
    }
    #endregion

    #region Log10s
    [Fact]
    public void Log10sGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log10sGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log10sGeneric_DoubleEnumerable_ReturnsLog10Values()
    {
        // Arrange
        var input = new object[] { 1.0, 10.0, 100.0, 1000.0 };
        var expected = new[] { 0.0, 1.0, 2.0, 3.0 };

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Log10sGeneric_Params_DoubleArray_ReturnsLog10Values()
    {
        // Arrange
        var expected = new[] { 0.0, 1.0, 2.0, 3.0 };

        // Act
        var result = YANMath.Log10s<double>(1, 10, 100, 1000);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Log2
    [Fact]
    public void Log2Generic_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Log2<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log2Generic_PositiveDouble_ReturnsLog2Value()
    {
        // Arrange
        object input = 8.0;

        // Act
        var result = input.Log2<double>();

        // Assert
        Assert.Equal(3.0, result);
    }
    #endregion

    #region Log2s
    [Fact]
    public void Log2sGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log2sGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log2sGeneric_DoubleEnumerable_ReturnsLog2Values()
    {
        // Arrange
        var input = new object[] { 1.0, 2.0, 4.0, 8.0 };
        var expected = new[] { 0.0, 1.0, 2.0, 3.0 };

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Log2sGeneric_Params_DoubleArray_ReturnsLog2Values()
    {
        // Arrange
        var expected = new[] { 0.0, 1.0, 2.0, 3.0 };

        // Act
        var result = YANMath.Log2s<double>(1, 2, 4, 8);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Sin
    [Fact]
    public void SinGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Sin<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void SinGeneric_ZeroRadians_ReturnsZero()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.Sin<double>();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void SinGeneric_PiOver2Radians_ReturnsOne()
    {
        // Arrange
        object input = Math.PI / 2;

        // Act
        var result = input.Sin<double>();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }
    #endregion

    #region Sins
    [Fact]
    public void SinsGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Sins<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SinsGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Sins<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SinsGeneric_DoubleEnumerable_ReturnsSinValues()
    {
        // Arrange
        var input = new object[] { 0.0, Math.PI / 2, Math.PI };

        // Act
        var result = input.Sins<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001));
    }

    [Fact]
    public void SinsGeneric_Params_DoubleArray_ReturnsSinValues()
    {
        // Arrange
        var obj = 0;

        // Act
        var result = YANMath.Sins<double>(obj, Math.PI / 2, Math.PI);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001));
    }
    #endregion

    #region Cos
    [Fact]
    public void CosGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Cos<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void CosGeneric_ZeroRadians_ReturnsOne()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.Cos<double>();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }

    [Fact]
    public void CosGeneric_PiRadians_ReturnsMinusOne()
    {
        // Arrange
        object input = Math.PI;

        // Act
        var result = input.Cos<double>();

        // Assert
        Assert.Equal(-1.0, result, 0.0001);
    }
    #endregion

    #region Coss
    [Fact]
    public void CossGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Coss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CossGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Coss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CossGeneric_DoubleEnumerable_ReturnsCosValues()
    {
        // Arrange
        var input = new object[] { 0.0, Math.PI / 2, Math.PI };

        // Act
        var result = input.Coss<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(-1.0, item, 0.0001));
    }

    [Fact]
    public void CossGeneric_Params_DoubleArray_ReturnsCosValues()
    {
        // Arrange
        var obj = 0;

        // Act
        var result = YANMath.Coss<double>(obj, Math.PI / 2, Math.PI);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(-1.0, item, 0.0001));
    }
    #endregion

    #region Tan
    [Fact]
    public void TanGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Tan<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void TanGeneric_ZeroRadians_ReturnsZero()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.Tan<double>();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void TanGeneric_PiOver4Radians_ReturnsOne()
    {
        // Arrange
        object input = Math.PI / 4;

        // Act
        var result = input.Tan<double>();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }
    #endregion

    #region Tans
    [Fact]
    public void TansGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Tans<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TansGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Tans<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TansGeneric_DoubleEnumerable_ReturnsTanValues()
    {
        // Arrange
        var input = new object[] { 0.0, Math.PI / 4, Math.PI };

        // Act
        var result = input.Tans<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001));
    }

    [Fact]
    public void TansGeneric_Params_DoubleArray_ReturnsTanValues()
    {
        // Arrange
        var obj = 0;

        // Act
        var result = YANMath.Tans<double>(obj, Math.PI / 4, Math.PI);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001));
    }
    #endregion

    #region Asin
    [Fact]
    public void AsinGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Asin<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void AsinGeneric_ZeroValue_ReturnsZero()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.Asin<double>();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void AsinGeneric_OneValue_ReturnsPiOverTwo()
    {
        // Arrange
        object input = 1.0;

        // Act
        var result = input.Asin<double>();

        // Assert
        Assert.Equal(Math.PI / 2, result, 0.0001);
    }

    [Fact]
    public void AsinGeneric_MinusOneValue_ReturnsMinusPiOverTwo()
    {
        // Arrange
        object input = -1.0;

        // Act
        var result = input.Asin<double>();

        // Assert
        Assert.Equal(-Math.PI / 2, result, 0.0001);
    }
    #endregion

    #region Asins
    [Fact]
    public void AsinsGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Asins<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AsinsGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Asins<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AsinsGeneric_DoubleEnumerable_ReturnsAsinValues()
    {
        // Arrange
        var input = new object[] { 0.0, 0.5, 1.0, -1.0 };

        // Act
        var result = input.Asins<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.Asin(0.5), item, 0.0001), item => Assert.Equal(Math.PI / 2, item, 0.0001), item => Assert.Equal(-Math.PI / 2, item, 0.0001));
    }

    [Fact]
    public void AsinsGeneric_Params_DoubleArray_ReturnsAsinValues()
    {
        // Arrange
        var obj = 0;

        // Act
        var result = YANMath.Asins<double>(obj, 0.5, 1.0, -1.0);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.Asin(0.5), item, 0.0001), item => Assert.Equal(Math.PI / 2, item, 0.0001), item => Assert.Equal(-Math.PI / 2, item, 0.0001));
    }
    #endregion

    #region Acos
    [Fact]
    public void AcosGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Acos<double?>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AcosGeneric_OneValue_ReturnsZero()
    {
        // Arrange
        object input = 1.0;

        // Act
        var result = input.Acos<double>();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void AcosGeneric_ZeroValue_ReturnsPiOverTwo()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.Acos<double>();

        // Assert
        Assert.Equal(Math.PI / 2, result, 0.0001);
    }

    [Fact]
    public void AcosGeneric_MinusOneValue_ReturnsPi()
    {
        // Arrange
        object input = -1.0;

        // Act
        var result = input.Acos<double>();

        // Assert
        Assert.Equal(Math.PI, result, 0.0001);
    }
    #endregion

    #region Acoss
    [Fact]
    public void AcossGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Acoss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AcossGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Acoss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AcossGeneric_DoubleEnumerable_ReturnsAcosValues()
    {
        // Arrange
        var input = new object[] { 1.0, 0.5, 0.0, -1.0 };

        // Act
        var result = input.Acoss<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.Acos(0.5), item, 0.0001), item => Assert.Equal(Math.PI / 2, item, 0.0001), item => Assert.Equal(Math.PI, item, 0.0001));
    }

    [Fact]
    public void AcossGeneric_Params_DoubleArray_ReturnsAcosValues()
    {
        // Arrange
        var obj = 1;

        // Act
        var result = YANMath.Acoss<double>(obj, 0.5, 0.0, -1.0);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.Acos(0.5), item, 0.0001), item => Assert.Equal(Math.PI / 2, item, 0.0001), item => Assert.Equal(Math.PI, item, 0.0001));
    }
    #endregion

    #region Atan
    [Fact]
    public void AtanGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Atan<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void AtanGeneric_ZeroValue_ReturnsZero()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.Atan<double>();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void AtanGeneric_OneValue_ReturnsPiOverFour()
    {
        // Arrange
        object input = 1.0;

        // Act
        var result = input.Atan<double>();

        // Assert
        Assert.Equal(Math.PI / 4, result, 0.0001);
    }

    [Fact]
    public void AtanGeneric_NegativeOneValue_ReturnsMinusPiOverFour()
    {
        // Arrange
        object input = -1.0;

        // Act
        var result = input.Atan<double>();

        // Assert
        Assert.Equal(-Math.PI / 4, result, 0.0001);
    }

    [Fact]
    public void AtanGeneric_VeryLargeValue_ApproachesPiOverTwo()
    {
        // Arrange
        object input = 1000000.0;

        // Act
        var result = input.Atan<double>();

        // Assert
        Assert.InRange(result, Math.PI / 2 - 0.001, Math.PI / 2);
    }
    #endregion

    #region Atans
    [Fact]
    public void AtansGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Atans<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AtansGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Atans<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void AtansGeneric_DoubleEnumerable_ReturnsAtanValues()
    {
        // Arrange
        var input = new object[] { 0.0, 1.0, -1.0 };

        // Act
        var result = input.Atans<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.PI / 4, item, 0.0001), item => Assert.Equal(-Math.PI / 4, item, 0.0001));
    }

    [Fact]
    public void AtansGeneric_Params_DoubleArray_ReturnsAtanValues()
    {
        // Arrange
        var obj = 0;

        // Act
        var result = YANMath.Atans<double>(obj, 1, -1);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.PI / 4, item, 0.0001), item => Assert.Equal(-Math.PI / 4, item, 0.0001));
    }
    #endregion

    #region Cbrt
    [Fact]
    public void CbrtGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Cbrt<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void CbrtGeneric_ZeroValue_ReturnsZero()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.Cbrt<double>();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void CbrtGeneric_PositiveValue_ReturnsCubeRoot()
    {
        // Arrange
        object input = 27.0;

        // Act
        var result = input.Cbrt<double>();

        // Assert
        Assert.Equal(3.0, result, 0.0001);
    }

    [Fact]
    public void CbrtGeneric_NegativeValue_ReturnsNegativeCubeRoot()
    {
        // Arrange
        object input = -27.0;

        // Act
        var result = input.Cbrt<double>();

        // Assert
        Assert.Equal(-3.0, result, 0.0001);
    }
    #endregion

    #region Cbrts
    [Fact]
    public void CbrtsGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Cbrts<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CbrtsGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Cbrts<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void CbrtsGeneric_DoubleEnumerable_ReturnsCbrtValues()
    {
        // Arrange
        var input = new object[] { 0.0, 8.0, 27.0, -27.0 };

        // Act
        var result = input.Cbrts<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(2.0, item, 0.0001), item => Assert.Equal(3.0, item, 0.0001), item => Assert.Equal(-3.0, item, 0.0001));
    }

    [Fact]
    public void CbrtsGeneric_Params_DoubleArray_ReturnsCbrtValues()
    {
        // Arrange
        var obj = 0;

        // Act
        var result = YANMath.Cbrts<double>(obj, 8, 27, -27);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(2.0, item, 0.0001), item => Assert.Equal(3.0, item, 0.0001), item => Assert.Equal(-3.0, item, 0.0001));
    }
    #endregion

    #region Exp
    [Fact]
    public void ExpGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Exp<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void ExpGeneric_ZeroValue_ReturnsOne()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.Exp<double>();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }

    [Fact]
    public void ExpGeneric_OneValue_ReturnsE()
    {
        // Arrange
        object input = 1.0;

        // Act
        var result = input.Exp<double>();

        // Assert
        Assert.Equal(Math.E, result, 0.0001);
    }

    [Fact]
    public void ExpGeneric_NegativeValue_ReturnsExpValue()
    {
        // Arrange
        object input = -1.0;

        // Act
        var result = input.Exp<double>();

        // Assert
        Assert.Equal(1.0 / Math.E, result, 0.0001);
    }
    #endregion

    #region Exps
    [Fact]
    public void ExpsGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Exps<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ExpsGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Exps<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ExpsGeneric_DoubleEnumerable_ReturnsExpValues()
    {
        // Arrange
        var input = new object[] { 0.0, 1.0, -1.0 };

        // Act
        var result = input.Exps<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(Math.E, item, 0.0001), item => Assert.Equal(1.0 / Math.E, item, 0.0001));
    }

    [Fact]
    public void ExpsGeneric_Params_DoubleArray_ReturnsExpValues()
    {
        // Arrange
        var obj = 0;

        // Act
        var result = YANMath.Exps<double>(obj, 1, -1);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(Math.E, item, 0.0001), item => Assert.Equal(1.0 / Math.E, item, 0.0001));
    }
    #endregion

    #region Exp2
    [Fact]
    public void Exp2Generic_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Exp2Generic_ZeroValue_ReturnsOne()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }

    [Fact]
    public void Exp2Generic_OneValue_ReturnsTwo()
    {
        // Arrange
        object input = 1.0;

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(2.0, result, 0.0001);
    }

    [Fact]
    public void Exp2Generic_ThreeValue_ReturnsEight()
    {
        // Arrange
        object input = 3.0;

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(8.0, result, 0.0001);
    }

    [Fact]
    public void Exp2Generic_NegativeValue_ReturnsExp2Value()
    {
        // Arrange
        object input = -1.0;

        // Act
        var result = input.Exp2<double>();

        // Assert
        Assert.Equal(0.5, result, 0.0001);
    }
    #endregion

    #region Exp2s
    [Fact]
    public void Exp2sGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Exp2s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exp2sGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.Exp2s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exp2sGeneric_DoubleEnumerable_ReturnsExp2Values()
    {
        // Arrange
        var input = new object[] { 0.0, 1.0, 2.0, 3.0, -1.0 };

        // Act
        var result = input.Exp2s<double>();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(2.0, item, 0.0001), item => Assert.Equal(4.0, item, 0.0001), item => Assert.Equal(8.0, item, 0.0001), item => Assert.Equal(0.5, item, 0.0001));
    }

    [Fact]
    public void Exp2sGeneric_Params_DoubleArray_ReturnsExp2Values()
    {
        // Arrange
        var obj = 0;

        // Act
        var result = YANMath.Exp2s<double>(obj, 1, 2, 3, -1);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(2.0, item, 0.0001), item => Assert.Equal(4.0, item, 0.0001), item => Assert.Equal(8.0, item, 0.0001), item => Assert.Equal(0.5, item, 0.0001));
    }
    #endregion

    #region ILogB
    [Fact]
    public void ILogBGeneric_NullValue_ReturnsDefault()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void ILogBGeneric_ZeroValue_ReturnsExpectedValue()
    {
        // Arrange
        object input = 0.0;

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(Math.ILogB(0.0), result);
    }

    [Fact]
    public void ILogBGeneric_PowerOfTwoValue_ReturnsExponent()
    {
        // Arrange
        object input = 16.0;

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void ILogBGeneric_NonPowerOfTwoValue_ReturnsFloorOfLog2()
    {
        // Arrange
        object input = 10.0;

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void ILogBGeneric_NegativeValue_ReturnsExponentOfAbsoluteValue()
    {
        // Arrange
        object input = -16.0;

        // Act
        var result = input.ILogB<int>();

        // Assert
        Assert.Equal(4, result);
    }
    #endregion

    #region ILogBs
    [Fact]
    public void ILogBsGeneric_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ILogBs<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ILogBsGeneric_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.ILogBs<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ILogBsGeneric_DoubleEnumerable_ReturnsILogBValues()
    {
        // Arrange
        var input = new object[] { 2.0, 4.0, 8.0, 16.0, 10.0 };

        // Act
        var result = input.ILogBs<int>();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1, item), item => Assert.Equal(2, item), item => Assert.Equal(3, item), item => Assert.Equal(4, item), item => Assert.Equal(3, item));
    }

    [Fact]
    public void ILogBsGeneric_Params_DoubleArray_ReturnsILogBValues()
    {
        // Arrange
        var obj = 2.0;

        // Act
        var result = YANMath.ILogBs<int>(obj, 4.0, 8.0, 16.0, 10.0);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1, item), item => Assert.Equal(2, item), item => Assert.Equal(3, item), item => Assert.Equal(4, item), item => Assert.Equal(3, item));
    }
    #endregion

    #region MixedTypes
    [Fact]
    public void GenericMethods_MixedTypes_ConvertCorrectly()
    {
        // Arrange
        var input = new object[] { 1, 2.5, 3, 4.5 };

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(2.75, result);
    }

    [Fact]
    public void GenericMethods_StringToNumber_ConvertCorrectly()
    {
        // Arrange
        var input = new object[] { "1", "2.5", "3", "4.5" };

        // Act
        var result = input.Average<double>();

        // Assert
        Assert.Equal(2.75, result);
    }

    [Fact]
    public void GenericMethods_DifferentReturnType_ConvertCorrectly()
    {
        // Arrange
        var input = new object[] { 1.1, 2.2, 3.3, 4.4 };

        // Act
        var result = input.Sum<int>();

        // Assert
        Assert.Equal(11, result);
    }
    #endregion
}
