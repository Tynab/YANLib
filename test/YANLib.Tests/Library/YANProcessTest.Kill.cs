using System.Diagnostics;
using System.Text;

namespace YANLib.Tests.Library;

// Starts copies of /bin/sleep (and of /bin/sh) under unique names (at most 15 characters, the Linux limit for process names)
// in a temporary directory, and on Dispose kills whatever is still running and deletes the directory, also when a test fails.
// Supported only where /bin/sleep exists (Linux) and a renamed copy of it can sleep (see SleepArguments); the shell fixtures
// also need /bin/sh. The tests return early elsewhere.
internal sealed class SleepProcesses : IDisposable
{
    private const string SLEEP_PATH = "/bin/sleep";
    private const string SHELL_PATH = "/bin/sh";

    // Generous: the machine may be busy; the waits end as soon as the state is reached.
    private static readonly TimeSpan StateTimeout = TimeSpan.FromSeconds(30);

    private readonly List<(int Id, string Name)> _started = [];
    private readonly List<string> _startedIndirectly = [];
    private readonly List<(string Name, Process Shell, StringBuilder Errors)> _shells = [];

    // How a renamed copy of /bin/sleep can be made to sleep under its own name. A plain sleep binary needs nothing. A multi-call
    // coreutils binary (to which /bin/sleep links on some systems, e.g. the GitHub ubuntu-latest image) picks its program by file
    // name: uutils accepts a name that ends in "-sleep", other builds take the program name as the first argument. Variants
    // that rename the process (GNU's --coreutils-prog=) are rejected, because the tests find processes by their unique name.
    // null: no variant works on this machine (see SleepProbeReport).
    private static readonly Lazy<(string Suffix, string[] Arguments)?> SleepVariant = new(ProbeSleepVariant);

    private static string _sleepProbeReport = "not probed";

    // What the probe found, for the message of a test that requires the fixture.
    public static string SleepProbeReport
    {
        get
        {
            _ = SleepVariant.Value;

            return _sleepProbeReport;
        }
    }

    private static string[] SleepArguments => SleepVariant.Value!.Value.Arguments;

    public SleepProcesses()
    {
        IsSupported = OperatingSystem.IsLinux() && File.Exists(SLEEP_PATH) && SleepVariant.Value is not null;
        IsShellSupported = IsSupported && File.Exists(SHELL_PATH);
        Directory = Path.Combine(Path.GetTempPath(), $"yanlib-process-{Guid.NewGuid():N}");

        if (IsSupported)
        {
            _ = System.IO.Directory.CreateDirectory(Directory);
        }
    }

    public bool IsSupported { get; }

    public bool IsShellSupported { get; }

    public string Directory { get; }

    // The sleep arguments for a shell command line, each preceded by a space (they contain no characters the shell interprets).
    private static string SleepShellArguments => string.Concat(SleepArguments.Select(x => $" {x}"));

