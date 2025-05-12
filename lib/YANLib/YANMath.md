### YANMath - Mathematical Operations Utility Library


## Overview

`YANMath` is a comprehensive utility library that provides extension methods for mathematical operations in C# applications. It offers a wide range of mathematical functions for both single values and collections, with support for generic types and null-safe operations.


## Features

The library is organized into several functional categories:

### Basic Mathematical Operations

- **Statistical Functions**: Min, Max, Average, Sum
- **Rounding Operations**: Truncate, Ceiling, Floor, Round
- **Power Functions**: Square root, Cube root, Power, Absolute value

### Trigonometric Functions

- **Basic Trigonometry**: Sin, Cos, Tan
- **Inverse Trigonometry**: Asin, Acos, Atan
- **Angle Conversions**: Radians to degrees, Degrees to radians

### Logarithmic and Exponential Functions

- **Logarithms**: Natural logarithm, Base-10 logarithm, Base-2 logarithm
- **Integer Logarithm**: Base-2 integer logarithm (ILogB)
- **Exponential Functions**: Exp (e^x), Exp2 (2^x)

### Collection Operations

- **Collection Processing**: Apply math operations to collections of values
- **Parallel Processing**: Automatic parallel processing for large collections
- **Null Handling**: Graceful handling of null values in collections

### Generic Type Support

- **Type Conversion**: Automatic conversion between numeric types
- **Object Processing**: Apply math operations to objects of any type
- **Generic Collections**: Support for collections of any object type


## Usage Examples

### Basic Mathematical Operations

```csharp
// Statistical functions
double min = YANMath.Min(5.2, 3.1, 7.8, 2.4); // Returns 2.4
double max = YANMath.Max(5.2, 3.1, 7.8, 2.4); // Returns 7.8
double avg = YANMath.Average(5.2, 3.1, 7.8, 2.4); // Returns 4.625
double sum = YANMath.Sum(5.2, 3.1, 7.8, 2.4); // Returns 18.5

// Rounding operations
double value = 3.75;
double truncated = value.Truncate(); // Returns 3.0
double ceiling = value.Ceiling(); // Returns 4.0
double floor = value.Floor(); // Returns 3.0
double rounded = value.Round(); // Returns 4.0
double roundedToDigits = value.Round(1); // Returns 3.8

// Negative values
double negValue = -3.75;
double negTruncated = negValue.Truncate(); // Returns -3.0
double negCeiling = negValue.Ceiling(); // Returns -3.0
double negFloor = negValue.Floor(); // Returns -4.0
double negRounded = negValue.Round(); // Returns -4.0

// Power functions
double sqrt = 16.0.Sqrt(); // Returns 4.0
double cbrt = 27.0.Cbrt(); // Returns 3.0
double powered = 2.0.Pow(3); // Returns 8.0
double abs = (-5.0).Abs(); // Returns 5.0
```

### Trigonometric Functions

```csharp
// Basic trigonometric functions
double sinValue = 0.0.Sin(); // Returns 0.0
double cosValue = 0.0.Cos(); // Returns 1.0
double tanValue = 0.0.Tan(); // Returns 0.0

double piHalf = Math.PI / 2;
double sinPiHalf = piHalf.Sin(); // Returns 1.0
double cosPiHalf = piHalf.Cos(); // Returns 0.0

// Inverse trigonometric functions
double asinValue = 1.0.Asin(); // Returns π/2 (1.5707...)
double acosValue = 1.0.Acos(); // Returns 0.0
double atanValue = 1.0.Atan(); // Returns π/4 (0.7853...)

// Working with degrees (requires conversion to radians)
double degrees = 90;
double radians = degrees * Math.PI / 180;
double sinDegrees = radians.Sin(); // Returns 1.0
```

### Logarithmic and Exponential Functions

```csharp
// Logarithmic functions
double naturalLog = Math.E.Log(); // Returns 1.0
double base10Log = 100.0.Log10(); // Returns 2.0
double base2Log = 8.0.Log2(); // Returns 3.0
double customBaseLog = 100.0.Log(10); // Returns 2.0

// Integer logarithm
int intLog = 8.0.ILogB<int>(); // Returns 3

// Exponential functions
double expValue = 1.0.Exp(); // Returns e (2.7182...)
double exp2Value = 3.0.Exp2(); // Returns 8.0
```

### Collection Operations

```csharp
// Statistical functions on collections
var numbers = new List<double?> { 5.2, 3.1, 7.8, 2.4 };
double? min = numbers.Min(); // Returns 2.4
double? max = numbers.Max(); // Returns 7.8
double? avg = numbers.Average(); // Returns 4.625
double? sum = numbers.Sum(); // Returns 18.5

// Rounding operations on collections
var values = new List<double?> { 3.75, -2.25, 0.5 };
IEnumerable<double?>? truncated = values.Truncates(); // Returns [3.0, -2.0, 0.0]
IEnumerable<double?>? ceilings = values.Ceilings(); // Returns [4.0, -2.0, 1.0]
IEnumerable<double?>? floors = values.Floors(); // Returns [3.0, -3.0, 0.0]
IEnumerable<double?>? rounded = values.Rounds(); // Returns [4.0, -2.0, 1.0]

// Trigonometric functions on collections
var angles = new List<double?> { 0.0, Math.PI / 2, Math.PI };
IEnumerable<double?>? sines = angles.Sins(); // Returns [0.0, 1.0, 0.0]
IEnumerable<double?>? cosines = angles.Coss(); // Returns [1.0, 0.0, -1.0]
IEnumerable<double?>? tangents = angles.Tans(); // Returns [0.0, ∞, 0.0]

// Power functions on collections
var bases = new List<double?> { 4.0, 9.0, 16.0 };
IEnumerable<double?>? squareRoots = bases.Sqrts(); // Returns [2.0, 3.0, 4.0]

var exponents = new List<double?> { 2.0, 3.0, 4.0 };
IEnumerable<double?>? powers = exponents.Pows(2); // Returns [4.0, 9.0, 16.0]

// Handling null values in collections
var withNulls = new List<double?> { 4.0, null, 16.0 };
IEnumerable<double?>? sqrtsWithNull = withNulls.Sqrts(); // Returns [2.0, null, 4.0]
```

