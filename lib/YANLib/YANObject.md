### YANObject - Object Utility Library


## Overview

`YANObject` is a comprehensive utility library that provides extension methods for object operations and validations in C# applications. It offers a wide range of methods for checking null values, default values, property states, and manipulating objects and collections.


## Features

The library is organized into several functional categories:

### Basic Object Operations

- **Null Checking**: `IsNull` / `IsNotNull` were removed in 8.3.3 by mistake and are restored as obsolete shims in the next release; use `is null` / `is not null`
- **Default Value Checking**: Check if values match their type's default value
- **Null/Default Combined Checking**: Verify if objects are null or have default property values
- **Collection Emptiness**: Check if collections are null or empty

### Collection Operations

- **Null Checking**: Methods to check if all or any elements in a collection are null
- **Default Value Checking**: Determine if all or any elements have default values
- **Combined Checks**: Methods that combine null and default value checks for collections

### Property Operations

- **Property Default Checking**: Check if all or any properties of an object have default values
- **Property Selection**: Perform checks on specific named properties
- **Collection Property Checks**: Apply property checks across collections of objects

### Object Manipulation

- **Time Zone Conversion**: Change time zones for all DateTime properties in objects or collections
- **Object Copying**: Create shallow copies of objects


## Usage Examples

### Basic Object Operations

```csharp
// Null checking
object? obj = null;
bool isNull = obj is null;          // Returns true
bool isNotNull = obj is not null;   // Returns false
// IsNull()/IsNotNull() were removed in 8.3.3 by mistake and are restored as obsolete shims in the next release; use `is null` / `is not null`

// Default value checking
int value = 0;
bool isDefault = value.IsDefault();      // Returns true
bool isNotDefault = value.IsNotDefault(); // Returns false

// Combined null/default checking
TestClass? testObj = new TestClass();
bool isNullDefault = testObj.IsNullDefault();      // Returns true if null or all properties are default
bool isNotNullDefault = testObj.IsNotNullDefault(); // Returns true if not null and has non-default properties

// Collection emptiness
IEnumerable<int>? collection = new List<int>();
bool isNullEmpty = collection.IsNullEmpty();      // Returns true if null or empty
bool isNotNullEmpty = collection.IsNotNullEmpty(); // Returns true if not null and not empty
```

### Collection Operations

```csharp
// Check if all elements are null
IEnumerable<object?> collection = new object?[] { null, null, null };
bool allNull = collection.AllNull(); // Returns true

// Check if any element is null
IEnumerable<object?> mixedCollection = new object?[] { new object(), null, new object() };
bool anyNull = mixedCollection.AnyNull(); // Returns true

// Check if all elements are not null
IEnumerable<object?> nonNullCollection = new object?[] { new object(), new object(), new object() };
bool allNotNull = nonNullCollection.AllNotNull(); // Returns true

// Check if all elements have default values
IEnumerable<int> defaultCollection = new int[] { 0, 0, 0 };
bool allDefault = defaultCollection.AllDefault(); // Returns true

// Check if any element has a non-default value
IEnumerable<int> mixedDefaultCollection = new int[] { 0, 1, 0 };
bool anyNotDefault = mixedDefaultCollection.AnyNotDefault(); // Returns true
```

### Property Operations

```csharp
// Check if all properties have default values
var obj = new TestClass();
bool allPropsDefault = obj.AllPropertiesDefault(); // Returns true if all properties have default values

// Check if any property has a non-default value
var objWithValue = new TestClass { StringProperty = "test" };
bool anyPropNotDefault = objWithValue.AnyPropertiesNotDefault(); // Returns true

// Check specific properties
var objWithMixedValues = new TestClass { StringProperty = "test", IntProperty = 0 };
bool specificPropDefault = objWithMixedValues.AllPropertiesDefault(["IntProperty"]); // Returns true

// Check properties across a collection
IEnumerable<TestClass?> objCollection = new TestClass?[] 
{
    new TestClass { StringProperty = "test1" },
    new TestClass { StringProperty = "test2" }
};

bool allCollectionPropsNotDefault = objCollection.AllPropertiesNotDefaults(["StringProperty"]); // Returns true
```

### Object Manipulation

