### YANUnmanaged - Type Conversion Utility Library


## Overview

`YANUnmanaged` is a powerful utility library that provides extension methods for parsing and converting objects to unmanaged types in C# applications. It offers a comprehensive set of methods for converting objects, strings, and collections to various unmanaged types such as numeric types, DateTime, Guid, and enums, with support for both non-nullable and nullable types.


## Features

The library is organized into several functional categories:

### Basic Type Conversion

- **Single Object Parsing**: Convert objects to unmanaged types like int, double, DateTime, Guid, and enums
- **Default Value Handling**: Specify default values to use when parsing fails
- **Format Support**: Use format strings for parsing DateTime values

### Collection Conversion

- **Collection Parsing**: Convert collections of objects to collections of unmanaged types
- **Parallel Processing**: Automatic parallel processing for large collections (>1000 elements)
- **Dictionary/Lookup Conversion**: Parse dictionaries with object keys/values to typed dictionaries

### Nullable Type Support

- **Nullable Value Types**: Parse objects to nullable value types (int?, double?, DateTime?, etc.)
- **Null Handling**: Proper handling of null values during conversion
- **Type Inference**: Automatic detection of underlying types for nullable types

### Advanced Conversion

- **Enum Parsing**: Case-insensitive parsing of string values to enum types
- **Type Coercion**: Intelligent type conversion between compatible types
- **Error Handling**: Graceful handling of conversion errors with default values


## Usage Examples

### Basic Type Conversion

```csharp
// Parse string to int
object input = "123";
int result = input.Parse<int>(); // Returns 123

// Parse with default value
object invalidInput = "not a number";
int resultWithDefault = invalidInput.Parse<int>(42); // Returns 42

// Parse to DateTime
object dateInput = "2023-06-15";
DateTime dateResult = dateInput.Parse<DateTime>(); // Returns DateTime(2023, 6, 15)

// Parse with format
object formattedDate = "15/06/2023";
DateTime dateWithFormat = formattedDate.Parse<DateTime>(null, "dd/MM/yyyy"); // Returns DateTime(2023, 6, 15)

// Parse to enum
object enumInput = "Tuesday";
DayOfWeek day = enumInput.Parse<DayOfWeek>(); // Returns DayOfWeek.Tuesday

// Parse to Guid
var guid = Guid.NewGuid();
object guidInput = guid.ToString();
Guid guidResult = guidInput.Parse<Guid>(); // Returns the original Guid

// Parse to TimeSpan
object timeInput = "01:30:45";
TimeSpan timeResult = timeInput.Parse<TimeSpan>(); // Returns TimeSpan(1, 30, 45)

// Parse TimeSpan with days
object timeWithDays = "2.03:30:45";
TimeSpan daysResult = timeWithDays.Parse<TimeSpan>(); // Returns TimeSpan(2, 3, 30, 45)
```

### Collection Conversion

```csharp
// Parse collection of strings to ints
IEnumerable<object?> numbers = new object?[] { "123", "456", "789" };
IEnumerable<int> intResults = numbers.Parses<int>(); // Returns [123, 456, 789]

// Handle mixed valid and invalid inputs
IEnumerable<object?> mixedInputs = new object?[] { "123", "not a number", "789" };
IEnumerable<int> mixedResults = mixedInputs.Parses<int>(0); // Returns [123, 0, 789]

// Parse non-generic collection
ArrayList arrayList = new ArrayList { "123", "456", "789" };
IEnumerable<int> arrayListResults = arrayList.Parses<int>(); // Returns [123, 456, 789]

// Parse dictionary
IDictionary<object, object?> dict = new Dictionary<object, object?>
{
    { "1", "Value1" },
    { "2", "Value2" },
    { "3", "Value3" }
};

Dictionary<int, string?> parsedDict = dict.Parses<int, string>(); // Returns {1: "Value1", 2: "Value2", 3: "Value3"}

// Parse collection of strings to TimeSpan values
IEnumerable<object?> timeInputs = new object?[] { "01:30:45", "02:15:30", "03:45:10" };
IEnumerable<TimeSpan> timeResults = timeInputs.Parses<TimeSpan>(); // Returns collection of TimeSpan objects

// Handle mixed valid and invalid TimeSpan inputs
IEnumerable<object?> mixedTimeInputs = new object?[] { "01:30:45", "not a timespan", "03:45:10" };
IEnumerable<TimeSpan> mixedTimeResults = mixedTimeInputs.Parses<TimeSpan>(TimeSpan.Zero); // Returns [01:30:45, 00:00:00, 03:45:10]
```