    // Starts a renamed copy of /bin/sleep with each candidate (name suffix, arguments) and returns the first whose process runs
    // under the copy's own name; the probe processes are killed. Records what happened in _sleepProbeReport.
    private static (string Suffix, string[] Arguments)? ProbeSleepVariant()
    {
        if (!OperatingSystem.IsLinux() || !File.Exists(SLEEP_PATH))
        {
            _sleepProbeReport = $"not Linux or no {SLEEP_PATH}";

            return null;
        }

        var report = new StringBuilder($"{SLEEP_PATH} -> {Path.GetFullPath(new FileInfo(SLEEP_PATH).ResolveLinkTarget(true)?.FullName ?? SLEEP_PATH)}; ");
        var directory = Path.Combine(Path.GetTempPath(), $"yanlib-sleep-probe-{Guid.NewGuid():N}");

        try
        {
            _ = System.IO.Directory.CreateDirectory(directory);

            (string Suffix, string[] Arguments)[] candidates = [("", []), ("-sleep", []), ("", ["sleep"]), ("", ["--coreutils-prog=sleep"])];

            foreach (var (suffix, arguments) in candidates)
            {
                var name = $"ysprobe{suffix}";
                var copy = Path.Combine(directory, name);

                if (!File.Exists(copy))
                {
                    File.Copy(SLEEP_PATH, copy);
                }

                var startInfo = new ProcessStartInfo(copy)
                {
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };

                foreach (var argument in arguments)
                {
                    startInfo.ArgumentList.Add(argument);
                }

                startInfo.ArgumentList.Add("10");

                using var process = Process.Start(startInfo)!;
                var stderr = process.StandardError.ReadToEndAsync();
                var deadline = Stopwatch.StartNew();
                var comm = "";

                // Accepted when the process runs under the copy's own name (it may first run briefly under another name).
                while (deadline.Elapsed < TimeSpan.FromSeconds(5) && !process.HasExited)
                {
                    try
                    {
                        var (current, state) = ReadStat($"/proc/{process.Id}/stat");

                        comm = current;

                        if (current == name && state is not ('Z' or 'X'))
                        {
                            Thread.Sleep(200);

                            if (!process.HasExited && ReadStat($"/proc/{process.Id}/stat").Comm == name)
                            {
                                process.Kill();
                                _ = process.WaitForExit(TimeSpan.FromSeconds(10));
                                _ = report.Append($"'{name}' {string.Join(' ', arguments)}: ok.");
                                _sleepProbeReport = report.ToString();

                                return (suffix, arguments);
                            }
                        }
                    }
                    catch (IOException)
                    {
                        // The process exited meanwhile.
                    }

                    Thread.Sleep(50);
                }

                if (!process.HasExited)
                {
                    process.Kill();
                    _ = process.WaitForExit(TimeSpan.FromSeconds(10));
                }

                var exit = process.HasExited ? process.ExitCode.ToString(System.Globalization.CultureInfo.InvariantCulture) : "running";

                _ = report.Append($"'{name}' {string.Join(' ', arguments)}: exit {exit}, ran as '{comm}', stderr [{(stderr.Wait(TimeSpan.FromSeconds(5)) ? stderr.Result.Trim() : "")}]; ");
            }

            _sleepProbeReport = report.Append("no variant works.").ToString();

            return null;
        }
        finally
        {
            try
            {
                System.IO.Directory.Delete(directory, recursive: true);
            }
            catch
            {
                // Best effort.
            }
        }
    }

    // A unique process name of at most 15 characters: prefix, hex digits and the suffix the sleep variant needs (see SleepVariant).
    public static string UniqueName(string prefix = "ys")
    {
        var suffix = SleepVariant.Value?.Suffix ?? "";

        return $"{prefix}{Guid.NewGuid():N}"[..(prefix.Length + Math.Min(8, 15 - prefix.Length - suffix.Length))] + suffix;
    }

    // Copies /bin/sleep as fileName and starts it for 60 seconds; the returned Process is owned by the caller.
    public Process Start(string fileName) => Start(fileName, new Process());

    public TProcess Start<TProcess>(string fileName, TProcess process) where TProcess : Process
    {
        process.StartInfo = new ProcessStartInfo(CopyOf(SLEEP_PATH, fileName))
        {
            UseShellExecute = false
        };

        foreach (var argument in SleepArguments)
        {
            process.StartInfo.ArgumentList.Add(argument);
        }

        process.StartInfo.ArgumentList.Add("60");

        _ = process.Start();
        _started.Add((process.Id, fileName));

        return process;
    }

    // Starts a copy of /bin/sh named parentName that starts a copy of /bin/sleep named childName for 60 seconds and waits
    // for it; returns the parent (owned by the caller) once the child is running, and the child's id.
    public (Process Parent, int ChildId) StartParentWithChild(string parentName, string childName)
    {
        var parent = StartShell(parentName, $"'{CopyOf(SLEEP_PATH, childName)}'{SleepShellArguments} 60 & wait");

        _startedIndirectly.Add(childName);

        return (parent, WaitForProcess(childName, state => state is not 'Z'));
    }

    // Leaves a zombie named zombieName: a copy of /bin/sh starts a copy of /bin/sleep named zombieName for 1 second, then
    // replaces itself (exec) with a copy of /bin/sleep named holderName, which never reaps the child that exits. As long as
    // the holder runs, the zombie never exits for .NET (it still exists for kill(pid, 0)), and Kill() does not fail on it.
    // Returns the zombie's id once it is a zombie.
    public int StartZombie(string holderName, string zombieName)
    {
        var zombiePath = CopyOf(SLEEP_PATH, zombieName);
        var holderPath = CopyOf(SLEEP_PATH, holderName);
        using var holder = StartShell(UniqueName("yh"), $"'{zombiePath}'{SleepShellArguments} 1 & exec '{holderPath}'{SleepShellArguments} 60");

        // After exec the started process carries the holder's name.
        _started[^1] = (holder.Id, holderName);
        _startedIndirectly.Add(zombieName);

        return WaitForProcess(zombieName, state => state is 'Z');
    }

