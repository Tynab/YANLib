using YANLib.Object;
using YANLib.Text;

namespace YANLib.Ultimate.Core;

public static partial class YANText
{
    public static IEnumerable<string?> Lowers(this IEnumerable<string?>? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Lower();
        }
    }

    public static IEnumerable<string?> Lowers(this ICollection<string?>? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Lower();
        }
    }

    public static IEnumerable<string?> Lowers(params string?[]? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Lower();
        }
    }

    public static IEnumerable<string?> LowerInvariants(this IEnumerable<string?>? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.LowerInvariant();
        }
    }

    public static IEnumerable<string?> LowerInvariants(this ICollection<string?>? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.LowerInvariant();
        }
    }

    public static IEnumerable<string?> LowerInvariants(params string?[]? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.LowerInvariant();
        }
    }

    public static IEnumerable<string?> Uppers(this IEnumerable<string?>? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Upper();
        }
    }

    public static IEnumerable<string?> Uppers(this ICollection<string?>? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Upper();
        }
    }

    public static IEnumerable<string?> Uppers(params string?[]? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Upper();
        }
    }

    public static IEnumerable<string?> UpperInvariants(this IEnumerable<string?>? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.UpperInvariant();
        }
    }

    public static IEnumerable<string?> UpperInvariants(this ICollection<string?>? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.UpperInvariant();
        }
    }

    public static IEnumerable<string?> UpperInvariants(params string?[]? strs)
    {
        if (strs.IsNullOEmpty())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.UpperInvariant();
        }
    }
}