### Nullable Type Support

```csharp
// Parse to nullable int
object input = "123";
int? nullableResult = input.Parse<int?>(); // Returns 123

// Handle invalid input
object invalidInput = "not a number";
int? nullableInvalidResult = invalidInput.Parse<int?>(); // Returns null

// Parse collection to nullable types
IEnumerable<object?> mixedInputs = new object?[] { "123", "not a number", "789" };
IEnumerable<int?> nullableResults = mixedInputs.Parses<int?>(); // Returns [123, null, 789]

// Handle null values in collection
IEnumerable<object?> withNulls = new object?[] { "123", null, "789" };
IEnumerable<int?> nullableWithNulls = withNulls.Parses<int?>(); // Returns [123, null, 789]
```

### Advanced Conversion Examples

```csharp
// Parse different types of DateTime inputs
IEnumerable<object?> dates = new object?[] { "2023-06-15", "2023-07-20", "2023-12-25" };
IEnumerable<DateTime> dateResults = dates.Parses<DateTime>(); // Returns collection of DateTime objects

// Parse enum values case-insensitively
IEnumerable<object?> days = new object?[] { "Monday", "tuesday", "WEDNESDAY" };
IEnumerable<DayOfWeek> dayResults = days.Parses<DayOfWeek>(); // Returns [Monday, Tuesday, Wednesday]

// Parse mixed types appropriately
var guid = Guid.NewGuid();
var mixedTypes = new object?[]
{
    "123",
    "true",
    "2023-06-15",
    "Monday",
    guid.ToString()
};

// Each Parse operation handles the appropriate values
IEnumerable<int?> intResults = mixedTypes.Parses<int?>(); // [123, null, null, null, null]
IEnumerable<bool?> boolResults = mixedTypes.Parses<bool?>(); // [null, true, null, null, null]
IEnumerable<DateTime?> dateResults = mixedTypes.Parses<DateTime?>(); // [null, null, 2023-06-15, null, null]
IEnumerable<DayOfWeek?> enumResults = mixedTypes.Parses<DayOfWeek?>(); // [null, null, null, Monday, null]
IEnumerable<Guid?> guidResults = mixedTypes.Parses<Guid?>(); // [null, null, null, null, guid]
```


## Performance Considerations

- The library uses caching for type reflection to improve performance
- For large collections (>1000 items), parallel processing is automatically used
- The implementation uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience
- Type conversion is optimized for common scenarios


## Implementation Details

- Extension methods are implemented in partial classes for better organization
- Internal implementation methods are separated from the public API
- The library uses nullable reference types for better null safety
- All public methods are well-documented with XML comments
- Type conversion logic handles edge cases gracefully


## Type Conversion Coverage

The library provides comprehensive coverage of type conversion operations:

| Category | Functions |
|----------|-----------|
| **Numeric Types** | Parse<byte>, Parse<sbyte>, Parse<short>, Parse<ushort>, Parse<int>, Parse<uint>, Parse<long>, Parse<ulong>, Parse<float>, Parse<double>, Parse<decimal> |
| **Other Value Types** | Parse<bool>, Parse<char>, Parse<DateTime>, Parse<DateTimeOffset>, Parse<TimeSpan>, Parse<Guid> |
| **Enum Types** | Parse<TEnum> where TEnum : struct, Enum |
| **Nullable Types** | Parse<T?> where T : struct |
| **Collection Conversion** | Parses<T>, Parses<TKey, TValue> |
| **Dictionary Conversion** | Parses<TKey, TValue> for IDictionary<object, object?> |
| **Format Support** | Parse<T>(format) for DateTime and other format-dependent types |


## Technical Details

- **Type Parsing**: Implements specialized parsing methods for each unmanaged type
- **Default Value Handling**: Provides configurable default values when parsing fails
- **Format Support**: Supports custom format strings for parsing formatted values like dates
- **Enum Parsing**: Implements case-insensitive enum parsing with name and value support
- **Type Conversion**: Uses `Convert.ChangeType()` and specialized conversion methods for type conversion
- **Nullable Type Support**: Implements special handling for nullable value types
- **Collection Processing**: Processes collections of objects with efficient type conversion
- **Dictionary Conversion**: Implements key and value parsing for dictionary type conversion
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
