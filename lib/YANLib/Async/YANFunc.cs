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
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
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
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, IAsyncEnumerable<TResult>> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, IAsyncEnumerable<TResult>> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, IAsyncEnumerable<TResult>> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, IAsyncEnumerable<TResult>> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await func(arg, coll).ToListAsync());
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
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
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
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
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
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
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
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, TResult>(Func<T, Task<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<IAsyncEnumerable<TResult>>> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.AddRange(await (await func(arg, coll)).ToListAsync());
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
