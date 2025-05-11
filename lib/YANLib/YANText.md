### YANText - Text Manipulation Utility Library

## Overview

`YANText` is a comprehensive utility library that provides extension methods for text manipulation, character operations, and string validation in C# applications. It offers a wide range of methods for working with strings, characters, and collections of text elements, with support for both non-nullable and nullable types.

## Features

The library is organized into several functional categories:

### String Operations

- **Case Conversion**: Convert strings to different cases (lowercase, uppercase, title case)
- **Text Formatting**: Format strings as proper names, clean whitespace, capitalize text
- **Content Filtering**: Extract specific character types (alphabetic, numeric, alphanumeric)
- **Null/Empty Checking**: Determine if strings are null, empty, or whitespace


### Character Operations

- **Type Checking**: Check if characters are empty, whitespace, alphabetic, numeric, etc.
- **Case Conversion**: Convert characters to uppercase or lowercase
- **Case Comparison**: Compare characters ignoring case differences
- **Collection Operations**: Perform operations on collections of characters


### Nullable Character Support

- **Null Handling**: Special handling for nullable character operations
- **Type Checking**: Check if nullable characters are null, empty, whitespace, etc.
- **Case Conversion**: Convert nullable characters to uppercase or lowercase
- **Collection Operations**: Perform operations on collections of nullable characters


### Collection Operations

- **Bulk Processing**: Apply text operations to collections of strings or characters
- **Validation**: Check if all or any elements in a collection meet specific criteria
- **Case Conversion**: Convert all strings or characters in a collection to a specific case
- **Parallel Processing**: Automatic parallel processing for large collections


## Usage Examples

### String Operations

```csharp
// Case conversion
string text = "hello world";
string upper = text.Upper(); // Returns "HELLO WORLD"
string lower = text.Lower(); // Returns "hello world"
string title = text.Title(); // Returns "Hello World"
string capitalized = text.Capitalize(); // Returns "Hello world"

// Text formatting
string name = "john.doe";
string formatted = name.FormatName(); // Returns "John Doe"

string messy = "  hello   world  ";
string clean = messy.CleanSpace(); // Returns "hello world"

// Content filtering
string mixed = "abc123!@#";
string letters = mixed.FilterAlphabetic(); // Returns "abc"
string numbers = mixed.FilterNumber(); // Returns "123"
string alphanumeric = mixed.FilterAlphanumeric(); // Returns "abc123"

// Null/empty checking
string? nullString = null;
bool isNull = nullString.IsNullEmpty(); // Returns true
bool isNotNull = nullString.IsNotNullEmpty(); // Returns false

string empty = "";
bool isEmpty = empty.IsNullEmpty(); // Returns true
bool isNotEmpty = empty.IsNotNullEmpty(); // Returns false

string whitespace = "   ";
bool isWhitespace = whitespace.IsNullWhiteSpace(); // Returns true
bool isNotWhitespace = whitespace.IsNotNullWhiteSpace(); // Returns false
```

### Character Operations

```csharp
// Type checking
char c = 'a';
bool isAlphabetic = c.IsAlphabetic(); // Returns true
bool isNumeric = c.IsNumber(); // Returns false
bool isAlphanumeric = c.IsAlphanumeric(); // Returns true
bool isPunctuation = c.IsPunctuation(); // Returns false
bool isWhitespace = c.IsWhiteSpace(); // Returns false

char whitespace = ' ';
bool isWhitespace2 = whitespace.IsWhiteSpace(); // Returns true

char defaultChar = default;
bool isEmpty = defaultChar.IsEmpty(); // Returns true

// Case conversion
char upper = 'a'.Upper(); // Returns 'A'
char lower = 'A'.Lower(); // Returns 'a'

// Case comparison
bool equals = 'a'.EqualsIgnoreCase('A'); // Returns true
bool notEquals = 'a'.NotEqualsIgnoreCase('b'); // Returns true

// Character collections
char[] chars = ['a', 'B', 'c'];
bool allAlphabetic = chars.AllAlphabetic(); // Returns true
bool anyUpper = chars.AnyUppers(); // Returns true
bool allLower = chars.AllLowers(); // Returns false

// Convert case in collections
List<char> charList = ['a', 'b', 'c'];
charList.Upper(); // Modifies list to ['A', 'B', 'C']

IEnumerable<char> upperChars = chars.Uppers(); // Returns ['A', 'B', 'C']
```

### Nullable Character Operations

```csharp
// Type checking with nullable characters
char? nullChar = null;
bool isNull = nullChar.IsNullEmpty(); // Returns true
bool isNotNull = nullChar.IsNotNullEmpty(); // Returns false

char? c = 'a';
bool isAlphabetic = c.IsAlphabetic(); // Returns true
bool isNumeric = c.IsNumber(); // Returns false

// Case conversion with nullable characters
char? upper = c.Upper(); // Returns 'A'
char? lower = 'A'.Lower(); // Returns 'a'
char? nullResult = nullChar.Upper(); // Returns null

// Nullable character collections
char?[] chars = ['a', null, 'c'];
bool anyNull = chars.AnyNullEmpty(); // Returns true
bool allAlphabetic = chars.AllAlphabetic(); // Returns false
bool anyAlphabetic = chars.AnyAlphabetic(); // Returns true

// Convert case in nullable collections
List<char?> charList = ['a', null, 'c'];
charList.Upper(); // Modifies list to ['A', null, 'C']

IEnumerable<char?> upperChars = chars.Uppers(); // Returns ['A', null, 'C']
```

### String Collection Operations

