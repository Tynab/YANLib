### YANLib.Snowflake - Distributed Unique ID Generator


## Overview

`YANLib.Snowflake` provides a robust implementation of the Snowflake ID algorithm for generating distributed, time-ordered unique identifiers in C# applications. The Snowflake algorithm, originally developed by Twitter, creates 64-bit IDs that are composed of a timestamp, worker ID, datacenter ID, and sequence number, making them suitable for distributed systems where unique, sortable IDs are required.


## Features

The library offers several key capabilities:

### ID Generation

- **Numeric IDs**: Generate 64-bit unique IDs based on the Snowflake algorithm
- **String Representations**: Convert IDs to alphabetic (base-26) or alphanumeric (base-36) formats
- **Time-Ordered**: IDs are sortable by creation time due to the timestamp component
- **Distributed Support**: Worker ID and datacenter ID components ensure uniqueness across distributed systems
- **Predefined Bit Allocation Strategies**: Choose from optimized bit allocation patterns for different use cases
- **Customizable Bit Allocation**: Flexible configuration of bits for worker ID, datacenter ID, and sequence components

### ID Component Extraction

- **Timestamp Extraction**: Extract the creation time from an existing ID
- **Worker ID Extraction**: Extract the worker ID component from an ID
- **Datacenter ID Extraction**: Extract the datacenter ID component from an ID
- **Format Support**: Extract components from numeric, alphabetic, or alphanumeric IDs
- **Strategy-Aware Extraction**: Extract components using the same bit allocation strategy used for generation
- **Bit Allocation Awareness**: Component extraction with matching bit allocation configuration

### Thread Safety

- **Synchronized Access**: Thread-safe implementation for concurrent ID generation
- **Clock Drift Handling**: Protection against system clock moving backwards
- **Sequence Overflow**: Automatic handling of sequence overflow within the same millisecond


## Usage Examples

### Basic ID Generation

```csharp
// Create an ID generator with worker ID 1 and datacenter ID 1
var generator = new IdGenerator(1, 1);

// Generate a numeric ID
long id = generator.NextId();
// Example: 6982190104624234496

// Generate an alphabetic ID (base-26, A-Z)
string alphabeticId = generator.NextIdAlphabetic();
// Example: "BPNHEBKDMGLCQ"

// Generate an alphanumeric ID (base-36, 0-9, A-Z)
string alphanumericId = generator.NextIdAlphanumeric();
// Example: "1Z9DHPKW0S"
```

### Using Predefined Bit Allocation Strategies

```csharp
// Default strategy (5-5-13): Balanced approach for most applications
var defaultGenerator = new IdGenerator(1, 1, BitAllocationStrategy.Default);

// MoreDistributed strategy (10-10-3): Optimized for systems with many workers and datacenters
var distributedGenerator = new IdGenerator(100, 200, BitAllocationStrategy.MoreDistributed);

// HighVolume strategy (2-2-19): Optimized for generating many IDs per millisecond on few nodes
var highVolumeGenerator = new IdGenerator(1, 1, BitAllocationStrategy.HighVolume);

// Balanced strategy (8-8-7): Middle ground between distribution and sequence capacity
var balancedGenerator = new IdGenerator(50, 50, BitAllocationStrategy.Balanced);

// Generate IDs with different strategies
long defaultId = defaultGenerator.NextId();
long distributedId = distributedGenerator.NextId();
long highVolumeId = highVolumeGenerator.NextId();
long balancedId = balancedGenerator.NextId();
```

### Using Custom Epoch

```csharp
// Create an ID generator with worker ID 2, datacenter ID 3
var generator = new IdGenerator(2, 3);

// Define a custom epoch (e.g., January 1, 2020 00:00:00 UTC)
long customEpoch = 1577836800000; // milliseconds since Unix epoch

// Generate an ID with custom epoch
long id = generator.NextId(customEpoch);

// Generate string representations with custom epoch
string alphabeticId = generator.NextIdAlphabetic(customEpoch);
string alphanumericId = generator.NextIdAlphanumeric(customEpoch);
```

### Customizing Bit Allocation Manually

