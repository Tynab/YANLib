using static System.Diagnostics.Process;
using static System.Threading.Tasks.Task;

namespace YANLib;

public static partial class YANProcess
{
    /// <summary>
    /// Asynchronously kills all running processes with the specified name by first attempting to close their main window, and if that fails, force-killing them.
    /// After attempting to close the processes, this method waits for one second before force-killing any remaining processes to give them a chance to exit gracefully.
    /// </summary>
    /// <param name="name">The name of the processes to kill.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task KillAllProcessesByName(this string name)
    {
        await WhenAll(GetProcessesByName(name).Select(p =>
        {
            if (!p.CloseMainWindow())
            {
                p.Kill();
            }
            return p.WaitForExitAsync();
        }));
    }

    /// <summary>
    /// Asynchronously kills all running processes with any of the specified names by first attempting to close their main window, and if that fails, force-killing them.
    /// After attempting to close the processes, this method waits for one second before force-killing any remaining processes to give them a chance to exit gracefully.
    /// </summary>
    /// <param name="names">The names of the processes to kill.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task KillAllProcessesByNames(params string[] names)
    {
        await WhenAll(names.SelectMany(name => GetProcessesByName(name)).Select(p =>
        {
            if (!p.CloseMainWindow())
            {
                p.Kill();
            }
            return p.WaitForExitAsync();
        }));
    }
}
