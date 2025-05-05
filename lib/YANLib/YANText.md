### YANText Component

The `YANText` component is part of the YANLib library, providing a comprehensive set of extension methods for text manipulation, validation, and transformation in .NET applications.


## Overview

YANText offers an extensive collection of extension methods for working with strings and characters, both individually and in collections. It provides convenient ways to perform common text operations like case conversion, whitespace handling, character filtering, and validation with built-in null safety.


## Key Features

### String Manipulation

Transform strings with ease:

```csharp
// Title case conversion
"hello world".Title(); // Returns "Hello World"

// Capitalize first letter only
"hello world".Capitalize(); // Returns "Hello world"

// Clean whitespace (trim and normalize)
"  hello  world  ".CleanSpace(); // Returns "hello world"

// Format names
"john.doe".FormatName(); // Returns "John Doe"

// Filter characters
"abc123!@#".FilterAlphabetic(); // Returns "abc"
"abc123!@#".FilterNumber(); // Returns "123"
"abc123!@#".FilterAlphanumeric(); // Returns "abc123"
```

### String Validation

Check string properties with null safety:

```csharp
// Null or empty checking
string? nullString = null;
nullString.IsNullEmpty(); // Returns true
"".IsNullEmpty(); // Returns true
"hello".IsNullEmpty(); // Returns false

// Null or whitespace checking
"   ".IsNullWhiteSpace(); // Returns true
"hello".IsNullWhiteSpace(); // Returns false

// Case-insensitive comparison
"hello".EqualsIgnoreCase("HELLO"); // Returns true
"hello".NotEqualsIgnoreCase("world"); // Returns true
```

### Case Conversion

Convert string case with null safety:

```csharp
// Lowercase conversion
"HELLO".Lower(); // Returns "hello"
"HELLO".LowerInvariant(); // Returns "hello" (culture-invariant)

// Uppercase conversion
"hello".Upper(); // Returns "HELLO"
"hello".UpperInvariant(); // Returns "HELLO" (culture-invariant)
```

### Character Operations

Work with individual characters:

```csharp
// Empty checking
default(char).IsEmpty(); // Returns true
'a'.IsEmpty(); // Returns false

// Whitespace checking
' '.IsWhiteSpace(); // Returns true
'a'.IsWhiteSpace(); // Returns false

// Character type checking
'a'.IsAlphabetic(); // Returns true
'5'.IsNumber(); // Returns true
'a'.IsAlphanumeric(); // Returns true
'.'.IsPunctuation(); // Returns true

// Case checking and conversion
'a'.IsLower(); // Returns true
'A'.IsUpper(); // Returns true
'A'.Lower(); // Returns 'a'
'a'.Upper(); // Returns 'A'
```

### Collection Operations

Process collections of strings or characters:

```csharp
// Check if all strings in a collection are null
new string?[] { null, null }.AllNull(); // Returns true

// Check if any strings in a collection are null or empty
new string?[] { "hello", null }.AnyNullEmpty(); // Returns true

// Check if all strings in a collection are equal (case-insensitive)
new string?[] { "hello", "HELLO" }.AllEqualsIgnoreCase(); // Returns true

// Convert all strings in a collection to lowercase
var strings = new List<string?> { "HELLO", "WORLD" };
strings.Lower(); // Modifies list to ["hello", "world"]

// Get a new collection with all strings in lowercase
var lowerStrings = new[] { "HELLO", "WORLD" }.Lowers(); // Returns ["hello", "world"]

// Apply text operations to collections
new[] { "hello world", "GOOD MORNING" }.Titles(); // Returns ["Hello World", "Good Morning"]
new[] { "  hello  world  ", " GOOD  MORNING " }.CleanSpaces(); // Returns ["hello world", "GOOD MORNING"]
```

### Nullable Character Support

Work safely with nullable characters:

```csharp
// Null checking
char? nullChar = null;
nullChar.IsNullEmpty(); // Returns true

// Character type checking with null safety
char? c = 'a';
c.IsAlphabetic(); // Returns true
nullChar.IsAlphabetic(); // Returns false

// Case conversion with null safety
char? upper = 'A';
upper.Lower(); // Returns 'a'
nullChar.Lower(); // Returns null
```


## Usage Examples

### Text Formatting

```csharp
public class TextFormatter
{
    public string FormatUserInput(string? input)
    {
        if (input.IsNullWhiteSpace())
        {
            return string.Empty;
        }

        // Clean up whitespace and capitalize
        return input.CleanSpace().Capitalize();
    }

    public string FormatUserName(string? firstName, string? lastName)
    {
        // Format and combine names
        var formattedFirst = firstName.FormatName();
        var formattedLast = lastName.FormatName();

        if (formattedFirst.IsNullWhiteSpace() && formattedLast.IsNullWhiteSpace())
        {
            return string.Empty;
        }
        else if (formattedFirst.IsNullWhiteSpace())
        {
            return formattedLast;
        }
        else if (formattedLast.IsNullWhiteSpace())
        {
            return formattedFirst;
        }
        else
        {
            return $"{formattedFirst} {formattedLast}";
        }
    }
}
```

