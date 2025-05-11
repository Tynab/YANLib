### YANRandom - Random Value Generation Utility Library

## Overview

`YANRandom` is a comprehensive utility library that provides extension methods and utility functions for generating random values of various types in C# applications. It extends the functionality of the built-in `System.Random` class with methods to generate random values for a wide range of data types, including numeric types, booleans, characters, strings, and dates.

## Features

The library is organized into several functional categories:

### Random Value Generation

- **Numeric Types**: Generate random values for all numeric types (byte, sbyte, short, ushort, int, uint, long, ulong, nint, nuint, float, double, decimal)
- **Boolean Values**: Generate random boolean values
- **DateTime Values**: Generate random DateTime values within specified ranges
- **Character and String Values**: Generate random characters and strings


### Range-Based Generation

- **Min/Max Constraints**: Generate random values within specified ranges
- **Default Ranges**: Use sensible defaults when ranges are not specified
- **Type-Safe Ranges**: Ensure generated values respect the constraints of their types


### Collection Operations

- **Random Value Collections**: Generate collections of random values of specified types
- **Random Sampling**: Select random values from existing collections
- **Duplicate Control**: Option to allow or prevent duplicates in generated collections
- **Parallel Processing**: Automatic parallel processing for large collections (1000+ elements)


### Type Flexibility

- **Generic Support**: Generate random values of any unmanaged type
- **Nullable Types**: Support for generating nullable random values
- **Type Conversion**: Automatic conversion between different types
- **Object Collections**: Process collections of objects of any type


## Usage Examples

### Basic Random Value Generation

```csharp
// Create a random number generator
var random = new Random();

// Generate random values of various types
int randomInt = random.NextInt(); // Random int (full range)
int boundedInt = random.NextInt(1, 100); // Random int between 1 (inclusive) and 100 (exclusive)
double randomDouble = random.NextDouble(); // Random double between 0.0 and 1.0
double boundedDouble = random.NextDouble(-10.5, 10.5); // Random double in range
decimal randomDecimal = random.NextDecimal(); // Random decimal value
bool randomBool = random.NextBool(); // Random boolean (true or false)
byte randomByte = random.NextByte(0, 255); // Random byte in range
DateTime randomDate = random.NextDateTime(); // Random DateTime
DateTime boundedDate = random.NextDateTime(
    new DateTime(2023, 1, 1), 
    new DateTime(2023, 12, 31)); // Random date in 2023
char randomChar = random.NextChar(); // Random lowercase letter
string randomString = random.NextString(10); // Random string of 10 lowercase letters
```

### Using Static Methods for Unmanaged Types

```csharp
// Generate random values of specific types
int randomInt = YANRandom.GenerateRandom<int>(); // Random int
int boundedInt = YANRandom.GenerateRandom<int>(1, 100); // Random int in range
float randomFloat = YANRandom.GenerateRandom<float>(); // Random float
double boundedDouble = YANRandom.GenerateRandom<double>(-10.5, 10.5); // Random double in range
DateTime randomDate = YANRandom.GenerateRandom<DateTime>(); // Random DateTime
bool randomBool = YANRandom.GenerateRandom<bool>(); // Random boolean

// Generate random values from collections
var numbers = new[] { 1, 2, 3, 4, 5 };
int randomNumber = numbers.GenerateRandom(); // Random element from the array

// Using params for convenience
int randomFromParams = YANRandom.GenerateRandom(1, 2, 3, 4, 5); // Random element from params
```

### Generating Collections of Random Values

```csharp
// Generate collections of random values
IEnumerable<int> randomInts = YANRandom.GenerateRandoms<int>(size: 10); // 10 random ints
IEnumerable<double> randomDoubles = YANRandom.GenerateRandoms<double>(-10.5, 10.5, 5); // 5 random doubles in range
IEnumerable<DateTime> randomDates = YANRandom.GenerateRandoms<DateTime>(size: 3); // 3 random dates

// Generate random values from an existing collection
var numbers = new[] { 1, 2, 3, 4, 5 };
IEnumerable<int> randomSelection = numbers.GenerateRandoms(size: 10); // 10 random elements (with duplicates)
IEnumerable<int> uniqueRandoms = numbers.GenerateRandoms(size: 5, allowDuplicates: false); // All 5 elements in random order

// Generate random values from a non-generic collection
ArrayList list = [1, 2, 3, 4, 5];
IEnumerable<int> randomFromList = list.GenerateRandoms<int>(size: 3); // 3 random elements from ArrayList
```

### Working with Nullable Types

```csharp
// Generate nullable random values
int? nullableInt = YANRandom.GenerateRandom<int?>(); // Random nullable int (non-null)
double? nullableDouble = YANRandom.GenerateRandom<double?>(); // Random nullable double (non-null)
DateTime? nullableDate = YANRandom.GenerateRandom<DateTime?>(); // Random nullable DateTime (non-null)

// Generate collections of nullable random values
IEnumerable<int?> nullableInts = YANRandom.GenerateRandoms<int?>(size: 10); // 10 random nullable ints
IEnumerable<double?> nullableDoubles = YANRandom.GenerateRandoms<double?>(size: 5); // 5 random nullable doubles
```

