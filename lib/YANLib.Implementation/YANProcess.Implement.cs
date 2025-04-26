using System.ComponentModel;
using System.Diagnostics;

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
    internal static Task KillAllProcessesByNameImplement(this string? name) => new[] { name }.KillAllProcessesByNamesImplement();
}
