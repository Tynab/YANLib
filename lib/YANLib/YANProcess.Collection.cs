using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for process management on collections.
/// </summary>
/// <remarks>
/// This partial class contains methods for managing multiple system processes at once. The overloads that take an <c>entireProcessTree</c> choice or a
/// cancellation token are generic in the type of the name collection, so that no existing call of the <c>params</c> overload changes meaning.
/// </remarks>
public static partial class YANProcess
{
    /// <summary>
    /// Kills all processes with names matching any of the specified names.
    /// </summary>
    /// <param name="names">
    /// The collection of process names (or executable paths) to kill. If <c>null</c> or empty, no action is taken; <c>null</c> or whitespace elements are skipped
    /// and the other names are still processed.
    /// </param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <exception cref="Exception">
    /// When a process cannot be killed (for example <see cref="InvalidOperationException"/> when it is an ancestor of the calling process), the other processes
    /// (for all names) are still killed and every process handle is disposed; then the first exception is rethrown with its original type.
    /// </exception>
    /// <remarks>
    /// Each name is matched as described for <see cref="KillAllProcessesByName(string?)"/>: the file name as given first, then without its extension if nothing matched.
    /// The calling process is never killed. Each process is killed together with its entire process tree (all descendants, whatever their names), except a matching
    /// process that is an ancestor of the calling process: .NET refuses to kill that tree, so that process keeps running and the refusal counts as a failure.
    /// Every matching process is signalled first; then it waits for each to exit before completing, without a time limit (to limit the wait, use
    /// <see cref="KillAllProcessesByNames{TNames}(TNames, CancellationToken)"/>; to keep descendant processes running, use
    /// <see cref="KillAllProcessesByNames{TNames}(TNames, bool, CancellationToken)"/>).
    /// The operation is performed in parallel for all process names.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByNames(this IEnumerable<string?>? names) => await names.KillAllProcessesByNamesImplement();

    /// <summary>
    /// Kills all processes with names matching any of the specified names, each with its entire process tree, and waits for them to exit until the cancellation
    /// token is canceled.
    /// </summary>
    /// <typeparam name="TNames">
    /// The type of the name collection, inferred from the argument (for example <see cref="List{T}"/> of <see cref="string"/> or an array). A <c>null</c> or
    /// <c>default</c> literal cannot be inferred: pass a typed variable or cast it, for example <c>((IEnumerable&lt;string?&gt;?)null)</c>.
    /// </typeparam>
    /// <param name="names">
    /// The collection of process names (or executable paths) to kill. If <c>null</c> or empty, no action is taken; <c>null</c> or whitespace elements are skipped
    /// and the other names are still processed.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that cancels the wait for the processes to exit. For a timeout, pass the token of a <see cref="CancellationTokenSource"/> created with
    /// <see cref="CancellationTokenSource(TimeSpan)"/>.
    /// </param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <exception cref="OperationCanceledException">
    /// <paramref name="cancellationToken"/> was canceled before the processes exited. If it was already canceled when the method was called, nothing is killed;
    /// otherwise the matching processes have been signalled and stay signalled, and only the wait stops. Every process handle is disposed in both cases.
    /// A failure to kill a process takes precedence: that exception is thrown instead (see the next exception description).
    /// </exception>
    /// <exception cref="Exception">
    /// When a process cannot be killed (for example <see cref="InvalidOperationException"/> when it is an ancestor of the calling process), the other processes
    /// (for all names) are still killed and every process handle is disposed; then the first exception is rethrown with its original type.
    /// </exception>
    /// <remarks>
    /// This method behaves like <see cref="KillAllProcessesByNames(IEnumerable{string?})"/>, except that the wait for the processes to exit ends when
    /// <paramref name="cancellationToken"/> is canceled.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByNames<TNames>(this TNames? names, CancellationToken cancellationToken) where TNames : IEnumerable<string?>
        => await names.KillAllProcessesByNamesImplement(cancellationToken: cancellationToken);

