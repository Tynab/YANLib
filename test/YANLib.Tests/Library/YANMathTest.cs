namespace YANLib.Tests.Library;

public partial class YANMathTest
{
    #region Min
    [Fact]
    public void Min_NullEnumerable_ReturnsDefault()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.Min();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Min_EmptyEnumerable_ReturnsDefault()
    {
        // Arrange
        var input = Array.Empty<int>();

        // Act
        var result = input.Min();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Min_IntegerEnumerable_ReturnsMinimumValue()
    {
        // Arrange
        var input = new[] { 5, 3, 9, 1, 7 };

        // Act
        var result = input.Min();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_DoubleEnumerable_ReturnsMinimumValue()
    {
        // Arrange
        var input = new[] { 5.5, 3.3, 9.9, 1.1, 7.7 };

        // Act
        var result = input.Min();

        // Assert
        Assert.Equal(1.1, result);
    }

    [Fact]
    public void Min_NullableIntegerEnumerable_ReturnsMinimumValue()
    {
        // Arrange
        var input = new int?[] { 5, null, 3, 9, 1, 7 };

        // Act
        var result = input.Min();

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_Params_IntegerArray_ReturnsMinimumValue()
    {
        // Arrange
        var obj = 5;

        // Act
        var result = YANMath.Min(obj, 3, 9, 1, 7);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Min_Params_NullArray_ReturnsDefault()
    {
        // Arrange
        int?[]? input = null;

        // Act
        var result = YANMath.Min(input);

        // Assert
        Assert.Equal(default, result);
    }
    #endregion

    #region Max
    [Fact]
    public void Max_NullEnumerable_ReturnsDefault()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.Max();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Max_EmptyEnumerable_ReturnsDefault()
    {
        // Arrange
        var input = Array.Empty<int>();

        // Act
        var result = input.Max();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Max_IntegerEnumerable_ReturnsMaximumValue()
    {
        // Arrange
        var input = new[] { 5, 3, 9, 1, 7 };

        // Act
        var result = input.Max();

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_DoubleEnumerable_ReturnsMaximumValue()
    {
        // Arrange
        var input = new[] { 5.5, 3.3, 9.9, 1.1, 7.7 };

        // Act
        var result = input.Max();

        // Assert
        Assert.Equal(9.9, result);
    }

    [Fact]
    public void Max_NullableIntegerEnumerable_ReturnsMaximumValue()
    {
        // Arrange
        var input = new int?[] { 5, null, 3, 9, 1, 7 };

        // Act
        var result = input.Max();

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_Params_IntegerArray_ReturnsMaximumValue()
    {
        // Arrange
        var obj = 5;

        // Act
        var result = YANMath.Max(obj, 3, 9, 1, 7);

        // Assert
        Assert.Equal(9, result);
    }

    [Fact]
    public void Max_Params_NullArray_ReturnsDefault()
    {
        // Arrange
        int?[]? input = null;

        // Act
        var result = YANMath.Max(input);

        // Assert
        Assert.Equal(default, result);
    }
    #endregion

    #region Average
    [Fact]
    public void Average_NullEnumerable_ReturnsDefault()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.Average();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Average_EmptyEnumerable_ReturnsDefault()
    {
        // Arrange
        var input = Array.Empty<int>();

        // Act
        var result = input.Average();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Average_IntegerEnumerable_ReturnsAverageValue()
    {
        // Arrange
        var input = new[] { 2, 4, 6, 8, 10 };

        // Act
        var result = input.Average();

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Average_DoubleEnumerable_ReturnsAverageValue()
    {
        // Arrange
        var input = new[] { 1.5, 2.5, 3.5, 4.5 };

        // Act
        var result = input.Average();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Average_NullableIntegerEnumerable_ReturnsAverageValue()
    {
        // Arrange
        var input = new int?[] { 2, null, 4, 6, 8, null, 10 };

        // Act
        var result = input.Average();

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Average_Params_IntegerArray_ReturnsAverageValue()
    {
        // Arrange
        var obj = 2;

        // Act
        var result = YANMath.Average(obj, 4, 6, 8, 10);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Average_Params_NullArray_ReturnsDefault()
    {
        // Arrange
        int?[]? input = null;

        // Act
        var result = YANMath.Average(input);

        // Assert
        Assert.Equal(default, result);
    }
    #endregion

    #region Sum
    [Fact]
    public void Sum_NullEnumerable_ReturnsDefault()
    {
        // Arrange
        IEnumerable<int>? input = null;

        // Act
        var result = input.Sum();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sum_EmptyEnumerable_ReturnsDefault()
    {
        // Arrange
        var input = Array.Empty<int>();

        // Act
        var result = input.Sum();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sum_IntegerEnumerable_ReturnsSumValue()
    {
        // Arrange
        var input = new[] { 1, 2, 3, 4, 5 };

        // Act
        var result = input.Sum();

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void Sum_DoubleEnumerable_ReturnsSumValue()
    {
        // Arrange
        var input = new[] { 1.1, 2.2, 3.3 };

        // Act
        var result = input.Sum();

        // Assert
        Assert.Equal(6.6, result, 0.0001);
    }

    [Fact]
    public void Sum_NullableIntegerEnumerable_ReturnsSumValue()
    {
        // Arrange
        var input = new int?[] { 1, null, 2, 3, null, 4, 5 };

        // Act
        var result = input.Sum();

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void Sum_Params_IntegerArray_ReturnsSumValue()
    {
        // Arrange
        var obj = 1;

        // Act
        var result = YANMath.Sum(obj, 2, 3, 4, 5);

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public void Sum_Params_NullArray_ReturnsDefault()
    {
        // Arrange
        int?[]? input = null;

        // Act
        var result = YANMath.Sum(input);

        // Assert
        Assert.Equal(default, result);
    }
    #endregion

    #region Truncate
    [Fact]
    public void Truncate_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Truncate();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Truncate_PositiveDouble_ReturnsTruncatedValue()
    {
        // Arrange
        var input = 3.7;

        // Act
        var result = input.Truncate();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Truncate_NegativeDouble_ReturnsTruncatedValue()
    {
        // Arrange
        var input = -3.7;

        // Act
        var result = input.Truncate();

        // Assert
        Assert.Equal(-3.0, result);
    }

    [Fact]
    public void Truncate_IntegerValue_ReturnsSameValue()
    {
        // Arrange
        var input = 5;

        // Act
        var result = input.Truncate();

        // Assert
        Assert.Equal(5, result);
    }
    #endregion

    #region Truncates
    [Fact]
    public void Truncates_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Truncates();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Truncates_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Truncates();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Truncates_DoubleEnumerable_ReturnsTruncatedValues()
    {
        // Arrange
        var input = new[] { 1.1, 2.7, 3.5, -4.2 };

        // Act
        var result = input.Truncates();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1.0, 2.0, 3.0, -4.0 }, result);
    }

    [Fact]
    public void Truncates_Params_DoubleArray_ReturnsTruncatedValues()
    {
        // Arrange
        var obj = 1.1;

        // Act
        var result = YANMath.Truncates(obj, 2.7, 3.5, -4.2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1.0, 2.0, 3.0, -4.0 }, result);
    }

    [Fact]
    public void Truncates_Params_NullArray_ReturnsNull()
    {
        // Arrange
        double?[]? input = null;

        // Act
        var result = YANMath.Truncates(input);

        // Assert
        Assert.Null(result);
    }
    #endregion

    #region Ceiling
    [Fact]
    public void Ceiling_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Ceiling();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Ceiling_PositiveDouble_ReturnsCeilingValue()
    {
        // Arrange
        var input = 3.2;

        // Act
        var result = input.Ceiling();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Ceiling_NegativeDouble_ReturnsCeilingValue()
    {
        // Arrange
        var input = -3.2;

        // Act
        var result = input.Ceiling();

        // Assert
        Assert.Equal(-3.0, result);
    }

    [Fact]
    public void Ceiling_IntegerValue_ReturnsSameValue()
    {
        // Arrange
        var input = 5;

        // Act
        var result = input.Ceiling();

        // Assert
        Assert.Equal(5, result);
    }
    #endregion

    #region Ceilings
    [Fact]
    public void Ceilings_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Ceilings();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Ceilings_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Ceilings();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Ceilings_DoubleEnumerable_ReturnsCeilingValues()
    {
        // Arrange
        var input = new[] { 1.1, 2.7, 3.0, -4.2 };

        // Act
        var result = input.Ceilings();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 2.0, 3.0, 3.0, -4.0 }, result);
    }

    [Fact]
    public void Ceilings_Params_DoubleArray_ReturnsCeilingValues()
    {
        // Arrange
        var obj = 1.1;

        // Act
        var result = YANMath.Ceilings(obj, 2.7, 3.0, -4.2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 2.0, 3.0, 3.0, -4.0 }, result);
    }

    [Fact]
    public void Ceilings_Params_NullArray_ReturnsNull()
    {
        // Arrange
        double?[]? input = null;

        // Act
        var result = YANMath.Ceilings(input);

        // Assert
        Assert.Null(result);
    }
    #endregion

    #region Floor
    [Fact]
    public void Floor_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Floor();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Floor_PositiveDouble_ReturnsFloorValue()
    {
        // Arrange
        var input = 3.7;

        // Act
        var result = input.Floor();

        // Assert
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void Floor_NegativeDouble_ReturnsFloorValue()
    {
        // Arrange
        var input = -3.2;

        // Act
        var result = input.Floor();

        // Assert
        Assert.Equal(-4.0, result);
    }

    [Fact]
    public void Floor_IntegerValue_ReturnsSameValue()
    {
        // Arrange
        var input = 5;

        // Act
        var result = input.Floor();

        // Assert
        Assert.Equal(5, result);
    }
    #endregion

    #region Floors
    [Fact]
    public void Floors_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Floors();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Floors_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Floors();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Floors_DoubleEnumerable_ReturnsFloorValues()
    {
        // Arrange
        var input = new[] { 1.1, 2.7, 3.0, -4.2 };

        // Act
        var result = input.Floors();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1.0, 2.0, 3.0, -5.0 }, result);
    }

    [Fact]
    public void Floors_Params_DoubleArray_ReturnsFloorValues()
    {
        // Arrange
        var obj = 1.1;

        // Act
        var result = YANMath.Floors(obj, 2.7, 3.0, -4.2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1.0, 2.0, 3.0, -5.0 }, result);
    }

    [Fact]
    public void Floors_Params_NullArray_ReturnsNull()
    {
        // Arrange
        double?[]? input = null;

        // Act
        var result = YANMath.Floors(input);

        // Assert
        Assert.Null(result);
    }
    #endregion

    #region Round
    [Fact]
    public void Round_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Round();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Round_DoubleWithoutDigits_ReturnsRoundedValue()
    {
        // Arrange
        var input = 3.7;

        // Act
        var result = input.Round();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Round_DoubleWithDigits_ReturnsRoundedValue()
    {
        // Arrange
        var input = 3.14159;
        var digits = 2;

        // Act
        var result = input.Round(digits);

        // Assert
        Assert.Equal(3.14, result);
    }

    [Fact]
    public void Round_NegativeDoubleWithDigits_ReturnsRoundedValue()
    {
        // Arrange
        var input = -3.14159;
        var digits = 2;

        // Act
        var result = input.Round(digits);

        // Assert
        Assert.Equal(-3.14, result);
    }
    #endregion

    #region Rounds
    [Fact]
    public void Rounds_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Rounds();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Rounds_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Rounds();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Rounds_DoubleEnumerableWithoutDigits_ReturnsRoundedValues()
    {
        // Arrange
        var input = new[] { 1.1, 2.7, 3.5, -4.2 };

        // Act
        var result = input.Rounds();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1.0, 3.0, 4.0, -4.0 }, result);
    }

    [Fact]
    public void Rounds_DoubleEnumerableWithDigits_ReturnsRoundedValues()
    {
        // Arrange
        var input = new[] { 1.11, 2.77, 3.55, -4.22 };
        var digits = 1;

        // Act
        var result = input.Rounds(digits);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1.1, 2.8, 3.6, -4.2 }, result);
    }

    [Fact]
    public void Rounds_Params_DoubleArray_ReturnsRoundedValues()
    {
        // Arrange
        var obj = 1.1;

        // Act
        var result = YANMath.Rounds(obj, 2.7, 3.5, -4.2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new[] { 1.0, 3.0, 4.0, -4.0 }, result);
    }
    #endregion

    #region Sqrt
    [Fact]
    public void Sqrt_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Sqrt();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sqrt_PositiveDouble_ReturnsSqrtValue()
    {
        // Arrange
        var input = 16.0;

        // Act
        var result = input.Sqrt();

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void Sqrt_Zero_ReturnsZero()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.Sqrt();

        // Assert
        Assert.Equal(0.0, result);
    }
    #endregion

    #region Sqrts
    [Fact]
    public void Sqrts_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Sqrts();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sqrts_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Sqrts();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Sqrts_DoubleEnumerable_ReturnsSqrtValues()
    {
        // Arrange
        var input = new[] { 4.0, 9.0, 16.0, 25.0 };
        var expected = new[] { 2.0, 3.0, 4.0, 5.0 };

        // Act
        var result = input.Sqrts();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sqrts_Params_DoubleArray_ReturnsSqrtValues()
    {
        // Arrange
        var expected = new[] { 2.0, 3.0, 4.0, 5.0 };

        // Act
        var result = YANMath.Sqrts(4.0, 9.0, 16.0, 25.0);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Pow
    [Fact]
    public void Pow_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;
        double power = 2;

        // Act
        var result = input.Pow(power);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Pow_NullPower_ReturnsDefault()
    {
        // Arrange
        double input = 2;
        double? power = null;

        // Act
        var result = input.Pow(power);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Pow_DoubleWithPower_ReturnsPowValue()
    {
        // Arrange
        var input = 2.0;
        var power = 3.0;

        // Act
        var result = input.Pow(power);

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void Pow_NegativeBaseWithIntegerPower_ReturnsPowValue()
    {
        // Arrange
        var input = -2.0;
        var power = 2.0;

        // Act
        var result = input.Pow(power);

        // Assert
        Assert.Equal(4.0, result);
    }
    #endregion

    #region Pows
    [Fact]
    public void Pows_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;
        double power = 2;

        // Act
        var result = input.Pows(power);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Pows_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();
        double power = 2;

        // Act
        var result = input.Pows(power);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Pows_DoubleEnumerable_ReturnsPowValues()
    {
        // Arrange
        var input = new[] { 1.0, 2.0, 3.0, 4.0 };
        double power = 2;
        var expected = new[] { 1.0, 4.0, 9.0, 16.0 };

        // Act
        var result = input.Pows(power);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Abs
    [Fact]
    public void Abs_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Abs();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Abs_PositiveDouble_ReturnsSameValue()
    {
        // Arrange
        var input = 5.5;

        // Act
        var result = input.Abs();

        // Assert
        Assert.Equal(5.5, result);
    }

    [Fact]
    public void Abs_NegativeDouble_ReturnsPositiveValue()
    {
        // Arrange
        var input = -5.5;

        // Act
        var result = input.Abs();

        // Assert
        Assert.Equal(5.5, result);
    }

    [Fact]
    public void Abs_Zero_ReturnsZero()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.Abs();

        // Assert
        Assert.Equal(0.0, result);
    }
    #endregion

    #region Abss
    [Fact]
    public void Abss_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Abss();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Abss_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Abss();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Abss_DoubleEnumerable_ReturnsAbsValues()
    {
        // Arrange
        var input = new[] { 1.1, -2.2, 3.3, -4.4 };
        var expected = new[] { 1.1, 2.2, 3.3, 4.4 };

        // Act
        var result = input.Abss();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Abss_Params_DoubleArray_ReturnsAbsValues()
    {
        // Arrange
        var expected = new[] { 1.1, 2.2, 3.3, 4.4 };

        // Act
        var result = YANMath.Abss(1.1, -2.2, 3.3, -4.4);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Log
    [Fact]
    public void Log_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log_PositiveDoubleWithoutBase_ReturnsNaturalLogValue()
    {
        // Arrange
        var input = Math.E;

        // Act
        var result = input.Log();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }

    [Fact]
    public void Log_PositiveDoubleWithBase_ReturnsLogValue()
    {
        // Arrange
        var input = 100.0;
        var baseValue = 10.0;

        // Act
        var result = input.Log(baseValue);

        // Assert
        Assert.Equal(2.0, result);
    }
    #endregion

    #region Logs
    [Fact]
    public void Logs_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Logs();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Logs_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Logs();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Logs_DoubleEnumerableWithoutBase_ReturnsNaturalLogValues()
    {
        // Arrange
        var input = new[] { 1.0, Math.E, Math.E * Math.E };

        // Act
        var result = input.Logs();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(2.0, item, 0.0001));
    }

    [Fact]
    public void Logs_DoubleEnumerableWithBase_ReturnsLogValues()
    {
        // Arrange
        var input = new[] { 1.0, 10.0, 100.0 };
        var baseValue = 10.0;
        var expected = new[] { 0.0, 1.0, 2.0 };

        // Act
        var result = input.Logs(baseValue);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Logs_Params_DoubleArray_ReturnsLogValues()
    {
        // Arrange
        var obj = 1.0;

        // Act
        var result = YANMath.Logs(obj, 10.0, 100.0);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.Log(10.0), item, 0.0001), item => Assert.Equal(Math.Log(100.0), item, 0.0001));
    }
    #endregion

    #region Log10
    [Fact]
    public void Log10_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log10();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log10_PositiveDouble_ReturnsLog10Value()
    {
        // Arrange
        var input = 100.0;

        // Act
        var result = input.Log10();

        // Assert
        Assert.Equal(2.0, result);
    }
    #endregion

    #region Log10s
    [Fact]
    public void Log10s_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Log10s();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log10s_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Log10s();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Log10s_DoubleEnumerable_ReturnsLog10Values()
    {
        // Arrange
        var input = new[] { 1.0, 10.0, 100.0, 1000.0 };
        var expected = new[] { 0.0, 1.0, 2.0, 3.0 };

        // Act
        var result = input.Log10s();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Log10s_Params_DoubleArray_ReturnsLog10Values()
    {
        // Arrange
        var expected = new[] { 0.0, 1.0, 2.0, 3.0 };

        // Act
        var result = YANMath.Log10s(1.0, 10.0, 100.0, 1000.0);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Log2
    [Fact]
    public void Log2_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Log2();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Log2_PositiveDouble_ReturnsLog2Value()
    {
        // Arrange
        var input = 8.0;

        // Act
        var result = input.Log2();

        // Assert
        Assert.Equal(3.0, result);
    }
    #endregion

    #region Log2s
    [Fact]
    public void Log2s_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Log2s();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log2s_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Log2s();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Log2s_DoubleEnumerable_ReturnsLog2Values()
    {
        // Arrange
        var input = new[] { 1.0, 2.0, 4.0, 8.0 };
        var expected = new[] { 0.0, 1.0, 2.0, 3.0 };

        // Act
        var result = input.Log2s();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Log2s_Params_DoubleArray_ReturnsLog2Values()
    {
        // Arrange
        var expected = new[] { 0.0, 1.0, 2.0, 3.0 };

        // Act
        var result = YANMath.Log2s(1.0, 2.0, 4.0, 8.0);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Sin
    [Fact]
    public void Sin_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Sin();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Sin_ZeroRadians_ReturnsZero()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.Sin();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void Sin_PiOver2Radians_ReturnsOne()
    {
        // Arrange
        var input = Math.PI / 2;

        // Act
        var result = input.Sin();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }
    #endregion

    #region Sins
    [Fact]
    public void Sins_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Sins();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sins_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Sins();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Sins_DoubleEnumerable_ReturnsSinValues()
    {
        // Arrange
        var input = new[] { 0.0, Math.PI / 2, Math.PI };

        // Act
        var result = input.Sins();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001));
    }

    [Fact]
    public void Sins_Params_DoubleArray_ReturnsSinValues()
    {
        // Arrange
        var obj = 0.0;

        // Act
        var result = YANMath.Sins(obj, Math.PI / 2, Math.PI);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001));
    }
    #endregion

    #region Cos
    [Fact]
    public void Cos_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Cos();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Cos_ZeroRadians_ReturnsOne()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.Cos();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }

    [Fact]
    public void Cos_PiRadians_ReturnsMinusOne()
    {
        // Arrange
        var input = Math.PI;

        // Act
        var result = input.Cos();

        // Assert
        Assert.Equal(-1.0, result, 0.0001);
    }
    #endregion

    #region Coss
    [Fact]
    public void Coss_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Coss();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Coss_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Coss();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Coss_DoubleEnumerable_ReturnsCosValues()
    {
        // Arrange
        var input = new[] { 0.0, Math.PI / 2, Math.PI };

        // Act
        var result = input.Coss();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(-1.0, item, 0.0001));
    }

    [Fact]
    public void Coss_Params_DoubleArray_ReturnsCosValues()
    {
        // Arrange
        var obj = 0.0;

        // Act
        var result = YANMath.Coss(obj, Math.PI / 2, Math.PI);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(-1.0, item, 0.0001));
    }
    #endregion

    #region Tan
    [Fact]
    public void Tan_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Tan();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Tan_ZeroRadians_ReturnsZero()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.Tan();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void Tan_PiOver4Radians_ReturnsOne()
    {
        // Arrange
        var input = Math.PI / 4;

        // Act
        var result = input.Tan();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }
    #endregion

    #region Tans
    [Fact]
    public void Tans_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Tans();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Tans_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Tans();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Tans_DoubleEnumerable_ReturnsTanValues()
    {
        // Arrange
        var input = new[] { 0.0, Math.PI / 4, Math.PI };

        // Act
        var result = input.Tans();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001));
    }

    [Fact]
    public void Tans_Params_DoubleArray_ReturnsTanValues()
    {
        // Arrange
        var obj = 0.0;

        // Act
        var result = YANMath.Tans(obj, Math.PI / 4, Math.PI);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(0.0, item, 0.0001));
    }
    #endregion

    #region Asin
    [Fact]
    public void Asin_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Asin();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Asin_ZeroValue_ReturnsZero()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.Asin();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void Asin_OneValue_ReturnsPiOverTwo()
    {
        // Arrange
        var input = 1.0;

        // Act
        var result = input.Asin();

        // Assert
        Assert.Equal(Math.PI / 2, result, 0.0001);
    }

    [Fact]
    public void Asin_MinusOneValue_ReturnsMinusPiOverTwo()
    {
        // Arrange
        var input = -1.0;

        // Act
        var result = input.Asin();

        // Assert
        Assert.Equal(-Math.PI / 2, result, 0.0001);
    }
    #endregion

    #region Asins
    [Fact]
    public void Asins_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Asins();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Asins_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Asins();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Asins_DoubleEnumerable_ReturnsAsinValues()
    {
        // Arrange
        var input = new[] { 0.0, 0.5, 1.0, -1.0 };

        // Act
        var result = input.Asins();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.Asin(0.5), item, 0.0001), item => Assert.Equal(Math.PI / 2, item, 0.0001), item => Assert.Equal(-Math.PI / 2, item, 0.0001));
    }

    [Fact]
    public void Asins_Params_DoubleArray_ReturnsAsinValues()
    {
        // Arrange
        var obj = 0.0;

        // Act
        var result = YANMath.Asins(obj, 0.5, 1.0, -1.0);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.Asin(0.5), item, 0.0001), item => Assert.Equal(Math.PI / 2, item, 0.0001), item => Assert.Equal(-Math.PI / 2, item, 0.0001));
    }
    #endregion

    #region Acos
    [Fact]
    public void Acos_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Acos();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Acos_OneValue_ReturnsZero()
    {
        // Arrange
        var input = 1.0;

        // Act
        var result = input.Acos();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void Acos_ZeroValue_ReturnsPiOverTwo()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.Acos();

        // Assert
        Assert.Equal(Math.PI / 2, result, 0.0001);
    }

    [Fact]
    public void Acos_MinusOneValue_ReturnsPi()
    {
        // Arrange
        var input = -1.0;

        // Act
        var result = input.Acos();

        // Assert
        Assert.Equal(Math.PI, result, 0.0001);
    }
    #endregion

    #region Acoss
    [Fact]
    public void Acoss_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Acoss();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Acoss_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Acoss();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Acoss_DoubleEnumerable_ReturnsAcosValues()
    {
        // Arrange
        var input = new[] { 1.0, 0.5, 0.0, -1.0 };

        // Act
        var result = input.Acoss();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.Acos(0.5), item, 0.0001), item => Assert.Equal(Math.PI / 2, item, 0.0001), item => Assert.Equal(Math.PI, item, 0.0001));
    }

