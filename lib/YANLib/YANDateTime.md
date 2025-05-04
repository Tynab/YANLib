### YANDateTime Component

The `YANDateTime` component is part of the YANLib library, providing extensive DateTime manipulation and calculation functionality with support for various data types and collections.


## Overview

YANDateTime offers a comprehensive set of extension methods for working with date and time values, supporting:

- Regular DateTime objects
- Nullable DateTime objects
- Generic object conversions
- Collections of DateTime objects
- String date representations
- Custom objects with DateTime properties


## Key Features

### Time Zone Conversion

Convert DateTime values between different time zones:

```csharp
// Convert a single DateTime
DateTime date = new DateTime(2023, 6, 15, 10, 0, 0);
DateTime converted = date.ChangeTimeZone(0, 2); // UTC to UTC+2

// Convert a collection of DateTimes
var dates = new DateTime[] 
{
    new DateTime(2023, 1, 1, 10, 0, 0),
    new DateTime(2023, 6, 15, 12, 0, 0)
};

var convertedDates = dates.ChangeTimeZones(0, 3); // UTC to UTC+3
```

### Week of Year Calculation

Calculate the week number for a given date:

```csharp
DateTime date = new DateTime(2023, 6, 15);
int weekNumber = date.GetWeekOfYear(); // Returns 24

// For collections
var dates = new DateTime[] 
{
    new DateTime(2023, 1, 1),
    new DateTime(2023, 6, 15)
};

var weekNumbers = dates.GetWeekOfYears<int>(); // Returns [1, 24]
```

### Month Difference Calculation

Calculate the total number of months between two dates:

```csharp
DateTime date1 = new DateTime(2023, 6, 15);
DateTime date2 = new DateTime(2022, 6, 15);
int monthDifference = YANDateTime.TotalMonth(date1, date2); // Returns 12
```


## Supported Types

YANDateTime methods work with:

- `DateTime` and `DateTime?` objects
- String representations of dates
- Generic objects that can be converted to DateTime
- Collections (`IEnumerable<T>`) of DateTime objects or convertible types


## Null Handling

The library provides robust null handling:

- Nullable methods return null for null inputs
- Collection methods preserve null values in the results
- Invalid date strings or objects are handled gracefully


## Generic Type Conversion

Methods support generic type parameters for flexible return types:

```csharp
// Return as int
int week = date.GetWeekOfYear<int>();

// Return as string
string weekStr = date.GetWeekOfYear<string>();

// Return as double
double weekDbl = date.GetWeekOfYear<double>();
```


## Collection Processing

Process entire collections of dates with a single method call:

```csharp
// Change time zones for all dates in a collection
var dates = new List<DateTime> { /* dates */ };
var convertedDates = dates.ChangeTimeZones(0, 2);

// Get week numbers for all dates
var weekNumbers = dates.GetWeekOfYears<int>();
```


## Edge Cases

The library handles various edge cases:

- Near minimum/maximum DateTime values
- Daylight saving time transitions
- Invalid time zone specifications
- Mixed valid and invalid inputs in collections


## Usage Examples

### Time Zone Conversion

#### Basic Time Zone Conversion

Convert a DateTime from one time zone to another:

```csharp
// Convert from UTC to UTC+3
DateTime utcDate = new DateTime(2023, 6, 15, 10, 0, 0);
DateTime convertedDate = utcDate.ChangeTimeZone(0, 3);
// Result: 2023-06-15 13:00:00

// Convert using string time zone offsets
DateTime result = utcDate.ChangeTimeZone("0", "3");
// Result: 2023-06-15 13:00:00

// Convert using decimal time zone offsets (for half-hour time zones)
DateTime halfHourResult = utcDate.ChangeTimeZone(0, 3.5m);
// Result: 2023-06-15 13:30:00
```

#### Converting Collections of Dates

Process multiple dates at once:

```csharp
// Convert a list of dates from UTC to UTC+2
var dateList = new List<DateTime>
{
    new DateTime(2023, 1, 1, 10, 0, 0),
    new DateTime(2023, 6, 15, 12, 0, 0),
    new DateTime(2023, 12, 31, 14, 0, 0)
};

// In-place modification of the list
dateList.ChangeTimeZone(0, 2);
// dateList now contains:
// 2023-01-01 12:00:00
// 2023-06-15 14:00:00
// 2023-12-31 16:00:00

// Create a new collection with converted dates
var dates = new DateTime[]
{
    new DateTime(2023, 1, 1, 10, 0, 0),
    new DateTime(2023, 6, 15, 12, 0, 0)
};

var convertedDates = dates.ChangeTimeZones(0, -3)?.ToArray();
// Result: 
// 2023-01-01 07:00:00
// 2023-06-15 09:00:00
```

#### Working with String Dates and Mixed Types

Convert dates in various formats:

```csharp
// Working with string dates
var mixedInput = new object[]
{
    new DateTime(2023, 1, 1, 10, 0, 0),
    "2023-06-15 12:00:00",
    "2023-12-31 14:00:00"
};

var convertedMixed = mixedInput.ChangeTimeZones(0, 3)?.ToArray();
// Result:
// 2023-01-01 13:00:00
// 2023-06-15 15:00:00
// 2023-12-31 17:00:00
```

### Week of Year Calculation

#### Basic Week Number Calculation

Get the ISO week number for a date:

```csharp
// Get week number for a specific date
DateTime date = new DateTime(2023, 6, 15);
int weekNumber = date.GetWeekOfYear();
// Result: 24

// Get week number for the first day of the year
DateTime firstDay = new DateTime(2023, 1, 1);
int firstWeek = firstDay.GetWeekOfYear();
// Result: 1

// Get week number for the last day of the year
DateTime lastDay = new DateTime(2023, 12, 31);
int lastWeek = lastDay.GetWeekOfYear();
// Result: 53
```

