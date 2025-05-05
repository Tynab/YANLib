using System.Diagnostics;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation;

internal static partial class YANText
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void TitleImplement(this List<string?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].TitleImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].TitleImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? TitlesImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.TitleImplement()) : input.AsParallel().Select(x => x.TitleImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void CapitalizeImplement(this List<string?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].CapitalizeImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].CapitalizeImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? CapitalizesImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.CapitalizeImplement()) : input.AsParallel().Select(x => x.CapitalizeImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void CleanSpaceImplement(this List<string?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].CleanSpaceImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].CleanSpaceImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? CleanSpacesImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.CleanSpaceImplement()) : input.AsParallel().Select(x => x.CleanSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void FormatNameImplement(this List<string?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].FormatNameImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].FormatNameImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? FormatNamesImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.FormatNameImplement()) : input.AsParallel().Select(x => x.FormatNameImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void FilterAlphabeticImplement(this List<string?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].FilterAlphabeticImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].FilterAlphabeticImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? FilterAlphabeticsImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.FilterAlphabeticImplement()) : input.AsParallel().Select(x => x.FilterAlphabeticImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void FilterNumberImplement(this List<string?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].FilterNumberImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].FilterNumberImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? FilterNumbersImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.FilterNumberImplement()) : input.AsParallel().Select(x => x.FilterNumberImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void FilterAlphanumericImplement(this List<string?>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (input.Count < 1_000)
        {
            for (var i = 0; i < input.Count; i++)
            {
                input[i] = input[i].FilterAlphanumericImplement();
            }
        }
        else
        {
            _ = For(0, input.Count, i => input[i] = input[i].FilterAlphanumericImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? FilterAlphanumericsImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.GetCountImplement() < 1_000 ? input.Select(static x => x.FilterAlphanumericImplement()) : input.AsParallel().Select(x => x.FilterAlphanumericImplement());
}
