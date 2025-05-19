<div align="center">
  <h1>YAMI AN NEPHILIM LIBRARY (YANLib)</h1>
  <img src="https://img.shields.io/badge/.NET-8.0%20LTS-512BD4" alt=".NET 8.0 LTS">
  <img src="https://img.shields.io/nuget/v/Tynab.YANLib" alt="NuGet version">
  <img src="https://img.shields.io/nuget/dt/Tynab.YANLib" alt="NuGet downloads">
  <img src="https://img.shields.io/github/license/Tynab/YANLib" alt="License">
  <br>
  <img src="https://img.shields.io/badge/platform-windows%20%7C%20macos%20%7C%20linux-lightgrey" alt="Platform">
  <br><br>
  <p>A comprehensive .NET utility library providing powerful extension methods for enhanced developer productivity</p>
</div>


## 📋 Table of Contents

- [Installation](#-installation)
- [Overview](#-overview)
- [Key Components](#-key-components)
  - [YANObject](#yanobject)
  - [YANUnmanaged](#yanunmanaged)
  - [YANEnumerable](#yanenumerable)
  - [YANText](#yantext)
  - [YANJson](#yanjson)
  - [YANMath](#yanmath)
  - [YANDateTime](#yandatetime)
  - [YANRandom](#yanrandom)
  - [YANTask](#yantask)
  - [YANProcess](#yanprocess)
  - [YANExpression](#yanexpression)
  - [YANLib.Snowflake](#yanlibsnowflake)
- [Performance Benchmarks](#-performance-benchmarks)
- [Code Examples](#-code-examples)
- [Project Architecture](#-project-architecture)
- [License](#-license)


## 📥 Installation

### Package Manager

```
PM> NuGet\Install-Package Tynab.YANLib
```

### .NET CLI

```
dotnet add package Tynab.YANLib
```

### Package Reference

```xml
<PackageReference Include="Tynab.YANLib" Version="x.x.x" />
```


## 📚 Overview

YANLib offers a collection of specialized components, each focusing on a specific area of functionality. The library is designed with a consistent API, robust error handling, and support for both nullable and non-nullable types. All components are implemented as extension methods, allowing for a fluent and intuitive coding experience.

### Common Features Across All Components

- **Extension Methods**: Implemented as extension methods for a fluent API
- **Null Safety**: Robust handling of null values to prevent NullReferenceExceptions
- **Collection Support**: Methods for both single values and collections
- **Generic Type Support**: Flexible type parameters for input and output types
- **Consistent API**: Similar method naming and behavior across components
- **Performance Optimization**: Efficient implementations with caching where appropriate
- **Parallel Processing**: Automatic parallel processing for large collections (>1000 elements)
- **Debugging Support**: Uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience


## 🧩 Key Components

### YANObject

A comprehensive utility library for object operations and validations, offering methods for checking null values, default values, property states, and manipulating objects and collections.

#### Key Features

- Null and default value checking
- Property analysis
- Collection operations
- Object manipulation (copy, time zone conversion)

```csharp
// Null checking
object? obj = null;
bool isNull = obj.IsNull();      // Returns true
bool isNotNull = obj.IsNotNull(); // Returns false

// Check if all properties have default values
var obj = new TestClass();
bool allPropsDefault = obj.AllPropertiesDefault(); // Returns true if all properties have default values

// Create a shallow copy of an object
var original = new TestClass { StringProperty = "test", IntProperty = 42 };
var copy = original.Copy(); // Creates a new instance with the same property values
```

### YANUnmanaged

A powerful utility library for parsing and converting objects to unmanaged types, supporting various data types, collections, and providing robust error handling.

#### Key Features

- Object parsing with default value fallbacks
- Nullable type parsing with null for invalid inputs
- Collection parsing with robust error handling
- Format support for date/time, TimeSpan, and culture-specific parsing

```csharp
// Parse string to int
object input = "123";
int result = input.Parse<int>(); // Returns 123

// Parse with default value
object invalidInput = "not a number";
int resultWithDefault = invalidInput.Parse<int>(42); // Returns 42

// Parse to enum
object enumInput = "Tuesday";
DayOfWeek day = enumInput.Parse<DayOfWeek>(); // Returns DayOfWeek.Tuesday

// Parse to TimeSpan
object timeInput = "01:30:45";
TimeSpan time = timeInput.Parse<TimeSpan>(); // Returns TimeSpan of 1 hour, 30 minutes, 45 seconds
```

### YANEnumerable

A versatile utility library for converting collections of objects to strongly-typed collections, supporting arrays, lists, hash sets, dictionaries, lookups, and immutable collections.

#### Key Features

- Array, List, and HashSet conversion
- Dictionary and Lookup creation
- Immutable collection support
- Type parsing during conversion

```csharp
// Convert collection of objects to array of integers
IEnumerable<object?> input = ["1", "2", "3"];
int[] result = input.ToArray<int>(); // Returns [1, 2, 3]

// Convert to ImmutableArray<T>
ImmutableArray<int> immutableArray = input.ToImmutableArray<int>(); // Returns ImmutableArray with [1, 2, 3]

// Convert to Dictionary<int, string?>
Dictionary<int, string?> dict = items.ToDictionary<TestItem, int, string?, int, string?>(
    item => item.Id,      // Key selector
    item => item.Name     // Value selector
);
```

### YANText

A comprehensive utility library for text manipulation, character operations, and string validation, offering methods for case conversion, formatting, filtering, and validation.

#### Key Features

- String manipulation (case conversion, whitespace handling)
- String validation with null safety
- Character operations
- Collection text operations
- Nullable character support

```csharp
// Case conversion
string text = "hello world";
string upper = text.Upper(); // Returns "HELLO WORLD"
string title = text.Title(); // Returns "Hello World"
string capitalized = text.Capitalize(); // Returns "Hello world"

// Text formatting
string name = "john.doe";
string formatted = name.FormatName(); // Returns "John Doe"

// Content filtering
string mixed = "abc123!@#";
string letters = mixed.FilterAlphabetic(); // Returns "abc"
string numbers = mixed.FilterNumber(); // Returns "123"
```

### YANJson

A comprehensive utility library for JSON serialization and deserialization, supporting single objects and collections with both string and byte array representations.

#### Key Features

- Object serialization/deserialization
- Collection processing
- Byte array support for better performance
- Default formatting with camel case property naming
- Error handling for serialization/deserialization errors

```csharp
// Serialize an object to a JSON string
var person = new Person { Id = 1, Name = "John Doe" };
string json = person.Serialize();
// Result: {"id":1,"name":"John Doe"}

// Deserialize from JSON string
string personJson = "{\"id\":1,\"name\":\"John Doe\"}";
Person? deserializedPerson = personJson.Deserialize<Person>();
// Result: Person { Id = 1, Name = "John Doe" }

// Serialize to UTF-8 byte array (more efficient for APIs)
byte[] jsonBytes = person.SerializeToBytes();
```

### YANMath

A comprehensive utility library for mathematical operations, providing extension methods for statistical functions, rounding operations, power functions, trigonometric functions, and more.

#### Key Features

- Statistical functions (Min, Max, Average, Sum)
- Rounding operations (Truncate, Ceiling, Floor, Round)
- Power functions (Sqrt, Cbrt, Pow, Abs)
- Trigonometric functions (Sin, Cos, Tan, Asin, Acos, Atan)
- Logarithmic and exponential functions

```csharp
// Statistical functions
double min = YANMath.Min(5.2, 3.1, 7.8, 2.4); // Returns 2.4
double max = YANMath.Max(5.2, 3.1, 7.8, 2.4); // Returns 7.8
double avg = YANMath.Average(5.2, 3.1, 7.8, 2.4); // Returns 4.625

// Power functions
double sqrt = 16.0.Sqrt(); // Returns 4.0
double powered = 2.0.Pow(3); // Returns 8.0
double abs = (-5.0).Abs(); // Returns 5.0
```

### YANDateTime

A comprehensive utility library for DateTime operations, offering methods for week number calculations, month differences, time zone conversions, and collection processing.

#### Key Features

- Week number calculation
- Month difference calculation
- Time zone conversion
- Collection operations
- Generic type support

```csharp
// Get week number for a specific date
var date = new DateTime(2023, 6, 15);
int weekNumber = date.GetWeekOfYear(); // Returns 24

// Calculate months between two dates
var date1 = new DateTime(2023, 6, 15);
var date2 = new DateTime(2022, 6, 15);
int monthDiff = YANDateTime.TotalMonth(date1, date2); // Returns 12

// Change time zone for a DateTime
var date = new DateTime(2023, 6, 15, 10, 0, 0);
var convertedDate = date.ChangeTimeZone(0, 3); // UTC to UTC+3, returns 2023-6-15 13:00:00
```

### YANRandom

A comprehensive utility library for generating random values of various types, supporting ranges, collections, and nullable types.

#### Key Features

- Random value generation for various types
- Range-based generation with min/max constraints
- Collection operations for generating random collections
- Type flexibility with generic support

```csharp
// Generate random values of various types
int randomInt = YANRandom.GenerateRandom<int>(); // Random int
double boundedDouble = YANRandom.GenerateRandom<double>(-10.5, 10.5); // Random double in range
DateTime randomDate = YANRandom.GenerateRandom<DateTime>(); // Random DateTime
bool randomBool = YANRandom.GenerateRandom<bool>(); // Random boolean

// Generate collections of random values
IEnumerable<int> randomInts = YANRandom.GenerateRandoms<int>(size: 10); // 10 random ints
IEnumerable<double> randomDoubles = YANRandom.GenerateRandoms<double>(-10.5, 10.5, 5); // 5 random doubles in range
```

### YANTask

A specialized utility library that extends the Task Parallel Library (TPL), providing methods for filtering and processing task results based on conditions.

#### Key Features

- Conditional task waiting
- Multiple result filtering
- Asynchronous enumeration
- Error handling with exception safety
- Cancellation support

```csharp
// Wait for any task that returns a value greater than 5
var tasks = new[]
{
    Task.FromResult(3),
    Task.FromResult(7),
    Task.FromResult(2),
    Task.FromResult(10)
};

// Using WaitAnyWithCondition - returns as soon as it finds a match
int? result = await tasks.WaitAnyWithCondition(x => x > 5);
Console.WriteLine(result); // Output: 7

// Using WhenAnyWithCondition - waits for tasks to complete until it finds a match
int? anotherResult = await tasks.WhenAnyWithCondition(x => x > 8);
Console.WriteLine(anotherResult); // Output: 10
```

### YANProcess

A specialized utility library for managing system processes, focusing on process termination operations.

#### Key Features

- Process termination by name
- Multiple process management
- Asynchronous operations
- Process cleanup with automatic resource disposal

```csharp
// Kill all instances of a process with a specific name
await "notepad".KillAllProcessesByName();

// Kill multiple processes using a collection
var processNames = new List<string?>
{
    "notepad",
    "calc",
    "mspaint"
};

await processNames.KillAllProcessesByNames();
```

### YANExpression

A specialized utility library for creating and manipulating strongly-typed expressions, particularly focused on property access.

#### Key Features

- Property access expression building
- Type safety with proper type information
- Value type handling with automatic boxing
- Expression caching for better performance

```csharp
// Create a property expression for accessing the Name property on a Person object
var expression = YANExpression.PropertyExpression<Person>("p", "Name");

// Compile and use the expression
var func = expression.Compile();
var person = new Person { Name = "John", Age = 30 };
string name = (string)func(person); // Returns "John"
```

### YANLib.Snowflake

A robust implementation of the Snowflake ID algorithm for generating distributed, time-ordered unique identifiers in C# applications.

#### Key Features

- 64-bit unique ID generation
- Alphabetic and alphanumeric string representations
- Time-ordered IDs for easy sorting
- Distributed system support with worker and datacenter IDs
- Component extraction from existing IDs
- Predefined bit allocation strategies for different use cases
- Customizable bit allocation for specialized scaling needs

```csharp
// Create an ID generator with worker ID 1 and datacenter ID 1
var generator = new IdGenerator(1, 1);

// Generate a numeric ID
long id = generator.NextId();
// Example: 6982190104624234496

// Generate an alphabetic ID (base-26, A-Z)
string alphabeticId = generator.NextIdAlphabetic();
// Example: "BPNHEBKDMGLCQ"

// Generate an alphanumeric ID (base-36, 0-9, A-Z)
string alphanumericId = generator.NextIdAlphanumeric();
// Example: "1Z9DHPKW0S"

// Create a generator with a predefined bit allocation strategy
// MoreDistributed: 10 bits for worker ID (0-1023), 10 bits for datacenter ID (0-1023), 3 bits for sequence (0-7)
var distributedGenerator = new IdGenerator(100, 200, BitAllocationStrategy.MoreDistributed);

// HighVolume: 2 bits for worker ID (0-3), 2 bits for datacenter ID (0-3), 19 bits for sequence (0-524,287)
var highVolumeGenerator = new IdGenerator(1, 1, BitAllocationStrategy.HighVolume);

// Extract components from an ID
var components = IdGenerator.ExtractIdComponents(id);
DateTime timestamp = components.Timestamp;
long workerId = components.WorkerId;
long datacenterId = components.DatacenterId;

// Extract components using the same strategy used to generate the ID
var strategicComponents = IdGenerator.ExtractIdComponents(
    distributedGenerator.NextId(),
    BitAllocationStrategy.MoreDistributed
);
```


## 📊 Performance Benchmarks

YANLib is designed with performance in mind. The library uses various optimizations to ensure high performance:

- Caching of expressions and reflection results
- Efficient memory usage with custom pooling
- Parallel processing for large collections where appropriate
- Optimized algorithms for common operations

### JSON Performance

YANJson is built on System.Text.Json, which offers significantly better performance compared to Newtonsoft.Json, especially for large datasets.

<div align="center">
  <img src='https://raw.githubusercontent.com/Tynab/YANLib/refs/heads/main/pic/1.jpg' alt="JSON Performance Comparison">
</div>

System.Text.Json is designed to provide better performance and security compared to other JSON libraries. It supports advanced features like parallel parsing and support for new data types such as Span and Utf8JsonReader, enabling faster data processing and reduced memory usage.

Based on performance benchmark tests conducted in different environments and scenarios, System.Text.Json is generally considered to have the best performance among these libraries. According to performance tests, the results show that System.Text.Json has significantly faster JSON-to-.NET object and vice versa conversion times compared to Newtonsoft.Json, especially in cases with large data.

#### Case Sensitivity and Configuration

When the properties of the object to be serialized to JSON have different capitalization, exceptions can occur when using JSON libraries. YANJson handles property case sensitivity issues elegantly while maintaining high performance.

To address case sensitivity issues, standard approaches include:

1. Configure `JsonSerializerOptions.PropertyNameCaseInsensitive` to ensure that the Deserialize process can find properties regardless of their capitalization
2. Use `JsonSerializerOptions.IgnoreNullValues` to exclude properties with null values during serialization
3. Use `JsonSerializerOptions.WriteIndented` to configure the formatting of the serialized result
4. Use `JsonSerializerOptions.MaxDepth` to limit the maximum depth of the object being serialized or deserialized
5. Use `JsonSerializerOptions.DictionaryKeyPolicy` to configure the naming of keys in a Dictionary


However, using these options can affect performance. YANJson provides optimized methods that maintain high performance while handling case sensitivity appropriately.

For the most recent performance benchmarks, visit:
[https://yanlib.yamiannephilim.com/api/json/yan-vs-standards?quantity=10000&hideSystem=true](https://yanlib.yamiannephilim.com/api/json/yan-vs-standards?quantity=10000&hideSystem=true)

<div align="center">
  <img src='https://raw.githubusercontent.com/Tynab/YANLib/refs/heads/main/pic/0.jpg' alt="YAN vs Standards Performance">
</div>


## 💻 Code Examples

### Data Processing Pipeline

```csharp
public List<Product> ProcessProductData(string[] rawData)
{
    return rawData
        .Where(line => line.IsNotNullWhiteSpace())
        .Select(line => line.Split(','))
        .Select(parts => new Product
        {
            Id = parts[0].Parse<int>(),
            Name = parts[1].CleanSpace().Capitalize(),
            Price = parts[2].Parse<decimal>(),
            IsAvailable = parts[3].Parse<bool>()
        })
        .Where(p => p.Id > 0 && p.Name.IsNotNullEmpty())
        .ToList();
}
```

### Asynchronous Operations with Error Handling

```csharp
public async Task<WeatherData> GetWeatherFromMultipleProviders(string location)
{
    var providers = new[]
    {
        GetWeatherFromProvider1(location),
        GetWeatherFromProvider2(location),
        GetWeatherFromProvider3(location)
    };

    // Return the first non-null weather data
    return await providers.WaitAnyWithCondition(data => data != null);
}
```

### Object Validation and Transformation

```csharp
public bool IsValidCustomer(Customer customer)
{
    // Customer must not be null and must have all required properties set
    return customer.IsNotNull() && 
           !customer.AnyPropertiesDefault(["Name", "Email", "PhoneNumber"]);
}

public Customer PrepareCustomerData(Customer customer)
{
    // Create a copy and normalize the data
    var normalizedCustomer = customer.Copy();

    normalizedCustomer.Name = normalizedCustomer.Name.CleanSpace().FormatName();
    normalizedCustomer.Email = normalizedCustomer.Email.Lower();
    normalizedCustomer.PhoneNumber = normalizedCustomer.PhoneNumber.FilterNumber();
    
    return normalizedCustomer;
}
```

### Unique ID Generation with Snowflake

```csharp
public class IdService
{
    private readonly IdGenerator _userIdGenerator;
    private readonly IdGenerator _orderIdGenerator;
    private readonly IdGenerator _highVolumeGenerator;
    
    public IdService()
    {
        // Create separate generators for different entity types
        _userIdGenerator = new IdGenerator(1, 1);
        _orderIdGenerator = new IdGenerator(2, 1);
        
        // Create a high-volume generator with custom bit allocation
        // 2 bits for worker ID, 2 bits for datacenter ID, 19 bits for sequence
        _highVolumeGenerator = new IdGenerator(
            workerId: 1,
            datacenterId: 1,
            sequence: 0,
            workerIdBits: 2,
            datacenterIdBits: 2,
            sequenceBits: 19
        );
    }
    
    public string GenerateUserId()
    {
        // Generate a compact alphanumeric ID for users
        return _userIdGenerator.NextIdAlphanumeric();
    }
    
    public long GenerateOrderId()
    {
        // Generate a numeric ID for orders
        return _orderIdGenerator.NextId();
    }
    
    public long GenerateHighVolumeId()
    {
        // Generate an ID optimized for high volume (up to 524,287 IDs per millisecond)
        return _highVolumeGenerator.NextId();
    }
    
    public DateTime GetIdCreationTime(long id)
    {
        // Extract the timestamp from an ID
        var components = IdGenerator.ExtractIdComponents(id);

        return components.Timestamp;
    }
}
```

### Random Test Data Generation

```csharp
public class TestDataGenerator
{
    public List<User> GenerateUsers(int count)
    {
        return YANRandom.GenerateRandoms<int>(size: count)
            .Select(i => new User
            {
                Id = i,
                Name = YANRandom.GenerateRandom<string>(),
                Age = YANRandom.GenerateRandom<int>(18, 80),
                RegistrationDate = YANRandom.GenerateRandom<DateTime>(
                    new DateTime(2020, 1, 1),
                    DateTime.Now
                ),
                IsActive = YANRandom.GenerateRandom<bool>()
            })
            .ToList();
    }
}
```

### Mathematical Calculations

```csharp
public double CalculateStatistics(IEnumerable<double> values)
{
    // Calculate various statistics
    double min = values.Min();
    double max = values.Max();
    double avg = values.Average();
    double sum = values.Sum();
    
    // Apply mathematical transformations
    var transformed = values
        .Select(v => v.Sqrt())
        .Select(v => v.Pow(2))
        .Select(v => v.Round(2))
        .ToList();
    
    return transformed.Average();
}
```


## 🏗️ Project Architecture

YANLib is based on .NET 8.0 (LTS) and consists of the following main components:

### Extensions

- Object
- Unmanaged
- Enumerable
- Text
- Json
- Math
- DateTime
- Random
- Task
- Process
- Expression
- Snowflake

### Project Structure

```plaintext
YANLib/
├── Core/
│   ├── Object/
│   │   ├── YANObject.cs
│   │   ├── YANObject.Property.cs
│   │   └── ...
│   ├── Unmanaged/
│   │   ├── YANUnmanaged.cs
│   │   ├── YANUnmanaged.Collection.cs
│   │   └── ...
│   ├── Enumerable/
│   │   ├── YANEnumerable.Generic.cs
│   │   ├── YANEnumerable.Generic.Immutable.cs
│   │   └── ...
│   └── Text/
│       ├── YANText.cs
│       ├── YANText.Char.cs
│       └── ...
├── Data & Serialization/
│   ├── Json/
│   │   ├── YANJson.cs
│   │   ├── YANJson.Collection.cs
│   │   └── ...
│   ├── Math/
│   │   ├── YANMath.cs
│   │   ├── YANMath.Collection.cs
│   │   └── ...
│   ├── DateTime/
│   │   ├── YANDateTime.cs
│   │   ├── YANDateTime.Generic.cs
│   │   └── ...
│   └── Random/
│       ├── YANRandom.cs
│       ├── YANRandom.Nullable.cs
│       └── ...
├── Concurrency & Process/
│   ├── Task/
│   │   ├── YANTask.cs
│   │   ├── YANTask.Collection.cs
│   │   └── ...
│   └── Process/
│       ├── YANProcess.cs
│       ├── YANProcess.Collection.cs
│       └── ...
└── Advanced/
    ├── Expression/
    │   ├── YANExpression.cs
    │   ├── YANExpression.Implement.cs
    │   └── ...
    └── Snowflake/
        ├── IdGenerator.Constant.cs
        ├── IdGenerator.Constructor.cs
        └── ...
```

### Technical Details

Each component in YANLib is implemented with careful attention to performance, memory usage, and error handling:

- **YANObject**: Uses reflection caching for property access, implements efficient null and default value checking
- **YANUnmanaged**: Implements specialized parsing methods for each unmanaged type with format support
- **YANEnumerable**: Uses optimized collection conversion with LINQ integration and immutable collection support
- **YANText**: Implements efficient string manipulation using StringBuilder where appropriate
- **YANJson**: Uses System.Text.Json with optimized options caching and UTF-8 encoding support
- **YANMath**: Wraps System.Math methods with extension methods and implements overflow protection
- **YANDateTime**: Implements ISO 8601 week numbering and time zone conversion with overflow protection
- **YANRandom**: Extends System.Random with type-specific generation and range validation
- **YANTask**: Uses HashSet<Task`<T>`> for efficient task tracking and implements async/await patterns
- **YANProcess**: Uses Process.GetProcessesByName() with proper resource cleanup
- **YANExpression**: Uses expression trees with thread-safe caching in ConcurrentDictionary
- **YANLib.Snowflake**: Implements the Snowflake algorithm with bit manipulation for efficient ID generation and customizable bit allocation


### Important Notes

- Elastic.Apm... (v1.24.x and above) is spam logs.
- DotNetCap.CAP... (v8.3.2 and above) error CreateConnectionAsync method.
- Do not [Remove Unused References...] in layers:
    - Host:
        - Microsoft.EntityFrameworkCore.Tools
        - DotNetCap.CAP...
        - Serilog...
        - Volo.Abp.EntityFrameworkCore.SqlServer
    - Domain.Shared:
        - Microsoft.Extensions.FileProviders.Embedded


## 📜 License

YANLib is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

<div align="center">
  <p>
    <a href="https://github.com/Tynab/YANLib">GitHub</a> •
    <a href="https://www.nuget.org/packages/Tynab.YANLib">NuGet</a> •
    <a href="https://github.com/Tynab/YANLib/wiki">Wiki</a>
  </p>
</div>
