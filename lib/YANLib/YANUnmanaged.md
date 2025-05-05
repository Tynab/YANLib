### YANUnmanaged Component

The `YANUnmanaged` component is part of the YANLib library, providing a comprehensive set of utilities for parsing and converting unmanaged types in .NET applications.


## Overview

YANUnmanaged offers a robust set of extension methods for parsing objects into various unmanaged types (such as int, double, DateTime, Guid, enum, etc.) with built-in error handling, format support, and collection operations. It provides a consistent API for working with both non-nullable and nullable types, making it easier to handle data conversion in a type-safe manner.


## Key Features

### Object Parsing

Parse objects into various types with built-in error handling:

```csharp
// Parse string to int with default value
object input = "123";
int result = input.Parse<int>(); // Returns 123

// Handle invalid input with default value
object invalidInput = "not a number";
int resultWithDefault = invalidInput.Parse<int>(42); // Returns 42

// Parse to various types
double doubleResult = "123.45".Parse<double>(); // Returns 123.45
DateTime dateResult = "2023-06-15".Parse<DateTime>(); // Returns DateTime(2023, 6, 15)
DayOfWeek enumResult = "Tuesday".Parse<DayOfWeek>(); // Returns DayOfWeek.Tuesday
bool boolResult = "true".Parse<bool>(); // Returns true
char charResult = "A".Parse<char>(); // Returns 'A'
Guid guidResult = someGuidString.Parse<Guid>(); // Returns parsed Guid
```

### Nullable Type Parsing

Parse objects into nullable types, returning null for invalid inputs:

```csharp
// Parse string to nullable int
object input = "123";
int? result = input.Parse<int?>(); // Returns 123

// Return null for invalid input
object invalidInput = "not a number";
int? nullableResult = invalidInput.Parse<int?>(); // Returns null

// Handle null input
object? nullInput = null;
int? nullResult = nullInput.Parse<int?>(); // Returns null

// Parse to various nullable types
DateTime? dateResult = "2023-06-15".Parse<DateTime?>(); // Returns DateTime(2023, 6, 15)
DayOfWeek? enumResult = "Tuesday".Parse<DayOfWeek?>(); // Returns DayOfWeek.Tuesday
bool? boolResult = "true".Parse<bool?>(); // Returns true
```

### Collection Parsing

Parse collections of objects into typed collections:

```csharp
// Parse collection of strings to ints
var input = new object[] { "123", "456", "789" };
IEnumerable<int> results = input.Parses<int>(); // Returns [123, 456, 789]

// Handle invalid values with default
var mixedInput = new object[] { "123", "not a number", "789" };
IEnumerable<int> mixedResults = mixedInput.Parses<int>(42); // Returns [123, 42, 789]

// Parse to various types
IEnumerable<DateTime> dateResults = new[] { "2023-06-15", "2023-07-20" }.Parses<DateTime>();
IEnumerable<DayOfWeek> enumResults = new[] { "Monday", "Tuesday" }.Parses<DayOfWeek>();
IEnumerable<bool> boolResults = new[] { "true", "false" }.Parses<bool>();
```

### Nullable Collection Parsing

Parse collections of objects into collections of nullable types:

```csharp
// Parse collection of strings to nullable ints
var input = new object[] { "123", "456", "789" };
IEnumerable<int?> results = input.Parses<int?>(); // Returns [123, 456, 789]

// Return null for invalid values
var mixedInput = new object[] { "123", "not a number", "789" };
IEnumerable<int?> mixedResults = mixedInput.Parses<int?>(); // Returns [123, null, 789]

// Handle null values
var inputWithNull = new object[] { "123", null, "789" };
IEnumerable<int?> resultsWithNull = inputWithNull.Parses<int?>(); // Returns [123, null, 789]
```

### Format Support

Parse date and time values with custom formats:

```csharp
// Parse date with specific format
object dateInput = "15/06/2023";
DateTime result = dateInput.Parse<DateTime>(default, "dd/MM/yyyy"); // Returns DateTime(2023, 6, 15)

// Parse collection of dates with specific format
var dates = new object[] { "15/06/2023", "20/07/2023", "25/12/2023" };
IEnumerable<DateTime> results = dates.Parses<DateTime>(default, "dd/MM/yyyy");
```


## Usage Examples

### Data Import and Validation

