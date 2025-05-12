### YANExpression - Expression Building Utility Library


## Overview

`YANExpression` is a specialized utility library that simplifies working with expressions in C# applications. It provides methods for creating and manipulating strongly-typed expressions, particularly focused on property access. The library is designed to improve performance through expression caching while providing a clean, type-safe API for reflection-based operations.


## Features

The library offers several key capabilities:

### Expression Building

- **Property Access**: Create strongly-typed expressions for accessing properties on objects
- **Type Safety**: Generate expressions with proper type information
- **Value Type Handling**: Automatic boxing of value types to object
- **Method Access**: Support for accessing methods on objects

### Performance Optimization

- **Expression Caching**: Automatically cache generated expressions for better performance
- **Reuse**: Efficiently reuse expressions for the same property across multiple calls
- **Minimal Overhead**: Reduce the cost of reflection-based property access

### Error Handling

- **Validation**: Thorough validation of parameter and property names
- **Descriptive Errors**: Clear error messages for troubleshooting
- **Null Safety**: Proper handling of null inputs


## Usage Examples

### Basic Property Expression Creation

```csharp
// Create a property expression for accessing the Name property on a Person object
var expression = YANExpression.PropertyExpression<Person>("p", "Name");

// Compile and use the expression
var func = expression.Compile();
var person = new Person { Name = "John", Age = 30 };
string name = (string)func(person); // Returns "John"

// Create an expression for a numeric property
var ageExpression = YANExpression.PropertyExpression<Person>("p", "Age");
var ageFunc = ageExpression.Compile();
int age = (int)ageFunc(person); // Returns 30
```

### Working with Different Property Types

```csharp
// Create expressions for various property types
var person = new Person
{
    Name = "Alice",
    Age = 25,
    IsActive = true,
    CreatedDate = new DateTime(2023, 1, 15)
};

// String property
var nameExpr = YANExpression.PropertyExpression<Person>("p", "Name");
var nameFunc = nameExpr.Compile();
string name = (string)nameFunc(person); // Returns "Alice"

// Integer property
var ageExpr = YANExpression.PropertyExpression<Person>("p", "Age");
var ageFunc = ageExpr.Compile();
int age = (int)ageFunc(person); // Returns 25

// Boolean property
var activeExpr = YANExpression.PropertyExpression<Person>("p", "IsActive");
var activeFunc = activeExpr.Compile();
bool isActive = (bool)activeFunc(person); // Returns true

// DateTime property
var dateExpr = YANExpression.PropertyExpression<Person>("p", "CreatedDate");
var dateFunc = dateExpr.Compile();
DateTime date = (DateTime)dateFunc(person); // Returns 2023-01-15
```

### Using Expressions with Collections

```csharp
// Create a list of people
var people = new List<Person>
{
    new Person { Name = "John", Age = 30 },
    new Person { Name = "Alice", Age = 25 },
    new Person { Name = "Bob", Age = 35 }
};

// Create a property expression for the Name property
var nameExpr = YANExpression.PropertyExpression<Person>("p", "Name");
var nameFunc = nameExpr.Compile();

// Use the expression with LINQ to extract all names
var names = people.Select(p => nameFunc(p)).Cast<string>().ToList();
// names contains ["John", "Alice", "Bob"]

// Create a property expression for the Age property
var ageExpr = YANExpression.PropertyExpression<Person>("p", "Age");
var ageFunc = ageExpr.Compile();

// Use the expression with LINQ to find people older than 30
var olderPeople = people.Where(p => (int)ageFunc(p) > 30).ToList();
// olderPeople contains the Person with Name="Bob", Age=35
```

### Advanced Usage Examples

```csharp
// Create a dynamic property accessor
public object GetPropertyValue<T>(T obj, string propertyName)
{
    var expr = YANExpression.PropertyExpression<T>("x", propertyName);
    var func = expr.Compile();

    return func(obj);
}

// Use the dynamic accessor
var person = new Person { Name = "John", Age = 30 };
string name = (string)GetPropertyValue(person, "Name"); // Returns "John"
int age = (int)GetPropertyValue(person, "Age"); // Returns 30

// Create a generic property setter using expressions
public void SetPropertyValue<T, TValue>(T obj, string propertyName, TValue value)
{
    // Note: This example shows how you might extend YANExpression
    // The current implementation only supports property getters
    var parameter = Expression.Parameter(typeof(T), "x");
    var property = Expression.Property(parameter, propertyName);
    var valueParameter = Expression.Parameter(typeof(TValue), "value");
    var convertedValue = Expression.Convert(valueParameter, property.Type);
    var assign = Expression.Assign(property, convertedValue);
    var lambda = Expression.Lambda<Action<T, TValue>>(assign, parameter, valueParameter);
    var setter = lambda.Compile();

    setter(obj, value);
}

// Use the property setter
var anotherPerson = new Person();

SetPropertyValue(anotherPerson, "Name", "Alice");
SetPropertyValue(anotherPerson, "Age", 25);
// anotherPerson now has Name="Alice" and Age=25
```

