### YANTask - Asynchronous Task Utility Library


## Overview

`YANTask` is a specialized utility library that extends the functionality of the Task Parallel Library (TPL) in C#. It provides extension methods for working with asynchronous tasks, particularly for waiting until a task produces a result that satisfies a condition, or for enumerating every such result as the tasks complete.


## Features

The library is organized into several functional categories:

### Conditional Task Waiting

- **Single Result Filtering**: Wait for any task that completes and satisfies a specified condition (`WaitAnyWithCondition`, `WhenAnyWithCondition`; the two currently behave the same)
- **Completion Order**: Tasks are checked as they complete; tasks that are already complete are checked first, in collection order
- **No Match**: When no task satisfies the condition, the result is `default(T)`: `null` for reference and nullable types, `0` for `int`

### Streaming All Matching Results

- **Multiple Result Filtering**: Enumerate every task result that satisfies a condition as an `IAsyncEnumerable<T>`, with `await foreach` (`WaitAnyWithConditions`, `WhenAnyWithConditions`; the two currently behave the same)
- **Completion Order**: Each result is yielded as soon as its task completes; tasks that are already complete when the enumeration starts come first, in collection order
- **Result Limiting**: The `taken` parameter ends the enumeration after that many results (`0`, the default, yields every match)
- **Lazy Execution**: Nothing runs until the result is enumerated, and the task collection is read again by each new enumeration

### Error Handling

- **Exception Safety**: Tasks that fault or are canceled are skipped (and do not count toward `taken`)
- **Condition Exceptions**: An exception thrown by the condition counts as no match in `WaitAnyWithCondition` / `WhenAnyWithCondition`, but ends the enumeration and propagates to the consumer in `WaitAnyWithConditions` / `WhenAnyWithConditions`
- **Null Safety**: A `null` or empty task collection returns `default(T)`, or an empty enumeration for the streaming methods; a `null` task in the collection throws `ArgumentException`
- **Cancellation Handling**: The cancellation token is observed while waiting; a canceled wait throws `OperationCanceledException`. The streaming methods throw it in every cancellation case: a token that is already canceled when the enumeration starts, a token passed with `WithCancellation`, a cancellation while waiting for a task, and a cancellation while your loop body handles an item (thrown by the next `MoveNextAsync`)


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

### Enumerating All Matching Results