### Generic Type Support

```csharp
// Operations on objects of any type
object value = 3.75;
double truncated = value.Truncate<double>(); // Returns 3.0
double ceiling = value.Ceiling<double>(); // Returns 4.0
double floor = value.Floor<double>(); // Returns 3.0

// String to number conversion and operation
string strValue = "3.75";
double rounded = strValue.Round<double>(); // Returns 4.0

// Collections of objects
var mixedObjects = new List<object?> { 3.75, "2.25", 0.5 };
IEnumerable<double?>? truncatedObjects = mixedObjects.Truncates<double>(); // Returns [3.0, 2.0, 0.0]
IEnumerable<double?>? roundedObjects = mixedObjects.Rounds<double>(); // Returns [4.0, 2.0, 1.0]

// Min/Max/Average/Sum on object collections
var objectNumbers = new List<object?> { 5, 2.5, "8", 1, "9" };
int minValue = objectNumbers.Min<int>(); // Returns 1
int maxValue = objectNumbers.Max<int>(); // Returns 9
double avgValue = objectNumbers.Average<double>(); // Returns 5.1
int sumValue = objectNumbers.Sum<int>(); // Returns 25
```

### Advanced Usage Examples

```csharp
// Chaining operations
double result = 16.0.Sqrt().Pow(3).Round(2); // √16 = 4, 4³ = 64, rounded to 64.0

// Combining with LINQ
var numbers = Enumerable.Range(1, 10).Select(x => (double)x);
var processed = numbers
    .Where(x => x > 3)
    .Select(x => x.Pow(2))
    .Where(x => x.Sqrt() > 3)
    .Average();
// Result: Average of squares of numbers > 3 where square root > 3

// Processing collections with multiple operations
var values = new List<double?> { 3.14159, 2.71828, 1.41421 };
var results = values
    .Rounds(2) // Round to 2 decimal places: [3.14, 2.72, 1.41]
    .Pows(2)   // Square each value: [9.8596, 7.3984, 1.9881]
    .Sqrts()   // Take square root: [3.14, 2.72, 1.41]
    .ToList();

// Parallel processing for large collections (happens automatically)
var largeCollection = Enumerable.Range(1, 10000).Select(x => (double)x).ToList();
var squareRoots = largeCollection.Sqrts(); // Uses parallel processing internally

// Handling null values gracefully
double? nullValue = null;
double? result1 = nullValue.Sqrt(); // Returns null
double? result2 = nullValue.Round(2); // Returns null
double? result3 = nullValue.Pow(3); // Returns null

// Type conversion in operations
int intValue = 16;
double sqrtResult = intValue.Sqrt(); // Returns 4.0
float floatResult = intValue.Sqrt<float>(); // Returns 4.0f
decimal decimalResult = intValue.Sqrt<decimal>(); // Returns 4.0m
```


## Performance Considerations

- **Parallel Processing**: For collections with more than 1000 elements, the library automatically uses parallel processing for better performance
- **Type Conversion**: The library handles type conversion internally, minimizing the need for explicit casting
- **Null Handling**: All methods handle null inputs gracefully, returning null rather than throwing exceptions
- **Caching**: Some operations use internal caching to improve performance for repeated calculations
- **Debugging Support**: Uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience


## Implementation Details

- **Extension Methods**: All operations are implemented as extension methods for better integration with existing code
- **Generic Type Support**: Methods use generic type parameters to support various numeric types
- **Null Safety**: All methods are designed to be null-safe, handling null inputs gracefully
- **Partial Classes**: Uses partial classes to organize functionality by category
- **Internal Implementation**: Core implementation details are separated from the public API for better maintainability


## Mathematical Functions Coverage

The library provides comprehensive coverage of mathematical functions:

| Category | Functions |
|----------|-----------|
| **Statistical** | Min, Max, Average, Sum |
| **Rounding** | Truncate, Ceiling, Floor, Round |
| **Power** | Sqrt, Cbrt, Pow, Abs |
| **Trigonometric** | Sin, Cos, Tan, Asin, Acos, Atan |
| **Logarithmic** | Log, Log10, Log2, ILogB |
| **Exponential** | Exp, Exp2 |
| **Collection Operations** | Collection versions of all operations (e.g., Mins, Maxes, Averages, Sums, Truncates, etc.) |
| **Generic Operations** | Generic versions of all operations |
| **Nullable Operations** | Support for nullable numeric types |


## Technical Details

- **Math Function Implementation**: Wraps `System.Math` methods with extension methods for better usability
- **Numeric Type Support**: Implements operations for all numeric types (int, double, decimal, etc.)
- **Overflow Protection**: Includes safeguards against numeric overflow in mathematical operations
- **NaN Handling**: Properly handles NaN (Not a Number) values in floating-point operations
- **Infinity Handling**: Includes special handling for positive and negative infinity values
- **Rounding Precision**: Supports configurable decimal precision in rounding operations
- **Parallel Processing**: Implements parallel processing using `Parallel.ForEach` for collections with more than 1000 elements
- **Generic Implementation**: Uses generic type parameters with constraints to support various numeric types
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
