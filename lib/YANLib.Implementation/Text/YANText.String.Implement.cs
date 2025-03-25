using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using YANLib.Implementation.Object;
using static System.Linq.Enumerable;
using static System.StringComparison;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation.Text;

internal static partial class YANText
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullImplement(this IEnumerable<string?> input) => !input.Any(x => x.IsNotNullImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullImplement(params string?[] input) => input.AllNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullImplement(this IEnumerable<string?> input) => input.Any(x => x.IsNullImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullEmptyImplement([NotNullWhen(false)] this string? input) => string.IsNullOrEmpty(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullEmptyImplement(this IEnumerable<string?> input) => !input.Any(x => x.IsNotNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullEmptyImplement(this IEnumerable<string?> input) => input.Any(x => x.IsNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNullWhiteSpaceImplement([NotNullWhen(false)] this string? input) => string.IsNullOrWhiteSpace(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNullWhiteSpaceImplement(this IEnumerable<string?> input) => !input.Any(x => x.IsNotNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNullWhiteSpaceImplement(this IEnumerable<string?> input) => input.Any(x => x.IsNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool EqualsIgnoreCaseImplement(this string? input1, string? input2) => AllNullImplement(input1, input2) || input1.IsNotNullImplement() && input1.IsNotNullImplement() && string.Equals(input1, input2, OrdinalIgnoreCase);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllEqualsIgnoreCaseImplement(this IEnumerable<string?> input) => !input.Any(x => x.NotEqualsIgnoreCaseImplement(input.First()));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyEqualsIgnoreCaseImplement(this IEnumerable<string?> input) => !input.AllNotEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullImplement(this IEnumerable<string?> input) => !input.Any(x => x.IsNullImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullImplement(params string?[] input) => input.AllNotNullImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullImplement(this IEnumerable<string?> input) => input.Any(x => x.IsNotNullImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullEmptyImplement([NotNullWhen(true)] this string? input) => !string.IsNullOrEmpty(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullEmptyImplement(this IEnumerable<string?> input) => !input.Any(x => x.IsNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullEmptyImplement(this IEnumerable<string?> input) => input.Any(x => x.IsNotNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool IsNotNullWhiteSpaceImplement([NotNullWhen(true)] this string? input) => !string.IsNullOrWhiteSpace(input);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotNullWhiteSpaceImplement(this IEnumerable<string?> input) => !input.Any(x => x.IsNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotNullWhiteSpaceImplement(this IEnumerable<string?> input) => input.Any(x => x.IsNotNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool NotEqualsIgnoreCaseImplement(this string? input1, string? input2) => AllNotNullImplement(input1, input2) && !string.Equals(input1, input2, OrdinalIgnoreCase);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AllNotEqualsIgnoreCaseImplement(this IEnumerable<string?> input)
    {
        var set = new HashSet<string?>(input.Count(), StringComparer.OrdinalIgnoreCase);

        foreach (var s in input)
        {
            if (!set.Add(s))
            {
                return false;
            }
        }

        return true;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static bool AnyNotEqualsIgnoreCaseImplement(this IEnumerable<string?> input) => !input.AllEqualsIgnoreCaseImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? LowerImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToLower();

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
        => input.IsNullEmptyImplement() ? input : input.Count() < 1_000 ? input.Select(x => x.LowerImplement()) : input.AsParallel().Select(x => x.LowerImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? LowerInvariantImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToLower(CultureInfo.InvariantCulture);

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
        => input.IsNullEmptyImplement() ? input : input.Count() < 1_000 ? input.Select(x => x.LowerInvariantImplement()) : input.AsParallel().Select(x => x.LowerInvariantImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? UpperImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToUpper();

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
        => input.IsNullEmptyImplement() ? input : input.Count() < 1_000 ? input.Select(x => x.UpperImplement()) : input.AsParallel().Select(x => x.UpperImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? UpperInvariantImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : input.ToUpper(CultureInfo.InvariantCulture);

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
        => input.IsNullEmptyImplement() ? input : input.Count() < 1_000 ? input.Select(x => x.UpperInvariantImplement()) : input.AsParallel().Select(x => x.UpperInvariantImplement());
}
