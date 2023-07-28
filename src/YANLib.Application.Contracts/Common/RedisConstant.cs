namespace YANLib.Common;

public readonly struct RedisConstant
{
    public const string YANLIB_PREF = "yanlib";
    public const string SMP_PREF = "sample";
    public const string DEV_TYPE_PREF = "developtype";

    public static readonly string DEV_TYPE_GRP = $"{YANLIB_PREF}:{SMP_PREF}:{DEV_TYPE_PREF}";
}