### Input Validation

```csharp
public class InputValidator
{
    public bool IsValidUsername(string? username)
    {
        // Check if username is not null or whitespace
        if (username.IsNullWhiteSpace())
        {
            return false;
        }

        // Check if username contains only alphanumeric characters
        return username == username.FilterAlphanumeric();
    }

    public bool IsValidPhoneNumber(string? phoneNumber)
    {
        // Check if phone number is not null or whitespace
        if (phoneNumber.IsNullWhiteSpace())
        {
            return false;
        }

        // Extract only the digits
        var digits = phoneNumber.FilterNumber();

        // Check if we have the right number of digits
        return digits.Length >= 10;
    }
}
```

### Text Processing

```csharp
public class TextProcessor
{
    public IEnumerable<string> ProcessTextLines(IEnumerable<string?> lines)
    {
        // Skip null or whitespace lines
        var validLines = lines.Where(line => line.IsNotNullWhiteSpace());

        // Clean whitespace and convert to title case
        return validLines.Select(line => line.CleanSpace().Title());
    }

    public string ExtractLettersAndNumbers(string? input)
    {
        if (input.IsNullWhiteSpace())
        {
            return string.Empty;
        }

        // Extract only alphanumeric characters
        return input.FilterAlphanumeric();
    }
}
```

### Case-Insensitive Comparison

```csharp
public class TextComparer
{
    public bool AreAllStringsEqual(IEnumerable<string?> strings)
    {
        // Check if all strings are equal, ignoring case
        return strings.AllEqualsIgnoreCase();
    }

    public bool ContainsCaseInsensitive(IEnumerable<string?> collection, string? value)
    {
        if (collection == null || value.IsNullEmpty())
        {
            return false;
        }

        // Check if any string in the collection equals the value, ignoring case
        return collection.Any(item => item.EqualsIgnoreCase(value));
    }
}
```

### Character Analysis

```csharp
public class CharacterAnalyzer
{
    public bool IsPasswordComplex(string? password)
    {
        if (password.IsNullWhiteSpace())
        {
            return false;
        }

        // Check if password contains at least one uppercase letter
        bool hasUppercase = password.Any(c => c.IsUpper());

        // Check if password contains at least one lowercase letter
        bool hasLowercase = password.Any(c => c.IsLower());

        // Check if password contains at least one number
        bool hasNumber = password.Any(c => c.IsNumber());

        // Check if password contains at least one special character
        bool hasSpecial = password.Any(c => c.IsNotAlphanumeric());

        return hasUppercase && hasLowercase && hasNumber && hasSpecial;
    }

    public Dictionary<string, int> CountCharacterTypes(string? input)
    {
        var result = new Dictionary<string, int>
        {
            ["Uppercase"] = 0,
            ["Lowercase"] = 0,
            ["Digits"] = 0,
            ["Punctuation"] = 0,
            ["Whitespace"] = 0,
            ["Other"] = 0
        };

        if (input.IsNullEmpty())
        {
            return result;
        }

        foreach (var c in input)
        {
            if (c.IsUpper())
                result["Uppercase"]++;
            else if (c.IsLower())
                result["Lowercase"]++;
            else if (c.IsNumber())
                result["Digits"]++;
            else if (c.IsPunctuation())
                result["Punctuation"]++;
            else if (c.IsWhiteSpace())
                result["Whitespace"]++;
            else
                result["Other"]++;
        }

        return result;
    }
}
```

### Batch Text Processing

```csharp
public class BatchTextProcessor
{
    public List<string> NormalizeNames(List<string?> names)
    {
        // Remove null or empty names
        var validNames = names.Where(name => name.IsNotNullEmpty()).ToList();

        // Format all names
        validNames.FormatName();

        return validNames;
    }

    public List<string> ExtractDigitsFromTexts(List<string?> texts)
    {
        // Filter out null or empty texts
        var validTexts = texts.Where(text => text.IsNotNullEmpty()).ToList();

        // Extract only digits from each text
        return validTexts.Select(text => text.FilterNumber()).ToList();
    }
}
```

## Implementation Notes

- All methods handle null values gracefully, avoiding NullReferenceExceptions
- String operations preserve null values in collections
- Case conversion methods have both culture-specific and culture-invariant versions
- Collection operations have both in-place (modifying) and non-modifying versions
- Character operations support both regular and nullable characters
- All methods are implemented as extension methods for easy chaining
