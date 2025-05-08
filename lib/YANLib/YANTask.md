### YANTask Component

The `YANTask` component is part of the YANLib library, providing enhanced task coordination and management capabilities for asynchronous programming in .NET applications.


## Overview

YANTask extends the functionality of the standard .NET Task API with additional methods that simplify common asynchronous programming patterns. It offers extension methods for collections of tasks that allow for more sophisticated coordination and filtering of task results.


## Key Features

### Conditional Task Waiting

Wait for any task in a collection that satisfies a specific condition:

```csharp
// Wait for any task that returns a value greater than 10
var tasks = new[]
{
    Task.FromResult(5),
    Task.FromResult(15),
    Task.FromResult(25)
};

// Returns 15 (the first value that satisfies the condition)
var result = await tasks.WaitAnyWithCondition(x => x > 10);
```

### Conditional Task Completion

Similar to `WaitAnyWithCondition`, but using the `WhenAny` pattern:

```csharp
// Wait for any task that returns a value greater than 10
var tasks = new[]
{
    Task.FromResult(5),
    Task.FromResult(15),
    Task.FromResult(25)
};

// Returns 15 (the first value that satisfies the condition)
var result = await tasks.WhenAnyWithCondition(x => x > 10);
```

### Asynchronous Enumeration with Conditions

Process multiple matching task results as an asynchronous stream:

```csharp
// Get all tasks that return values greater than 10
var tasks = new[]
{
    Task.FromResult(5),
    Task.FromResult(15),
    Task.FromResult(25)
};

// Use internal methods via reflection or InternalsVisibleTo for testing
// Returns an IAsyncEnumerable with values 15 and 25
var results = tasks.WaitAnyWithConditions(x => x > 10);

await foreach (var item in results)
{
    Console.WriteLine(item); // Outputs 15, then 25
}
```

### Limited Result Collection

Limit the number of results returned from conditional task enumeration:

```csharp
var tasks = new[]
{
    Task.FromResult(5),
    Task.FromResult(15),
    Task.FromResult(25),
    Task.FromResult(35)
};

// Only take the first 2 matching results
var results = tasks.WhenAnyWithConditions(x => x > 10, taken: 2);

// Will only contain 15 and 25, even though 35 also matches
await foreach (var item in results)
{
    Console.WriteLine(item);
}
```

### Graceful Error Handling

All methods handle exceptions gracefully, continuing to check other tasks if one throws an exception:

```csharp
var tasks = new[]
{
    Task.FromException<int>(new Exception("Task failed")),
    Task.FromResult(15),
    Task.FromResult(25)
};

// Still returns 15, ignoring the failed task
var result = await tasks.WaitAnyWithCondition(x => x > 10);
```

### Cancellation Support

Support for cancellation tokens to stop waiting for tasks:

```csharp
var cts = new CancellationTokenSource();

var tasks = new[]
{
    Task.Delay(1000).ContinueWith(_ => 5),
    Task.Delay(2000).ContinueWith(_ => 15),
    Task.Delay(3000).ContinueWith(_ => 25)
};

// Cancel after a timeout
cts.CancelAfter(500);

try
{
    var result = await tasks.WaitAnyWithCondition(x => x > 10, cts.Token);
}
catch (TaskCanceledException)
{
    // Handle cancellation
}
```


## Usage Examples

### Finding the First Valid Result

```csharp
public async Task<string> FindFirstValidUrl(IEnumerable<string> potentialUrls)
{
    var tasks = potentialUrls.Select(async url =>
    {
        try
        {
            using var client = new HttpClient();

            var response = await client.GetAsync(url);

            return new { Url = url, IsValid = response.IsSuccessStatusCode };
        }
        catch
        {
            return new { Url = url, IsValid = false };
        }
    });

    var result = await tasks.WaitAnyWithCondition(r => r.IsValid);

    return result?.Url ?? string.Empty;
}
```

### Collecting Multiple Valid Results

```csharp
public async Task<List<string>> FindAllValidUrls(IEnumerable<string> potentialUrls, int maxResults = 0)
{
    var tasks = potentialUrls.Select(async url =>
    {
        try
        {
            using var client = new HttpClient();

            var response = await client.GetAsync(url);

            return new { Url = url, IsValid = response.IsSuccessStatusCode };
        }
        catch
        {
            return new { Url = url, IsValid = false };
        }
    });

    var validUrls = new List<string>();
    
    // Use internal methods via reflection or InternalsVisibleTo for testing
    var results = tasks.WaitAnyWithConditions(r => r.IsValid, maxResults > 0 ? (uint)maxResults : 0);
    
    await foreach (var result in results)
    {
        validUrls.Add(result.Url);
    }

    return validUrls;
}
```