    // Whether the process with this id still runs under this name: a zombie (state Z) or a dead process (X) has exited,
    // whether or not its parent has reaped it yet.
    public static bool IsRunning(int id, string name)
    {
        try
        {
            var (comm, state) = ReadStat($"/proc/{id}/stat");

            return comm == name && state is not ('Z' or 'X');
        }
        catch (IOException)
        {
            return false;
        }
    }

    // Polls until the process is no longer running; false if it still runs after the (generous) timeout.
    public static bool WaitUntilStopped(int id, string name)
    {
        var deadline = Stopwatch.StartNew();

        while (IsRunning(id, name))
        {
            if (deadline.Elapsed > StateTimeout)
            {
                return false;
            }

            Thread.Sleep(50);
        }

        return true;
    }

    // "pid (comm) state ppid ...", where comm may contain spaces and parentheses.
    private static (string Comm, char State) ReadStat(string path)
    {
        var stat = File.ReadAllText(path);
        var end = stat.LastIndexOf(')');

        return (stat[(stat.IndexOf('(') + 1)..end], stat[end + 2]);
    }

    // Polls /proc until a process with this name is in an accepted state; fails the test after the (generous) timeout.
    private int WaitForProcess(string name, Func<char, bool> acceptState)
    {
        var deadline = Stopwatch.StartNew();

        while (deadline.Elapsed <= StateTimeout)
        {
            foreach (var directory in System.IO.Directory.EnumerateDirectories("/proc"))
            {
                if (!int.TryParse(Path.GetFileName(directory), out var id))
                {
                    continue;
                }

                try
                {
                    var (comm, state) = ReadStat(Path.Combine(directory, "stat"));

                    if (comm == name && acceptState(state))
                    {
                        return id;
                    }
                }
                catch (IOException)
                {
                    // The process exited meanwhile.
                }
            }

            Thread.Sleep(50);
        }

        throw new TimeoutException($"No process named {name} reached the expected state. {Diagnostics()}");
    }

    private string CopyOf(string sourcePath, string fileName)
    {
        var path = Path.Combine(Directory, fileName);

        if (!File.Exists(path))
        {
            File.Copy(sourcePath, path);
        }

        return path;
    }

    private Process StartShell(string fileName, string command)
    {
        var errors = new StringBuilder();
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(CopyOf(SHELL_PATH, fileName))
            {
                ArgumentList =
                {
                    "-c",
                    command
                },
                UseShellExecute = false,
                RedirectStandardError = true
            }
        };

        // The shell's error output (for example a failed exec) goes into the diagnostics of a failed wait.
        process.ErrorDataReceived += (_, e) =>
        {
            if (e.Data is not null)
            {
                lock (errors)
                {
                    _ = errors.AppendLine(e.Data);
                }
            }
        };

        _ = process.Start();
        process.BeginErrorReadLine();
        _started.Add((process.Id, fileName));
        _shells.Add((fileName, process, errors));