### Error Handling Examples

```csharp
// Handle invalid parameter name
try
{
    var expr = YANExpression.PropertyExpression<Person>("", "Name");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // "Parameter name cannot be null or whitespace."
}

// Handle invalid property name
try
{
    var expr = YANExpression.PropertyExpression<Person>("p", "");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // "Property name cannot be null or whitespace."
}

// Handle non-existent property
try
{
    var expr = YANExpression.PropertyExpression<Person>("p", "Address");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // "Type Person does not contain a property named 'Address'."
}
```

### Caching Demonstration

```csharp
// Demonstrate expression caching
var expr1 = YANExpression.PropertyExpression<Person>("p", "Name");
var expr2 = YANExpression.PropertyExpression<Person>("p", "Name");
var expr3 = YANExpression.PropertyExpression<Person>("x", "Name");

// expr1 and expr2 reference the same cached expression
bool areSameInstance = object.ReferenceEquals(expr1, expr2); // Returns true

// expr3 uses a different parameter name, so it's a different expression
bool areDifferentInstances = object.ReferenceEquals(expr1, expr3); // Returns false

// Different types with the same property name use different expressions
var customerExpr = YANExpression.PropertyExpression<Customer>("p", "Name");
bool areDifferentTypes = object.ReferenceEquals(expr1, customerExpr); // Returns false
```


## Performance Considerations

- **Expression Caching**: The library automatically caches expressions based on the type and property name, significantly improving performance for repeated access to the same property
- **Compilation Cost**: Expression compilation is relatively expensive, but the caching mechanism ensures this cost is paid only once per type/property combination
- **Memory Usage**: Cached expressions are stored in a `ConcurrentDictionary`, which uses memory proportional to the number of unique type/property combinations
- **Thread Safety**: The caching mechanism is thread-safe, using `ConcurrentDictionary` for concurrent access
- **Debugging Support**: Uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience


## Implementation Details

- **Expression Trees**: Uses the Expression API from `System.Linq.Expressions` to build property access expressions
- **Caching Strategy**: Uses a `ConcurrentDictionary<(Type Type, string PropertyName), LambdaExpression>` for thread-safe caching
- **Value Type Handling**: Automatically converts value types to `object` using `Expression.Convert`
- **Reflection**: Uses reflection to verify property existence and access property information
- **Error Handling**: Provides detailed error messages for common issues like null/empty names or non-existent properties


## Expression Operations Coverage

The library provides focused coverage of expression operations:

| Category | Functions |
|----------|-----------|
| **Property Access** | PropertyExpression<T> |
| **Expression Caching** | Internal caching mechanism for compiled expressions |
| **Type Conversion** | Automatic boxing/unboxing for value types |
| **Error Handling** | Validation for parameter and property names |


## Technical Details

- **Expression Building**: Uses `System.Linq.Expressions` to dynamically build property access expressions at runtime
- **Expression Caching**: Implements a thread-safe caching mechanism using `ConcurrentDictionary<(Type Type, string PropertyName), LambdaExpression>` to store and reuse compiled expressions
- **Cache Key Structure**: Uses a tuple of `(Type, string)` combining the object type and property name as the cache key
- **Parameter Naming**: Supports custom parameter names in expressions (e.g., `p => p.PropertyName` vs `x => x.PropertyName`)
- **Type Handling**: Automatically handles boxing/unboxing for value types when converting to/from `object`
- **Property Validation**: Performs validation to ensure properties exist on the target type before building expressions
- **Reflection Usage**: Uses reflection only for initial property discovery, then relies on compiled expressions for performance
- **Thread Safety**: All operations are thread-safe, allowing concurrent access from multiple threads
- **Memory Management**: Efficiently manages memory by sharing compiled expressions across multiple calls
