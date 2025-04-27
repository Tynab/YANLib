using System.Collections;
using System.Text;
using System.Text.Json;

namespace YANLib.Tests.Library;

public partial class YANJsonTest
{
    #region Serializes

    [Fact]
    public void Serializes_NullEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Serializes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Serializes_EmptyEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.Serializes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Serializes_SimpleObjects_ReturnsJsonStrings_Collection()
    {
        // Arrange
        var input = new object?[]
        {
            new TestClass { Id = 1, Name = "Test1" },
            new TestClass { Id = 2, Name = "Test2" },
            new TestClass { Id = 3, Name = "Test3" }
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
    public void Serializes_MixedNullValues_PreservesNulls_Collection()
    {
        // Arrange
        var input = new object?[]
        {
            new TestClass { Id = 1, Name = "Test1" },
            null,
            new TestClass { Id = 3, Name = "Test3" }
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
    public void Serializes_WithCustomOptions_UsesOptions_Collection()
    {
        // Arrange
        var input = new object?[]
        {
            new TestClass { Id = 1, Name = "Test1" },
            new TestClass { Id = 2, Name = "Test2" }
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
    public void Serializes_ParamsOverload_ReturnsJsonStrings_Collection()
    {
        // Act
        var result = YANJson.Serializes(new TestClass { Id = 1, Name = "Test1" }, new TestClass { Id = 2, Name = "Test2" })?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Contains("\"id\":1", result[0]);
        Assert.Contains("\"name\":\"Test1\"", result[0]);
        Assert.Contains("\"id\":2", result[1]);
        Assert.Contains("\"name\":\"Test2\"", result[1]);
    }

    [Fact]
    public void Serializes_IEnumerableOverload_ReturnsJsonStrings_Collection()
    {
        // Arrange
        ArrayList input = [new TestClass { Id = 1, Name = "Test1" }, new TestClass { Id = 2, Name = "Test2" }];

        // Act
        var result = input.Serializes()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Contains("\"id\":1", result[0]);
        Assert.Contains("\"name\":\"Test1\"", result[0]);
        Assert.Contains("\"id\":2", result[1]);
        Assert.Contains("\"name\":\"Test2\"", result[1]);
    }

    [Fact]
    public void Serializes_NullIEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        ArrayList? input = null;

        // Act
        var result = input.Serializes();

        // Assert
        Assert.Null(result);
    }

    #endregion

    #region SerializesToBytes

    [Fact]
    public void SerializesToBytes_NullEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.SerializesToBytes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SerializesToBytes_EmptyEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.SerializesToBytes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SerializesToBytes_SimpleObjects_ReturnsByteArrays_Collection()
    {
        // Arrange
        var input = new object?[]
        {
            new TestClass { Id = 1, Name = "Test1" },
            new TestClass { Id = 2, Name = "Test2" }
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
    public void SerializesToBytes_MixedNullValues_PreservesNulls_Collection()
    {
        // Arrange
        var input = new object?[]
        {
            new TestClass { Id = 1, Name = "Test1" },
            null,
            new TestClass { Id = 3, Name = "Test3" }
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
    public void SerializesToBytes_ParamsOverload_ReturnsByteArrays_Collection()
    {
        // Act
        var result = YANJson.SerializesToBytes(new TestClass { Id = 1, Name = "Test1" }, new TestClass { Id = 2, Name = "Test2" })?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.True(result[0]!.Length > 0);
        Assert.True(result[1]!.Length > 0);
    }

    [Fact]
    public void SerializesToBytes_IEnumerableOverload_ReturnsByteArrays_Collection()
    {
        // Arrange
        ArrayList input = [new TestClass { Id = 1, Name = "Test1" }, new TestClass { Id = 2, Name = "Test2" }];

        // Act
        var result = input.SerializesToBytes()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.True(result[0]!.Length > 0);
        Assert.True(result[1]!.Length > 0);
    }

    #endregion

    #region Deserializes

    [Fact]
    public void Deserializes_NullEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Deserializes<TestClass>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserializes_EmptyEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.Deserializes<TestClass>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserializes_ValidJsonStrings_ReturnsObjects_Collection()
    {
        // Arrange
        var input = new string?[]
        {
            "{\"id\":1,\"name\":\"Test1\"}",
            "{\"id\":2,\"name\":\"Test2\"}",
            "{\"id\":3,\"name\":\"Test3\"}"
        };

        // Act
        var result = input.Deserializes<TestClass>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]!.Id);
        Assert.Equal("Test1", result[0]!.Name);
        Assert.Equal(2, result[1]!.Id);
        Assert.Equal("Test2", result[1]!.Name);
        Assert.Equal(3, result[2]!.Id);
        Assert.Equal("Test3", result[2]!.Name);
    }

    [Fact]
    public void Deserializes_MixedNullValues_PreservesNulls_Collection()
    {
        // Arrange
        var input = new string?[]
        {
            "{\"id\":1,\"name\":\"Test1\"}",
            null,
            "{\"id\":3,\"name\":\"Test3\"}"
        };

        // Act
        var result = input.Deserializes<TestClass>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]!.Id);
        Assert.Equal("Test1", result[0]!.Name);
        Assert.Null(result[1]);
        Assert.Equal(3, result[2]!.Id);
        Assert.Equal("Test3", result[2]!.Name);
    }

    [Fact]
    public void Deserializes_InvalidJsonStrings_HandlesGracefully_Collection()
    {
        // Arrange
        var input = new string?[]
        {
            "{\"id\":1,\"name\":\"Test1\"}",
            "{invalid json}",
            "{\"id\":3,\"name\":\"Test3\"}"
        };

        // Act
        var result = input.Deserializes<TestClass>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]!.Id);
        Assert.Equal("Test1", result[0]!.Name);
        Assert.Null(result[1]);
        Assert.Equal(3, result[2]!.Id);
        Assert.Equal("Test3", result[2]!.Name);
    }

    [Fact]
    public void Deserializes_ParamsOverload_ReturnsObjects_Collection()
    {
        // Act
        var result = YANJson.Deserializes<TestClass>("{\"id\":1,\"name\":\"Test1\"}", "{\"id\":2,\"name\":\"Test2\"}")?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Equal(1, result[0]!.Id);
        Assert.Equal("Test1", result[0]!.Name);
        Assert.Equal(2, result[1]!.Id);
        Assert.Equal("Test2", result[1]!.Name);
    }

    #endregion

    #region DeserializesFromBytes

    [Fact]
    public void DeserializesFromBytes_NullEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        IEnumerable<byte[]?>? input = null;

        // Act
        var result = input.DeserializesFromBytes<TestClass>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void DeserializesFromBytes_EmptyEnumerable_ReturnsNull_Collection()
    {
        // Arrange
        var input = Array.Empty<byte[]?>();

        // Act
        var result = input.DeserializesFromBytes<TestClass>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void DeserializesFromBytes_ValidByteArrays_ReturnsObjects_Collection()
    {
        // Arrange
        var input = new byte[]?[]
        {
            Encoding.UTF8.GetBytes("{\"id\":1,\"name\":\"Test1\"}"),
            Encoding.UTF8.GetBytes("{\"id\":2,\"name\":\"Test2\"}")
        };

        // Act
        var result = input.DeserializesFromBytes<TestClass>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Equal(1, result[0]!.Id);
        Assert.Equal("Test1", result[0]!.Name);
        Assert.Equal(2, result[1]!.Id);
        Assert.Equal("Test2", result[1]!.Name);
    }

    [Fact]
    public void DeserializesFromBytes_MixedNullValues_PreservesNulls_Collection()
    {
        // Arrange
        var input = new byte[]?[]
        {
            Encoding.UTF8.GetBytes("{\"id\":1,\"name\":\"Test1\"}"),
            null,
            Encoding.UTF8.GetBytes("{\"id\":3,\"name\":\"Test3\"}")
        };

        // Act
        var result = input.DeserializesFromBytes<TestClass>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(3, result.Length);
        Assert.Equal(1, result[0]!.Id);
        Assert.Equal("Test1", result[0]!.Name);
        Assert.Null(result[1]);
        Assert.Equal(3, result[2]!.Id);
        Assert.Equal("Test3", result[2]!.Name);
    }

    [Fact]
    public void DeserializesFromBytes_ParamsOverload_ReturnsObjects_Collection()
    {
        // Arrange
        var bytes1 = Encoding.UTF8.GetBytes("{\"id\":1,\"name\":\"Test1\"}");
        var bytes2 = Encoding.UTF8.GetBytes("{\"id\":2,\"name\":\"Test2\"}");

        // Act
        var result = YANJson.DeserializesFromBytes<TestClass>(bytes1, bytes2)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Equal(1, result[0]!.Id);
        Assert.Equal("Test1", result[0]!.Name);
        Assert.Equal(2, result[1]!.Id);
        Assert.Equal("Test2", result[1]!.Name);
    }

    #endregion
}
