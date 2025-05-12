### YANProcess - Process Management Utility Library


## Overview

`YANProcess` is a specialized utility library that provides extension methods for managing system processes in C# applications. It offers a streamlined approach to common process management tasks, particularly focused on terminating processes by name. The library is designed to be robust, handling edge cases gracefully and providing asynchronous operations for better performance.


## Features

The library is organized into several functional categories:

### Process Termination

- **Single Process Management**: Kill all processes with a specific name
- **Multiple Process Management**: Kill all processes with names matching any in a collection
- **Asynchronous Operations**: All operations are asynchronous, returning Tasks
- **Process Cleanup**: Automatically disposes of process resources after termination

### Error Handling

- **Null Safety**: Graceful handling of null or empty process names
- **Exception Safety**: Robust error handling during process termination
- **Whitespace Handling**: Proper handling of whitespace in process names

### Collection Support

- **Collection Processing**: Process multiple process names at once
- **Parallel Execution**: Terminate multiple processes in parallel
- **Params Array Support**: Convenient API for specifying multiple process names


## Usage Examples

### Killing a Single Process by Name

```csharp
// Kill all instances of a process with a specific name
await "notepad".KillAllProcessesByName();

// Process name is case-insensitive and doesn't need the .exe extension
await "chrome".KillAllProcessesByName();

// Kill a process using a full path (only the filename will be used)
await @"C:\Program Files\Mozilla Firefox\firefox.exe".KillAllProcessesByName();

// Null-safe operation (no action taken)
string? nullProcessName = null;
await nullProcessName.KillAllProcessesByName();

// Empty or whitespace process name (no action taken)
await "".KillAllProcessesByName();
await "   ".KillAllProcessesByName();
```

### Killing Multiple Processes by Name

```csharp
// Kill multiple processes using a collection
var processNames = new List<string?>
{
    "notepad",
    "calc",
    "mspaint"
};

await processNames.KillAllProcessesByNames();

// Kill multiple processes using params array
await YANProcess.KillAllProcessesByNames("chrome", "firefox", "edge");

// Mixed collection with null, empty, and whitespace values (valid names are processed)
var mixedNames = new List<string?>
{
    "notepad",
    null,
    "",
    "   ",
    "calc"
};

await mixedNames.KillAllProcessesByNames();

// Null or empty collection (no action taken)
List<string?>? nullList = null;
await nullList.KillAllProcessesByNames();

var emptyList = new List<string?>();
await emptyList.KillAllProcessesByNames();
```

### Advanced Usage Examples

```csharp
// Kill all browser processes
await YANProcess.KillAllProcessesByNames("chrome", "firefox", "edge", "opera", "brave");

// Kill processes with similar names
var similarProcesses = new List<string?>
{
    "winword",   // Microsoft Word
    "excel",     // Microsoft Excel
    "powerpnt"   // Microsoft PowerPoint
};

await similarProcesses.KillAllProcessesByNames();

// Kill processes that might not exist (no exceptions thrown)
await "NonExistentProcess".KillAllProcessesByName();
await YANProcess.KillAllProcessesByNames("Process1", "Process2", "Process3");

// Kill a process and wait for completion
Console.WriteLine("Terminating notepad...");
await "notepad".KillAllProcessesByName();
Console.WriteLine("Notepad terminated successfully");
```

### Integration with Application Shutdown

```csharp
// Example of using YANProcess in an application shutdown method
public async Task ShutdownApplication()
{
    // Save application state
    await SaveApplicationState();
    
    // Terminate all child processes
    var childProcesses = new List<string?>
    {
        "HelperProcess",
        "BackgroundWorker",
        "DataProcessor"
    };
    
    // Kill all child processes in parallel
    await childProcesses.KillAllProcessesByNames();
    
    // Log completion
    Console.WriteLine("All child processes terminated successfully");
}

private async Task SaveApplicationState()
{
    // Implementation details
    await Task.Delay(100);
}
```

### Handling Process Cleanup

```csharp
// YANProcess automatically handles process cleanup
// The following code shows what happens internally

// Manual implementation (for illustration only - YANProcess does this automatically)
public async Task ManualProcessKill(string processName)
{
    var processes = Process.GetProcessesByName(
        Path.GetFileNameWithoutExtension(Path.GetFileName(processName)));
    
    foreach (var process in processes)
    {
        try
        {
            // Kill the process and wait for it to exit
            process.Kill(true);
            await process.WaitForExitAsync();
        }
        finally
        {
            // Always dispose of the process resources
            process.Dispose();
        }
    }
}
```


## Performance Considerations

- **Asynchronous Operations**: All methods are asynchronous, allowing for non-blocking execution
- **Parallel Processing**: When killing multiple processes, operations are performed in parallel
- **Resource Management**: Processes are properly disposed after termination to prevent resource leaks
- **Null Handling**: All methods handle null inputs gracefully, avoiding unnecessary operations
- **Exception Safety**: Operations are designed to be robust, handling exceptions during process termination
- **Debugging Support**: Uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience


## Implementation Details

- **Extension Methods**: All operations are implemented as extension methods for better integration with existing code
- **Asynchronous Pattern**: Fully embraces the modern async/await pattern for asynchronous programming
- **Process Name Extraction**: Automatically extracts the process name from full paths
- **Null Safety**: All methods are designed to be null-safe, handling null inputs gracefully
- **Internal Implementation**: Core implementation details are separated from the public API for better maintainability


## Process Management Coverage

The library provides focused coverage of process termination operations:

| Category | Functions |
|----------|-----------|
| **Single Process** | KillAllProcessesByName |
| **Multiple Processes** | KillAllProcessesByNames |
| **Asynchronous Operations** | All methods return Task for asynchronous execution |
| **Path Handling** | Automatic extraction of process name from file paths |
| **Error Handling** | Graceful handling of non-existent processes |


## Technical Details

- **Process Identification**: Uses `Process.GetProcessesByName()` to find processes by name
- **Process Termination**: Uses `Process.Kill(true)` to terminate processes and their child processes
- **Asynchronous Waiting**: Uses `Process.WaitForExitAsync()` to wait for process termination without blocking
- **Resource Cleanup**: Implements proper resource disposal using `using` statements or explicit `Dispose()` calls
- **Path Handling**: Uses `Path.GetFileNameWithoutExtension()` and `Path.GetFileName()` to extract process names from paths
- **Case Insensitivity**: Implements case-insensitive process name matching for Windows compatibility
- **Parallel Termination**: Implements parallel processing for terminating multiple processes efficiently
- **Exception Handling**: Catches and suppresses exceptions during process termination to ensure robustness
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
