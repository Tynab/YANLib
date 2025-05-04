### YANMath Component

The `YANMath` component is part of the YANLib library, providing a comprehensive set of mathematical operations and functions with robust null handling and type conversion capabilities.


## Overview

YANMath offers an extensive collection of extension methods for performing mathematical operations on both single values and collections. It supports various numeric types, nullable values, and even automatic type conversion from strings or other convertible types.


## Key Features

### Basic Mathematical Operations

Perform common mathematical operations on single values or collections:

```csharp
// Single value operations
int min = YANMath.Min(5, 2, 8, 1, 9);       // Returns 1
int max = YANMath.Max(5, 2, 8, 1, 9);       // Returns 9
double avg = YANMath.Average<double>(2, 4, 6, 8, 10);  // Returns 6.0
int sum = YANMath.Sum(2, 4, 6, 8, 10);      // Returns 30

// Collection operations
var numbers = new List<int?> { 5, 2, 8, 1, 9 };
int? min = numbers.Min<int>();              // Returns 1
int? max = numbers.Max<int>();              // Returns 9
```

### Rounding Functions

Round numbers in various ways:

```csharp
// Single value operations
double truncated = 3.75.Truncate<double>();  // Returns 3.0
double ceiling = 3.75.Ceiling<double>();     // Returns 4.0
double floor = (-3.75).Floor<double>();      // Returns -4.0
double rounded = 3.14159.Round<double>(2);   // Returns 3.14

// Collection operations
var values = new List<double?> { 3.75, -2.25, 0.5 };
var truncated = values.Truncates<double>();  // Returns [3.0, -2.0, 0.0]
var ceilings = values.Ceilings<double>();    // Returns [4.0, -2.0, 1.0]
var floors = values.Floors<double>();        // Returns [3.0, -3.0, 0.0]
```

### Power and Root Functions

Calculate powers, square roots, and cube roots:

```csharp
// Single value operations
double sqrt = 16.0.Sqrt<double>();           // Returns 4.0
double pow = 2.0.Pow<double>(3);             // Returns 8.0
double cbrt = 27.0.Cbrt<double>();           // Returns 3.0

// Collection operations
var values = new List<double?> { 4.0, 9.0, 16.0 };
var sqrts = values.Sqrts<double>();          // Returns [2.0, 3.0, 4.0]
var pows = values.Pows<double>(2);           // Returns [16.0, 81.0, 256.0]
```

### Trigonometric Functions

Perform trigonometric calculations:

```csharp
// Single value operations
double sin = (Math.PI / 2).Sin<double>();    // Returns 1.0
double cos = Math.PI.Cos<double>();          // Returns -1.0
double tan = (Math.PI / 4).Tan<double>();    // Returns 1.0

// Inverse trigonometric functions
double asin = 1.0.Asin<double>();            // Returns π/2
double acos = 0.0.Acos<double>();            // Returns π/2
double atan = 1.0.Atan<double>();            // Returns π/4

// Collection operations
var angles = new List<double?> { 0.0, Math.PI / 2, Math.PI };
var sines = angles.Sins<double>();           // Returns [0.0, 1.0, 0.0]
var cosines = angles.Coss<double>();         // Returns [1.0, 0.0, -1.0]
```

### Logarithmic and Exponential Functions

Calculate logarithms and exponentials:

```csharp
// Single value operations
double log = 100.0.Log<double>(10);          // Returns 2.0
double log10 = 100.0.Log10<double>();        // Returns 2.0
double log2 = 8.0.Log2<double>();            // Returns 3.0
int ilogb = 8.0.ILogB<int>();                // Returns 3

double exp = 1.0.Exp<double>();              // Returns Math.E
double exp2 = 3.0.Exp2<double>();            // Returns 8.0

// Collection operations
var values = new List<double?> { 10.0, 100.0, 1000.0 };
var log10s = values.Log10s<double>();        // Returns [1.0, 2.0, 3.0]
var log2s = new List<double?> { 2.0, 4.0, 8.0 }.Log2s<double>();  // Returns [1.0, 2.0, 3.0]
```

### Absolute Value

Calculate absolute values:

```csharp
// Single value operations
double abs = (-5.0).Abs<double>();           // Returns 5.0

// Collection operations
var values = new List<double?> { 3.0, -2.0, 0.0 };
var abss = values.Abss<double>();            // Returns [3.0, 2.0, 0.0]
```


## Null Handling

YANMath provides robust null handling:

- Null inputs return default values for single operations
- Null values in collections are preserved or ignored as appropriate
- Empty collections return null

```csharp
// Null handling for single values
double? nullValue = null;
double? result = nullValue.Sqrt<double>();   // Returns default(double)

// Null handling for collections
var mixedValues = new List<double?> { 3.75, null, 0.5 };
var truncated = mixedValues.Truncates<double>();  // Returns [3.0, default, 0.0]
```


## Type Conversion

YANMath supports automatic type conversion:

```csharp
// String to numeric conversion
object stringValue = "3.75";
double? result = stringValue.Truncate<double>();  // Returns 3.0

// Mixed type collections
var mixedTypes = new List<object?> { 5, 2.5, "8", 1, "9" };
int? min = mixedTypes.Min<int>();            // Returns 1
```


## Generic Type Support

Operations can be performed with generic type parameters:

```csharp
// Generic single operations
object input = 16.0;
double? sqrt = input.Sqrt<double>();         // Returns 4.0

// Generic collection operations
var inputs = new List<object?> { 4.0, "9.0", 16.0 };
var sqrts = inputs.Sqrts<double>();          // Returns [2.0, 3.0, 4.0]
```


## Usage Examples

### Basic Calculations

```csharp
// Find the minimum and maximum values
int min = YANMath.Min(10, 5, 8, 3, 7);       // Returns 3
int max = YANMath.Max(10, 5, 8, 3, 7);       // Returns 10

// Calculate average and sum
double avg = YANMath.Average<double>(10, 20, 30, 40);  // Returns 25.0
int sum = YANMath.Sum(10, 20, 30, 40);       // Returns 100
```

### Rounding Numbers

```csharp
// Round a number to 2 decimal places
double pi = 3.14159;
double rounded = pi.Round<double>(2);        // Returns 3.14

// Round a collection of numbers
var prices = new List<double?> { 19.95, 29.99, 9.49 };
var roundedPrices = prices.Rounds<double>(0); // Returns [20.0, 30.0, 9.0]

// Use different rounding modes
double midpoint = 2.5;
double rounded1 = midpoint.Round<double>(0, MidpointRounding.AwayFromZero); // Returns 3.0
double rounded2 = midpoint.Round<double>(0, MidpointRounding.ToEven);       // Returns 2.0
```

### Financial Calculations

```csharp
// Calculate compound interest
double principal = 1000;
double rate = 0.05;
int years = 5;
double amount = principal * (1 + rate).Pow<double>(years);  // Returns 1276.28

// Round monetary values
var amounts = new List<double?> { 19.955, 29.994, 9.496 };
var roundedAmounts = amounts.Rounds<double>(2);  // Returns [19.96, 29.99, 9.50]
```

### Scientific Calculations

```csharp
// Calculate the area of a circle
double radius = 5;
double area = Math.PI * radius.Pow<double>(2);  // Returns 78.54

// Convert degrees to radians
double degrees = 180;
double radians = degrees * (Math.PI / 180);     // Returns 3.14159

// Calculate sine and cosine
double sin90 = radians.Sin<double>();           // Returns 0.0 (approximately)
double cos90 = radians.Cos<double>();           // Returns -1.0 (approximately)
```

### Statistical Operations

```csharp
// Calculate standard deviation
var values = new List<double?> { 2, 4, 4, 4, 5, 5, 7, 9 };
double mean = values.Average<double>().Value;
var squaredDiffs = values.Select(v => (v - mean).Pow<double>(2));
double variance = squaredDiffs.Average<double>().Value;
double stdDev = variance.Sqrt<double>().Value;  // Returns 2.0
```

### Working with Mixed Types

```csharp
// Process data from different sources
var measurements = new List<object?> { 10, "15.5", 20.75, null, "25" };
double? average = measurements.Average<double>();  // Returns 17.81 (ignoring null)

// Convert and process string inputs
var stringValues = new List<string?> { "10", "20", "30", null, "40" };
var numericValues = stringValues.Select(s => s.As<double>()).ToList();
double? sum = numericValues.Sum<double>();  // Returns 100.0 (ignoring null)
```

### Batch Processing

```csharp
// Process multiple values at once
var temperatures = new List<double?> { 98.6, 99.2, 97.9, 100.5, 98.2 };
var rounded = temperatures.Rounds<double>(1);  // Returns [98.6, 99.2, 97.9, 100.5, 98.2]
var elevated = temperatures.Where(t => t > 99.0).ToList();  // Returns [99.2, 100.5]
```
