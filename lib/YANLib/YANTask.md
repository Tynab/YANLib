### YANTask - Asynchronous Task Utility Library

## Overview

`YANTask` is a specialized utility library that extends the functionality of the Task Parallel Library (TPL) in C#. It provides powerful extension methods for working with asynchronous tasks, particularly for filtering and processing task results based on conditions. The library simplifies complex asynchronous operations such as waiting for tasks that satisfy specific conditions and processing multiple matching results from concurrent operations.

## Features

The library is organized into several functional categories:

### Conditional Task Waiting

- **Single Result Filtering**: Wait for any task that completes and satisfies a specified condition
- **Multiple Result Filtering**: Asynchronously enumerate tasks that complete and satisfy a condition
- **Completion Strategies**: Options for waiting until first match or until all tasks complete
- **Result Limiting**: Ability to limit the number of matching results returned


### Asynchronous Enumeration

- **Async Streams**: Support for modern C# async streams (IAsyncEnumerable)
- **Lazy Evaluation**: Results are yielded as soon as they become available
- **Cancellation Support**: Full support for cancellation tokens to stop operations


### Error Handling

- **Exception Safety**: Graceful handling of tasks that throw exceptions
- **Null Safety**: Proper handling of null task collections
- **Cancellation Handling**: Clean response to cancellation requests


## Usage Examples

### Waiting for a Single Task with Condition

```csharp
// Wait for any task that returns a value greater than 5
var tasks = new[]
{
    Task.FromResult(3),
    Task.FromResult(7),
    Task.FromResult(2),
    Task.FromResult(10)
};

// Using WaitAnyWithCondition - returns as soon as it finds a match
int? result = await tasks.WaitAnyWithCondition(x => x > 5);
Console.WriteLine(result); // Output: 7

// Using WhenAnyWithCondition - waits for tasks to complete until it finds a match
int? anotherResult = await tasks.WhenAnyWithCondition(x => x > 8);
Console.WriteLine(anotherResult); // Output: 10
```

### Handling Tasks with Exceptions

```csharp
// Create a collection of tasks, including one that throws an exception
var tasksWithException = new[]
{
    Task.FromResult(3),
    Task.FromException<int>(new InvalidOperationException("Task failed")),
    Task.FromResult(7),
    Task.FromResult(10)
};

// Exception is handled gracefully, skipped and doesn't affect the result
int? result = await tasksWithException.WaitAnyWithCondition(x => x > 5);
Console.WriteLine(result); // Output: 7
```

### Using Cancellation Tokens

```csharp
// Create a cancellation token source
var cts = new CancellationTokenSource();

// Create a collection of delayed tasks
var delayedTasks = new[]
{
    Task.Delay(1000).ContinueWith(_ => 1),
    Task.Delay(2000).ContinueWith(_ => 5),
    Task.Delay(3000).ContinueWith(_ => 10)
};

try
{
    // Start the operation and cancel it immediately
    cts.Cancel();
    int? result = await delayedTasks.WaitAnyWithCondition(x => x > 5, cts.Token);
    
    // This line won't be reached if cancellation occurs
    Console.WriteLine(result);
}
catch (TaskCanceledException)
{
    Console.WriteLine("Operation was canceled");
}
```

### Asynchronous Enumeration of Multiple Results

```csharp
// Create a collection of tasks
var tasks = new[]
{
    Task.FromResult(3),
    Task.FromResult(7),
    Task.FromResult(2),
    Task.FromResult(10),
    Task.FromResult(15)
};

// Using WaitAnyWithConditions to get all values greater than 5
await foreach (var item in tasks.WaitAnyWithConditions(x => x > 5))
{
    Console.WriteLine(item); // Output: 7, 10, 15 (order may vary)
}

// Using WhenAnyWithConditions with a limit on the number of results
await foreach (var item in tasks.WhenAnyWithConditions(x => x > 5, taken: 2))
{
    Console.WriteLine(item); // Output: Only the first 2 matching results
}
```

### Working with Delayed Tasks

```csharp
// Create a collection of tasks with different delays
var delayedTasks = new[]
{
    Task.Delay(300).ContinueWith(_ => 3),
    Task.Delay(100).ContinueWith(_ => 7),
    Task.Delay(200).ContinueWith(_ => 2),
    Task.Delay(50).ContinueWith(_ => 10)
};

// Wait for the first task that completes and satisfies the condition
int? fastResult = await delayedTasks.WaitAnyWithCondition(x => x > 5);
Console.WriteLine(fastResult); // Output: 10 (the fastest task with value > 5)

// Enumerate all tasks that complete and satisfy the condition
await foreach (var item in delayedTasks.WaitAnyWithConditions(x => x > 5))
{
    Console.WriteLine(item); // Output: 10, 7 (in order of completion)
}
```

### Advanced Usage Examples

