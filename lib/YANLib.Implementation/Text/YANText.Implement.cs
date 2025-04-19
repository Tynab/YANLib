using System.Diagnostics;
using System.Text;
using YANLib.Implementation.Object;
using YANLib.Implementation.Text;
using static System.Globalization.CultureInfo;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation.Text;

internal static partial class YANText
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? TitleImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : CurrentCulture.TextInfo.ToTitleCase(input.LowerImplement()!);

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
    internal static string? CapitalizeImplement(this string? input)
    {
        if (input.IsNullWhiteSpaceImplement())
        {
            return input;
        }

        var sb = new StringBuilder(input);
        var isFirstChar = true;

        for (var i = 0; i < sb.Length; i++)
        {
            if (isFirstChar && sb[i].IsAlphabeticImplement())
            {
                sb[i] = sb[i].UpperImplement();
                isFirstChar = false;
            }
            else
            {
                sb[i] = sb[i].LowerImplement();
            }
        }

        return sb.ToString();
    }

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
    internal static string? CleanSpaceImplement(this string? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return input;
        }

        input = input.Trim();

        if (input.IsNullEmptyImplement())
        {
            return input;
        }

        var sb = new StringBuilder(input.Length);
        var isWhiteSpace = false;

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsWhiteSpaceImplement())
            {
                if (!isWhiteSpace)
                {
                    _ = sb.Append(' ');
                    isWhiteSpace = true;
                }
            }
            else
            {
                _ = sb.Append(input[i]);
                isWhiteSpace = false;
            }
        }

        return sb.ToString();
    }

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
    internal static string? FormatNameImplement(this string? input)
    {
        if (input.IsNullWhiteSpaceImplement())
        {
            return input;
        }

        input = input.Trim();

        var sb = new StringBuilder(input.Length);
        var isPreviousCharWhiteSpace = true;

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsPunctuationImplement())
            {
                _ = sb.Append(' ');
                isPreviousCharWhiteSpace = true;

                continue;
            }

            if (input[i].IsNumberImplement() || isPreviousCharWhiteSpace && input[i].IsWhiteSpaceImplement())
            {
                continue;
            }

            _ = isPreviousCharWhiteSpace ? sb.Append(input[i].UpperImplement()) : sb.Append(input[i].LowerImplement());
            isPreviousCharWhiteSpace = input[i].IsWhiteSpaceImplement();
        }

        return sb.ToString();
    }

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
    internal static string? FilterAlphabeticImplement(this string? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return input;
        }

        input = input.Trim();

        if (input.IsNullEmptyImplement())
        {
            return input;
        }

        var sb = new StringBuilder(input.Length);

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsAlphabeticImplement())
            {
                _ = sb.Append(input[i]);
            }
        }

        return sb.ToString();
    }

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
    internal static string? FilterNumberImplement(this string? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return input;
        }

        input = input.Trim();

        if (input.IsNullEmptyImplement())
        {
            return input;
        }

        var sb = new StringBuilder(input.Length);

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsNumberImplement())
            {
                _ = sb.Append(input[i]);
            }
        }

        return sb.ToString();
    }

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
    internal static string? FilterAlphanumericImplement(this string? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return input;
        }

        input = input.Trim();

        if (input.IsNullEmptyImplement())
        {
            return input;
        }

        var sb = new StringBuilder(input.Length);

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsAlphanumericImplement())
            {
                _ = sb.Append(input[i]);
            }
        }

        return sb.ToString();
    }

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
