### YANText - Text Manipulation Utility Library


## Overview

`YANText` is a comprehensive utility library that provides extension methods for text manipulation, character operations, and string validation in C# applications. It offers a wide range of methods for working with strings, characters, and collections of text elements, with support for both non-nullable and nullable types.


## Features

The library is organized into several functional categories:

### String Operations

- **Case Conversion**: Convert strings to different cases (lowercase, uppercase, title case)
- **Word Case Conversion** (8.5.0): Convert text or identifiers to camelCase, PascalCase, snake_case, SNAKE_CASE, kebab-case and KEBAB-CASE
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
- **Order Preservation**: Collection results are lazily evaluated and keep the input order


## Usage Examples

### String Operations

```csharp
// Case conversion
string text = "hello world";
string upper = text.Upper(); // Returns "HELLO WORLD"
string lower = text.Lower(); // Returns "hello world"
string title = text.Title(); // Returns "Hello World"
string capitalized = text.Capitalize(); // Returns "Hello world"

// Word case conversion (8.5.0)
string camel = "hello world".CamelCase(); // Returns "helloWorld"
string pascal = "user_id".PascalCase(); // Returns "UserId"
string snake = "HTTPServer".SnakeLowerCase(); // Returns "http_server"
string constant = "getHTTPResponseCode".SnakeUpperCase(); // Returns "GET_HTTP_RESPONSE_CODE"
string kebab = "XMLHttpRequest".KebabLowerCase(); // Returns "xml-http-request"
string header = "content type".KebabUpperCase(); // Returns "CONTENT-TYPE"

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

// Complex string formatting: punctuation separates the words and digits are removed
string rawName = "john.q.public123";
string formattedName = rawName.FormatName(); // Returns "John Q Public"

// Filtering first removes the dots, so the words run together
string filteredName = rawName
    .FilterAlphanumeric() // Remove special characters: "johnqpublic123"
    .Replace("123", "") // Remove numbers: "johnqpublic"
    .FormatName(); // Returns "Johnqpublic"

// Tabs, repeated separators and trailing punctuation do not leave extra spaces
string tidyName = " john ,\tDOE. ".FormatName(); // Returns "John Doe"
```


### Word Case Conversion Rules

`CamelCase`, `PascalCase`, `SnakeLowerCase`, `SnakeUpperCase`, `KebabLowerCase` and `KebabUpperCase` (8.5.0) split the input into words, then write the words in their style:

- A word is a run of letters and decimal digits (Unicode letters included). Every other character (white space, `_`, `-`, `.`, `/`, symbols, emoji) separates words and is dropped. A combining mark stays with the letter before it, so decomposed text (`"cha\u0300o"`) stays one word; a mark with no letter before it is dropped.
- A new word also starts at an upper-case letter that follows a lower-case letter, a digit or an uncased letter (`helloWorld` is hello + World, `version2Update` is version2 + Update), and at the last upper-case letter of a run that is followed by a lower-case letter (`HTTPServer` is HTTP + Server, `XMLHttpRequest` is XML + Http + Request). A digit stays with the word before it, and letters after a digit continue the word (`foo123bar` is one word). An acronym followed by a word that starts with a lower-case letter is split before its last capital (`IPv6Address` is I + Pv6 + Address, `iOS` is i + OS).
- Letters are cased with the invariant culture, so the result does not depend on the current culture (under `tr-TR`, `"ID".CamelCase()` is `"id"`, not `"ıd"`). camelCase writes the first word in lower case and starts every other word with an upper-case letter; PascalCase starts every word with an upper-case letter; the other letters of a word are lower case. The snake and kebab styles join the words with `_` or `-`, all in lower or all in upper case.
- `null`, an empty string and white space are returned as they are; a string with no letter or digit (`"--"`) gives an empty string; when the result equals the input, the input string itself is returned (no allocation for the result).
- The `List<string?>` overloads convert in place (lists of 1,000 or more strings in parallel by index); the `IEnumerable<string?>` and `params` overloads (`CamelCases`, `PascalCases`, ...) are lazily evaluated and keep the input order. `null` elements stay `null`.

| Input | CamelCase | PascalCase | SnakeLowerCase | SnakeUpperCase | KebabLowerCase | KebabUpperCase |
|-------|-----------|------------|----------------|----------------|----------------|----------------|
| `hello world` | helloWorld | HelloWorld | hello_world | HELLO_WORLD | hello-world | HELLO-WORLD |
| `HTTPServer` | httpServer | HttpServer | http_server | HTTP_SERVER | http-server | HTTP-SERVER |
| `user_id` | userId | UserId | user_id | USER_ID | user-id | USER-ID |
| `Version 2 update` | version2Update | Version2Update | version_2_update | VERSION_2_UPDATE | version-2-update | VERSION-2-UPDATE |
| `Xin chào thế giới` | xinChàoThếGiới | XinChàoThếGiới | xin_chào_thế_giới | XIN_CHÀO_THẾ_GIỚI | xin-chào-thế-giới | XIN-CHÀO-THẾ-GIỚI |


