using YANLib.Core;

namespace YANLib.Ultimate.Nullable;

public static partial class YANText
{
    public static IEnumerable<char?>? Lowers(this IEnumerable<char?>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.Lower(c);
        }
    }

    public static IEnumerable<char?>? Lowers(this ICollection<char?>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.Lower(c);
        }
    }

    public static IEnumerable<char?>? Lowers(params char?[]? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.Lower(c);
        }
    }

    public static IEnumerable<char?>? LowerInvariants(this IEnumerable<char?>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.LowerInvariant(c);
        }
    }

    public static IEnumerable<char?>? LowerInvariants(this ICollection<char?>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.LowerInvariant(c);
        }
    }

    public static IEnumerable<char?>? LowerInvariants(params char?[]? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.LowerInvariant(c);
        }
    }

    public static IEnumerable<char?>? Uppers(this IEnumerable<char?>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.Upper(c);
        }
    }

    public static IEnumerable<char?>? Uppers(this ICollection<char?>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.Upper(c);
        }
    }

    public static IEnumerable<char?>? Uppers(params char?[]? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.Upper(c);
        }
    }

    public static IEnumerable<char?>? UpperInvariants(this IEnumerable<char?>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.UpperInvariant(c);
        }
    }

    public static IEnumerable<char?>? UpperInvariants(this ICollection<char?>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.UpperInvariant(c);
        }
    }

    public static IEnumerable<char?>? UpperInvariants(params char?[]? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return YANLib.Nullable.YANText.UpperInvariant(c);
        }
    }
}
