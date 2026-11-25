using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation;

internal static partial class YANText
{
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

    internal static IEnumerable<string?>? TitlesImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.TitleImplement());

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

    internal static IEnumerable<string?>? CapitalizesImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.CapitalizeImplement());

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

    internal static IEnumerable<string?>? CleanSpacesImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.CleanSpaceImplement());

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

    internal static IEnumerable<string?>? FormatNamesImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.FormatNameImplement());

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

    internal static IEnumerable<string?>? FilterAlphabeticsImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.FilterAlphabeticImplement());

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

    internal static IEnumerable<string?>? FilterNumbersImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.FilterNumberImplement());

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

    internal static IEnumerable<string?>? FilterAlphanumericsImplement(this IEnumerable<string?>? input)
        => input.IsNullEmptyImplement() ? input : input.Select(static x => x.FilterAlphanumericImplement());
}
