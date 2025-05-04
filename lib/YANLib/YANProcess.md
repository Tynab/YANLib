### YANProcess Component

The `YANProcess` component is part of the YANLib library, providing a set of utility methods for process management and manipulation in .NET applications.


## Overview

YANProcess offers extension methods that simplify common process management tasks, such as terminating processes by name. It provides a clean, safe API that handles edge cases gracefully and supports both single process operations and batch operations on multiple processes.


## Key Features

### Process Termination

Easily terminate processes by name:

```csharp
// Kill all processes with a specific name
await "notepad".KillAllProcessesByName();

// Kill multiple processes by their names
await YANProcess.KillAllProcessesByNames("chrome", "firefox", "edge");

// Kill processes from a collection of names
List<string> processesToKill = ["notepad", "calc", "mspaint"];
await processesToKill.KillAllProcessesByNames();
```

### Robust Error Handling

YANProcess methods are designed to handle edge cases gracefully:

- Null process names
- Empty or whitespace process names
- Non-existent processes
- Collections with mixed valid and invalid values

All operations complete without throwing exceptions, making your code more robust and easier to maintain.


## Usage Examples

### Basic Process Termination

```csharp
// Terminate all instances of Notepad
await "notepad".KillAllProcessesByName();

// Terminate all instances of Calculator
await "calc".KillAllProcessesByName();
```

### Batch Process Termination

```csharp
// Terminate multiple browser processes
await YANProcess.KillAllProcessesByNames("chrome", "firefox", "edge", "opera");

// Terminate processes from a collection
List<string> backgroundProcesses = ["svhost", "wininit", "lsass"];
await backgroundProcesses.KillAllProcessesByNames();
```

### Safe Process Cleanup

```csharp
public async Task CleanupProcesses()
{
    try
    {
        // This is safe even if some process names are null, empty, or non-existent
        await YANProcess.KillAllProcessesByNames(
            "TempProcess1", 
            null,               // Null is safely handled
            "",                 // Empty string is safely handled
            "   ",              // Whitespace is safely handled
            "NonExistentApp"    // Non-existent process is safely handled
        );
        
        Console.WriteLine("Process cleanup completed successfully");
    }
    catch (Exception ex)
    {
        // YANProcess methods don't throw exceptions for normal operation failures,
        // so this would only catch unexpected system-level issues
        Console.WriteLine($"Unexpected error during process cleanup: {ex.Message}");
    }
}
```

### Application Shutdown Cleanup

```csharp
public class Application
{
    private List<string> startedProcesses = new List<string>();
    
    public void StartProcess(string processName)
    {
        Process.Start(processName);
        startedProcesses.Add(processName);
    }
    
    public async Task Shutdown()
    {
        // Clean up all processes started by this application
        await startedProcesses.KillAllProcessesByNames();
        Console.WriteLine("All processes terminated, application shutting down");
    }
}
```

### Process Management in System Administration

```csharp
public class SystemManager
{
    public async Task RestartServices()
    {
        // First, terminate all instances of the services
        await YANProcess.KillAllProcessesByNames("ServiceA", "ServiceB", "ServiceC");
        
        // Wait a moment for processes to fully terminate
        await Task.Delay(1000);
        
        // Restart the services
        Process.Start("ServiceA");
        Process.Start("ServiceB");
        Process.Start("ServiceC");
        
        Console.WriteLine("Services restarted successfully");
    }
    
    public async Task KillResourceIntensiveProcesses()
    {
        // Terminate processes that might be consuming too many resources
        List<string> resourceHungryProcesses = GetResourceIntensiveProcesses();
        await resourceHungryProcesses.KillAllProcessesByNames();
    }
    
    private List<string> GetResourceIntensiveProcesses()
    {
        // Logic to identify resource-intensive processes
        return ["heavyapp1", "heavyapp2"];
    }
}
```

### Safe Process Cleanup in Application Installer

```csharp
public class Installer
{
    public async Task PrepareForInstallation()
    {
        Console.WriteLine("Preparing system for installation...");
        
        // Ensure no conflicting applications are running
        await YANProcess.KillAllProcessesByNames(
            "ConflictingApp1", 
            "ConflictingApp2", 
            "ConflictingApp3"
        );
        
        Console.WriteLine("System ready for installation");
    }
}
```

### Automated Testing Cleanup

```csharp
public class TestEnvironment
{
    public async Task SetUp()
    {
        // Start necessary processes for testing
        Process.Start("TestServer.exe");
        Process.Start("TestDatabase.exe");
    }
    
    public async Task TearDown()
    {
        // Clean up all test processes
        await YANProcess.KillAllProcessesByNames("TestServer", "TestDatabase");
    }
}
```


## Implementation Notes

- All methods are implemented as extension methods, allowing for fluent API usage
- Methods are asynchronous, returning `Task` to allow for non-blocking operation
- Process termination is attempted for all processes matching the given name(s)
- The component safely handles all edge cases without throwing exceptions during normal operation


## Best Practices

- Use specific process names when possible to avoid terminating unintended processes
- Consider the implications of terminating processes, especially system processes
- For critical applications, consider implementing additional checks before terminating processes
- Remember that process termination is immediate and may not allow processes to save data or clean up resources