```csharp
// Default bit allocation (5 bits for worker ID, 5 bits for datacenter ID, 13 bits for sequence)
var defaultGenerator = new IdGenerator(1, 1);

// Custom bit allocation for more workers and datacenters, fewer sequences
// 10 bits for worker ID (0-1023), 10 bits for datacenter ID (0-1023), 3 bits for sequence (0-7)
var distributedGenerator = new IdGenerator(
    workerId: 100,
    datacenterId: 200,
    sequence: 0,
    workerIdBits: 10,
    datacenterIdBits: 10,
    sequenceBits: 3
);

// Custom bit allocation for high-volume sequence generation
// 2 bits for worker ID (0-3), 2 bits for datacenter ID (0-3), 19 bits for sequence (0-524,287)
var highVolumeGenerator = new IdGenerator(
    workerId: 1,
    datacenterId: 1,
    sequence: 0,
    workerIdBits: 2,
    datacenterIdBits: 2,
    sequenceBits: 19
);

// Generate IDs with custom bit allocation
long distributedId = distributedGenerator.NextId();
long highVolumeId = highVolumeGenerator.NextId();
```

### Extracting Components from IDs

```csharp
// Extract components from a numeric ID
long id = 6982190104624234496;
var components = IdGenerator.ExtractIdComponents(id);

DateTime timestamp = components.Timestamp;
long workerId = components.WorkerId;
long datacenterId = components.DatacenterId;

Console.WriteLine($"Timestamp: {timestamp}");
Console.WriteLine($"Worker ID: {workerId}");
Console.WriteLine($"Datacenter ID: {datacenterId}");

// Extract components using a specific bit allocation strategy
var strategicComponents = IdGenerator.ExtractIdComponents(
    id,
    BitAllocationStrategy.MoreDistributed
);

// Extract components from an ID with custom bit allocation
var customComponents = IdGenerator.ExtractIdComponents(
    id: id,
    timestampEpoch: IdGenerator.TIMESTAMP_EPOCH,
    sequence: 0,
    workerIdBits: 10,
    datacenterIdBits: 10,
    sequenceBits: 3
);

// Extract components from an alphabetic ID
string alphabeticId = "BPNHEBKDMGLCQ";
var alphabeticComponents = IdGenerator.ExtractIdAlphabeticComponents(alphabeticId);

// Extract components from an alphanumeric ID
string alphanumericId = "1Z9DHPKW0S";
var alphanumericComponents = IdGenerator.ExtractIdAlphanumericComponents(alphanumericId);
```

### Multiple Generator Instances

```csharp
// Create generators for different services or nodes
var userIdGenerator = new IdGenerator(1, 1);
var orderIdGenerator = new IdGenerator(2, 1);
var productIdGenerator = new IdGenerator(3, 1);

// Generate IDs for different entities
long userId = userIdGenerator.NextId();
long orderId = orderIdGenerator.NextId();
long productId = productIdGenerator.NextId();

// Generate string representations for different entities
string userAlphanumericId = userIdGenerator.NextIdAlphanumeric();
string orderAlphanumericId = orderIdGenerator.NextIdAlphanumeric();
string productAlphanumericId = productIdGenerator.NextIdAlphanumeric();
```

### High-Volume ID Generation

```csharp
// Create a generator for high-volume ID generation using the HighVolume strategy
var generator = new IdGenerator(1, 1, BitAllocationStrategy.HighVolume);

// Generate multiple IDs in a loop
var ids = new List<long>();

for (int i = 0; i < 1000; i++)
{
    ids.Add(generator.NextId());
}

// Generate multiple IDs in parallel (thread-safe)
var parallelIds = Enumerable.Range(0, 1000)
    .AsParallel()
    .Select(_ => generator.NextId())
    .ToList();
```

### Error Handling

```csharp
// Handle invalid worker ID
try
{
    var generator = new IdGenerator(32, 1); // Worker ID must be between 0 and 31
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // "Worker ID must be between 0 and 31, but got 32."
}

// Handle invalid datacenter ID
try
{
    var generator = new IdGenerator(1, 32); // Datacenter ID must be between 0 and 31
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // "Datacenter ID must be between 0 and 31, but got 32."
}

// Handle invalid bit allocation
try
{
    var generator = new IdGenerator(1, 1, 0, 10, 10, 10); // Total bits must be 23
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // "The total bits allocated for worker ID, datacenter ID, and sequence must equal 23."
}

// Handle invalid worker ID for a specific strategy
try
{
    var generator = new IdGenerator(1500, 1, BitAllocationStrategy.MoreDistributed); // Worker ID must be between 0 and 1023
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // "Worker ID must be between 0 and 1023, but got 1500."
}

// Handle clock moving backwards
// This would occur if the system clock is adjusted backwards while the application is running
// The generator will throw an exception to prevent duplicate IDs
```


