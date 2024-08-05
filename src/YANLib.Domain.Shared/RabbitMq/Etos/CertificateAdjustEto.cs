using Volo.Abp.EventBus;
using static YANLib.RabbitMq.RabbitMqTopic;

namespace YANLib.RabbitMq.Etos;

[EventName(ADJ_CRT)]
public sealed class CertificateAdjustEto
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public double? GPA { get; set; }

    public string? DeveloperId { get; set; }
}
