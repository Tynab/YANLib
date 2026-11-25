### YANUnmanaged - Type Conversion Utility Library


## Overview

`YANUnmanaged` is a powerful utility library that provides extension methods for parsing and converting objects to unmanaged types in C# applications. It offers a comprehensive set of methods for converting objects, strings, and collections to various unmanaged types such as numeric types, DateTime, Guid, and enums, with support for both non-nullable and nullable types.


## Features

The library is organized into several functional categories:

### Basic Type Conversion

- **Single Object Parsing**: Convert objects to unmanaged types like int, double, DateTime, Guid, and enums
- **Default Value Handling**: Specify default values to use when parsing fails
- **Format Support**: Use format strings for parsing DateTime values
- **Culture Choice**: `Parse` and `Parses` use the current culture; `ParseWith` and `ParsesWith` (since 8.4.0) take an `IFormatProvider` (see [Culture](#culture-parsewith--parseswith))

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

// Keys that parse to the same value: Parses<TKey, TValue>() throws ArgumentException, the onDuplicate overload decides
IDictionary<object, object?> clash = new Dictionary<object, object?> { { "1", "a" }, { 1, "b" }, { "3.2", "c" }, { "3.7", "d" } };
Dictionary<int, string?> keepFirst = clash.Parses<int, string>((stored, incoming) => stored); // {1: "a", 3: "c"}
Dictionary<int, string?> keepLast = clash.Parses<int, string>((stored, incoming) => incoming); // {1: "b", 3: "d"}
Dictionary<int, string?> merged = clash.Parses<int, string>((stored, incoming) => stored + incoming); // {1: "ab", 3: "cd"}

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

`Parse` never throws. Strings are parsed with `CultureInfo.CurrentCulture` and the same number styles as `Convert.ToInt32(string, IFormatProvider)` and its siblings (so `"1.5"` is 15 for `double` under `de-DE`). To parse with another culture, use `ParseWith` / `ParsesWith` (see [Culture](#culture-parsewith--parseswith)); the rules below apply to them as well.

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
- **`DateTime` default with a format**: a `defaultValue` that is not a `DateTime` (usually a string) is turned into text and parsed with the `format` strings first and, if they do not match, like an input without a format (the current culture, or the provider of `ParseWith` / `ParsesWith`); if that fails too, the result is `DateTime.MinValue`. So `"bad".Parse<DateTime>("2025-01-01", "dd/MM/yyyy")` is 1 January 2025, and `"bad".Parse<DateTime>("02/01/2025", "dd/MM/yyyy")` is 2 January 2025 under any culture because the format matches. Other non-`DateTime` defaults take the same path, so a `DateTimeOffset` or `DateOnly` default now gives the same result with a format as without one (before 8.4.0, `DateTime.MinValue`).
- **`char`**: `5.Parse<char>()` converts through the text (`'5'`), `5.Parse<char>('#')` through `Convert.ToChar` (`'\u0005'`).
- **Failing `ToString()`**: an input whose `ToString()` throws is treated as unparsable.
- **Dictionary keys that parse to the same value**: `Parses<TKey, TValue>(IDictionary<object, object?>)` throws `ArgumentException` when two keys parse to the same `TKey` (`"1"` and `1`, or `"3.2"` and `"3.7"`, which are both floored to 3). Since 8.4.0, `Parses<TKey, TValue>(onDuplicate)` takes a `Func<TValue?, TValue?, TValue?>` that receives the value stored for the key and the parsed value of the new entry and returns the value to store: `(stored, incoming) => stored` keeps the first, `(stored, incoming) => incoming` the last, in the enumeration order of the input dictionary (insertion order for a `Dictionary` without removals). It is not called when no keys collide, an exception it throws propagates, and a `null` function throws `ArgumentNullException`.

### Culture (`ParseWith` / `ParsesWith`)

Since 8.4.0, `ParseWith` and `ParsesWith` take an `IFormatProvider` right after the input and otherwise follow `Parse` and `Parses`. `Parse` and `Parses` keep reading `CultureInfo.CurrentCulture`.

| Overload | Same rules as |
|----------|---------------|
| `ParseWith<T>(this object? input, IFormatProvider? provider)` | `Parse<T>()` |
| `ParseWith<T>(this object? input, IFormatProvider? provider, object? defaultValue, IEnumerable<string?>? format)` and `(..., object? defaultValue, params string?[]? format)`, `where T : unmanaged` | `Parse<T>(defaultValue, format)` |
| `ParsesWith<T>(this IEnumerable<object?>? input, IFormatProvider? provider)` and the same for a non-generic `IEnumerable` | `Parses<T>()` |
| `ParsesWith<T>(this IEnumerable<object?>? input, IFormatProvider? provider, object? defaultValue, IEnumerable<string?>? format)` and `(..., params string?[]? format)`, both also for a non-generic `IEnumerable`, `where T : unmanaged` | `Parses<T>(defaultValue, format)` |

```csharp
using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("vi-VN"); // ',' is the decimal separator, '.' the group separator

double a = "1.5".Parse<double>(); // 15
double b = "1.5".ParseWith<double>(CultureInfo.InvariantCulture); // 1.5 under any current culture
double c = "1,5".ParseWith<double>(null); // 1.5: a null provider is the current culture, as in Parse
string? d = 1.5.ParseWith<string>(CultureInfo.InvariantCulture); // "1.5" (1.5.Parse<string>() is "1,5")
double e = "abc".ParseWith<double>(CultureInfo.InvariantCulture, "2.5"); // 2.5: the default value is parsed with the provider too
int f = "3.7".ParseWith<int>(CultureInfo.InvariantCulture); // 3: the rules of Parse<int>() (floored)
int g = "3.7".ParseWith<int>(CultureInfo.InvariantCulture, null); // 0: the rules of Parse<int>(null)
IEnumerable<decimal>? h = new object?[] { "1,234.5", "x" }.ParsesWith<decimal>(CultureInfo.InvariantCulture, -1m); // [1234.5, -1]
DateTime i = "01/02/2025".ParseWith<DateTime>(new CultureInfo("en-GB"), null); // 1 February 2025
DateTime j = "13/12/2025".ParseWith<DateTime>(new CultureInfo("de-DE"), null, "dd/MM/yyyy"); // 13 December 2025 (exact formats are invariant)
```

- **What the provider controls**: number parsing, `DateTime` and `TimeSpan` text without an exact format, `Convert.ChangeType` (a custom `IConvertible` input receives the provider), and the text of an input or default value that implements `IFormattable`. That text comes from `ToString(null, provider)`, also for `string` targets. For a custom type it can differ from `ToString()`, which `Parse` and a `null` provider use, so there `ParseWith(CultureInfo.CurrentCulture)` can differ from `Parse`. An enum input is the exception: `Enum` ignores the provider, so a negative enum value without a name, such as `(DayOfWeek)(-1)`, gets the negative sign of the current culture (`"−1"` with U+2212 under `sv-SE`, also from `ParseWith<string>(CultureInfo.InvariantCulture)`).
- **Exact formats stay invariant**: the `format` strings are matched with `CultureInfo.InvariantCulture`, as by `Parse` (`/` and `:` are literal); the provider does not change them. `"13.12.2025".ParseWith<DateTime>(new CultureInfo("de-DE"), null, "dd/MM/yyyy")` is `default`, while without a format `"13.12.2025".ParseWith<DateTime>(new CultureInfo("de-DE"), null)` is 13 December 2025.
- **`null` provider**: the same as the existing overload. `ParsesWith` is lazy like `Parses`: with a `null` provider every element is parsed with the culture of the thread that enumerates the result, while an explicit provider, also `CultureInfo.CurrentCulture`, is the one passed to `ParsesWith`.
- **One-argument and default-value rules**: `defaultValue` has no default value in `ParseWith`, so `ParseWith<int>(provider)` follows `Parse<int>()` (floors fractional strings, `null` for a nullable `T`) and `ParseWith<int>(provider, null)` follows `Parse<int>(null)`.
- **Never throws**, also when the provider throws (for example from `GetFormat`): that step counts as a failed parse.
- **Not affected**: `Guid` and enum names do not depend on the culture (the sign of a negative enum value without a name does, see above). The dictionary and lookup forms of `Parses`, the `YANEnumerable` conversions (`ToList<T>`, `ToArray<T>`, ...) and `Parses<T>(params object?[]?)` have no provider form and use the current culture; an `object?[]` array binds to `ParsesWith<T>(IEnumerable<object?>?, ...)`.

### Changes since 8.3.3

- Out-of-range integer conversions (`"99999999999".Parse<int>()`, `1e10.Parse<int>()`, and through them `100000.Pow(2)` or `int.MinValue.Abs()` on `int`) used to crash the process with a stack overflow; they now return `0` / `null` / the default value.
- `nint` / `nuint` conversions work (`"5".Parse<nint>(0)` was 0, `"5".Parse<nint?>()` was `null`, `((object)5).Parse<nint>()` crashed).
- Fractional strings are floored exactly: `"2.9999999999999999".Parse<int>()` is 2 (was 3), `"0.99999999999999999999".Parse<byte>()` is 0 (was 1), `"12345678901234567.9".Parse<long>()` is 12345678901234567 (was 12345678901234600).
- Inputs that already have the target type are returned unchanged: `Animal a = new Dog(); a.IsDefault()` is `false` (was `true`), `new object[] { dog }.ToList<Animal>()` is `[dog]` (was `[null]`), parsed `DateTime` values keep milliseconds and `Kind`.
- `"bad".Parse<DateTime>(dt, "dd/MM/yyyy")` returns `dt` (was `DateTime.MinValue`).
- In `Parse<DateTime>` with a `format`, a default value that is not a `DateTime` and does not match the format is parsed again without it: `"bad".Parse<DateTime>("2025-01-01", "dd/MM/yyyy")` is 1 January 2025 (was `DateTime.MinValue`), also in `ParseWith`, `Parses` and `ParsesWith`. Only results that were `DateTime.MinValue` change.
- `Parses` and the `ToList`, `ToArray`, `ToImmutableArray`, ... conversions built on it keep the input order for 1,000+ elements (they used unordered PLINQ); `Parses` is lazily evaluated on the enumerating thread.
- Invalid strings no longer throw and catch exceptions internally: `"abc".Parse<int>()` takes about 30 ns instead of about 24 µs.
- New in 8.4.0: `ParseWith` and `ParsesWith` with an `IFormatProvider` (see [Culture](#culture-parsewith--parseswith)); the existing overloads are unchanged.
- New in 8.4.0: `Parses<TKey, TValue>(IDictionary<object, object?>?, Func<TValue?, TValue?, TValue?> onDuplicate)` resolves keys that parse to the same value (see Conversion Rules); `Parses<TKey, TValue>()` still throws `ArgumentException` for them. With the second overload, `var f = dict.Parses<int, string>;` needs an explicit delegate type (CS8917).


## Performance Considerations

- Per-type metadata is cached in a static generic class, which is thread-safe without locks
- Collection methods are lazily evaluated on the enumerating thread and preserve the input order
- The thin public facade is marked `DebuggerHidden` and `DebuggerStepThrough`, so the debugger steps from your code straight into the implementation (`YANLib.Implementation`), whose code you can step through
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
| **Dictionary Conversion** | Parses<TKey, TValue> for IDictionary<object, object?>, with an optional onDuplicate function |
| **Format Support** | Parse<T>(format) for DateTime and other format-dependent types |
| **Culture** | ParseWith<T>(provider), ParseWith<T>(provider, defaultValue, format), ParsesWith<T>(provider), ParsesWith<T>(provider, defaultValue, format) |


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
