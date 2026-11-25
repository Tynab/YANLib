namespace YANLib.Tests.Models;

/// <summary>
/// The data that <c>ConcurrentCollectionTests</c> merges: the fields and <c>Setup</c> of <c>ConcurrentCollectionBenchmark</c> (console/YANLib.Benchmarks),
/// kept here so that the test project does not reference the benchmark console.
/// </summary>
public sealed class ConcurrentCollectionData
{
    /// <summary>
    /// Builds <paramref name="size"/> items with new ids and the batch numbers that cover them, as <c>ConcurrentCollectionBenchmark.Setup</c> does.
    /// </summary>
    /// <param name="size">The number of items.</param>
    public ConcurrentCollectionData(int size)
    {
        Size = size;
        AllData = [.. Enumerable.Range(1, size).Select(static _ => new ConcurrentCollectionItem { Id = Guid.NewGuid() })];
        Batches = [.. Enumerable.Range(0, (size.Parse<double>() / BatchSize).Ceiling<int>())];
    }

    public int Size { get; }

    public int BatchSize { get; } = 1_000;

    public object LockObj { get; } = new();

    public List<ConcurrentCollectionItem> AllData { get; }

    public List<int> Batches { get; }
}

/// <summary>
/// An item of <see cref="ConcurrentCollectionData"/>: the only property of the benchmark's <c>SampleClass</c> that the test reads.
/// </summary>
public sealed class ConcurrentCollectionItem
{
    public Guid Id { get; set; }
}
