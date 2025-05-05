using System;
using Volo.Abp.BackgroundJobs;

namespace YANLib.BackgroundArgs;

[BackgroundJobName("notification")]
public sealed record NotificationArgs(string? Message, Guid SentBy);