```csharp
// Create a collection of tasks that simulate API calls
var apiTasks = new[]
{
    SimulateApiCall(1, 200), // ID: 1, Delay: 200ms
    SimulateApiCall(2, 150), // ID: 2, Delay: 150ms
    SimulateApiCall(3, 300), // ID: 3, Delay: 300ms
    SimulateApiCall(4, 100), // ID: 4, Delay: 100ms
    SimulateApiCall(5, 250)  // ID: 5, Delay: 250ms
};

// Wait for the first successful API response (status code 200)
var firstSuccess = await apiTasks.WaitAnyWithCondition(response => response.StatusCode == 200);
Console.WriteLine($"First successful response: ID {firstSuccess?.Id}");

// Get all successful API responses as they complete
await foreach (var response in apiTasks.WaitAnyWithConditions(r => r.StatusCode == 200))
{
    Console.WriteLine($"Successful response: ID {response.Id}, Time: {DateTime.Now}");
}

// Simulate an API call that returns after a delay
async Task<ApiResponse> SimulateApiCall(int id, int delayMs)
{
    await Task.Delay(delayMs);
    return new ApiResponse { Id = id, StatusCode = id % 2 == 0 ? 200 : 404 };
}

class ApiResponse
{
    public int Id { get; set; }
    public int StatusCode { get; set; }
}
```

### Combining with Other Async Operations

```csharp
// Create a collection of tasks that read data from different sources
var dataTasks = new[]
{
    ReadFromDatabaseAsync(),
    ReadFromApiAsync(),
    ReadFromCacheAsync(),
    ReadFromFileAsync()
};

// Wait for the first non-empty result
var firstData = await dataTasks.WaitAnyWithCondition(data => data != null && data.Length > 0);
Console.WriteLine($"First data source returned {firstData?.Length} bytes");

// Process all data sources that return valid data
await foreach (var data in dataTasks.WhenAnyWithConditions(d => d != null && d.Length > 0))
{
    Console.WriteLine($"Processing {data.Length} bytes of data");
    await ProcessDataAsync(data);
}

// Simulate reading from different data sources
async Task<byte[]> ReadFromDatabaseAsync() => await Task.Delay(200).ContinueWith(_ => new byte[100]);
async Task<byte[]> ReadFromApiAsync() => await Task.Delay(150).ContinueWith(_ => new byte[0]);
async Task<byte[]> ReadFromCacheAsync() => await Task.Delay(50).ContinueWith(_ => new byte[200]);
async Task<byte[]> ReadFromFileAsync() => await Task.Delay(300).ContinueWith(_ => new byte[150]);
async Task ProcessDataAsync(byte[] data) => await Task.Delay(10);
```

## Performance Considerations

- **Early Completion**: `WaitAnyWithCondition` and `WaitAnyWithConditions` return as soon as matching tasks are found, without waiting for other tasks
- **Lazy Enumeration**: Results are yielded as soon as they become available, without waiting for all tasks to complete
- **Exception Handling**: Tasks that throw exceptions are gracefully skipped without affecting other tasks
- **Cancellation Support**: Operations can be canceled at any time using cancellation tokens
- **Memory Efficiency**: Uses `IAsyncEnumerable` for memory-efficient processing of large task collections
- **Debugging Support**: Uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience


## Implementation Details

- **Extension Methods**: All operations are implemented as extension methods for better integration with existing code
- **Async/Await Pattern**: Fully embraces the modern async/await pattern for asynchronous programming
- **Task Tracking**: Uses a `HashSet<Task<T>>` to efficiently track pending tasks
- **Null Safety**: All methods handle null inputs gracefully, returning appropriate default values
- **Internal Implementation**: Core implementation details are separated from the public API for better maintainability


## Task Operations Coverage

The library provides focused coverage of conditional task operations:

| Category | Functions |
|----------|-----------|
| **Single Result Filtering** | WaitAnyWithCondition<T>, WhenAnyWithCondition<T> |
| **Multiple Results Filtering** | WaitAnyWithConditions<T>, WhenAnyWithConditions<T> |
| **Cancellation Support** | All methods support CancellationToken |
| **Result Limiting** | Support for limiting the number of results with 'taken' parameter |
| **Utility Functions** | AsyncEnumerableEmpty<T> |


## Technical Details

- **Task Tracking**: Uses a `HashSet<Task<T>>` to efficiently track pending tasks and avoid duplicate processing
- **Asynchronous Implementation**: Uses `async/await` pattern throughout for non-blocking operations
- **Condition Evaluation**: Evaluates task results against provided predicates as tasks complete
- **Task Completion Detection**: Uses `Task.WhenAny` to detect when individual tasks complete
- **Result Collection**: Implements `IAsyncEnumerable<T>` for lazy, asynchronous enumeration of results
- **Exception Handling**: Catches and suppresses exceptions from individual tasks to prevent operation failure
- **Cancellation Support**: Implements cancellation token support throughout the API for responsive cancellation
- **Memory Management**: Efficiently manages memory by removing completed tasks from the tracking set
- **Task Completion Strategies**: Implements both "wait for any" and "when any" strategies for different use cases
