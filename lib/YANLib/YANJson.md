### YANJson Component

The `YANJson` component is part of the YANLib library, providing powerful and flexible JSON serialization and deserialization utilities with robust error handling and collection support.


## Overview

YANJson offers a comprehensive set of extension methods for working with JSON data, built on top of System.Text.Json. It provides a clean, fluent API for converting between .NET objects and JSON representations, with support for both string and binary formats.


## Key Features

### Simple Object Serialization

Convert objects to JSON strings or byte arrays:

```csharp
// Serialize an object to a JSON string
string json = myObject.Serialize();

// Serialize an object to a byte array
byte[] bytes = myObject.SerializeToBytes();
```

### Object Deserialization

Convert JSON strings or byte arrays back to objects:

```csharp
// Deserialize a JSON string to an object
MyClass obj = jsonString.Deserialize<MyClass>();

// Deserialize a byte array to an object
MyClass obj = byteArray.DeserializeFromBytes<MyClass>();
```

### Collection Processing

Batch process collections of objects:

```csharp
// Serialize a collection of objects to JSON strings
IEnumerable<string> jsonStrings = myObjects.Serializes();

// Deserialize a collection of JSON strings to objects
IEnumerable<MyClass> objects = jsonStrings.Deserializes<MyClass>();
```

### Customization Options

Configure serialization behavior with JsonSerializerOptions:

```csharp
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = null,  // Use property names as-is
    WriteIndented = true          // Format JSON with indentation
};

string json = myObject.Serialize(options);
```


## Null Handling

YANJson provides robust null handling:

- Null inputs return null outputs
- Empty collections return null
- Invalid JSON is handled gracefully, returning null instead of throwing exceptions
- Collections with mixed null values preserve the nulls in the result


## Technical Details

### Single Object Methods

| Method | Description
|-----|-----
| `Serialize()` | Converts an object to a JSON string
| `SerializeToBytes()` | Converts an object to a JSON byte array
| `Deserialize<T>()` | Converts a JSON string to an object of type T
| `DeserializeFromBytes<T>()` | Converts a JSON byte array to an object of type T

### Collection Methods

| Method | Description
|-----|-----
| `Serializes()` | Converts a collection of objects to JSON strings
| `SerializesToBytes()` | Converts a collection of objects to JSON byte arrays
| `Deserializes<T>()` | Converts a collection of JSON strings to objects of type T
| `DeserializesFromBytes<T>()` | Converts a collection of JSON byte arrays to objects of type T


## Usage Examples

### Basic Serialization and Deserialization

```csharp
// Define a class
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// Create an object
var person = new Person { Id = 1, Name = "John Doe" };

// Serialize to JSON
string json = person.Serialize();
// Result: {"id":1,"name":"John Doe"}

// Deserialize back to object
Person deserializedPerson = json.Deserialize<Person>();
// deserializedPerson.Id == 1
// deserializedPerson.Name == "John Doe"
```

### Working with Collections

```csharp
// Create a collection of objects
var people = new List<Person>
{
    new Person { Id = 1, Name = "John Doe" },
    new Person { Id = 2, Name = "Jane Smith" },
    new Person { Id = 3, Name = "Bob Johnson" }
};

// Serialize collection to JSON strings
IEnumerable<string> jsonStrings = people.Serializes();
// Result: ["{"id":1,"name":"John Doe"}", "{"id":2,"name":"Jane Smith"}", "{"id":3,"name":"Bob Johnson"}"]

// Deserialize collection back to objects
IEnumerable<Person> deserializedPeople = jsonStrings.Deserializes<Person>();
```

### Binary Serialization

```csharp
// Serialize to byte array
var person = new Person { Id = 1, Name = "John Doe" };
byte[] bytes = person.SerializeToBytes();

// Deserialize from byte array
Person deserializedPerson = bytes.DeserializeFromBytes<Person>();
```

### Handling Null Values

```csharp
// Null input handling
Person nullPerson = null;
string json = nullPerson.Serialize(); // Returns null

// Empty string handling
Person result = "".Deserialize<Person>(); // Returns null

// Invalid JSON handling
Person result = "{invalid json}".Deserialize<Person>(); // Returns null

// Mixed null values in collections
var mixedPeople = new Person[]
{
    new Person { Id = 1, Name = "John" },
    null,
    new Person { Id = 3, Name = "Bob" }
};

var jsonStrings = mixedPeople.Serializes();
// Result: ["{"id":1,"name":"John"}", null, "{"id":3,"name":"Bob"}"]

var deserializedMixed = jsonStrings.Deserializes<Person>();
// Result: [Person{Id=1, Name="John"}, null, Person{Id=3, Name="Bob"}]
```

### Custom Serialization Options

```csharp
// Create custom options
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = null, // Use original property names
    WriteIndented = true,        // Format with indentation
    IgnoreNullValues = true      // Exclude null properties
};

// Use custom options
var person = new Person { Id = 1, Name = "John Doe" };
string json = person.Serialize(options);
// Result:
// {
//   "Id": 1,
//   "Name": "John Doe"
// }

// Custom options with deserialization
Person deserializedPerson = json.Deserialize<Person>(options);
```

### Params Overloads

```csharp
// Serialize multiple objects at once
var jsonStrings = YANJson.Serializes(
    new Person { Id = 1, Name = "John" },
    new Person { Id = 2, Name = "Jane" },
    new Person { Id = 3, Name = "Bob" }
);

// Deserialize multiple JSON strings at once
var people = YANJson.Deserializes<Person>(
    "{\"id\":1,\"name\":\"John\"}",
    "{\"id\":2,\"name\":\"Jane\"}",
    "{\"id\":3,\"name\":\"Bob\"}"
);
```

### Working with Complex Objects

```csharp
// Define a complex class with nesting
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Person> Employees { get; set; }
}

// Create and serialize a complex object
var department = new Department
{
    Id = 1,
    Name = "Engineering",
    Employees = new List<Person>
    {
        new Person { Id = 1, Name = "John" },
        new Person { Id = 2, Name = "Jane" }
    }
};

string json = department.Serialize();
// Result: {"id":1,"name":"Engineering","employees":[{"id":1,"name":"John"},{"id":2,"name":"Jane"}]}

// Deserialize complex object
Department deserializedDept = json.Deserialize<Department>();
```

### Error Handling

```csharp
// Safe deserialization with error handling
public T SafeDeserialize<T>(string json) where T : class
{
    try
    {
        return json.Deserialize<T>() ?? throw new InvalidOperationException("Deserialization returned null");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error deserializing JSON: {ex.Message}");
        
        return null;
    }
}
```


## Performance Considerations

- YANJson uses System.Text.Json under the hood, which offers better performance than Newtonsoft.Json
- Collection methods process each item individually, allowing for partial success even when some items fail
- The library handles edge cases gracefully without throwing exceptions, improving robustness
- Consider using byte array methods for large objects to avoid string encoding/decoding overhead
