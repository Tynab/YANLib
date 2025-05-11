### YANDateTime - DateTime Operations Utility Library

## Overview

`YANDateTime` is a comprehensive utility library that provides extension methods for working with DateTime objects in C# applications. It offers a wide range of date and time operations for both single DateTime values and collections, with support for generic types and null-safe operations.

## Features

The library is organized into several functional categories:

### Date Calculations

- **Week Number**: Calculate the week number of the year for a date
- **Month Difference**: Calculate the total number of months between two dates
- **Time Zone Conversion**: Change the time zone of DateTime objects


### Collection Operations

- **Batch Processing**: Apply date operations to collections of DateTime objects
- **Parallel Processing**: Automatic parallel processing for large collections (1000+ elements)
- **Null Handling**: Graceful handling of null values in collections


### Type Flexibility

- **Generic Support**: Process objects of any type that can be converted to DateTime
- **Nullable DateTime**: Support for nullable DateTime operations
- **Type Conversion**: Automatic conversion between different types


## Usage Examples

### Week Number Calculations

```csharp
// Get week number for a specific date
var date = new DateTime(2023, 6, 15);
int weekNumber = date.GetWeekOfYear(); // Returns 24

// Handle null values gracefully
DateTime? nullDate = null;
int weekForNull = nullDate.GetWeekOfYear(); // Returns 0

// Convert objects to DateTime and get week number
object dateObject = new DateTime(2023, 12, 31);
int weekForObject = dateObject.GetWeekOfYear<int>(); // Returns 53

// Convert string to DateTime and get week number
string dateString = "2023-01-01";
int weekForString = dateString.GetWeekOfYear<int>(); // Returns 1

// Get week number with custom return type
double weekAsDouble = date.GetWeekOfYear<double>(); // Returns 24.0
string weekAsString = date.GetWeekOfYear<string>(); // Returns "24"
```

### Month Difference Calculations

```csharp
// Calculate months between two dates
var date1 = new DateTime(2023, 6, 15);
var date2 = new DateTime(2022, 6, 15);
int monthDiff = YANDateTime.TotalMonth(date1, date2); // Returns 12

// Absolute value is always returned (order doesn't matter)
int sameMonthDiff = YANDateTime.TotalMonth(date2, date1); // Also returns 12

// Complex difference calculation
var complexDate1 = new DateTime(2023, 8, 15);
var complexDate2 = new DateTime(2021, 3, 10);
int complexMonthDiff = YANDateTime.TotalMonth(complexDate1, complexDate2); // Returns 29

// Handle null values gracefully
DateTime? nullDate = null;
int nullMonthDiff = YANDateTime.TotalMonth(date1, nullDate); // Returns 0

// Calculate with custom return type
string monthDiffAsString = YANDateTime.TotalMonth<string>(date1, date2); // Returns "12"
double monthDiffAsDouble = YANDateTime.TotalMonth<double>(date1, date2); // Returns 12.0
```

### Time Zone Conversions

```csharp
// Change time zone for a DateTime
var date = new DateTime(2023, 6, 15, 10, 0, 0);
var convertedDate = date.ChangeTimeZone(0, 3); // UTC to UTC+3, returns 2023-6-15 13:00:00

// Negative offset
var negativeOffset = date.ChangeTimeZone(0, -3); // UTC to UTC-3, returns 2023-6-15 7:00:00

// Same time zone (no change)
var sameTimeZone = date.ChangeTimeZone(2, 2); // Returns original date

// Using string time zones
var stringTimeZone = date.ChangeTimeZone("0", "3"); // Returns 2023-6-15 13:00:00

// Using decimal time zones for half-hour offsets
var halfHourOffset = date.ChangeTimeZone(0, 3.5m); // Returns 2023-6-15 13:30:00

// Handle edge cases near min/max DateTime
var nearMin = DateTime.MinValue.AddHours(2);
var safeNearMin = nearMin.ChangeTimeZone(0, -3); // Returns original date to avoid overflow

// Convert object to DateTime and change time zone
object dateObject = new DateTime(2023, 6, 15, 10, 0, 0);
var convertedObject = dateObject.ChangeTimeZone(0, 2); // Returns 2023-6-15 12:00:00
```

### Collection Operations

