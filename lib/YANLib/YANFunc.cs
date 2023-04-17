using static System.Environment;
using static System.Threading.Tasks.Task;

namespace YANLib;

public static partial class YANFunc
{
    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, TResult> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, TResult> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, TResult> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, TResult> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, ValueTask<TResult>> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, ValueTask<TResult>> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, ValueTask<TResult>> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, ValueTask<TResult>> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, Task<TResult>> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, Task<TResult>> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, Task<TResult>> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, TResult>(Func<T, Task<TResult>> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> AggregateResultsConcurrently<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
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
