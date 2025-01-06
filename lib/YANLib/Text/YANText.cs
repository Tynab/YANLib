using System.Text;
using YANLib.Object;
using static System.Globalization.CultureInfo;

namespace YANLib.Text;

public static partial class YANText
{
    public static string? Title(this string? input) => input.IsNullWhiteSpace() ? input : CurrentCulture.TextInfo.ToTitleCase(input);

    public static void Titles(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.Title());
    }

    public static IEnumerable<string?>? Titles(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Title());

    public static IEnumerable<string?>? Titles(this ICollection<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Title());

    public static IEnumerable<string?>? Titles(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.Title());

    public static string? Capitalize(this string? input)
    {
        if (input.IsNullWhiteSpace())
        {
            return input;
        }

        var sb = new StringBuilder(input);
        var isFirstChar = true;

        for (var i = 0; i < sb.Length; i++)
        {
            if (isFirstChar && sb[i].IsAlphabetic())
            {
                sb[i] = sb[i].Upper();
                isFirstChar = false;
            }
            else
            {
                sb[i] = sb[i].Lower();
            }
        }

        return sb.ToString();
    }

    public static void Capitalizes(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.Capitalize());
    }

    public static IEnumerable<string?>? Capitalizes(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Capitalize());

    public static IEnumerable<string?>? Capitalizes(this ICollection<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.Capitalize());

    public static IEnumerable<string?>? Capitalizes(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.Capitalize());

    public static string? CleanSpace(this string? input)
    {
        if (input.IsNullEmpty())
        {
            return input;
        }

        input = input.Trim();

        var sb = new StringBuilder();
        var isWhiteSpace = false;

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsWhiteSpace())
            {
                if (!isWhiteSpace)
                {
                    _ = sb.Append(input[i]);
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

    public static void CleanSpace(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.CleanSpace());
    }

    public static IEnumerable<string?>? CleanSpaces(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.CleanSpace());

    public static IEnumerable<string?>? CleanSpaces(this ICollection<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.CleanSpace());

    public static IEnumerable<string?>? CleanSpaces(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.CleanSpace());

    public static string? FormatName(this string? input)
    {
        if (input.IsNullEmpty())
        {
            return input;
        }

        input = input.Trim();

        var sb = new StringBuilder();
        var isPreviousCharWhiteSpace = true;

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsPunctuation() || input[i].IsNumber() || isPreviousCharWhiteSpace && input[i].IsWhiteSpace())
            {
                continue;
            }

            _ = isPreviousCharWhiteSpace ? sb.Append(input[i].Upper()) : sb.Append(input[i].Lower());
            isPreviousCharWhiteSpace = input[i].IsWhiteSpace();
        }

        return sb.ToString();
    }

    public static void FormatName(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.FormatName());
    }

    public static IEnumerable<string?>? FormatNames(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FormatName());

    public static IEnumerable<string?>? FormatNames(this ICollection<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FormatName());

    public static IEnumerable<string?>? FormatNames(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.FormatName());

    public static string? FilterAlphabetic(this string? input)
    {
        if (input.IsNullEmpty())
        {
            return input;
        }

        input = input.Trim();

        var sb = new StringBuilder();

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsAlphabetic())
            {
                _ = sb.Append(input[i]);
            }
        }

        return sb.ToString();
    }

    public static void FilterAlphabetic(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.FilterAlphabetic());
    }

    public static IEnumerable<string?>? FilterAlphabetics(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterAlphabetic());

    public static IEnumerable<string?>? FilterAlphabetics(this ICollection<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterAlphabetic());

    public static IEnumerable<string?>? FilterAlphabetics(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterAlphabetic());

    public static string? FilterNumber(this string? input)
    {
        if (input.IsNullEmpty())
        {
            return input;
        }

        input = input.Trim();

        var sb = new StringBuilder();

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsNumber())
            {
                _ = sb.Append(input[i]);
            }
        }

        return sb.ToString();
    }

    public static void FilterNumber(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.FilterNumber());
    }

    public static IEnumerable<string?>? FilterNumbers(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterNumber());

    public static IEnumerable<string?>? FilterNumbers(this ICollection<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterNumber());

    public static IEnumerable<string?>? FilterNumbers(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterNumber());

    public static string? FilterAlphanumeric(this string? input)
    {
        if (input.IsNullEmpty())
        {
            return input;
        }

        input = input.Trim();

        var sb = new StringBuilder();

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].IsNumber() || input[i].IsAlphabetic())
            {
                _ = sb.Append(input[i]);
            }
        }

        return sb.ToString();
    }

    public static void FilterAlphanumeric(this List<string?>? input)
    {
        if (input.IsNullEmpty())
        {
            return;
        }

        input.ForEach(x => x = x.FilterAlphanumeric());
    }

    public static IEnumerable<string?>? FilterAlphanumerics(this IEnumerable<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterAlphanumeric());

    public static IEnumerable<string?>? FilterAlphanumerics(this ICollection<string?>? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterAlphanumeric());

    public static IEnumerable<string?>? FilterAlphanumerics(params string?[]? input) => input.IsNullEmpty() ? input : input.Select(x => x.FilterAlphanumeric());
}