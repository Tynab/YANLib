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
- Readable and writable public instance properties are walked, inherited ones included and indexers excluded; a base property hidden with `new` by a property of another type is walked too (as in 8.3.3). `DateTime` and `DateTime?` values are converted and written back. Any other value that is walked (an object or a struct) is written back with the property's setter when a `DateTime` was converted somewhere inside it, once everything reachable from it has been walked and before the next property is read, as in 8.3.3. So a property whose getter returns a copy (a defensive copy such as `get => _dates.ToList()`, a computed wrapper, a JSON-backed object) receives the converted copy, and a later property that this setter writes (a DTO or wrapper over the owner's own `DateTime` properties) is read, and converted, after the setter has run. State that is reachable through two paths is converted once per path. As in 8.3.3, a copy getter over an object or field that is also reachable through a writable property or through a second copy getter, or a wrapper `Period { get => new() { Start = Start, End = End }; set { Start = value.Start; End = value.End; } }` declared next to the `Start` and `End` it copies, shifts that state twice. Two such cases are new (see Changes since 8.3.3): a field exposed both by a getter-only list, array or dictionary property (walked by the getter-only rule below) and by a writable copy getter, such as `List<DateTime> View => _d;` next to `List<DateTime> Copy { get => _d.ToList(); set => _d = value; }` in either order, is shifted twice where 8.3.3 shifted it once; and a dictionary or `IList<DateTime?>` type whose own writable property holds the collection behind its interface (`IList<DateTime?>` implemented over `public List<DateTime?> Backing { get; set; }`) has those values converted through the interface and again through that property. No other setter is called: not for strings, numbers or other values that are not walked, not for a value in which nothing was converted, and not for a second reference to an object already converted. (A struct item of a read-only list, such as `ReadOnlyCollection<MyStruct>`, is converted in a copy that is then discarded, but it still counts as converted, so the setter of a property holding that list is called with the unchanged list.) Along the path to a converted `DateTime`, ordinary properties are therefore set again with the object they already hold.
- A getter-only property is walked only when its declared type is an array, list or dictionary type, either a class (`DateTime[]`, `List<T>`, `Dictionary<TKey, TValue>`, a class deriving from them) or an interface (`IList<T>`, `IDictionary<TKey, TValue>`, `IList`, `IDictionary`), and its value is not a struct; the collection is converted in place. A getter-only struct value (`ArraySegment<T>`, `ImmutableArray<T>`, ..., even behind an `IList<T>` property) and a getter-only property declared as another interface (`IReadOnlyList<T>`, `ICollection<T>`, `IEnumerable<T>`, ...) are not walked.
- Lists and arrays of `DateTime` / `DateTime?`, and dictionaries with `DateTime` / `DateTime?` values (`IDictionary<TKey, DateTime>`), are converted when they are writable. Read-only ones (`ReadOnlyCollection<T>`, `ImmutableArray<T>`, `ReadOnlyDictionary<TKey, TValue>`, ...) are left unchanged. The elements of other lists (`IList`, e.g. `List<Order>`, `object[]`) are walked, and an element in which a `DateTime` was converted is written back into a writable list (`list[i] = element`, which raises a `Replace` event on an `ObservableCollection<T>`), as in 8.3.3. A type that implements `IDictionary<TKey, DateTime>` / `IDictionary<TKey, DateTime?>`, or `IList<DateTime?>` without the non-generic `IList` (an explicit interface implementation, a `ReadOnlyDictionary<TKey, DateTime>` subclass, ...), has its values or items converted as above and then its own readable and writable properties walked, as 8.3.3 did for such a type without a public settable indexer (for a `Dictionary<TKey, DateTime>` subclass 8.3.3 threw `TargetParameterCountException`); its getter-only properties are not walked, not even a getter-only list or dictionary, since they can be views of the values just converted. A type that implements `IList<DateTime>` without `IList` has only its items converted, as in 8.3.3.
- An `ArraySegment<T>` is handled like an array holding only the segment's items: they are converted or walked in the underlying array (a struct item is written back into it), and the items outside the segment are left alone.
- Limitations: other collections (`HashSet<DateTime>`, `Queue<T>`, ...), multi-dimensional arrays and dictionary values that are not `DateTime` are left unchanged.
- Strings, primitives, enums, date/time/number types and non-data types (`Type` and other reflection objects, delegates, streams, text readers and writers (`TextReader`, `TextWriter`: `StringWriter`, `StreamReader`, ...), tasks, threads, wait handles, cancellation tokens and their sources, safe handles, pointers) are not walked into. Neither is a class deriving from one of these types, so the `DateTime` properties it declares itself (`class LogWriter : StringWriter { public DateTime Started { get; set; } }`, `class Job : CancellationTokenSource`, `class Work : Task`) are left unchanged, as the input, as a property value or as a list item (see Changes since 8.3.3). A `Lazy<T>` value is not walked and the walk never reads its `Value` (as in 8.3.3), so a `Lazy<T>` property does not run its factory; a class deriving from `Lazy<T>` has its own properties walked. A getter-only list property whose own getter reads a lazy value (`public List<DateTime> Dates => _lazy.Value;`) is still called by the walk (getter-only rule above), so that lazy factory runs during the walk (8.3.3 did not call getter-only properties).
- A property whose getter throws is skipped; an exception thrown by a setter propagates.
- Objects and structs are walked from a work list, not recursively, so the depth of the graph (a long linked list, a deep tree, a chain of structs) is not limited by the call stack. The order is that of 8.3.3: depth first, in property / item order; a value found in a property or an item is walked, and written back (rules above), before the next property or item of its owner is read. The getter calls on a list differ slightly: each item of a list of objects (`IList`) is read once (8.3.3 read each non-null item twice, to test it for `null` and to walk it), and the walk also reads the list's `IsReadOnly` before its items and its `Count` once more than 8.3.3 did (before the items of an `IList`, after those of an `IList<DateTime>`). This is visible only through a custom list whose getters have side effects; the converted values are the same. The work list holds one entry per level of the path being walked, not one per list item. A graph that never ends, such as a getter that returns a new object on every call whose type leads back to itself, is walked until memory runs out.


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
- `ChangeTimeZoneAllProperty` converts an object reached through several references once (it was shifted once per reference), converts getter-only lists, arrays and dictionaries and `DateTime` items of `object` lists, and skips throwing getters. It calls fewer setters: 8.3.3 set every readable and writable property that held a non-null value (strings, numbers, objects with nothing to convert, a second reference to a shared object) and every non-null item of a list (a read-only one such as a non-empty `ReadOnlyCollection<Order>` threw `NotSupportedException`; its items are now converted in place), so a setter that rejects every write (for example on a read-only `CultureInfo` property) failed the walk with `TargetInvocationException` and every item of an `ObservableCollection<T>` raised a `Replace` event. Now a property or a writable-list item is set only when it holds a `DateTime` or a value in which a `DateTime` was converted (see the rules above), still after that value has been walked; a property whose getter returns a copy still receives the converted copy.
- `ChangeTimeZoneAllProperty` and `ChangeTimeZoneAllProperties` no longer recurse into class instances or structs, so deep graphs are converted at any depth (measured with Release builds: with a node class holding a `DateTime` and a `Next` property, 8.3.3 crashed the process with a stack overflow on a 3 000-node linked list on a thread with a 1 MB stack and on a 30 000-node one on the main thread with an 8 MB stack; with a struct holding a `DateTime` and an `object`- or interface-typed `Next` property, it crashed at about 2 150 levels on a 1 MB stack and about 17 400 on the 8 MB main thread; a 1 000 000-node list and a 1 000 000-level struct chain are now converted on both). Properties and items are still read, converted and written back in 8.3.3's order (a referenced object is walked, and written back, as soon as its property is read); only the getter calls on a list differ: an item of an `IList` is read once instead of twice, and the list's `IsReadOnly` and one more `Count` are read (see the rules above). The walk now keeps every object and struct it walks until it returns (see Performance Considerations). A graph that never ends, such as a writable property whose getter returns a new object on every call whose type leads back to itself, now runs until memory runs out instead of crashing the process with a stack overflow. The same holds for a getter-only list property that builds new objects of that kind on every call (a view over a cyclic model), for which 8.3.3 returned normally because it skipped getter-only properties.
- `ChangeTimeZoneAllProperty` converts the values of a writable type that implements `IDictionary<TKey, DateTime>` / `IDictionary<TKey, DateTime?>` through an explicit interface implementation and the `DateTime?` items of a type that implements only `IList<DateTime?>`, which 8.3.3 left unchanged; as in 8.3.3, the readable and writable properties of these types, and of a `ReadOnlyDictionary<TKey, DateTime>` subclass (whose values stay unchanged), are walked too. When such a type keeps those values in a collection that one of its own writable properties also returns (`IList<DateTime?>` implemented over `public List<DateTime?> Backing { get; set; }`), they are converted twice, once through the interface and once through that property (`(0, 7)` turns 10:00 into 00:00 the next day; 8.3.3 left such `DateTime?` items at 10:00, and threw `TargetParameterCountException` for a `Dictionary<TKey, DateTime>` held that way).
- `ChangeTimeZoneAllProperty` shifts twice a field exposed both by a getter-only list, array or dictionary property and by a writable property whose getter returns a copy of it, such as a CA2227-style DTO with `public List<DateTime> View => _d;` and `public List<DateTime> Copy { get => _d.ToList(); set => _d = value; }`, in either declaration order: the getter-only property is now converted in place, and the copy getter then returns a copy of the converted values, which is converted again and written back. With `(0, 7)`, 10:00 becomes 00:00 the next day (+14 h); 8.3.3 did not read the getter-only property and gave 17:00 (+7 h).
- `ChangeTimeZoneAllProperty` leaves unchanged the `DateTime` properties of classes deriving from the non-data framework types it does not walk into (reflection types, delegates, `Stream`, `TextReader` / `TextWriter`, `Task`, `WaitHandle`, `Thread`, `CancellationTokenSource`, `SafeHandle`), as the input, as a property value or as a list item: `class LogWriter : StringWriter { public DateTime Started { get; set; } }`, `class Job : CancellationTokenSource { public DateTime Due { get; set; } }` and `class Work : Task { public DateTime Due { get; set; } }` keep their values, which 8.3.3 converted.
- `Copy()`: `Base b = new Derived(); b.Copy()` returns a `Derived` copy made with `Derived`'s public parameterless constructor (8.3.3 threw `TargetException` when `Derived` adds a settable property, and otherwise returned a `Base` without running that constructor; an exception thrown by it now surfaces as `TargetInvocationException`). Classes with an indexer are copied (threw `TargetParameterCountException`), but only their settable properties: the items of a list or dictionary are not copied (`new List<int> { 1, 2 }.Copy()` is an empty list). A struct is copied by value (returned `default(T)`, e.g. `5.Copy()` was `0`), and a boxed struct passed as `object` is copied (threw `TargetException`).
- `IsValidField` no longer throws `AmbiguousMatchException` for a property hidden with `new`, and the indexer `Item` and write-only properties are no longer valid fields.
- Blank field names are never valid again (as in 8.3.2): `["Name", null].AllValidFields<User>()` and `["Name", "  "].AllValidFields<User>()` are `false` (were `true`), `IsNotValidField` of `null` / `""` / whitespace is `true` (was `false`) and `["Name", null].AnyNotValidField<User>()` is `true` (was `false`).


## Performance Considerations

- The library caches the property list and the `default(T)` value of each type (thread-safe `ConcurrentDictionary`); property values are read through reflection on every call
- `ChangeTimeZoneAllProperty` (and `ChangeTimeZoneAllProperties`, for the whole call) keeps every object and struct it walks in a set until it returns, so that each object is converted once, plus one work-list entry per level of the path being walked. Measured with Release builds on a list of 3 000 000 small items holding one `DateTime` each: a peak working set of about 464 MB for class items and 381 MB for struct items (8.3.3, which kept no such set: 307 MB and 188 MB); both completed under a 384 MB GC heap hard limit (`DOTNET_GCHeapHardLimit`)
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
