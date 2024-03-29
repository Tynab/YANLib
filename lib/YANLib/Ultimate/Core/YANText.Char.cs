﻿using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANText
{
    public static IEnumerable<char> GenerateRandomCharacters(object? size)
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.Core.YANText.GenerateRandomCharacter();
        }
    }

    public static IEnumerable<char> Lowers(this IEnumerable<char>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.Lower();
        }
    }

    public static IEnumerable<char> Lowers(this ICollection<char>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.Lower();
        }
    }

    public static IEnumerable<char> Lowers(params char[]? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.Lower();
        }
    }

    public static IEnumerable<char> LowerInvariants(this IEnumerable<char>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.LowerInvariant();
        }
    }

    public static IEnumerable<char> LowerInvariants(this ICollection<char>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.LowerInvariant();
        }
    }

    public static IEnumerable<char> LowerInvariants(params char[]? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.LowerInvariant();
        }
    }

    public static IEnumerable<char> Uppers(this IEnumerable<char>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.Upper();
        }
    }

    public static IEnumerable<char> Uppers(this ICollection<char>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.Upper();
        }
    }

    public static IEnumerable<char> Uppers(params char[]? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.Upper();
        }
    }

    public static IEnumerable<char> UpperInvariants(this IEnumerable<char>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.UpperInvariant();
        }
    }

    public static IEnumerable<char> UpperInvariants(this ICollection<char>? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.UpperInvariant();
        }
    }

    public static IEnumerable<char> UpperInvariants(params char[]? cs)
    {
        if (cs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var c in cs)
        {
            yield return c.UpperInvariant();
        }
    }
}
