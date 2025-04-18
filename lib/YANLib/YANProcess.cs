using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods to asynchronously terminate Windows processes by their names.
/// This includes attempts to close the main window before forcing a kill.
/// </summary>
public static partial class YANProcess
{
    /// <summary>
    /// Asynchronously closes or kills all processes whose name matches <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The name of the process to terminate (without the .exe extension).</param>
    /// <returns>A <see cref="Task"/> that completes when all matching processes have exited.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByName(this string? name) => await name.KillAllProcessesByNameImplement();

    /// <summary>
    /// Asynchronously closes or kills all processes whose names match any element in <paramref name="names"/>.
    /// </summary>
    /// <param name="names">A collection of process names to terminate.</param>
    /// <returns>A <see cref="Task"/> that completes when all matching processes have exited.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByNames(this IEnumerable<string?>? names) => await names.KillAllProcessesByNamesImplement();

    /// <summary>
    /// Asynchronously closes or kills all processes whose names match any of the specified <paramref name="names"/>.
    /// </summary>
    /// <param name="names">An array of process names to terminate.</param>
    /// <returns>A <see cref="Task"/> that completes when all matching processes have exited.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByNames(params string?[]? names) => await names.KillAllProcessesByNamesImplement();
}