        return process;
    }

    // What the shells did and which fixture processes exist, for the message of a failed wait.
    public string Diagnostics()
    {
        var text = new StringBuilder();

        foreach (var (name, shell, errors) in _shells)
        {
            string exit;

            try
            {
                exit = shell.HasExited ? $"exited with {shell.ExitCode}" : "running";
            }
            catch (Exception e)
            {
                exit = e.GetType().Name;
            }

            lock (errors)
            {
                _ = text.Append($"Shell {name} (pid {shell.Id}): {exit}; stderr: [{errors.ToString().Trim()}]. ");
            }
        }

        _ = text.Append("Processes: ");

        foreach (var directory in System.IO.Directory.EnumerateDirectories("/proc"))
        {
            if (!int.TryParse(Path.GetFileName(directory), out var id))
            {
                continue;
            }

            try
            {
                var stat = File.ReadAllText(Path.Combine(directory, "stat"));
                var (comm, state) = ReadStat(Path.Combine(directory, "stat"));
                var fields = stat[(stat.LastIndexOf(')') + 2)..].Split(' ');

                if (comm.StartsWith('y'))
                {
                    _ = text.Append($"{id} {comm} {state} ppid {fields[1]}; ");
                }
            }
            catch (IOException)
            {
                // The process exited meanwhile.
            }
        }

        return text.Append($"Directory {Directory}: [{string.Join(", ", System.IO.Directory.EnumerateFiles(Directory).Select(Path.GetFileName))}].").ToString();
    }

    public void Dispose()
    {
        // Processes started by the shells: unique names, so no unrelated process is touched.
        foreach (var name in _startedIndirectly)
        {
            foreach (var process in Process.GetProcessesByName(name))
            {
                using (process)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch
                    {
                        // Already exited.
                    }
                }
            }
        }

        foreach (var (id, name) in _started)
        {
            try
            {
                using var process = Process.GetProcessById(id);

                // Never kill a recycled process id.
                if (process.ProcessName == name)
                {
                    process.Kill();
                    _ = process.WaitForExit(TimeSpan.FromSeconds(10));
                }
            }
            catch
            {
                // Already exited.
            }
        }

        try
        {
            System.IO.Directory.Delete(Directory, recursive: true);
        }
        catch
        {
            // Best effort.
        }
    }
}

// Records whether Dispose was called.
internal sealed class DisposeTrackingProcess : Process
{
    public bool IsDisposed { get; private set; }

    protected override void Dispose(bool disposing)
    {
        IsDisposed = true;
        base.Dispose(disposing);
    }
}

public partial class YANProcessTest
{
    // Generous: the machine may be busy; a passing test returns as soon as the process has exited.
    private static readonly TimeSpan ExitTimeout = TimeSpan.FromSeconds(30);

    // The parent process id from /proc/self/stat ("pid (comm) state ppid ...", where comm may contain spaces and parentheses).
    // Init (pid 1) and an unreadable file give false.
    private static bool TryGetParentProcessId(out int parentId)
    {
        parentId = 0;

        try
        {
            var stat = File.ReadAllText("/proc/self/stat");
            var fields = stat[(stat.LastIndexOf(')') + 1)..].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return fields.Length > 1 && int.TryParse(fields[1], out parentId) && parentId > 1;
        }
        catch (IOException)
        {
            return false;
        }
        catch (UnauthorizedAccessException)
        {
            return false;
        }
    }

    // Yields the first name, then cancels the source before it yields the second: the token is canceled after the call has
    // started and before the second name is looked up.
    private static IEnumerable<string?> CancelBetween(string? first, CancellationTokenSource source, string? second)
    {
        yield return first;

        source.Cancel();

        yield return second;
    }

    #region Kill

    [Fact]
    public void SleepProcesses_OnLinuxCi_CanStartRenamedCopies_Process()
    {
        // On a Linux CI runner the fixture must work: otherwise every process test returns early and passes without a process
        // (this happened on the GitHub image, where /bin/sleep is a multi-call coreutils binary). Locally it may be unsupported.
        if (!OperatingSystem.IsLinux() || Environment.GetEnvironmentVariable("CI") is not "true")
        {
            return;
        }

        // Arrange & Act
        using var sleepers = new SleepProcesses();

        // Assert
        Assert.True(sleepers.IsShellSupported, SleepProcesses.SleepProbeReport);
    }

    [Fact]
    public async Task KillAllProcessesByName_RunningProcess_KillsIt_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        using var process = sleepers.Start(name);

        // Act
        await name.KillAllProcessesByName();

