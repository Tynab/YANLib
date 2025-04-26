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
    public void Serialize_PrimitiveTypes_ReturnsCorrectJson()
    {
        // Arrange
        var intValue = 42;
        var stringValue = "test";
        var boolValue = true;
        var doubleValue = 3.14;

        // Act
        var intResult = intValue.Serialize();
        var stringResult = stringValue.Serialize();
        var boolResult = boolValue.Serialize();
        var doubleResult = doubleValue.Serialize();

        // Assert
        Assert.Equal("42", intResult);
        Assert.Equal("\"test\"", stringResult);
        Assert.Equal("true", boolResult);
        Assert.Equal("3.14", doubleResult);
    }

    [Fact]
    public void Serialize_ComplexObject_ReturnsCorrectJson()
    {
        // Arrange
        var person = new TestPerson
        {
            Id = 1,
            Name = "John Doe",
            BirthDate = new DateTime(1990, 1, 1),
            Hobbies = ["Reading", "Coding"],
            Address = new TestAddress
            {
                Street = "123 Main St",
                City = "Anytown",
                Country = "USA",
                PostalCode = "12345"
            },
            IsActive = true
        };

        // Act
        var result = person.Serialize();

        // Assert
        Assert.NotNull(result);
        Assert.Contains("\"id\":1", result);
        Assert.Contains("\"name\":\"John Doe\"", result);
        Assert.Contains("\"birthDate\":\"1990-01-01T00:00:00\"", result);
        Assert.Contains("\"hobbies\":[\"Reading\",\"Coding\"]", result);
        Assert.Contains("\"address\":{", result);
        Assert.Contains("\"street\":\"123 Main St\"", result);
        Assert.Contains("\"isActive\":true", result);
    }

    [Fact]
    public void Serialize_Collection_ReturnsCorrectJson()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4, 5 };

        // Act
        var result = list.Serialize();

        // Assert
        Assert.Equal("[1,2,3,4,5]", result);
    }

    [Fact]
    public void Serialize_EmptyCollection_ReturnsEmptyArrayJson()
    {
        // Arrange
        var list = new List<int>();

        // Act
        var result = list.Serialize();

        // Assert
        Assert.Equal("[]", result);
    }

    [Fact]
    public void Serialize_WithCustomOptions_UsesProvidedOptions()
    {
        // Arrange
        var person = new TestPerson
        {
            Id = 1,
            Name = "John Doe"
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        // Act
        var result = person.Serialize(options);

        // Assert
        Assert.NotNull(result);
        Assert.Contains("\n", result);
        Assert.Contains("  ", result);
    }

    #endregion

    #region Serializes

    [Fact]
    public void Serializes_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.Serializes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Serializes_EmptyCollection_ReturnsNullCollection()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.Serializes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Serializes_MixedCollection_ReturnsSerializedItems()
    {
        // Arrange
        var input = new object?[]
        {
            42,
            "test",
            true,
            new TestPerson { Id = 1, Name = "John" },
            null
        };

        // Act
        var result = input.Serializes()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Length);
        Assert.Equal("42", result[0]);
        Assert.Equal("\"test\"", result[1]);
        Assert.Equal("true", result[2]);
        Assert.Contains("\"id\":1", result[3]);
        Assert.Contains("\"name\":\"John\"", result[3]);
        Assert.Null(result[4]);
    }

    [Fact]
    public void Serializes_ParamsOverload_ReturnsSerializedItems()
    {
        // Act
        var result = YANJson.Serializes(42, "test", true, new TestPerson { Id = 1, Name = "John" }, null)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Length);
        Assert.Equal("42", result[0]);
        Assert.Equal("\"test\"", result[1]);
        Assert.Equal("true", result[2]);
        Assert.Contains("\"id\":1", result[3]);
        Assert.Contains("\"name\":\"John\"", result[3]);
        Assert.Null(result[4]);
    }

    [Fact]
    public void Serializes_WithCustomOptions_UsesProvidedOptions()
    {
        // Arrange
        var input = new object[]
        {
            new TestPerson { Id = 1, Name = "John" },
            new TestPerson { Id = 2, Name = "Jane" }
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        // Act
        var result = input.Serializes(options)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Contains("\n", result[0]);
        Assert.Contains("  ", result[0]);
        Assert.Contains("\n", result[1]);
        Assert.Contains("  ", result[1]);
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
    public void SerializeToBytes_PrimitiveTypes_ReturnsCorrectBytes()
    {
        // Arrange
        var intValue = 42;
        var stringValue = "test";
        var boolValue = true;

        // Act
        var intBytes = intValue.SerializeToBytes();
        var stringBytes = stringValue.SerializeToBytes();
        var boolBytes = boolValue.SerializeToBytes();

        // Assert
        Assert.NotNull(intBytes);
        Assert.NotNull(stringBytes);
        Assert.NotNull(boolBytes);

        var intJson = Encoding.UTF8.GetString(intBytes);
        Assert.Equal("42", intJson);

        var stringJson = Encoding.UTF8.GetString(stringBytes);
        Assert.Equal("\"test\"", stringJson);

        var boolJson = Encoding.UTF8.GetString(boolBytes);
        Assert.Equal("true", boolJson);
    }

    [Fact]
    public void SerializeToBytes_ComplexObject_ReturnsCorrectBytes()
    {
        // Arrange
        var person = new TestPerson
        {
            Id = 1,
            Name = "John Doe",
            BirthDate = new DateTime(1990, 1, 1),
            IsActive = true
        };

        // Act
        var bytes = person.SerializeToBytes();

        // Assert
        Assert.NotNull(bytes);

        var json = Encoding.UTF8.GetString(bytes);
        Assert.Contains("\"id\":1", json);
        Assert.Contains("\"name\":\"John Doe\"", json);
        Assert.Contains("\"birthDate\":\"1990-01-01T00:00:00\"", json);
        Assert.Contains("\"isActive\":true", json);
    }

    [Fact]
    public void SerializeToBytes_WithCustomOptions_UsesProvidedOptions()
    {
        // Arrange
        var person = new TestPerson
        {
            Id = 1,
            Name = "John Doe"
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        // Act
        var bytes = person.SerializeToBytes(options);

        // Assert
        Assert.NotNull(bytes);

        var json = Encoding.UTF8.GetString(bytes);
        Assert.Contains("\n", json);
        Assert.Contains("  ", json);
    }

    #endregion

    #region SerializesToBytes

    [Fact]
    public void SerializesToBytes_NullCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<object?>? input = null;

        // Act
        var result = input.SerializesToBytes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SerializesToBytes_EmptyCollection_ReturnsNullCollection()
    {
        // Arrange
        var input = Array.Empty<object?>();

        // Act
        var result = input.SerializesToBytes();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void SerializesToBytes_MixedCollection_ReturnsSerializedItems()
    {
        // Arrange
        var input = new object?[]
        {
            42,
            "test",
            true,
            new TestPerson { Id = 1, Name = "John" },
            null
        };

        // Act
        var result = input.SerializesToBytes()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Length);
        Assert.Null(result[4]);

        var json0 = Encoding.UTF8.GetString(result[0]!);
        Assert.Equal("42", json0);

        var json1 = Encoding.UTF8.GetString(result[1]!);
        Assert.Equal("\"test\"", json1);

        var json2 = Encoding.UTF8.GetString(result[2]!);
        Assert.Equal("true", json2);

        var json3 = Encoding.UTF8.GetString(result[3]!);
        Assert.Contains("\"id\":1", json3);
        Assert.Contains("\"name\":\"John\"", json3);
    }

    [Fact]
    public void SerializesToBytes_ParamsOverload_ReturnsSerializedItems()
    {
        // Act
        var result = YANJson.SerializesToBytes(42, "test", true, new TestPerson { Id = 1, Name = "John" }, null)?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Length);
        Assert.Null(result[4]);

        var json0 = Encoding.UTF8.GetString(result[0]!);
        Assert.Equal("42", json0);

        var json1 = Encoding.UTF8.GetString(result[1]!);
        Assert.Equal("\"test\"", json1);

        var json2 = Encoding.UTF8.GetString(result[2]!);
        Assert.Equal("true", json2);

        var json3 = Encoding.UTF8.GetString(result[3]!);
        Assert.Contains("\"id\":1", json3);
        Assert.Contains("\"name\":\"John\"", json3);
    }

    #endregion

    #region Deserialize String

    [Fact]
    public void Deserialize_NullString_ReturnsDefault()
    {
        // Arrange
        string? input = null;

        // Act
        var result = input.Deserialize<TestPerson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_EmptyString_ReturnsDefault()
    {
        // Arrange
        var input = "";

        // Act
        var result = input.Deserialize<TestPerson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_WhitespaceString_ReturnsDefault()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = input.Deserialize<TestPerson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_InvalidJson_ReturnsDefault()
    {
        // Arrange
        var input = "{invalid json}";

        // Act
        var result = input.Deserialize<TestPerson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_PrimitiveTypes_ReturnsCorrectValues()
    {
        // Arrange
        var intJson = "42";
        var stringJson = "\"test\"";
        var boolJson = "true";
        var doubleJson = "3.14";

        // Act
        var intResult = intJson.Deserialize<int>();
        var stringResult = stringJson.Deserialize<string>();
        var boolResult = boolJson.Deserialize<bool>();
        var doubleResult = doubleJson.Deserialize<double>();

        // Assert
        Assert.Equal(42, intResult);
        Assert.Equal("test", stringResult);
        Assert.True(boolResult);
        Assert.Equal(3.14, doubleResult);
    }

    [Fact]
    public void Deserialize_ComplexObject_ReturnsCorrectObject()
    {
        // Arrange
        var json = @"{
            ""id"": 1,
            ""name"": ""John Doe"",
            ""birthDate"": ""1990-01-01T00:00:00"",
            ""hobbies"": [""Reading"", ""Coding""],
            ""address"": {
                ""street"": ""123 Main St"",
                ""city"": ""Anytown"",
                ""country"": ""USA"",
                ""postalCode"": ""12345""
            },
            ""isActive"": true
        }";

        // Act
        var result = json.Deserialize<TestPerson>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("John Doe", result.Name);
        Assert.Equal(new DateTime(1990, 1, 1), result.BirthDate);
        Assert.Equal(["Reading", "Coding"], result.Hobbies);
        Assert.NotNull(result.Address);
        Assert.Equal("123 Main St", result.Address.Street);
        Assert.Equal("Anytown", result.Address.City);
        Assert.Equal("USA", result.Address.Country);
        Assert.Equal("12345", result.Address.PostalCode);
        Assert.True(result.IsActive);
    }

    [Fact]
    public void Deserialize_Collection_ReturnsCorrectCollection()
    {
        // Arrange
        var json = "[1, 2, 3, 4, 5]";

        // Act
        var result = json.Deserialize<List<int>>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal([1, 2, 3, 4, 5], result);
    }

    [Fact]
    public void Deserialize_CaseInsensitive_DeserializesCorrectly()
    {
        // Arrange
        var json = @"{
            ""ID"": 1,
            ""NAME"": ""John Doe"",
            ""BIRTHDATE"": ""1990-01-01T00:00:00"",
            ""ISACTIVE"": true
        }";

        // Act
        var result = json.Deserialize<TestPerson>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("John Doe", result.Name);
        Assert.Equal(new DateTime(1990, 1, 1), result.BirthDate);
        Assert.True(result.IsActive);
    }

    [Fact]
    public void Deserialize_WithCustomOptions_UsesProvidedOptions()
    {
        // Arrange
        var json = @"{
            ""id"": 1,
            ""name"": ""John Doe""
        }";

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false
        };

        // Act
        var result = json.Deserialize<TestPersonWithDifferentCasing>(options);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("John Doe", result.Name);
    }

    #endregion

    #region Deserializes String

    [Fact]
    public void Deserializes_NullStringCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<string?>? input = null;

        // Act
        var result = input.Deserializes<TestPerson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserializes_EmptyStringCollection_ReturnsNullCollection()
    {
        // Arrange
        var input = Array.Empty<string?>();

        // Act
        var result = input.Deserializes<TestPerson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserializes_MixedStringCollection_ReturnsDeserializedItems()
    {
        // Arrange
        var input = new string?[]
        {
            @"{""id"": 1, ""name"": ""John""}",
            @"{""id"": 2, ""name"": ""Jane""}",
            null,
            "invalid json",
            @"{""id"": 3, ""name"": ""Bob""}"
        };

        // Act
        var result = input.Deserializes<TestPerson>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Length);

        Assert.NotNull(result[0]);
        Assert.Equal(1, result[0]!.Id);
        Assert.Equal("John", result[0]!.Name);

        Assert.NotNull(result[1]);
        Assert.Equal(2, result[1]!.Id);
        Assert.Equal("Jane", result[1]!.Name);

        Assert.Null(result[2]);
        Assert.Null(result[3]);

        Assert.NotNull(result[4]);
        Assert.Equal(3, result[4]!.Id);
        Assert.Equal("Bob", result[4]!.Name);
    }

    [Fact]
    public void Deserializes_ParamsStringOverload_ReturnsDeserializedItems()
    {
        // Act
        var result = YANJson.Deserializes<TestPerson>(
            @"{""id"": 1, ""name"": ""John""}",
            @"{""id"": 2, ""name"": ""Jane""}",
            null,
            "invalid json",
            @"{""id"": 3, ""name"": ""Bob""}")?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Length);

        Assert.NotNull(result[0]);
        Assert.Equal(1, result[0]!.Id);
        Assert.Equal("John", result[0]!.Name);

        Assert.NotNull(result[1]);
        Assert.Equal(2, result[1]!.Id);
        Assert.Equal("Jane", result[1]!.Name);

        Assert.Null(result[2]);
        Assert.Null(result[3]);

        Assert.NotNull(result[4]);
        Assert.Equal(3, result[4]!.Id);
        Assert.Equal("Bob", result[4]!.Name);
    }

    #endregion

    #region Deserialize Bytes

    [Fact]
    public void Deserialize_NullBytes_ReturnsDefault()
    {
        // Arrange
        byte[]? input = null;

        // Act
        var result = input.DeserializeFromBytes<TestPerson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_EmptyBytes_ReturnsDefault()
    {
        // Arrange
        byte[] input = [];

        // Act
        var result = input.DeserializeFromBytes<TestPerson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_InvalidBytes_ReturnsDefault()
    {
        // Arrange
        byte[] input = [0xFF, 0xFF, 0xFF];

        // Act
        var result = input.DeserializeFromBytes<TestPerson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserialize_PrimitiveTypesFromBytes_ReturnsCorrectValues()
    {
        // Arrange
        var intBytes = Encoding.UTF8.GetBytes("42");
        var stringBytes = Encoding.UTF8.GetBytes("\"test\"");
        var boolBytes = Encoding.UTF8.GetBytes("true");
        var doubleBytes = Encoding.UTF8.GetBytes("3.14");

        // Act
        var intResult = intBytes.DeserializeFromBytes<int>();
        var stringResult = stringBytes.DeserializeFromBytes<string>();
        var boolResult = boolBytes.DeserializeFromBytes<bool>();
        var doubleResult = doubleBytes.DeserializeFromBytes<double>();

        // Assert
        Assert.Equal(42, intResult);
        Assert.Equal("test", stringResult);
        Assert.True(boolResult);
        Assert.Equal(3.14, doubleResult);
    }

    [Fact]
    public void Deserialize_ComplexObjectFromBytes_ReturnsCorrectObject()
    {
        // Arrange
        var json = @"{
            ""id"": 1,
            ""name"": ""John Doe"",
            ""birthDate"": ""1990-01-01T00:00:00"",
            ""isActive"": true
        }";

        var bytes = Encoding.UTF8.GetBytes(json);

        // Act
        var result = bytes.DeserializeFromBytes<TestPerson>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result!.Id);
        Assert.Equal("John Doe", result.Name);
        Assert.Equal(new DateTime(1990, 1, 1), result.BirthDate);
        Assert.True(result.IsActive);
    }

    #endregion

    #region Deserializes Bytes

    [Fact]
    public void Deserializes_NullBytesCollection_ReturnsNull()
    {
        // Arrange
        IEnumerable<byte[]?>? input = null;

        // Act
        var result = input.DeserializesFromBytes<TestPerson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserializes_EmptyBytesCollection_ReturnsNullCollection()
    {
        // Arrange
        var input = Array.Empty<byte[]?>();

        // Act
        var result = input.DeserializesFromBytes<TestPerson>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Deserializes_MixedBytesCollection_ReturnsDeserializedItems()
    {
        // Arrange
        var input = new byte[]?[]
        {
            Encoding.UTF8.GetBytes(@"{""id"": 1, ""name"": ""John""}"),
            Encoding.UTF8.GetBytes(@"{""id"": 2, ""name"": ""Jane""}"),
            null,
            Encoding.UTF8.GetBytes("invalid json"),
            Encoding.UTF8.GetBytes(@"{""id"": 3, ""name"": ""Bob""}")
        };

        // Act
        var result = input.DeserializesFromBytes<TestPerson>()?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Length);

        Assert.NotNull(result[0]);
        Assert.Equal(1, result[0]!.Id);
        Assert.Equal("John", result[0]!.Name);

        Assert.NotNull(result[1]);
        Assert.Equal(2, result[1]!.Id);
        Assert.Equal("Jane", result[1]!.Name);

        Assert.Null(result[2]);
        Assert.Null(result[3]);

        Assert.NotNull(result[4]);
        Assert.Equal(3, result[4]!.Id);
        Assert.Equal("Bob", result[4]!.Name);
    }

    [Fact]
    public void Deserializes_ParamsBytesOverload_ReturnsDeserializedItems()
    {
        // Act
        var result = YANJson.DeserializesFromBytes<TestPerson>(
            Encoding.UTF8.GetBytes(@"{""id"": 1, ""name"": ""John""}"),
            Encoding.UTF8.GetBytes(@"{""id"": 2, ""name"": ""Jane""}"),
            null,
            Encoding.UTF8.GetBytes("invalid json"),
            Encoding.UTF8.GetBytes(@"{""id"": 3, ""name"": ""Bob""}"))?.ToArray();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Length);

        Assert.NotNull(result[0]);
        Assert.Equal(1, result[0]!.Id);
        Assert.Equal("John", result[0]!.Name);

        Assert.NotNull(result[1]);
        Assert.Equal(2, result[1]!.Id);
        Assert.Equal("Jane", result[1]!.Name);

        Assert.Null(result[2]);
        Assert.Null(result[3]);

        Assert.NotNull(result[4]);
        Assert.Equal(3, result[4]!.Id);
        Assert.Equal("Bob", result[4]!.Name);
    }

    #endregion

    #region Round Trip Tests

    [Fact]
    public void RoundTrip_SerializeAndDeserialize_PreservesData()
    {
        // Arrange
        var original = new TestPerson
        {
            Id = 1,
            Name = "John Doe",
            BirthDate = new DateTime(1990, 1, 1),
            Hobbies = ["Reading", "Coding"],
            Address = new TestAddress
            {
                Street = "123 Main St",
                City = "Anytown",
                Country = "USA",
                PostalCode = "12345"
            },
            IsActive = true
        };

        // Act
        var json = original.Serialize();
        var deserialized = json.Deserialize<TestPerson>();

        // Assert
        Assert.NotNull(deserialized);
        Assert.Equal(original.Id, deserialized.Id);
        Assert.Equal(original.Name, deserialized.Name);
        Assert.Equal(original.BirthDate, deserialized.BirthDate);
        Assert.Equal(original.Hobbies, deserialized.Hobbies);
        Assert.NotNull(deserialized.Address);
        Assert.Equal(original.Address.Street, deserialized.Address.Street);
        Assert.Equal(original.Address.City, deserialized.Address.City);
        Assert.Equal(original.Address.Country, deserialized.Address.Country);
        Assert.Equal(original.Address.PostalCode, deserialized.Address.PostalCode);
        Assert.Equal(original.IsActive, deserialized.IsActive);
    }

    [Fact]
    public void RoundTrip_SerializeToBytesAndDeserialize_PreservesData()
    {
        // Arrange
        var original = new TestPerson
        {
            Id = 1,
            Name = "John Doe",
            BirthDate = new DateTime(1990, 1, 1),
            IsActive = true
        };

        // Act
        var bytes = original.SerializeToBytes();
        var deserialized = bytes.DeserializeFromBytes<TestPerson>();

        // Assert
        Assert.NotNull(deserialized);
        Assert.Equal(original.Id, deserialized.Id);
        Assert.Equal(original.Name, deserialized.Name);
        Assert.Equal(original.BirthDate, deserialized.BirthDate);
        Assert.Equal(original.IsActive, deserialized.IsActive);
    }

    [Fact]
    public void RoundTrip_CollectionSerializeAndDeserialize_PreservesData()
    {
        // Arrange
        var original = new List<TestPerson>
        {
            new() { Id = 1, Name = "John" },
            new() { Id = 2, Name = "Jane" },
            new() { Id = 3, Name = "Bob" }
        };

        // Act
        var json = original.Serialize();
        var deserialized = json.Deserialize<List<TestPerson>>();

        // Assert
        Assert.NotNull(deserialized);
        Assert.Equal(3, deserialized.Count);
        Assert.Equal(original[0].Id, deserialized[0].Id);
        Assert.Equal(original[0].Name, deserialized[0].Name);
        Assert.Equal(original[1].Id, deserialized[1].Id);
        Assert.Equal(original[1].Name, deserialized[1].Name);
        Assert.Equal(original[2].Id, deserialized[2].Id);
        Assert.Equal(original[2].Name, deserialized[2].Name);
    }

    #endregion

    #region Default Options Tests

    [Fact]
    public void DefaultOptions_Serialize_UsesCamelCase()
    {
        // Arrange
        var person = new TestPerson
        {
            Id = 1,
            Name = "John Doe"
        };

        // Act
        var result = person.Serialize();

        // Assert
        Assert.NotNull(result);
        Assert.Contains("\"id\":1", result);
        Assert.Contains("\"name\":\"John Doe\"", result);
    }

    [Fact]
    public void DefaultOptions_Deserialize_IsCaseInsensitive()
    {
        // Arrange
        var json = @"{
            ""ID"": 1,
            ""NAME"": ""John Doe"",
            ""BIRTHDATE"": ""1990-01-01T00:00:00"",
            ""ISACTIVE"": true
        }";

        // Act
        var result = json.Deserialize<TestPerson>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("John Doe", result.Name);
        Assert.Equal(new DateTime(1990, 1, 1), result.BirthDate);
        Assert.True(result.IsActive);
    }

    #endregion

    #region Test Classes

    private class TestPerson
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public List<string> Hobbies { get; set; } = [];

        public TestAddress? Address { get; set; }

        public bool IsActive { get; set; }
    }

    private class TestAddress
    {
        public string Street { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;
    }

    private class TestPersonWithDifferentCasing
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("hobbies")]
        public List<string> Hobbies { get; set; } = [];

        [JsonPropertyName("address")]
        public TestAddress? Address { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }

    #endregion
}
