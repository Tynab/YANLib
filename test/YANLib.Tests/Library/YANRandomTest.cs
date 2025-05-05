namespace YANLib.Tests.Library;

public partial class YANRandomTest
{
    #region NextInt32

    [Fact]
    public void NextInt32_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextInt32();

        // Assert
        Assert.True(result is > int.MinValue and < int.MaxValue);
    }

    [Fact]
    public void NextInt32_MultipleCallsReturnDifferentValues_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result1 = random.NextInt32();
        var result2 = random.NextInt32();
        var result3 = random.NextInt32();

        // Assert
        Assert.False(result1 == result2 && result2 == result3);
    }

    #endregion

    #region NextDecimal

    [Fact]
    public void NextDecimal_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextDecimal();

        // Assert
        Assert.True(result is > decimal.MinValue and < decimal.MaxValue);
    }

    [Fact]
    public void NextDecimal_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        decimal min = -100;
        decimal max = 100;

        // Act
        var result = random.NextDecimal(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextDecimal_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        decimal min = 100;
        decimal max = -100;

        // Act
        var result = random.NextDecimal(min, max);

        // Assert
        Assert.Equal(0m, result);
    }

    #endregion

    #region NextBool

    [Fact]
    public void NextBool_ReturnsBooleanValue_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextBool();

        // Assert
        _ = Assert.IsType<bool>(result);
    }

    [Fact]
    public void NextBool_MultipleCallsReturnMixOfValues_RandomExtension()
    {
        // Arrange
        var random = new Random();
        var results = new List<bool>();

        // Act
        for (var i = 0; i < 100; i++)
        {
            results.Add(random.NextBool());
        }

        // Assert
        Assert.Contains(true, results);
        Assert.Contains(false, results);
    }

    #endregion

    #region NextByte

    [Fact]
    public void NextByte_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextByte();

        // Assert
        Assert.True(result is > byte.MinValue and < byte.MaxValue);
    }

    [Fact]
    public void NextByte_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        byte min = 10;
        byte max = 100;

        // Act
        var result = random.NextByte(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextByte_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        byte min = 100;
        byte max = 10;

        // Act
        var result = random.NextByte(min, max);

        // Assert
        Assert.Equal((byte)0, result);
    }

    #endregion

    #region NextSbyte

    [Fact]
    public void NextSbyte_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextSbyte();

        // Assert
        Assert.True(result is > sbyte.MinValue and < sbyte.MaxValue);
    }

    [Fact]
    public void NextSbyte_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        sbyte min = -50;
        sbyte max = 50;

        // Act
        var result = random.NextSbyte(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextSbyte_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        sbyte min = 50;
        sbyte max = -50;

        // Act
        var result = random.NextSbyte(min, max);

        // Assert
        Assert.Equal((sbyte)0, result);
    }

    #endregion

    #region NextShort

    [Fact]
    public void NextShort_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextShort();

        // Assert
        Assert.True(result is > short.MinValue and < short.MaxValue);
    }

    [Fact]
    public void NextShort_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        short min = -1000;
        short max = 1000;

        // Act
        var result = random.NextShort(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextShort_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        short min = 1000;
        short max = -1000;

        // Act
        var result = random.NextShort(min, max);

        // Assert
        Assert.Equal((short)0, result);
    }

    #endregion

    #region NextUshort

    [Fact]
    public void NextUshort_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextUshort();

        // Assert
        Assert.True(result is > ushort.MinValue and < ushort.MaxValue);
    }

    [Fact]
    public void NextUshort_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        ushort min = 1000;
        ushort max = 5000;

        // Act
        var result = random.NextUshort(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextUshort_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        ushort min = 5000;
        ushort max = 1000;

        // Act
        var result = random.NextUshort(min, max);

        // Assert
        Assert.Equal((ushort)0, result);
    }

    #endregion

    #region NextInt

    [Fact]
    public void NextInt_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextInt();

        // Assert
        Assert.True(result is > int.MinValue and < int.MaxValue);
    }

    [Fact]
    public void NextInt_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        var min = -10000;
        var max = 10000;

        // Act
        var result = random.NextInt(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextInt_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        var min = 10000;
        var max = -10000;

        // Act
        var result = random.NextInt(min, max);

        // Assert
        Assert.Equal(0, result);
    }

    #endregion

    #region NextUint

    [Fact]
    public void NextUint_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextUint();

        // Assert
        Assert.True(result is > uint.MinValue and < uint.MaxValue);
    }

    [Fact]
    public void NextUint_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        uint min = 10000;
        uint max = 50000;

        // Act
        var result = random.NextUint(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextUint_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        uint min = 50000;
        uint max = 10000;

        // Act
        var result = random.NextUint(min, max);

        // Assert
        Assert.Equal(0u, result);
    }

    #endregion

    #region NextLong

    [Fact]
    public void NextLong_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextLong();

        // Assert
        Assert.True(result is > long.MinValue and < long.MaxValue);
    }

    [Fact]
    public void NextLong_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        long min = -1000000;
        long max = 1000000;

        // Act
        var result = random.NextLong(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextLong_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        long min = 1000000;
        long max = -1000000;

        // Act
        var result = random.NextLong(min, max);

        // Assert
        Assert.Equal(0L, result);
    }

    #endregion

    #region NextUlong

    [Fact]
    public void NextUlong_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextUlong();

        // Assert
        Assert.True(result is > ulong.MinValue and < ulong.MaxValue);
    }

    [Fact]
    public void NextUlong_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        ulong min = 1000000;
        ulong max = 5000000;

        // Act
        var result = random.NextUlong(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextUlong_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        ulong min = 5000000;
        ulong max = 1000000;

        // Act
        var result = random.NextUlong(min, max);

        // Assert
        Assert.Equal(0UL, result);
    }

    #endregion

    #region NextNint

    [Fact]
    public void NextNint_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextNint();

        // Assert
        Assert.True(result >= nint.MinValue && result <= nint.MaxValue);
    }

    [Fact]
    public void NextNint_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        nint min = -10000;
        nint max = 10000;

        // Act
        var result = random.NextNint(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextNint_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        nint min = 10000;
        nint max = -10000;

        // Act
        var result = random.NextNint(min, max);

        // Assert
        Assert.Equal(0, result);
    }

    #endregion

    #region NextNuint

    [Fact]
    public void NextNuint_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextNuint();

        // Assert
        Assert.True(result >= nuint.MinValue && result <= nuint.MaxValue);
    }

    [Fact]
    public void NextNuint_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        nuint min = 10000;
        nuint max = 50000;

        // Act
        var result = random.NextNuint(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextNuint_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        nuint min = 50000;
        nuint max = 10000;

        // Act
        var result = random.NextNuint(min, max);

        // Assert
        Assert.Equal((nuint)0, result);
    }

    #endregion

    #region NextSingle

    [Fact]
    public void NextSingle_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextSingle();

        // Assert
        Assert.True(result is >= (float.MinValue / 100) and <= (float.MaxValue / 100));
    }

    [Fact]
    public void NextSingle_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        var min = -100.5f;
        var max = 100.5f;

        // Act
        var result = random.NextSingle(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextSingle_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        var min = 100.5f;
        var max = -100.5f;

        // Act
        var result = random.NextSingle(min, max);

        // Assert
        Assert.Equal(0f, result);
    }

    #endregion

    #region NextDouble

    [Fact]
    public void NextDouble_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextDouble();

        // Assert
        Assert.True(result is >= 0 and < 1);
    }

    [Fact]
    public void NextDouble_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        var min = -100.5;
        var max = 100.5;

        // Act
        var result = random.NextDouble(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextDouble_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        var min = 100.5;
        var max = -100.5;

        // Act
        var result = random.NextDouble(min, max);

        // Assert
        Assert.Equal(0.0, result);
    }

    #endregion

    #region NextDateTime

    [Fact]
    public void NextDateTime_NoParameters_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextDateTime();

        // Assert
        Assert.True(result >= DateTime.MinValue && result <= DateTime.MaxValue);
    }

    [Fact]
    public void NextDateTime_WithMinMax_ReturnsValueInRange_RandomExtension()
    {
        // Arrange
        var random = new Random();
        var min = new DateTime(2000, 1, 1);
        var max = new DateTime(2023, 12, 31);

        // Act
        var result = random.NextDateTime(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void NextDateTime_MinGreaterThanMax_ReturnsDefault_RandomExtension()
    {
        // Arrange
        var random = new Random();
        var min = new DateTime(2023, 12, 31);
        var max = new DateTime(2000, 1, 1);

        // Act
        var result = random.NextDateTime(min, max);

        // Assert
        Assert.Equal(default, result);
    }

    #endregion

    #region NextChar

    [Fact]
    public void NextChar_ReturnsLowercaseLetter_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextChar();

        // Assert
        Assert.True(char.IsLower(result) && char.IsLetter(result));
    }

    [Fact]
    public void NextChar_MultipleCallsReturnDifferentValues_RandomExtension()
    {
        // Arrange
        var random = new Random();
        var results = new HashSet<char>();

        // Act
        for (var i = 0; i < 20; i++)
        {
            _ = results.Add(random.NextChar());
        }

        // Assert
        Assert.True(results.Count > 1);
    }

    #endregion

    #region NextString

    [Fact]
    public void NextString_NoParameters_ReturnsRandomString_RandomExtension()
    {
        // Arrange
        var random = new Random();

        // Act
        var result = random.NextString();

        // Assert
        _ = Assert.IsType<string>(result);
        Assert.True(result.All(c => char.IsLower(c) && char.IsLetter(c)));
    }

    [Fact]
    public void NextString_WithSize_ReturnsStringOfSpecifiedLength_RandomExtension()
    {
        // Arrange
        var random = new Random();
        var size = 10;

        // Act
        var result = random.NextString(size);

        // Assert
        Assert.Equal(size, result.Length);
        Assert.True(result.All(c => char.IsLower(c) && char.IsLetter(c)));
    }

    #endregion

    #region GenerateRandom

    [Fact]
    public void GenerateRandom_Int_ReturnsRandomInt_RandomGeneric()
    {
        // Act
        var result = YANRandom.GenerateRandom<int>();

        // Assert
        _ = Assert.IsType<int>(result);
    }

    [Fact]
    public void GenerateRandom_Double_WithMinMax_ReturnsValueInRange_RandomGeneric()
    {
        // Arrange
        var min = -100.5;
        var max = 100.5;

        // Act
        var result = YANRandom.GenerateRandom<double>(min, max);

        // Assert
        Assert.True(result >= min && result <= max);
    }

    [Fact]
    public void GenerateRandom_DateTime_ReturnsRandomDateTime_RandomGeneric()
    {
        // Act
        var result = YANRandom.GenerateRandom<DateTime>();

        // Assert
        _ = Assert.IsType<DateTime>(result);
        Assert.True(result >= DateTime.MinValue && result <= DateTime.MaxValue);
    }

    [Fact]
    public void GenerateRandom_String_ReturnsRandomString_RandomGeneric()
    {
        // Act
        var result = YANRandom.GenerateRandom<string>();

        // Assert
        _ = Assert.IsType<string>(result);
        Assert.NotNull(result);
        Assert.True(result.All(c => char.IsLower(c) && char.IsLetter(c)));
    }

    [Fact]
    public void GenerateRandom_Bool_ReturnsRandomBool_RandomGeneric()
    {
        // Act
        var result = YANRandom.GenerateRandom<bool>();

        // Assert
        _ = Assert.IsType<bool>(result);
    }

    #endregion
}
