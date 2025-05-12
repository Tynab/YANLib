# YANLib

Welcome to the YANLib documentation! YANLib is a comprehensive .NET utility library that provides a wide range of extension methods and helper classes to simplify common programming tasks and enhance developer productivity.


## Overview

YANLib offers a collection of specialized components, each focusing on a specific area of functionality. The library is designed with a consistent API, robust error handling, and support for both nullable and non-nullable types. All components are implemented as extension methods, allowing for a fluent and intuitive coding experience.


## Key Components

### [YANObject](YANObject)

A comprehensive utility library for object operations and validations, offering methods for checking null values, default values, property states, and manipulating objects and collections.

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

### [YANUnmanaged](YANUnmanaged)

A powerful utility library for parsing and converting objects to unmanaged types, supporting various data types, collections, and providing robust error handling.

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
```

### [YANEnumerable](YANEnumerable)

A versatile utility library for converting collections of objects to strongly-typed collections, supporting arrays, lists, hash sets, dictionaries, lookups, and immutable collections.

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

### [YANText](YANText)

A comprehensive utility library for text manipulation, character operations, and string validation, offering methods for case conversion, formatting, filtering, and validation.

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

### [YANJson](YANJson)

A comprehensive utility library for JSON serialization and deserialization, supporting single objects and collections with both string and byte array representations.

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

### [YANMath](YANMath)

A comprehensive utility library for mathematical operations, providing extension methods for statistical functions, rounding operations, power functions, trigonometric functions, and more.

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

### [YANDateTime](YANDateTime)

A comprehensive utility library for DateTime operations, offering methods for week number calculations, month differences, time zone conversions, and collection processing.

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

### [YANRandom](YANRandom)

A comprehensive utility library for generating random values of various types, supporting ranges, collections, and nullable types.

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

### [YANTask](YANTask)

A specialized utility library that extends the Task Parallel Library (TPL), providing methods for filtering and processing task results based on conditions.

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

### [YANProcess](YANProcess)

A specialized utility library for managing system processes, focusing on process termination operations.

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

### [YANExpression](YANExpression)

A specialized utility library for creating and manipulating strongly-typed expressions, particularly focused on property access.

```csharp
// Create a property expression for accessing the Name property on a Person object
var expression = YANExpression.PropertyExpression<Person>("p", "Name");

// Compile and use the expression
var func = expression.Compile();
var person = new Person { Name = "John", Age = 30 };
string name = (string)func(person); // Returns "John"
```

## Common Features Across Components

All YANLib components share these common characteristics:

- **Extension Methods**: Implemented as extension methods for a fluent API
- **Null Safety**: Robust handling of null values to prevent NullReferenceExceptions
- **Collection Support**: Methods for both single values and collections
- **Generic Type Support**: Flexible type parameters for input and output types
- **Consistent API**: Similar method naming and behavior across components
- **Performance Optimization**: Efficient implementations with caching where appropriate
- **Parallel Processing**: Automatic parallel processing for large collections (>1000 elements)
- **Debugging Support**: Uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience


## Technical Implementation

YANLib is built with several technical considerations in mind:

- **Partial Classes**: Uses partial classes to organize functionality by category
- **Thread Safety**: All operations are thread-safe, with no shared mutable state
- **Memory Efficiency**: Optimizes operations to minimize memory allocations
- **Type Conversion**: Handles type conversion internally, minimizing the need for explicit casting
- **Error Handling**: Provides graceful error handling with meaningful default values instead of exceptions
- **Caching**: Implements caching mechanisms for frequently used operations to improve performance


## Getting Started

To use YANLib in your project, simply add a reference to the YANLib NuGet package:

```plaintext
dotnet add package YANLib
```

Then add the appropriate using directive to your code:

```csharp
using YANLib;
```

Now you can start using any of the extension methods provided by the library.


## Examples

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

### Random Data Generation

```csharp
public List<User> GenerateTestUsers(int count)
{
    return Enumerable.Range(1, count)
        .Select(_ => new User
        {
            Id = YANRandom.GenerateRandom<int>(1, 10000),
            Name = $"User-{YANRandom.GenerateRandom<string>(8)}",
            Email = $"{YANRandom.GenerateRandom<string>(5)}@example.com",
            CreatedDate = YANRandom.GenerateRandom<DateTime>(
                new DateTime(2020, 1, 1),
                DateTime.Now)
        })
        .ToList();
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


## Contributing

Contributions to YANLib are welcome! Please feel free to submit issues, feature requests, or pull requests to help improve the library.