### Parallel Data Processing with Filtering

```csharp
public async Task<int> ProcessDataWithFilter(IEnumerable<string> dataFiles)
{
    var tasks = dataFiles.Select(async file =>
    {
        var data = await File.ReadAllTextAsync(file);
        var processedValue = ProcessData(data);

        return processedValue;
    });

    // Return the first processed value that meets our criteria
    return await tasks.WhenAnyWithCondition(value => value > 100);
}

private int ProcessData(string data)
{
    // Some processing logic
    return data.Length;
}
```

### Implementing a Timeout with Fallback

```csharp
public async Task<T> ExecuteWithTimeoutAndFallback<T>(
    Func<Task<T>> primaryOperation,
    Func<Task<T>> fallbackOperation,
    TimeSpan timeout)
{
    var cts = new CancellationTokenSource();
    
    cts.CancelAfter(timeout);

    try
    {
        var primaryTask = primaryOperation();
        var timeoutTask = Task.Delay(timeout).ContinueWith(_ => default(T));
        var tasks = new[] { primaryTask, timeoutTask };

        var result = await tasks.WhenAnyWithCondition(
            r => !EqualityComparer<T>.Default.Equals(r, default),
            cts.Token);

        if (!EqualityComparer<T>.Default.Equals(result, default))
        {
            return result;
        }
    }
    catch (TaskCanceledException)
    {
        // Timeout occurred
    }

    // Fall back to secondary operation
    return await fallbackOperation();
}
```

### Concurrent API Calls with First Valid Response

```csharp
public async Task<WeatherData> GetWeatherFromMultipleProviders(string location)
{
    var providers = new[]
    {
        GetWeatherFromProvider1(location),
        GetWeatherFromProvider2(location),
        GetWeatherFromProvider3(location)
    };

    // Return the first non-null weather data
    return await providers.WaitAnyWithCondition(data => data != null);
}

private async Task<WeatherData> GetWeatherFromProvider1(string location)
{
    // Implementation for provider 1
}

private async Task<WeatherData> GetWeatherFromProvider2(string location)
{
    // Implementation for provider 2
}

private async Task<WeatherData> GetWeatherFromProvider3(string location)
{
    // Implementation for provider 3
}
```

### Collecting Results from Multiple Providers

```csharp
public async Task<List<WeatherData>> GetWeatherFromAllProviders(string location, int maxResults = 0)
{
    var providers = new[]
    {
        GetWeatherFromProvider1(location),
        GetWeatherFromProvider2(location),
        GetWeatherFromProvider3(location)
    };

    var results = new List<WeatherData>();
    
    // Use internal methods via reflection or InternalsVisibleTo for testing
    var weatherData = providers.WhenAnyWithConditions(
        data => data != null && data.IsValid, 
        maxResults > 0 ? (uint)maxResults : 0);
    
    await foreach (var data in weatherData)
    {
        results.Add(data);
    }

    return results;
}
```

### Distributed Computing with Result Validation

```csharp
public async Task<Solution> SolveComplexProblemDistributed(Problem problem)
{
    // Distribute the problem to multiple solvers with different algorithms
    var solverTasks = new[]
    {
        SolveWithAlgorithm1(problem),
        SolveWithAlgorithm2(problem),
        SolveWithAlgorithm3(problem)
    };

    // Return the first valid solution
    return await solverTasks.WhenAnyWithCondition(solution => solution.IsValid);
}
```


## Implementation Notes

- Both `WaitAnyWithCondition` and `WhenAnyWithCondition` handle null or empty task collections gracefully, returning the default value.
- If no task satisfies the condition, the methods return the default value for the type.
- The methods continue checking other tasks if one throws an exception, providing resilience against partial failures.
- Cancellation tokens are fully supported, allowing for timeouts and manual cancellation.
- The methods work with both immediate and delayed tasks, waiting for completion before checking the condition.
- The internal `WaitAnyWithConditions` and `WhenAnyWithConditions` methods provide more advanced functionality for collecting multiple results as an asynchronous stream.
- The `taken` parameter allows limiting the number of results returned from the asynchronous enumeration methods.
