using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANProcess
{
    #region Private

    // A null, empty or white-space name is skipped; it no longer cancels the other names.
    private static async Task KillAll(IEnumerable<string?>? names, bool entireProcessTree, CancellationToken cancellationToken)
    {
        if (names is null)
        {
            return;
        }

        await WhenAll(names.Select(name => KillAndDisposeAsync(name, entireProcessTree, cancellationToken))).ConfigureAwait(false);
    }

    #endregion

    // A token that is already cancelled gives a cancelled task and kills nothing. This is the only check before the kills:
    // a token cancelled after it (while the names are read or looked up) still lets every matching process be killed and
    // only stops the waiting. Task.WhenAll reports a failure to kill (a faulted name) before a cancelled wait (a cancelled name).
    internal static Task KillAllProcessesByNamesImplement(this IEnumerable<string?>? names, bool entireProcessTree = true, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested ? FromCanceled(cancellationToken) : KillAll(names, entireProcessTree, cancellationToken);

    internal static Task KillAllProcessesByNamesImplement(params string?[]? names) => names.KillAllProcessesByNamesImplement();
}