## Performance Considerations

- The library uses optimized implementations for different text operations
- Collection methods that return `IEnumerable<T>` are lazily evaluated and preserve the input order; the in-place `List<string?>` / `List<char>` / `List<char?>` overloads (`Title`, `Lower`, `Upper`, ...) update lists with 1,000+ elements in parallel by index, so the order is kept as well
- The thin public facade is marked `DebuggerHidden` and `DebuggerStepThrough`, so the debugger steps from your code straight into the implementation (`YANLib.Implementation`), whose code you can step through
- String operations are designed to minimize memory allocations where possible: `CleanSpace`, the `Filter*` methods and the word case methods (`CamelCase`, `SnakeLowerCase`, ...) build their result in a stack buffer (a pooled array for long strings) and return the input itself when nothing changes, `Capitalize` writes straight into the new string, and `FormatName` reuses a per-thread `StringBuilder`
- `AllEqualsIgnoreCase`, `AnyEqualsIgnoreCase`, `AllNotEqualsIgnoreCase` and `AnyNotEqualsIgnoreCase` compare strings exactly like `EqualsIgnoreCase` (`StringComparison.OrdinalIgnoreCase`), enumerate the collection once and do not create lower-cased copies; for arrays and lists (of up to 16 strings for `AnyEqualsIgnoreCase` / `AllNotEqualsIgnoreCase`, which otherwise use a `HashSet`) they allocate nothing


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
| **String Word Case Conversion** | CamelCase, PascalCase, SnakeLowerCase, SnakeUpperCase, KebabLowerCase, KebabUpperCase |
| **String Formatting** | FormatName, CleanSpace |
| **String Content Filtering** | FilterAlphabetic, FilterNumber, FilterAlphanumeric |
| **String Validation** | IsNullEmpty, IsNotNullEmpty, IsNullWhiteSpace, IsNotNullWhiteSpace |
| **Character Type Checking** | IsEmpty, IsWhiteSpace, IsAlphabetic, IsNumber, IsAlphanumeric, IsPunctuation |
| **Character Case Operations** | Upper, Lower, EqualsIgnoreCase, NotEqualsIgnoreCase |
| **Nullable Character Operations** | IsNullEmpty, IsNotNullEmpty, Upper, Lower for nullable char |
| **Character Collection Operations** | AllEmpty, AnyEmpty, AllWhiteSpace, AnyWhiteSpace, AllAlphabetic, AnyAlphabetic, AllNumber, AnyNumber, AllAlphanumeric, AnyAlphanumeric, AllPunctuation, AnyPunctuation, AllLowers, AnyLowers, AllUppers, AnyUppers |
| **String Collection Operations** | AllNull, AnyNull, AllNullEmpty, AnyNullEmpty, AllNullWhiteSpace, AnyNullWhiteSpace, AllNotNull, AnyNotNull, AllNotNullEmpty, AnyNotNullEmpty, AllNotNullWhiteSpace, AnyNotNullWhiteSpace, AllEqualsIgnoreCase, AnyEqualsIgnoreCase |
| **Collection Case Conversion** | Upper, Lower, Uppers, Lowers, Titles, Capitalizes |
| **Collection Word Case Conversion** | CamelCase, PascalCase, SnakeLowerCase, SnakeUpperCase, KebabLowerCase, KebabUpperCase (in place); CamelCases, PascalCases, SnakeLowerCases, SnakeUpperCases, KebabLowerCases, KebabUpperCases |
| **Collection Formatting** | FormatNames, CleanSpaces |
| **Collection Content Filtering** | FilterAlphabetics, FilterNumbers, FilterAlphanumerics |


## Technical Details

- **String Manipulation**: Implements efficient string manipulation using `StringBuilder` where appropriate
- **Character Classification**: Uses `char` methods like `char.IsLetter()`, `char.IsDigit()` for character classification
- **Case Conversion**: Uses `ToUpper()` and `ToLower()` with culture considerations for case conversion; the word case methods use the invariant culture (`Rune.ToUpperInvariant` / `Rune.ToLowerInvariant`)
- **Whitespace Handling**: Implements specialized methods for cleaning and normalizing whitespace
- **String Formatting**: Uses regex and string replacement for complex text formatting operations
- **Collection Processing**: Implements specialized methods for processing collections of strings or characters
- **Null Safety**: Implements comprehensive null checking throughout the API
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
- **Memory Efficiency**: Optimizes string operations to minimize memory allocations and garbage collection