#### Working with Collections of Dates

Calculate week numbers for multiple dates:

```csharp
// Get week numbers for an array of dates
var dates = new DateTime?[]
{
    new DateTime(2023, 1, 1),
    new DateTime(2023, 6, 15),
    new DateTime(2023, 12, 31)
};

var weekNumbers = dates.GetWeekOfYears<int>()?.ToArray();
// Result: [1, 24, 53]

// Using the params overload
var weeks = YANDateTime.GetWeekOfYears<int>(
    new DateTime(2023, 1, 1), 
    new DateTime(2023, 6, 15), 
    new DateTime(2023, 12, 31)
)?.ToArray();
// Result: [1, 24, 53]
```

#### Type Conversion

Get week numbers in different formats:

```csharp
// Get week number as string
DateTime date = new DateTime(2023, 12, 31);
string weekStr = date.GetWeekOfYear<string>();
// Result: "53"

// Get week number as double
double weekDbl = date.GetWeekOfYear<double>();
// Result: 53.0

// Get week numbers as strings for a collection
var dates = new DateTime?[]
{
    new DateTime(2023, 1, 1),
    new DateTime(2023, 6, 15)
};

var weekStrings = dates.GetWeekOfYears<string>()?.ToArray();
// Result: ["1", "24"]
```

### Month Difference Calculation

Calculate the number of months between dates:

```csharp
// Calculate months between two dates
DateTime date1 = new DateTime(2023, 6, 15);
DateTime date2 = new DateTime(2022, 6, 15);
int monthDiff = YANDateTime.TotalMonth(date1, date2);
// Result: 12

// Calculate months with different day values
DateTime date3 = new DateTime(2023, 8, 15);
DateTime date4 = new DateTime(2021, 3, 10);
int complexDiff = YANDateTime.TotalMonth(date3, date4);
// Result: 29

// Calculate months with negative difference (returns absolute value)
DateTime date5 = new DateTime(2022, 1, 15);
DateTime date6 = new DateTime(2023, 7, 15);
int negDiff = YANDateTime.TotalMonth(date5, date6);
// Result: 18
```

### Working with Nullable Types

Handle null values gracefully:

```csharp
// Handling null DateTime values
DateTime? nullDate = null;
int weekResult = nullDate.GetWeekOfYear();
// Result: 0

// Handling null values in collections
var mixedDates = new DateTime?[]
{
    new DateTime(2023, 1, 1, 10, 0, 0),
    null,
    new DateTime(2023, 12, 31, 14, 0, 0)
};

var convertedMixed = mixedDates.ChangeTimeZones(0, 2)?.ToArray();
// Result:
// 2023-01-01 12:00:00
// null
// 2023-12-31 16:00:00
```

### Working with Custom Objects

Use DateTime methods with custom objects:

```csharp
// Define a custom class with a DateTime property
public class EventDate
{
    public DateTime Date { get; set; }
    
    public override string ToString() => Date.ToString();
}

// Use with custom objects
var event1 = new EventDate { Date = new DateTime(2023, 6, 15) };
int weekNumber = event1.Date.GetWeekOfYear();
// Result: 24

// Use with collections of custom objects
var events = new EventDate[]
{
    new() { Date = new DateTime(2023, 1, 1, 10, 0, 0) },
    new() { Date = new DateTime(2023, 6, 15, 12, 0, 0) }
};

// Convert the dates in the custom objects
var convertedDates = events.ChangeTimeZones(0, 2)?.ToArray();
// Result:
// 2023-01-01 12:00:00
// 2023-06-15 14:00:00
```

### Handling Invalid Inputs

The library gracefully handles invalid inputs:

```csharp
// Invalid string date
object invalidDate = "not a date";
var result = invalidDate.ChangeTimeZone(0, 2);
// Result: null

// Mixed valid and invalid inputs in a collection
var mixedInput = new string?[]
{
    "2023-01-01 10:00:00",
    "not a date",
    "2023-12-31 14:00:00"
};

var convertedMixed = mixedInput.ChangeTimeZones(0, 2)?.ToArray();
// Result:
// 2023-01-01 12:00:00
// null
// 2023-12-31 16:00:00

// Invalid time zone specifications
var date = new DateTime(2023, 6, 15, 10, 0, 0);
var defaultResult = date.ChangeTimeZone("invalid", "timezone");
// Result: Same as input (2023-06-15 10:00:00)
```

### Edge Cases

The library handles various edge cases:

```csharp
// Near minimum DateTime value
var nearMin = DateTime.MinValue.AddHours(2);
var minResult = nearMin.ChangeTimeZone(0, -3);
// Result: Same as input (no change to avoid overflow)

// Near maximum DateTime value
var nearMax = DateTime.MaxValue.AddHours(-2);
var maxResult = nearMax.ChangeTimeZone(0, 3);
// Result: Same as input (no change to avoid overflow)

// Daylight saving time transitions
var dstDates = new DateTime[]
{
    new(2023, 3, 25, 10, 0, 0), // Before DST change
    new(2023, 3, 27, 10, 0, 0), // After DST change
    new(2023, 10, 28, 10, 0, 0), // Before DST end
    new(2023, 10, 30, 10, 0, 0)  // After DST end
};

var convertedDst = dstDates.ChangeTimeZones(0, -5)?.ToArray();
// Result: All dates shifted by 5 hours
```
