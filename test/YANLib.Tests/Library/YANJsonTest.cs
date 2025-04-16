using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace YANLib.Tests.Library;

public partial class YANJsonTest
{
    private class TestJson
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    #region Serialize
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
    #endregion

    #region Deserialize (byte[])
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
