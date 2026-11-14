using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Linq.Enumerable;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation;

internal static partial class YANText
{
    #region Private

    // The EqualsIgnoreCase helpers below use the comparison of the scalar EqualsIgnoreCase
    // (StringComparison.OrdinalIgnoreCase), enumerate the input once and do not create lower-cased copies. null equals only
    // null. Arrays and lists are read as spans, so they need no enumerator; up to this many strings, duplicates are found
    // by comparing every pair instead of filling a HashSet, so those inputs allocate nothing.
    private const int PAIRWISE_DUPLICATE_CHECK_MAX_COUNT = 16;

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool TryGetSpan(IEnumerable<string?> input, out ReadOnlySpan<string?> span)
    {
        switch (input)
        {
            case string?[] array:
            {
                span = array;

                return true;
            }
            case List<string?> list:
            {
                span = CollectionsMarshal.AsSpan(list);

                return true;
            }
            default:
            {
                span = default;

                return false;
            }
        }
    }

    // Returns null for a null or empty input, otherwise whether every string equals the first one.
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool? AllEqualToFirstIgnoreCase(IEnumerable<string?>? input)
    {
        if (input is null)
        {
            return null;
        }

        if (TryGetSpan(input, out var span))
        {
            if (span.IsEmpty)
            {
                return null;
            }

            for (var i = 1; i < span.Length; i++)
            {
                if (!span[0].EqualsIgnoreCaseImplement(span[i]))
                {
                    return false;
                }
            }

            return true;
        }

        using var enumerator = input.GetEnumerator();

        if (!enumerator.MoveNext())
        {
            return null;
        }

        var first = enumerator.Current;

        while (enumerator.MoveNext())
        {
            if (!first.EqualsIgnoreCaseImplement(enumerator.Current))
            {
                return false;
            }
        }

        return true;
    }

    // Returns null for a null or empty input, otherwise whether two of the strings are equal.
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool? HasDuplicateIgnoreCase(IEnumerable<string?>? input)
    {
        if (input is null)
        {
            return null;
        }

        if (TryGetSpan(input, out var span) && span.Length <= PAIRWISE_DUPLICATE_CHECK_MAX_COUNT)
        {
            if (span.IsEmpty)
            {
                return null;
            }

            for (var i = 1; i < span.Length; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (span[i].EqualsIgnoreCaseImplement(span[j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        var seen = new HashSet<string?>(StringComparer.OrdinalIgnoreCase);
        var isEmpty = true;

        foreach (var item in input)
        {
            isEmpty = false;

            if (!seen.Add(item))
            {
                return true;
            }
        }

        return isEmpty ? null : false;
    }

    #endregion

    #region Null

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x is not null);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x is null);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x is null);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x is not null);

    #endregion

    #region NullEmpty

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullEmptyImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullEmptyImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullEmptyImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullEmptyImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotNullEmptyImplement());

    #endregion

    #region NullWhiteSpace

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullWhiteSpaceImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNotNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullWhiteSpaceImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullWhiteSpaceImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && !input.Any(static x => x.IsNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullWhiteSpaceImplement(this IEnumerable<string?>? input) => input.IsNotNullEmptyImplement() && input.Any(static x => x.IsNotNullWhiteSpaceImplement());

    #endregion

    #region EqualsIgnoreCase

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllEqualsIgnoreCaseImplement(this IEnumerable<string?>? input) => AllEqualToFirstIgnoreCase(input) is true;

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyEqualsIgnoreCaseImplement(this IEnumerable<string?>? input) => HasDuplicateIgnoreCase(input) is true;

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotEqualsIgnoreCaseImplement(this IEnumerable<string?>? input) => HasDuplicateIgnoreCase(input) is false;

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotEqualsIgnoreCaseImplement(this IEnumerable<string?>? input) => AllEqualToFirstIgnoreCase(input) is false;

    #endregion

    #region Lower

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void LowerImplement(this List<string?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].LowerImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].LowerImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? LowersImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.LowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void LowerInvariantImplement(this List<string?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].LowerInvariantImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].LowerInvariantImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? LowerInvariantsImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.LowerInvariantImplement());

    #endregion

    #region Upper

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void UpperImplement(this List<string?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].UpperImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].UpperImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? UppersImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.UpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void UpperInvariantImplement(this List<string?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].UpperInvariantImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].UpperInvariantImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? UpperInvariantsImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.UpperInvariantImplement());

    #endregion
}