```csharp
// Change time zone for DateTime properties
var dateObj = new TestClass
{
    DateProperty = new DateTime(2023, 1, 1, 12, 0, 0, DateTimeKind.Utc),
    StringProperty = "test"
};

var convertedObj = dateObj.ChangeTimeZoneAllProperty(0, 7); // Convert from UTC to UTC+7

// Create a shallow copy of an object
var original = new TestClass
{
    DateProperty = new DateTime(2023, 1, 1),
    StringProperty = "test",
    IntProperty = 42
};

var copy = original.Copy(); // Creates a new instance with the same property values
```


## Property Rules

- **Which properties**: the property checks (`IsNullDefault`, `AllPropertiesDefault`, `AnyPropertiesNotDefault`, ...) use the public instance properties of the object's runtime type, inherited ones included. Indexers, write-only properties and by-ref-like (`Span<T>`) properties are skipped, and for a property hidden with `new` only the most-derived one is used.
- **Default values**: reference types (strings included) are default when `null`; value types are compared with `default(T)` (a struct's explicit parameterless constructor is not run).
- **Getters**: every selected getter is called; an exception thrown by a getter propagates (wrapped in `TargetInvocationException`).
- **Names**: the `names` overloads match property names case-sensitively. When none of the names matches a property, `AllPropertiesDefault`, `AllPropertiesNotDefault` and their collection versions return `false`.
- **Collections**: `AllPropertiesDefaults` / `AllPropertiesNotDefaults` return `false` when the collection contains a `null` element.
- **Field names**: `IsValidField<T>` checks the first space-separated token of the string against the public instance properties of `T`. A `null`, empty or whitespace string is never a valid field, so `IsNotValidField<T>` is always the opposite of `IsValidField<T>`, `AllValidFields` is `!AnyNotValidField` and `AnyValidField` is `!AllNotValidFields` for a non-empty sequence.

## Time Zone Conversion Rules

`ChangeTimeZoneAllProperty` (and `ChangeTimeZoneAllProperties` for each element) changes the object graph in place:

- Every object is converted at most once, so parent/child back-references and shared references are safe.
- Readable and writable properties are walked. `DateTime` and `DateTime?` values are converted and written back; a struct is walked and written back when something in it changed. No other property is written.
- A getter-only property is walked only when its declared type is an array, a list or a dictionary; the collection is converted in place.
- Lists and arrays of `DateTime` / `DateTime?`, and dictionaries with `DateTime` / `DateTime?` values (`IDictionary<TKey, DateTime>`), are converted when they are writable. Read-only ones (`ReadOnlyCollection<T>`, `ImmutableArray<T>`, `ReadOnlyDictionary<TKey, TValue>`, ...) are left unchanged. The elements of other lists (`IList`, e.g. `List<Order>`, `object[]`) are walked.
- Limitations: other collections (`HashSet<DateTime>`, `Queue<T>`, ...), multi-dimensional arrays and dictionary values that are not `DateTime` are left unchanged.
- Strings, primitives, enums, date/time/number types and non-data types (`Type` and other reflection objects, delegates, streams, tasks, threads, wait handles, cancellation tokens, safe handles, pointers) are not walked into.
- A property whose getter throws is skipped; an exception thrown by a setter propagates.

## Copy Rules

- For a class, `Copy()` creates an instance of the input's runtime type when it differs from `T` and has a public parameterless constructor (`Base b = new Derived(); b.Copy()` is a `Derived`), otherwise a new `T`. The readable and writable public instance properties of that type, inherited ones included and indexers excluded, are copied; reference values are shared (shallow copy).
- For a value type, `Copy()` returns the value itself (assigning a struct already copies all of its fields).

### Changes since 8.3.3

- Inherited properties are checked again: `new Derived { BaseName = "x" }.IsNullDefault()` is `false` (was `true`).
- Indexers and write-only properties are skipped: `new List<int>().IsNullDefault()` is `true` (threw `TargetParameterCountException`), a class with a write-only property no longer throws `ArgumentException`.
- Arrays expose the inherited `Rank` and `IsFixedSize`, so every array, even an empty one, is no longer null-default: `Array.Empty<int>().IsNullDefault()` is `false` (was `true`).
- Exception types expose the inherited `Message`: `new InvalidOperationException().IsNullDefault()` is `false` (was `true`).
- Inherited getters are called, so an inherited getter that throws now surfaces as a `TargetInvocationException`.
- A struct property is compared with `default(T)`, not with an instance built by its parameterless constructor.
- `AllPropertiesDefault(names)` (and `AllPropertiesDefaults(names)`, `AllPropertiesNotDefaults(names)`) return `false` when no name matches a property (were `true`).
- `AllPropertiesDefaults` / `AllPropertiesNotDefaults` return `false` for a collection that contains `null` (a `null` element satisfied both).
- `ChangeTimeZoneAllProperty` no longer throws for classes with an indexer (`TargetParameterCountException`), `Dictionary<TKey, DateTime>` properties (now converted), read-only lists such as `ReadOnlyCollection<DateTime>` (`NotSupportedException`, now left unchanged) or `Stream` properties (`MemoryStream.ReadTimeout`), and no longer crashes the process with a stack overflow on parent/child back-references.
- `ChangeTimeZoneAllProperty` converts an object reached through several references once (it was shifted once per reference), converts getter-only lists, arrays and dictionaries and `DateTime` items of `object` lists, skips throwing getters, and no longer calls the setters of properties it does not change.
- `Copy()`: `Base b = new Derived(); b.Copy()` returns a `Derived` copy (threw `TargetException`), classes with an indexer are copied (threw `TargetParameterCountException`), and a struct is copied by value (returned `default(T)`, e.g. `5.Copy()` was `0`).
- Blank field names are never valid again (as in 8.3.2): `["Name", null].AllValidFields<User>()` and `["Name", "  "].AllValidFields<User>()` are `false` (were `true`), `IsNotValidField` of `null` / `""` / whitespace is `true` (was `false`) and `["Name", null].AnyNotValidField<User>()` is `true` (was `false`).


## Performance Considerations

- The library caches the property list and the `default(T)` value of each type (thread-safe `ConcurrentDictionary`); property values are read through reflection on every call
- Collection methods such as `ChangeTimeZoneAllProperties` are lazily evaluated and preserve the input order
- The implementation uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience


## Implementation Details

- Extension methods are implemented in partial classes for better organization
- Internal implementation methods are separated from the public API
- The library uses nullable reference types for better null safety
- All public methods are well-documented with XML comments


## Object Operations Coverage

The library provides comprehensive coverage of object operations:

| Category | Functions |
|----------|-----------|
| **Null Checking** | IsNull, IsNotNull (obsolete shims: removed in 8.3.3 by mistake, restored in the next release; use `is null` / `is not null`) |
| **Default Value Checking** | IsDefault, IsNotDefault |
| **Combined Checking** | IsNullDefault, IsNotNullDefault |
| **Collection Checking** | IsNullEmpty, IsNotNullEmpty |
| **Collection Null Operations** | AllNull, AnyNull, AllNotNull, AnyNotNull |
| **Collection Default Operations** | AllDefault, AnyDefault, AllNotDefault, AnyNotDefault |
| **Collection Combined Operations** | AllNullDefault, AnyNullDefault, AllNotNullDefault, AnyNotNullDefault |
| **Field Validation** | IsValidField, AllValidFields, AnyValidField, IsNotValidField, AllNotValidFields, AnyNotValidField |
| **Property Operations** | AllPropertiesDefault, AnyPropertiesDefault, AllPropertiesNotDefault, AnyPropertiesNotDefault |
| **Collection Property Operations** | AllPropertiesDefaults, AnyPropertiesDefaults, AllPropertiesNotDefaults, AnyPropertiesNotDefaults |
| **Object Manipulation** | ChangeTimeZoneAllProperty, Copy |


## Technical Details

- **Reflection Usage**: Uses reflection to access and evaluate object properties
- **Property Caching**: Implements caching of property information to improve performance
- **Default Value Comparison**: Uses `EqualityComparer<T>.Default` for type-safe default value comparison
- **Null Propagation**: Implements null-safe property access throughout the API
- **Collection Processing**: Processes collections of objects with property evaluation
- **DateTime Handling**: Includes specialized handling for DateTime properties
- **Object Copying**: Implements shallow copying of objects using reflection
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
- **Memory Efficiency**: Optimizes reflection operations to minimize memory allocations