```csharp
public class DataImporter
{
    public List<Product> ImportProducts(IEnumerable<Dictionary<string, object>> rawData)
    {
        var products = new List<Product>();
        
        foreach (var item in rawData)
        {
            var product = new Product
            {
                Id = item.TryGetValue("id", out var id) ? id.Parse<int>(-1) : -1,
                Name = item.TryGetValue("name", out var name) ? name?.ToString() : string.Empty,
                Price = item.TryGetValue("price", out var price) ? price.Parse<decimal>(0) : 0,
                IsAvailable = item.TryGetValue("available", out var available) ? available.Parse<bool>(false) : false,
                CreatedDate = item.TryGetValue("created", out var created) ? created.Parse<DateTime>(DateTime.Now) : DateTime.Now
            };
            
            // Only add valid products
            if (product.Id > 0 && !string.IsNullOrEmpty(product.Name))
            {
                products.Add(product);
            }
        }
        
        return products;
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreatedDate { get; set; }
}
```

### Configuration Parser

```csharp
public class ConfigurationParser
{
    private readonly Dictionary<string, object> _configValues;
    
    public ConfigurationParser(Dictionary<string, object> configValues)
    {
        _configValues = configValues;
    }
    
    public T GetValue<T>(string key, T defaultValue = default)
    {
        if (_configValues.TryGetValue(key, out var value))
        {
            return value.Parse<T>(defaultValue);
        }
        
        return defaultValue;
    }
    
    public T? GetNullableValue<T>(string key) where T : struct
    {
        if (_configValues.TryGetValue(key, out var value))
        {
            return value.Parse<T?>();
        }
        
        return null;
    }
    
    public IEnumerable<T> GetValues<T>(string key, T defaultValue = default)
    {
        if (_configValues.TryGetValue(key, out var value) && value is IEnumerable<object> values)
        {
            return values.Parses<T>(defaultValue);
        }
        
        return Enumerable.Empty<T>();
    }
}
```

### CSV Data Processing

```csharp
public class CsvProcessor
{
    public IEnumerable<T> ProcessCsv<T>(string csvContent, Func<string[], T> rowMapper)
    {
        var lines = csvContent.Split('\n');
        
        foreach (var line in lines.Skip(1)) // Skip header
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;
                
            var columns = line.Split(',');
            yield return rowMapper(columns);
        }
    }
    
    public IEnumerable<SalesRecord> ProcessSalesData(string csvContent)
    {
        return ProcessCsv(csvContent, columns => new SalesRecord
        {
            OrderId = columns[0].Parse<int>(),
            ProductId = columns[1].Parse<int>(),
            Quantity = columns[2].Parse<int>(),
            UnitPrice = columns[3].Parse<decimal>(),
            OrderDate = columns[4].Parse<DateTime>(DateTime.Now, "yyyy-MM-dd")
        });
    }
}

public class SalesRecord
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
```

### API Response Handling

```csharp
public class ApiClient
{
    private readonly HttpClient _httpClient;
    
    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(content);
            
            return new ApiResponse<T>
            {
                Success = data.TryGetValue("success", out var success) && success.Parse<bool>(),
                Data = data.TryGetValue("data", out var value) ? value.Parse<T>() : default,
                Timestamp = data.TryGetValue("timestamp", out var timestamp) 
                    ? timestamp.Parse<DateTime>(DateTime.Now) 
                    : DateTime.Now
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
}

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Error { get; set; }
    public DateTime Timestamp { get; set; }
}
```

### Form Data Processing

```csharp
public class FormProcessor
{
    public UserProfile ProcessUserForm(Dictionary<string, string> formData)
    {
        return new UserProfile
        {
            UserId = formData.TryGetValue("userId", out var id) ? id.Parse<int>(-1) : -1,
            Name = formData.TryGetValue("name", out var name) ? name : string.Empty,
            BirthDate = formData.TryGetValue("birthDate", out var birthDate) 
                ? birthDate.Parse<DateTime?>(null, "yyyy-MM-dd") 
                : null,
            PreferredCategories = formData.TryGetValue("categories", out var categories)
                ? categories.Split(',').Parses<int>()
                : Enumerable.Empty<int>(),
            IsSubscribed = formData.TryGetValue("isSubscribed", out var subscribed) 
                ? subscribed.Parse<bool>() 
                : false
        };
    }
}

public class UserProfile
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public IEnumerable<int> PreferredCategories { get; set; } = Enumerable.Empty<int>();
    public bool IsSubscribed { get; set; }
}
```


## Implementation Notes

- All parsing methods handle null values gracefully, avoiding NullReferenceExceptions
- Invalid inputs return either default values or null (for nullable types)
- Collection methods preserve the structure of the input collection
- Format support is available for types that require it (like DateTime)
- Case-insensitive parsing is supported for enums
- All methods are implemented as extension methods for easy chaining
- Empty strings and whitespace are treated as invalid inputs