```csharp
// Check if all strings in a collection are null
IEnumerable<string?> allNulls = [null, null, null];
bool allNull = allNulls.AllNull(); // Returns true

// Check if any string in a collection is null
IEnumerable<string?> someNulls = ["text", null, "more text"];
bool anyNull = someNulls.AnyNull(); // Returns true

// Check if all strings are not null or empty
IEnumerable<string?> nonEmpty = ["text1", "text2", "text3"];
bool allNotEmpty = nonEmpty.AllNotNullEmpty(); // Returns true

// Check if all strings are equal (ignoring case)
IEnumerable<string?> sameText = ["text", "TEXT", "Text"];
bool allEqual = sameText.AllEqualsIgnoreCase(); // Returns true

// Convert all strings in a collection to uppercase
List<string?> texts = ["hello", "world", null];
texts.Upper(); // Modifies list to ["HELLO", "WORLD", null]

// Get a new collection with all strings converted to lowercase
IEnumerable<string?> lowerTexts = texts.Lowers(); // Returns ["hello", "world", null]

// Format all strings in a collection
IEnumerable<string?> names = ["john.doe", "jane.smith", null];
IEnumerable<string?> formattedNames = names.FormatNames(); // Returns ["John Doe", "Jane Smith", null]

// Clean whitespace in all strings in a collection
IEnumerable<string?> messyTexts = ["  hello  ", "  world  ", null];
IEnumerable<string?> cleanTexts = messyTexts.CleanSpaces(); // Returns ["hello", "world", null]
```

### Advanced Usage Examples

```csharp
// Combining operations
string text = "  JOHN.DOE@123  ";
string result = text.CleanSpace().FilterAlphabetic().Lower().Capitalize(); // Returns "Johndoe"

// Processing collections with multiple operations
IEnumerable<string?> inputs = ["  JOHN.DOE  ", "  jane.SMITH  ", null, "  bob.123.JOHNSON  "];
var results = inputs
    .Where(x => x.IsNotNullWhiteSpace())
    .Select(x => x.CleanSpace().FormatName())
    .ToList(); // Returns ["John Doe", "Jane Smith", "Bob Johnson"]

// Character analysis
string password = "Password123!";
bool hasLower = password.ToCharArray().AnyLowers(); // Returns true
bool hasUpper = password.ToCharArray().AnyUppers(); // Returns true
bool hasNumber = password.ToCharArray().AnyNumber(); // Returns true
bool hasPunctuation = password.ToCharArray().AnyPunctuation(); // Returns true

// Complex string formatting
string rawName = "john.q.public123";
string formattedName = rawName
    .FilterAlphanumeric() // Remove special characters
    .Replace("123", "") // Remove numbers
    .FormatName(); // Format as proper name
// Returns "John Q Public"
```

## Performance Considerations

- The library uses optimized implementations for different text operations
- For large collections (>1000 items), parallel processing is automatically used
- The implementation uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience
- String operations are designed to minimize memory allocations where possible


## Implementation Details

- Extension methods are implemented in partial classes for better organization
- Internal implementation methods are separated from the public API
- The library uses nullable reference types for better null safety
- All public methods are well-documented with XML comments
- Character and string operations handle edge cases gracefully


## Text Operations Coverage

The library provides comprehensive coverage of text manipulation operations:

| Category | Functions |
|----------|-----------|
| **String Case Conversion** | Upper, Lower, Title, Capitalize |
| **String Formatting** | FormatName, CleanSpace |
| **String Content Filtering** | FilterAlphabetic, FilterNumber, FilterAlphanumeric |
| **String Validation** | IsNullEmpty, IsNotNullEmpty, IsNullWhiteSpace, IsNotNullWhiteSpace |
| **Character Type Checking** | IsEmpty, IsWhiteSpace, IsAlphabetic, IsNumber, IsAlphanumeric, IsPunctuation |
| **Character Case Operations** | Upper, Lower, EqualsIgnoreCase, NotEqualsIgnoreCase |
| **Nullable Character Operations** | IsNullEmpty, IsNotNullEmpty, Upper, Lower for nullable char |
| **Character Collection Operations** | AllEmpty, AnyEmpty, AllWhiteSpace, AnyWhiteSpace, AllAlphabetic, AnyAlphabetic, AllNumber, AnyNumber, AllAlphanumeric, AnyAlphanumeric, AllPunctuation, AnyPunctuation, AllLowers, AnyLowers, AllUppers, AnyUppers |
| **String Collection Operations** | AllNull, AnyNull, AllNullEmpty, AnyNullEmpty, AllNullWhiteSpace, AnyNullWhiteSpace, AllNotNull, AnyNotNull, AllNotNullEmpty, AnyNotNullEmpty, AllNotNullWhiteSpace, AnyNotNullWhiteSpace, AllEqualsIgnoreCase, AnyEqualsIgnoreCase |
| **Collection Case Conversion** | Upper, Lower, Uppers, Lowers, Titles, Capitalizes |
| **Collection Formatting** | FormatNames, CleanSpaces |
| **Collection Content Filtering** | FilterAlphabetics, FilterNumbers, FilterAlphanumerics |


## Technical Details

- **String Manipulation**: Implements efficient string manipulation using `StringBuilder` where appropriate
- **Character Classification**: Uses `char` methods like `char.IsLetter()`, `char.IsDigit()` for character classification
- **Case Conversion**: Uses `ToUpper()` and `ToLower()` with culture considerations for case conversion
- **Whitespace Handling**: Implements specialized methods for cleaning and normalizing whitespace
- **String Formatting**: Uses regex and string replacement for complex text formatting operations
- **Collection Processing**: Implements specialized methods for processing collections of strings or characters
- **Null Safety**: Implements comprehensive null checking throughout the API
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
- **Memory Efficiency**: Optimizes string operations to minimize memory allocations and garbage collection