        // Assert
        Assert.True(process.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAllProcessesByName_NameWithDot_KillsIt_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName("ys.");
        using var process = sleepers.Start(name);

        // Act
        await name.KillAllProcessesByName();

        // Assert
        Assert.True(process.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAllProcessesByName_PathWithExtension_KillsProcessNamedWithoutExtension_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        using var process = sleepers.Start(name);

        // Act (like passing Assembly.Location of an app whose apphost has the assembly's name)
        await Path.Combine(sleepers.Directory, $"{name}.dll").KillAllProcessesByName();

        // Assert
        Assert.True(process.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAllProcessesByName_DottedNameWithExtension_KillsProcessNamedWithoutExtension_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName("ys.");
        using var process = sleepers.Start(name);

        // Act
        await $"{name}.exe".KillAllProcessesByName();

        // Assert
        Assert.True(process.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAllProcessesByNames_BlankNamesMixedIn_KillsTheValidNames_ProcessCollection()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name1 = SleepProcesses.UniqueName();
        var name2 = SleepProcesses.UniqueName();
        using var process1 = sleepers.Start(name1);
        using var process2 = sleepers.Start(name2);

        // Act
        await new[] { null, name1, string.Empty, "   ", name2 }.KillAllProcessesByNames();

        // Assert
        Assert.True(process1.WaitForExit(ExitTimeout));
        Assert.True(process2.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAllProcessesByName_SeveralProcessesWithSameName_KillsAll_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        using var process1 = sleepers.Start(name);
        using var process2 = sleepers.Start(name);

        // Act
        await name.KillAllProcessesByName();

        // Assert
        Assert.True(process1.WaitForExit(ExitTimeout));
        Assert.True(process2.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAndDispose_OneProcessFails_KillsTheOthersDisposesAllAndRethrowsFirstFailure_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        var failing = new DisposeTrackingProcess();
        var target = sleepers.Start(name, new DisposeTrackingProcess());
        var targetId = target.Id;

        // Act (a Process that was never started has no Id: reading it throws InvalidOperationException)
        _ = await Assert.ThrowsAsync<InvalidOperationException>(() => new Process[] { failing, target }.KillAndDispose());

        // Assert
        Assert.True(failing.IsDisposed);
        Assert.True(target.IsDisposed);

        try
        {
            using var stillRunning = Process.GetProcessById(targetId);

            Assert.True(stillRunning.ProcessName != name || stillRunning.WaitForExit(ExitTimeout));
        }
        catch (ArgumentException)
        {
            // The process no longer exists.
        }
    }

    [Fact]
    public async Task KillAndDispose_CurrentProcess_IsSkipped_Process()
    {
        // Arrange
        var current = Process.GetCurrentProcess();

        // Act
        var exception = await Record.ExceptionAsync(() => new[] { current }.KillAndDispose());

        // Assert (Kill(entireProcessTree: true) on the calling process would throw InvalidOperationException)
        Assert.Null(exception);
    }

    [Fact]
    public async Task KillAndDispose_AncestorOfCallingProcess_IsRefusedAndTheOthersAreStillKilled_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported || !TryGetParentProcessId(out var parentId))
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        var parent = Process.GetProcessById(parentId);
        var target = sleepers.Start(name);
        var targetId = target.Id;

        // Act (the parent is passed as a Process, never by name, so no other process with its name is touched;
        // Kill(entireProcessTree: true) refuses a tree that contains the calling process)
        _ = await Assert.ThrowsAsync<InvalidOperationException>(() => new[] { parent, target }.KillAndDispose());

        // Assert
        using var stillRunningParent = Process.GetProcessById(parentId);

        Assert.False(stillRunningParent.HasExited);

        try
        {
            using var stillRunning = Process.GetProcessById(targetId);

            Assert.True(stillRunning.ProcessName != name || stillRunning.WaitForExit(ExitTimeout));
        }
        catch (ArgumentException)
        {
            // The process no longer exists.
        }
    }

    [Fact]
    public async Task KillAndDispose_CurrentProcessWithoutTree_IsSkipped_Process()
    {
        // Arrange
        var current = Process.GetCurrentProcess();

        // Act (Kill() on the calling process would end the test run)
        var exception = await Record.ExceptionAsync(() => new[] { current }.KillAndDispose(entireProcessTree: false));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public async Task KillAllProcessesByName_EntireProcessTreeFalse_LeavesChildRunning_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsShellSupported)
        {
            return;
        }

        var parentName = SleepProcesses.UniqueName("yp");
        var childName = SleepProcesses.UniqueName("yc");
        var (parent, childId) = sleepers.StartParentWithChild(parentName, childName);

        using (parent)
        {
            // Act
            await parentName.KillAllProcessesByName(entireProcessTree: false);

            // Assert (the child is killed by the fixture afterwards)
            Assert.True(parent.WaitForExit(ExitTimeout));
            Assert.True(SleepProcesses.IsRunning(childId, childName), sleepers.Diagnostics());
        }
    }

    [Fact]
    public async Task KillAllProcessesByName_EntireProcessTreeTrue_KillsChild_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsShellSupported)
        {
            return;
        }

        var parentName = SleepProcesses.UniqueName("yp");
        var childName = SleepProcesses.UniqueName("yc");
        var (parent, childId) = sleepers.StartParentWithChild(parentName, childName);

        using (parent)
        {
            // Act
            await parentName.KillAllProcessesByName(entireProcessTree: true, CancellationToken.None);

            // Assert
            Assert.True(parent.WaitForExit(ExitTimeout));
            Assert.True(SleepProcesses.WaitUntilStopped(childId, childName));
        }
    }

