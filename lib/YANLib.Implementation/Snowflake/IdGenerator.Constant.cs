namespace YANLib.Implementation.Snowflake;

public partial class IdGenerator
{
    internal const long TIMESTAMP_EPOCH = 1_672_531_200_000;

    private const int WORKER_ID_BITS = 5;
    private const int DATACENTER_ID_BITS = 5;
    private const int SEQUENCE_BITS = 13;

    private const long MAX_WORKER_ID = -1 ^ (-1 << WORKER_ID_BITS);
    private const long MAX_DATACENTER_ID = -1 ^ (-1 << DATACENTER_ID_BITS);
    private const long MAX_SEQUENCE = -1 ^ (-1 << SEQUENCE_BITS);

    private const int WORKER_ID_SHIFT = SEQUENCE_BITS;
    private const int DATACENTER_ID_SHIFT = SEQUENCE_BITS + WORKER_ID_BITS;
    private const int TIMESTAMP_LEFT_SHIFT = SEQUENCE_BITS + WORKER_ID_BITS + DATACENTER_ID_BITS;

    private const string BASE_ALPHABETIC_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static readonly int BASE_ALPHABETIC_CHARS_LENGTH = BASE_ALPHABETIC_CHARS.Length;

    private const string BASE_ALPHANUMERIC_CHARS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static readonly int BASE_ALPHANUMERIC_CHARS_LENGTH = BASE_ALPHANUMERIC_CHARS.Length;
}