    [Fact]
    public void Acoss_Params_DoubleArray_ReturnsAcosValues()
    {
        // Arrange
        var obj = 1.0;

        // Act
        var result = YANMath.Acoss(obj, 0.5, 0.0, -1.0);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.Acos(0.5), item, 0.0001), item => Assert.Equal(Math.PI / 2, item, 0.0001), item => Assert.Equal(Math.PI, item, 0.0001));
    }
    #endregion

    #region Atan
    [Fact]
    public void Atan_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Atan();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Atan_ZeroValue_ReturnsZero()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.Atan();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void Atan_OneValue_ReturnsPiOverFour()
    {
        // Arrange
        var input = 1.0;

        // Act
        var result = input.Atan();

        // Assert
        Assert.Equal(Math.PI / 4, result, 0.0001);
    }

    [Fact]
    public void Atan_NegativeOneValue_ReturnsMinusPiOverFour()
    {
        // Arrange
        var input = -1.0;

        // Act
        var result = input.Atan();

        // Assert
        Assert.Equal(-Math.PI / 4, result, 0.0001);
    }

    [Fact]
    public void Atan_VeryLargeValue_ApproachesPiOverTwo()
    {
        // Arrange
        var input = 1000000.0;

        // Act
        var result = input.Atan();

        // Assert
        Assert.InRange(result, Math.PI / 2 - 0.001, Math.PI / 2);
    }
    #endregion

    #region Atans
    [Fact]
    public void Atans_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Atans();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Atans_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Atans();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Atans_DoubleEnumerable_ReturnsAtanValues()
    {
        // Arrange
        var input = new[] { 0.0, 1.0, -1.0 };

        // Act
        var result = input.Atans();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.PI / 4, item, 0.0001), item => Assert.Equal(-Math.PI / 4, item, 0.0001));
    }

    [Fact]
    public void Atans_Params_DoubleArray_ReturnsAtanValues()
    {
        // Act
        var result = YANMath.Atans(0.0, 1.0, -1.0);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(Math.PI / 4, item, 0.0001), item => Assert.Equal(-Math.PI / 4, item, 0.0001));
    }
    #endregion

    #region Cbrt
    [Fact]
    public void Cbrt_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Cbrt();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Cbrt_ZeroValue_ReturnsZero()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.Cbrt();

        // Assert
        Assert.Equal(0.0, result, 0.0001);
    }

    [Fact]
    public void Cbrt_PositiveValue_ReturnsCubeRoot()
    {
        // Arrange
        var input = 27.0;

        // Act
        var result = input.Cbrt();

        // Assert
        Assert.Equal(3.0, result, 0.0001);
    }

    [Fact]
    public void Cbrt_NegativeValue_ReturnsNegativeCubeRoot()
    {
        // Arrange
        var input = -27.0;

        // Act
        var result = input.Cbrt();

        // Assert
        Assert.Equal(-3.0, result, 0.0001);
    }
    #endregion

    #region Cbrts
    [Fact]
    public void Cbrts_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Cbrts();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Cbrts_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Cbrts();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Cbrts_DoubleEnumerable_ReturnsCbrtValues()
    {
        // Arrange
        var input = new[] { 0.0, 8.0, 27.0, -27.0 };

        // Act
        var result = input.Cbrts();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(2.0, item, 0.0001), item => Assert.Equal(3.0, item, 0.0001), item => Assert.Equal(-3.0, item, 0.0001));
    }

    [Fact]
    public void Cbrts_Params_DoubleArray_ReturnsCbrtValues()
    {
        // Arrange
        var obj = 0.0;

        // Act
        var result = YANMath.Cbrts(obj, 8.0, 27.0, -27.0);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(0.0, item, 0.0001), item => Assert.Equal(2.0, item, 0.0001), item => Assert.Equal(3.0, item, 0.0001), item => Assert.Equal(-3.0, item, 0.0001));
    }
    #endregion

    #region Exp
    [Fact]
    public void Exp_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Exp();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Exp_ZeroValue_ReturnsOne()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.Exp();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }

    [Fact]
    public void Exp_OneValue_ReturnsE()
    {
        // Arrange
        var input = 1.0;

        // Act
        var result = input.Exp();

        // Assert
        Assert.Equal(Math.E, result, 0.0001);
    }

    [Fact]
    public void Exp_NegativeValue_ReturnsExpValue()
    {
        // Arrange
        var input = -1.0;

        // Act
        var result = input.Exp();

        // Assert
        Assert.Equal(1.0 / Math.E, result, 0.0001);
    }
    #endregion

    #region Exps
    [Fact]
    public void Exps_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Exps();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exps_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Exps();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Exps_DoubleEnumerable_ReturnsExpValues()
    {
        // Arrange
        var input = new[] { 0.0, 1.0, -1.0 };

        // Act
        var result = input.Exps();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(Math.E, item, 0.0001), item => Assert.Equal(1.0 / Math.E, item, 0.0001));
    }

    [Fact]
    public void Exps_Params_DoubleArray_ReturnsExpValues()
    {
        // Arrange
        var obj = 0.0;

        // Act
        var result = YANMath.Exps(obj, 1.0, -1.0);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(Math.E, item, 0.0001), item => Assert.Equal(1.0 / Math.E, item, 0.0001));
    }
    #endregion

    #region Exp2
    [Fact]
    public void Exp2_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.Exp2();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void Exp2_ZeroValue_ReturnsOne()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.Exp2();

        // Assert
        Assert.Equal(1.0, result, 0.0001);
    }

    [Fact]
    public void Exp2_OneValue_ReturnsTwo()
    {
        // Arrange
        var input = 1.0;

        // Act
        var result = input.Exp2();

        // Assert
        Assert.Equal(2.0, result, 0.0001);
    }

    [Fact]
    public void Exp2_ThreeValue_ReturnsEight()
    {
        // Arrange
        var input = 3.0;

        // Act
        var result = input.Exp2();

        // Assert
        Assert.Equal(8.0, result, 0.0001);
    }

    [Fact]
    public void Exp2_NegativeValue_ReturnsExp2Value()
    {
        // Arrange
        var input = -1.0;

        // Act
        var result = input.Exp2();

        // Assert
        Assert.Equal(0.5, result, 0.0001);
    }
    #endregion

    #region Exp2s
    [Fact]
    public void Exp2s_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.Exp2s();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exp2s_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.Exp2s();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Exp2s_DoubleEnumerable_ReturnsExp2Values()
    {
        // Arrange
        var input = new[] { 0.0, 1.0, 2.0, 3.0, -1.0 };

        // Act
        var result = input.Exp2s();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(2.0, item, 0.0001), item => Assert.Equal(4.0, item, 0.0001), item => Assert.Equal(8.0, item, 0.0001), item => Assert.Equal(0.5, item, 0.0001));
    }

    [Fact]
    public void Exp2s_Params_DoubleArray_ReturnsExp2Values()
    {
        // Arrange
        var obj = 0.0;

        // Act
        var result = YANMath.Exp2s(obj, 1.0, 2.0, 3.0, -1.0);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1.0, item, 0.0001), item => Assert.Equal(2.0, item, 0.0001), item => Assert.Equal(4.0, item, 0.0001), item => Assert.Equal(8.0, item, 0.0001), item => Assert.Equal(0.5, item, 0.0001));
    }
    #endregion

    #region ILogB
    [Fact]
    public void ILogB_NullValue_ReturnsDefault()
    {
        // Arrange
        double? input = null;

        // Act
        var result = input.ILogB();

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void ILogB_ZeroValue_ReturnsExpectedValue()
    {
        // Arrange
        var input = 0.0;

        // Act
        var result = input.ILogB();

        // Assert
        Assert.Equal(Math.ILogB(0.0), result);
    }

    [Fact]
    public void ILogB_PowerOfTwoValue_ReturnsExponent()
    {
        // Arrange
        var input = 16.0;

        // Act
        var result = input.ILogB();

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void ILogB_NonPowerOfTwoValue_ReturnsFloorOfLog2()
    {
        // Arrange
        var input = 10.0;

        // Act
        var result = input.ILogB();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void ILogB_NegativeValue_ReturnsExponentOfAbsoluteValue()
    {
        // Arrange
        var input = -16.0;

        // Act
        var result = input.ILogB();

        // Assert
        Assert.Equal(4, result);
    }
    #endregion

    #region ILogBs
    [Fact]
    public void ILogBs_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<double>? input = null;

        // Act
        var result = input.ILogBs();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ILogBs_EmptyEnumerable_ReturnsEmptyEnumerable()
    {
        // Arrange
        var input = Array.Empty<double>();

        // Act
        var result = input.ILogBs();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void ILogBs_DoubleEnumerable_ReturnsILogBValues()
    {
        // Arrange
        var input = new[] { 2.0, 4.0, 8.0, 16.0, 10.0 };

        // Act
        var result = input.ILogBs();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1, item), item => Assert.Equal(2, item), item => Assert.Equal(3, item), item => Assert.Equal(4, item), item => Assert.Equal(3, item));
    }

    [Fact]
    public void ILogBs_Params_DoubleArray_ReturnsILogBValues()
    {
        // Arrange
        var obj = 2.0;

        // Act
        var result = YANMath.ILogBs(obj, 4.0, 8.0, 16.0, 10.0);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result, item => Assert.Equal(1, item), item => Assert.Equal(2, item), item => Assert.Equal(3, item), item => Assert.Equal(4, item), item => Assert.Equal(3, item));
    }
    #endregion
}
