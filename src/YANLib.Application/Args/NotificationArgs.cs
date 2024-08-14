using System;
using Volo.Abp.BackgroundJobs;

namespace YANLib.Args;

[BackgroundJobName("notifications")]
public sealed record NotificationArgs(string? Message, Guid SentBy);
