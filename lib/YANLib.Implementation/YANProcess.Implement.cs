using System.ComponentModel;
using System.Diagnostics;
using YANLib.Implementation.Object;
using YANLib.Implementation.Text;
using static System.Diagnostics.Process;
using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANProcess
{
    #region Private
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static async Task KillAndDisposeAsync(Process proc, CancellationToken cancellation)
    {
        try
        {
            if (!proc.CloseMainWindow())
            {
                proc.Kill();
            }

            await proc.WaitForExitAsync(cancellation);
        }
        catch (Exception ex) when (ex is InvalidOperationException or Win32Exception)
        {
            throw new InvalidOperationException($"Failed to kill process {proc.Id} ({proc.ProcessName}).", ex);
        }
        finally
        {
            proc.Dispose();
        }
    }
    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static async Task KillAllProcessesByNamesImplement(this IEnumerable<string?>? names, CancellationToken cancellation = default)
    {
        if (names.IsNullEmptyImplement() || names.AnyNullWhiteSpaceImplement())
        {
            return;
        }

        await WhenAll(names.SelectMany(GetProcessesByName).Select(p => KillAndDisposeAsync(p, cancellation)));
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task KillAllProcessesByNamesImplement(params string?[]? names) => names.KillAllProcessesByNamesImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task KillAllProcessesByNameImplement(this string? name) => new[] { name }.KillAllProcessesByNamesImplement();
}