```csharp
// Get week numbers for a collection of dates
var dates = new DateTime?[]
{
    new DateTime(2023, 1, 1),
    new DateTime(2023, 6, 15),
    new DateTime(2023, 12, 31)
};
var weekNumbers = dates.GetWeekOfYears<int>()?.ToArray(); // Returns [1, 24, 53]

// Handle null values in collections
var datesWithNull = new DateTime?[]
{
    new DateTime(2023, 1, 1),
    null,
    new DateTime(2023, 12, 31)
};
var weeksWithNull = datesWithNull.GetWeekOfYears<int>()?.ToArray(); // Returns [1, 0, 53]

// Change time zone for a list of dates (modifies the list in-place)
var dateList = new List<DateTime>
{
    new(2023, 1, 1, 10, 0, 0),
    new(2023, 6, 15, 12, 0, 0),
    new(2023, 12, 31, 14, 0, 0)
};
dateList.ChangeTimeZone(0, 2); // Modifies list to [2023-1-1 12:00, 2023-6-15 14:00, 2023-12-31 16:00]

// Change time zone for an enumerable (returns a new collection)
var dateArray = new DateTime[]
{
    new(2023, 1, 1, 10, 0, 0),
    new(2023, 6, 15, 12, 0, 0),
    new(2023, 12, 31, 14, 0, 0)
};
var convertedDates = dateArray.ChangeTimeZones(0, 3)?.ToArray(); // Returns new collection with converted dates

// Process collections of objects that can be converted to DateTime
var objectDates = new object?[]
{
    new DateTime(2023, 1, 1),
    "2023-06-15",
    1672444800000 // Unix timestamp
};
var objectWeeks = objectDates.GetWeekOfYears<int>()?.ToArray(); // Returns [1, 24, ...]

// Process non-generic collections
ArrayList dateList = [new DateTime(2023, 1, 1), new DateTime(2023, 6, 15)];
var weeksFromArrayList = dateList.GetWeekOfYears<int>()?.ToArray(); // Returns [1, 24]
```

### Advanced Usage Examples

```csharp
// Using params array for convenience
var weekNumbers = YANDateTime.GetWeekOfYears<int>(
    new DateTime(2023, 1, 1), 
    new DateTime(2023, 6, 15), 
    new DateTime(2023, 12, 31)
)?.ToArray(); // Returns [1, 24, 53]

// Convert week numbers to different types
var weekStrings = dates.GetWeekOfYears<string>()?.ToArray(); // Returns ["1", "24", "53"]
var weekDoubles = dates.GetWeekOfYears<double>()?.ToArray(); // Returns [1.0, 24.0, 53.0]

// Change time zone for a collection of objects
var mixedObjects = new List<object?>
{
    new DateTime(2023, 1, 1, 10, 0, 0),
    "2023-06-15 12:00:00",
    new DateTime(2023, 12, 31, 14, 0, 0)
};
mixedObjects.ChangeTimeZone(0, 2); // Modifies list with converted DateTime objects

// Process large collections with automatic parallel processing
var largeDateCollection = Enumerable.Range(0, 10000)
    .Select(i => new DateTime(2023, 1, 1).AddDays(i))
    .ToList();
var largeWeekCollection = largeDateCollection.GetWeekOfYears<int>(); // Uses parallel processing

// Handle invalid objects gracefully
var mixedValidInvalid = new object?[]
{
    new DateTime(2023, 1, 1),
    "not a date",
    null
};
var safeResults = mixedValidInvalid.GetWeekOfYears<int?>()?.ToArray(); // Returns [1, null, null]
```

## Performance Considerations

- **Parallel Processing**: For collections with more than 1000 elements, the library automatically uses parallel processing for better performance
- **Type Conversion**: The library handles type conversion internally, minimizing the need for explicit casting
- **Null Handling**: All methods handle null inputs gracefully, returning appropriate default values rather than throwing exceptions
- **Edge Case Protection**: Time zone conversions include protection against DateTime overflow/underflow
- **Debugging Support**: Uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience


## Implementation Details

- **Extension Methods**: All operations are implemented as extension methods for better integration with existing code
- **Generic Type Support**: Methods use generic type parameters to support various return types
- **Null Safety**: All methods are designed to be null-safe, handling null inputs gracefully
- **Partial Classes**: Uses partial classes to organize functionality by category:
    - Core functionality (YANDateTime.cs)
    - Collection operations (YANDateTime.Collection.cs)
    - Generic operations (YANDateTime.Generic.cs)
    - Nullable operations (YANDateTime.Nullable.cs)
- **Internal Implementation**: Core implementation details are separated from the public API for better maintainability


## Date and Time Operations Coverage

The library provides focused coverage of date and time operations:

| Category | Functions |
|----------|-----------|
| **Week Calculation** | GetWeekOfYear, GetWeekOfYear<T> |
| **Month Calculation** | TotalMonth, TotalMonth<T> |
| **Time Zone Conversion** | ChangeTimeZone |
| **Collection Week Calculation** | GetWeekOfYears<T> |
| **Collection Time Zone Conversion** | ChangeTimeZones |
| **Generic Type Support** | Generic versions of all operations |
| **Nullable Type Support** | Support for nullable DateTime operations |


## Technical Details

- **Week Number Calculation**: Implements ISO 8601 week numbering system for consistent week calculations
- **Month Difference Algorithm**: Uses a specialized algorithm that considers both year and month components for accurate month difference calculations
- **Time Zone Conversion**: Implements time zone conversion using hour offsets rather than time zone identifiers
- **DateTime Overflow Protection**: Includes safeguards against DateTime overflow/underflow during time zone conversions
- **String Parsing**: Uses `DateTime.TryParse` with InvariantCulture for consistent string-to-DateTime conversion
- **Parallel Processing**: Implements parallel processing using `Parallel.ForEach` for collections with more than 1000 elements
- **Generic Implementation**: Uses generic type parameters with constraints to support various return types
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
- **Thread Safety**: All operations are thread-safe, with no shared mutable state
