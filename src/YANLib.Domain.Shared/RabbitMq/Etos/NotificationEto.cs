using System;
using Volo.Abp.EventBus;
using static YANLib.RabbitMq.RabbitMqTopic;

namespace YANLib.RabbitMq.Etos;

[EventName(NOTIF_SEND)]
public sealed record NotificationEto(string? Message, Guid SentBy);
