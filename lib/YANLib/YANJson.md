### YANJson - JSON Serialization Utility Library

## Overview

`YANJson` is a comprehensive utility library that provides extension methods for JSON serialization and deserialization in C# applications. It offers a simplified API for converting objects to and from JSON format, with support for both single objects and collections, and handles both string and byte array representations.

## Features

The library is organized into several functional categories:

### Single Object Operations

- **Object Serialization**: Convert objects to JSON strings or byte arrays
- **Object Deserialization**: Convert JSON strings or byte arrays to strongly-typed objects
- **Default Formatting**: Automatic camel case property naming for serialization
- **Error Handling**: Graceful handling of serialization/deserialization errors


### Collection Operations

- **Collection Serialization**: Convert collections of objects to JSON strings or byte arrays
- **Collection Deserialization**: Convert collections of JSON strings or byte arrays to strongly-typed objects
- **Generic Collection Support**: Type-specific processing for generic collections
- **Non-Generic Collection Support**: Support for legacy `IEnumerable` collections


### Performance Optimizations

- **Byte Array Support**: Direct serialization to/from UTF-8 encoded byte arrays for better performance
- **Parallel Processing**: Automatic parallel processing for large collections (1000+ elements)
- **Default Options Caching**: Reuse of common serialization/deserialization options


## Usage Examples

### Single Object Operations

```csharp
// Serialize an object to a JSON string
var person = new Person { Id = 1, Name = "John Doe" };
string json = person.Serialize();
// Result: {"id":1,"name":"John Doe"}

// Serialize with custom options
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = null, // Use original property names
    WriteIndented = true // Format with indentation
};
string prettyJson = person.Serialize(options);
// Result:
// {
//   "Id": 1,
//   "Name": "John Doe"
// }

// Serialize to UTF-8 byte array (more efficient for APIs)
byte[] jsonBytes = person.SerializeToBytes();

// Deserialize from JSON string
string personJson = "{\"id\":1,\"name\":\"John Doe\"}";
Person? deserializedPerson = personJson.Deserialize<Person>();
// Result: Person { Id = 1, Name = "John Doe" }

// Deserialize with case-insensitive property matching
string differentCaseJson = "{\"ID\":1,\"NAME\":\"John Doe\"}";
Person? caseInsensitivePerson = differentCaseJson.Deserialize<Person>();
// Result: Person { Id = 1, Name = "John Doe" }

// Deserialize from UTF-8 byte array
byte[] personJsonBytes = Encoding.UTF8.GetBytes("{\"id\":1,\"name\":\"John Doe\"}");
Person? byteDeserializedPerson = personJsonBytes.DeserializeFromBytes<Person>();
// Result: Person { Id = 1, Name = "John Doe" }

// Graceful error handling
string invalidJson = "{invalid json}";
Person? nullResult = invalidJson.Deserialize<Person>(); // Returns null instead of throwing
```

### Collection Operations

```csharp
// Serialize a collection of objects to JSON strings
var people = new List<Person>
{
    new Person { Id = 1, Name = "John Doe" },
    new Person { Id = 2, Name = "Jane Smith" },
    new Person { Id = 3, Name = "Bob Johnson" }
};

IEnumerable<string?>? jsonStrings = people.Serializes();
// Result: ["{"id":1,"name":"John Doe"}", "{"id":2,"name":"Jane Smith"}", "{"id":3,"name":"Bob Johnson"}"]

// Serialize a collection to byte arrays
IEnumerable<byte[]?>? jsonByteArrays = people.SerializesToBytes();

// Serialize with params syntax
IEnumerable<string?>? moreJsonStrings = YANJson.Serializes(
    new Person { Id = 1, Name = "John Doe" },
    new Person { Id = 2, Name = "Jane Smith" }
);

// Serialize non-generic collections
System.Collections.ArrayList legacyList = new()
{
    new Person { Id = 1, Name = "John Doe" },
    new Person { Id = 2, Name = "Jane Smith" }
};
IEnumerable<string?>? legacyJsonStrings = legacyList.Serializes();

// Deserialize a collection of JSON strings
var jsonCollection = new string?[]
{
    "{\"id\":1,\"name\":\"John Doe\"}",
    "{\"id\":2,\"name\":\"Jane Smith\"}",
    null, // Handles null values gracefully
    "{\"id\":3,\"name\":\"Bob Johnson\"}"
};

IEnumerable<Person?>? deserializedPeople = jsonCollection.Deserializes<Person>();
// Result: [Person { Id = 1, Name = "John Doe" }, Person { Id = 2, Name = "Jane Smith" }, null, Person { Id = 3, Name = "Bob Johnson" }]

// Deserialize with params syntax
IEnumerable<Person?>? morePeople = YANJson.Deserializes<Person>(
    "{\"id\":1,\"name\":\"John Doe\"}",
    "{\"id\":2,\"name\":\"Jane Smith\"}"
);

// Deserialize from byte arrays
var byteArrayCollection = new byte[]?[]
{
    Encoding.UTF8.GetBytes("{\"id\":1,\"name\":\"John Doe\"}"),
    Encoding.UTF8.GetBytes("{\"id\":2,\"name\":\"Jane Smith\"}"),
    null // Handles null values gracefully
};

IEnumerable<Person?>? bytesDeserializedPeople = byteArrayCollection.DeserializesFromBytes<Person>();
```

