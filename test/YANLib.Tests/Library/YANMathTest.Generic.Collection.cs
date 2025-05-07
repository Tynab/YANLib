namespace YANLib.Tests.Library;

public partial class YANMathTest
{
    #region Truncates

    [Fact]
    public void Truncates_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Truncates_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Truncates_CollectionWithValues_ReturnsTruncatedValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, -2.25, 0.5 };

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, -2.0, 0.0 }, result);
    }

    [Fact]
    public void Truncates_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, null, 0.5 };

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, default, 0.0 }, result);
    }

    [Fact]
    public void Truncates_CollectionWithMixedTypes_ConvertsAndTruncates_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, "-2.25", 0.5 };

        // Act
        var result = input.Truncates<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, -2.0, 0.0 }, result);
    }

    [Fact]
    public void Truncates_ParamsOverload_ReturnsTruncatedValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.Truncates<double?>(3.75, -2.25, 0.5);

        // Assert
        Assert.Equal([3.0, -2.0, 0.0], result);
    }

    #endregion

    #region Ceilings

    [Fact]
    public void Ceilings_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Ceilings_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Ceilings_CollectionWithValues_ReturnsCeilingValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, -2.25, 0.5 };

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.Equal(new List<double> { 4.0, -2.0, 1.0 }, result);
    }

    [Fact]
    public void Ceilings_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, null, 0.5 };

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.Equal(new List<double> { 4.0, default, 1.0 }, result);
    }

    [Fact]
    public void Ceilings_CollectionWithMixedTypes_ConvertsAndCeils_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, "-2.25", 0.5 };

        // Act
        var result = input.Ceilings<double>();

        // Assert
        Assert.Equal(new List<double> { 4.0, -2.0, 1.0 }, result);
    }

    [Fact]
    public void Ceilings_ParamsOverload_ReturnsCeilingValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.Ceilings<double?>(3.75, -2.25, 0.5);

        // Assert
        Assert.Equal([4.0, -2.0, 1.0], result);
    }

    #endregion

    #region Floors

    [Fact]
    public void Floors_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Floors_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Floors_CollectionWithValues_ReturnsFloorValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, -2.25, 0.5 };

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, -3.0, 0.0 }, result);
    }

    [Fact]
    public void Floors_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, null, 0.5 };

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, default, 0.0 }, result);
    }

    [Fact]
    public void Floors_CollectionWithMixedTypes_ConvertsAndFloors_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, "-2.25", 0.5 };

        // Act
        var result = input.Floors<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, -3.0, 0.0 }, result);
    }

    [Fact]
    public void Floors_ParamsOverload_ReturnsFloorValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.Floors<double?>(3.75, -2.25, 0.5);

        // Assert
        Assert.Equal([3.0, -3.0, 0.0], result);
    }

    #endregion

    #region Rounds

    [Fact]
    public void Rounds_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Rounds_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Rounds_CollectionWithValues_ReturnsRoundedValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, -2.25, 0.5 };

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.Equal(new List<double> { 4.0, -2.0, 1.0 }, result);
    }

    [Fact]
    public void Rounds_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, null, 0.5 };

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.Equal(new List<double> { 4.0, default, 1.0 }, result);
    }

    [Fact]
    public void Rounds_CollectionWithMixedTypes_ConvertsAndRounds_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.75, "-2.25", 0.5 };

        // Act
        var result = input.Rounds<double>();

        // Assert
        Assert.Equal(new List<double> { 4.0, -2.0, 1.0 }, result);
    }

    [Fact]
    public void Rounds_WithDigits_ReturnsRoundedValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.14159, 2.71828 };

        // Act
        var result = input.Rounds<double>(2);

        // Assert
        Assert.Equal(new List<double> { 3.14, 2.72 }, result);
    }

    [Fact]
    public void Rounds_WithMidpointRounding_ReturnsRoundedValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 2.5, 3.5 };

        // Act
        var result = input.Rounds<double>(0, MidpointRounding.ToEven);

        // Assert
        Assert.Equal(new List<double> { 2.0, 4.0 }, result);
    }

    [Fact]
    public void Rounds_ParamsOverload_ReturnsRoundedValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.Rounds<double?>(3.75, -2.25, 0.5);

        // Assert
        Assert.Equal([4.0, -2.0, 1.0], result);
    }

    #endregion

    #region Sqrts

    [Fact]
    public void Sqrts_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sqrts_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sqrts_CollectionWithValues_ReturnsSqrtValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 4.0, 9.0, 16.0 };

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.Equal(new List<double> { 2.0, 3.0, 4.0 }, result);
    }

    [Fact]
    public void Sqrts_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 4.0, null, 16.0 };

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.Equal(new List<double> { 2.0, default, 4.0 }, result);
    }

    [Fact]
    public void Sqrts_CollectionWithMixedTypes_ConvertsAndCalculatesSqrt_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 4.0, "9.0", 16.0 };

        // Act
        var result = input.Sqrts<double>();

        // Assert
        Assert.Equal(new List<double> { 2.0, 3.0, 4.0 }, result);
    }

    [Fact]
    public void Sqrts_ParamsOverload_ReturnsSqrtValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.Sqrts<double?>(4.0, 9.0, 16.0);

        // Assert
        Assert.Equal([2.0, 3.0, 4.0], result);
    }

    #endregion

    #region Pows

    [Fact]
    public void Pows_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Pows<double>(2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Pows_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Pows<double>(2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Pows_CollectionWithValues_ReturnsPowValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 2.0, 3.0, 4.0 };

        // Act
        var result = input.Pows<double>(2);

        // Assert
        Assert.Equal(new List<double> { 4.0, 9.0, 16.0 }, result);
    }

    [Fact]
    public void Pows_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 2.0, null, 4.0 };

        // Act
        var result = input.Pows<double>(2);

        // Assert
        Assert.Equal(new List<double> { 4.0, default, 16.0 }, result);
    }

    [Fact]
    public void Pows_CollectionWithMixedTypes_ConvertsAndCalculatesPow_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 2.0, "3.0", 4.0 };

        // Act
        var result = input.Pows<double>(2);

        // Assert
        Assert.Equal(new List<double> { 4.0, 9.0, 16.0 }, result);
    }

    #endregion

    #region Abss

    [Fact]
    public void Abss_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Abss_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Abss_CollectionWithValues_ReturnsAbsValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.0, -2.0, 0.0 };

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, 2.0, 0.0 }, result);
    }

    [Fact]
    public void Abss_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.0, null, -2.0 };

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, default, 2.0 }, result);
    }

    [Fact]
    public void Abss_CollectionWithMixedTypes_ConvertsAndCalculatesAbs_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 3.0, "-2.0", 0.0 };

        // Act
        var result = input.Abss<double>();

        // Assert
        Assert.Equal(new List<double> { 3.0, 2.0, 0.0 }, result);
    }

    [Fact]
    public void Abss_ParamsOverload_ReturnsAbsValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.Abss<double>(3.0, -2.0, 0.0);

        // Assert
        Assert.Equal(new List<double> { 3.0, 2.0, 0.0 }, result);
    }

    #endregion

    #region Sins

    [Fact]
    public void Sins_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Sins<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sins_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Sins<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Sins_CollectionWithValues_ReturnsSinValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, Math.PI / 2, Math.PI };

        // Act
        var result = input.Sins<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(1.0, item, 15), static item => Assert.Equal(0.0, item, 15));
    }

    [Fact]
    public void Sins_CollectionWithMixedTypes_ConvertsAndCalculatesSin_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, "1.5707963267948966", Math.PI };

        // Act
        var result = input.Sins<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(1.0, item, 15), static item => Assert.Equal(0.0, item, 15));
    }

    #endregion

    #region Coss

    [Fact]
    public void Coss_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Coss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Coss_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Coss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Coss_CollectionWithValues_ReturnsCosValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, Math.PI / 2, Math.PI };

        // Act
        var result = input.Coss<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(1.0, item), static item => Assert.Equal(0.0, item, 15), static item => Assert.Equal(-1.0, item, 15));
    }

    [Fact]
    public void Coss_CollectionWithMixedTypes_ConvertsAndCalculatesCos_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, "1.5707963267948966", Math.PI };

        // Act
        var result = input.Coss<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(1.0, item), static item => Assert.Equal(0.0, item, 15), static item => Assert.Equal(-1.0, item, 15));
    }

    #endregion

    #region Tans

    [Fact]
    public void Tans_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Tans<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Tans_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Tans<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Tans_CollectionWithValues_ReturnsTanValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, Math.PI / 4 };

        // Act
        var result = input.Tans<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(1.0, item, 15));
    }

    [Fact]
    public void Tans_CollectionWithMixedTypes_ConvertsAndCalculatesTan_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, "0.7853981633974483" };

        // Act
        var result = input.Tans<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(1.0, item, 15));
    }

    #endregion

    #region Asins

    [Fact]
    public void Asins_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Asins<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Asins_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Asins<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Asins_CollectionWithValues_ReturnsAsinValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, 1.0, -1.0 };

        // Act
        var result = input.Asins<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(Math.PI / 2, item), static item => Assert.Equal(-Math.PI / 2, item));
    }

    [Fact]
    public void Asins_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, null, 1.0 };

        // Act
        var result = input.Asins<double>();

        // Assert
        Assert.Equal(new List<double> { 0.0, default, Math.PI / 2 }, result);
    }

    [Fact]
    public void Asins_CollectionWithMixedTypes_ConvertsAndCalculatesAsin_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, "1.0", -1.0 };

        // Act
        var result = input.Asins<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(Math.PI / 2, item), static item => Assert.Equal(-Math.PI / 2, item));
    }

    [Fact]
    public void Asins_ParamsOverload_ReturnsAsinValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.Asins(0.0, 1.0, -1.0);

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(Math.PI / 2, item), static item => Assert.Equal(-Math.PI / 2, item));
    }

    #endregion

    #region Acoss

    [Fact]
    public void Acoss_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Acoss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Acoss_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Acoss<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Acoss_CollectionWithValues_ReturnsAcosValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 1.0, 0.0, -1.0 };

        // Act
        var result = input.Acoss<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(Math.PI / 2, item), static item => Assert.Equal(Math.PI, item));
    }

    [Fact]
    public void Acoss_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 1.0, null, -1.0 };

        // Act
        var result = input.Acoss<double>();

        // Assert
        Assert.Equal(new List<double> { 0.0, default, Math.PI }, result);
    }

    [Fact]
    public void Acoss_CollectionWithMixedTypes_ConvertsAndCalculatesAcos_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 1.0, "0.0", -1.0 };

        // Act
        var result = input.Acoss<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(Math.PI / 2, item), static item => Assert.Equal(Math.PI, item));
    }

    [Fact]
    public void Acoss_ParamsOverload_ReturnsAcosValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.Acoss(1.0, 0.0, -1.0);

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(Math.PI / 2, item), static item => Assert.Equal(Math.PI, item));
    }

    #endregion

    #region Atans

    [Fact]
    public void Atans_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Atans<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Atans_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Atans<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Atans_CollectionWithValues_ReturnsAtanValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, 1.0, -1.0 };

        // Act
        var result = input.Atans<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(Math.PI / 4, item), static item => Assert.Equal(-Math.PI / 4, item));
    }

    [Fact]
    public void Atans_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, null, 1.0 };

        // Act
        var result = input.Atans<double>();

        // Assert
        Assert.Equal(new List<double> { 0.0, default, Math.PI / 4 }, result);
    }

    [Fact]
    public void Atans_CollectionWithMixedTypes_ConvertsAndCalculatesAtan_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, "1.0", -1.0 };

        // Act
        var result = input.Atans<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(Math.PI / 4, item), static item => Assert.Equal(-Math.PI / 4, item));
    }

    [Fact]
    public void Atans_ParamsOverload_ReturnsAtanValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.Atans(0.0, 1.0, -1.0);

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(0.0, item), static item => Assert.Equal(Math.PI / 4, item), static item => Assert.Equal(-Math.PI / 4, item));
    }

    #endregion

    #region Cbrts

    [Fact]
    public void Cbrts_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Cbrts<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Cbrts_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Cbrts<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Cbrts_CollectionWithValues_ReturnsCbrtValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 8.0, 27.0, -27.0 };

        // Act
        var result = input.Cbrts<double>();

        // Assert
        Assert.Equal(new List<double> { 2.0, 3.0, -3.0 }, result);
    }

    [Fact]
    public void Cbrts_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 8.0, null, 27.0 };

        // Act
        var result = input.Cbrts<double>();

        // Assert
        Assert.Equal(new List<double> { 2.0, default, 3.0 }, result);
    }

    [Fact]
    public void Cbrts_CollectionWithMixedTypes_ConvertsAndCalculatesCbrt_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 8.0, "27.0", -27.0 };

        // Act
        var result = input.Cbrts<double>();

        // Assert
        Assert.Equal(new List<double> { 2.0, 3.0, -3.0 }, result);
    }

    [Fact]
    public void Cbrts_ParamsOverload_ReturnsCbrtValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.Cbrts<double?>(8.0, 27.0, -27.0);

        // Assert
        Assert.Equal([2.0, 3.0, -3.0], result);
    }

    #endregion

    #region Exps

    [Fact]
    public void Exps_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Exps<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exps_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Exps<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exps_CollectionWithValues_ReturnsExpValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, 1.0, 2.0 };

        // Act
        var result = input.Exps<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(1.0, item), static item => Assert.Equal(Math.E, item), static item => Assert.Equal(Math.E * Math.E, item, 14));
    }

    [Fact]
    public void Exps_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, null, 1.0 };

        // Act
        var result = input.Exps<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, default, Math.E }, result);
    }

    [Fact]
    public void Exps_CollectionWithMixedTypes_ConvertsAndCalculatesExp_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, "1.0", 2.0 };

        // Act
        var result = input.Exps<double>();

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(1.0, item), static item => Assert.Equal(Math.E, item), static item => Assert.Equal(Math.E * Math.E, item, 14));
    }

    [Fact]
    public void Exps_ParamsOverload_ReturnsExpValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.Exps(0.0, 1.0, 2.0);

        // Assert
        Assert.Collection(result!, static item => Assert.Equal(1.0, item), static item => Assert.Equal(Math.E, item), static item => Assert.Equal(Math.E * Math.E, item, 14));
    }

    #endregion

    #region Exp2s

    [Fact]
    public void Exp2s_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Exp2s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exp2s_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Exp2s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Exp2s_CollectionWithValues_ReturnsExp2Values_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, 1.0, 2.0, 3.0 };

        // Act
        var result = input.Exp2s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0, 4.0, 8.0 }, result);
    }

    [Fact]
    public void Exp2s_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, null, 2.0 };

        // Act
        var result = input.Exp2s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, default, 4.0 }, result);
    }

    [Fact]
    public void Exp2s_CollectionWithMixedTypes_ConvertsAndCalculatesExp2_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 0.0, "1.0", 2.0, "3.0" };

        // Act
        var result = input.Exp2s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0, 4.0, 8.0 }, result);
    }

    [Fact]
    public void Exp2s_ParamsOverload_ReturnsExp2Values_MathGenericCollection()
    {
        // Act
        var result = YANMath.Exp2s<double?>(0.0, 1.0, 2.0, 3.0);

        // Assert
        Assert.Equal([1.0, 2.0, 4.0, 8.0], result);
    }

    #endregion

    #region Logs

    [Fact]
    public void Logs_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Logs_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Logs_CollectionWithValues_ReturnsLogValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { Math.E, Math.E * Math.E };

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0 }, result);
    }

    [Fact]
    public void Logs_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { Math.E, null, Math.E * Math.E };

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, default, 2.0 }, result);
    }

    [Fact]
    public void Logs_CollectionWithMixedTypes_ConvertsAndCalculatesLog_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { Math.E, "2.718281828459045", Math.E * Math.E };

        // Act
        var result = input.Logs<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, 1.0, 2.0 }, result);
    }

    [Fact]
    public void Logs_WithBase_ReturnsLogValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 10.0, 100.0, 1000.0 };

        // Act
        var result = input.Logs<double>(10).Rounds();

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0, 3.0 }, result);
    }

    #endregion

    #region Log10s

    [Fact]
    public void Log10s_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log10s_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log10s_CollectionWithValues_ReturnsLog10Values_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 10.0, 100.0, 1000.0 };

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0, 3.0 }, result);
    }

    [Fact]
    public void Log10s_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 10.0, null, 1000.0 };

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, default, 3.0 }, result);
    }

    [Fact]
    public void Log10s_CollectionWithMixedTypes_ConvertsAndCalculatesLog10_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 10.0, "100.0", 1000.0 };

        // Act
        var result = input.Log10s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0, 3.0 }, result);
    }

    [Fact]
    public void Log10s_ParamsOverload_ReturnsLog10Values_MathGenericCollection()
    {
        // Act
        var result = YANMath.Log10s<double?>(10.0, 100.0, 1000.0);

        // Assert
        Assert.Equal([1.0, 2.0, 3.0], result);
    }

    #endregion

    #region Log2s

    [Fact]
    public void Log2s_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log2s_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Log2s_CollectionWithValues_ReturnsLog2Values_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 2.0, 4.0, 8.0 };

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0, 3.0 }, result);
    }

    [Fact]
    public void Log2s_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 2.0, null, 8.0 };

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, default, 3.0 }, result);
    }

    [Fact]
    public void Log2s_CollectionWithMixedTypes_ConvertsAndCalculatesLog2_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 2.0, "4.0", 8.0 };

        // Act
        var result = input.Log2s<double>();

        // Assert
        Assert.Equal(new List<double> { 1.0, 2.0, 3.0 }, result);
    }

    [Fact]
    public void Log2s_ParamsOverload_ReturnsLog2Values_MathGenericCollection()
    {
        // Act
        var result = YANMath.Log2s<double?>(2.0, 4.0, 8.0);

        // Assert
        Assert.Equal([1.0, 2.0, 3.0], result);
    }

    #endregion

    #region ILogBs

    [Fact]
    public void ILogBs_NullCollection_ReturnsNull_MathGenericCollection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.ILogBs<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ILogBs_EmptyCollection_ReturnsNullCollection_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?>();

        // Act
        var result = input.ILogBs<int>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ILogBs_CollectionWithValues_ReturnsILogBValues_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 2.0, 4.0, 8.0, 16.0 };

        // Act
        var result = input.ILogBs<int>();

        // Assert
        Assert.Equal(new List<int> { 1, 2, 3, 4 }, result);
    }

    [Fact]
    public void ILogBs_CollectionWithNullValues_PreservesNulls_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 2.0, null, 8.0 };

        // Act
        var result = input.ILogBs<int>();

        // Assert
        Assert.Equal(new List<int> { 1, default, 3 }, result);
    }

    [Fact]
    public void ILogBs_CollectionWithMixedTypes_ConvertsAndCalculatesILogB_MathGenericCollection()
    {
        // Arrange
        var input = new List<object?> { 2.0, "4.0", 8.0, "16.0" };

        // Act
        var result = input.ILogBs<int>();

        // Assert
        Assert.Equal(new List<int> { 1, 2, 3, 4 }, result);
    }

    [Fact]
    public void ILogBs_ParamsOverload_ReturnsILogBValues_MathGenericCollection()
    {
        // Act
        var result = YANMath.ILogBs<int?>(2.0, 4.0, 8.0, 16.0);

        // Assert
        Assert.Equal([1, 2, 3, 4], result);
    }

    #endregion
}
