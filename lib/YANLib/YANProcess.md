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
- **Process Trees**: Each matching process is killed together with all of its descendant processes
- **Self Protection**: The calling process is never killed, even when it has the specified name

### Error Handling

- **Null Safety**: Graceful handling of null or empty process names
- **Exception Safety**: If a process cannot be killed, the others are still killed and every handle is disposed; then the first exception is rethrown
- **Whitespace Handling**: Null, empty and whitespace names are skipped without affecting the other names
- **Empty Names**: A path without a file name (for example a directory path) or a bare extension such as `".exe"` matches no process

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

// Kill a process using a full path (only the file name is used): "firefox.exe" is looked up first,
// and since no process has that name, the processes named "firefox" are killed
await @"C:\Program Files\Mozilla Firefox\firefox.exe".KillAllProcessesByName();

// A process whose name contains a dot can be targeted by its full name
await "my.app".KillAllProcessesByName();

// The calling process itself is never killed. If a matching process is an ancestor of the calling process
// (for example the shell that started it), .NET refuses to kill its process tree: that process keeps running,
// the other matching processes are still killed, and the InvalidOperationException is rethrown at the end
// (unless another process failed first: only the first failure is rethrown).

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

// A process that cannot be killed (for example access denied) does not stop the others:
// all of them are tried and disposed, then the first exception is rethrown
try
{
    await YANProcess.KillAllProcessesByNames("ProtectedService", "notepad");
}
catch (Exception ex)
{
    Console.WriteLine($"Some processes could not be killed: {ex.Message}");
}
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
public async Task ManualProcessKill(string processNameOrPath)
{
    var name = Path.GetFileName(processNameOrPath);

    if (string.IsNullOrWhiteSpace(name))
    {
        return; // Process.GetProcessesByName("") would return every process
    }

    // Look the name up as given first, then without its extension
    var processes = Process.GetProcessesByName(name);

    if (processes.Length == 0 && Path.HasExtension(name))
    {
        var nameWithoutExtension = Path.GetFileNameWithoutExtension(name);

        processes = string.IsNullOrWhiteSpace(nameWithoutExtension) ? [] : Process.GetProcessesByName(nameWithoutExtension);
    }

    ExceptionDispatchInfo? firstFailure = null;

    foreach (var process in processes)
    {
        try
        {
            // Never kill the calling process; kill the others with their process trees and wait for them to exit
            if (process.Id != Environment.ProcessId)
            {
                process.Kill(entireProcessTree: true);
                await process.WaitForExitAsync();
            }
        }
        catch (Exception ex)
        {
            // Keep going; remember the first failure
            firstFailure ??= ExceptionDispatchInfo.Capture(ex);
        }
        finally
        {
            // Always dispose of the process resources
            process.Dispose();
        }
    }

    firstFailure?.Throw();
}
```


## Performance Considerations

- **Asynchronous Operations**: All methods are asynchronous, allowing for non-blocking execution
- **Parallel Processing**: When killing multiple processes, operations are performed in parallel
- **Resource Management**: Processes are properly disposed after termination to prevent resource leaks
- **Null Handling**: All methods handle null inputs gracefully, avoiding unnecessary operations
- **Exception Safety**: A failure to kill one process does not stop the others or leak process handles; the first failure is rethrown at the end
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
- **Process Termination**: Uses `Process.Kill(entireProcessTree: true)`, which kills every descendant of a matching process, whatever its name. If a matching process is an ancestor of the calling process (for example the shell that started it), .NET refuses to kill its tree with an `InvalidOperationException`: that process keeps running and nothing is killed through it, the other matching processes are still killed, and the refusal is rethrown at the end like any other failure (only the first failure is rethrown)
- **Self Protection**: Skips the process whose id is `Environment.ProcessId` (`Kill(entireProcessTree: true)` always refuses a tree that contains the caller)
- **Asynchronous Waiting**: Uses `Process.WaitForExitAsync()` to wait for process termination without blocking
- **Resource Cleanup**: Disposes every `Process` handle in a `finally` block, also when killing it failed
- **Path Handling**: Uses `Path.GetFileName()` to drop the directory, looks the file name up as given, and only if nothing matches and it has an extension, looks it up again without the extension (`Path.GetFileNameWithoutExtension()`); a name that is empty at that point matches nothing
- **Case Insensitivity**: Process names are matched case-insensitively by `Process.GetProcessesByName()` (on Windows and Linux)
- **Parallel Termination**: Implements parallel processing for terminating multiple processes efficiently
- **Exception Handling**: Tries every process, then rethrows the first failure with `ExceptionDispatchInfo`, so its type (`Win32Exception`, `AggregateException`, `InvalidOperationException`, ...) and stack trace are kept
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
