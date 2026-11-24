using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for process management.
/// </summary>
/// <remarks>
/// This class contains methods for managing system processes, including killing processes by name, with or without their process trees,
/// and with a cancellation token that limits the wait for them to exit.
/// </remarks>
public static partial class YANProcess
{
    /// <summary>
    /// Kills all processes with the specified name.
    /// </summary>
    /// <param name="name">
    /// The name of the processes to kill, or a path to their executable (only the file name is used). If <c>null</c> or whitespace, or if no file name is left
    /// (for example a directory path or <c>".exe"</c>), no action is taken.
    /// </param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <exception cref="Exception">
    /// When a process cannot be killed (for example <see cref="System.ComponentModel.Win32Exception"/> for access denied, <see cref="AggregateException"/> when part of its
    /// process tree could not be killed, or <see cref="InvalidOperationException"/> when it is an ancestor of the calling process), the other processes are still killed and
    /// every process handle is disposed; the first exception is then rethrown with its original type.
    /// </exception>
    /// <remarks>
    /// <para>
    /// The file name is matched as given, so a process whose name contains a dot (for example <c>my.app</c>) can be targeted. Only when no process has that name and the name has
    /// an extension (for example <c>"notepad.exe"</c> or <c>"MyApp.dll"</c>), the processes named without the extension are killed instead.
    /// The calling process itself is never killed, even when it has the specified name.
    /// </para>
    /// <para>
    /// Each process is killed with <see cref="Process.Kill(bool)"/> and <c>entireProcessTree: true</c>: all of its descendant processes are killed too,
    /// whatever their names. If a matching process is an ancestor of the calling process (for example the shell that started it), <see cref="Process.Kill(bool)"/> refuses
    /// to kill its tree with an <see cref="InvalidOperationException"/>: that process keeps running and nothing is killed through it, so the calling process survives too.
    /// The other matching processes are still killed, and the refusal is reported like any other failure (see the exception description).
    /// </para>
    /// <para>
    /// Every matching process is signalled first; then it waits for each to exit before completing, without a time limit. To limit the wait, use
    /// <see cref="KillAllProcessesByName(string?, CancellationToken)"/>; to keep the descendant processes running, use
    /// <see cref="KillAllProcessesByName(string?, bool, CancellationToken)"/> with <c>entireProcessTree: false</c>.
    /// </para>
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByName(this string? name) => await name.KillAllProcessesByNameImplement();

    /// <summary>
    /// Kills all processes with the specified name, each with its entire process tree, and waits for them to exit until the cancellation token is canceled.
    /// </summary>
    /// <param name="name">
    /// The name of the processes to kill, or a path to their executable (only the file name is used). If <c>null</c> or whitespace, or if no file name is left
    /// (for example a directory path or <c>".exe"</c>), no action is taken.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that cancels the wait for the processes to exit. For a timeout, pass the token of a <see cref="CancellationTokenSource"/> created with
    /// <see cref="CancellationTokenSource(TimeSpan)"/>.
    /// </param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <exception cref="OperationCanceledException">
    /// <paramref name="cancellationToken"/> was canceled before the processes exited. If it was already canceled when the method was called, nothing is killed;
    /// otherwise every matching process has been signalled and stays signalled, and only the wait stops. Every process handle is disposed in both cases.
    /// A failure to kill a process takes precedence: that exception is thrown instead (see the next exception description).
    /// </exception>
    /// <exception cref="Exception">
    /// When a process cannot be killed (for example <see cref="System.ComponentModel.Win32Exception"/> for access denied, <see cref="AggregateException"/> when part of its
    /// process tree could not be killed, or <see cref="InvalidOperationException"/> when it is an ancestor of the calling process), the other processes are still killed and
    /// every process handle is disposed; the first exception is then rethrown with its original type.
    /// </exception>
    /// <remarks>
    /// This method behaves like <see cref="KillAllProcessesByName(string?)"/> (same name matching, each process killed with <c>entireProcessTree: true</c>, the calling
    /// process never killed), except that the wait for the processes to exit ends when <paramref name="cancellationToken"/> is canceled, for example for a process that
    /// does not exit after it is signalled (one stuck in an uninterruptible state, or a zombie that its parent does not reap).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByName(this string? name, CancellationToken cancellationToken)
        => await name.KillAllProcessesByNameImplement(cancellationToken: cancellationToken);

