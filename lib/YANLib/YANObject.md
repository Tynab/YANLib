### YANObject Component

The `YANObject` component is part of the YANLib library, providing a comprehensive set of utility methods for object manipulation, validation, and analysis.


## Overview

YANObject offers an extensive collection of extension methods for working with objects and collections. It provides convenient ways to check for null or default values, analyze object properties, work with collections, and perform operations like copying objects or changing time zones for DateTime properties.


## Key Features

### Null and Default Value Checking

Easily check if objects are null or have default values:

```csharp
// Null checking
bool isNull = someObject.IsNull();       // Returns true if object is null
bool isNotNull = someObject.IsNotNull(); // Returns true if object is not null

// Default value checking
bool isDefault = someValue.IsDefault();       // Returns true if value equals default(T)
bool isNotDefault = someValue.IsNotDefault(); // Returns true if value doesn't equal default(T)

// Combined checks
bool isNullOrDefault = someObject.IsNullDefault();       // Returns true if null or all properties have default values
bool isNotNullOrDefault = someObject.IsNotNullDefault(); // Returns true if not null and has at least one non-default property

// Collection emptiness checking
bool isNullOrEmpty = someCollection.IsNullEmpty();       // Returns true if collection is null or empty
bool isNotNullOrEmpty = someCollection.IsNotNullEmpty(); // Returns true if collection is not null and not empty
```

### Property Analysis

Analyze object properties to check if they have default or non-default values:

```csharp
// Check if all properties have default values
bool allDefault = myObject.AllPropertiesDefault();

// Check if all properties have non-default values
bool allNonDefault = myObject.AllPropertiesNotDefault();

// Check if any property has a default value
bool anyDefault = myObject.AnyPropertiesDefault();

// Check if any property has a non-default value
bool anyNonDefault = myObject.AnyPropertiesNotDefault();

// Check specific properties only
bool specificPropsDefault = myObject.AllPropertiesDefault(["PropertyName1", "PropertyName2"]);
```

### Collection Operations

Perform checks on collections of objects:

```csharp
// Check if all items in a collection are null
bool allNull = myCollection.AllNull();

// Check if any item in a collection is null
bool anyNull = myCollection.AnyNull();

// Check if all items in a collection are not null
bool allNotNull = myCollection.AllNotNull();

// Check if any item in a collection is not null
bool anyNotNull = myCollection.AnyNotNull();

// Similar methods for default values
bool allDefault = myCollection.AllDefault();
bool anyDefault = myCollection.AnyDefault();
bool allNotDefault = myCollection.AllNotDefault();
bool anyNotDefault = myCollection.AnyNotDefault();

// Combined null and default checks for collections
bool allNullOrDefault = myCollection.AllNullDefault();
bool anyNullOrDefault = myCollection.AnyNullDefault();
bool allNotNullOrDefault = myCollection.AllNotNullDefault();
bool anyNotNullOrDefault = myCollection.AnyNotNullDefault();

// Property checks for collections
bool allPropsDefault = myCollection.AllPropertiesDefaults();
bool allPropsNotDefault = myCollection.AllPropertiesNotDefaults();
bool anyPropsDefault = myCollection.AnyPropertiesDefaults();
bool anyPropsNotDefault = myCollection.AnyPropertiesNotDefaults();
```

### Object Manipulation

Perform operations on objects:

```csharp
// Create a deep copy of an object
MyClass copy = myObject.Copy();

// Change time zone for all DateTime properties in an object
var convertedObject = myObject.ChangeTimeZoneAllProperty(0, 7); // Convert from UTC to UTC+7

// Change time zone for all DateTime properties in a collection of objects
var convertedCollection = myCollection.ChangeTimeZoneAllProperties(0, 7);
```


## Usage Examples

### Basic Object Validation

```csharp
public void ProcessOrder(Order order)
{
    // Check if order is null
    if (order.IsNull())
    {
        throw new ArgumentNullException(nameof(order));
    }

    // Check if order has any non-default properties
    if (!order.AnyPropertiesNotDefault())
    {
        throw new ArgumentException("Order must have at least one property set", nameof(order));
    }

    // Process the order...
}
```

### Working with Collections

```csharp
public void ProcessOrders(List<Order> orders)
{
    // Check if orders collection is null or empty
    if (orders.IsNullEmpty())
    {
        throw new ArgumentException("Orders cannot be null or empty", nameof(orders));
    }

    // Check if all orders have required properties set
    if (!orders.AllPropertiesNotDefaults(["CustomerId", "OrderDate", "TotalAmount"]))
    {
        throw new ArgumentException("All orders must have customer ID, date, and amount", nameof(orders));
    }

    // Process valid orders...
}
```

### Data Validation

```csharp
public bool IsValidCustomer(Customer customer)
{
    // Customer must not be null and must have all required properties set
    return customer.IsNotNull() && 
           !customer.AnyPropertiesDefault(["Name", "Email", "PhoneNumber"]);
}
```

### Time Zone Conversion

```csharp
public void ConvertOrderTimesToLocalTimeZone(Order order)
{
    // Convert all DateTime properties from UTC to local time zone (e.g., UTC+7)
    var localOrder = order.ChangeTimeZoneAllProperty(0, 7);
    
    // Now all DateTime properties (OrderDate, ShipDate, etc.) are in local time
    DisplayOrder(localOrder);
}
```

### Batch Processing with Filtering

```csharp
public List<Product> GetActiveProducts(List<Product> products)
{
    // Filter out null or default products
    return products
        .Where(p => p.IsNotNullDefault())
        .ToList();
}
```

### Object Copying

```csharp
public Order CreateOrderCopy(Order originalOrder)
{
    // Create a deep copy of the order
    var orderCopy = originalOrder.Copy();
    
    // Modify some properties of the copy
    orderCopy.OrderId = Guid.NewGuid();
    orderCopy.OrderDate = DateTime.UtcNow;
    
    return orderCopy;
}
```

### Conditional Processing

```csharp
public void ProcessPayment(Payment payment)
{
    // Different processing based on payment properties
    if (payment.AllPropertiesDefault(["CreditCardInfo"]) && 
        payment.AllPropertiesNotDefault(["BankTransferInfo"]))
    {
        ProcessBankTransfer(payment);
    }
    else if (payment.AllPropertiesDefault(["BankTransferInfo"]) && 
             payment.AllPropertiesNotDefault(["CreditCardInfo"]))
    {
        ProcessCreditCard(payment);
    }
    else
    {
        throw new ArgumentException("Invalid payment information");
    }
}
```

### Collection Analysis

```csharp
public string GetCollectionStatus(List<Task> tasks)
{
    if (tasks.AllNull())
        return "All tasks are null";
        
    if (tasks.AnyNull())
        return "Some tasks are null";
        
    if (tasks.AllPropertiesDefaults())
        return "All tasks are empty";
        
    if (tasks.AllPropertiesNotDefaults(["CompletedDate"]))
        return "All tasks are completed";
        
    if (tasks.AnyPropertiesNotDefaults(["CompletedDate"]))
        return "Some tasks are completed";
        
    return "No tasks are completed";
}
```
