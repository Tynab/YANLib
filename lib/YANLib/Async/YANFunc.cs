using static System.Environment;
using static System.Threading.Tasks.Task;

namespace YANLib.Async;

public static partial class YANFunc
{
    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, IAsyncEnumerable<TResult>> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            var rng = await func(arg).ToListAsync();
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(rng);
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            var rng = await func(arg, coll).ToListAsync();
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(rng);
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, ValueTask<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            var rng = await (await func(arg)).ToListAsync();
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(rng);
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            var rng = await (await func(arg, coll)).ToListAsync();
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(rng);
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, Task<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            var rng = await (await func(arg)).ToListAsync();
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(rng);
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            var rng = await (await func(arg, coll)).ToListAsync();
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(rng);
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }
}
