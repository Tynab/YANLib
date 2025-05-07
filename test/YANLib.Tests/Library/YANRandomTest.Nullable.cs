namespace YANLib.Tests.Library;

public partial class YANRandomTest
{
    #region GenerateRandom

    [Fact]
    public void GenerateRandom_Int_ReturnsNullableInt_RandomNullable()
    {
        // Act
        var result = YANRandom.GenerateRandom<int?>();

        // Assert
        _ = Assert.IsType<int>(result);
    }

    [Fact]
    public void GenerateRandom_String_ReturnsRandomString_RandomNullable()
    {
        // Act
        var result = YANRandom.GenerateRandom<string>();

        // Assert
        _ = Assert.IsType<string>(result);
        Assert.NotNull(result);
        Assert.True(result.All(static c => char.IsLower(c) && char.IsLetter(c)));
    }

    [Fact]
    public void GenerateRandom_DateTime_ReturnsRandomDateTime_RandomNullable()
    {
        // Act
        var result = YANRandom.GenerateRandom<DateTime?>();

        // Assert
        _ = Assert.IsAssignableFrom<DateTime?>(result);
        Assert.True(result >= DateTime.MinValue && result <= DateTime.MaxValue);
    }

    [Fact]
    public void GenerateRandom_Bool_ReturnsRandomBool_RandomNullable()
    {
        // Act
        var result = YANRandom.GenerateRandom<bool?>();

        // Assert
        _ = Assert.IsType<bool>(result);
    }

    [Fact]
    public void GenerateRandom_MultipleCallsReturnDifferentValues_RandomNullable()
    {
        // Act
        var result1 = YANRandom.GenerateRandom<int?>();
        var result2 = YANRandom.GenerateRandom<int?>();
        var result3 = YANRandom.GenerateRandom<int?>();

        // Assert
        Assert.False(result1 == result2 && result2 == result3);
    }

    #endregion
}