    [Fact]
    public async Task KillAllProcessesByNames_EntireProcessTreeFalse_LeavesChildRunning_ProcessCollection()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsShellSupported)
        {
            return;
        }

        var parentName = SleepProcesses.UniqueName("yp");
        var childName = SleepProcesses.UniqueName("yc");
        var (parent, childId) = sleepers.StartParentWithChild(parentName, childName);
        List<string?> names = [null, parentName];

        using (parent)
        {
            // Act
            await names.KillAllProcessesByNames(entireProcessTree: false);

            // Assert
            Assert.True(parent.WaitForExit(ExitTimeout));
            Assert.True(SleepProcesses.IsRunning(childId, childName), sleepers.Diagnostics());
        }
    }

    [Fact]
    public async Task KillAllProcessesByNames_EntireProcessTreeTrue_KillsChild_ProcessCollection()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsShellSupported)
        {
            return;
        }

        var parentName = SleepProcesses.UniqueName("yp");
        var childName = SleepProcesses.UniqueName("yc");
        var (parent, childId) = sleepers.StartParentWithChild(parentName, childName);

        using (parent)
        {
            // Act
            await new[] { parentName }.KillAllProcessesByNames(entireProcessTree: true);

            // Assert
            Assert.True(parent.WaitForExit(ExitTimeout));
            Assert.True(SleepProcesses.WaitUntilStopped(childId, childName));
        }
    }

    [Fact]
    public async Task KillAllProcessesByName_AlreadyCanceledToken_ThrowsOperationCanceledExceptionAndKillsNothing_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        using var process = sleepers.Start(name);
        using var cts = new CancellationTokenSource();

        cts.Cancel();

        // Act & Assert
        _ = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => name.KillAllProcessesByName(cts.Token));
        _ = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => name.KillAllProcessesByName(entireProcessTree: false, cts.Token));
        _ = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => new[] { name }.KillAllProcessesByNames(cts.Token));
        Assert.True(SleepProcesses.IsRunning(process.Id, name));
    }

    [Fact]
    public async Task KillAllProcessesByNames_NullNamesWithAlreadyCanceledToken_ThrowsOperationCanceledException_ProcessCollection()
    {
        // Arrange
        IEnumerable<string?>? names = null;
        using var cts = new CancellationTokenSource();

        cts.Cancel();

        // Act & Assert
        _ = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => names.KillAllProcessesByNames(cts.Token));
    }

    [Fact]
    public async Task KillAllProcessesByNames_TokenCanceledBeforeANameIsLookedUp_StillKillsItsProcesses_ProcessCollection()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        using var process = sleepers.Start(name);
        using var cts = new CancellationTokenSource();

        // Act (the token is not canceled when the method is called; the names cancel it before the target is looked up)
        var exception = await Record.ExceptionAsync(() => CancelBetween(SleepProcesses.UniqueName("yn"), cts, name).KillAllProcessesByNames(cts.Token));

        // Assert (only the wait is canceled: it throws unless the process has already exited)
        Assert.True(cts.IsCancellationRequested);
        Assert.True(exception is null or OperationCanceledException);
        Assert.True(SleepProcesses.WaitUntilStopped(process.Id, name));
    }

    [Fact]
    public async Task KillAllProcessesByNames_TokenCanceledAfterCallStartsAndNothingMatches_DoesNotThrow_ProcessCollection()
    {
        // Arrange
        using var cts = new CancellationTokenSource();

        // Act (the token is not canceled when the method is called; the names cancel it, and no process has either name)
        var exception = await Record.ExceptionAsync(() => CancelBetween(SleepProcesses.UniqueName("yn"), cts, SleepProcesses.UniqueName("yn")).KillAllProcessesByNames(cts.Token));

        // Assert (a token canceled after the call has started only stops a wait, and there is nothing to wait for)
        Assert.True(cts.IsCancellationRequested);
        Assert.Null(exception);
    }

    [Fact]
    public async Task KillAndDispose_AlreadyCanceledToken_KillsNothingAndDisposesHandles_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsSupported)
        {
            return;
        }

        var name = SleepProcesses.UniqueName();
        var target = sleepers.Start(name, new DisposeTrackingProcess());
        var targetId = target.Id;
        using var cts = new CancellationTokenSource();

        cts.Cancel();

        // Act
        _ = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => new[] { target }.KillAndDispose(cancellationToken: cts.Token));

        // Assert
        Assert.True(target.IsDisposed);
        Assert.True(SleepProcesses.IsRunning(targetId, name));
    }

    [Fact]
    public async Task KillAllProcessesByName_CanceledWhileWaiting_ThrowsOperationCanceledException_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsShellSupported)
        {
            return;
        }

        var zombieName = SleepProcesses.UniqueName("yz");

        _ = sleepers.StartZombie(SleepProcesses.UniqueName("yh"), zombieName);

        using var cts = new CancellationTokenSource();

        // Act (the zombie is signalled but never exits while its parent runs, so only the cancellation ends the wait)
        var kill = zombieName.KillAllProcessesByName(cts.Token);

        cts.Cancel();

        // Assert (the guard only fails the test if cancellation is never observed)
        Assert.Same(kill, await Task.WhenAny(kill, Task.Delay(ExitTimeout)));
        _ = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => kill);
    }

    [Fact]
    public async Task KillAndDispose_CanceledWhileWaitingForProcessThatDoesNotExit_StillKillsAndDisposesTheOthers_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsShellSupported)
        {
            return;
        }

        var zombieName = SleepProcesses.UniqueName("yz");

        _ = sleepers.StartZombie(SleepProcesses.UniqueName("yh"), zombieName);

        var zombie = Assert.Single(Process.GetProcessesByName(zombieName));
        var name = SleepProcesses.UniqueName();
        var target = sleepers.Start(name, new DisposeTrackingProcess());
        using var observer = Process.GetProcessById(target.Id);
        using var cts = new CancellationTokenSource();

        // Act (every process is signalled before the first wait, which never ends for the zombie)
        var kill = new[] { zombie, target }.KillAndDispose(cancellationToken: cts.Token);

        cts.Cancel();

        // Assert
        Assert.Same(kill, await Task.WhenAny(kill, Task.Delay(ExitTimeout)));
        _ = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => kill);
        Assert.True(target.IsDisposed);
        Assert.True(observer.WaitForExit(ExitTimeout));
    }

    [Fact]
    public async Task KillAndDispose_FailureAndCanceledWait_RethrowsTheFailure_Process()
    {
        // Arrange
        using var sleepers = new SleepProcesses();

        if (!sleepers.IsShellSupported)
        {
            return;
        }

        var zombieName = SleepProcesses.UniqueName("yz");

        _ = sleepers.StartZombie(SleepProcesses.UniqueName("yh"), zombieName);

        var failing = new DisposeTrackingProcess();
        var zombie = Assert.Single(Process.GetProcessesByName(zombieName));
        using var cts = new CancellationTokenSource();

        // Act (a Process that was never started has no Id: reading it throws InvalidOperationException before the wait is canceled)
        var kill = new[] { failing, zombie }.KillAndDispose(cancellationToken: cts.Token);

        cts.Cancel();

        // Assert
        Assert.Same(kill, await Task.WhenAny(kill, Task.Delay(ExitTimeout)));
        _ = await Assert.ThrowsAsync<InvalidOperationException>(() => kill);
        Assert.True(failing.IsDisposed);
    }

    [Theory]
    [InlineData("some/directory/")]
    [InlineData("/")]
    [InlineData(".exe")]
    [InlineData("   ")]
    public void GetProcessesByFileName_NoFileNameLeft_ReturnsNoProcesses_Process(string processNameOrPath)
    {
        // Arrange & Act (Process.GetProcessesByName("") would return every process)
        var processes = processNameOrPath.GetProcessesByFileName();

        // Assert
        Assert.Empty(processes);
    }

    [Fact]
    public void GetProcessesByFileName_NonExistentName_ReturnsNoProcesses_Process()
        // Arrange & Act & Assert
        => Assert.Empty(SleepProcesses.UniqueName("yn.").GetProcessesByFileName());

    #endregion
}