    /// <summary>
    /// Kills all processes with names matching any of the specified names, with or without their process trees, and waits for them to exit until the
    /// cancellation token is canceled.
    /// </summary>
    /// <typeparam name="TNames">
    /// The type of the name collection, inferred from the argument (for example <see cref="List{T}"/> of <see cref="string"/> or an array). A <c>null</c> or
    /// <c>default</c> literal cannot be inferred: pass a typed variable or cast it, for example <c>((IEnumerable&lt;string?&gt;?)null)</c>.
    /// </typeparam>
    /// <param name="names">
    /// The collection of process names (or executable paths) to kill. If <c>null</c> or empty, no action is taken; <c>null</c> or whitespace elements are skipped
    /// and the other names are still processed.
    /// </param>
    /// <param name="entireProcessTree">
    /// <c>true</c> to kill each matching process together with all of its descendant processes, as <see cref="KillAllProcessesByNames(IEnumerable{string?})"/> does;
    /// <c>false</c> to kill only the matching processes, so that their descendant processes keep running.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that cancels the wait for the processes to exit. For a timeout, pass the token of a <see cref="CancellationTokenSource"/> created with
    /// <see cref="CancellationTokenSource(TimeSpan)"/>. The default never cancels.
    /// </param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <exception cref="OperationCanceledException">
    /// <paramref name="cancellationToken"/> was canceled before the processes exited. If it was already canceled when the method was called, nothing is killed;
    /// otherwise the matching processes have been signalled and stay signalled, and only the wait stops. Every process handle is disposed in both cases.
    /// A failure to kill a process takes precedence: that exception is thrown instead (see the next exception description).
    /// </exception>
    /// <exception cref="Exception">
    /// When a process cannot be killed (for example, with <paramref name="entireProcessTree"/> <c>true</c>, <see cref="InvalidOperationException"/> when it is an
    /// ancestor of the calling process), the other processes (for all names) are still killed and every process handle is disposed; then the first exception is
    /// rethrown with its original type.
    /// </exception>
    /// <remarks>
    /// Each name is matched as described for <see cref="KillAllProcessesByName(string?)"/>, and each matching process is killed as described for
    /// <see cref="KillAllProcessesByName(string?, bool, CancellationToken)"/>: with <c>entireProcessTree: false</c>, descendant processes keep running and a matching
    /// ancestor of the calling process is killed on its own instead of being refused. The calling process is never killed.
    /// The matching processes of each name are signalled before the method waits for them to exit; the names are processed in parallel.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByNames<TNames>(this TNames? names, bool entireProcessTree, CancellationToken cancellationToken = default) where TNames : IEnumerable<string?>
        => await names.KillAllProcessesByNamesImplement(entireProcessTree, cancellationToken);

    /// <summary>
    /// Kills all processes with names matching any of the specified names.
    /// </summary>
    /// <param name="names">
    /// The array of process names (or executable paths) to kill. If <c>null</c> or empty, no action is taken; <c>null</c> or whitespace elements are skipped
    /// and the other names are still processed.
    /// </param>
    /// <returns>A task that represents the asynchronous kill operation.</returns>
    /// <exception cref="Exception">
    /// When a process cannot be killed (for example <see cref="InvalidOperationException"/> when it is an ancestor of the calling process), the other processes
    /// (for all names) are still killed and every process handle is disposed; then the first exception is rethrown with its original type.
    /// </exception>
    /// <remarks>
    /// This method provides a convenient way to kill processes by name without having to explicitly create a collection.
    /// Each name is matched as described for <see cref="KillAllProcessesByName(string?)"/>: the file name as given first, then without its extension if nothing matched.
    /// The calling process is never killed. Each process is killed together with its entire process tree (all descendants, whatever their names), except a matching
    /// process that is an ancestor of the calling process: .NET refuses to kill that tree, so that process keeps running and the refusal counts as a failure.
    /// Every matching process is signalled first; then it waits for each to exit before completing, without a time limit (the <c>entireProcessTree</c> and
    /// cancellation overloads take a collection, for example an array: <c>new[] { "a", "b" }.KillAllProcessesByNames(false, token)</c>).
    /// The operation is performed in parallel for all process names.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task KillAllProcessesByNames(params string?[]? names) => await names.KillAllProcessesByNamesImplement();
}
