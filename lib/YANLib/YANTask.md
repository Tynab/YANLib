### YANTask - Asynchronous Task Utility Library


## Overview

`YANTask` is a specialized utility library that extends the functionality of the Task Parallel Library (TPL) in C#. It provides extension methods for working with asynchronous tasks, particularly for waiting until a task produces a result that satisfies a condition.


## Features

The library is organized into several functional categories:

### Conditional Task Waiting

- **Single Result Filtering**: Wait for any task that completes and satisfies a specified condition (`WaitAnyWithCondition`, `WhenAnyWithCondition`; the two currently behave the same)
- **Completion Order**: Tasks are checked as they complete; tasks that are already complete are checked first, in collection order
- **No Match**: When no task satisfies the condition, the result is `default(T)`: `null` for reference and nullable types, `0` for `int`

### Error Handling

- **Exception Safety**: Tasks that fault or are canceled are skipped; an exception thrown by the condition counts as no match
- **Null Safety**: A `null` or empty task collection returns `default(T)`
- **Cancellation Handling**: The cancellation token is observed while waiting; a canceled wait throws `OperationCanceledException`


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
int result = await tasks.WaitAnyWithCondition(x => x > 5);
Console.WriteLine(result); // Output: 7

// Using WhenAnyWithCondition - waits for tasks to complete until it finds a match
int anotherResult = await tasks.WhenAnyWithCondition(x => x > 8);
Console.WriteLine(anotherResult); // Output: 10

// No match: the result is default(int), which is 0 (not null)
int noMatch = await tasks.WaitAnyWithCondition(x => x > 100);
Console.WriteLine(noMatch); // Output: 0

// Use tasks of a nullable type when 0 can be a real result
var nullableTasks = new[] { Task.FromResult<int?>(0), Task.FromResult<int?>(3) };
int? none = await nullableTasks.WaitAnyWithCondition(x => x > 5);
Console.WriteLine(none is null); // Output: True
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
int result = await tasksWithException.WaitAnyWithCondition(x => x > 5);
Console.WriteLine(result); // Output: 7
```

### Using Cancellation Tokens

```csharp
// Create a cancellation token source that cancels after 100 ms
using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(100));

// Create a collection of delayed tasks
var delayedTasks = new[]
{
    Task.Delay(1000).ContinueWith(_ => 1),
    Task.Delay(2000).ContinueWith(_ => 5),
    Task.Delay(3000).ContinueWith(_ => 10)
};

try
{
    // The wait is canceled after 100 ms, while the tasks are still running
    int result = await delayedTasks.WaitAnyWithCondition(x => x > 5, cts.Token);

    // This line won't be reached if cancellation occurs
    Console.WriteLine(result);
}
catch (OperationCanceledException)
{
    // A token that is already canceled when the method is called gives a TaskCanceledException,
    // a cancellation while waiting gives an OperationCanceledException: catch the base type for both
    Console.WriteLine("Operation was canceled"); // Output: Operation was canceled
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
int fastResult = await delayedTasks.WaitAnyWithCondition(x => x > 5);
Console.WriteLine(fastResult); // Output: 10 (the fastest task with value > 5)
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

// Wait for the first successful API response (status code 200); null if none succeeds
var firstSuccess = await apiTasks.WaitAnyWithCondition(response => response.StatusCode == 200);

Console.WriteLine($"First successful response: ID {firstSuccess?.Id}"); // Output: First successful response: ID 4

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

// Wait for the first non-empty result; null if every source returns an empty result
var firstData = await dataTasks.WaitAnyWithCondition(data => data != null && data.Length > 0);

Console.WriteLine($"First data source returned {firstData?.Length} bytes"); // Output: First data source returned 200 bytes

// Process all data sources that return valid data, once all of them have completed
foreach (var data in (await Task.WhenAll(dataTasks)).Where(d => d != null && d.Length > 0))
{
    Console.WriteLine($"Processing {data.Length} bytes of data"); // Output: 100, 200 and 150 bytes
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

- **Early Completion**: `WaitAnyWithCondition` and `WhenAnyWithCondition` return as soon as a matching task is found, without waiting for the other tasks (which keep running)
- **Linear Cost**: Each task is observed through a single continuation, so waiting on `n` tasks costs O(n) time and allocations rather than O(n²) with repeated `Task.WhenAny` calls
- **Single Enumeration**: The task collection is enumerated exactly once, so a lazy sequence (for example `ids.Select(LoadAsync)`) does not start its tasks twice
- **No Leaked Continuations**: The continuations registered on tasks that are still running are removed when the method returns, so many calls that share a long-running task do not accumulate memory
- **Exception Handling**: Tasks that throw exceptions are gracefully skipped without affecting other tasks
- **Cancellation Support**: The wait can be canceled at any time using a cancellation token
- **Debugging Support**: Uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience


## Implementation Details

- **Extension Methods**: All operations are implemented as extension methods for better integration with existing code
- **Async/Await Pattern**: Fully embraces the modern async/await pattern for asynchronous programming
- **Task Tracking**: The task collection is copied once into a `HashSet<Task<T>>`, so a task that appears twice is checked once; a `null` task faults the returned task with `ArgumentException`
- **Null Safety**: All methods handle null inputs gracefully, returning appropriate default values
- **Internal Implementation**: Core implementation details are separated from the public API for better maintainability
- **Internal Streaming Variants**: The library also contains `WaitAnyWithConditions` / `WhenAnyWithConditions` (an `IAsyncEnumerable<T>` of all matching results with a `taken` limit) and `AsyncEnumerableEmpty`, but they are `internal`: they are not part of the public API and cannot be called from your code


## Task Operations Coverage

The library provides focused coverage of conditional task operations:

| Category | Functions |
|----------|-----------|
| **Single Result Filtering** | WaitAnyWithCondition<T>, WhenAnyWithCondition<T> |
| **Cancellation Support** | All methods support CancellationToken |


## Technical Details

- **Task Tracking**: Copies the task collection once into a `HashSet<Task<T>>` to avoid duplicate processing
- **Asynchronous Implementation**: Uses `async/await` pattern throughout for non-blocking operations
- **Condition Evaluation**: Checks tasks that are already complete first, in collection order, then evaluates the others as they complete
- **Task Completion Detection**: Registers one continuation per running task that writes the task to a `Channel<Task<T>>`, which is read in completion order; the continuations are removed (through a cancellation token) as soon as the method returns
- **Exception Handling**: Skips tasks that fault or are canceled (their exceptions are observed) and treats an exception thrown by the condition as no match
- **Cancellation Support**: Waits with `ChannelReader.ReadAsync(cancellationToken)`, so cancellation is observed while waiting, not only when a task completes
- **Wait vs. When**: `WaitAnyWithCondition` and `WhenAnyWithCondition` currently have the same implementation and behave identically
