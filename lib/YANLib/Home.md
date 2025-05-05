# YANLib

Welcome to the YANLib documentation! YANLib is a comprehensive .NET utility library that provides a wide range of extension methods and helper classes to simplify common programming tasks and enhance developer productivity.


## Overview

YANLib offers a collection of specialized components, each focusing on a specific area of functionality. The library is designed with a consistent API, robust error handling, and support for both nullable and non-nullable types. All components are implemented as extension methods, allowing for a fluent and intuitive coding experience.


## Key Components

### [YANUnmanaged](YANUnmanaged)

Provides utilities for parsing and converting unmanaged types with built-in error handling and format support.

```csharp
// Parse string to int with default value
object input = "123";
int result = input.Parse<int>(); // Returns 123

// Handle invalid input with default value
object invalidInput = "not a number";
int resultWithDefault = invalidInput.Parse<int>(42); // Returns 42
```

### [YANRandom](YANRandom)

Offers tools for generating random values of various types, with support for ranges, collections, and nullable types.

```csharp
// Generate random values of different types
int randomInt = YANRandom.GenerateRandom<int>();
double randomDouble = YANRandom.GenerateRandom<double>(-100.5, 100.5);
DateTime randomDate = YANRandom.GenerateRandom<DateTime>();
```

### [YANTask](YANTask)

Extends the standard .NET Task API with additional methods for task coordination and management.

```csharp
// Wait for any task that returns a value greater than 10
var tasks = new[] { Task.FromResult(5), Task.FromResult(15), Task.FromResult(25) };
var result = await tasks.WaitAnyWithCondition(x => x > 10); // Returns 15
```

### [YANText](YANText)

Provides a comprehensive set of extension methods for text manipulation, validation, and transformation.

```csharp
// Title case conversion
"hello world".Title(); // Returns "Hello World"

// Clean whitespace (trim and normalize)
"  hello  world  ".CleanSpace(); // Returns "hello world"

// Filter characters
"abc123!@#".FilterAlphanumeric(); // Returns "abc123"
```

### [YANObject](YANObject)

Offers utilities for object manipulation, validation, and analysis.

```csharp
// Null checking
bool isNull = someObject.IsNull();       // Returns true if object is null
bool isNotNull = someObject.IsNotNull(); // Returns true if object is not null

// Check if all properties have default values
bool allDefault = myObject.AllPropertiesDefault();
```

### [YANProcess](YANProcess)

Provides utilities for process management and manipulation.

```csharp
// Kill all processes with a specific name
await "notepad".KillAllProcessesByName();

// Kill multiple processes by their names
await YANProcess.KillAllProcessesByNames("chrome", "firefox", "edge");
```

### [YANJson](YANJson)

Offers JSON serialization and deserialization utilities with robust error handling.

```csharp
// Serialize an object to a JSON string
string json = myObject.Serialize();

// Deserialize a JSON string to an object
MyClass obj = jsonString.Deserialize<MyClass>();
```

### [YANMath](YANMath)

Provides mathematical operations and functions with robust null handling.

```csharp
// Find the minimum and maximum values
int min = YANMath.Min(10, 5, 8, 3, 7);       // Returns 3
int max = YANMath.Max(10, 5, 8, 3, 7);       // Returns 10

// Calculate average and sum
double avg = YANMath.Average<double>(10, 20, 30, 40);  // Returns 25.0
```

### [YANDateTime](YANDateTime)

Offers DateTime manipulation and calculation functionality.

```csharp
// Convert a DateTime from one time zone to another
DateTime utcDate = new DateTime(2023, 6, 15, 10, 0, 0);
DateTime convertedDate = utcDate.ChangeTimeZone(0, 3); // UTC to UTC+3
```

### [YANExpression](YANExpression)

Provides utilities for working with expression trees and dynamic property access.

```csharp
// Create an expression that accesses the "Name" property of TestClass
var expression = YANExpression.PropertyExpression<TestClass>("p", "Name");
```


## Common Features Across Components

All YANLib components share these common characteristics:

- **Extension Methods**: Implemented as extension methods for a fluent API
- **Null Safety**: Robust handling of null values to prevent NullReferenceExceptions
- **Collection Support**: Methods for both single values and collections
- **Generic Type Support**: Flexible type parameters for input and output types
- **Consistent API**: Similar method naming and behavior across components
- **Performance Optimization**: Efficient implementations with caching where appropriate


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


## Contributing

Contributions to YANLib are welcome! Please feel free to submit issues, feature requests, or pull requests to help improve the library.


## License

YANLib is licensed under the MIT License. See the LICENSE file for details.
