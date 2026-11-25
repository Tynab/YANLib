using System.Numerics;

namespace YANLib.Tests.Library;

public partial class YANMathTest
{
    #region IsEven / IsOdd

    [Theory]
    [InlineData(0, true)]
    [InlineData(4, true)]
    [InlineData(-2, true)]
    [InlineData(3, false)]
    [InlineData(-3, false)]
    [InlineData(int.MaxValue, false)]
    [InlineData(int.MinValue, true)]
    public void IsEvenIsOdd_Int32_ReturnsParity_Math(int input, bool even)
    {
        // Act & Assert
        Assert.Equal(even, input.IsEven());
        Assert.Equal(!even, input.IsOdd());
    }

    [Fact]
    public void IsEvenIsOdd_OtherIntegerTypes_ReturnParity_Math()
    {
        // Act & Assert
        Assert.True(((byte)8).IsEven());
        Assert.True(((sbyte)-7).IsOdd());
        Assert.True(long.MinValue.IsEven());
        Assert.True(ulong.MaxValue.IsOdd());
        Assert.True(((nint)10).IsEven());
        Assert.True(UInt128.MaxValue.IsOdd());
        Assert.True(BigInteger.Pow(10, 30).IsEven());
        Assert.True((BigInteger.Pow(10, 30) + 1).IsOdd());
    }

    [Theory]
    [InlineData(4.0, true, false)]
    [InlineData(3.0, false, true)]
    [InlineData(-0.0, true, false)]
    [InlineData(4.5, false, false)]
    [InlineData(double.NaN, false, false)]
    [InlineData(double.PositiveInfinity, false, false)]
    [InlineData(1e300, true, false)]
    public void IsEvenIsOdd_Double_ReturnsTrueOnlyForIntegers_Math(double input, bool even, bool odd)
    {
        // Act & Assert
        Assert.Equal(even, input.IsEven());
        Assert.Equal(odd, input.IsOdd());
    }

    [Fact]
    public void IsEvenIsOdd_DecimalAndFloat_ReturnTrueOnlyForIntegers_Math()
    {
        // Act & Assert
        Assert.True(4.0m.IsEven());
        Assert.True(3m.IsOdd());
        Assert.False(4.5m.IsEven());
        Assert.False(4.5m.IsOdd());
        Assert.True(2f.IsEven());
        Assert.False(float.NaN.IsOdd());
    }

    [Fact]
    public void IsEvenIsOdd_Nullable_NullIsNeither_Math()
    {
        // Arrange
        int? none = null;
        int? four = 4;
        double? three = 3.0;
        decimal? half = 0.5m;

        // Act & Assert
        Assert.False(none.IsEven());
        Assert.False(none.IsOdd());
        Assert.True(four.IsEven());
        Assert.False(four.IsOdd());
        Assert.True(three.IsOdd());
        Assert.False(half.IsEven());
        Assert.False(half.IsOdd());
    }

    #endregion
}
