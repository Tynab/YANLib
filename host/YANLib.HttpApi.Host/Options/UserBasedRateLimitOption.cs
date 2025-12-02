using System.Threading.RateLimiting;
using static System.Threading.RateLimiting.QueueProcessingOrder;

namespace YANLib.Options;

public sealed class UserBasedRateLimitOption
{
    public Auth Authenticated { get; set; } = new();

    public Anon Anonymous { get; set; } = new();

    public sealed class Auth
    {
        public int TokenLimit { get; set; }

        public int TokensPerPeriod { get; set; }

        public int ReplenishmentPeriodSeconds { get; set; }

        public int QueueLimit { get; set; }

        public QueueProcessingOrder QueueProcessingOrder { get; set; } = OldestFirst;

        public bool AutoReplenishment { get; set; } = true;
    }

    public sealed class Anon
    {
        public int PermitLimit { get; set; }

        public int WindowSeconds { get; set; }

        public int SegmentsPerWindow { get; set; }

        public int QueueLimit { get; set; }

        public QueueProcessingOrder QueueProcessingOrder { get; set; } = OldestFirst;
    }
}
