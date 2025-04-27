using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YANLib.Tests.Library;

public partial class YANJsonTest
{
    #region Serialize

    [Fact]
    public void Serialize_NullInput_ReturnsNull()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.Serialize();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Serialize_SimpleObject_ReturnsJsonString()
    {
        // Arrange
        var input = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        // Act
        var result = input.Serialize();

        // Assert
        Assert.NotNull(result);
        Assert.Contains("\"id\":1", result);
        Assert.Contains("\"name\":\"Test\"", result);
    }

    [Fact]
    public void Serialize_PrimitiveType_ReturnsJsonString()
    {
        // Arrange
        var input = 42;

        // Act
        var result = input.Serialize();

        // Assert
        Assert.Equal("42", result);
    }

    [Fact]
    public void Serialize_WithCustomOptions_UsesOptions()
    {
        // Arrange
        var input = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            WriteIndented = true
        };

        // Act
        var result = input.Serialize(options);

        // Assert
        Assert.NotNull(result);
        Assert.Contains("\"Id\":", result);
        Assert.Contains("\"Name\":", result);
    }

    [Fact]
    public void Serialize_ComplexObject_HandlesNesting()
    {
        // Arrange
        var input = new TestClassWithNesting
        {
            Id = 1,
            Name = "Parent",
            Child = new TestClass { Id = 2, Name = "Child" }
        };

        // Act
        var result = input.Serialize();

        // Assert
        Assert.NotNull(result);
        Assert.Contains("\"id\":1", result);
        Assert.Contains("\"name\":\"Parent\"", result);
        Assert.Contains("\"child\":{", result);
        Assert.Contains("\"id\":2", result);
        Assert.Contains("\"name\":\"Child\"", result);
    }

    #endregion

    #region SerializeToBytes

    [Fact]
    public void SerializeToBytes_NullInput_ReturnsNull()
    {
        // Arrange
        object? input = null;

        // Act
        var result = input.SerializeToBytes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SerializeToBytes_SimpleObject_ReturnsByteArray()
    {
        // Arrange
        var input = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        // Act
        var result = input.SerializeToBytes();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Length > 0);
    }

    [Fact]
    public void SerializeToBytes_WithCustomOptions_UsesOptions()
    {
        // Arrange
        var input = new TestClass
        {
            Id = 1,
            Name = "Test"
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            WriteIndented = true
        };

        // Act
        var result = input.SerializeToBytes(options);
        var stringResult = Encoding.UTF8.GetString(result!);

        // Assert
        Assert.NotNull(result);
        Assert.Contains("\"Id\":", stringResult);
        Assert.Contains("\"Name\":", stringResult);
    }

    #endregion

    #region Deserialize

    [Fact]
    public void Deserialize_NullInput_ReturnsNull()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Deserialize<TestClass>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_EmptyString_ReturnsNull()
    {
        // Arrange
        var input = "";

        // Act
        var result = input.Deserialize<TestClass>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_WhitespaceString_ReturnsNull()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Deserialize<TestClass>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_ValidJson_ReturnsObject()
    {
        // Arrange
        var input = "{\"id\":1,\"name\":\"Test\"}";

        // Act
        var result = input.Deserialize<TestClass>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Test", result.Name);
    }

    [Fact]
    public void Deserialize_CaseInsensitive_HandlesPropertyNameCasing()
    {
        // Arrange
        var input = "{\"ID\":1,\"NAME\":\"Test\"}";

        // Act
        var result = input.Deserialize<TestClass>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Test", result.Name);
    }

    [Fact]
    public void Deserialize_InvalidJson_ReturnsNull()
    {
        // Arrange
        var input = "{invalid json}";

        // Act
        var result = input.Deserialize<TestClass>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_WithCustomOptions_UsesOptions()
    {
        // Arrange
        var input = "{\"Id\":1,\"Name\":\"Test\"}";
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null
        };

        // Act
        var result = input.Deserialize<TestClass>(options);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Test", result.Name);
    }

    #endregion

    #region DeserializeFromBytes

    [Fact]
    public void DeserializeFromBytes_NullInput_ReturnsNull()
    {
        // Arrange
        byte[]? input = null;

        // Act
        var result = input.DeserializeFromBytes<TestClass>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void DeserializeFromBytes_EmptyArray_ReturnsNull()
    {
        // Arrange
        byte[] input = [];

        // Act
        var result = input.DeserializeFromBytes<TestClass>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void DeserializeFromBytes_ValidJson_ReturnsObject()
    {
        // Arrange
        var jsonString = "{\"id\":1,\"name\":\"Test\"}";
        var input = Encoding.UTF8.GetBytes(jsonString);

        // Act
        var result = input.DeserializeFromBytes<TestClass>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Test", result.Name);
    }

    [Fact]
    public void DeserializeFromBytes_InvalidJson_ReturnsNull()
    {
        // Arrange
        var jsonString = "{invalid json}";
        var input = Encoding.UTF8.GetBytes(jsonString);

        // Act
        var result = input.DeserializeFromBytes<TestClass>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void DeserializeFromBytes_WithCustomOptions_UsesOptions()
    {
        // Arrange
        var jsonString = "{\"Id\":1,\"Name\":\"Test\"}";
        var input = Encoding.UTF8.GetBytes(jsonString);
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null
        };

        // Act
        var result = input.DeserializeFromBytes<TestClass>(options);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Test", result.Name);
    }

    #endregion

    private class TestClass
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }

    private class TestClassWithNesting
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("child")]
        public TestClass? Child { get; set; }
    }
}
