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
- **Order Preservation**: `Parses` results are lazily evaluated and keep the input order
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


## Conversion Rules

`Parse` never throws. Strings are parsed with `CultureInfo.CurrentCulture` and the same number styles as `Convert.ToInt32(string, IFormatProvider)` and its siblings (so `"1.5"` is 15 for `double` under `de-DE`).

| Input | `Parse<int>()` | `Parse<int>(-1)` | `Parse<int?>()` |
|-------|----------------|------------------|-----------------|
| `"123"` | 123 | 123 | 123 |
| `"3.7"` / `"-3.5"` | 3 / -4 (floored) | -1 | `null` |
| `"abc"` | 0 | -1 | `null` |
| `"99999999999"` (out of range) | 0 | -1 | `null` |
| `3.7` / `2.5` (boxed `double`) | 4 / 2 (rounded half to even) | 4 / 2 | 4 / 2 |
| `1e10` (boxed, out of range) | 0 | -1 | `null` |
| `2147483647.6` (boxed) | 2147483647 (the floor fits) | -1 | `null` |

- **Fractions**: a fractional string is floored, using the exact `decimal` value, only by the one-argument `Parse<T>()` with a non-nullable integer `T`; the `defaultValue` overload and nullable targets return the default / `null` instead. A boxed fractional number is rounded half to even by every overload; when only the rounded value is out of range (`2147483647.6`), `Parse<T>()` floors it if the floor fits.
- **Out of range**: never throws and never wraps around: the result is `0` / `null` / the converted `defaultValue`.
- **`nint` / `nuint`**: supported as targets and as inputs (converted through `long` / `ulong`).
- **Already the target type**: an input that already is a `T` is returned unchanged (a derived instance typed as its base class stays the same instance; a `DateTime` keeps its milliseconds and `Kind`). A `defaultValue` of type `T` is returned unchanged as well, also when a `format` is given.
- **`char`**: `5.Parse<char>()` converts through the text (`'5'`), `5.Parse<char>('#')` through `Convert.ToChar` (`'\u0005'`).
- **Failing `ToString()`**: an input whose `ToString()` throws is treated as unparsable.

### Changes since 8.3.3

- Out-of-range integer conversions (`"99999999999".Parse<int>()`, `1e10.Parse<int>()`, and through them `100000.Pow(2)` or `int.MinValue.Abs()` on `int`) used to crash the process with a stack overflow; they now return `0` / `null` / the default value.
- `nint` / `nuint` conversions work (`"5".Parse<nint>(0)` was 0, `"5".Parse<nint?>()` was `null`, `((object)5).Parse<nint>()` crashed).
- Fractional strings are floored exactly: `"2.9999999999999999".Parse<int>()` is 2 (was 3), `"0.99999999999999999999".Parse<byte>()` is 0 (was 1), `"12345678901234567.9".Parse<long>()` is 12345678901234567 (was 12345678901234600).
- Inputs that already have the target type are returned unchanged: `Animal a = new Dog(); a.IsDefault()` is `false` (was `true`), `new object[] { dog }.ToList<Animal>()` is `[dog]` (was `[null]`), parsed `DateTime` values keep milliseconds and `Kind`.
- `"bad".Parse<DateTime>(dt, "dd/MM/yyyy")` returns `dt` (was `DateTime.MinValue`).
- `Parses` and the `ToList`, `ToArray`, `ToImmutableArray`, ... conversions built on it keep the input order for 1,000+ elements (they used unordered PLINQ); `Parses` is lazily evaluated on the enumerating thread.
- Invalid strings no longer throw and catch exceptions internally: `"abc".Parse<int>()` takes about 30 ns instead of about 24 µs.


## Performance Considerations

- Per-type metadata is cached in a static generic class, which is thread-safe without locks
- Collection methods are lazily evaluated on the enumerating thread and preserve the input order
- The implementation uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience
- Strings are parsed with `TryParse`, so invalid input does not cost an exception


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
| **Numeric Types** | Parse<byte>, Parse<sbyte>, Parse<short>, Parse<ushort>, Parse<int>, Parse<uint>, Parse<long>, Parse<ulong>, Parse<nint>, Parse<nuint>, Parse<float>, Parse<double>, Parse<decimal> |
| **Other Value Types** | Parse<bool>, Parse<char>, Parse<DateTime>, Parse<TimeSpan>, Parse<Guid> |
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
- **Type Conversion**: Parses strings with `TryParse` (`IParsable<T>`), range-checks boxed numbers before converting them, and uses `Convert.ChangeType()` only for the remaining `IConvertible` conversions, inside `try`/`catch`
- **Nullable Type Support**: Implements special handling for nullable value types
- **Collection Processing**: Processes collections of objects with efficient type conversion
- **Dictionary Conversion**: Implements key and value parsing for dictionary type conversion
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
