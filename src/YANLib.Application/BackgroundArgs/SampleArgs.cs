using Volo.Abp.BackgroundJobs;

namespace YANLib.BackgroundArgs;

[BackgroundJobName("sample")]
public sealed record SampleArgs(string Message);
