using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace YANLib.Tests.Library;

public partial class YANJsonTest
{
    private static readonly JsonSerializerOptions CamelCasePropertyNamingPolicy = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private class TestJson
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    #region Serialize (string)
    [Fact]
    public void Serialize_NullInput_ReturnsNull()
    {
        // Arrange
        object? input = null;

        // Act
        var json = input.Serialize();

        // Assert
        Assert.Null(json);
    }

    [Fact]
    public void Serialize_Object_ReturnsExpectedJson()
    {
        // Arrange
        var obj = new TestJson
        {
            Id = 1,
            Name = "Test"
        };

        // Act
        var json = obj.Serialize();

        // Assert
        Assert.NotNull(json);

        var deserialized = json.Deserialize<TestJson>();

        Assert.NotNull(deserialized);
        Assert.Equal(obj.Id, deserialized.Id);
        Assert.Equal(obj.Name, deserialized.Name);
    }

    [Fact]
    public void Serializes_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var jsons = input.Serializes();

        // Assert
        Assert.Null(jsons);
    }

    [Fact]
    public void Serializes_EmptyEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?> input = [];

        // Act
        var jsons = input.Serializes();

        // Assert
        Assert.Null(jsons);
    }

    [Fact]
    public void Serializes_Collection_ReturnsExpectedJsonStrings()
    {
        // Arrange
        var list = new List<TestJson>
        {
            new() { Id = 1, Name = "Alice" },
            new() { Id = 2, Name = "Bob" }
        };

        // Act
        var jsons = list.Serializes();

        // Assert
        Assert.NotNull(jsons);

        var jsonArray = jsons.ToArray();

        Assert.Equal(2, jsonArray.Length);

        var first = jsonArray[0].Deserialize<TestJson>();
        var second = jsonArray[1].Deserialize<TestJson>();

        Assert.NotNull(first);
        Assert.NotNull(second);
        Assert.Equal(1, first.Id);
        Assert.Equal("Alice", first.Name);
        Assert.Equal(2, second.Id);
        Assert.Equal("Bob", second.Name);
    }

    [Fact]
    public void Serializes_Params_ReturnsExpectedJsonStrings()
    {
        // Arrange
        var a = new TestJson
        {
            Id = 10,
            Name = "X"
        };

        var b = new TestJson
        {
            Id = 20,
            Name = "Y"
        };

        // Act
        var result = YANJson.Serializes(a, b);

        // Assert
        Assert.NotNull(result);

        var arr = result.ToArray();

        Assert.Equal(2, arr.Length);
        Assert.Equal(a.Id, arr[0]!.Deserialize<TestJson>()!.Id);
        Assert.Equal(b.Id, arr[1]!.Deserialize<TestJson>()!.Id);
    }
    #endregion

    #region Serialize (byte[])
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
    public void SerializeToBytes_Object_ReturnsUtf8JsonBytes()
    {
        // Arrange
        var obj = new TestJson
        {
            Id = 42,
            Name = "Test"
        };

        var expectedJson = JsonSerializer.Serialize(obj, CamelCasePropertyNamingPolicy);

        // Act
        var bytes = obj.SerializeToBytes();
        var json = bytes == null ? null : Encoding.UTF8.GetString(bytes);

        // Assert
        Assert.Equal(expectedJson, json);
    }

    [Fact]
    public void SerializesToBytes_NullInput_ReturnsNull()
    {
        // Arrange
        List<object>? input = null;

        // Act
        var result = input.SerializesToBytes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SerializesToBytes_EmptyInput_ReturnsNull()
    {
        // Arrange
        var input = Array.Empty<object>();

        // Act
        var result = input.SerializesToBytes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SerializesToBytes_MultipleObjects_ReturnsSequenceOfUtf8JsonBytes()
    {
        // Arrange
        var a = new TestJson
        {
            Id = 1,
            Name = "A"
        };

        var b = new TestJson
        {
            Id = 2,
            Name = "B"
        };

        var list = new[] { a, b };
        var expectedA = JsonSerializer.Serialize(a, CamelCasePropertyNamingPolicy);
        var expectedB = JsonSerializer.Serialize(b, CamelCasePropertyNamingPolicy);

        // Act
        var results = list.SerializesToBytes();

        // Assert
        Assert.NotNull(results);

        var arr = new List<byte[]?>(results);

        Assert.Equal(2, arr.Count);
        Assert.Equal(expectedA, Encoding.UTF8.GetString(arr[0]!));
        Assert.Equal(expectedB, Encoding.UTF8.GetString(arr[1]!));
    }

    [Fact]
    public void SerializesToBytes_Params_ReturnsExpectedByteArrays()
    {
        // Arrange
        var a = new TestJson
        {
            Id = 10,
            Name = "X"
        };

        var b = new TestJson
        {
            Id = 20,
            Name = "Y"
        };

        // Act
        var results = YANJson.SerializesToBytes(a, b);

        // Assert
        Assert.NotNull(results);

        var arr = results.ToArray();

        Assert.Equal(2, arr.Length);
        Assert.Equal(JsonSerializer.Serialize(a, CamelCasePropertyNamingPolicy), Encoding.UTF8.GetString(arr[0]!));
        Assert.Equal(JsonSerializer.Serialize(b, CamelCasePropertyNamingPolicy), Encoding.UTF8.GetString(arr[1]!));
    }
    #endregion

    #region Deserialize (string)
    [Fact]
    public void Deserialize_NullOrWhitespaceString_ReturnsDefault()
    {
        // Arrange
        var input = "  ";

        // Act
        var result = input.Deserialize<TestJson>();

        // Assert
        Assert.Null(result);
    }

    [Theory]
    [InlineData("{\"id\":10,\"name\":\"Alice\"}", 10, "Alice")]
    [InlineData("{\"id\":20,\"name\":\"Bob\"}", 20, "Bob")]
    public void Deserialize_ValidJson_ReturnsExpectedObject(string json, int expectedId, string expectedName)
    {
        // Act
        var result = json.Deserialize<TestJson>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedId, result.Id);
        Assert.Equal(expectedName, result.Name);
    }

    [Fact]
    public void Deserialize_InvalidJson_ReturnsDefault()
    {
        // Arrange
        var invalidJson = "{invalid json";

        // Act
        var result = invalidJson.Deserialize<TestJson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserializes_NullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Deserializes<TestJson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserializes_CollectionOfJsonStrings_ReturnsExpectedObjects()
    {
        // Arrange
        var jsonList = new List<string?>
        {
            "{\"id\":1,\"name\":\"A\"}",
            "{\"id\":2,\"name\":\"B\"}"
        };

        // Act
        var results = jsonList.Deserializes<TestJson>();

        // Assert
        Assert.NotNull(results);

        var arr = results.ToArray();

        Assert.Equal(2, arr.Length);
        Assert.Equal(1, arr[0]!.Id);
        Assert.Equal("A", arr[0]!.Name);
        Assert.Equal(2, arr[1]!.Id);
        Assert.Equal("B", arr[1]!.Name);
    }

    [Fact]
    public void Deserializes_ParamsJsonStrings_ReturnsExpectedObjects()
    {
        // Arrange
        var a = new TestJson
        {
            Id = 99,
            Name = "Test99"
        };

        var b = new TestJson
        {
            Id = 88,
            Name = "Test88"
        };

        var jsons = new[] { a.Serialize(), b.Serialize() };

        // Act
        var result = YANJson.Deserializes<TestJson>(jsons);

        // Assert
        Assert.NotNull(result);

        var list = result.ToList();

        Assert.Equal(a.Id, list[0]!.Id);
        Assert.Equal(b.Id, list[1]!.Id);
    }
    #endregion

    #region Deserialize (byte[])
    [Fact]
    public void Deserialize_ByteArrayNullInput_ReturnsNull()
    {
        // Arrange
        byte[]? input = null;

        // Act
        var result = input.Deserialize<TestJson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_ByteArray_ReturnsExpectedObject()
    {
        // Arrange
        var obj = new TestJson
        {
            Id = 5,
            Name = "Test5"
        };

        var json = obj.Serialize();

        Assert.NotNull(json);

        var bytes = Encoding.UTF8.GetBytes(json);

        // Act
        var result = bytes.Deserialize<TestJson>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Id);
        Assert.Equal("Test5", result.Name);
    }

    [Fact]
    public void Deserialize_InvalidByteArray_ReturnsDefault()
    {
        // Arrange
        var bytes = Encoding.UTF8.GetBytes("invalid json");

        // Act
        var result = bytes.Deserialize<TestJson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserializes_ByteArrayNullEnumerable_ReturnsNull()
    {
        // Arrange
        IEnumerable<byte[]?>? input = null;

        // Act
        var result = input.Deserializes<TestJson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserializes_ByteArrayEnumerable_ReturnsExpectedObjects()
    {
        // Arrange
        var list = new List<TestJson>
        {
            new() { Id = 7, Name = "Seven" },
            new() { Id = 8, Name = "Eight" }
        };

        var byteArrays = list.Select(x => Encoding.UTF8.GetBytes(x.Serialize()!)).ToList();

        // Act
        var results = byteArrays.Deserializes<TestJson>();

        // Assert
        Assert.NotNull(results);

        var arr = results.ToArray();

        Assert.Equal(2, arr.Length);
        Assert.Equal(7, arr[0]!.Id);
        Assert.Equal("Seven", arr[0]!.Name);
        Assert.Equal(8, arr[1]!.Id);
        Assert.Equal("Eight", arr[1]!.Name);
    }

    [Fact]
    public void Deserializes_ParamsByteArrays_ReturnsExpectedObjects()
    {
        // Arrange
        var a = new TestJson
        {
            Id = 111,
            Name = "AA"
        };

        var b = new TestJson
        {
            Id = 222,
            Name = "BB"
        };

        var arr = YANJson.SerializesToBytes(a, b);

        // Act
        var result = YANJson.Deserializes<TestJson>(arr!.ToArray());

        // Assert
        Assert.NotNull(result);

        var list = result.ToList();

        Assert.Equal(2, list.Count);
        Assert.Equal(a.Id, list[0]!.Id);
        Assert.Equal(b.Id, list[1]!.Id);
    }
    #endregion

    #region Optional
    [Fact]
    public void Serialize_WithCustomOptions_ReturnsExpectedJson()
    {
        // Arrange
        var obj = new TestJson
        {
            Id = 100,
            Name = "Custom"
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        // Act
        var json = obj.Serialize(options);

        // Assert
        Assert.NotNull(json);
        Assert.Contains(Environment.NewLine, json);
    }

    [Fact]
    public void Deserialize_WithCustomOptions_ReturnsExpectedObject()
    {
        // Arrange
        var json = "{\"Id\":200,\"Name\":\"CustomDeserialized\"}";
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // Act
        var result = json.Deserialize<TestJson>(options);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.Id);
        Assert.Equal("CustomDeserialized", result.Name);
    }
    #endregion
}
