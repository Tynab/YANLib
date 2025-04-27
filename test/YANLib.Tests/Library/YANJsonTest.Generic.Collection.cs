using System.Text;
using System.Text.Json;

namespace YANLib.Tests.Library;

public partial class YANJsonTest
{
    #region Serializes

    [Fact]
    public void Serializes_NullEnumerable_ReturnsNull_GenericCollection()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.Serializes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Serializes_EmptyEnumerable_ReturnsNull_GenericCollection()
    {
        // Arrange
        var input = Array.Empty<TestClass?>();

        // Act
        var result = input.Serializes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Serializes_SimpleObjects_ReturnsJsonStrings_GenericCollection()
    {
        // Arrange
        var input = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1" },
            new() { Id = 2, Name = "Test2" },
            new() { Id = 3, Name = "Test3" }
        };

        // Act
        var result = input.Serializes()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Contains("\"id\":1", result[0]);
        Assert.Contains("\"name\":\"Test1\"", result[0]);
        Assert.Contains("\"id\":2", result[1]);
        Assert.Contains("\"name\":\"Test2\"", result[1]);
        Assert.Contains("\"id\":3", result[2]);
        Assert.Contains("\"name\":\"Test3\"", result[2]);
    }

    [Fact]
    public void Serializes_MixedNullValues_PreservesNulls_GenericCollection()
    {
        // Arrange
        var input = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1" },
            null,
            new() { Id = 3, Name = "Test3" }
        };

        // Act
        var result = input.Serializes()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Contains("\"id\":1", result[0]);
        Assert.Null(result[1]);
        Assert.Contains("\"id\":3", result[2]);
    }

    [Fact]
    public void Serializes_WithCustomOptions_UsesOptions_GenericCollection()
    {
        // Arrange
        var input = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1" },
            new() { Id = 2, Name = "Test2" }
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            WriteIndented = true
        };

        // Act
        var result = input.Serializes(options)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Contains("\"Id\":", result[0]);
        Assert.Contains("\"Name\":", result[0]);
        Assert.Contains("\"Id\":", result[1]);
        Assert.Contains("\"Name\":", result[1]);
    }

    [Fact]
    public void Serializes_ValueTypes_HandlesCorrectly_GenericCollection()
    {
        // Arrange
        var input = new int?[] { 1, 2, 3, null, 5 };

        // Act
        var result = input.Serializes()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Length);
        Assert.Equal("1", result[0]);
        Assert.Equal("2", result[1]);
        Assert.Equal("3", result[2]);
        Assert.Null(result[3]);
        Assert.Equal("5", result[4]);
    }

    [Fact]
    public void Serializes_StringTypes_HandlesCorrectly_GenericCollection()
    {
        // Arrange
        var input = new string?[] { "one", "two", null, "four" };

        // Act
        var result = input.Serializes()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Length);
        Assert.Equal("\"one\"", result[0]);
        Assert.Equal("\"two\"", result[1]);
        Assert.Null(result[2]);
        Assert.Equal("\"four\"", result[3]);
    }

    #endregion

    #region SerializesToBytes

    [Fact]
    public void SerializesToBytes_NullEnumerable_ReturnsNull_GenericCollection()
    {
        // Arrange
        IEnumerable<TestClass?>? input = null;

        // Act
        var result = input.SerializesToBytes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SerializesToBytes_EmptyEnumerable_ReturnsNull_GenericCollection()
    {
        // Arrange
        var input = Array.Empty<TestClass?>();

        // Act
        var result = input.SerializesToBytes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SerializesToBytes_SimpleObjects_ReturnsByteArrays_GenericCollection()
    {
        // Arrange
        var input = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1" },
            new() { Id = 2, Name = "Test2" }
        };

        // Act
        var result = input.SerializesToBytes()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.True(result[0]!.Length > 0);
        Assert.True(result[1]!.Length > 0);
    }

    [Fact]
    public void SerializesToBytes_MixedNullValues_PreservesNulls_GenericCollection()
    {
        // Arrange
        var input = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1" },
            null,
            new() { Id = 3, Name = "Test3" }
        };

        // Act
        var result = input.SerializesToBytes()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.True(result[0]!.Length > 0);
        Assert.Null(result[1]);
        Assert.True(result[2]!.Length > 0);
    }

    [Fact]
    public void SerializesToBytes_WithCustomOptions_UsesOptions_GenericCollection()
    {
        // Arrange
        var input = new TestClass?[]
        {
            new() { Id = 1, Name = "Test1" },
            new() { Id = 2, Name = "Test2" }
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            WriteIndented = true
        };

        // Act
        var result = input.SerializesToBytes(options)?.ToArray();
        var stringResult1 = Encoding.UTF8.GetString(result![0]!);
        var stringResult2 = Encoding.UTF8.GetString(result[1]!);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Contains("\"Id\":", stringResult1);
        Assert.Contains("\"Name\":", stringResult1);
        Assert.Contains("\"Id\":", stringResult2);
        Assert.Contains("\"Name\":", stringResult2);
    }

    [Fact]
    public void SerializesToBytes_ValueTypes_HandlesCorrectly_GenericCollection()
    {
        // Arrange
        var input = new int?[] { 1, 2, null, 4 };

        // Act
        var result = input.SerializesToBytes()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Length);
        Assert.Equal("1", Encoding.UTF8.GetString(result[0]!));
        Assert.Equal("2", Encoding.UTF8.GetString(result[1]!));
        Assert.Null(result[2]);
        Assert.Equal("4", Encoding.UTF8.GetString(result[3]!));
    }

    #endregion
}
