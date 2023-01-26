using static System.Diagnostics.Process;

namespace YANLib;

public static partial class YANProcess
{
    /// <summary>
    /// Kill all process with name.
    /// </summary>
    /// <param name="name">Process name.</param>
    public static void ProcessKiller(this string name)
    {
        while (GetProcessesByName(name).Length > 0)
        {
            GetProcessesByName(name).FirstOrDefault()?.Kill();
        }
    }
}