### Generic Collection Operations

```csharp
// Serialize a generic collection with specific type
IEnumerable<int?> numbers = new int?[] { 1, 2, null, 4, 5 };
IEnumerable<string?>? serializedNumbers = numbers.Serializes();
// Result: ["1", "2", null, "4", "5"]

// Serialize a generic collection to byte arrays
IEnumerable<byte[]?>? numberByteArrays = numbers.SerializesToBytes();

// Mixed type collections with nulls
var mixedPeople = new Person?[]
{
    new Person { Id = 1, Name = "John Doe" },
    null,
    new Person { Id = 3, Name = "Bob Johnson" }
};

IEnumerable<string?>? mixedJsonStrings = mixedPeople.Serializes();
// Result: ["{"id":1,"name":"John Doe"}", null, "{"id":3,"name":"Bob Johnson"}"]
```

### Advanced Usage Examples

```csharp
// Custom serialization options
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
};

// Serialize complex nested objects
var company = new Company
{
    Id = 1,
    Name = "Acme Corp",
    Employees = new List<Person>
    {
        new Person { Id = 1, Name = "John Doe" },
        new Person { Id = 2, Name = "Jane Smith" }
    }
};

string companyJson = company.Serialize(options);

// Process large collections efficiently (automatic parallel processing)
var largePeopleList = Enumerable.Range(1, 10000)
    .Select(i => new Person { Id = i, Name = $"Person {i}" })
    .ToList();

// This will automatically use parallel processing
IEnumerable<string?>? largeJsonCollection = largePeopleList.Serializes();

// Combining with LINQ for advanced scenarios
var processedData = people
    .Where(p => p.Id > 1)
    .Select(p => new { p.Name, UppercaseName = p.Name?.ToUpper() })
    .Serializes()
    .Where(json => json != null)
    .Select(json => json!.Contains("JANE") ? json : null)
    .ToList();
```

## Performance Considerations

- **Byte Array Operations**: Using `SerializeToBytes` and `DeserializeFromBytes` is more efficient when working with APIs that accept byte arrays
- **Parallel Processing**: For collections with more than 1000 elements, the library automatically uses parallel processing for better performance
- **Default Options Caching**: The library caches commonly used serialization options to avoid recreating them for each operation
- **Error Handling**: Deserialization methods catch exceptions internally and return null/default instead of throwing, which can improve application resilience
- **Memory Efficiency**: The implementation is designed to minimize unnecessary memory allocations


## Implementation Details

- **Default Serialization Options**: Uses camel case property naming by default for serialization
- **Default Deserialization Options**: Uses case-insensitive property matching by default for deserialization
- **Null Handling**: All methods handle null inputs gracefully, returning null rather than throwing exceptions
- **Debugging Support**: Uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience
- **Extension Methods**: Implemented as extension methods for better integration with existing code
- **Partial Classes**: Uses partial classes to organize functionality by category


## JSON Serialization Coverage

The library provides comprehensive coverage of JSON serialization operations:

| Category | Functions |
|----------|-----------|
| **Object Serialization** | Serialize, SerializeToBytes |
| **Object Deserialization** | Deserialize<T>, DeserializeFromBytes<T> |
| **Collection Serialization** | Serializes, SerializesToBytes |
| **Collection Deserialization** | Deserializes<T>, DeserializesFromBytes<T> |
| **Options Customization** | All methods support custom JsonSerializerOptions |
| **Non-Generic Collection Support** | Extension methods for IEnumerable |
| **Params Array Support** | Static methods with params object[] parameters |
| **Error Handling** | All deserialization methods handle exceptions gracefully |


## Technical Details

- **JSON Serialization**: Uses `System.Text.Json` for modern, high-performance JSON processing
- **Default Options**: Configures default serialization options with camelCase property naming
- **Default Deserialization Options**: Uses case-insensitive property matching for more flexible deserialization
- **UTF-8 Encoding**: Implements direct byte array serialization/deserialization for better performance
- **Options Caching**: Caches commonly used serialization/deserialization options to avoid recreation
- **Exception Handling**: Implements try-catch patterns to prevent exceptions from propagating to calling code
- **Parallel Processing**: Uses parallel processing for serializing/deserializing large collections
- **Memory Efficiency**: Minimizes memory allocations during serialization/deserialization operations
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