    /// <summary>
    /// Kills all processes with the specified name, with or without their process trees, and waits for them to exit until the cancellation token is canceled.
    /// </summary>
    /// <param name="name">
    /// The name of the processes to kill, or a path to their executable (only the file name is used). If <c>null</c> or whitespace, or if no file name is left
    /// (for example a directory path or <c>".exe"</c>), no action is taken.
    /// </param>
    /// <param name="entireProcessTree">
    /// <c>true</c> to kill each matching process together with all of its descendant processes, as <see cref="KillAllProcessesByName(string?)"/> does;
    /// <c>false</c> to kill only the matching processes, so that their descendant processes keep running.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that cancels the wait for the processes to exit. For a timeout, pass the token of a <see cref="CancellationTokenSource"/> created with
    /// <see cref="CancellationTokenSource(TimeSpan)"/>. The default never cancels.
    /// </param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <exception cref="OperationCanceledException">
    /// <paramref name="cancellationToken"/> was canceled before the processes exited. If it was already canceled when the method was called, nothing is killed;
    /// otherwise every matching process has been signalled and stays signalled, and only the wait stops. Every process handle is disposed in both cases.
    /// A failure to kill a process takes precedence: that exception is thrown instead (see the next exception description).
    /// </exception>
    /// <exception cref="Exception">
    /// When a process cannot be killed (for example <see cref="System.ComponentModel.Win32Exception"/> for access denied, or, with <paramref name="entireProcessTree"/>
    /// <c>true</c>, <see cref="AggregateException"/> when part of its process tree could not be killed and <see cref="InvalidOperationException"/> when it is an ancestor of
    /// the calling process), the other processes are still killed and every process handle is disposed; the first exception is then rethrown with its original type.
    /// </exception>
    /// <remarks>
    /// <para>
    /// The name is matched as described for <see cref="KillAllProcessesByName(string?)"/>: the file name as given first, then without its extension if nothing matched.
    /// The calling process itself is never killed, even when it has the specified name.
    /// </para>
    /// <para>
    /// With <paramref name="entireProcessTree"/> <c>true</c>, each process is killed with <see cref="Process.Kill(bool)"/> and <c>entireProcessTree: true</c>, exactly as
    /// <see cref="KillAllProcessesByName(string?)"/> does, including the refusal (<see cref="InvalidOperationException"/>) for a matching ancestor of the calling process.
    /// With <c>false</c>, each process is killed with <see cref="Process.Kill()"/>: its descendant processes keep running (on Linux they are re-parented), and a matching
    /// process that is an ancestor of the calling process (for example the shell that started it) is not refused but killed on its own; the calling process keeps running.
    /// </para>
    /// <para>
    /// Every matching process is signalled before the method waits for any of them to exit; then it waits for each to exit until
    /// <paramref name="cancellationToken"/> is canceled.
    /// </para>
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByName(this string? name, bool entireProcessTree, CancellationToken cancellationToken = default)
        => await name.KillAllProcessesByNameImplement(entireProcessTree, cancellationToken);

    /// <summary>
    /// Gets the processes that <see cref="KillAllProcessesByName(string?)"/> would kill for the specified name or path, without killing them.
    /// </summary>
    /// <param name="processNameOrPath">The process name, or a path to its executable (only the file name is used).</param>
    /// <returns>The matching processes (an empty array when no file name is left). The caller must dispose them.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Process[] GetProcessesByFileName(this string? processNameOrPath) => processNameOrPath.GetProcessesByFileNameImplement();

    /// <summary>
    /// Kills every process in the sequence (with its process tree, unless <paramref name="entireProcessTree"/> is <c>false</c>) except the calling process,
    /// then waits for each to exit and disposes every process handle.
    /// </summary>
    /// <param name="processes">The processes to kill.</param>
    /// <param name="entireProcessTree"><c>true</c> to kill each process with its descendants; <c>false</c> to kill only the process.</param>
    /// <param name="cancellationToken">A token that cancels the wait; if it is already canceled, nothing is killed.</param>
    /// <returns>
    /// A task that represents the asynchronous kill operation; it rethrows the first failure after all processes have been tried (a canceled wait comes after
    /// every failure to kill).
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task KillAndDispose(this IEnumerable<Process> processes, bool entireProcessTree = true, CancellationToken cancellationToken = default)
        => processes.KillAndDisposeImplement(entireProcessTree, cancellationToken);
}
