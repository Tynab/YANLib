using System.Collections;

namespace YANLib.Tests.Extensions;

internal sealed class CountingEnumerable<T>(IEnumerable<T> source) : IEnumerable<T>
{
    public int EnumerationCount { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
        EnumerationCount++;

        return source.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
