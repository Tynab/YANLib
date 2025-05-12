### YANEnumerable - Collection Conversion Utility Library


## Overview

`YANEnumerable` is a versatile utility library that provides extension methods for converting collections of objects to strongly-typed collections in C# applications. It offers a comprehensive set of methods for transforming generic and non-generic collections into arrays, lists, hash sets, dictionaries, lookups, and immutable collections of specific types.


## Features

The library is organized into several functional categories:

### Basic Collection Conversion

- **Array Conversion**: Convert collections to strongly-typed arrays
- **List Conversion**: Transform collections into strongly-typed lists
- **HashSet Conversion**: Create strongly-typed hash sets from collections
- **Type Parsing**: Automatically parse elements to the specified type during conversion

### Dictionary and Lookup Conversion

- **Dictionary Creation**: Convert collections to dictionaries with typed keys and values
- **Lookup Creation**: Transform collections into lookups with typed keys and elements
- **Key/Value Selection**: Extract and convert keys and values from source elements

### Immutable Collection Support

- **Immutable Arrays**: Convert collections to immutable arrays
- **Immutable Lists**: Transform collections into immutable lists
- **Immutable HashSets**: Create immutable hash sets from collections
- **Immutable Dictionaries**: Convert collections to immutable dictionaries
- **Immutable Stacks/Queues**: Transform collections into immutable stacks or queues
- **Immutable Sorted Collections**: Create immutable sorted sets and dictionaries

### Collection Source Support

- **Generic Collections**: Convert from `IEnumerable<object?>` sources
- **Non-Generic Collections**: Transform from `IEnumerable` sources
- **Array Parameters**: Convert from params arrays of objects
- **Null Handling**: Proper handling of null collections and null elements


## Usage Examples

### Basic Collection Conversion

```csharp
// Convert collection of objects to array of integers
IEnumerable<object?> input = ["1", "2", "3"];
int[] result = input.ToArray<int>(); // Returns [1, 2, 3]

// Convert mixed types with parsing
IEnumerable<object?> mixedInput = ["1", 2, "3.5"];
int[] mixedResult = mixedInput.ToArray<int>(); // Returns [1, 2, 3]

// Convert using params array
int[] paramsResult = YANEnumerable.ToArray<int>("1", 2, "3.5"); // Returns [1, 2, 3]

// Convert from non-generic collection
System.Collections.ArrayList arrayList = ["1", 2, "3.5"];
int[] nonGenericResult = arrayList.ToArray<int>(); // Returns [1, 2, 3]

// Convert to List<T>
List<int> listResult = input.ToList<int>(); // Returns List with [1, 2, 3]

// Convert to HashSet<T>
HashSet<int> hashSetResult = input.ToHashSet<int>(); // Returns HashSet with [1, 2, 3]
```

### Dictionary and Lookup Conversion

```csharp
// Create a test class for demonstration
class TestItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

// Convert collection to dictionary
IEnumerable<object?> items = [
    new TestItem { Id = 1, Name = "Item1" },
    new TestItem { Id = 2, Name = "Item2" },
    new TestItem { Id = 3, Name = "Item3" }
];

// Convert to Dictionary<int, string?>
Dictionary<int, string?> dict = items.ToDictionary<TestItem, int, string?, int, string?>(
    item => item.Id,      // Key selector
    item => item.Name     // Value selector
);
// Returns {1: "Item1", 2: "Item2", 3: "Item3"}

// Convert to Lookup<int, string?>
ILookup<int?, string?> lookup = items.ToLookup<TestItem, int, string?, int, string?>(
    item => item.Id,      // Key selector
    item => item.Name     // Value selector
);
// Returns lookup with keys [1, 2, 3] and corresponding values
```

### Immutable Collection Conversion

```csharp
// Convert to ImmutableArray<T>
IEnumerable<object?> input = ["1", "2", "3"];
ImmutableArray<int> immutableArray = input.ToImmutableArray<int>(); // Returns ImmutableArray with [1, 2, 3]

// Convert to ImmutableList<T>
ImmutableList<int> immutableList = input.ToImmutableList<int>(); // Returns ImmutableList with [1, 2, 3]

// Convert to ImmutableHashSet<T>
ImmutableHashSet<int> immutableHashSet = input.ToImmutableHashSet<int>(); // Returns ImmutableHashSet with [1, 2, 3]

// Convert to ImmutableStack<T>
ImmutableStack<int> immutableStack = input.ToImmutableStack<int>(); 
// Returns ImmutableStack with 3 at the top, then 2, then 1

// Convert to ImmutableQueue<T>
ImmutableQueue<int> immutableQueue = input.ToImmutableQueue<int>();
// Returns ImmutableQueue with 1 at the front, then 2, then 3

// Convert to ImmutableSortedSet<T>
IEnumerable<object?> unsortedInput = ["3", "1", "2"];
ImmutableSortedSet<int> immutableSortedSet = unsortedInput.ToImmutableSortedSet<int>();
// Returns ImmutableSortedSet with [1, 2, 3]

// Convert to ImmutableDictionary<TKey, TValue>
IEnumerable<object?> items = [
    new TestItem { Id = 1, Name = "Item1" },
    new TestItem { Id = 2, Name = "Item2" },
    new TestItem { Id = 3, Name = "Item3" }
];

ImmutableDictionary<int, string?> immutableDict = items.ToImmutableDictionary<TestItem, int, string?, int, string?>(
    item => item.Id,      // Key selector
    item => item.Name     // Value selector
);
// Returns ImmutableDictionary with {1: "Item1", 2: "Item2", 3: "Item3"}

// Convert to ImmutableSortedDictionary<TKey, TValue>
ImmutableSortedDictionary<int, string?> immutableSortedDict = items.ToImmutableSortedDictionary<TestItem, int, string?, int, string?>(
    item => item.Id,      // Key selector
    item => item.Name     // Value selector
);
// Returns ImmutableSortedDictionary with {1: "Item1", 2: "Item2", 3: "Item3"} in key order
```

