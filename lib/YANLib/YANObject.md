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
- **Getters**: the getters are called one property at a time until the result is known, so the getters after the deciding property are not called (`new User { Name = "x" }.IsNullDefault()` can stop at `Name`). An exception thrown by a getter that is called propagates (wrapped in `TargetInvocationException`), so whether a throwing getter surfaces depends on the property values and order.
- **Names**: the `names` overloads match property names case-sensitively. When none of the names matches a property, `AllPropertiesDefault`, `AllPropertiesNotDefault` and their collection versions return `false`.
- **Collections**: `AllPropertiesDefaults` / `AllPropertiesNotDefaults` return `false` when the collection contains a `null` element.
- **Field names**: `IsValidField<T>` checks the first space-separated token of the string against the readable, non-indexer public instance properties of `T` (inherited ones included), case-insensitively with an exact match preferred, the same lookup as `YANExpression.PropertyExpression`. A `null`, empty or whitespace string is never a valid field, so `IsNotValidField<T>` is always the opposite of `IsValidField<T>`, `AllValidFields` is `!AnyNotValidField` and `AnyValidField` is `!AllNotValidFields` for a non-empty sequence.


## Time Zone Conversion Rules

`ChangeTimeZoneAllProperty` (and `ChangeTimeZoneAllProperties` for each element) changes the object graph in place:

- Every object (class instance) is converted at most once, so parent/child back-references and shared references are safe. Items reached through `ArraySegment<T>` values are the exception: an array reachable both directly and through a segment over it, or through overlapping segments, has its `DateTime` items, boxed `DateTime` items and struct items converted once per path (class items are still converted once).
- Readable and writable public instance properties are walked, inherited ones included and indexers excluded; a base property hidden with `new` by a property of another type is walked too (as in 8.3.3). `DateTime` and `DateTime?` values are converted and written back; a struct is walked and written back when something in it changed. No other property is written.
- A getter-only property is walked only when its declared type is an array, list or dictionary type, either a class (`DateTime[]`, `List<T>`, `Dictionary<TKey, TValue>`, a class deriving from them) or an interface (`IList<T>`, `IDictionary<TKey, TValue>`, `IList`, `IDictionary`), and its value is not a struct; the collection is converted in place. A getter-only struct value (`ArraySegment<T>`, `ImmutableArray<T>`, ..., even behind an `IList<T>` property) and a getter-only property declared as another interface (`IReadOnlyList<T>`, `ICollection<T>`, `IEnumerable<T>`, ...) are not walked.
- Lists and arrays of `DateTime` / `DateTime?`, and dictionaries with `DateTime` / `DateTime?` values (`IDictionary<TKey, DateTime>`), are converted when they are writable. Read-only ones (`ReadOnlyCollection<T>`, `ImmutableArray<T>`, `ReadOnlyDictionary<TKey, TValue>`, ...) are left unchanged. The elements of other lists (`IList`, e.g. `List<Order>`, `object[]`) are walked.
- An `ArraySegment<T>` is handled like an array holding only the segment's items: they are converted or walked (and written back) in the underlying array, and the items outside the segment are left alone.
- Limitations: other collections (`HashSet<DateTime>`, `Queue<T>`, ...), multi-dimensional arrays and dictionary values that are not `DateTime` are left unchanged.
- Strings, primitives, enums, date/time/number types and non-data types (`Type` and other reflection objects, delegates, streams, tasks, threads, wait handles, cancellation tokens, safe handles, pointers) are not walked into. A `Lazy<T>` value is not walked and the walk never reads its `Value` (as in 8.3.3), so a `Lazy<T>` property does not run its factory; a class deriving from `Lazy<T>` has its own properties walked. A getter-only list property whose own getter reads a lazy value (`public List<DateTime> Dates => _lazy.Value;`) is still called by the walk (getter-only rule above), so that lazy factory runs during the walk (8.3.3 did not call getter-only properties).
- A property whose getter throws is skipped; an exception thrown by a setter propagates.
- Class instances are walked from a work list, not recursively, so the depth of the graph (a long linked list, a deep tree) is not limited by the call stack. Each object's own properties are converted first, then the objects it references, in property / item order, depth first. A graph that never ends, such as a getter that returns a new object on every call whose type leads back to itself, is walked until memory runs out.


## Copy Rules

- For a class, `Copy()` creates an instance of the input's runtime type when it differs from `T` and has a public parameterless constructor (`Base b = new Derived(); b.Copy()` is a `Derived`), otherwise a new `T`. The readable and writable public instance properties of that type, inherited ones included and indexers excluded, are copied; a base property hidden with `new` by a property of another type is copied too (as in 8.3.3). Reference values are shared (shallow copy).
- Only properties are copied, so the items of a collection type (`List<T>`, `Dictionary<TKey, TValue>`, a class deriving from `List<T>`, ...) are not: `new List<int> { 1, 2 }.Copy()` is an empty list.
- When the copy is an instance of the runtime type, its public parameterless constructor runs; an exception thrown by it surfaces as `TargetInvocationException`.
- For a value type, `Copy()` returns the value itself (assigning a struct already copies all of its fields); a boxed struct passed as `object` is returned in a new box.


## Changes since 8.3.3

