namespace YANLib.Tests.Library;

public partial class YANMathTest
{
    #region Truncates

    [Fact]
    public void Truncates_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Truncates_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Truncates_CollectionWithValues_ReturnsTruncatedValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 3.75, -2.25, 0.5 };

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, -2.0, 0.0 }, result);
    }

    [Fact]
    public void Truncates_CollectionWithNullValues_PreservesNulls_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 3.75, null, 0.5 };

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, default, 0.0 }, result);
    }

    [Fact]
    public void Truncates_ParamsOverload_ReturnsTruncatedValues_MathCollection()
    {
        // Act
        var result = YANMath.Truncates<double?>(3.75, -2.25, 0.5);

        // Assert
        Assert.Equal([3.0, -2.0, 0.0], result);
    }

    #endregion

    #region Ceilings

    [Fact]
    public void Ceilings_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Ceilings_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Ceilings_CollectionWithValues_ReturnsCeilingValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 3.75, -2.25, 0.5 };

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.Equal(new List<double> { 4.0, -2.0, 1.0 }, result);
    }

    [Fact]
    public void Ceilings_CollectionWithNullValues_PreservesNulls_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 3.75, null, 0.5 };

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.Equal(new List<double> { 4.0, default, 1.0 }, result);
    }

    [Fact]
    public void Ceilings_ParamsOverload_ReturnsCeilingValues_MathCollection()
    {
        // Act
        var result = YANMath.Ceilings<double?>(3.75, -2.25, 0.5);

        // Assert
        Assert.Equal([4.0, -2.0, 1.0], result);
    }

    #endregion

    #region Floors

    [Fact]
    public void Floors_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Floors_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Floors_CollectionWithValues_ReturnsFloorValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 3.75, -2.25, 0.5 };

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, -3.0, 0.0 }, result);
    }

    [Fact]
    public void Floors_CollectionWithNullValues_PreservesNulls_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 3.75, null, 0.5 };

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, default, 0.0 }, result);
    }

    [Fact]
    public void Floors_ParamsOverload_ReturnsFloorValues_MathCollection()
    {
        // Act
        var result = YANMath.Floors<double?>(3.75, -2.25, 0.5);

        // Assert
        Assert.Equal([3.0, -3.0, 0.0], result);
    }

    #endregion

    #region Rounds

    [Fact]
    public void Rounds_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Rounds_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Rounds_CollectionWithValues_ReturnsRoundedValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 3.75, -2.25, 0.5 };

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.Equal(new List<double> { 4.0, -2.0, 0.0 }, result);
    }

    [Fact]
    public void Rounds_CollectionWithNullValues_PreservesNulls_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 3.75, null, 0.5 };

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.Equal(new List<double> { 4.0, default, 0.0 }, result);
    }

    [Fact]
    public void Rounds_WithDigits_ReturnsRoundedValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 3.14159, 2.71828 };

        // Act
        var result = input.Rounds<double>(2);

        // Assert
        Assert.Equal(new List<double> { 3.14, 2.72 }, result);
    }

    [Fact]
    public void Rounds_WithMidpointRounding_ReturnsRoundedValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 2.5, 3.5 };

        // Act
        var result = input.Rounds<double>(0, MidpointRounding.ToEven);

        // Assert
        Assert.Equal(new List<double> { 2.0, 4.0 }, result);
    }

    #endregion

    #region Sqrts

    [Fact]
    public void Sqrts_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sqrts_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Sqrts_CollectionWithValues_ReturnsSqrtValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 4.0, 9.0, 16.0 };

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.Equal(new List<double> { 2.0, 3.0, 4.0 }, result);
    }

    [Fact]
    public void Sqrts_CollectionWithNullValues_PreservesNulls_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 4.0, null, 16.0 };

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.Equal(new List<double> { 2.0, default, 4.0 }, result);
    }

    [Fact]
    public void Sqrts_ParamsOverload_ReturnsSqrtValues_MathCollection()
    {
        // Act
        var result = YANMath.Sqrts<double?>(4.0, 9.0, 16.0);

        // Assert
        Assert.Equal([2.0, 3.0, 4.0], result);
    }

    #endregion

    #region Pows

    [Fact]
    public void Pows_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Pows<double>(2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Pows_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Pows<double>(2);

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Pows_CollectionWithValues_ReturnsPowValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 2.0, 3.0, 4.0 };

        // Act
        var result = input.Pows<double>(2);

        // Assert
        Assert.Equal(new List<double> { 4.0, 9.0, 16.0 }, result);
    }

    [Fact]
    public void Pows_CollectionWithNullValues_PreservesNulls_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 2.0, null, 4.0 };

        // Act
        var result = input.Pows<double>(2);

        // Assert
        Assert.Equal(new List<double> { 4.0, default, 16.0 }, result);
    }

    #endregion

    #region Abss

    [Fact]
    public void Abss_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Abss_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Abss_CollectionWithValues_ReturnsAbsValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 3.0, -2.0, 0.0 };

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, 2.0, 0.0 }, result);
    }

    [Fact]
    public void Abss_CollectionWithNullValues_PreservesNulls_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 3.0, null, -2.0 };

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, default, 2.0 }, result);
    }

    [Fact]
    public void Abss_ParamsOverload_ReturnsAbsValues_MathCollection()
    {
        // Act
        var result = YANMath.Abss<double?>(3.0, -2.0, 0.0);

        // Assert
        Assert.Equal([3.0, 2.0, 0.0], result);
    }

    #endregion

    #region Logs

    [Fact]
    public void Logs_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Logs_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Logs_CollectionWithValues_ReturnsLogValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { Math.E, Math.E * Math.E };

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0 }, result);
    }

    [Fact]
    public void Logs_CollectionWithNullValues_PreservesNulls_MathCollection()
    {
        // Arrange
        var input = new List<double?> { Math.E, null, Math.E * Math.E };

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, default, 2.0 }, result);
    }

    [Fact]
    public void Logs_WithBase_ReturnsLogValues_MathCollection()
    {
        // Arrange
        var input = new List<object?> { 10.0, 100.0, 1000.0 };

        // Act
        var result = input.Logs<double>(10);

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0, 3.0 }, result);
    }

    #endregion

    #region Log10s

    [Fact]
    public void Log10s_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log10s_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Log10s_CollectionWithValues_ReturnsLog10Values_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 10.0, 100.0, 1000.0 };

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0, 3.0 }, result);
    }

    [Fact]
    public void Log10s_CollectionWithNullValues_PreservesNulls_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 10.0, null, 1000.0 };

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, default, 3.0 }, result);
    }

    [Fact]
    public void Log10s_ParamsOverload_ReturnsLog10Values_MathCollection()
    {
        // Act
        var result = YANMath.Log10s<double?>(10.0, 100.0, 1000.0);

        // Assert
        Assert.Equal([1.0, 2.0, 3.0], result);
    }

    #endregion

    #region Log2s

    [Fact]
    public void Log2s_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log2s_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Log2s_CollectionWithValues_ReturnsLog2Values_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 2.0, 4.0, 8.0 };

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0, 3.0 }, result);
    }

    [Fact]
    public void Log2s_CollectionWithNullValues_PreservesNulls_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 2.0, null, 8.0 };

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, default, 3.0 }, result);
    }

    [Fact]
    public void Log2s_ParamsOverload_ReturnsLog2Values_MathCollection()
    {
        // Act
        var result = YANMath.Log2s<double?>(2.0, 4.0, 8.0);

        // Assert
        Assert.Equal([1.0, 2.0, 3.0], result);
    }

    #endregion

    #region Sins

    [Fact]
    public void Sins_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Sins<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sins_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Sins<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Sins_CollectionWithValues_ReturnsSinValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 0.0, Math.PI / 2, Math.PI };

        // Act
        var result = input.Sins<double>();

        // Assert
        Assert.Collection(result!, item => Assert.Equal(0.0, item), item => Assert.Equal(1.0, item, 15), item => Assert.Equal(0.0, item, 15));
    }

    #endregion

    #region Coss

    [Fact]
    public void Coss_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Coss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Coss_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Coss<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Coss_CollectionWithValues_ReturnsCosValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 0.0, Math.PI / 2, Math.PI };

        // Act
        var result = input.Coss<double>();

        // Assert
        Assert.Collection(result!, item => Assert.Equal(1.0, item), item => Assert.Equal(0.0, item, 15), item => Assert.Equal(-1.0, item, 15));
    }

    #endregion

    #region Tans

    [Fact]
    public void Tans_NullCollection_ReturnsNull_MathCollection()
    {
        // Arrange
        IEnumerable<double?>? input = null;

        // Act
        var result = input.Tans<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Tans_EmptyCollection_ReturnsEmptyCollection_MathCollection()
    {
        // Arrange
        var input = new List<double?>();

        // Act
        var result = input.Tans<double>();

        // Assert
        Assert.Empty(result!);
    }

    [Fact]
    public void Tans_CollectionWithValues_ReturnsTanValues_MathCollection()
    {
        // Arrange
        var input = new List<double?> { 0.0, Math.PI / 4 };

        // Act
        var result = input.Tans<double>();

        // Assert
        Assert.Collection(result!, item => Assert.Equal(0.0, item), item => Assert.Equal(1.0, item, 15));
    }

    #endregion
}
