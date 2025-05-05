### YANExpression Component

The `YANExpression` component is part of the YANLib library, providing powerful utilities for working with expression trees and dynamic property access in C#.


## Overview

YANExpression offers tools for creating and manipulating expression trees at runtime, enabling dynamic property access, lambda creation, and other expression-based operations. This component is particularly useful for scenarios where property names are only known at runtime, such as in dynamic queries, reflection alternatives, and data binding scenarios.


## Key Features

### Dynamic Property Access

The `PropertyExpression<T>` method creates strongly-typed expressions that access properties by name:

```csharp
// Create an expression that accesses the "Name" property of TestClass
var expression = YANExpression.PropertyExpression<TestClass>("p", "Name");

// Compile and use the expression
var func = expression.Compile();
var result = func(myTestClassInstance);
```


## Supported Types

YANExpression works with various property types:

- String properties
- Numeric properties (int, double, etc.)
- Boolean properties
- DateTime properties
- Custom object properties
- And more


## Performance Optimization

The component includes built-in caching to improve performance:

- Expressions are cached based on type and property name
- Repeated calls with the same parameters return the same expression instance
- This reduces the overhead of expression creation for frequently accessed properties


## Error Handling

YANExpression provides clear error messages for common issues:

- Null or whitespace parameter names
- Null or whitespace property names
- Non-existent properties on the target type


## Technical Details

### PropertyExpression Method

```csharp
public static Expression<Func<T, object>> PropertyExpression<T>(string parameterName, string propertyName)
```

**Parameters:**

- `parameterName`: The name of the parameter in the lambda expression
- `propertyName`: The name of the property to access


**Returns:**

- An expression of type `Expression<Func<T, object>>` that accesses the specified property


**Exceptions:**

- `ArgumentException`: Thrown when parameter name or property name is null or whitespace
- `ArgumentException`: Thrown when the property doesn't exist on the specified type


## Usage Examples

### Basic Property Access

Access a string property:

```csharp
// Define a class
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}

// Create an expression to access the Name property
var expression = YANExpression.PropertyExpression<User>("user", "Name");

// Compile the expression to a delegate
var getNameFunc = expression.Compile();

// Use the delegate
var user = new User { Name = "John Doe", Age = 30 };
string name = (string)getNameFunc(user); // Returns "John Doe"
```

### Working with Different Property Types

Access various property types:

```csharp
// Create expressions for different property types
var nameExpr = YANExpression.PropertyExpression<User>("u", "Name");
var ageExpr = YANExpression.PropertyExpression<User>("u", "Age");
var isActiveExpr = YANExpression.PropertyExpression<User>("u", "IsActive");
var createdDateExpr = YANExpression.PropertyExpression<User>("u", "CreatedDate");

// Compile the expressions
var getName = nameExpr.Compile();
var getAge = ageExpr.Compile();
var getIsActive = isActiveExpr.Compile();
var getCreatedDate = createdDateExpr.Compile();

// Use the compiled functions
var user = new User 
{
    Name = "Jane Smith",
    Age = 25,
    IsActive = true,
    CreatedDate = new DateTime(2023, 1, 15)
};

string name = (string)getName(user);           // "Jane Smith"
int age = (int)getAge(user);                   // 25
bool isActive = (bool)getIsActive(user);       // true
DateTime created = (DateTime)getCreatedDate(user); // 2023-01-15
```

### Dynamic Property Selection

Select properties dynamically at runtime:

```csharp
public object GetPropertyValue<T>(T obj, string propertyName)
{
    var expression = YANExpression.PropertyExpression<T>("x", propertyName);
    var func = expression.Compile();

    return func(obj);
}

// Usage
var user = new User { Name = "Alice", Age = 28 };

// Get property values by name
var nameValue = GetPropertyValue(user, "Name"); // Returns "Alice"
var ageValue = GetPropertyValue(user, "Age");   // Returns 28
```

### Building Dynamic Queries

Use with LINQ to create dynamic queries:

```csharp
public IQueryable<T> OrderBy<T>(IQueryable<T> source, string propertyName)
{
    var expression = YANExpression.PropertyExpression<T>("x", propertyName);

    return source.OrderBy(expression);
}

// Usage with Entity Framework or other LINQ providers
var users = dbContext.Users;
var orderedUsers = OrderBy(users, "LastName");
```

### Error Handling

Handle potential errors when working with dynamic properties:

```csharp
public object TryGetPropertyValue<T>(T obj, string propertyName)
{
    try
    {
        var expression = YANExpression.PropertyExpression<T>("x", propertyName);
        var func = expression.Compile();

        return func(obj);
    }
    catch (ArgumentException ex) when (ex.Message.Contains("does not contain a property named"))
    {
        Console.WriteLine($"Property '{propertyName}' does not exist on type {typeof(T).Name}");

        return null;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error accessing property: {ex.Message}");

        return null;
    }
}
```

### Leveraging Expression Caching

Take advantage of the built-in caching for performance:

```csharp
// These calls use the same cached expression
for (int i = 0; i < 1000; i++)
{
    var expr = YANExpression.PropertyExpression<User>("u", "Name");
    // Do something with expr
}
```


## Advanced Scenarios

### Creating Property Setters

While not directly shown in the tests, you could extend the pattern to create property setters:

```csharp
public static Action<T, TProperty> CreatePropertySetter<T, TProperty>(string propertyName)
{
    var parameter = Expression.Parameter(typeof(T), "x");
    var valueParameter = Expression.Parameter(typeof(TProperty), "value");
    
    var property = typeof(T).GetProperty(propertyName);

    if (property == null)
        throw new ArgumentException($"Type {typeof(T).Name} does not contain a property named {propertyName}");
        
    var propertyAccess = Expression.Property(parameter, property);
    var assign = Expression.Assign(propertyAccess, valueParameter);
    
    var lambda = Expression.Lambda<Action<T, TProperty>>(assign, parameter, valueParameter);
    
    return lambda.Compile();
}

// Usage
var setName = CreatePropertySetter<User, string>("Name");
var user = new User();
setName(user, "Robert"); // Sets user.Name to "Robert"
```

### Combining Multiple Expressions

Build more complex expressions by combining property expressions:

```csharp
public static Expression<Func<T, bool>> CreateEqualityPredicate<T>(string propertyName, object value)
{
    var parameter = Expression.Parameter(typeof(T), "x");
    var propertyExpr = YANExpression.PropertyExpression<T>("x", propertyName);
    
    // Extract the property access from the lambda body
    var propertyAccess = ((LambdaExpression)propertyExpr).Body;
    
    // Create a constant for the value
    var constant = Expression.Constant(value);
    
    // Create equality comparison
    var equality = Expression.Equal(propertyAccess, constant);
    
    // Create the final lambda
    return Expression.Lambda<Func<T, bool>>(equality, parameter);
}

// Usage
var predicate = CreateEqualityPredicate<User>("Age", 30);
var users = dbContext.Users.Where(predicate).ToList();
```
