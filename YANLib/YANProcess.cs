using static System.Diagnostics.Process;

namespace YANLib;

public static partial class YANProcess
{
    /// <summary>
    /// A extension method that kills all processes by the specified name.
    /// </summary>
    /// <param name="name">The name of the processes to be killed.</param>
    public static void KillAllProcessesByName(this string name)
    {
        while (GetProcessesByName(name)?.Length > 0)
        {
            GetProcessesByName(name)?.FirstOrDefault()?.Kill();
        }
    }
}
