using System.Diagnostics;
using System.Text;
using static System.Globalization.CultureInfo;

namespace YANLib.Implementation;

internal static partial class YANText
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? TitleImplement(this string? input) => input.IsNullWhiteSpaceImplement() ? input : CurrentCulture.TextInfo.ToTitleCase(input.LowerImplement()!);

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
}