### Handling Null and Empty Collections

```csharp
// Handle null input for arrays
IEnumerable<object?>? nullInput = null;
int[] nullResult = nullInput.ToArray<int>(); // Returns empty array []

// Handle null input for lists
List<int> nullListResult = nullInput.ToList<int>(); // Returns empty list []

// Handle null input for hash sets
HashSet<int> nullHashSetResult = nullInput.ToHashSet<int>(); // Returns empty hash set []

// Handle null input for immutable collections
ImmutableArray<int> nullImmutableArray = nullInput.ToImmutableArray<int>(); // Returns empty immutable array
ImmutableList<int> nullImmutableList = nullInput.ToImmutableList<int>(); // Returns empty immutable list
```

### Handling Mixed Types and Null Elements

```csharp
// Handle mixed types with parsing
IEnumerable<object?> mixedInput = ["1", 2, "3.5", "not a number"];
int[] mixedResult = mixedInput.ToArray<int>(); // Returns [1, 2, 3, 0]

// Handle null elements in string conversion
IEnumerable<object?> inputWithNulls = ["1", null, "3"];
string?[] stringResult = inputWithNulls.ToArray<string>(); // Returns ["1", null, "3"]

// Handle duplicate values in hash sets
IEnumerable<object?> duplicates = ["1", "1", 1, "2"];
HashSet<int> hashSetResult = duplicates.ToHashSet<int>(); // Returns HashSet with [1, 2]
```

## Performance Considerations

- The library uses optimized implementations for different collection types
- Type conversion is performed efficiently with minimal overhead
- The implementation uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience
- Collection operations are designed to minimize memory allocations where possible


## Implementation Details

- Extension methods are implemented in partial classes for better organization
- Internal implementation methods are separated from the public API
- The library uses nullable reference types for better null safety
- All public methods are well-documented with XML comments
- Type conversion logic handles edge cases gracefully


## Collection Conversion Coverage

The library provides comprehensive coverage of collection conversion operations:

| Category | Functions |
|----------|-----------|
| **Array Conversion** | ToArray<T> |
| **List Conversion** | ToList<T> |
| **HashSet Conversion** | ToHashSet<T> |
| **Dictionary Conversion** | ToDictionary<TSource, TKey, TValue, TKeyResult, TValueResult> |
| **Lookup Conversion** | ToLookup<TSource, TKey, TElement, TKeyResult, TElementResult> |
| **Immutable Array** | ToImmutableArray<T> |
| **Immutable List** | ToImmutableList<T> |
| **Immutable HashSet** | ToImmutableHashSet<T> |
| **Immutable Dictionary** | ToImmutableDictionary<TSource, TKey, TValue, TKeyResult, TValueResult> |
| **Immutable SortedDictionary** | ToImmutableSortedDictionary<TSource, TKey, TValue, TKeyResult, TValueResult> |
| **Immutable SortedSet** | ToImmutableSortedSet<T> |
| **Immutable Stack** | ToImmutableStack<T> |
| **Immutable Queue** | ToImmutableQueue<T> |
| **Non-Generic Collection Support** | Extension methods for IEnumerable |
| **Params Array Support** | Static methods with params object[] parameters |


## Technical Details

- **Collection Conversion**: Implements specialized methods for converting between collection types
- **Type Conversion**: Uses `Convert.ChangeType()` and custom parsing for type conversion during collection processing
- **LINQ Integration**: Builds upon LINQ methods for efficient collection processing
- **Immutable Collection Support**: Integrates with `System.Collections.Immutable` for immutable collection types
- **Dictionary Key Generation**: Implements key selection and validation for dictionary conversion
- **Duplicate Key Handling**: Includes strategies for handling duplicate keys in dictionary conversion
- **Null Element Handling**: Properly processes null elements during collection conversion
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
- **Memory Efficiency**: Optimizes collection operations to minimize memory allocations
