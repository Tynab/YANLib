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
- **Process Trees**: By default each matching process is killed together with all of its descendant processes; pass `entireProcessTree: false` to kill only the matching processes
- **Self Protection**: The calling process is never killed, even when it has the specified name
- **Cancellation and Timeouts**: Overloads take a `CancellationToken` that limits the wait for the processes to exit; for a timeout, pass the token of a `new CancellationTokenSource(TimeSpan)`

### Error Handling

- **Null Safety**: Graceful handling of null or empty process names
- **Exception Safety**: If a process cannot be killed, the others are still killed and every handle is disposed; then the first exception is rethrown
- **Cancellation**: A token that is already canceled when the method is called throws `OperationCanceledException`, and nothing is killed. A token canceled after the call has started only stops the wait: the matching processes have been signalled (they stay signalled), and `OperationCanceledException` is thrown only if a signalled process has not exited when the wait for it sees the cancellation (for example, nothing is thrown when no process matched). A failure to kill a process takes precedence and is thrown instead
- **Whitespace Handling**: Null, empty and whitespace names are skipped without affecting the other names
- **Empty Names**: A path without a file name (for example a directory path) or a bare extension such as `".exe"` matches no process

### Collection Support

- **Collection Processing**: Process multiple process names at once
- **Parallel Execution**: Terminate multiple processes in parallel
- **Params Array Support**: Convenient API for specifying multiple process names
- **Options for Collections**: The `entireProcessTree` and cancellation overloads take any collection type (`KillAllProcessesByNames<TNames>`, inferred from the argument); a `null` literal needs a typed variable or a cast


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
// With entireProcessTree: false (see below) there is no refusal: that ancestor is killed on its own.

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

### Choosing Whether to Kill Process Trees

```csharp
// Default: each matching process is killed with its whole process tree (all descendants, whatever their names)
await "launcher".KillAllProcessesByName();

// Kill only the matching processes: their child processes keep running
await "launcher".KillAllProcessesByName(entireProcessTree: false);

// The same choice for several names (any collection type; the params overload has no options)
var names = new List<string?> { "launcher", "updater" };
await names.KillAllProcessesByNames(entireProcessTree: false);
await new[] { "launcher", "updater" }.KillAllProcessesByNames(entireProcessTree: true);

// A null collection needs a type for the options overloads: a typed variable or a cast
IEnumerable<string?>? noNames = null;
await noNames.KillAllProcessesByNames(entireProcessTree: false); // no action taken
```

### Cancellation and Timeouts

