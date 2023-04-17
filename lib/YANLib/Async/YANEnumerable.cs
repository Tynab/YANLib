namespace YANLib.Async;

public static partial class YANEnumerable
{
    public static async ValueTask<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> srcs)
    {
        var rslts = new List<T>();
        await foreach (var src in srcs.ConfigureAwait(false))
        {
            rslts.Add(src);
        }
        return rslts;
    }
}
