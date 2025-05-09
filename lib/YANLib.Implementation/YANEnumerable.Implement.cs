using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YANLib.Implementation;

internal static partial class YANEnumerable
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T[] ToArray<T>(this IEnumerable<object?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return [];
        }

        var array = input is Array x ? x : input.ToArray();

        return [.. array.ParsesImplement<T>()!];
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T[] ToArray<T>(this System.Collections.IEnumerable? input)
    {
        if (input.IsNullImplement())
        {
            return [];
        }

        var array = input is Array x ? x : input.Cast<object?>().ToArray();

        return [.. array.ParsesImplement<T>()!];
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static List<T> ToList<T>(this IEnumerable<object?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return [];
        }

        var list = input as List<object?> ?? [.. input];

        return [.. list.ParsesImplement<T>()!];
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static List<T> ToList<T>(this System.Collections.IEnumerable? input)
    {
        if (input.IsNullImplement())
        {
            return [];
        }

        var list = input is List<object?> x ? x : [.. input.Cast<object?>()];

        return [.. list.ParsesImplement<T>()!];
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static HashSet<T> ToHashSet<T>(this IEnumerable<object?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return [];
        }

        var set = input as HashSet<object?> ?? [.. input];

        return [.. set.ParsesImplement<T>()!];
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static HashSet<T> ToHashSet<T>(this System.Collections.IEnumerable? input)
    {
        if (input.IsNullImplement())
        {
            return [];
        }

        var set = input is HashSet<object?> x ? x : [.. input.Cast<object?>()];

        return [.. set.ParsesImplement<T>()!];
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Dictionary<TKey, TValue?> ToDictionary<TKey, TValue>(this IDictionary<object, object?>? input) where TKey : unmanaged
    {
        if (input.IsNullEmptyImplement())
        {
            return [];
        }

        var result = new Dictionary<TKey, TValue?>(input.Count);

        foreach (var pair in input)
        {
            var key = pair.Key is TKey k ? k : pair.Key.ParseImplement<TKey>();
            var value = pair.Value is TValue v ? v : pair.Value.ParseImplement<TValue>();

            result[key] = value;
        }

        return result;
    }

    //[DebuggerHidden]
    //[DebuggerStepThrough]
    //internal static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(
    //    this System.Collections.IEnumerable? input,
    //    Func<T, TKey> keySelector,
    //    Func<T, TValue> elementSelector)
    //{
    //    if (input.IsNullImplement())
    //    {
    //        return new Dictionary<TKey, TValue>();
    //    }

    //    var list = input is List<object?> x ? x : input.Cast<object?>().ToList();
    //    var parsed = list.ParsesImplement<T>()!;
    //    return parsed.ToDictionary(keySelector, elementSelector);
    //}

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ILookup<TKey, TValue> ToLookup<T, TKey, TValue>(
        this IEnumerable<object?>? input,
        Func<T, TKey> keySelector,
        Func<T, TValue> elementSelector)
    {
        if (input.IsNullEmptyImplement())
        {
            return Enumerable.Empty<T>().ToLookup(keySelector, elementSelector);
        }

        var list = input as List<object?> ?? input.ToList();
        var parsed = list.ParsesImplement<T>()!;
        return parsed.ToLookup(keySelector, elementSelector);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static ILookup<TKey, TValue> ToLookup<T, TKey, TValue>(
        this System.Collections.IEnumerable? input,
        Func<T, TKey> keySelector,
        Func<T, TValue> elementSelector)
    {
        if (input.IsNullImplement())
        {
            return Enumerable.Empty<T>().ToLookup(keySelector, elementSelector);
        }

        var list = input is List<object?> x ? x : input.Cast<object?>().ToList();
        var parsed = list.ParsesImplement<T>()!;
        return parsed.ToLookup(keySelector, elementSelector);
    }
}