## Performance Considerations

- **Thread Safety**: The implementation uses a lock to ensure thread safety, which may impact performance in highly concurrent scenarios
- **ID Generation Speed**: Can generate thousands of IDs per second on modern hardware
- **String Conversion**: Converting to alphabetic or alphanumeric formats adds some overhead compared to numeric IDs
- **Memory Usage**: The generator has a small memory footprint, using only a few fields to track state
- **Clock Synchronization**: For distributed systems, ensure clocks are synchronized to prevent issues with timestamp ordering
- **Bit Allocation Trade-offs**: Consider the trade-offs between number of workers/datacenters and sequence capacity when customizing bit allocation
- **Strategy Selection**: Choose the appropriate predefined strategy based on your system's scale and throughput requirements
- **Debugging Support**: Uses `DebuggerHidden` and `DebuggerStepThrough` attributes to improve debugging experience


## Implementation Details

- **ID Structure**: 64-bit IDs composed of timestamp (41 bits) and configurable bits for datacenter ID, worker ID, and sequence (total 23 bits)
- **Epoch**: Default epoch is January 1, 2023 00:00:00 UTC (1,672,531,200,000 milliseconds since Unix epoch)
- **Sequence Overflow**: When sequence exceeds maximum value within the same millisecond, the generator waits for the next millisecond
- **Clock Drift**: Throws an exception if the system clock moves backwards to prevent duplicate IDs
- **Base Conversion**: Implements custom base-26 (alphabetic) and base-36 (alphanumeric) conversion for string representations
- **Component Extraction**: Provides methods to extract the original components from an ID
- **Bit Allocation**: Supports both predefined strategies and customizable bit allocation between worker ID, datacenter ID, and sequence components


## Snowflake ID Structure

The Snowflake algorithm generates 64-bit IDs with the following default structure:

| Component | Bits | Description | Range
|-----|-----|-----|-----
| **Timestamp** | 41 bits | Milliseconds since epoch | ~69 years
| **Datacenter ID** | 5 bits | Identifier for the datacenter | 0-31
| **Worker ID** | 5 bits | Identifier for the worker/process | 0-31
| **Sequence** | 13 bits | Sequence number within the same millisecond | 0-8,191


With predefined bit allocation strategies, you can choose from optimized configurations:

| Strategy | Worker ID Bits | Datacenter ID Bits | Sequence Bits | Worker Range | Datacenter Range | Sequence Range | Use Case
|-----|-----|-----|-----|-----|-----|-----|-----
| Default | 5 | 5 | 13 | 0-31 | 0-31 | 0-8,191 | General purpose
| MoreDistributed | 10 | 10 | 3 | 0-1,023 | 0-1,023 | 0-7 | Large distributed systems
| HighVolume | 2 | 2 | 19 | 0-3 | 0-3 | 0-524,287 | High throughput on few nodes
| Balanced | 8 | 8 | 7 | 0-255 | 0-255 | 0-127 | Medium-scale systems

You can also create custom bit allocations to suit your specific needs, as long as the total bits equals 23.


## Technical Details

- **Bit Manipulation**: Uses bit shifting and masking operations to compose and extract ID components
- **Thread Synchronization**: Implements a lock-based synchronization mechanism for thread safety
- **Clock Handling**: Includes logic to handle clock drift and sequence overflow
- **Base Conversion**: Implements custom algorithms for converting between numeric and string representations
- **Component Extraction**: Uses bit manipulation to extract the original components from an ID
- **Error Handling**: Includes validation for worker ID, datacenter ID, and bit allocation ranges
- **Bit Allocation Validation**: Ensures the total bits allocated equals 23 (41 bits for timestamp + 23 bits = 64 bits total)
- **Strategy Implementation**: Encapsulates bit allocation patterns in an enum for simplified configuration
- **Debugging Support**: Includes attributes to improve debugging experience