- Inherited properties are now checked (8.3.3 and earlier releases ignored them, so this is new rather than a fix of an 8.3.3 regression): `new Derived { BaseName = "x" }.IsNullDefault()` is `false` (was `true`).
- Indexers and write-only properties are skipped: `new List<int>().IsNullDefault()` is `true` (threw `TargetParameterCountException`), a class with a write-only property no longer throws `ArgumentException`.
- Arrays expose the inherited `Rank` and `IsFixedSize`, so every array, even an empty one, is no longer null-default: `Array.Empty<int>().IsNullDefault()` is `false` (was `true`).
- Exception types expose the inherited `Message`: `new InvalidOperationException().IsNullDefault()` is `false` (was `true`).
- Inherited getters are called, so an inherited getter that throws can now surface as a `TargetInvocationException`.
- A struct property is compared with `default(T)`, not with an instance built by its parameterless constructor.
- `AllPropertiesDefault(names)` (and `AllPropertiesDefaults(names)`, `AllPropertiesNotDefaults(names)`) return `false` when no name matches a property (were `true`).
- `AllPropertiesDefaults` / `AllPropertiesNotDefaults` return `false` for a collection that contains `null` (a `null` element satisfied both).
- `ChangeTimeZoneAllProperties` is eager: `people.ChangeTimeZoneAllProperties(0, 7);` with the result ignored converted nothing, and enumerating the lazy result twice (`r.Count(); r.ToList();`) shifted the objects twice (+14 h). It now converts once, in input order, before returning an array, and an object listed twice or shared by several elements is converted once.
- `ChangeTimeZoneAllProperty` no longer throws for classes with an indexer (`TargetParameterCountException`), `Dictionary<TKey, DateTime>` properties (now converted), read-only lists such as `ReadOnlyCollection<DateTime>` (`NotSupportedException`, now left unchanged), non-empty multi-dimensional arrays such as `DateTime[,]` (`ArgumentException`, now left unchanged) or `Stream` properties (`MemoryStream.ReadTimeout`), and no longer crashes the process with a stack overflow on parent/child back-references.
- `ChangeTimeZoneAllProperty` converts `DateTime?` items of lists and arrays (`List<DateTime?>`, `DateTime?[]`, as properties or as the input itself), which 8.3.3 left unchanged, and `ArraySegment<DateTime?>` items (8.3.3 threw `TargetParameterCountException`).
- `ChangeTimeZoneAllProperty` walks the items inside an `ArraySegment<T>` of other items (`ArraySegment<Order>`, `ArraySegment<object>`, struct items), as a property or as the input itself, and leaves the rest of the underlying array alone (8.3.3 threw `TargetParameterCountException`).
- `ChangeTimeZoneAllProperty` converts an object reached through several references once (it was shifted once per reference), converts getter-only lists, arrays and dictionaries and `DateTime` items of `object` lists, skips throwing getters, and no longer calls the setters of properties it does not change.
- `ChangeTimeZoneAllProperty` and `ChangeTimeZoneAllProperties` no longer recurse into class instances, so deep graphs are converted at any depth (measured with a Release build and a node class with a `DateTime` and a `Next` property: 8.3.3 crashed the process with a stack overflow on a 3 000-node linked list on a thread with a 1 MB stack and on a 30 000-node one on the main thread with an 8 MB stack; a 1 000 000-node list is now converted). Each object's own properties are now converted before the objects it references (8.3.3 walked a referenced object as soon as it read the property), so when a setter throws, a different set of objects may already be converted. A graph that never ends, such as a writable property whose getter returns a new object on every call whose type leads back to itself, now runs until memory runs out instead of crashing the process with a stack overflow. The same holds for a getter-only list property that builds new objects of that kind on every call (a view over a cyclic model), for which 8.3.3 returned normally because it skipped getter-only properties.
- `Copy()`: `Base b = new Derived(); b.Copy()` returns a `Derived` copy made with `Derived`'s public parameterless constructor (8.3.3 threw `TargetException` when `Derived` adds a settable property, and otherwise returned a `Base` without running that constructor; an exception thrown by it now surfaces as `TargetInvocationException`). Classes with an indexer are copied (threw `TargetParameterCountException`), but only their settable properties: the items of a list or dictionary are not copied (`new List<int> { 1, 2 }.Copy()` is an empty list). A struct is copied by value (returned `default(T)`, e.g. `5.Copy()` was `0`), and a boxed struct passed as `object` is copied (threw `TargetException`).
- `IsValidField` no longer throws `AmbiguousMatchException` for a property hidden with `new`, and the indexer `Item` and write-only properties are no longer valid fields.
- Blank field names are never valid again (as in 8.3.2): `["Name", null].AllValidFields<User>()` and `["Name", "  "].AllValidFields<User>()` are `false` (were `true`), `IsNotValidField` of `null` / `""` / whitespace is `true` (was `false`) and `["Name", null].AnyNotValidField<User>()` is `true` (was `false`).


## Performance Considerations

- The library caches the property list and the `default(T)` value of each type (thread-safe `ConcurrentDictionary`); property values are read through reflection on every call
- `ChangeTimeZoneAllProperties` runs eagerly and sequentially: it enumerates the input once, converts every element in input order before returning, and returns the elements as a new array (enumerating the result again does not convert anything again)
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