```csharp
var tasks = new[]
{
    Task.FromResult(3),
    Task.FromResult(7),
    Task.FromResult(10),
    Task.FromResult(15)
};

// Every result greater than 5; these tasks are already complete, so they come in collection order
await foreach (var item in tasks.WaitAnyWithConditions(x => x > 5))
{
    Console.WriteLine(item); // Output: 7, 10, 15
}

// Stop after the first 2 matching results
await foreach (var item in tasks.WhenAnyWithConditions(x => x > 5, taken: 2))
{
    Console.WriteLine(item); // Output: 7, 10
}

// No match, or a null or empty collection: the enumeration is empty
await foreach (var item in tasks.WaitAnyWithConditions(x => x > 100))
{
    Console.WriteLine(item); // Not reached
}
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

// The faulted task is skipped by the streaming methods too
await foreach (var item in tasksWithException.WaitAnyWithConditions(x => x > 5))
{
    Console.WriteLine(item); // Output: 7, 10
}

// An exception thrown by the condition: no match for WaitAnyWithCondition, propagated by WaitAnyWithConditions
var withZero = new[] { Task.FromResult(0), Task.FromResult(5) };

int first = await withZero.WaitAnyWithCondition(x => 10 / x > 1);
Console.WriteLine(first); // Output: 5 (the DivideByZeroException for 0 counts as no match)

try
{
    await foreach (var item in withZero.WaitAnyWithConditions(x => 10 / x > 1))
    {
        Console.WriteLine(item); // Not reached: 0 is checked first and the condition throws
    }
}
catch (DivideByZeroException)
{
    Console.WriteLine("The condition threw"); // Output: The condition threw
}
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

// The streaming methods throw OperationCanceledException too, from the await foreach
try
{
    await foreach (var item in delayedTasks.WaitAnyWithConditions(x => x > 0, cancellationToken: cts.Token))
    {
        Console.WriteLine(item); // Not reached: the token is already canceled
    }
}
catch (OperationCanceledException)
{
    Console.WriteLine("Enumeration was canceled"); // Output: Enumeration was canceled
}

// A token passed with WithCancellation is observed as well, and so is a cancellation from inside the loop
using var stop = new CancellationTokenSource();

try
{
    await foreach (var item in new[] { Task.FromResult(1), Task.FromResult(2) }.WaitAnyWithConditions(x => x > 0).WithCancellation(stop.Token))
    {
        Console.WriteLine(item); // Output: 1
        stop.Cancel();           // the next MoveNextAsync throws, even though 2 is ready
    }
}
catch (OperationCanceledException)
{
    Console.WriteLine("Stopped after the first item"); // Output: Stopped after the first item
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

// Enumerate every task that completes and satisfies the condition
await foreach (var item in delayedTasks.WaitAnyWithConditions(x => x > 5))
{
    Console.WriteLine(item); // Output: 10, 7 (in completion order)
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

// Wait for the first successful API response (status code 200); null if none succeeds
var firstSuccess = await apiTasks.WaitAnyWithCondition(response => response.StatusCode == 200);

Console.WriteLine($"First successful response: ID {firstSuccess?.Id}"); // Output: First successful response: ID 4

// Get all successful API responses as they complete
await foreach (var response in apiTasks.WaitAnyWithConditions(r => r.StatusCode == 200))
{
    Console.WriteLine($"Successful response: ID {response.Id}"); // Output: ID 4 (already complete), then ID 2 (at about 150 ms)
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

// Wait for the first non-empty result; null if every source returns an empty result
var firstData = await dataTasks.WaitAnyWithCondition(data => data != null && data.Length > 0);

Console.WriteLine($"First data source returned {firstData?.Length} bytes"); // Output: First data source returned 200 bytes

// Process every data source that returns valid data, as soon as it completes
await foreach (var data in dataTasks.WhenAnyWithConditions(d => d != null && d.Length > 0))
{
    Console.WriteLine($"Processing {data.Length} bytes of data"); // Output: 200, 100 and 150 bytes (in completion order)
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

- **Early Completion**: `WaitAnyWithCondition` and `WhenAnyWithCondition` return as soon as a matching task is found, and the streaming methods stop waiting once `taken` results have been yielded, without waiting for the other tasks (which keep running)
- **Lazy Enumeration**: The streaming methods yield each result as soon as its task completes, without waiting for all tasks to complete
- **Linear Cost**: Each task is observed through a single continuation, so waiting on `n` tasks costs O(n) time and allocations rather than O(n²) with repeated `Task.WhenAny` calls
- **Single Enumeration**: The task collection is enumerated exactly once per call (once per enumeration for the streaming methods), so a lazy sequence (for example `ids.Select(LoadAsync)`) does not start its tasks twice
- **No Leaked Continuations**: The continuations registered on tasks that are still running are removed when the method returns or the enumeration ends (all tasks checked, limit reached, exception, cancellation, or a loop that exits early), so many calls that share a long-running task do not accumulate memory
- **Exception Handling**: Tasks that throw exceptions are gracefully skipped without affecting other tasks
- **Cancellation Support**: The wait can be canceled at any time using a cancellation token
- **Debugging Support**: The thin public facade is marked `DebuggerHidden` and `DebuggerStepThrough`, so the debugger steps from your code straight into the implementation (`YANLib.Implementation`), whose code you can step through


## Implementation Details

- **Extension Methods**: All operations are implemented as extension methods for better integration with existing code
- **Async/Await Pattern**: Fully embraces the modern async/await pattern for asynchronous programming
- **Task Tracking**: The task collection is copied once into a `HashSet<Task<T>>`, so a task that appears twice is checked once; a `null` task faults the returned task with `ArgumentException`
- **Null Safety**: All methods handle null inputs gracefully, returning appropriate default values
- **Internal Implementation**: Core implementation details are separated from the public API for better maintainability
- **Streaming Variants**: `WaitAnyWithConditions` / `WhenAnyWithConditions` return an `IAsyncEnumerable<T>` of all matching results with a `taken` limit; they are public since 8.4.0 (the `AsyncEnumerableEmpty` helper stays internal)


## Task Operations Coverage

The library provides focused coverage of conditional task operations:

| Category | Functions |
|----------|-----------|
| **Single Result Filtering** | WaitAnyWithCondition<T>, WhenAnyWithCondition<T> |
| **Multiple Results Filtering** | WaitAnyWithConditions<T>, WhenAnyWithConditions<T> |
| **Result Limiting** | The `taken` parameter of WaitAnyWithConditions<T> and WhenAnyWithConditions<T> |
| **Cancellation Support** | All methods support CancellationToken (and `WithCancellation` for the streaming methods) |


## Technical Details

- **Task Tracking**: Copies the task collection once into a `HashSet<Task<T>>` to avoid duplicate processing
- **Asynchronous Implementation**: Uses `async/await` pattern throughout for non-blocking operations
- **Condition Evaluation**: Checks tasks that are already complete first, in collection order, then evaluates the others as they complete
- **Task Completion Detection**: Registers one continuation per running task that writes the task to a `Channel<Task<T>>`, which is read in completion order; the continuations are removed (through a cancellation token) as soon as the method returns
- **Exception Handling**: Skips tasks that fault or are canceled (their exceptions are observed); an exception thrown by the condition counts as no match in the single-result methods and propagates from the streaming methods
- **Cancellation Support**: Waits with `ChannelReader.ReadAsync(cancellationToken)`, so cancellation is observed while waiting, not only when a task completes; the streaming methods are async iterators whose token parameter has `[EnumeratorCancellation]`, so the token passed to the method and one passed with `WithCancellation` are combined, and every cancellation throws `OperationCanceledException`, as `ChannelReader.ReadAllAsync` does
- **Result Collection**: The streaming methods implement `IAsyncEnumerable<T>` as async iterators, for lazy, asynchronous enumeration of results
- **Wait vs. When**: `WaitAnyWithCondition` and `WhenAnyWithCondition` currently have the same implementation and behave identically, and so do `WaitAnyWithConditions` and `WhenAnyWithConditions`
