### YANRandom Component

The `YANRandom` component is part of the YANLib library, providing a comprehensive set of utilities for generating random values of various types in .NET applications.


## Overview

YANRandom offers both extension methods for the standard `Random` class and static methods for generating random values of different types. It supports generating single random values, collections of random values, and handles nullable types seamlessly. The component provides a consistent API for working with random data across various data types.


## Key Features

### Random Value Generation

Generate random values of various types:

```csharp
// Using static methods
int randomInt = YANRandom.GenerateRandom<int>();
double randomDouble = YANRandom.GenerateRandom<double>(-100.5, 100.5);
DateTime randomDate = YANRandom.GenerateRandom<DateTime>();
string randomString = YANRandom.GenerateRandom<string>();
bool randomBool = YANRandom.GenerateRandom<bool>();

// Using Random extensions
var random = new Random();
int randomInt = random.NextInt();
double randomDouble = random.NextDouble(-100.5, 100.5);
DateTime randomDate = random.NextDateTime();
string randomString = random.NextString();
bool randomBool = random.NextBool();
```

### Random Collection Generation

Generate collections of random values:

```csharp
// Generate a collection of 10 random integers
IEnumerable<int> randomInts = YANRandom.GenerateRandoms<int>(size: 10);

// Generate a collection of 10 random doubles between -100.5 and 100.5
IEnumerable<double> randomDoubles = YANRandom.GenerateRandoms<double>(-100.5, 100.5, 10);

// Generate a collection of 10 random DateTime values
IEnumerable<DateTime> randomDates = YANRandom.GenerateRandoms<DateTime>(size: 10);
```

### Support for Nullable Types

Generate random nullable values:

```csharp
// Generate a random nullable int (always returns a non-null value)
int? randomNullableInt = YANRandom.GenerateRandom<int?>();

// Generate a random nullable DateTime (always returns a non-null value)
DateTime? randomNullableDate = YANRandom.GenerateRandom<DateTime?>();

// Generate a collection of random nullable values
IEnumerable<int?> randomNullableInts = YANRandom.GenerateRandoms<int?>(10);
```

### Support for Various Numeric Types

Generate random values for all numeric types:

```csharp
// Byte
byte randomByte = random.NextByte();
byte randomByteInRange = random.NextByte(10, 100);

// SByte
sbyte randomSByte = random.NextSbyte();
sbyte randomSByteInRange = random.NextSbyte(-50, 50);

// Short
short randomShort = random.NextShort();
short randomShortInRange = random.NextShort(-1000, 1000);

// UShort
ushort randomUShort = random.NextUshort();
ushort randomUShortInRange = random.NextUshort(1000, 5000);

// Int
int randomInt = random.NextInt();
int randomIntInRange = random.NextInt(-10000, 10000);

// UInt
uint randomUInt = random.NextUint();
uint randomUIntInRange = random.NextUint(10000, 50000);

// Long
long randomLong = random.NextLong();
long randomLongInRange = random.NextLong(-1000000, 1000000);

// ULong
ulong randomULong = random.NextUlong();
ulong randomULongInRange = random.NextUlong(1000000, 5000000);

// NInt (native int)
nint randomNInt = random.NextNint();
nint randomNIntInRange = random.NextNint(-10000, 10000);

// NUInt (native unsigned int)
nuint randomNUInt = random.NextNuint();
nuint randomNUIntInRange = random.NextNuint(10000, 50000);

// Float
float randomFloat = random.NextSingle();
float randomFloatInRange = random.NextSingle(-100.5f, 100.5f);

// Double
double randomDouble = random.NextDouble();
double randomDoubleInRange = random.NextDouble(-100.5, 100.5);

// Decimal
decimal randomDecimal = random.NextDecimal();
decimal randomDecimalInRange = random.NextDecimal(-100m, 100m);
```

### Parallel Processing for Large Collections

Automatically uses parallel processing for generating large collections of random values:

```csharp
// Generate a large collection of random integers (uses parallel processing)
IEnumerable<int> manyRandomInts = YANRandom.GenerateRandoms<int>(size: 2000);
```


## Usage Examples

### Basic Random Value Generation

```csharp
// Create a random instance
var random = new Random();

// Generate random values of different types
int randomInt = random.NextInt(-100, 100);
double randomDouble = random.NextDouble(0, 1);
DateTime randomDate = random.NextDateTime(
    new DateTime(2000, 1, 1),
    new DateTime(2023, 12, 31)
);

bool randomBool = random.NextBool();
string randomString = random.NextString(10); // 10-character random string
```

### Using Static Methods

```csharp
// Generate random values using static methods
int randomInt = YANRandom.GenerateRandom<int>();
double randomDouble = YANRandom.GenerateRandom<double>(0, 100);
DateTime randomDate = YANRandom.GenerateRandom<DateTime>();
string randomString = YANRandom.GenerateRandom<string>();
```

### Generating Test Data

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

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool IsActive { get; set; }
}
```

### Random Data for Unit Tests

```csharp
[Fact]
public void CalculateDiscount_WithValidInput_ReturnsCorrectDiscount()
{
    // Arrange
    var price = YANRandom.GenerateRandom<decimal>(100, 1000);
    var discountPercentage = YANRandom.GenerateRandom<decimal>(5, 50);
    var expectedDiscount = price * (discountPercentage / 100);
    
    // Act
    var actualDiscount = DiscountCalculator.CalculateDiscount(price, discountPercentage);
    
    // Assert
    Assert.Equal(expectedDiscount, actualDiscount, 2); // Compare with precision of 2 decimal places
}
```

### Generating Random Collections

```csharp
public class ProductGenerator
{
    public List<Product> GenerateRandomProducts(int count)
    {
        var categories = new[] { "Electronics", "Clothing", "Books", "Home", "Sports" };
        
        return YANRandom.GenerateRandoms<int>(size: count)
            .Select(i => new Product
            {
                Id = i,
                Name = $"Product-{YANRandom.GenerateRandom<string>()}",
                Price = YANRandom.GenerateRandom<decimal>(10, 1000),
                Category = categories[YANRandom.GenerateRandom<int>(0, categories.Length - 1)],
                IsInStock = YANRandom.GenerateRandom<bool>()
            })
            .ToList();
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public bool IsInStock { get; set; }
}
```

### Random Date Generation

```csharp
public class DateRangeGenerator
{
    public (DateTime Start, DateTime End) GenerateRandomDateRange(int maxDaysBetween)
    {
        var start = YANRandom.GenerateRandom<DateTime>(
            DateTime.Now.AddYears(-1),
            DateTime.Now
        );
        
        var end = YANRandom.GenerateRandom<DateTime>(
            start,
            start.AddDays(maxDaysBetween)
        );
        
        return (start, end);
    }
}
```

### Performance Testing with Random Data

```csharp
public class PerformanceTester
{
    public TimeSpan MeasureProcessingTime(int dataSize)
    {
        // Generate a large collection of random data
        var data = YANRandom.GenerateRandoms<double>(size: dataSize).ToList();
        
        var stopwatch = Stopwatch.StartNew();
        
        // Process the data
        var result = data.Select(x => Math.Pow(x, 2)).Sum();
        
        stopwatch.Stop();
        return stopwatch.Elapsed;
    }
}
```

### Random String Generation

```csharp
public class PasswordGenerator
{
    public string GenerateRandomPassword(int length)
    {
        var random = new Random();
        return new string(Enumerable.Range(0, length)
            .Select(_ => random.NextChar())
            .ToArray());
    }
}
```


## Implementation Notes

- All methods handle edge cases gracefully (e.g., min > max returns default value)
- The component uses parallel processing for generating large collections of random values
- String generation produces lowercase letters by default
- DateTime generation ensures values are within the valid DateTime range
- All methods are thread-safe when used with separate Random instances