```csharp
// The methods wait for every killed process to exit. A process that does not exit after it is signalled
// (for example a zombie that its parent never reaps, or one stuck in an uninterruptible state) would make
// the wait last forever; a cancellation token limits it.

// Timeout recipe: a CancellationTokenSource that cancels itself after the given time
using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));

try
{
    await "notepad".KillAllProcessesByName(timeout.Token);
    Console.WriteLine("All notepad processes have exited");
}
catch (OperationCanceledException)
{
    // The processes were signalled and stay signalled; only the wait stopped.
    // Every process handle has been disposed.
    Console.WriteLine("Gave up waiting after 10 seconds");
}

// A canceled token stays canceled: give each call that needs its own timeout a new CancellationTokenSource
// (the token above may already be canceled here, and would make these calls kill nothing and throw at once)

// Combine with the process tree choice, for one name or a collection; each call has its own 10 seconds
// and, like the call above, throws OperationCanceledException when they run out
using var treeTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
await "notepad".KillAllProcessesByName(entireProcessTree: false, treeTimeout.Token);

using var namesTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
await new[] { "notepad", "calc" }.KillAllProcessesByNames(namesTimeout.Token);

// A token that is already canceled kills nothing: the call throws OperationCanceledException right away
using var canceled = new CancellationTokenSource();
canceled.Cancel();

try
{
    await "notepad".KillAllProcessesByName(canceled.Token);
}
catch (OperationCanceledException)
{
    Console.WriteLine("Nothing was killed"); // Output: Nothing was killed
}

// A failure to kill a process (for example access denied) takes precedence over the cancellation:
// that exception is thrown instead of OperationCanceledException
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
public async Task ManualProcessKill(string processNameOrPath, bool entireProcessTree = true, CancellationToken cancellationToken = default)
{
    // A token that is already canceled kills nothing. This is the only check before the kills:
    // a token canceled after it only stops the waiting below
    cancellationToken.ThrowIfCancellationRequested();

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
    var signalled = new List<Process>();

    try
    {
        // First signal every process: never the calling process; the others with their process trees
        // (Kill() instead when entireProcessTree is false)
        foreach (var process in processes)
        {
            try
            {
                if (process.Id != Environment.ProcessId)
                {
                    process.Kill(entireProcessTree);
                    signalled.Add(process);
                }
            }
            catch (Exception ex)
            {
                // Keep going; remember the first failure
                firstFailure ??= ExceptionDispatchInfo.Capture(ex);
            }
        }

        // Then wait for each to exit, until the token is canceled
        foreach (var process in signalled)
        {
            try
            {
                await process.WaitForExitAsync(cancellationToken);
            }
            catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
            {
                // Stop waiting; a failure to kill comes first and wins
                firstFailure ??= ExceptionDispatchInfo.Capture(ex);
                break;
            }
            catch (Exception ex)
            {
                firstFailure ??= ExceptionDispatchInfo.Capture(ex);
            }
        }
    }
    finally
    {
        // Always dispose of the process resources
        foreach (var process in processes)
        {
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
- **Signal First, Then Wait**: Every matching process is signalled before the method waits for any of them, so the processes exit in parallel and a process that does not exit never keeps the others from being killed
- **Bounded Waiting**: With a cancellation token (for example from `new CancellationTokenSource(TimeSpan)`), the wait for the processes to exit ends when the token is canceled
- **Debugging Support**: The thin public facade is marked `DebuggerHidden` and `DebuggerStepThrough`, so the debugger steps from your code straight into the implementation (`YANLib.Implementation`), whose code you can step through


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
| **Process Tree Choice** | KillAllProcessesByName(name, entireProcessTree, cancellationToken), KillAllProcessesByNames(names, entireProcessTree, cancellationToken) |
| **Cancellation and Timeouts** | KillAllProcessesByName(name, cancellationToken), KillAllProcessesByNames(names, cancellationToken), and the tree-choice overloads |
| **Asynchronous Operations** | All methods return Task for asynchronous execution |
| **Path Handling** | Automatic extraction of process name from file paths |
| **Error Handling** | Graceful handling of non-existent processes |


## Technical Details

- **Process Identification**: Uses `Process.GetProcessesByName()` to find processes by name
- **Process Termination**: Uses `Process.Kill(entireProcessTree: true)` by default, which kills every descendant of a matching process, whatever its name. If a matching process is an ancestor of the calling process (for example the shell that started it), .NET refuses to kill its tree with an `InvalidOperationException`: that process keeps running and nothing is killed through it, the other matching processes are still killed, and the refusal is rethrown at the end like any other failure (only the first failure is rethrown)
- **Single-Process Termination**: With `entireProcessTree: false`, uses `Process.Kill()`: only the matching process is killed and its descendants keep running (on Linux they are re-parented). A matching ancestor of the calling process is then killed on its own, without a refusal; the calling process keeps running
- **Self Protection**: Skips the process whose id is `Environment.ProcessId` (`Kill(entireProcessTree: true)` always refuses a tree that contains the caller, and `Kill()` would kill the caller itself)
- **Asynchronous Waiting**: Signals every matching process first, then uses `Process.WaitForExitAsync(cancellationToken)` to wait for each to exit without blocking
- **Cancellation**: A token that is already canceled kills nothing (the returned task is canceled); a token canceled later stops only the waiting, and the processes stay signalled. The cancellation counts as a failure that comes after every failure to kill, so a failure to kill is rethrown instead; across names, `Task.WhenAll` also reports a failed name before a canceled one
- **Overload Design**: The collection overloads with options are generic (`KillAllProcessesByNames<TNames>(this TNames? names, ...) where TNames : IEnumerable<string?>`), so that calls of the `params` overload with only `null`/`default` arguments keep their meaning; there are no `TimeSpan` overloads, because a `default` argument would be ambiguous between a token and a timeout. Since 8.4.0, `KillAllProcessesByName` has more than one overload, so its method group no longer has a natural delegate type: `var kill = YANProcess.KillAllProcessesByName;` does not compile (CS8917) and needs an explicit delegate type, for example `Func<string?, Task> kill = YANProcess.KillAllProcessesByName;` (`YANProcess.KillAllProcessesByNames` already had two overloads in 8.3.3, but the extension form `names.KillAllProcessesByNames` had one and now also needs an explicit delegate type, for example `Func<Task> kill = names.KillAllProcessesByNames;`)
- **Resource Cleanup**: Disposes every `Process` handle in a `finally` block, also when killing it failed or the wait was canceled
- **Path Handling**: Uses `Path.GetFileName()` to drop the directory, looks the file name up as given, and only if nothing matches and it has an extension, looks it up again without the extension (`Path.GetFileNameWithoutExtension()`); a name that is empty at that point matches nothing
- **Case Insensitivity**: Process names are matched case-insensitively by `Process.GetProcessesByName()` (on Windows and Linux)
- **Parallel Termination**: Implements parallel processing for terminating multiple processes efficiently
- **Exception Handling**: Tries every process, then rethrows the first failure with `ExceptionDispatchInfo`, so its type (`Win32Exception`, `AggregateException`, `InvalidOperationException`, ...) and stack trace are kept
- **Extension Method Pattern**: Implements all functionality as extension methods for better integration with existing code
