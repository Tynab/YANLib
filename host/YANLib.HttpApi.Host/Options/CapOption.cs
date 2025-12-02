namespace YANLib.Options;

public sealed class CapOption
{
    public string? ConnectionString { get; set; }

    public string? DBName { get; set; }

    public string? DefaultGroupName { get; set; }

    public RabbitMqSection RabbitMQ { get; set; } = new();

    public sealed class RabbitMqSection
    {
        public string? HostName { get; set; }

        public int Port { get; set; } = 5672;

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? VirtualHost { get; set; } = "/";

        public string? ExchangeName { get; set; }
    }
}