### Working with Object Collections

```csharp
// Generate random values from collections of objects
var objectCollection = new object[] { 1, "2", 3.5, "4", 5 };
int randomInt = objectCollection.GenerateRandom<int>(); // Random int from the collection
IEnumerable<int> randomInts = objectCollection.GenerateRandoms<int>(size: 10); // 10 random ints from the collection

// Generate random values from mixed-type collections
var mixedTypes = new object[] { 1, "2.5", 3.7, "four", null };
double randomDouble = mixedTypes.GenerateRandom<double>(); // Random double from valid elements
IEnumerable<double> randomDoubles = mixedTypes.GenerateRandoms<double>(size: 5); // 5 random doubles from valid elements
```

### Advanced Usage Examples

```csharp
// Generate a large collection of random values (uses parallel processing)
IEnumerable<int> largeCollection = YANRandom.GenerateRandoms<int>(size: 10000); // 10,000 random ints

// Generate random values with custom min/max for different types
byte randomByte = YANRandom.GenerateRandom<byte>(10, 20); // Random byte between 10 and 20
short randomShort = YANRandom.GenerateRandom<short>(-100, 100); // Random short between -100 and 100
long randomLong = YANRandom.GenerateRandom<long>(long.MinValue / 2, long.MaxValue / 2); // Random long in range

// Generate random values from a collection with no duplicates
var sourceCollection = Enumerable.Range(1, 100).ToList();
var uniqueSample = sourceCollection.GenerateRandoms(size: 50, allowDuplicates: false); // 50 unique random elements

// Generate random values from a non-generic collection with type conversion
ArrayList mixedList = [1, "2", 3.5, "4.7"];
IEnumerable<double> convertedRandoms = mixedList.GenerateRandoms<double>(size: 10); // 10 random doubles

// Generate random values with custom object parsing
var customObjects = new object[] { "1.1", 2, "3.3", 4 };
float randomFloat = customObjects.GenerateRandom<float>(); // Random float from parsed objects
```

## Performance Considerations

- **Parallel Processing**: For collections with more than 1000 elements, the library automatically uses parallel processing for better performance
- **Type Conversion**: The library handles type conversion internally, minimizing the need for explicit casting
- **Null Handling**: All methods handle null inputs gracefully, returning appropriate default values rather than throwing exceptions
- **Range Validation**: Methods validate min/max ranges and return default values for invalid ranges
- **Debugging Support**: Uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience


## Implementation Details

- **Extension Methods**: All operations are implemented as extension methods for better integration with existing code
- **Generic Type Support**: Methods use generic type parameters to support various types
- **Null Safety**: All methods are designed to be null-safe, handling null inputs gracefully
- **Partial Classes**: Uses partial classes to organize functionality by category:

- Core functionality (YANRandom.cs)
- Collection operations (YANRandom.Collection.cs)
- Generic operations (YANRandom.Generic.cs)
- Nullable operations (YANRandom.Nullable.cs)



- **Internal Implementation**: Core implementation details are separated from the public API for better maintainability


## Random Value Generation Coverage

The library provides comprehensive coverage of random value generation:

| Category | Functions |
|----------|-----------|
| **Numeric Types** | NextByte, NextSbyte, NextShort, NextUshort, NextInt, NextUint, NextLong, NextUlong, NextNint, NextNuint, NextSingle, NextDouble, NextDecimal |
| **Boolean** | NextBool |
| **DateTime** | NextDateTime |
| **Text** | NextChar, NextString |
| **Generic** | GenerateRandom<T> |
| **Collections** | GenerateRandoms<T> |
| **Collection Sampling** | GenerateRandom, GenerateRandoms |
| **Nullable Types** | Support for generating nullable random values |
| **Range Control** | Min/max parameters for all numeric types |


## Technical Details

- **Random Number Generation**: Extends `System.Random` with additional methods for various data types
- **Range Validation**: Implements boundary checking to ensure generated values stay within specified ranges
- **Type-Specific Generation**: Uses specialized methods for each primitive type to ensure proper range and distribution
- **DateTime Generation**: Generates random DateTime values within the supported DateTime range
- **String Generation**: Implements character-based random string generation with configurable length
- **Collection Sampling**: Uses reservoir sampling algorithm for selecting random elements from collections
- **Duplicate Control**: Implements tracking mechanism to prevent duplicates when requested
- **Thread Safety**: Uses thread-local Random instances to prevent contention in multi-threaded scenarios
- **Parallel Processing**: Implements parallel processing for generating large collections of random values
- **Generic Implementation**: Uses generic type parameters with constraints to support various types
