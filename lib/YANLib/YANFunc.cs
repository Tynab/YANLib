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
            var item = func(arg);
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(item);
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
            var item = func(arg, coll);
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(item);
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
            var item = await func(arg);
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(item);
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
            var item = await func(arg, coll);
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(item);
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
            var item = await func(arg);
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(item);
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
            var item = await func(arg, coll);
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(item);
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
